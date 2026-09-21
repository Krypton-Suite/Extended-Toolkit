@echo off
setlocal EnableExtensions
if /I "%KRYPTON_VS_PROFILE%"=="Current" (
    call "%~dp0Current\build-canary.cmd" %*
) else (
    call "%~dp0VS2022\build-canary.cmd" %*
)
exit /b %ERRORLEVEL%
