using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestMobileBuilder
{
    [Serializable]
    public class MBConfig
    {
        public List<string> RecentProjects { get; set; }

        public void Serialize(string filename)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            StreamWriter writer = new StreamWriter(filename);
            x.Serialize(writer, this);
            writer.Close();
        }

        public MBConfig DeSerialize(string filename)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(this.GetType());
            FileStream fileStream = new FileStream(filename, FileMode.Open);

            var ret = (MBConfig)x.Deserialize(fileStream);

            fileStream.Close();

            return ret;
        }
    }
}
