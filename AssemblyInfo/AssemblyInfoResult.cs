using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfo
{
    public class AssemblyInfoResult
    {
        public string CodeBase { get; set; }
        public string ContentType { get; set; }
        public string CultureInfo { get; set; }
        public string CultureName { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string VersionCompatibility { get; set; }
        public string Naming { get; set; }

        public string ToJson()
        {
            return "{}";
        }
    }
}
