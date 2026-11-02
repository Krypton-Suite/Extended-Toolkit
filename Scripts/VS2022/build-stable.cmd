@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" 2022 build.proj stable %*
exit /b %ERRORLEVEL%
