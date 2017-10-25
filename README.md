# AssemblyInfo
This tiny console application shows properties of an assembly that it recieves its name as a command line argument.
```
> asminfo.exe assemblyNameOrPath [arg [arg] ...]<br/>
arg:<br/>
        -a: Display all<br/>
        -i: Display Assembly information<br/>
        -m: Display Modules<br/>
        -e: Display Exported Types<br/>
        -t: Display Types<br/>
        -r: Display Referenced Assemblies<br/>
        -o: Create output file<br/>
        -j: Use JSON for ourput file<br/>
        -x: Use XML for ourput file<br/>
Arguments can be merged together<br/>
Example:<br/>
asminfo.exe MyLib.dll -imt<br/>
```
You can specify just the name of the assembly. The tool tries to load it from the current directory (where it is invoked from). If the assembly resides in another directory, you need to specify its path as well.
The tool assumes assemblies are ended with ".dll" by defualt. So, you can ommit ".dll" from the name of the assembly.

Example (assuming the path of the tool is included in the PATH environment):

invoking from the directory where the intended assembly resides:
```
C:\MyApp\>asminfo MyLib.dll<br/>
C:\MyApp\>asminfo MyLib<br/>
C:\MyApp\>asminfo MyCompany.MyApp.MyLib.dll<br/>
C:\MyApp\>asminfo MyCompany.MyApp.MyLib<br/>
```
invoking from another directory:
```
D:\>asminfo.exe C:\MyApp\Bin\MyLib.dll<br/>
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