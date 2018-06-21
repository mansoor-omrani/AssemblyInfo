# AssemblyInfo
This tiny console application shows properties of an assembly that it recieves its name as a command line argument.
```
> asminfo.exe assemblyNameOrPath [arg [arg] ...]
arg:
        -a: Display all
        -i: Display Assembly information
        -m: Display Modules
        -e: Display Exported Types
        -t: Display Types
        -r: Display Referenced Assemblies
        -s: Display resources
        -o: Create output file
        -j: Use JSON for ourput file
        -x: Use XML for ourput file
Arguments can be merged together
Example:
asminfo.exe MyLib.dll -imt
```
You can specify just the name of the assembly. The tool tries to load it from the current directory (where it is invoked from). If the assembly resides in another directory, you need to specify its path as well.
The tool assumes assemblies are ended with ".dll" by defualt. So, you can ommit ".dll" from the name of the assembly.

Example (assuming the path of the tool is included in the PATH environment):

invoking from the directory where the intended assembly resides:
```
C:\MyApp\>asminfo MyLib.dll
C:\MyApp\>asminfo MyLib
C:\MyApp\>asminfo MyCompany.MyApp.MyLib.dll
C:\MyApp\>asminfo MyCompany.MyApp.MyLib
```
invoking from another directory:
```
D:\>asminfo.exe C:\MyApp\Bin\MyLib.dll
```
If your path contains space character, surround the argument with quote character.
```
asminfo.exe "C:\My App\MyLib.dll"
```
This is a sample result of the tool:
```
C:\>asminfo "C:\Users\Mansoor\Documents\Visual Studio 2015\Projects\MyWebApp\MyWebApp.Service\bin\Release\MyWebApp.Service.dll"
CodeBase: file:///C:/Users/Mansoor/Documents/Visual Studio 2015/Projects/MyWebApp/MyWebApp.Service/bin/Release/MyWebApp.Service.dll
ContentType: Default
CultureInfo: 
CultureName: 
FullName: MyWebApp.Service, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
Name: MyWebApp.Service
Version: 1.0.0.0
VersionCompatibility: SameMachine
Naming: Strong

Modules
    MyWebApp.Service.dll

Exported Types
    IPhotoService
    PhotoService

Types
    IPhotoService
    PhotoService
    <>c__DisplayClass1_0

Referenced Assemblies
    mscorlib
    MyWebApp.Models
    System.Xml
C:\>
```
