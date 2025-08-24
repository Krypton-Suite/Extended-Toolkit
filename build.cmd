@echo off
:: Wrapper script for the main build system
:: This script calls the main build script in the Scripts directory

if "%1"=="" (
    echo Krypton Extended Toolkit Build System
    echo =====================================
    echo.
    echo Usage: build.cmd [Configuration] [Platform] [TargetFramework]
    echo.
    echo Examples:
    echo   build.cmd                    - Build Release configuration
    echo   build.cmd Release            - Build Release configuration
    echo   build.cmd Debug "Any CPU"       - Build Debug configuration
    echo   build.cmd Canary "Any CPU" net8.0-windows
    echo.
    echo For more options, use: Scripts\build.cmd /?
    echo.
    pause
    exit /b 1
)

:: Call the main build script in the Scripts directory
call Scripts\build.cmd %*

if %ERRORLEVEL% neq 0 (
    echo.
    echo Build failed. Check the output above for errors.
    pause
    exit /b 1
)
