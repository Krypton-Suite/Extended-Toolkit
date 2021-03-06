:: -------------------------------------------------------
::
:: Author: P. Wagner
:: Created: Saturday 10th October, 2020 10:00 AM GMT
:: Last Updated:
::
:: -------------------------------------------------------

@echo off

echo You are about to publish new shared module updates to NuGet. Have You set your API key correctly? (Y/N)
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
dotnet nuget push Krypton.Toolkit.Suite.Extended.Common.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Toolkit.Control.Settings.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Core.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Global.Utilities.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Language.Model.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Palette.Controller.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Palette.Controls.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Resources.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Settings.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

dotnet nuget push Krypton.Toolkit.Suite.Extended.Utilities.Canary.5.550.<#BUILD#>.nupkg -k <#API-KEY#> -s https://api.nuget.org/v3/index.json

echo All NuGet packages have now been published!

:no
pause