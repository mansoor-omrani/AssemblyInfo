using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

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
        private List<string> modules;
        public List<string> Modules
        {
            get
            {
                if (modules == null)
                    modules = new List<string>();

                return modules;
            }
            set { modules = value; }
        }
        private List<string> exportedTypes;
        public List<string> ExportedTypes
        {
            get
            {
                if (exportedTypes == null)
                    exportedTypes = new List<string>();
                
                return exportedTypes;
            }
            set { exportedTypes = value; }
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
            set { types = value; }
        }
        private List<string> referencedAssemblies;
        public List<string> ReferencedAssemblies
        {
            get
            {
                if (referencedAssemblies == null)
                    referencedAssemblies = new List<string>();

                return referencedAssemblies;
            }
            set { referencedAssemblies = value; }
        }
        private string ToJsonProperty(List<string> list, string name)
        {
            var x = string.Join(@""",""", list.ToArray());

            return (list.Count > 0)? $@",\n\t""{name}"": [""{x}""]" : "";
        }
        public string ToJson()
        {
            var _modules = ToJsonProperty(Modules, "Modules");
            var _types = ToJsonProperty(Types, "Types");
            var _exportedTypes = ToJsonProperty(ExportedTypes, "Types");
            var _referencedAssemblies = ToJsonProperty(ReferencedAssemblies, "Types");
            
            return
$@"{{
    ""CodeBase"": ""{CodeBase}"",
    ""ContentType"": ""{ContentType}"",
    ""CultureInfo"": ""{CultureInfo}"",
    ""CultureName"": ""{CultureName}"",
    ""FullName"": ""{FullName}"",
    ""Name"": ""{Name}"",
    ""Version"": ""{Version}"",
    ""VersionCompatibility"": ""{VersionCompatibility}"",
    ""Naming"": ""{Naming}""{_modules}{_exportedTypes}{_types}{_referencedAssemblies}
}}";
        }

        public string ToXml()
        {
            var xsSubmit = new XmlSerializer(this.GetType());
            var result = "";

            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    xsSubmit.Serialize(writer, this);
                    result = sw.ToString();
                }
            }

            return result;
        }
    }
}
