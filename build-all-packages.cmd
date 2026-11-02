@echo off
REM Build full + lite packages for Nightly, Canary, and Release
setlocal EnableExtensions
set "NOPAUSE=1"
cd /d "%~dp0"
call "%~dp0Scripts\build-nightly.cmd" PackAll
if errorlevel 1 exit /b %ERRORLEVEL%
call "%~dp0Scripts\build-canary.cmd" PackAll
if errorlevel 1 exit /b %ERRORLEVEL%
call "%~dp0Scripts\build-release.cmd" PackAll
exit /b %ERRORLEVEL%
