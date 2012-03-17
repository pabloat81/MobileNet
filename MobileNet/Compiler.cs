using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileNet.Config;
using System.IO;

namespace MobileNet
{
    public class Compiler
    {
        const string ASSETS = "ASSETS/";
        
        IStatusInformer Logger;

        public Compiler(IStatusInformer logger)
        {
            Logger = logger;
        }

        void CopyAssets(Config.Config config, string buildAssetsDir)
        {
            string from = config.AppPath + "\\images";
            string to = buildAssetsDir;

            CopyFolder(from, to);
        }

        void CopyIndexHTML(Config.Config config, string absoluteWWWDir, string relativeAssetsDir)
        {
            string sourceHtmlFilename = config.AppPath + "\\index.html";
            string destHtmlFilename = absoluteWWWDir + "\\index.html";

            if (File.Exists(destHtmlFilename))
                File.Delete(destHtmlFilename);

            StreamReader sr = new StreamReader(sourceHtmlFilename);
            string indexcontent = sr.ReadToEnd().Replace(ASSETS, string.IsNullOrEmpty(relativeAssetsDir) ? "" : ("./" + relativeAssetsDir) + "/");
            sr.Close();

            StreamWriter sw = new StreamWriter(destHtmlFilename);
            sw.Write(indexcontent);
            sw.Close();
        } 

        void CopyFolder(string from, string to)
        {
            if (from.Contains(".svn"))
                return;

            if (!Directory.Exists(to))
                Directory.CreateDirectory(to);

            string[] files = Directory.GetFiles(from);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(to, name);

                if (File.Exists(dest))
                    File.Delete(dest);

                File.Copy(file, dest);
            }
            string[] folders = Directory.GetDirectories(from);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(to, name);
                CopyFolder(folder, dest);
            }
        }

        void AddContent(string vendorDir, List<string> paths, StreamWriter writer, string relativeAssetsDir)
        {
            foreach (string sourcePath in paths)
            {
                string path = vendorDir + "\\" + sourcePath;

                string content = ReadContentAndReplaceAssetsDir(path, relativeAssetsDir);

                writer.WriteLine();
                writer.Write(content);
            }
        }

        private string ReadContentAndReplaceAssetsDir(string sourcePath, string relativeAssetsDir)
        {
            StreamReader sr = new StreamReader(sourcePath);
            string content = sr.ReadToEnd().Replace(ASSETS, string.IsNullOrEmpty(relativeAssetsDir) ? "" : ("./" + relativeAssetsDir + "/"));
            sr.Close();

            return content;
        }

        void CompileAppFiles(OutputFile output, string originalSourceDir, string sourceDir, StreamWriter writer, string relativeAssetsDir)
        {
            if (sourceDir.Contains(".svn"))
                return;

            string[] files = Directory.GetFiles(sourceDir);
            string defineRequireTemplate = "(this.require.define({\n'{moduleName}': function(exports, require, module) {\n{content}\n}}));\n";

            foreach (string file in files)
            {
                string path = Path.GetFullPath(file);

                if (output.Compilers.Where(c => path.Contains(c.Extension)).Count() == 0)
                    continue;

                string moduleName = path.Replace(originalSourceDir, "").Replace(Path.GetExtension(file), "");
                if (moduleName.StartsWith("\\"))
                    moduleName = moduleName.Substring(1).Replace("\\", "/");

                string content = ReadContentAndReplaceAssetsDir(path, relativeAssetsDir);

                string compileCommand = output.Compilers.Where(c => path.Contains(c.Extension)).Select(c => c.CompileCommand).FirstOrDefault();
                
                if(!string.IsNullOrEmpty(compileCommand))
                {
                    string command = "";
                    if(compileCommand.Contains("{filename}"))
                        command = compileCommand.Replace("{filename}", path);
                    else if(compileCommand.Contains("{data}"))
                        command = compileCommand.Replace("{data}", "'\"" + content + "\"'");
                    content = this.ExecuteCommandSync(command, false);
                }

                if (output.RelativeFilename.Contains(".js"))
                    content = defineRequireTemplate.Replace("{moduleName}", moduleName).Replace("{content}", content);

                writer.Write(content);
            }

            string[] folders = Directory.GetDirectories(sourceDir);
            foreach (string folder in folders)
            {
                CompileAppFiles(output, originalSourceDir, folder, writer, relativeAssetsDir);
            }
        }

        void AddRequireContent(OutputFile output, StreamWriter writer)
        {
            if (!output.RelativeFilename.Contains(".js"))
                return;

            string sourceFilename = Directory.GetCurrentDirectory() + "\\requireDefinition.js";

            StreamReader sr = new StreamReader(sourceFilename);
            string requirecontent = sr.ReadToEnd();
            sr.Close();
                        
            writer.Write(requirecontent);
        }

        public void Compile(Config.Config config)
        {
            foreach (Platform platform in config.Platforms)
            {
                string AbsoluteAssetsDir = string.Format("{0}\\{1}\\{2}", config.BuildPath, platform.Name, platform.AssetsDir);
                CopyAssets(config, AbsoluteAssetsDir);

                string AbsoluteWWWDir = string.Format("{0}\\{1}\\{2}", config.BuildPath, platform.Name, platform.WWWDir);
                CheckExistenceOrCreateDir(AbsoluteWWWDir);

                Logger.Log("Copying index.html...");
                CopyIndexHTML(config, AbsoluteWWWDir, platform.AssetsDir);
                
                foreach (OutputFile output in config.Outputs)
                {
                    Logger.Log(string.Format("Compiling {0} file...", output.RelativeFilename));
                    Logger.ResetProgress();
                    Logger.AddProgress(20);

                    string outputFileName = AbsoluteAssetsDir + "\\" + output.RelativeFilename;

                    if (File.Exists(outputFileName))
                        File.Delete(outputFileName);

                    StreamWriter writer = new StreamWriter(outputFileName);

                    AddRequireContent(output, writer);
                    Logger.AddProgress(10);

                    AddContent(config.VendorPath, output.BeforeLibs, writer, platform.AssetsDir);
                    Logger.Log("Adding pre-required vendor Libs/styles...");
                    Logger.AddProgress(20);

                    Logger.Log("compiling Routers/Views/Models/Collections/others...");
                    CompileAppFiles(output, config.AppPath, config.AppPath, writer, platform.AssetsDir);
                    Logger.AddProgress(30);

                    Logger.Log("Adding post-required vendor Libs/styles...");
                    AddContent(config.VendorPath, output.AfterLibs, writer, platform.AssetsDir);
                    Logger.AddProgress(20);

                    writer.Close();
                }
            }
        }      

        private void CheckExistenceOrCreateDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void CreateFile(string path)
        {
            if (File.Exists(path))            
                File.Delete(path);
            
            File.Create(path);
        }

        public static string ExecuteCommandSyncStatic(string command, bool useShellWindow)
        {
            Compiler c = new Compiler(new DefaultStatusInformer());
            return c.ExecuteCommandSync(command, useShellWindow);
        }

        public string ExecuteCommandSync(string command, bool useShellWindow)
        {
            // create the ProcessStartInfo using "cmd" as the program to be run,
            // and "/c " as the parameters.
            // Incidentally, /c tells cmd that we want it to execute the command that follows,
            // and then exit.
            System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            procStartInfo.RedirectStandardOutput = true;

            procStartInfo.RedirectStandardError = true;

            procStartInfo.UseShellExecute = useShellWindow;
            // Do not create the black window.
            procStartInfo.CreateNoWindow = !useShellWindow;

            procStartInfo.RedirectStandardOutput = !useShellWindow;
            procStartInfo.RedirectStandardInput = !useShellWindow;
            procStartInfo.RedirectStandardError = !useShellWindow;

            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            // Get the output into a string

            if (!useShellWindow)
            {
                string result = proc.StandardOutput.ReadToEnd();

                if (string.IsNullOrEmpty(result))
                {
                    string error = proc.StandardError.ReadToEnd();
                    Logger.LogError(error);
                    if (!string.IsNullOrEmpty(error))
                        throw new Exception(error);
                }
                
                return result;
            }

            return "";
        }        
    }
}
