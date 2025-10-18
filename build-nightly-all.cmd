@echo off
REM Build both Nightly and NightlyLite packages

echo ================================================================================
echo Building Nightly Packages (Full + Lite)
echo ================================================================================
echo.

set SOLUTION="Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"

echo Building Nightly (Full - 6 TFMs including net472)...
dotnet pack %SOLUTION% -c Nightly
if errorlevel 1 (
    echo ERROR: Nightly build failed
    exit /b 1
)

echo.
echo Building NightlyLite (Lite - 5 TFMs excluding net472)...
dotnet pack %SOLUTION% -c NightlyLite
if errorlevel 1 (
    echo ERROR: NightlyLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Success! Both Nightly package types created:
echo ================================================================================
echo   Full packages:  Bin\NuGet Packages\Nightly\*.Nightly.nupkg
echo   Lite packages:  Bin\NuGet Packages\Nightly\*.Lite.Nightly.nupkg
echo.
echo Total: ~122 packages (61 projects x 2 variants)
echo ================================================================================

pause

