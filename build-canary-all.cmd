@echo off
REM Build both Canary and CanaryLite packages

echo ================================================================================
echo Building Canary Packages (Full + Lite)
echo ================================================================================
echo.

set SOLUTION="Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"

echo Building Canary (Full - 6 TFMs including net472)...
dotnet pack %SOLUTION% -c Canary
if errorlevel 1 (
    echo ERROR: Canary build failed
    exit /b 1
)

echo.
echo Building CanaryLite (Lite - 5 TFMs excluding net472)...
dotnet pack %SOLUTION% -c CanaryLite
if errorlevel 1 (
    echo ERROR: CanaryLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Success! Both Canary package types created:
echo ================================================================================
echo   Full packages:  Bin\NuGet Packages\Canary\*.Canary.nupkg
echo   Lite packages:  Bin\NuGet Packages\Canary\*.Lite.Canary.nupkg
echo.
echo Total: ~122 packages (61 projects x 2 variants)
echo ================================================================================

pause

