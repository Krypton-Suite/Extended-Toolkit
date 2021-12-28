@echo off

echo You are about to delete the Bin folder; do you want to continue? (Y/N)
set INPUT=
set /P INPUT=Type input: %=%
if /I "%INPUT%"=="y" goto yes
if /I "%INPUT%"=="n" goto no

:yes
echo Deleting the 'Bin' folder
rd /s /q "Bin"
echo Deleted the 'Bin' folder

echo Deleting the main 'obj' directories
echo Deleting 'Krypton.Toolkit.Suite.Extended.Buttons\obj'
rd /s /q "Source\Krypton Toolkit\Toolkit\Krypton.Toolkit.Suite.Extended.*\obj"
rd /s /q "Source\Bin"

if exist build.log ( goto deletebuildfile )
if exist debug.log ( goto deletedebugfile )
if exist package-restore.log ( goto deletepackagerestorefile )

:deletebuildfile
echo Deleting the 'build.log' file
del /f build.log
echo Deleted the 'build.log' file
goto restorepackages

:deletedebugfile
echo Deleting the 'debug.log' file
del /f debug.log
echo Deleted the 'debug.log' file

:deletepackagerestorefile
echo Deleting the 'package-restore.log' file
del /f package-restore.log
echo Deleted the 'package-restore.log' file

:no
pause