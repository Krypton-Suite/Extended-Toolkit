@echo off
setlocal EnableExtensions
if /I "%KRYPTON_VS_PROFILE%"=="Current" (
    call "%~dp0Current\build-stable.cmd" CIAll
) else (
    call "%~dp0VS2022\build-stable.cmd" CIAll
)
exit /b %ERRORLEVEL%
