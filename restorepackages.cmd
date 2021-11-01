@echo off

echo Do you have 'nuget.exe' installed? (Y/N)
set /P INPUT=Type input: %=%
if /I "%INPUT%"=="y" goto yes
if /I "%INPUT%"=="n" goto no

:yes
:: TODO I'm at a loss with this one :(
echo Restoring packages...
nuget.exe restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2019.sln" -Force -Verbosity detailed > package-restore.log
echo All packages have now been restored!
echo The details can be found in the 'package-restore.log' file
pause

:no
echo Please go to https://www.nuget.org/downloads, to download the newest 'nuget.exe'

pause