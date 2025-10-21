@echo off
REM ========================================================================
REM Krypton Extended Toolkit - Quick Build Script
REM 
REM This script builds the Release configuration of the toolkit.
REM For other configurations, use build-canary.cmd or build-nightly.cmd
REM ========================================================================

echo.
echo ========================================================================
echo   Krypton Extended Toolkit - Building Release Configuration
echo ========================================================================
echo.

REM Try to find MSBuild
set MSBUILD=

REM Check Visual Studio 2022 Enterprise
if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

REM Check Visual Studio 2022 Professional
if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

REM Check Visual Studio 2022 Community
if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" (
    set MSBUILD=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe
    goto :found
)

REM Try to use MSBuild from PATH
where msbuild.exe >nul 2>&1
if %ERRORLEVEL% == 0 (
    set MSBUILD=msbuild.exe
    goto :found
)

REM MSBuild not found
echo ERROR: MSBuild.exe not found!
echo.
echo Please install Visual Studio 2022 or ensure MSBuild is in your PATH.
echo.
pause
exit /b 1

:found
echo Using MSBuild: %MSBUILD%
echo.

REM Build the project
"%MSBUILD%" Build.proj /t:CI /p:Configuration=Release /v:minimal

REM Check result
if %ERRORLEVEL% == 0 (
    echo.
    echo ========================================================================
    echo   Build Completed Successfully!
    echo ========================================================================
    echo.
    echo Output locations:
    echo   - Binaries: Bin\Release\
    echo   - Packages: Bin\NuGet Packages\Release\
    echo.
) else (
    echo.
    echo ========================================================================
    echo   Build Failed!
    echo ========================================================================
    echo.
    echo Check the output above for errors.
    echo.
)

pause

