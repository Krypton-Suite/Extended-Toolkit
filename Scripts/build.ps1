# PowerShell build script for Krypton Extended Toolkit
# Similar to the Standard Toolkit build system

param(
    [Parameter(Position=0)]
    [ValidateSet("Debug", "Release", "Canary", "Nightly")]
    [string]$Configuration = "Release",
    
    [Parameter(Position=1)]
    [string]$Platform = "AnyCPU",
    
    [Parameter(Position=2)]
    [string]$TargetFramework = "net8.0-windows",
    
    [switch]$Clean,
    [switch]$Restore,
    [switch]$Build,
    [switch]$Pack,
    [switch]$Test,
    [switch]$UpdatePackages,
    [switch]$CheckUpdates,
    [switch]$UpdateAll,
    [switch]$UpdateMajor
)

# Set error action preference
$ErrorActionPreference = "Stop"

# Function to write colored output
function Write-ColorOutput {
    param(
        [string]$Message,
        [string]$Color = "White"
    )
    Write-Host $Message -ForegroundColor $Color
}

# Function to find MSBuild
function Find-MSBuild {
    # Try to find MSBuild in PATH first
    try {
        $msbuild = Get-Command msbuild -ErrorAction Stop
        return $msbuild.Source
    }
    catch {
        Write-ColorOutput "MSBuild not found in PATH. Searching for Visual Studio installation..." "Yellow"
    }
    
    # Common Visual Studio 2022 locations
    $vs2022Paths = @(
        "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files\Microsoft Visual Studio\2022\Professional\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
    )
    
    # Common Visual Studio 2019 locations
    $vs2019Paths = @(
        "C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\MSBuild\Current\Bin\MSBuild.exe",
        "C:\Program Files (x86)\Microsoft Visual Studio\2019\Enterprise\MSBuild\Current\Bin\MSBuild.exe"
    )
    
    # Check VS 2022 first
    foreach ($path in $vs2022Paths) {
        if (Test-Path $path) {
            Write-ColorOutput "Found MSBuild at: $path" "Green"
            return $path
        }
    }
    
    # Check VS 2019
    foreach ($path in $vs2019Paths) {
        if (Test-Path $path) {
            Write-ColorOutput "Found MSBuild at: $path" "Green"
            return $path
        }
    }
    
    throw "MSBuild not found. Please install Visual Studio or .NET SDK."
}

# Function to find NuGet CLI
function Find-NuGet {
    # Try to find nuget.exe in PATH first
    try {
        $nuget = Get-Command nuget -ErrorAction Stop
        return $nuget.Source
    }
    catch {
        Write-ColorOutput "NuGet CLI not found in PATH. Searching for common locations..." "Yellow"
    }
    
    # Common NuGet CLI locations
    $nugetPaths = @(
        "nuget.exe",
        "C:\Tools\NuGet\nuget.exe",
        "C:\Program Files\NuGet\nuget.exe",
        "C:\Program Files (x86)\NuGet\nuget.exe"
    )
    
    foreach ($path in $nugetPaths) {
        if (Get-Command $path -ErrorAction SilentlyContinue) {
            Write-ColorOutput "Found NuGet CLI at: $path" "Green"
            return $path
        }
    }
    
    # Try to download NuGet CLI if not found
    Write-ColorOutput "NuGet CLI not found. Attempting to download..." "Yellow"
    try {
        $nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
        $nugetPath = "nuget.exe"
        
        Write-ColorOutput "Downloading NuGet CLI from: $nugetUrl" "Cyan"
        Invoke-WebRequest -Uri $nugetUrl -OutFile $nugetPath
        
        if (Test-Path $nugetPath) {
            Write-ColorOutput "NuGet CLI downloaded successfully" "Green"
            return $nugetPath
        }
    }
    catch {
        Write-ColorOutput "Failed to download NuGet CLI. Please install it manually." "Red"
    }
    
    throw "NuGet CLI not found. Please install NuGet CLI or ensure it's in PATH."
}

# Function to determine solution file
function Get-SolutionFile {
    param([string]$Config)
    
    switch ($Config) {
        { $_ -in @("Canary", "Nightly") } {
            return "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln"
        }
        default {
            return "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"
        }
    }
}

# Function to clean build artifacts
function Invoke-Clean {
    Write-ColorOutput "Cleaning build artifacts..." "Cyan"
    
    if (Test-Path "..\clean.cmd") {
        & cmd /c ..\clean.cmd
    } else {
        # Manual cleanup if clean.cmd doesn't exist
        $pathsToClean = @(
            "Bin",
            "Source\Krypton Toolkit\**\obj",
            "Source\Krypton Toolkit\**\bin"
        )
        
        foreach ($path in $pathsToClean) {
            if (Test-Path $path) {
                Get-ChildItem $path -Recurse | Remove-Item -Recurse -Force -ErrorAction SilentlyContinue
                Write-ColorOutput "Cleaned: $path" "Gray"
            }
        }
    }
}

# Function to restore NuGet packages
function Invoke-Restore {
    param([string]$MSBuildPath, [string]$SolutionFile, [string]$Config, [string]$Platform, [string]$Framework)
    
    Write-ColorOutput "Restoring NuGet packages..." "Cyan"
    
    $restoreArgs = @(
        $SolutionFile,
        "/t:Restore",
        "/p:Configuration=$Config",
        "/p:Platform=`"Any CPU`"",
        "/p:TargetFramework=$Framework",
        "/verbosity:minimal"
    )
    
    if ($Verbose) {
        $restoreArgs += "/verbosity:detailed"
    }
    
    & $MSBuildPath $restoreArgs
    
    if ($LASTEXITCODE -ne 0) {
        throw "NuGet restore failed with exit code: $LASTEXITCODE"
    }
}

# Function to check for package updates
function Invoke-CheckUpdates {
    param([string]$NuGetPath, [string]$SolutionFile)
    
    Write-ColorOutput "Checking for package updates..." "Cyan"
    
    try {
        # Get all project files from solution
        $solutionDir = Split-Path $SolutionFile -Parent
        $projectFiles = Get-ChildItem -Path $solutionDir -Recurse -Filter "*.csproj"
        
        $updateablePackages = @()
        
        foreach ($projectFile in $projectFiles) {
            Write-ColorOutput "Checking project: $($projectFile.Name)" "Gray"
            
            # Check for outdated packages in this project
            $checkArgs = @(
                "outdated",
                $projectFile.FullName,
                "-Format", "table"
            )
            
            $output = & $NuGetPath $checkArgs 2>$null
            
            if ($output -and $output.Length -gt 0) {
                # Parse output to find outdated packages
                foreach ($line in $output) {
                    if ($line -match "^\s*(\S+)\s+(\S+)\s+(\S+)\s+(\S+)") {
                        $packageName = $matches[1]
                        $currentVersion = $matches[2]
                        $latestVersion = $matches[3]
                        $projectName = $projectFile.BaseName
                        
                        $updateablePackages += [PSCustomObject]@{
                            Project = $projectName
                            Package = $packageName
                            Current = $currentVersion
                            Latest = $latestVersion
                        }
                    }
                }
            }
        }
        
        if ($updateablePackages.Count -gt 0) {
            Write-ColorOutput "`nFound $($updateablePackages.Count) packages that can be updated:" "Yellow"
            $updateablePackages | Format-Table -AutoSize
            
            Write-ColorOutput "`nTo update packages, use: .\build.ps1 -UpdatePackages" "Cyan"
            Write-ColorOutput "To update all packages: .\build.ps1 -UpdateAll" "Cyan"
        } else {
            Write-ColorOutput "All packages are up to date!" "Green"
        }
        
        return $updateablePackages
    }
    catch {
        Write-ColorOutput "Failed to check for updates: $($_.Exception.Message)" "Red"
        return @()
    }
}

# Function to update NuGet packages
function Invoke-UpdatePackages {
    param([string]$NuGetPath, [string]$SolutionFile, [switch]$UpdateAll, [switch]$UpdateMajor)
    
    Write-ColorOutput "Updating NuGet packages..." "Cyan"
    
    try {
        # Get all project files from solution
        $solutionDir = Split-Path $SolutionFile -Parent
        $projectFiles = Get-ChildItem -Path $solutionDir -Recurse -Filter "*.csproj"
        
        $updatedCount = 0
        
        foreach ($projectFile in $projectFiles) {
            Write-ColorOutput "Updating packages in project: $($projectFile.Name)" "Gray"
            
            # Update packages in this project
            $updateArgs = @(
                "update",
                $projectFile.FullName
            )
            
            if ($UpdateAll) {
                $updateArgs += "-Safe"
            }
            
            if ($UpdateMajor) {
                $updateArgs += "-Safe"
                Write-ColorOutput "  Updating to latest compatible versions (including major versions)" "Yellow"
            } else {
                Write-ColorOutput "  Updating to latest compatible versions (excluding major versions)" "Yellow"
            }
            
            $output = & $NuGetPath $updateArgs 2>$null
            
            if ($LASTEXITCODE -eq 0) {
                Write-ColorOutput "  Packages updated successfully" "Green"
                $updatedCount++
            } else {
                Write-ColorOutput "  Failed to update packages" "Red"
            }
        }
        
        Write-ColorOutput "`nUpdated packages in $updatedCount projects" "Green"
        
        # Restore packages after updates
        Write-ColorOutput "Restoring packages after updates..." "Cyan"
        $msbuildPath = Find-MSBuild
        Invoke-Restore -MSBuildPath $msbuildPath -SolutionFile $SolutionFile -Config $Configuration -Platform $Platform -Framework $TargetFramework
        
    }
    catch {
        Write-ColorOutput "Failed to update packages: $($_.Exception.Message)" "Red"
    }
}

# Function to build solution
function Invoke-Build {
    param([string]$MSBuildPath, [string]$SolutionFile, [string]$Config, [string]$Platform, [string]$Framework)
    
    Write-ColorOutput "Building solution..." "Cyan"
    
    $buildArgs = @(
        $SolutionFile,
        "/t:Build",
        "/p:Configuration=$Config",
        "/p:Platform=`"Any CPU`"",
        "/p:TargetFramework=$Framework",
        "/p:BuildProjectReferences=true",
        "/m",
        "/verbosity:minimal"
    )
    
    if ($Verbose) {
        $buildArgs += "/verbosity:detailed"
    }
    
    & $MSBuildPath $buildArgs
    
    if ($LASTEXITCODE -ne 0) {
        throw "Build failed with exit code: $LASTEXITCODE"
    }
}

# Function to pack NuGet packages
function Invoke-Pack {
    param([string]$MSBuildPath, [string]$SolutionFile, [string]$Config, [string]$Platform, [string]$Framework)
    
    if ($Config -in @("Canary", "Nightly", "Release")) {
        Write-ColorOutput "Building NuGet packages..." "Cyan"
        
        $packArgs = @(
            $SolutionFile,
            "/t:Pack",
            "/p:Configuration=$Config",
            "/p:Platform=`"Any CPU`"",
            "/p:TargetFramework=$Framework",
            "/p:NoBuild=false",
            "/p:IncludeSymbols=false",
            "/verbosity:minimal"
        )
        
        if ($Verbose) {
            $packArgs += "/verbosity:detailed"
        }
        
        & $MSBuildPath $packArgs
        
        if ($LASTEXITCODE -ne 0) {
            throw "NuGet pack failed with exit code: $LASTEXITCODE"
        }
    } else {
        Write-ColorOutput "Skipping NuGet pack for Debug configuration" "Yellow"
    }
}

# Main execution
try {
    Write-ColorOutput "========================================" "Magenta"
    Write-ColorOutput "Building Krypton Extended Toolkit" "Magenta"
    Write-ColorOutput "========================================" "Magenta"
    Write-ColorOutput "Configuration: $Configuration" "White"
    Write-ColorOutput "Platform: $Platform" "White"
    Write-ColorOutput "Target Framework: $TargetFramework" "White"
    Write-ColorOutput "Solution: $(Get-SolutionFile $Configuration)" "White"
    Write-ColorOutput "========================================" "Magenta"
    
    # Handle package update operations first
    if ($CheckUpdates -or $UpdatePackages -or $UpdateAll -or $UpdateMajor) {
        $nugetPath = Find-NuGet
        $solutionFile = Get-SolutionFile $Configuration
        
        if ($CheckUpdates) {
            Invoke-CheckUpdates -NuGetPath $nugetPath -SolutionFile $solutionFile
            return
        }
        
        if ($UpdatePackages -or $UpdateAll -or $UpdateMajor) {
            Invoke-UpdatePackages -NuGetPath $nugetPath -SolutionFile $solutionFile -UpdateAll:$UpdateAll -UpdateMajor:$UpdateMajor
            return
        }
    }
    
    # Find MSBuild
    $msbuildPath = Find-MSBuild
    Write-ColorOutput "Using MSBuild: $msbuildPath" "Green"
    
    # Get solution file
    $solutionFile = Get-SolutionFile $Configuration
    
    # Execute build steps based on parameters
    if ($Clean -or (-not $Restore -and -not $Build -and -not $Pack -and -not $Test)) {
        Invoke-Clean
    }
    
    if ($Restore -or (-not $Build -and -not $Pack -and -not $Test)) {
        Invoke-Restore -MSBuildPath $msbuildPath -SolutionFile $solutionFile -Config $Configuration -Platform $Platform -Framework $TargetFramework
    }
    
    if ($Build -or (-not $Pack -and -not $Test)) {
        Invoke-Build -MSBuildPath $msbuildPath -SolutionFile $solutionFile -Config $Configuration -Platform $Platform -Framework $TargetFramework
    }
    
    if ($Pack -or (-not $Test)) {
        Invoke-Pack -MSBuildPath $msbuildPath -SolutionFile $solutionFile -Config $Configuration -Platform $Platform -Framework $TargetFramework
    }
    
    # Display results
    Write-ColorOutput "" "White"
    Write-ColorOutput "========================================" "Green"
    Write-ColorOutput "Build completed successfully!" "Green"
    Write-ColorOutput "========================================" "Green"
    Write-ColorOutput "Output location: Bin\$Configuration\$TargetFramework" "White"
    
    if ($Configuration -in @("Canary", "Nightly", "Release")) {
        Write-ColorOutput "NuGet packages: Bin\NuGet Packages\$Configuration" "White"
    }
    
    Write-ColorOutput "========================================" "Green"
    
} catch {
    Write-ColorOutput "Build failed: $($_.Exception.Message)" "Red"
    exit 1
}
