@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" 2022 nightly.proj nightly %*
exit /b %ERRORLEVEL%
