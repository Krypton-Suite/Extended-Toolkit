@echo off
setlocal EnableExtensions

cd /d "%~dp0"

if /I "%~1"=="/q" goto clean
if /I "%~1"=="-q" goto clean
if /I "%~1"=="/y" goto clean

echo You are about to delete Bin, obj, and build logs. Continue? (Y/N)
set /P INPUT=Type input:
if /I "%INPUT%"=="y" goto clean
echo Cancelled.
goto :eof

:clean
echo Deleting Bin...
if exist "Bin" rd /s /q "Bin"

echo Deleting obj directories under Source...
powershell.exe -NoProfile -Command "Get-ChildItem -LiteralPath 'Source' -Directory -Filter 'obj' -Recurse -ErrorAction SilentlyContinue | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue"

echo Deleting Logs...
if exist "Logs" (
    del /q "Logs\*.log" 2>nul
    del /q "Logs\*.binlog" 2>nul
)

if exist "build.log" del /f /q "build.log"
if exist "debug.log" del /f /q "debug.log"
if exist "package-restore.log" del /f /q "package-restore.log"

echo Clean completed.
if /I not "%~1"=="/q" if /I not "%~1"=="-q" if /I not "%~1"=="/y" pause
exit /b 0
