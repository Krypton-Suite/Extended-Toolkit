@echo off
:: Test script to verify all build configurations work

echo Testing Krypton Extended Toolkit Build System
echo =============================================

echo.
echo Testing Debug configuration...
Scripts\build.cmd Debug "Any CPU" net8.0-windows
if %ERRORLEVEL% neq 0 (
    echo Debug build FAILED
    pause
    exit /b 1
) else (
    echo Debug build SUCCESS
)

echo.
echo Testing Release configuration...
Scripts\build.cmd Release "Any CPU" net8.0-windows
if %ERRORLEVEL% neq 0 (
    echo Release build FAILED
    pause
    exit /b 1
) else (
    echo Release build SUCCESS
)

echo.
echo Testing Canary configuration...
Scripts\build.cmd Canary "Any CPU" net8.0-windows
if %ERRORLEVEL% neq 0 (
    echo Canary build FAILED
    pause
    exit /b 1
) else (
    echo Canary build SUCCESS
)

echo.
echo Testing Nightly configuration...
Scripts\build.cmd Nightly "Any CPU" net8.0-windows
if %ERRORLEVEL% neq 0 (
    echo Nightly build FAILED
    pause
    exit /b 1
) else (
    echo Nightly build SUCCESS
)

echo.
echo =============================================
echo All build configurations tested successfully!
echo =============================================
pause
