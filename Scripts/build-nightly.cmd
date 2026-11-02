@echo off
REM Compatibility shim: use Scripts\VS2022 unless KRYPTON_VS_PROFILE=Current
setlocal EnableExtensions
if /I "%KRYPTON_VS_PROFILE%"=="Current" (
    call "%~dp0Current\build-nightly.cmd" %*
) else (
    call "%~dp0VS2022\build-nightly.cmd" %*
)
exit /b %ERRORLEVEL%
