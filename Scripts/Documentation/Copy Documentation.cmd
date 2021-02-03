@echo off

echo Do you want to setup the top level directories?
set INPUT=Type a response: %=%
if /I "%INPUT%"=="y" goto setup
if /I "%INPUT%"=="n" goto close

echo Do you want to setup the libraries directories?
set INPUT=Type a response: %=%
if /I "%INPUT%"=="y" goto setuplibraries
if /I "%INPUT%"=="n" goto close

echo Do you want to setup the shared directories?
set INPUT=Type a response: %=%
if /I "%INPUT%"=="y" goto setupshared
if /I "%INPUT%"=="n" goto close

:setup
md Extended-Toolkit
cd Extended-Toolkit
md Libraries
md Shared

:setuplibraries
cd Libraries
md Krypton.Toolkit.Suite.Extended.Base
md Krypton.Toolkit.Suite.Extended.Drawing.Suite
md Krypton.Toolkit.Suite.Extended.Data.Visualisation
md Krypton.Toolkit.Suite.Extended.Error.Reporting
md Krypton.Toolkit.Suite.Extended.Dialogs
md Krypton.Toolkit.Suite.Extended.Standard.Controls
:: md Krypton.Toolkit.Suite.Extended.File.Explorer
md Krypton.Toolkit.Suite.Extended.Floating.Toolbars
md Krypton.Toolkit.Suite.Extended.IO
md Krypton.Toolkit.Suite.Extended.Wizard
md Krypton.Toolkit.Suite.Extended.Navi.Suite
md Krypton.Toolkit.Suite.Extended.Navigator
md Krypton.Toolkit.Suite.Extended.Networking
md Krypton.Toolkit.Suite.Extended.Notifications
:: md Krypton.Toolkit.Suite.Extended.Object.ListView
:: md Krypton.Toolkit.Suite.Extended.Outlook.Grid
md Krypton.Toolkit.Suite.Extended.Rounded.Controls
md Krypton.Toolkit.Suite.Extended.Software.Updater
:: md Krypton.Toolkit.Suite.Extended.Task.Dialogs
md Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
cd ..
goto createnet48directoriesinlibraries

:setupshared
cd Shared
md Krypton.Toolkit.Suite.Extended.Common
md Krypton.Toolkit.Suite.Extended.Global.Utilities
:: md Krypton.Toolkit.Suite.Extended.Palette.Controller
md Krypton.Toolkit.Suite.Extended.Palette.Controls
md Krypton.Toolkit.Suite.Extended.Palette.Utilities
:: md Krypton.Toolkit.Suite.Extended.Persistence
:: md Krypton.Toolkit.Suite.Extended.Toolkit.Control.Settings
md Krypton.Toolkit.Suite.Extended.Core
md Krypton.Toolkit.Suite.Extended.Language.Model
md Krypton.Toolkit.Suite.Extended.Resources
md Krypton.Toolkit.Suite.Extended.Settings
md Krypton.Toolkit.Suite.Extended.Utilities
cd ..
goto createnet48directoriesinshared

:createnet48directoriesinlibraries
cd Libraries
cd Krypton.Toolkit.Suite.Extended.Base
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Drawing.Suite
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Data.Visualisation
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Error.Reporting
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Dialogs
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Standard.Toolkit
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Floating.Toolbars
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.IO
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Wizard
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Navi.Suite
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Navigator
goto createnet48directory
cd  ..
cd Krypton.Toolkit.Suite.Extended.Networking
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Notifications
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Rounded.Controls
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Software.Updater
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
goto createnet48directory
cd ..\..

:createnet48directoriesinshared
cd Shared
cd Krypton.Toolkit.Suite.Extended.Common
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Global.Utilities
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Core
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Language.Model
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Resources
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Settings
goto createnet48directory
cd ..
cd Krypton.Toolkit.Suite.Extended.Utilities
goto createnet48directory
cd ..\..

:copylibraryfiles
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Base\net48\Krypton.Toolkit.Suite.Extended.Base.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Base\Krypton.Toolkit.Suite.Extended.Base.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Base\net48\Krypton.Toolkit.Suite.Extended.Base.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Base\Krypton.Toolkit.Suite.Extended.Base.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Drawing.Suite\net48\Krypton.Toolkit.Suite.Extended.Drawing.Suite.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Drawing.Suite\Krypton.Toolkit.Suite.Extended.Drawing.Suite.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Drawing.Suite\net48\Krypton.Toolkit.Suite.Extended.Drawing.Suite.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Drawing.Suite\Krypton.Toolkit.Suite.Extended.Drawing.Suite.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Data.Visualisation\net48\Krypton.Toolkit.Suite.Extended.Data.Visualisation.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Data.Visualisation\Krypton.Toolkit.Suite.Extended.Data.Visualisation.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Data.Visualisation\net48\Krypton.Toolkit.Suite.Extended.Data.Visualisation.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Data.Visualisation\Krypton.Toolkit.Suite.Extended.Data.Visualisation.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Error.Reporting\net48\Krypton.Toolkit.Suite.Extended.Error.Reporting.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Error.Reporting\Krypton.Toolkit.Suite.Extended.Error.Reporting.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Error.Reporting\net48\Krypton.Toolkit.Suite.Extended.Error.Reporting.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Error.Reporting\Krypton.Toolkit.Suite.Extended.Error.Reporting.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Dialogs\net48\Krypton.Toolkit.Suite.Extended.Dialogs.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Dialogs\Krypton.Toolkit.Suite.Extended.Dialogs.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Dialogs\net48\Krypton.Toolkit.Suite.Extended.Dialogs.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Dialogs\Krypton.Toolkit.Suite.Extended.Dialogs.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Standard.Controls\net48\Krypton.Toolkit.Suite.Extended.Standard.Controls.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Standard.Controls\Krypton.Toolkit.Suite.Extended.Standard.Controls.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Standard.Controls\net48\Krypton.Toolkit.Suite.Extended.Standard.Controls.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Standard.Controls\Krypton.Toolkit.Suite.Extended.Standard.Controls.xml

copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\net48\Krypton.Toolkit.Suite.Extended.Floating.Toolbars.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\Krypton.Toolkit.Suite.Extended.Floating.Toolbars.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\net48\Krypton.Toolkit.Suite.Extended.Floating.Toolbars.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Floating.Toolbars\Krypton.Toolkit.Suite.Extended.Floating.Toolbars.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.IO\net48\Krypton.Toolkit.Suite.Extended.IO.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.IO\Krypton.Toolkit.Suite.Extended.IO.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.IO\net48\Krypton.Toolkit.Suite.Extended.IO.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.IO\Krypton.Toolkit.Suite.Extended.IO.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Wizard\net48\Krypton.Toolkit.Suite.Extended.Wizard.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Wizard\Krypton.Toolkit.Suite.Extended.Wizard.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Wizard\net48\Krypton.Toolkit.Suite.Extended.Wizard.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Wizard\Krypton.Toolkit.Suite.Extended.Wizard.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Navi.Suite\net48\Krypton.Toolkit.Suite.Extended.Navi.Suite.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Navi.Suite\Krypton.Toolkit.Suite.Extended.Navi.Suite.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Navi.Suite\net48\Krypton.Toolkit.Suite.Extended.Navi.Suite.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Navi.Suite\Krypton.Toolkit.Suite.Extended.Navi.Suite.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Navigator\net48\Krypton.Toolkit.Suite.Extended.Navigator.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Navigator\Krypton.Toolkit.Suite.Extended.Navigator.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Navigator\net48\Krypton.Toolkit.Suite.Extended.Navigator.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Navigator\Krypton.Toolkit.Suite.Extended.Navigator.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Networking\net48\Krypton.Toolkit.Suite.Extended.Networking.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Networking\Krypton.Toolkit.Suite.Extended.Networking.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Networking\net48\Krypton.Toolkit.Suite.Extended.Networking.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Networking\Krypton.Toolkit.Suite.Extended.Networking.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Notifications\net48\Krypton.Toolkit.Suite.Extended.Notifications.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Notifications\Krypton.Toolkit.Suite.Extended.Notifications.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Notifications\net48\Krypton.Toolkit.Suite.Extended.Notifications.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Notifications\Krypton.Toolkit.Suite.Extended.Notifications.xml


copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Rounded.Controls\net48\Krypton.Toolkit.Suite.Extended.Rounded.Controls.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Rounded.Controls\Krypton.Toolkit.Suite.Extended.Rounded.Controls.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Rounded.Controls\net48\Krypton.Toolkit.Suite.Extended.Rounded.Controls.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Rounded.Controls\Krypton.Toolkit.Suite.Extended.Rounded.Controls.xml
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Software.Updater\net48\Krypton.Toolkit.Suite.Extended.Software.Updater.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Software.Updater\Krypton.Toolkit.Suite.Extended.Software.Updater.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Software.Updater\net48\Krypton.Toolkit.Suite.Extended.Software.Updater.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Software.Updater\Krypton.Toolkit.Suite.Extended.Software.Updater.xml

copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\net48\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.dll <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.dll
copy <##Target-directory##>\Bin\Debug\Libraries\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\net48\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.xml <##Destination##>\Extended-Toolkit\Libraries\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items\Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.xml

:copysharedfiles
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Common\net48\Krypton.Toolkit.Suite.Extended.Common.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Common\Krypton.Toolkit.Suite.Extended.Common.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Common\net48\Krypton.Toolkit.Suite.Extended.Common.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Common\Krypton.Toolkit.Suite.Extended.Common.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Global.Utilities\net48\Krypton.Toolkit.Suite.Extended.Global.Utilities.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Global.Utilities\Krypton.Toolkit.Suite.Extended.Global.Utilities.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Global.Utilities\net48\Krypton.Toolkit.Suite.Extended.Global.Utilities.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Global.Utilities\Krypton.Toolkit.Suite.Extended.Global.Utilities.xml

copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Palette.Controls\net48\Krypton.Toolkit.Suite.Extended.Palette.Controls.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Palette.Controls\Krypton.Toolkit.Suite.Extended.Palette.Controls.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Palette.Controls\net48\Krypton.Toolkit.Suite.Extended.Palette.Controls.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Palette.Controls\Krypton.Toolkit.Suite.Extended.Palette.Controls.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Palette.Utilities\net48\Krypton.Toolkit.Suite.Extended.Palette.Utilities.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Palette.Utilities\Krypton.Toolkit.Suite.Extended.Palette.Utilities.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Palette.Utilities\net48\Krypton.Toolkit.Suite.Extended.Palette.Utilities.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Palette.Utilities\Krypton.Toolkit.Suite.Extended.Palette.Utilities.xml


copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Core\net48\Krypton.Toolkit.Suite.Extended.Core.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Core\Krypton.Toolkit.Suite.Extended.Core.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Core\net48\Krypton.Toolkit.Suite.Extended.Core.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Core\Krypton.Toolkit.Suite.Extended.Core.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Language.Model\net48\Krypton.Toolkit.Suite.Extended.Language.Model.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Language.Model\Krypton.Toolkit.Suite.Extended.Language.Model.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Language.Model\net48\Krypton.Toolkit.Suite.Extended.Language.Model.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Language.Model\Krypton.Toolkit.Suite.Extended.Language.Model.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Resources\net48\Krypton.Toolkit.Suite.Extended.Resources.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Resources\Krypton.Toolkit.Suite.Extended.Resources.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Resources\net48\Krypton.Toolkit.Suite.Extended.Resources.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Resources\Krypton.Toolkit.Suite.Extended.Resources.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Settings\net48\Krypton.Toolkit.Suite.Extended.Settings.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Settings\Krypton.Toolkit.Suite.Extended.Settings.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Settings\net48\Krypton.Toolkit.Suite.Extended.Settings.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Settings\Krypton.Toolkit.Suite.Extended.Settings.xml
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Utilities\net48\Krypton.Toolkit.Suite.Extended.Utilities.dll <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Utilities\Krypton.Toolkit.Suite.Extended.Utilities.dll
copy <##Target-directory##>\Bin\Debug\Shared\Krypton.Toolkit.Suite.Extended.Utilities\net48\Krypton.Toolkit.Suite.Extended.Utilities.xml <##Destination##>\Extended-Toolkit\Shared\Krypton.Toolkit.Suite.Extended.Utilities\Krypton.Toolkit.Suite.Extended.Utilities.xml

:createnet48directory
md net48

:close
exit