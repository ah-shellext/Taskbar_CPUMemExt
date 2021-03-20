@echo off

:: Unregister
cd ResourceDeskBand.Extension\build
regasm /u ResourceDeskBand.Extension.dll
cd ..\..

@echo on
