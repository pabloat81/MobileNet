using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileNet.Config
{
    [Serializable]
    public class Platform
    {
        public string Name { get; set; }
        public string WWWDir { get; set; }
        public string AssetsDir { get; set; }        
    }
}
