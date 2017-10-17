using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AssemblyInfo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                Assembly asm = null;
                var name = args[0];
                var switches = "";

                for (var i = 1; i < args.Length; i++)
                {
                    switches += args[i].ToLower().Replace('-', ' ').Trim();
                }

                var showAll = switches.Contains('a');
                var showModules = switches.Contains('m') || showAll;
                var showExportedTypes = switches.Contains('e') || showAll;
                var showTypes = switches.Contains('t') || showAll;
                var showReferencedAssemblies = switches.Contains('r') || showAll;
                var showInfo = switches.Contains('i') || string.IsNullOrEmpty(switches) || showAll;
                var toJson = switches.Contains('j');
                var toXml = switches.Contains('x');
                var generateOutput = switches.Contains('o');
                var result = new AssemblyInfoResult();

                try
                {
                    if (name.Substring(name.Length - 4, 4) != ".dll")
                    {
                        name += ".dll";
                    }

                    asm = Assembly.LoadFrom(name);
                }
                catch
                {
                    try
                    {
                        var path = AppDomain.CurrentDomain.BaseDirectory + @"\" + name;

                        asm = Assembly.LoadFrom(path);
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);

                        return;
                    }
                }

                var x = asm.GetName();

                if (showInfo)
                {
                    if (generateOutput)
                    {
                        result.CodeBase = x.CodeBase;
                        result.ContentType = x.ContentType.ToString();
                        result.CultureInfo = x.CultureInfo.ToString();
                        result.CultureName = x.CultureName;
                        result.FullName = x.FullName;
                        result.Name = x.Name;
                        result.Version = x.Version.ToString();
                        result.VersionCompatibility = x.VersionCompatibility.ToString();
                        result.Naming = (x.GetPublicKeyToken() == null) ? "Weak" : "Strong"; 
                    }

                    System.Console.WriteLine("CodeBase: {0}", x.CodeBase);
                    System.Console.WriteLine("ContentType: {0}", x.ContentType);
                    System.Console.WriteLine("CultureInfo: {0}", x.CultureInfo);
                    System.Console.WriteLine("CultureName: {0}", x.CultureName);
                    System.Console.WriteLine("FullName: {0}", x.FullName);
                    System.Console.WriteLine("Name: {0}", x.Name);
                    System.Console.WriteLine("Version: {0}", x.Version);
                    System.Console.WriteLine("VersionCompatibility: {0}", x.VersionCompatibility);
                    System.Console.WriteLine("Naming: {0}", (x.GetPublicKeyToken() == null) ? "Weak" : "Strong"); 
                }

                if (showModules)
                {
                    System.Console.WriteLine("\nModules");
                    var modules = asm.GetModules().OrderBy(m => m.Name);
                    result.Modules = modules.Select(t => t.Name).ToList();

                    foreach (var module in modules)
                    {
                        System.Console.WriteLine("  " + module.Name);
                    }
                }

                if (showExportedTypes)
                {
                    System.Console.WriteLine("\nExported Types");
                    var types = asm.GetExportedTypes().OrderBy(t => t.Name);
                    result.ExportedTypes = types.Select(t => t.Name).ToList();

                    foreach (var type in types)
                    {
                        System.Console.WriteLine("  " + type.Name);
                    } 
                }

                if (showTypes)
                {
                    System.Console.WriteLine("\nTypes");
                    var types = asm.GetTypes().OrderBy(t => t.Name);
                    result.Types = types.Select(t => t.Name).ToList();

                    foreach (var type in types)
                    {
                        System.Console.WriteLine("  " + type.Name);
                    } 
                }

                if (showReferencedAssemblies)
                {
                    System.Console.WriteLine("\nReferenced Assemblies");
                    var referencedAssemblies = asm.GetReferencedAssemblies().OrderBy(n => n.Name);
                    result.ReferencedAssemblies = types.Select(t => t.Name).ToList();
                    
                    foreach (var a in referencedAssemblies)
                    {
                        System.Console.WriteLine("  " + a.Name);
                    } 
                }

                if (generateOutput)
                {
                    var filename = System.Environment.CurrentDirectory + "\\" + x.Name;
                    var output = "";

                    if (toJson)
                    {
                        filename += ".json";
                        output = result.ToJson();
                    }
                    else if (toXml)
                    {
                        filename += ".xml";
                        output = result.ToXml();
                    }
                    else
                    {
                        System.Console.WriteLine("No output format specified. Use -j or -x to specify Json or Xml format respectively");
                    }

                    if (!string.IsNullOrEmpty(output))
                    {
                        try
                        {
                            File.WriteAllText(filename, output);
                            System.Console.WriteLine("json output created");
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine("Creating output failed");
                            System.Console.WriteLine(e.Message);
                        }
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Usage: asminfo.exe assembly [arg [arg] ...]");
                System.Console.WriteLine("arg:");
                System.Console.WriteLine("\t-a: Display all");
                System.Console.WriteLine("\t-i: Display Assembly information");
                System.Console.WriteLine("\t-m: Display Modules");
                System.Console.WriteLine("\t-e: Display Exported Types");
                System.Console.WriteLine("\t-t: Display Types");
                System.Console.WriteLine("\t-r: Display Referenced Assemblies\n");
                System.Console.WriteLine("\t-o: Create output file\n");
                System.Console.WriteLine("\t-j: Use JSON for ourput file\n");
                System.Console.WriteLine("\t-x: Use XML for ourput file\n");
                System.Console.WriteLine("Arguments can be merged together");
                System.Console.WriteLine("Example:\nasminfo.exe MyLib.dll -imt");
            }
        }
    }
}
