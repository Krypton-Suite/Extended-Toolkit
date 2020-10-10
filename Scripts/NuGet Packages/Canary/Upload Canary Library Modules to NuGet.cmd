:: -------------------------------------------------------
::
:: Author: P. Wagner
:: Created: Saturday 10th October, 2020 10:00 AM GMT
:: Last Updated:
::
:: -------------------------------------------------------

@echo off

echo You are about to publish new library module updates to NuGet. Have You set your API key correctly? (Y/N)
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
dotnet nuget push Krypton.Toolkit.Suite.Extended.Base.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Data.Visualisation.Canary.5.550.<#BUILD#> -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Drawing.Suite.Canary.5.550.<#BUILD#> -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Dialogs.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Standard.Controls.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Software.Updater.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Floating.Toolbars.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.IO.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Outlook.Canary.Grid.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Navi.Suite.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Networking.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Notifications.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Task.Dialogs.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Wizard.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

echo All NuGet packages have now been published!

:no
pause