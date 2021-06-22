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

echo REMINDER: DELETE THE 'OBJ' DIRECTORIES!

if exist build.log ( goto deletebuildfile )
if exist debug.log ( goto deletedebugfile )

:deletebuildfile
echo Deleting the 'build.log' file
del /f build.log
echo Deleted the 'build.log' file

:deletedebugfile
echo Deleting the 'debug.log' file
del /f debug.log
echo Deleted the 'debug.log' file

:no
pause