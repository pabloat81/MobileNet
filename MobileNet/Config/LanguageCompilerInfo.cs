using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileNet.Config
{
    [Serializable]
    public class LanguageCompilerInfo
    {
        public string Extension { get; set; }
        public string CompilerName { get; set; }
        public string CompileCommand { get; set; }
    }
}
