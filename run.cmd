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
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Buttons\obj"
echo Deleted 'Krypton.Toolkit.Suite.Extended.Buttons\obj'
echo Deleting 'Krypton.Toolkit.Suite.Extended.Calandar\obj'
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Calandar\obj"
echo Deleted 'Krypton.Toolkit.Suite.Extended.Calandar\obj'
echo Deleting 'Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\obj'
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.ComboBox\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Controls\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Data.Visualisation\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.DataGridView\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Dialogs\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Dock.Extender\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Drawing.Utilities\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Error.Reporting\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Fast.Coloured.TextBox\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.File.Explorer\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Guages\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.IO\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Messagebox\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Navi.Suite\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Navigator\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Networking\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Notifications\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Outlook.Grid\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Palette.Selectors\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Property.Grid\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Scroll.Bars\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Software.Updater\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.TaskDialogs\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Theme.Switcher\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Toggle.Switch\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Tool.Box\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.TreeGridView\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.UI\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Wizard\obj"

echo Deleting the shared 'obj' directories
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Common\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Core\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Developer.Utilities\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Drawing\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Effects\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Global.Utilities\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Language.Model\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Resources\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Settings\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Tools\obj"
rd /s /q "Source\Krypton Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Utilities\obj"

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
goto restorepackages

:deletepackagerestorefile
echo Deleting the 'package-restore.log' file
del /f package-restore.log
echo Deleted the 'package-restore.log' file

:no
pause

:restorepackages
echo Do you have 'nuget.exe' installed? (Y/N)
set /P INPUT=Type input: %=%
if /I "%INPUT%"=="y" goto nugetexists
if /I "%INPUT%"=="n" goto nugetdoesnotexist

:nugetexists
echo Restoring packages...
nuget.exe restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2019.sln" -Force -Verbosity detailed > package-restore.log
echo All packages have now been restored!
echo The details can be found in the 'package-restore.log' file
pause

:nugetdoesnotexist
echo Please go to https://www.nuget.org/downloads, to download the newest 'nuget.exe'

pause