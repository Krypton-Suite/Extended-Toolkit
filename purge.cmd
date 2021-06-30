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
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Buttons\obj"
rd /s /q "Source\Krypton Toolkit\Main\Krypton.Toolkit.Suite.Extended.Calandar\obj"
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