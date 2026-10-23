@echo off
REM Build Canary (full) and CanaryLite packages
setlocal EnableExtensions
set "NOPAUSE=1"
cd /d "%~dp0"
call "%~dp0Scripts\build-canary.cmd" PackAll
exit /b %ERRORLEVEL%
