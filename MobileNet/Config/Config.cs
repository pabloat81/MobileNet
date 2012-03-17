using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MobileNet.Config
{
    [Serializable]
    public class Config
    {
        public string RootPath { get; set; }
        public string BuildPath { get; set; }
        public string VendorPath { get; set; }
        public string AppPath { get; set; }
        public string TestsPath { get; set; }

        public string ServerPort { get; set; }
        public string ServerWWWPath{ get; set; }

        public List<string> RequiredNodePlugins { get; set; }         
        public List<OutputFile> Outputs { get; set; }
        public List<Platform> Platforms { get; set; }
        
        public Config()
        {
            Outputs = new List<OutputFile>();
            RequiredNodePlugins = new List<string>();
            Platforms = new List<Platform>();
        }

        public void Serialize(string filename)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            StreamWriter writer = new StreamWriter(filename);
            x.Serialize(writer, this);
            writer.Close();
        }

        public Config DeSerialize(string filename)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            FileStream fileStream = new FileStream(filename, FileMode.Open);

            var ret = (Config) x.Deserialize(fileStream);

            fileStream.Close();

            return ret;
        }
    }
}
