@echo off
REM Build both Release and ReleaseLite packages

echo ================================================================================
echo Building Release Packages (Full + Lite)
echo ================================================================================
echo.

set SOLUTION="Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"

echo Building Release (Full - 6 TFMs including net472)...
dotnet pack %SOLUTION% -c Release
if errorlevel 1 (
    echo ERROR: Release build failed
    exit /b 1
)

echo.
echo Building ReleaseLite (Lite - 5 TFMs excluding net472)...
dotnet pack %SOLUTION% -c ReleaseLite  
if errorlevel 1 (
    echo ERROR: ReleaseLite build failed
    exit /b 1
)

echo.
echo ================================================================================
echo Success! Both Release package types created:
echo ================================================================================
echo   Full packages:  Bin\NuGet Packages\Release\*.nupkg
echo   Lite packages:  Bin\NuGet Packages\Release\*.Lite.nupkg
echo.
echo Total: ~122 packages (61 projects x 2 variants)
echo ================================================================================

pause

