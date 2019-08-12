@echo off

:: Build dll
rm bin/ obj/ -rf
dotnet publish -c Release

:: Generate Key
cd ./bin/Release/netstandard2.0/
sn -k key.snk

:: ReCompile
ildasm Taskbar_CPUMemExt.dll /OUTPUT=CpuMemExt.il
ilasm CpuMemExt.il /DLL /OUTPUT=CpuMemExt.dll /KEY=key.snk

:: Register
cp ./publish/SharpShell.dll ./SharpShell.dll
regasm /codebase CpuMemExt.dll

:: regasm /u CpuMemExt.dll

@echo on