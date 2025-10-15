:: Krypton Extended Toolkit - Interactive Build System
:: Last updated: Wednesday 15th January, 2025

@echo off

title Krypton Extended Toolkit Build System

:: Try to find MSBuild
set MSBUILD=

:: Check Visual Studio 2022 Enterprise
if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

:: Check Visual Studio 2022 Professional
if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

:: Check Visual Studio 2022 Community
if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

:: Try to use MSBuild from PATH
where msbuild.exe >nul 2>&1
if %ERRORLEVEL% == 0 (
    set MSBUILD=msbuild.exe
    goto :found
)

:: MSBuild not found
echo ERROR: MSBuild.exe not found!
echo.
echo Please install Visual Studio 2022 or ensure MSBuild is in your PATH.
echo.
pause
exit /b 1

:found

cls

@echo Welcome to the Krypton Extended Toolkit Build system, version: 4.0 (MSBuild Edition)
echo Using MSBuild: %MSBUILD%
echo:
@echo ==============================================================================================
echo:
echo 1. Clean project
echo 2. Build Toolkit
echo 3. Create NuGet packages  
echo 4. Build and Pack Toolkit
echo 5. Debug project
echo 6. Rebuild project
echo 7. NuGet Package Manager
echo 8. Show build information
echo 9. Create Archives (ZIP/TAR)
echo 10. End
echo:
set /p answer="Enter number (1 - 10): "
if %answer%==1 (goto cleanproject)
if %answer%==2 (goto buildproject)
if %answer%==3 (goto createnugetpackages)
if %answer%==4 (goto buildandpacktoolkit)
if %answer%==5 (goto debugproject)
if %answer%==6 (goto rebuildproject)
if %answer%==7 (goto nugetmanager)
if %answer%==8 (goto showbuildinfo)
if %answer%==9 (goto createarchives)
if %answer%==10 (goto exitbuildsystem)

@echo Invalid input, please try again.
pause
goto mainmenu

:: ===================================================================================================

:mainmenu

cls

echo Krypton Extended Toolkit Build System v4.0
echo Using MSBuild: %MSBUILD%
echo:
echo 1. Clean project
echo 2. Build Toolkit
echo 3. Create NuGet packages
echo 4. Build and Pack Toolkit
echo 5. Debug project
echo 6. Rebuild project
echo 7. NuGet Package Manager
echo 8. Show build information
echo 9. Create Archives (ZIP/TAR)
echo 10. End
echo:
set /p answer="Enter number (1 - 10): "
if %answer%==1 (goto cleanproject)
if %answer%==2 (goto buildproject)
if %answer%==3 (goto createnugetpackages)
if %answer%==4 (goto buildandpacktoolkit)
if %answer%==5 (goto debugproject)
if %answer%==6 (goto rebuildproject)
if %answer%==7 (goto nugetmanager)
if %answer%==8 (goto showbuildinfo)
if %answer%==9 (goto createarchives)
if %answer%==10 (goto exitbuildsystem)

@echo Invalid input, please try again.
pause
goto mainmenu

:: ===================================================================================================

:buildmenu
cls

echo Build Menu - Select Configuration:
echo:
echo 1. Build Nightly version (alpha branch, -alpha suffix)
echo 2. Build Canary version (canary branch, -beta suffix) 
echo 3. Build Stable version (master branch, stable packages)
echo 4. Build Debug version
echo 5. Go back to main menu
echo:
set /p answer="Enter number (1 - 5): "
if %answer%==1 (goto buildnightly)
if %answer%==2 (goto buildcanary)
if %answer%==3 (goto buildstable)
if %answer%==4 (goto builddebug)
if %answer%==5 (goto mainmenu)

@echo Invalid input, please try again.
pause
goto buildmenu

:packmenu
cls

echo Pack Menu - Select Configuration:
echo:
echo 1. Pack Nightly version (alpha packages)
echo 2. Pack Canary version (beta packages)
echo 3. Pack Stable version (release packages)
echo 4. Go back to main menu
echo:
set /p answer="Enter number (1 - 4): "
if %answer%==1 (goto packnightly)
if %answer%==2 (goto packcanary)
if %answer%==3 (goto packstable)
if %answer%==4 (goto mainmenu)

@echo Invalid input, please try again.
pause
goto packmenu

:buildandpackmenu
cls

echo Build and Pack Menu - Select Configuration:
echo:
echo 1. Build and Pack Nightly (Complete CI)
echo 2. Build and Pack Canary (Complete CI)
echo 3. Build and Pack Stable (Complete CI)
echo 4. Build and Pack All Configurations
echo 5. Go back to main menu
echo:
set /p answer="Enter number (1 - 5): "
if %answer%==1 (goto buildandpacknightly)
if %answer%==2 (goto buildandpackcanary)
if %answer%==3 (goto buildandpackstable)
if %answer%==4 (goto buildandpackall)
if %answer%==5 (goto mainmenu)

@echo Invalid input, please try again.
pause
goto buildandpackmenu

:createarchives
cls

echo Archive Creation Menu:
echo:
echo 1. Create ZIP archive (Nightly)
echo 2. Create ZIP archive (Canary)
echo 3. Create ZIP archive (Stable)
echo 4. Create ZIP archives (All configurations)
echo 5. Show package locations
echo 6. Go back to main menu
echo:
set /p answer="Enter number (1 - 6): "
if %answer%==1 (goto createzipnightly)
if %answer%==2 (goto createzipcanary)
if %answer%==3 (goto createzipstable)
if %answer%==4 (goto createzipall)
if %answer%==5 (goto showpackagelocations)
if %answer%==6 (goto mainmenu)

@echo Invalid input, please try again.
pause
goto createarchives

:: ===================================================================================================
:: Main Actions
:: ===================================================================================================

:cleanproject
cls
echo ========================================================================
echo   Cleaning Project
echo ========================================================================
echo:

echo Running: "%MSBUILD%" Build.proj /t:Clean /v:minimal
"%MSBUILD%" Build.proj /t:Clean /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Clean completed successfully!
) else (
    echo:
    echo ❌ Clean failed!
)

echo:
pause
goto mainmenu

:buildproject
goto buildmenu

:createnugetpackages
goto packmenu

:buildandpacktoolkit
goto buildandpackmenu

:debugproject
cls
echo ========================================================================
echo   Debug Build
echo ========================================================================
echo:

echo Running: "%MSBUILD%" Build.proj /t:Debug /v:minimal
"%MSBUILD%" Build.proj /t:Debug /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Debug build completed successfully!
    echo Output: Bin\Debug\
) else (
    echo:
    echo ❌ Debug build failed!
)

echo:
pause
goto mainmenu

:rebuildproject
cls
echo ========================================================================
echo   Rebuild Project (Clean + Build)
echo ========================================================================
echo:

echo Running: "%MSBUILD%" Build.proj /t:Rebuild /v:minimal
"%MSBUILD%" Build.proj /t:Rebuild /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Rebuild completed successfully!
) else (
    echo:
    echo ❌ Rebuild failed!
)

echo:
pause
goto mainmenu

:nugetmanager
cls
echo ========================================================================
echo   Launching NuGet Package Manager
echo ========================================================================
echo:

if exist "update-nuget.cmd" (
    call update-nuget.cmd
    cls
    goto mainmenu
) else (
    echo ❌ Error: update-nuget.cmd not found!
    echo:
    echo Please ensure update-nuget.cmd is in the same directory as run.cmd
    echo:
    pause
    goto mainmenu
)

:showbuildinfo
cls
echo ========================================================================
echo   Build System Information
echo ========================================================================
echo:
echo MSBuild: %MSBUILD%
echo Build Project: Build.proj
echo:
echo Release Channels:
echo   - Nightly ^(alpha branch, -alpha suffix^)
echo   - Canary ^(canary branch, -beta suffix^)
echo   - Stable ^(master branch, no suffix^)
echo:
echo Output Locations:
echo   - Binaries: Bin\{Configuration}\
echo   - Packages: Bin\NuGet Packages\{Configuration}\
echo:
echo Available Targets:
echo   - Clean: Remove all build outputs
echo   - Build: Build main solution
echo   - Pack: Create NuGet packages
echo   - CI: Complete CI pipeline ^(Clean + Build + Pack^)
echo   - Debug: Build Debug configuration
echo   - Rebuild: Clean + Build
echo:
pause
goto mainmenu

:exitbuildsystem
cls
echo ========================================================================
echo   Thank you for using the Krypton Extended Toolkit Build System!
echo ========================================================================
echo:
echo Build system v4.0 with MSBuild integration
echo Have a great day! 🎉
echo:
pause
exit

:: ===================================================================================================
:: Build Actions
:: ===================================================================================================

:buildnightly
cls
echo ========================================================================
echo   Building Nightly Configuration
echo ========================================================================
echo Target: alpha branch, -alpha package suffix
echo:

echo Running: "%MSBUILD%" Build.proj /t:Build /p:Configuration=Nightly /v:minimal
"%MSBUILD%" Build.proj /t:Build /p:Configuration=Nightly /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Nightly build completed successfully!
    echo Output: Bin\Nightly\
) else (
    echo:
    echo ❌ Nightly build failed!
)

echo:
pause
goto mainmenu

:buildcanary
cls
echo ========================================================================
echo   Building Canary Configuration
echo ========================================================================
echo Target: canary branch, -beta package suffix
echo:

echo Running: "%MSBUILD%" Build.proj /t:Build /p:Configuration=Canary /v:minimal
"%MSBUILD%" Build.proj /t:Build /p:Configuration=Canary /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Canary build completed successfully!
    echo Output: Bin\Canary\
) else (
    echo:
    echo ❌ Canary build failed!
)

echo:
pause
goto mainmenu

:buildstable
cls
echo ========================================================================
echo   Building Stable Configuration
echo ========================================================================
echo Target: master branch, stable packages
echo:

echo Running: "%MSBUILD%" Build.proj /t:Build /p:Configuration=Release /v:minimal
"%MSBUILD%" Build.proj /t:Build /p:Configuration=Release /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Stable build completed successfully!
    echo Output: Bin\Release\
) else (
    echo:
    echo ❌ Stable build failed!
)

echo:
pause
goto mainmenu

:builddebug
cls
echo ========================================================================
echo   Building Debug Configuration
echo ========================================================================
echo:

echo Running: "%MSBUILD%" Build.proj /t:Build /p:Configuration=Debug /v:minimal
"%MSBUILD%" Build.proj /t:Build /p:Configuration=Debug /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Debug build completed successfully!
    echo Output: Bin\Debug\
) else (
    echo:
    echo ❌ Debug build failed!
)

echo:
pause
goto mainmenu

:: ===================================================================================================
:: Pack Actions
:: ===================================================================================================

:packnightly
cls
echo ========================================================================
echo   Creating Nightly Packages
echo ========================================================================
echo Target: alpha packages with -alpha suffix
echo:

echo Running: "%MSBUILD%" Build.proj /t:Pack /p:Configuration=Nightly /v:minimal
"%MSBUILD%" Build.proj /t:Pack /p:Configuration=Nightly /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Nightly packages created successfully!
    echo Output: Bin\NuGet Packages\Nightly\
) else (
    echo:
    echo ❌ Nightly packaging failed!
)

echo:
pause
goto mainmenu

:packcanary
cls
echo ========================================================================
echo   Creating Canary Packages
echo ========================================================================
echo Target: beta packages with -beta suffix
echo:

echo Running: "%MSBUILD%" Build.proj /t:Pack /p:Configuration=Canary /v:minimal
"%MSBUILD%" Build.proj /t:Pack /p:Configuration=Canary /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Canary packages created successfully!
    echo Output: Bin\NuGet Packages\Canary\
) else (
    echo:
    echo ❌ Canary packaging failed!
)

echo:
pause
goto mainmenu

:packstable
cls
echo ========================================================================
echo   Creating Stable Packages
echo ========================================================================
echo Target: stable packages with no suffix
echo:

echo Running: "%MSBUILD%" Build.proj /t:Pack /p:Configuration=Release /v:minimal
"%MSBUILD%" Build.proj /t:Pack /p:Configuration=Release /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Stable packages created successfully!
    echo Output: Bin\NuGet Packages\Release\
) else (
    echo:
    echo ❌ Stable packaging failed!
)

echo:
pause
goto mainmenu

:: ===================================================================================================
:: Build and Pack Actions (Complete CI)
:: ===================================================================================================

:buildandpacknightly
cls
echo ========================================================================
echo   Complete CI: Nightly (Clean + Build + Pack)
echo ========================================================================
echo Target: alpha branch, -alpha packages
echo:

echo Running: "%MSBUILD%" Build.proj /t:CI /p:Configuration=Nightly /v:minimal
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Nightly /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Nightly CI completed successfully!
    echo Binaries: Bin\Nightly\
    echo Packages: Bin\NuGet Packages\Nightly\
) else (
    echo:
    echo ❌ Nightly CI failed!
)

echo:
pause
goto mainmenu

:buildandpackcanary
cls
echo ========================================================================
echo   Complete CI: Canary (Clean + Build + Pack)
echo ========================================================================
echo Target: canary branch, -beta packages
echo:

echo Running: "%MSBUILD%" Build.proj /t:CI /p:Configuration=Canary /v:minimal
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Canary /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Canary CI completed successfully!
    echo Binaries: Bin\Canary\
    echo Packages: Bin\NuGet Packages\Canary\
) else (
    echo:
    echo ❌ Canary CI failed!
)

echo:
pause
goto mainmenu

:buildandpackstable
cls
echo ========================================================================
echo   Complete CI: Stable (Clean + Build + Pack)
echo ========================================================================
echo Target: master branch, stable packages
echo:

echo Running: "%MSBUILD%" Build.proj /t:CI /p:Configuration=Release /v:minimal
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Release /v:minimal

if %ERRORLEVEL% == 0 (
    echo:
    echo ✅ Stable CI completed successfully!
    echo Binaries: Bin\Release\
    echo Packages: Bin\NuGet Packages\Release\
) else (
    echo:
    echo ❌ Stable CI failed!
)

echo:
pause
goto mainmenu

:buildandpackall
cls
echo ========================================================================
echo   Complete CI: All Configurations
echo ========================================================================
echo Building Nightly, Canary, and Stable configurations
echo:

echo Step 1/3: Building Nightly...
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Nightly /v:minimal

echo:
echo Step 2/3: Building Canary...
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Canary /v:minimal

echo:
echo Step 3/3: Building Stable...
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Release /v:minimal

echo:
echo ✅ All configurations completed!
echo:
echo Output locations:
echo   Nightly - Bin\Nightly\ and Bin\NuGet Packages\Nightly\
echo   Canary  - Bin\Canary\ and Bin\NuGet Packages\Canary\
echo   Stable  - Bin\Release\ and Bin\NuGet Packages\Release\

echo:
pause
goto mainmenu

:: ===================================================================================================
:: Archive Actions
:: ===================================================================================================

:createzipnightly
cls
echo ========================================================================
echo   Creating Nightly ZIP Archive
echo ========================================================================
echo:

if not exist "Bin\NuGet Packages\Nightly" (
    echo ❌ Nightly packages not found! Please build first.
    pause
    goto mainmenu
)

echo Creating ZIP archive from Nightly packages...
if exist "NightlyPackages.zip" del "NightlyPackages.zip"
powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Nightly\*' -DestinationPath 'NightlyPackages.zip'"

if exist "NightlyPackages.zip" (
    echo ✅ Nightly ZIP archive created: NightlyPackages.zip
) else (
    echo ❌ Failed to create ZIP archive
)

echo:
pause
goto mainmenu

:createzipcanary
cls
echo ========================================================================
echo   Creating Canary ZIP Archive
echo ========================================================================
echo:

if not exist "Bin\NuGet Packages\Canary" (
    echo ❌ Canary packages not found! Please build first.
    pause
    goto mainmenu
)

echo Creating ZIP archive from Canary packages...
if exist "CanaryPackages.zip" del "CanaryPackages.zip"
powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Canary\*' -DestinationPath 'CanaryPackages.zip'"

if exist "CanaryPackages.zip" (
    echo ✅ Canary ZIP archive created: CanaryPackages.zip
) else (
    echo ❌ Failed to create ZIP archive
)

echo:
pause
goto mainmenu

:createzipstable
cls
echo ========================================================================
echo   Creating Stable ZIP Archive
echo ========================================================================
echo:

if not exist "Bin\NuGet Packages\Release" (
    echo ❌ Stable packages not found! Please build first.
    pause
    goto mainmenu
)

echo Creating ZIP archive from Stable packages...
if exist "StablePackages.zip" del "StablePackages.zip"
powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Release\*' -DestinationPath 'StablePackages.zip'"

if exist "StablePackages.zip" (
    echo ✅ Stable ZIP archive created: StablePackages.zip
) else (
    echo ❌ Failed to create ZIP archive
)

echo:
pause
goto mainmenu

:createzipall
cls
echo ========================================================================
echo   Creating ZIP Archives for All Configurations
echo ========================================================================
echo:

if exist "Bin\NuGet Packages\Nightly" (
    echo Creating Nightly ZIP...
    if exist "NightlyPackages.zip" del "NightlyPackages.zip"
    powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Nightly\*' -DestinationPath 'NightlyPackages.zip'"
)

if exist "Bin\NuGet Packages\Canary" (
    echo Creating Canary ZIP...
    if exist "CanaryPackages.zip" del "CanaryPackages.zip"
    powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Canary\*' -DestinationPath 'CanaryPackages.zip'"
)

if exist "Bin\NuGet Packages\Release" (
    echo Creating Stable ZIP...
    if exist "StablePackages.zip" del "StablePackages.zip"
    powershell -command "Compress-Archive -Path 'Bin\NuGet Packages\Release\*' -DestinationPath 'StablePackages.zip'"
)

echo:
echo ✅ ZIP archive creation completed!
echo Created archives: *.zip files in current directory

echo:
pause
goto mainmenu

:showpackagelocations
cls
echo ========================================================================
echo   Package Locations
echo ========================================================================
echo:

echo Current directory: %CD%
echo:

if exist "Bin\NuGet Packages\Nightly" (
    echo ✅ Nightly packages: Bin\NuGet Packages\Nightly\
) else (
    echo ❌ Nightly packages: Not built
)

if exist "Bin\NuGet Packages\Canary" (
    echo ✅ Canary packages: Bin\NuGet Packages\Canary\
) else (
    echo ❌ Canary packages: Not built
)

if exist "Bin\NuGet Packages\Release" (
    echo ✅ Stable packages: Bin\NuGet Packages\Release\
) else (
    echo ❌ Stable packages: Not built
)

echo:
echo ZIP Archives:
if exist "NightlyPackages.zip" (echo ✅ NightlyPackages.zip) else (echo ❌ NightlyPackages.zip)
if exist "CanaryPackages.zip" (echo ✅ CanaryPackages.zip) else (echo ❌ CanaryPackages.zip)
if exist "StablePackages.zip" (echo ✅ StablePackages.zip) else (echo ❌ StablePackages.zip)

echo:
pause
goto mainmenu
