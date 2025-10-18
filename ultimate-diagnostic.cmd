@echo off
:: Ultimate Package Diagnostic Tool

title Ultimate Package Diagnostic Tool

cls

echo ========================================================================
echo   Ultimate Package Diagnostic Tool
echo ========================================================================
echo:

:mainmenu

echo 1. Check Ultimate project references
echo 2. Verify package contents
echo 3. Test package creation
echo 4. Show package dependencies
echo 5. Clean and rebuild Ultimate packages
echo 6. Compare package sizes
echo 7. Return to main menu
echo:

set /p choice="Enter your choice (1-7): "

if "%choice%"=="1" goto checkreferences
if "%choice%"=="2" goto verifycontents
if "%choice%"=="3" goto testcreation
if "%choice%"=="4" goto showdependencies
if "%choice%"=="5" goto cleanrebuild
if "%choice%"=="6" goto comparesizes
if "%choice%"=="7" goto exit

echo Invalid choice. Please try again.
pause
cls
goto mainmenu

:: ===================================================================================================

:checkreferences
cls
echo ========================================================================
echo   Checking Ultimate Project References
echo ========================================================================
echo:

echo Checking Ultimate project references...
echo:

echo Project References in Ultimate:
findstr /C:"ProjectReference" "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" | find /C "ProjectReference"

echo:
echo Project References in Ultimate.Lite:
findstr /C:"ProjectReference" "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" | find /C "ProjectReference"

echo:
echo Package References in Ultimate:
findstr /C:"PackageReference" "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" | find /C "PackageReference"

echo:
echo Package References in Ultimate.Lite:
findstr /C:"PackageReference" "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" | find /C "PackageReference"

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:verifycontents
cls
echo ========================================================================
echo   Verify Package Contents
echo ========================================================================
echo:

echo Checking for existing packages...
echo:

if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg" (
    echo ✅ Ultimate Release packages found
    for %%f in ("Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg") do (
        echo   - %%~nxf
    )
) else (
    echo ❌ No Ultimate Release packages found
)

echo:

if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg" (
    echo ✅ Ultimate.Lite Release packages found
    for %%f in ("Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg") do (
        echo   - %%~nxf
    )
) else (
    echo ❌ No Ultimate.Lite Release packages found
)

echo:

if exist "Bin\NuGet Packages\Nightly\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg" (
    echo ✅ Ultimate Nightly packages found
    for %%f in ("Bin\NuGet Packages\Nightly\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg") do (
        echo   - %%~nxf
    )
) else (
    echo ❌ No Ultimate Nightly packages found
)

echo:

if exist "Bin\NuGet Packages\Canary\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg" (
    echo ✅ Ultimate Canary packages found
    for %%f in ("Bin\NuGet Packages\Canary\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg") do (
        echo   - %%~nxf
    )
) else (
    echo ❌ No Ultimate Canary packages found
)

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:testcreation
cls
echo ========================================================================
echo   Test Package Creation
echo ========================================================================
echo:

echo Testing Ultimate package creation...
echo:

echo Step 1: Clean Ultimate projects
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\bin" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\bin"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\obj" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\obj"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\bin" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\bin"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\obj" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\obj"

echo Step 2: Build Ultimate project
dotnet build "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" --configuration Release --verbosity minimal

if %ERRORLEVEL% == 0 (
    echo ✅ Ultimate build successful
) else (
    echo ❌ Ultimate build failed
    pause
    cls
    goto mainmenu
)

echo:
echo Step 3: Pack Ultimate project
dotnet pack "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" --configuration Release --output "Bin\NuGet Packages\Release" --no-build --verbosity minimal

if %ERRORLEVEL% == 0 (
    echo ✅ Ultimate pack successful
) else (
    echo ❌ Ultimate pack failed
)

echo:
echo Step 4: Build Ultimate.Lite project
dotnet build "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" --configuration Release --verbosity minimal

if %ERRORLEVEL% == 0 (
    echo ✅ Ultimate.Lite build successful
) else (
    echo ❌ Ultimate.Lite build failed
    pause
    cls
    goto mainmenu
)

echo:
echo Step 5: Pack Ultimate.Lite project
dotnet pack "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" --configuration Release --output "Bin\NuGet Packages\Release" --no-build --verbosity minimal

if %ERRORLEVEL% == 0 (
    echo ✅ Ultimate.Lite pack successful
) else (
    echo ❌ Ultimate.Lite pack failed
)

echo:
echo Test completed!
echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:showdependencies
cls
echo ========================================================================
echo   Show Package Dependencies
echo ========================================================================
echo:

echo Analyzing Ultimate package dependencies...
echo:

echo Ultimate Package Dependencies:
dotnet list "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" package

echo:
echo Ultimate.Lite Package Dependencies:
dotnet list "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" package

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:cleanrebuild
cls
echo ========================================================================
echo   Clean and Rebuild Ultimate Packages
echo ========================================================================
echo:

echo This will clean and rebuild both Ultimate packages...
echo:

echo Step 1: Clean all Ultimate projects
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\bin" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\bin"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\obj" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\obj"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\bin" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\bin"
if exist "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\obj" rmdir /s /q "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\obj"

echo Step 2: Clean package output directories
if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg" del "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg"
if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg" del "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg"

echo Step 3: Restore packages
dotnet restore "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj"
dotnet restore "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj"

echo Step 4: Build Ultimate
dotnet build "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" --configuration Release

echo Step 5: Build Ultimate.Lite
dotnet build "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" --configuration Release

echo Step 6: Pack Ultimate
dotnet pack "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate\Krypton.Toolkit.Suite.Extended.Ultimate 2022.csproj" --configuration Release --output "Bin\NuGet Packages\Release" --no-build

echo Step 7: Pack Ultimate.Lite
dotnet pack "Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Ultimate.Lite\Krypton.Toolkit.Suite.Extended.Ultimate.Lite 2022.csproj" --configuration Release --output "Bin\NuGet Packages\Release" --no-build

echo:
echo ✅ Clean and rebuild completed!
echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:comparesizes
cls
echo ========================================================================
echo   Compare Package Sizes
echo ========================================================================
echo:

echo Package size comparison:
echo:

if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg" (
    for %%f in ("Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate*.nupkg") do (
        echo Ultimate: %%~nxf
        for %%s in ("%%f") do echo   Size: %%~zs bytes
    )
) else (
    echo ❌ No Ultimate packages found
)

echo:

if exist "Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg" (
    for %%f in ("Bin\NuGet Packages\Release\Krypton.Toolkit.Suite.Extended.Ultimate.Lite*.nupkg") do (
        echo Ultimate.Lite: %%~nxf
        for %%s in ("%%f") do echo   Size: %%~zs bytes
    )
) else (
    echo ❌ No Ultimate.Lite packages found
)

echo:
pause
cls
goto mainmenu

:: ===================================================================================================

:exit
echo:
echo Returning to main build system...
echo:
exit /b 0
