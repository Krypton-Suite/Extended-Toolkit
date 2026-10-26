@echo off
REM Build Nightly (full) and NightlyLite packages
setlocal EnableExtensions
set "NOPAUSE=1"
cd /d "%~dp0"
call "%~dp0Scripts\build-nightly.cmd" PackAll
exit /b %ERRORLEVEL%
