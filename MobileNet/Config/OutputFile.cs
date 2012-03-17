using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileNet.Config
{
    [Serializable]
    public class OutputFile
    {        
        public string RelativeFilename  { get; set; }

        public List<LanguageCompilerInfo> Compilers { get; set; }

        public List<string> BeforeLibs { get; set; }
        public List<string> AfterLibs { get; set; }

        public OutputFile()
        {
            Compilers = new List<LanguageCompilerInfo>();
            BeforeLibs = new List<string>();
            AfterLibs = new List<string>();
        }
    }
}
