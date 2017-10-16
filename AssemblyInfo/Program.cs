using System;
using System.Reflection;

namespace AssemblyInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                Assembly asm = null;
                var name = args[0];

                try
                {
                    if (name.Substring(name.Length - 4, 4) != ".dll")
                        name += ".dll";

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

                System.Console.WriteLine("CodeBase: {0}", x.CodeBase);
                System.Console.WriteLine("ContentType: {0}", x.ContentType);
                System.Console.WriteLine("CultureInfo: {0}", x.CultureInfo);
                System.Console.WriteLine("CultureName: {0}", x.CultureName);
                System.Console.WriteLine("FullName: {0}", x.FullName);
                System.Console.WriteLine("Name: {0}", x.Name);
                System.Console.WriteLine("Version: {0}", x.Version);
                System.Console.WriteLine("VersionCompatibility: {0}", x.VersionCompatibility);
            }
            else
            {
                System.Console.WriteLine("Usage: asminfo.exe assembly");
            }
        }
    }
}
