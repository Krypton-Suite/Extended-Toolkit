@echo off
REM =============================================================================
REM invoke-msbuild.cmd - Run a channel .proj with the selected VS toolset
REM
REM USAGE
REM   call "%~dp0invoke-msbuild.cmd" <profile> <proj-file> <log-name> [target]
REM
REM EXAMPLES
REM   call invoke-msbuild.cmd 2022 nightly.proj nightly Build
REM   call invoke-msbuild.cmd current build.proj stable Pack
REM
REM Set NOPAUSE=1 to skip the trailing pause (used by run.cmd and CI helpers).
REM =============================================================================

setlocal EnableExtensions
set "PROFILE=%~1"
set "PROJ_FILE=%~2"
set "LOG_NAME=%~3"
set "TARGETS=%~4"

if "%PROFILE%"=="" goto :usage
if "%PROJ_FILE%"=="" goto :usage
if "%LOG_NAME%"=="" goto :usage
if "%TARGETS%"=="" set "TARGETS=Build"

set "COMMON_DIR=%~dp0"
set "REPO_ROOT=%COMMON_DIR%..\.."
set "PROJ_PATH=%COMMON_DIR%..\Build\%PROJ_FILE%"

call "%COMMON_DIR%find-msbuild.cmd" %PROFILE%
if errorlevel 1 (
    if not defined NOPAUSE pause
    exit /b 1
)

if not exist "%PROJ_PATH%" (
    echo ERROR: Project file not found: "%PROJ_PATH%"
    if not defined NOPAUSE pause
    exit /b 1
)

if not exist "%REPO_ROOT%\Logs" mkdir "%REPO_ROOT%\Logs"

for /f "tokens=* usebackq" %%A in (`tzutil /g`) do set "zone=%%A"

echo Started: %date% %time% %zone%
echo Project: %PROJ_PATH%
echo Target : %TARGETS%
echo.

"%msbuildpath%\msbuild.exe" /m /t:"%TARGETS%" "%PROJ_PATH%" /fl /flp:logfile="%REPO_ROOT%\Logs\%LOG_NAME%-build-log.log" /bl:"%REPO_ROOT%\Logs\%LOG_NAME%-build.binlog" /clp:Summary;ShowTimestamp /v:minimal
set "EC=%ERRORLEVEL%"

echo.
if "%EC%"=="0" (
    echo Build completed: %date% %time% %zone%
) else (
    echo Build failed with exit code %EC%: %date% %time% %zone%
)
echo Logs: %REPO_ROOT%\Logs\%LOG_NAME%-build-log.log
echo.

if not defined NOPAUSE pause
exit /b %EC%

:usage
echo Usage: invoke-msbuild.cmd ^<profile^> ^<proj-file^> ^<log-name^> [target]
exit /b 1
