# ![Krypton Extended Toolkit Logo](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Krypton.png?raw=true) Extended Toolkit

=======

## NuGet Information

[![Version information](https://img.shields.io/badge/NuGet-Version%20Information-orange.svg?label=Version&logo=nuget&style=flat-square)](https://github.com/Krypton-Suite/Documentation/blob/main/Documents/Packages/Extended/Krypton-Toolkit-Suite-Extended-Modules.md)

=======

## Supporters

Development of the Krypton Extended Toolkit is supported by these generous organisations:

| [![JetBrains](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/PNG/Supporter%20Logos/jetbrains-logo.png?raw=true)](https://www.jetbrains.com/) | [![YourKit](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Assets/PNG/Supporter%20Logos/yourkit-logo.png?raw=true)](https://www.yourkit.com/) |
|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------:|:------------------------------------------------------------------------------------------------------------------------------------------------------------:|
| JetBrains provides cutting-edge IDE and developer productivity tools. | YourKit provides a market-leading intelligent [Java Profiler](https://www.yourkit.com/features/) and [.NET Profiler](https://www.yourkit.com/dotnet/features/). |

=======

## Documentation

[![Download the extended toolkit documentation installer](https://img.shields.io/badge/Documentation-Download%20File-orange.svg?style=flat-square)](https://github.com/Krypton-Suite/Help-Files/releases/download/5.550.2102/Krypton.Extended.Toolkit.Help.exe)

## Examples

[![Toolkit Examples](https://img.shields.io/badge/Toolkit-Examples-orange.svg?style=flat-square)](https://github.com/Krypton-Suite/Extended-Toolkit/tree/master/Documents/Examples/Examples.md)

## Version Information

[![Version Information](https://img.shields.io/badge/Version-Information-purple.svg?style=flat-square)](https://github.com/Krypton-Suite/Krypton-Toolkit-Suite-Version-Dashboard/blob/main/Documents/Modules/Extended/Krypton-Toolkit-Suite-Extended-Modules.md)

## Version History

[![Extended Toolkit Changelog](https://img.shields.io/badge/Version%20History-Changelog-B19CD1.svg?style=flat-square)](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Documents/Help/Changelog.md)

## Support Information

[![Package Support Information](https://img.shields.io/badge/NuGet-Package%20Support%20Information-informational.svg?style=flat-square)](https://github.com/Krypton-Suite/Documentation/blob/main/Documents/Development/Package-Support-Information.md)

## Enabling preview SDK usage

If you want to try out the latest .NET SDK (currently .NET 8), but just have the stable version of Visual Studio installed, please read this [article](https://github.com/Krypton-Suite/Documentation/blob/main/Documents/Development/Enable-Preview-SDK.md).

=======

## Install the `Ultimate` Package

**Note:** These packages do not support anything newer than .NET Framework 4.8.1.

### Full

#### Package Manager

```ps
PM> NuGet\Install-Package Krypton.Toolkit.Suite.Extended.Ultimate -Version 70.22.11.312
```

#### Package Reference

```xml
<PackageReference Include="Krypton.Toolkit.Suite.Extended.Ultimate" Version="70.22.11.312" />
```

### Lite

```ps
PM> NuGet\Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Lite -Version 70.22.11.312
```

=======

## Build System

The Krypton Extended Toolkit includes a comprehensive build automation system similar to the [Krypton Standard Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit).

## Quick Start

```cmd
# Interactive build menu (recommended)
quick-build.cmd

# Direct build commands
Scripts\build.cmd Release AnyCPU net8.0-windows
Scripts\test-build.cmd
```

## Build Configurations

- **Debug** - Development builds with symbols
- **Release** - Production builds with NuGet packages
- **Canary** - Beta testing builds
- **Nightly** - Continuous integration builds

## Build Documentation

- **Complete Guide**: [Scripts/BUILD_SYSTEM.md](Scripts/BUILD_SYSTEM.md)
- **Scripts Directory**: [Scripts/](Scripts/)

=======

## Modules

## Main Modules

| Module Name              | Description                                                                                                                                 | Example Image |
|--------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|---------------|
| Advanced Data Grid View  | This package implements the advanced data grid view controls.                                                                               | ![Advanced Data Grid View Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/AdvancedDataGridView.gif?raw=true)             |  
| Buttons                  | This package holds extensions to the standard `KryptonButton` controls.                                                                     | ![Buttons Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/Buttons.png?raw=true)             |
| Calendar                 | This package implements a `KryptonCalendar` control.                                                                                        | 2             |
| CheckSum Tools           | This package holds utilities to compute and verify checksums.                                                                               | 3             |
| Circular Progress Bar    | This package holds the circular progressbar control.                                                                                        | ![Circular Progress Bar Normal](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/CircularProgressBarNormal.gif?raw=true) ![Circular Progress Bar Trio](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/CircularProgressBarTrio.gif?raw=true)            |
| ComboBox                 | This package implements extensions to the Krypton standard toolkit ComboBox, including additional Drop Down types and views.                | 5             |
| Compression              | This package holds additional file compression utilities.                                                                                   | 6             |
| Controls                 | This package holds numerous controls that complement the standard toolkit.                                                                  | ![Controls Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/Controls.png?raw=true)              |
| Data Visualisation       | This package implements charts, graphs and other additional data visualisation tools.                                                       | 8             |
| Data Grid View           | This package implements additional extensions to the Krypton standard toolkit DataGridView, including Column types and Master-Detail views. | ![DataGridView Launch List View](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/DataGridViewLaunchListView.png?raw=true)    ![DataGridView Single and Multi Detail Views](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/DataGridViewSingleAndMultiDetailViews.png?raw=true)              |
| Dialogs                  | This package implements additional extensions to standard dialogs.                                                                          | 10            |
| Dock Extender            | This package implements additional docking operations. (Under Development)                                                                  | 11            |
| Drawing Utilities        | This package implements additional drawing utilities.                                                                                       | 12            |
| Error Reporting          | This package implements error reporting features.                                                                                           | 13            |
| Fast Coloured TextBox    | This package implements the FastColouredTextBox control.                                                                                    | 14            |
| File Copier              | This package provides tools to move and copy files.                                                                                         | 15            |
| File Explorer            | This package implements a file explorer. (Under Development)                                                                                | 16            |
| Floating Toolbars        | This package allows the usage of floating toolbars.                                                                                         | ![Floating Toolbars Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/FloatableToolStrips.gif?raw=true)            |
| Forms                    | This package implements additional `KryptonForm` effects, to be used in conjunction with the standard toolkit.                              | 18            |
| Gages                    | This package implements additional gage controls. (Under Development)                                                                       | 19            |
| Input Box                | This package implements a input box dialog.                                                                                                 | 20            |
| IO                       | This package implements IO controls and features.                                                                                           | 21            |
| Memory Box               | This package implements a memory box dialog.                                                                                                | ![Memory Box Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/MemoryBoxExample.gif?raw=true)            |
| Message Box              | This package implements additional `KryptonMessageBox` features and functionality.                                                          | 23            |
| Navi Suite               | This package implements the 'NaviSuite' control.                                                                                            | 24            |
| Navigator                | This package implements additional `KryptonNavigator` designs and features.                                                                 | 25            |
| Networking               | This package implements networking features.                                                                                                | 26            |
| Notifications            | This package implements items to create notifications for your applications.                                                                | 27            |
| Outlook Grid             | This package implements the 'OutlookGrid' control.                                                                                          | 28            |
| Palette Selectors        | This package implements palette creation tools. (Under Development)                                                                         | 29            |
| Panel                    | This package implements extra 'KryptonPanel' features and functionality. (Under Development)                                                | 30            |
| Ribbon                   | This package implements extra 'KryptonRibbon' features and functionality.                                                                   | 31            |
| Software Updater         | This package implements software updating features.                                                                                         | 32            |
| Specialised Dialogs      | This package implements system dialogs, using the Krypton themes.                                                                           | 33            |
| Task Dialogs             | This package implements extra 'KryptonTaskDialog' features and functionality.                                                               | 34            |
| Theme Switcher           | This package implements a easy to use theme switcher.                                                                                       | ![Theme Switcher Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/ThemeSwitcher.gif?raw=true)            |
| Themes                   | This package implements theme utilities for use with KryptonFormExtended.                                                                   | 36            |
| Toast                    | This package contains a framework that allows the creation of toast notifications.                                                          | 37            |
| Toggle Switch            | This package implements toggle switch controls. (Under Development)                                                                         | 38            |
| Tool Box                 | This package implements a Visual Studio toolbox control.                                                                                    | 39            |
| Tool Strip Items         | This package implements additional tool strip items.                                                                                        | 40            |
| Tree Grid View           | This package implements items to create tree grid views for your applications.                                                              | ![Tree Grid View Theming](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/TreeGidViewTheming.gif?raw=true) ![Tree Grid View Data Source](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/TreeGridViewDaataSource.gif?raw=true)             |
| Virtual Tree Column View | This package implements items to create a 'virtual tree column view' for your applications.                                                 | ![Virtual Tree Column View Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/VirtualTreeColumnView.png?raw=true)             |
| Wizard                   | This package implements a wizard control.                                                                                                   | ![Wizard Example](https://github.com/Krypton-Suite/Documentation/blob/main/Assets/Extended-Toolkit/KryptonWizard.gif?raw=true)            |

***Note:*** Some packages may install third-party libraries in order to make them function correctly.
