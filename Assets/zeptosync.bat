@echo OFF
echo :
echo : XCOPY Batch Process Started
echo :
xcopy .\zeptolib\ ..\..\zeptoslim /E /D /Y
echo :
xcopy ..\..\zeptoslim .\zeptolib\ /E /D /Y
rmdir .\zeptolib\bin /s /q
rmdir .\zeptolib\obj /s /q
rmdir .\zeptolib\.vscode /s /q
del .\zeptolib\zeptolib.csproj
del .\zeptolib\.gitignore
del .\zeptolib\*.bat
del ..\..\zeptoslim\*.meta
echo :
echo : XCOPY Batch Process Complete
echo :