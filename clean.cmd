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
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Buttons\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Calendar\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Calendar\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.CheckSum.Tools\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.CheckSum.Tools\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.ComboBox\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.ComboBox\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Common\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Common\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Compression\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Compression\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Controls\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Controls\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Core\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Core\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Data.Visualisation\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Data.Visualisation\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.DataGridView\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.DataGridView\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Developer.Utilities\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Developer.Utilities\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Dialogs\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Dialogs\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Dock.Extender\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Dock.Extender\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Drawing\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Drawing\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Drawing.Utilities\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Drawing.Utilities\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Effects\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Effects\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Error.Reporting\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Error.Reporting\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Fast.Coloured.TextBox\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Fast.Coloured.TextBox\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.File.Copier\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.File.Copier\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.File.Explorer\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.File.Explorer\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Floating.Toolbars\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Forms\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Forms\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Gages\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Gages\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Global.Utilities\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Global.Utilities\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Guages\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Guages\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.InputBox\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.InputBox\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.IO\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.IO\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Language.Model\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Language.Model\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Memory.Box\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Memory.Box\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Messagebox\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Messagebox\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Navi.Suite\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Navi.Suite\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Navigator\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Navigator\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Networking\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Networking\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Notifications\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Notifications\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Outlook.Grid\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Outlook.Grid\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Palette.Selectors\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Palette.Selectors\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Panels\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Panels\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Resources\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Resources\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Ribbon\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ribbon\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Settings\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Settings\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Software.Updater\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Software.Updater\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Specialised.Dialogs\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Specialised.Dialogs\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.TaskDialogs\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.TaskDialogs\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Theme.Switcher\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Theme.Switcher\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Toast\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Toast\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Toggle.Switch\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Toggle.Switch\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tool.Box\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tool.Box\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tools\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tools\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.TreeGridView\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.TreeGridView\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Utilities\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Utilities\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView\obj"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Wizard\obj'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Wizard\obj

rd /s /q "Source\Bin"

if exist build.log ( goto deletebuildfile )
if exist debug.log ( goto deletedebugfile )
if exist package-restore.log ( goto deletepackagerestorefile )

echo Do you want to cleanup backup files? (Y/N)
set INPUT=
set /P INPUT=Type input: %=%
if /I "%INPUT%"=="y" goto cleanupbackupfiles
if /I "%INPUT%"=="n" goto no

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

:cleanupbackupfiles
echo Deleting 'Krypton.Toolkit.Suite.Extended.Buttons\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Buttons\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Calendar\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Calendar\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.CheckSum.Tools\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.CheckSum.Tools\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Circular.ProgressBar\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.ComboBox\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.ComboBox\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Common\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Common\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Compression\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Compression\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Controls\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Controls\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Core\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Core\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Data.Visualisation\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Data.Visualisation\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.DataGridView\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.DataGridView\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Developer.Utilities\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Developer.Utilities\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Dialogs\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Dialogs\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Dock.Extender\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Dock.Extender\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Drawing\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Drawing\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Drawing.Utilities\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Drawing.Utilities\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Effects\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Effects\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Error.Reporting\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Error.Reporting\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Fast.Coloured.TextBox\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Fast.Coloured.TextBox\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.File.Copier\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.File.Copier\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.File.Explorer\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.File.Explorer\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Floating.Toolbars\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Forms\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Forms\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Gages\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Gages\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Global.Utilities\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Global.Utilities\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Guages\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Guages\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.InputBox\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.InputBox\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.IO\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.IO\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Language.Model\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Language.Model\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Memory.Box\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Memory.Box\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Messagebox\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Messagebox\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Navi.Suite\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Navi.Suite\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Navigator\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Navigator\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Networking\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Networking\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Notifications\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Notifications\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Outlook.Grid\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Outlook.Grid\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Palette.Selectors\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Palette.Selectors\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Panels\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Panels\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Resources\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Resources\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Ribbon\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ribbon\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Settings\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Settings\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Software.Updater\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Software.Updater\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Specialised.Dialogs\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Specialised.Dialogs\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.TaskDialogs\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.TaskDialogs\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Theme.Switcher\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Theme.Switcher\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Toast\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Toast\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Toggle.Switch\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Toggle.Switch\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tool.Box\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tool.Box\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Tools\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Tools\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.TreeGridView\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.TreeGridView\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Utilities\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Utilities\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView\*.bak"
echo Deleting 'Krypton.Toolkit.Suite.Extended.Wizard\*.bak'
rd /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Wizard\*.bak"

:no
pause