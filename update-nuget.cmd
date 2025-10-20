@echo off
:: Krypton Extended Toolkit - NuGet Package Update Tool

title NuGet Package Manager

cls

echo ========================================================================
echo   Krypton Extended Toolkit - NuGet Package Manager
echo ========================================================================
echo:

:mainmenu

echo 1. Check for outdated packages
echo 2. Update all NuGet packages (restore with force)
echo 3. Clear NuGet cache
echo 4. List all packages
echo 5. Install dotnet-outdated tool (recommended)
echo 6. Update specific package
echo 7. Restore packages (normal)
echo 8. Show NuGet sources
echo 9. Return to main menu
echo:

set /p choice="Enter your choice (1-9): "

if "%choice%"=="1" goto checkoutdated
if "%choice%"=="2" goto updateall
if "%choice%"=="3" goto clearcache
if "%choice%"=="4" goto listpackages
if "%choice%"=="5" goto installtool
if "%choice%"=="6" goto updatespecific
if "%choice%"=="7" goto restore
if "%choice%"=="8" goto showsources
if "%choice%"=="9" goto exit

echo Invalid choice. Please try again.
pause
cls
goto mainmenu

:: ===================================================================================================

:checkoutdated
cls
echo ========================================================================
echo   Checking for Outdated Packages
echo ========================================================================
echo:

echo Checking if dotnet-outdated tool is installed...
dotnet tool list --global | findstr /C:"dotnet-outdated" >nul 2>&1

if %ERRORLEVEL% == 0 (
    echo ✅ dotnet-outdated tool is installed
    echo:
    echo Checking for outdated packages in solution...
    echo:
    dotnet outdated "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"
) else (
    echo ❌ dotnet-outdated tool is not installed
    echo:
    echo Would you like to install it now? (Y/N)
    set /p install="Choice: "
    if /i "%install%"=="Y" (
        echo:
        echo Installing dotnet-outdated tool...
        dotnet tool install --global dotnet-outdated-tool
        echo:
        echo Tool installed! Running check...
        echo:
        dotnet outdated "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"
    ) else (
        echo:
        echo Using basic package list instead...
        echo:
        dotnet list "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" package --outdated
    )
)

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:updateall
cls
echo ========================================================================
echo   Update All NuGet Packages
echo ========================================================================
echo:
echo WARNING: This will force update all NuGet packages!
echo:
echo Are you sure you want to continue? (Y/N)
set /p confirm="Choice: "

if /i not "%confirm%"=="Y" (
    echo Operation cancelled.
    pause
    cls
    goto mainmenu
)

echo:
echo Updating all packages...
echo:

echo Step 1: Clearing local NuGet cache...
dotnet nuget locals all --clear

echo:
echo Step 2: Restoring packages with force flag...
dotnet restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" --force

echo:
echo ✅ All packages have been updated!
echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:clearcache
cls
echo ========================================================================
echo   Clear NuGet Cache
echo ========================================================================
echo:

echo Clearing all NuGet caches...
echo:

dotnet nuget locals all --clear

echo:
echo ✅ NuGet cache cleared successfully!
echo:
echo Cache locations that were cleared:
echo   - http-cache
echo   - global-packages
echo   - temp
echo   - plugins-cache
echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:listpackages
cls
echo ========================================================================
echo   List All Packages
echo ========================================================================
echo:

echo Listing all packages in the solution...
echo:

dotnet list "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" package

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:installtool
cls
echo ========================================================================
echo   Install dotnet-outdated Tool
echo ========================================================================
echo:

echo Checking current installation...
dotnet tool list --global | findstr /C:"dotnet-outdated"

echo:
echo Installing/Updating dotnet-outdated-tool...
echo:

dotnet tool install --global dotnet-outdated-tool

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Tool installed successfully!
) else (
    echo:
    echo Tool might already be installed. Attempting update...
    dotnet tool update --global dotnet-outdated-tool
)

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:updatespecific
cls
echo ========================================================================
echo   Update Specific Package
echo ========================================================================
echo:

echo This feature requires you to know:
echo   1. The project file path
echo   2. The package name
echo:

echo Example projects:
echo   - Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Core\Krypton.Toolkit.Suite.Extended.Core 2022.csproj
echo   - Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Controls\Krypton.Toolkit.Suite.Extended.Controls 2022.csproj
echo:

set /p projectpath="Enter project path (or 'back' to return): "

if /i "%projectpath%"=="back" (
    cls
    goto mainmenu
)

if not exist "%projectpath%" (
    echo:
    echo ❌ Project file not found: %projectpath%
    echo:
    pause
    cls
    goto mainmenu
)

echo:
set /p packagename="Enter package name to update: "

echo:
echo Updating %packagename% in project...
echo:

dotnet add "%projectpath%" package %packagename%

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:restore
cls
echo ========================================================================
echo   Restore NuGet Packages
echo ========================================================================
echo:

echo Restoring all NuGet packages (normal restore)...
echo:

dotnet restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Packages restored successfully!
) else (
    echo:
    echo ❌ Restore failed! Check the error messages above.
)

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:showsources
cls
echo ========================================================================
echo   NuGet Package Sources
echo ========================================================================
echo:

echo Current NuGet sources:
echo:

dotnet nuget list source

echo:
echo To add a new source:
echo   dotnet nuget add source [URL] --name [NAME]
echo:
echo To remove a source:
echo   dotnet nuget remove source [NAME]
echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:exit
echo:
echo Returning to main build system...
echo:
exit /b 0
