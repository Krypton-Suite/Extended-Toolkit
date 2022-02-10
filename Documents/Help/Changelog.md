=======

## 2022-04-04 - Build 2204 - April 2022
* Implemented [#290](https://github.com/Krypton-Suite/Extended-Toolkit/issues/290), `KryptonOutlookGridGroupBox` 'CreateGroupBox' method not found
* New `Krypton.Toolkit.Suite.Extended.Networking` module
* Moved `KryptonPanelExtended` & `KryptonButtonPanel` to `Krypton.Toolkit.Suite.Extended.Panels` module
* Added `Signed` configuration
* Resolved [#268](https://github.com/Krypton-Suite/Extended-Toolkit/issues/268), Crashes using Outlook Grid control
* Resolved [#226](https://github.com/Krypton-Suite/Extended-Toolkit/issues/226), `KryptonOutlookGrid` throws a `MissingManifestResourceException` when trying to configure its columns
* The `ThemeSelector` now uses the native `KryptonThemeComboBox` control
* Nightly packages are now available both on GitHub and nuget.org
* Reworked the `Toast` module (RTL support coming soon!)
* Updated NuGet package descriptions to provide more information
* Removed examples from source, you can find the example source code [here](https://github.com/Krypton-Suite/Extended-Toolkit-Demos)
* Fix errant typos
* Updated standard toolkit to build `2204`

=======

## 2022-02-02 - Build 2202.1 - February 2022
* Resolved [#299](https://github.com/Krypton-Suite/Extended-Toolkit/issues/299), Toolkit used is the wrong version

=======

## 2022-02-01 - Build 2202 - February 2022
* Updated NuGet package information to aid deployment to GitHub
* New `Krypton.Toolkit.Suite.Extended.Error.Reporting` module
* Removal of unused 'using' statements
* New `Krypton.Toolkit.Suite.Extended.Data.Visualisation` module (ScottPlot only)
* Resolve [#268](https://github.com/Krypton-Suite/Extended-Toolkit/issues/268), Crashes using Outlook Grid control
* Implemented [#271](https://github.com/Krypton-Suite/Extended-Toolkit/issues/271), NuGet Package Information needs to have direct download links
* Resolved issues where some canary NuGet packages were accidentally uploaded as stable packages
* Refined build configurations
* Updated standard toolkit to build `2202`

=======

## 2021-12-07 - Build 2112 - December 2021
* New `Krypton.Toolkit.Suite.Extended.Outlook.Grid` module
* New `Krypton.Toolkit.Suite.Extended.InputBox` module
* Resolve toast 'Dismiss' button location
* New `Krypton.Toolkit.Suite.Extended.Toast` module
* Resolved [#245](https://github.com/Krypton-Suite/Extended-Toolkit/issues/245), 2108 Canary NuGet lists unnecessary dependencies for packages
* Resolve possible `KryptonButton` text bugs
* New icon
* New `KryptonExceptionCaptureDialog` - it is now possible to display an exception in a window along with a typical messagebox
* Broken toolkit up into smaller modules - see list for available modules (Not all modules will be completed yet)
* Improved documentation
* New `Krypton.Toolkit.Suite.Extended.DataGridView` module
* Projects now follow the **Standard-Toolkit** naming convention
* The `ExtendedKryptonMessageBox` now supports a optional checkbox, custom icon and custom button text
* New `KryptonMessageBoxExtendedManager` to allows the creation of a `KryptonMessageBoxExtended` through the designer
* New `KryptonDeveloperDebugConsole` feature - allows developers to see exceptions in a window
* Updated standard toolkit to build `2111`

=======

## 2021-06-04 - Build 2106 - June 2021
* Removal/de-listing of `Krypton.Toolkit.Suite.Extended.Rounded.Controls`, see 'standard toolkit' build 2106 for more information
* New `KryptonFormExtended` to expose properties, which cannot be fulfilled by a action list over time
* Renamed both `KryptonTabControl` in the `Krypton.Toolkit.Suite.Extended.Navigator` module to 'Version1'/'Version2' respectively to avoid confusion
* Cleanup `ExtendedKryptonMessageBox` to remove redundant arguments (some features will return in a future version.)
* New `Krypton.Toolkit.Suite.Extended.Toggle.Switch` module
* Resolve issues with the `Krypton.Toolkit.Suite.Extended.Outlook.Grid` module
* Updated standard toolkit to build `2106`

=======

## 2021-04-01 - Build 2104 - April 2021
* Rewritten the `Krypton.Toolkit.Suite.Extended.Outlook.Grid` module
* Implement [#36](https://github.com/Krypton-Suite/Extended-Toolkit/issues/36), Expose the `OutlookGrid.Classes.OutlookGridRowComparer2` class
* Elevation events for command link button controls
* New `Krypton.Toolkit.Suite.Extended.Circular.Progress.Bar` module

=======

## 2021-03-04 - Build 2103 - March 2021
* Resolved package descriptions
* New `KryptonEnhancedToolStrip` control
* New `KryptonEnhancedToolStripProgressBar` control
* New `KryptonStatusStrip` control
* UAC options for command link buttons (elevation events will come in the next update)
* A new version of the `KryptonUACElevatedButton` that uses the `SystemIcons` API, to grab the version specific UAC shield icon (32 x 32). The existing `KryptonUACElevatedButton` is still in the toolkit for compatibility reasons, but will be hidden in the tool box.
* Updated standard toolkit to build `2103`

=======

## 2021-02-01 - Build 2102 - February 2021
* New `Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box` NuGet package
* New expandable menu/context menu item in `Krypton.Toolkit.Suite.Extended.Tool.Strip.Items`
* New [Visual Studio Toolbox](https://www.codeproject.com/Articles/8658/Another-ToolBox-Control) control
* New `KryptonPasswordEyeTextBox`
* Implemented [#37](https://github.com/Krypton-Suite/Extended-Toolkit/issues/37), KryptonTextBox with Icon
* `KryptonRunDialog` modifications
* License headers for code files
* Canary versions will now start with `6.0`, whereas stable versions will remain on `5.550`
* New icon for canary packages

=======

## 2021-01-03 - Build 2101 - January 2021
* Rounded controls are now in a separate package `Krypton.Toolkit.Suite.Extended.Rounded.Controls`, rather than the `Base` package
* Added [Information Box](https://github.com/JohannBlais/InformationBox), by [Johann Blais](https://github.com/JohannBlais)
* New 'Alert' toast notification. Use the `Alert` class in `Notifications` to activate it
* Implement public version of the `KryptonFadeManager` class, so you can apply *fading* effects to `KryptonForm`
* New `KryptonAboutDialog`, with extra features
* New `NotificationLocationPosition` property in `KryptonToastNotificationPopup` to allow for custom location configuration
* Updated standard toolkit to build `2101`

=======

## 2020-12-01 - Build 2012 - December 2020
* Resolve issues with `FastColouredTextBox`
* New Gantt chart control for `Data Visualisation`
* Removed `Notification` elements from `Dialogs` module

=======

## 2020-11-01 - Build 2011 - November 2020
* New `Networking` NuGet package
* Stable packages will now use the stable `Krypton.*` standard toolkit & vice-versa
* General bugfixes
* Resolve for 'ZipExtractor' in `Software.Updaters` package
* Updated standard toolkit to build `2011`
* ***Important! If you're upgrading from a older legacy version, please uninstall your currently installed packages BEFORE intalling these packages. Please also follow [this](https://github.com/Krypton-Suite/Standard-Toolkit-Online-Help/blob/master/Source/Documentation/Standard%20Toolkit%20Migration%20Guide.md) guidence, as the toolkit now uses different namespaces!***

=======

## 2020-10-01 - Build 2010 - October 2020
* Improved NuGet package descriptions
* Resolved [#21](https://github.com/Krypton-Suite/Extended-Toolkit/issues/21), OutlookGrid Column right click causes error. Thanks to [dax-leo](https://github.com/dax-leo)
* New `Data Visualisation` NuGet package for charts & graphs
* New `KryptonDriveComboBox` & `KryptonImageComboBox` in `Base`
* New `Notifications` NuGet package
* ***Warning: Please uninstall ANY previous versions before installing this build!***

=======

## 2020-09-01 - Build 2009 - September 2020
* Support for more framework versions - In addition to supporting .NET Framework 4.5, .NET Core 3.1 and .NET 5, the toolkit can be now used with projects using .NET Framework 4.5.1 to 4.8 inclusive
* Canary packages are now available
* Implement extra features for `KryptonToastNotificationWindow`
* New `csproj` configuration options to support canary/stable NuGet packages
* Updated standard toolkit to build `2008`

=======

## 2020-08-01 - Build 2008 - August 2020
* All namespaces now correlate to the package name e.g, `Krypton.Toolkit.Extended.Base` now becomes `Krypton.Toolkit.Suite.Extended.Base`
* New find and replace dialog built off of [FnR](https://github.com/zzzprojects/findandreplace)
* All NuGet packages will now be output to `Bin\NuGet`
* General bugfixes

=======

## 2020-07-01 - Build 2007 - July 2020
* Add `.NET Sparkle` to software updater package
* Add `Task Dialogs` module
* Small changes to dialog buttons
* Tidy up code

=======

## 2020-06-01 pm - Build 2006 - June 2020
* Add strong name key files `snk` to projects & DLLs

=======

## 2020-06-01 am - Build 2006 - June 2020
* Versions are now `5.550.xxxx`
* Add preliminary support for .NET 5
* Removed `KryptonListView` due to bug (will return at some point in the future)
* Add `KryptonMemoryBox` a versitile alternative to `KryptonMessageBox` 
* Add `Navi Suite` module
* Add new package for popular software updaters, such as `AutoUpdater.NET` and `SharpUpdate`
* Updated standard toolkit to build **6.0.2006.1**

=======

## 2020-05-01 pm - Build 2005.1 - May 2020
* Removed errant `Experimental` package
* Updated standard toolkit to build **6.0.2006**

=======

## 2020-05-01 am - Build 2005 - May 2020
* Resolved [#3](https://github.com/Krypton-Suite/Extended-Toolkit/issues/3), Missing controls
* Add `IO Components` module
* Add `Outlook Grid` module
* Add `Wizard` module
* Add `Palette Controls` module
* Resolved names for `KryptonComboBoxExtended`, `KryptonPanelExtended` and `KryptonRichTextBoxExtended` to <ControlName>`Enhanced` to avoid confusion
* Resolved [#5](https://github.com/Krypton-Suite/Extended-Toolkit/issues/5), `NuGet Packaging Issue`
* General fixes
* Updated standard toolkit to build **2005**

=======

## 2020-03-21 - Build 2004 - April 2020
* Support for all frameworks .NET 4.5 to 4.8 inclusive
* Support for .NET Core LTS (currently 3.1)
* Changed `490` to `500`
* Builds from now on will be labelled as `YYMM`
* ***Before installing, please follow [this](https://github.com/Krypton-Suite/Standard-Toolkit-Online-Help/blob/master/Source/Documentation/Standard%20Toolkit%20Migration%20Guide.md) as the toolkit now uses different namespaces!***
 module