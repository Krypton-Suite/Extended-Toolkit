@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" 2022 canary.proj canary %*
exit /b %ERRORLEVEL%
