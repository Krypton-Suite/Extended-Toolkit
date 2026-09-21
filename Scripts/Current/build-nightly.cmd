@echo off
setlocal EnableExtensions
call "%~dp0..\Common\invoke-msbuild.cmd" current nightly.proj nightly %*
exit /b %ERRORLEVEL%
