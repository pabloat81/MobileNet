using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MobileNet.Config;

namespace MobileNet
{
    public class Commands
    {
        Config.Config MobileNetConfig;
        FileSystemWatcher _VendorWatcher = null;
        FileSystemWatcher _AppWatcher = null;
        
        public IStatusInformer Logger { get; set; }

        public event EventHandler OnCompilationStarted;
        public event EventHandler OnCompilationEnded;

        Compiler compiler;

        public Commands(IStatusInformer logger, string rootPath, string buildPath)
        {
            compiler = new Compiler(logger);
            Logger = logger;
            
            var config = new Config.Config();
            MobileNetConfig = config.DeSerialize(Directory.GetCurrentDirectory() + "\\MobileNet.config");
            ChangeRootPath(rootPath, buildPath);
        }

        public Commands(IStatusInformer logger, FileSystemWatcher vendorWatcher, FileSystemWatcher appWatcher, string rootPath, string buildPath)
            : this(logger, rootPath, buildPath)
        {
            _VendorWatcher = vendorWatcher;
            _AppWatcher = appWatcher;
        }

        public void ChangeRootPath(string rootPath)
        {
            ChangeRootPath(rootPath, null);
        }

        public void ChangeRootPath(string rootPath, string buildPath)
        {
            MobileNetConfig.RootPath = string.IsNullOrEmpty(rootPath) ? Directory.GetCurrentDirectory() : rootPath;
            MobileNetConfig.BuildPath = string.IsNullOrEmpty(buildPath) ? MobileNetConfig.RootPath + "\\build" : buildPath;
            MobileNetConfig.VendorPath = MobileNetConfig.RootPath; // +"\\vendor";
            MobileNetConfig.AppPath = MobileNetConfig.RootPath + "\\app";
            MobileNetConfig.TestsPath = MobileNetConfig.RootPath + "\\spec";
        }

        /// <summary>
        /// Compiles all files in current working directory.
        /// </summary>
        /// <param name="rootPath">Path to application directory</param>                
        /// <param name="config">Config class</param>
        public void Build(bool startServer)
        {
            Watch(false, startServer);
        }
                
        /// <summary>
        /// Recompiles all files in current working directory.
        /// </summary>
        /// <param name="rootPath">Path to application directory</param>                
        /// <param name="config">Should watcher be stopped after compiling the app first time?</param>
        public void Watch(bool persistent, bool startServer)
        {
            Logger.ClearLog();

            bool ok = CompileApplication();

            if (!ok) return;

            if (persistent)
            {
                Logger.Log("Watching App and vendor directories...");
                _VendorWatcher = GetWatcher(MobileNetConfig.VendorPath);
                _AppWatcher = GetWatcher(MobileNetConfig.AppPath);
                //FileSystemWatcher testWatcher = GetWatcher(config.TestsPath);
            }            
            
            if (startServer)            
                StartServer();             
        }

        public bool ServerCanBeStarted
        {
            get 
            {
                return MobileNetConfig != null;
            }
        }

        public void StartServer()
        {
            compiler.ExecuteCommandSync(string.Format("node ./plugins/expressServer.js {0} {1}\\WWW",
                                            MobileNetConfig.ServerPort,
                                            MobileNetConfig.BuildPath), true);
            Logger.Log("Server is Running on http://localhost:" + (MobileNetConfig.ServerPort ?? "4000"));
        }

        bool CompileApplication()
        {
            if (OnCompilationStarted != null)
                OnCompilationStarted(this, new EventArgs());

            Logger.LogAndNotify("Build Started...", false);

            try
            {
                compiler.Compile(MobileNetConfig);

                Logger.LogAndNotify("Build Succeded...", false);
            }
            catch (Exception ex)
            {
                Logger.LogAndNotify("Build Failed..." + Environment.NewLine + ex.Message, true);
                return false;
            }

            if (OnCompilationEnded != null)
                OnCompilationEnded(this, new EventArgs());

            return true;
        }

        void WatcherEvents(object sender, FileSystemEventArgs e)
        {
            _VendorWatcher.EnableRaisingEvents = false;
            _AppWatcher.EnableRaisingEvents = false;            
            CompileApplication();
            _VendorWatcher.EnableRaisingEvents = true;
            _AppWatcher.EnableRaisingEvents = true;
        }       

        FileSystemWatcher GetWatcher(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
                       
            watcher.Path = path;
            watcher.Filter = "*.*";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            watcher.NotifyFilter = NotifyFilters.FileName |
                       NotifyFilters.Attributes |
                       NotifyFilters.LastWrite |
                       NotifyFilters.Security |
                       NotifyFilters.Size;

            watcher.Renamed += new RenamedEventHandler(WatcherEvents);
            watcher.Created += new FileSystemEventHandler(WatcherEvents);
            watcher.Changed += new FileSystemEventHandler(WatcherEvents);
            watcher.Deleted += new FileSystemEventHandler(WatcherEvents);

            return watcher;
        }        
    }
}
