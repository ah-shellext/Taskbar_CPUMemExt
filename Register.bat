@echo off

:: Generate Key
cd ResourceDeskBand.Extension\bin\x64\Release
if not exist "key.snk" sn -k key.snk

:: Recompile
ildasm ResourceDeskBand.Extension.dll /OUTPUT=ResourceDeskBand.Extension.il
ilasm ResourceDeskBand.Extension.il /DLL /OUTPUT=ResourceDeskBand.Extension.dll /KEY=key.snk

:: Backup dll
if not exist "..\..\..\build" mkdir ..\..\..\build
cp *.dll ..\..\..\build
cd ..\..\..\build

:: Register
regasm /codebase ResourceDeskBand.Extension.dll

:: Back to solution folder
cd ..\..

@echo on
