@echo off
REM Build Release (full) and ReleaseLite packages
setlocal EnableExtensions
set "NOPAUSE=1"
cd /d "%~dp0"
call "%~dp0Scripts\build-release.cmd" PackAll
exit /b %ERRORLEVEL%
