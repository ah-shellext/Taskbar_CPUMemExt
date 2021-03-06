# Taskbar_CPUMemExt
+ My personal tool to monitor CPU and Memory Usage

### Environment
+ `.NET Core cli 2.2.401`
+ `.NET Framework 4.8`
+ `VS Code`
+ `Windows 10 Version 1803`

### Path
+ `Program Files\Microsoft SDKs\Windows\vx.xA\bin\NETFX x.x.x Tools` -> `sn.exe` / `ildasm.exe`
+ `Windows\Microsoft.NET\Framework64\vx.x.x` -> `ilasm.exe` / `regasm.exe`

### Depedences
```bash
# Add depedence
dotnet add package SharpShell
dotnet add package System.Windows.Forms
dotnet add package System.Drawing.Common
```

```xml
<PropertyGroup>
    <TargetFramework>net48</TargetFramework>
</PropertyGroup>
```

+ See [Taskbar_CPUMemExt.csproj](./Taskbar_CPUMemExt.csproj)

### Build
```bash
# Do this in cmd !!!

# Build dll
rm bin/ obj/ -rf
dotnet publish -c Release

# Generate Key
cd ./bin/Release/netstandard2.0/
sn -k key.snk # write strong key pair

# ReCompile
ildasm Taskbar_CPUMemExt.dll /OUTPUT=CpuMemExt.il
ilasm CpuMemExt.il /DLL /OUTPUT=CpuMemExt.dll /KEY=key.snk # All key to dll

# Backup dll
cp ./publish/SharpShell.dll ../../../build/SharpShell.dll 
cp ./CpuMemExt.dll ../../../build/CpuMemExt.dll 
cd ../../..

# Register
regasm /codebase ./build/CpuMemExt.dll

# Restart explorer.exe
```

### UnRegister
```bash
regasm /u ./build/CpuMemExt.dll

# Restart explorer.exe
```

### Problem
+ `StartIsBack` tool priority error

### Screenshot
![No_Theme_Screenshot](./assets/no_theme.jpg)
![Has_Theme_Screenshot](./assets/has_theme.jpg)

### Remark
> ### Ensure you register with the correct bitness
> If you are on Windows 32 bit, make sure you register the server with an > x86 version of `regasm`, e.g:  
> 
> ```
> C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm 
> ```
> 
> If you are on Windows 64 bit, make sure you register the server with an > x64 version of `regasm`, e.g:
> 
> ```
> C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm
> ```
>

### Reference
+ Shell
    + [sharpshell](https://github.com/dwmkerr/sharpshell)
    + [Desk Band Extensions](https://github.com/dwmkerr/sharpshell/blob/master/docs/extensions/deskband/deskband.md)
    + [Installing and Uninstalling SharpShell Servers](https://github.com/dwmkerr/sharpshell/blob/master/docs/installing/installing.md)
    + [C#程序集使用强名字(Strong Name)签名/强名称签名](https://www.cnblogs.com/1175429393wljblog/p/5377533.html)
+ Resources
    + [C#获取使用的内存％](https://codeday.me/bug/20171129/102809.html)
    + [C＃システムのCPU使用率とWindowsタスクマネージャとの同期](https://codeday.me/jp/qa/20190723/1280712.html)
    + [GetSystemTimes](https://docs.microsoft.com/en-us/windows/win32/api/processthreadsapi/nf-processthreadsapi-getsystemtimes)