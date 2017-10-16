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
        private List<string> exportedTypes;
        public List<string> ExportedTypes
        {
            get
            {
                if (exportedTypes == null)
                    exportedTypes = new List<string>();
                
                return exportedTypes;
            }
        }
        private List<string> types;
        public List<string> Types
        {
            get
            {
                if (types == null)
                    types = new List<string>();

                return types;
            }
        }
        public string ToJson()
        {
            var _types = string.Join(",", Types.ToArray());

            return
$@"
{{
    ""CodeBase"": ""{CodeBase}"",
    ""ContentType"": ""{ContentType}"",
    ""CultureInfo"": ""{CultureInfo}"",
    ""CultureName"": ""{CultureName}"",
    ""FullName"": ""{FullName}"",
    ""Name"": ""{Name}"",
    ""Version"": ""{Version}"",
    ""VersionCompatibility"": ""{VersionCompatibility}"",
    ""Naming"": ""{Naming}"",
    ""Types"": {_types}
}}";
        }
    }
}
