@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" 2022 debug.proj debug %*
exit /b %ERRORLEVEL%
