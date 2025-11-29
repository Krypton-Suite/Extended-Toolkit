@echo off
REM Build script to create both Full and Lite packages for all release channels
REM This builds all package variants in parallel where possible

setlocal enabledelayedexpansion

echo ================================================================================
echo Krypton Extended Toolkit - Build All Package Variants
echo ================================================================================
echo.

set SOLUTION="Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"

echo This will build the following package variants:
echo.
echo FULL PACKAGES (6 TFMs - includes net472):
echo   1. Release
echo   2. Canary (beta)
echo   3. Nightly (alpha)
echo.
echo LITE PACKAGES (5 TFMs - excludes net472):
echo   4. ReleaseLite
echo   5. CanaryLite (beta)
echo   6. NightlyLite (alpha)
echo.
echo Total: 366 packages (61 projects x 6 configurations)
echo.
set /p confirm="Continue? (Y/N): "
if /i not "%confirm%"=="Y" (
    echo Build cancelled.
    exit /b 0
)

echo.
echo ================================================================================
echo Step 1: Clean previous builds
echo ================================================================================
echo.

dotnet clean %SOLUTION%
if errorlevel 1 (
    echo ERROR: Clean failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 2: Restore NuGet packages
echo ================================================================================
echo.

dotnet restore %SOLUTION%
if errorlevel 1 (
    echo ERROR: Restore failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 3: Build and Pack - Release (Full - 6 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c Release --no-restore
if errorlevel 1 (
    echo ERROR: Release build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 4: Build and Pack - ReleaseLite (Lite - 5 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c ReleaseLite --no-restore
if errorlevel 1 (
    echo ERROR: ReleaseLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 5: Build and Pack - Canary (Full - 6 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c Canary --no-restore
if errorlevel 1 (
    echo ERROR: Canary build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 6: Build and Pack - CanaryLite (Lite - 5 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c CanaryLite --no-restore
if errorlevel 1 (
    echo ERROR: CanaryLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 7: Build and Pack - Nightly (Full - 6 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c Nightly --no-restore
if errorlevel 1 (
    echo ERROR: Nightly build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Step 8: Build and Pack - NightlyLite (Lite - 5 TFMs)
echo ================================================================================
echo.

dotnet pack %SOLUTION% -c NightlyLite --no-restore
if errorlevel 1 (
    echo ERROR: NightlyLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Build Complete! Summary:
echo ================================================================================
echo.
echo Package locations:
echo   Release (Full):      Bin\NuGet Packages\Release\
echo   ReleaseLite (Lite):  Bin\NuGet Packages\Release\
echo   Canary (Full):       Bin\NuGet Packages\Canary\
echo   CanaryLite (Lite):   Bin\NuGet Packages\Canary\
echo   Nightly (Full):      Bin\NuGet Packages\Nightly\
echo   NightlyLite (Lite):  Bin\NuGet Packages\Nightly\
echo.
echo Total packages created: ~366 (61 projects x 6 configurations)
echo.
echo Package naming:
echo   Release:      PackageName.nupkg
echo   ReleaseLite:  PackageName.Lite.nupkg
echo   Canary:       PackageName.Canary.nupkg
echo   CanaryLite:   PackageName.Lite.Canary.nupkg
echo   Nightly:      PackageName.Nightly.nupkg
echo   NightlyLite:  PackageName.Lite.Nightly.nupkg
echo.
echo ================================================================================
echo Build and Pack completed successfully!
echo ================================================================================

pause

