@echo off
:: Quick build script for common scenarios

echo Krypton Extended Toolkit - Quick Build
echo =====================================

echo.
echo Select build type:
echo 1. Debug Build
echo 2. Release Build  
echo 3. Canary Build
echo 4. Nightly Build
echo 5. Clean Only
echo 6. Check Package Updates
echo 7. Update Packages
echo 8. Update All Packages
echo 9. Restore Packages
echo.

set /p choice="Enter your choice (1 - 9): "

if "%choice%"=="1" (
    echo Building Debug configuration...
    call Scripts\build.cmd Debug
) else if "%choice%"=="2" (
    echo Building Release configuration...
    call Scripts\build.cmd Release
) else if "%choice%"=="3" (
    echo Building Canary configuration...
    call Scripts\build.cmd Canary
) else if "%choice%"=="4" (
    echo Building Nightly configuration...
    call Scripts\build.cmd Nightly
) else if "%choice%"=="5" (
    echo Cleaning build artifacts...
    call clean.cmd
) else if "%choice%"=="6" (
    echo Checking for package updates...
    powershell -ExecutionPolicy Bypass -File Scripts\build.ps1 -CheckUpdates
) else if "%choice%"=="7" (
    echo Updating packages...
    powershell -ExecutionPolicy Bypass -File Scripts\build.ps1 -UpdatePackages
) else if "%choice%"=="8" (
    echo Updating all packages...
    powershell -ExecutionPolicy Bypass -File Scripts\build.ps1 -UpdateAll
) else if "%choice%"=="9" (
    echo Restoring packages...
    powershell -ExecutionPolicy Bypass -File Scripts\manage-packages.ps1 restore
) else (
    echo Invalid choice. Please run again.
    pause
    exit /b 1
)

echo.
echo Operation completed!
pause
