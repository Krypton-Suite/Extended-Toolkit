@echo off

echo Do you have 'nuget.exe' installed? (Y/N)
set /P INPUT=Type input: %=%
if /I "%INPUT%"=="y" goto yes
if /I "%INPUT%"=="n" goto no

:yes
echo Restoring packages...
nuget.exe restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2019.sln"
echo All packages have now been restored!
pause

:no
echo Please go to https://www.nuget.org/downloads, to download the newest 'nuget.exe'

pause