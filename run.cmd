:: Krypton Extended Toolkit - Interactive Build System
:: Last updated: Saturday 29th August, 2026

@echo off
setlocal EnableExtensions

title Krypton Extended Toolkit Build System

set "REPO_ROOT=%~dp0"
set "VS_VERSION="
set "VS_SCRIPTS_DIR="

goto selectvsversion

:: ===================================================================================================

:selectvsversion
cls
echo Welcome to the Krypton Extended Toolkit Build system, version 5.0.
echo Please select the Visual Studio toolset to target.
echo:
echo ==============================================================================================
echo:
echo 1. Visual Studio 2022 (Scripts\VS2022)
echo 2. Visual Studio 2026 (Scripts\Current)
echo 3. End
echo:
set /p answer="Enter number (1 - 3): "
if "%answer%"=="1" (goto usevs2022)
if "%answer%"=="2" (goto usevscurrent)
if "%answer%"=="3" (goto exitbuildsystem)
echo Invalid input, please try again.
pause
goto selectvsversion

:usevs2022
call :configurevsversion VS2022
if errorlevel 1 (goto selectvsversion)
goto mainmenu

:usevscurrent
call :configurevsversion Current
if errorlevel 1 (goto selectvsversion)
goto mainmenu

:configurevsversion
set "VS_VERSION=%~1"
set "VS_SCRIPTS_DIR=%REPO_ROOT%Scripts\%~1"
if not exist "%VS_SCRIPTS_DIR%" (
    echo.
    echo ERROR: Could not find "%VS_SCRIPTS_DIR%".
    pause
    set "VS_VERSION="
    set "VS_SCRIPTS_DIR="
    exit /b 1
)
echo.
echo Using %VS_VERSION% scripts located at "%VS_SCRIPTS_DIR%".
echo.
exit /b 0

:cleanworkspace
echo Cleaning Bin, obj, and Logs...
call "%REPO_ROOT%clean.cmd" /q
exit /b 0

:: ===================================================================================================

:mainmenu
cls
if "%VS_SCRIPTS_DIR%"=="" (goto selectvsversion)

echo Krypton Extended Toolkit Build System v5.0
echo Current Visual Studio target: %VS_VERSION%
echo Script directory............: %VS_SCRIPTS_DIR%
echo:
echo 1. Clean project
echo 2. Build Toolkit
echo 3. Create NuGet packages
echo 4. Build and Pack Toolkit
echo 5. Debug project
echo 6. NuGet Package Manager
echo 7. Ultimate Package Diagnostic
echo 8. Create Archives (ZIP/TAR)
echo 9. Change Visual Studio target
echo 10. End
echo:
set /p answer="Enter number (1 - 10): "
if "%answer%"=="1" (goto cleanproject)
if "%answer%"=="2" (goto buildmenu)
if "%answer%"=="3" (goto packmenu)
if "%answer%"=="4" (goto buildandpackmenu)
if "%answer%"=="5" (goto debugmenu)
if "%answer%"=="6" (goto nugetmanager)
if "%answer%"=="7" (goto ultimatediagnostic)
if "%answer%"=="8" (goto createarchives)
if "%answer%"=="9" (goto selectvsversion)
if "%answer%"=="10" (goto exitbuildsystem)
echo Invalid input, please try again.
pause
goto mainmenu

:buildmenu
cls
echo 1. Build nightly version (alpha, -alpha)
echo 2. Build canary version (canary, -beta)
echo 3. Build stable version (master)
echo 4. Rebuild nightly
echo 5. Go back to main menu
echo:
set /p answer="Enter number (1 - 5): "
if "%answer%"=="1" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" & goto buildmenu)
if "%answer%"=="2" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" & goto buildmenu)
if "%answer%"=="3" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" & goto buildmenu)
if "%answer%"=="4" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" Rebuild & goto buildmenu)
if "%answer%"=="5" (goto mainmenu)
echo Invalid input, please try again.
pause
goto buildmenu

:packmenu
cls
echo 1. Pack nightly (full)
echo 2. Pack nightly lite
echo 3. Pack nightly full + lite
echo 4. Pack canary (full)
echo 5. Pack canary lite
echo 6. Pack canary full + lite
echo 7. Pack stable (full)
echo 8. Pack stable lite
echo 9. Pack stable full + lite
echo 10. Go back to main menu
echo:
set /p answer="Enter number (1 - 10): "
if "%answer%"=="1" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" Pack & goto packmenu)
if "%answer%"=="2" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" PackLite & goto packmenu)
if "%answer%"=="3" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" PackAll & goto packmenu)
if "%answer%"=="4" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" Pack & goto packmenu)
if "%answer%"=="5" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" PackLite & goto packmenu)
if "%answer%"=="6" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" PackAll & goto packmenu)
if "%answer%"=="7" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" Pack & goto packmenu)
if "%answer%"=="8" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" PackLite & goto packmenu)
if "%answer%"=="9" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" PackAll & goto packmenu)
if "%answer%"=="10" (goto mainmenu)
echo Invalid input, please try again.
pause
goto packmenu

:buildandpackmenu
cls
echo 1. Build and pack nightly
echo 2. Build and pack canary
echo 3. Build and pack stable
echo 4. Build and pack all channels
echo 5. Go back to main menu
echo:
set /p answer="Enter number (1 - 5): "
if "%answer%"=="1" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" CI & goto buildandpackmenu)
if "%answer%"=="2" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" CI & goto buildandpackmenu)
if "%answer%"=="3" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" CI & goto buildandpackmenu)
if "%answer%"=="4" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" CIAll & goto buildandpackmenu)
if "%answer%"=="5" (goto mainmenu)
echo Invalid input, please try again.
pause
goto buildandpackmenu

:debugmenu
cls
echo 1. Debug build
echo 2. Run TestForm
echo 3. Go back to main menu
echo:
set /p answer="Enter number (1 - 3): "
if "%answer%"=="1" (call "%VS_SCRIPTS_DIR%\debug.cmd" Rebuild & goto debugmenu)
if "%answer%"=="2" (goto runtestform)
if "%answer%"=="3" (goto mainmenu)
echo Invalid input, please try again.
pause
goto debugmenu

:createarchives
cls
echo 1. Create ZIP archive (Nightly)
echo 2. Create TAR archive (Nightly)
echo 3. Create both (Nightly)
echo 4. Create ZIP archive (Canary)
echo 5. Create TAR archive (Canary)
echo 6. Create both (Canary)
echo 7. Create ZIP archive (Stable)
echo 8. Create TAR archive (Stable)
echo 9. Create both (Stable)
echo 10. Go back to main menu
echo:
set /p answer="Enter number (1 - 10): "
if "%answer%"=="1" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" CreateNightlyZip & goto createarchives)
if "%answer%"=="2" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" CreateNightlyTar & goto createarchives)
if "%answer%"=="3" (call "%VS_SCRIPTS_DIR%\build-nightly.cmd" CreateAllArchives & goto createarchives)
if "%answer%"=="4" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" CreateCanaryZip & goto createarchives)
if "%answer%"=="5" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" CreateCanaryTar & goto createarchives)
if "%answer%"=="6" (call "%VS_SCRIPTS_DIR%\build-canary.cmd" CreateAllCanaryArchives & goto createarchives)
if "%answer%"=="7" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" CreateReleaseZip & goto createarchives)
if "%answer%"=="8" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" CreateReleaseTar & goto createarchives)
if "%answer%"=="9" (call "%VS_SCRIPTS_DIR%\build-stable.cmd" CreateAllReleaseArchives & goto createarchives)
if "%answer%"=="10" (goto mainmenu)
echo Invalid input, please try again.
pause
goto createarchives

:cleanproject
cls
call :cleanworkspace
pause
goto mainmenu

:nugetmanager
cls
if exist "%REPO_ROOT%update-nuget.cmd" (
    call "%REPO_ROOT%update-nuget.cmd"
) else (
    echo update-nuget.cmd not found.
    pause
)
goto mainmenu

:ultimatediagnostic
cls
if exist "%REPO_ROOT%ultimate-diagnostic.cmd" (
    call "%REPO_ROOT%ultimate-diagnostic.cmd"
) else (
    echo ultimate-diagnostic.cmd not found.
    pause
)
goto mainmenu

:runtestform
cls
if exist "%REPO_ROOT%run-testform.cmd" (
    call "%REPO_ROOT%run-testform.cmd"
) else (
    echo run-testform.cmd not found.
    pause
)
goto debugmenu

:exitbuildsystem
echo Exiting the build system. Bye!
pause
exit /b 0
