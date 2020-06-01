@REM The intent of this file is to push updates to NuGet. REMEMBER!!! To always place the '*.nupkg' files in the top level directory for this to work.

@echo off

:: Update nuget.exe
nuget update

nuget push Krypton.Toolkit.Suite.Extended.Base.5.500.2005.nupkg
nuget push Krypton.Toolkit.Extended.Colour.Controls.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Dialogs.5.500.2005.nupkg
nuget push Krypton.Toolkit.Extended.Floating.Toolbars.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.IO.5.500.2005.nupkg

nuget push Krypton.Toolkit.Suite.Extended.Navigator.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Outlook.Grid.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Standard.Controls.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Wizard.5.550.2005.nupkg

nuget push Krypton.Toolkit.Suite.Extended.Common.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Core.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Global.Utilities.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Language.Model.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Palette.Controller.5.500.2005.nupkg

nuget push Krypton.Toolkit.Suite.Extended.Palette.Controls.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Persistence.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Resources.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Settings.5.500.2005.nupkg
nuget push Krypton.Toolkit.Suite.Extended.Toolkit.Control.Settings.5.500.2005.nupkg

nuget push Krypton.Toolkit.Suite.Extended.Utilities.5.500.2005.nupkg