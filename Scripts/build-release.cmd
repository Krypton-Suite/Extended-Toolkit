@echo off
setlocal EnableExtensions
if /I "%KRYPTON_VS_PROFILE%"=="Current" (
    call "%~dp0Current\build-stable.cmd" %*
) else (
    call "%~dp0VS2022\build-stable.cmd" %*
)
exit /b %ERRORLEVEL%
