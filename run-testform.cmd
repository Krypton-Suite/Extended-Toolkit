@echo off
setlocal

cd /d "%~dp0"

set "PROJECT=Source\Krypton Toolkit\TestForm\TestForm.csproj"
set "FRAMEWORK=net8.0-windows"
if not "%~1"=="" set "FRAMEWORK=%~1"

echo Running TestForm (%FRAMEWORK%)...
dotnet run --project "%PROJECT%" -c Debug -f "%FRAMEWORK%"
if errorlevel 1 (
    echo.
    echo TestForm failed to start.
    pause
    exit /b 1
)
