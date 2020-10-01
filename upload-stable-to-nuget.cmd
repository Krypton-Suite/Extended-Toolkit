@echo off

echo You are about to publish new updates to NuGet. Have You set your API key correctly? (Y/N)
set INPUT=
set /P INPUT=Type response: %=%
if /I "%INPUT%"=="y" goto apikeycheck
if /I "%INPUT%"=="n" goto no

:apikeycheck
echo The API key is now entered. Have You set your version correctly? (Y/N)
set INPUT=
set /P INPUT=Type response: %=%
if /I "%INPUT%"=="y" goto versioncheck
if /I "%INPUT%"=="n" goto no

:versioncheck
echo The version is now correct. Do you want to publish to NuGet? (Y/N)
set INPUT=
set /P INPUT=Type response: %=%
if /I "%INPUT%"=="y" goto publish
if /I "%INPUT%"=="n" goto no

:publish
dotnet nuget push Krypton.Toolkit.Suite.Extended.Base.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Colour.Controls.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Common.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Core.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Data.Visualisation.5.550.<#BUILD#> -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Dialogs.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Floating.Toolbars.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Global.Utilities.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.IO.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Language.Model.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Navi.Suite.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Networking.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Notifications.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Outlook.Grid.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Palette.Controller.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Palette.Controls.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Resources.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Settings.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Software.Updater.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Standard.Controls.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Toolkit.Control.Settings.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Utilities.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Wizard.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Task.Dialogs.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

echo All NuGet packages have now been published!

:no
pause