@echo off
if "%PROCESSOR_ARCHITECTURE%"=="AMD64" regsvr32 /u /s x64\Release\sqlite-oledb.dll
regsvr32 /u /s Win32\Release\sqlite-oledb.dll
