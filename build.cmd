@echo off

:: Build dll
rm bin/ obj/ -rf
dotnet publish -c Release

:: Generate Key
cd ./bin/Release/net48/
sn -k key.snk

:: ReCompile
ildasm Taskbar_CPUMemExt.dll /OUTPUT=CpuMemExt.il
ilasm CpuMemExt.il /DLL /OUTPUT=CpuMemExt.dll /KEY=key.snk

:: Backup dll
cp ./publish/SharpShell.dll ../../../build/SharpShell.dll 
cp ./CpuMemExt.dll ../../../build/CpuMemExt.dll 
cd ../../..

:: Register
regasm /codebase ./build/CpuMemExt.dll

:: regasm /u ./build/CpuMemExt.dll

@echo on