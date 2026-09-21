@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" current build.proj stable %*
exit /b %ERRORLEVEL%
