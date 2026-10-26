@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" current debug.proj debug %*
exit /b %ERRORLEVEL%
