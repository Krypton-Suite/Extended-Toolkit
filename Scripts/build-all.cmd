@echo off
REM ========================================================================
REM Krypton Extended Toolkit - Build All Configurations
REM 
REM This script builds all three release channels:
REM - Release (master)
REM - Canary (canary - beta)  
REM - Nightly (alpha - alpha)
REM ========================================================================

echo.
echo ========================================================================
echo   Krypton Extended Toolkit - Building All Configurations
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

REM Build all configurations
"%MSBUILD%" Build.proj /t:CIAll /v:minimal

REM Check result
if %ERRORLEVEL% == 0 (
    echo.
    echo ========================================================================
    echo   All Builds Completed Successfully!
    echo ========================================================================
    echo.
    echo Output locations:
    echo   Release:
    echo     - Binaries: Bin\Release\
    echo     - Packages: Bin\NuGet Packages\Release\
    echo.
    echo   Canary (Beta):
    echo     - Binaries: Bin\Canary\
    echo     - Packages: Bin\NuGet Packages\Canary\
    echo.
    echo   Nightly (Alpha):
    echo     - Binaries: Bin\Nightly\
    echo     - Packages: Bin\NuGet Packages\Nightly\
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

