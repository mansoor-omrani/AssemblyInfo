# AssemblyInfo
This tiny console application shows properties of an assembly that it recieves its name as a command line argument.

Usage:
> asminfo.exe assemblyNameOrPath

You can specify just the name of the assembly. The tool tries to load it from the current directory (where it is invoked from). If the assembly resides in another directory, you need to specify its path as well.
The tool assumes assemblies are ended with ".dll" by defualt. So, you can ommit ".dll" from the name of the assembly.

Example (assuming the path of the tool is included in the PATH environment):

invoking from the directory where the intended assembly resides:

C:\MyApp\>asminfo MyLib.dll
C:\MyApp\>asminfo MyLib
C:\MyApp\>asminfo MyCompany.MyApp.MyLib.dll
C:\MyApp\>asminfo MyCompany.MyApp.MyLib

invoking from another directory:

D:\>asminfo.exe C:\MyApp\Bin\MyLib.dll

If your path contains space character, surround the argument with quote character.

asminfo.exe "C:\My App\MyLib.dll"

This is a sample result of the tool:

C:\>asminfo "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\System.dll"<br/>
CodeBase: file:///C:/Windows/Microsoft.Net/assembly/GAC_MSIL/System/v4.0_4.0.0.0__b77a5c561934e089/System.dll<br/>
ContentType: Default<br/>
CultureInfo:<br/>
CultureName:<br/>
FullName: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<br/>
Name: System<br/>
Version: 4.0.0.0<br/>
VersionCompatibility: SameMachine<br/>
<br/>
C:\><br/>
