@echo off
setlocal enabledelayedexpansion

:: Build script for Krypton Extended Toolkit
:: Similar to the Standard Toolkit build system

:: Configuration
set "CONFIGURATION=%1"
if "%CONFIGURATION%"=="" set "CONFIGURATION=Release"
set "PLATFORM=%2"
if "%PLATFORM%"=="" set "PLATFORM=AnyCPU"
set "TARGET_FRAMEWORK=%3"
if "%TARGET_FRAMEWORK%"=="" set "TARGET_FRAMEWORK=net8.0-windows"

:: Validate configuration
if not "%CONFIGURATION%"=="Debug" if not "%CONFIGURATION%"=="Release" if not "%CONFIGURATION%"=="Canary" if not "%CONFIGURATION%"=="Nightly" (
    echo Invalid configuration: %CONFIGURATION%
    echo Valid configurations: Debug, Release, Canary, Nightly
    exit /b 1
)

:: Set solution file based on configuration
if "%CONFIGURATION%"=="Canary" (
    set "SOLUTION_FILE=Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln"
) else if "%CONFIGURATION%"=="Nightly" (
    set "SOLUTION_FILE=Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln"
) else (
    set "SOLUTION_FILE=Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"
)

echo ========================================
echo Building Krypton Extended Toolkit
echo ========================================
echo Configuration: %CONFIGURATION%
echo Platform: %PLATFORM%
echo Target Framework: %TARGET_FRAMEWORK%
echo Solution: %SOLUTION_FILE%
echo ========================================

:: Check if MSBuild is available
where msbuild >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo MSBuild not found in PATH. Trying to find Visual Studio installation...
    
    :: Try to find MSBuild in common Visual Studio locations
    if exist "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe"
    ) else if exist "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe" (
        set "MSBUILD_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
    ) else (
        echo MSBuild not found. Please install Visual Studio or .NET SDK.
        exit /b 1
    )
) else (
    set "MSBUILD_PATH=msbuild"
)

echo Using MSBuild: %MSBUILD_PATH%

:: Clean previous build artifacts
echo.
echo Cleaning previous build artifacts...
call ..\clean.cmd

:: Restore NuGet packages
echo.
echo Restoring NuGet packages...
"%MSBUILD_PATH%" "%SOLUTION_FILE%" /t:Restore /p:Configuration=%CONFIGURATION% /p:Platform="Any CPU" /p:TargetFramework=%TARGET_FRAMEWORK%

if %ERRORLEVEL% neq 0 (
    echo Failed to restore NuGet packages.
    exit /b 1
)

:: Build the solution
echo.
echo Building solution...
"%MSBUILD_PATH%" "%SOLUTION_FILE%" /t:Build /p:Configuration=%CONFIGURATION% /p:Platform="Any CPU" /p:TargetFramework=%TARGET_FRAMEWORK% /p:BuildProjectReferences=true /m

if %ERRORLEVEL% neq 0 (
    echo Build failed.
    exit /b 1
)

:: Build NuGet packages if configured
if "%CONFIGURATION%"=="Canary" if "%CONFIGURATION%"=="Nightly" if "%CONFIGURATION%"=="Release" (
    echo.
    echo Building NuGet packages...
    "%MSBUILD_PATH%" "%SOLUTION_FILE%" /t:Pack /p:Configuration=%CONFIGURATION% /p:Platform="Any CPU" /p:TargetFramework=%TARGET_FRAMEWORK% /p:NoBuild=false /p:IncludeSymbols=false
)

echo.
echo ========================================
echo Build completed successfully!
echo ========================================
echo Output location: Bin\%CONFIGURATION%\%TARGET_FRAMEWORK%
if "%CONFIGURATION%"=="Canary" if "%CONFIGURATION%"=="Nightly" if "%CONFIGURATION%"=="Release" (
    echo NuGet packages: Bin\NuGet Packages\%CONFIGURATION%
)
echo ========================================

endlocal
