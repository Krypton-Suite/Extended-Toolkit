@echo off
setlocal EnableExtensions
if /I "%KRYPTON_VS_PROFILE%"=="Current" (
    call "%~dp0Current\build-lts.cmd" %*
) else (
    call "%~dp0VS2022\build-lts.cmd" %*
)
exit /b %ERRORLEVEL%
