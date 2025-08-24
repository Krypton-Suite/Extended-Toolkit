# NuGet Package Management Script for Krypton Extended Toolkit
# Provides comprehensive package management capabilities

param(
    [Parameter(Position=0)]
    [ValidateSet("check", "update", "update-all", "update-major", "restore", "list", "sources", "clean")]
    [string]$Action = "check",
    
    [Parameter(Position=1)]
    [string]$Project = "",
    
    [Parameter(Position=2)]
    [string]$Package = "",
    
    [switch]$Force,
    [switch]$Interactive
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

# Function to get solution file
function Get-SolutionFile {
    $solutions = @(
        "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln",
        "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln"
    )
    
    foreach ($solution in $solutions) {
        if (Test-Path $solution) {
            return $solution
        }
    }
    
    throw "No solution file found in expected locations."
}

# Function to get all project files
function Get-ProjectFiles {
    param([string]$SolutionFile)
    
    $solutionDir = Split-Path $SolutionFile -Parent
    $projectFiles = Get-ChildItem -Path $solutionDir -Recurse -Filter "*.csproj"
    
    if ($projectFiles.Count -eq 0) {
        throw "No project files found in solution directory."
    }
    
    return $projectFiles
}

# Function to check for package updates
function Invoke-CheckUpdates {
    param([string]$NuGetPath, [string]$SolutionFile, [string]$SpecificProject = "")
    
    Write-ColorOutput "Checking for package updates..." "Cyan"
    
    try {
        $projectFiles = Get-ProjectFiles -SolutionFile $SolutionFile
        
        if ($SpecificProject) {
            $projectFiles = $projectFiles | Where-Object { $_.BaseName -eq $SpecificProject }
            if ($projectFiles.Count -eq 0) {
                throw "Project '$SpecificProject' not found."
            }
        }
        
        $updateablePackages = @()
        $totalProjects = $projectFiles.Count
        $currentProject = 0
        
        foreach ($projectFile in $projectFiles) {
            $currentProject++
            Write-ColorOutput "[$currentProject/$totalProjects] Checking project: $($projectFile.Name)" "Gray"
            
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
            
            Write-ColorOutput "`nUpdate Options:" "Cyan"
            Write-ColorOutput "  .\manage-packages.ps1 update          - Update packages safely" "White"
            Write-ColorOutput "  .\manage-packages.ps1 update-all      - Update all packages" "White"
            Write-ColorOutput "  .\manage-packages.ps1 update-major    - Update including major versions" "White"
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

# Function to update packages
function Invoke-UpdatePackages {
    param([string]$NuGetPath, [string]$SolutionFile, [string]$SpecificProject = "", [switch]$UpdateAll, [switch]$UpdateMajor)
    
    Write-ColorOutput "Updating NuGet packages..." "Cyan"
    
    try {
        $projectFiles = Get-ProjectFiles -SolutionFile $SolutionFile
        
        if ($SpecificProject) {
            $projectFiles = $projectFiles | Where-Object { $_.BaseName -eq $SpecificProject }
            if ($projectFiles.Count -eq 0) {
                throw "Project '$SpecificProject' not found."
            }
        }
        
        $updatedCount = 0
        $totalProjects = $projectFiles.Count
        $currentProject = 0
        
        foreach ($projectFile in $projectFiles) {
            $currentProject++
            Write-ColorOutput "[$currentProject/$totalProjects] Updating packages in project: $($projectFile.Name)" "Gray"
            
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
        $restoreArgs = @(
            "restore",
            $SolutionFile
        )
        
        & $NuGetPath $restoreArgs
        
        if ($LASTEXITCODE -eq 0) {
            Write-ColorOutput "Packages restored successfully" "Green"
        } else {
            Write-ColorOutput "Failed to restore packages" "Red"
        }
        
    }
    catch {
        Write-ColorOutput "Failed to update packages: $($_.Exception.Message)" "Red"
    }
}

# Function to list installed packages
function Invoke-ListPackages {
    param([string]$NuGetPath, [string]$SolutionFile, [string]$SpecificProject = "")
    
    Write-ColorOutput "Listing installed packages..." "Cyan"
    
    try {
        $projectFiles = Get-ProjectFiles -SolutionFile $SolutionFile
        
        if ($SpecificProject) {
            $projectFiles = $projectFiles | Where-Object { $_.BaseName -eq $SpecificProject }
            if ($projectFiles.Count -eq 0) {
                throw "Project '$SpecificProject' not found."
            }
        }
        
        $allPackages = @()
        
        foreach ($projectFile in $projectFiles) {
            Write-ColorOutput "Project: $($projectFile.Name)" "Yellow"
            
            # List packages in this project
            $listArgs = @(
                "list",
                $projectFile.FullName
            )
            
            $output = & $NuGetPath $listArgs 2>$null
            
            if ($output -and $output.Length -gt 0) {
                foreach ($line in $output) {
                    if ($line -match "^\s*(\S+)\s+(\S+)") {
                        $packageName = $matches[1]
                        $version = $matches[2]
                        
                        $allPackages += [PSCustomObject]@{
                            Project = $projectFile.BaseName
                            Package = $packageName
                            Version = $version
                        }
                        
                        Write-ColorOutput "  $packageName $version" "White"
                    }
                }
            } else {
                Write-ColorOutput "  No packages found" "Gray"
            }
            Write-ColorOutput ""
        }
        
        return $allPackages
    }
    catch {
        Write-ColorOutput "Failed to list packages: $($_.Exception.Message)" "Red"
        return @()
    }
}

# Function to manage package sources
function Invoke-ManageSources {
    param([string]$NuGetPath)
    
    Write-ColorOutput "Managing NuGet package sources..." "Cyan"
    
    try {
        # List current sources
        Write-ColorOutput "Current package sources:" "Yellow"
        $listArgs = @("sources", "list")
        $output = & $NuGetPath $listArgs 2>$null
        
        if ($output) {
            foreach ($line in $output) {
                Write-ColorOutput "  $line" "White"
            }
        }
        
        Write-ColorOutput "`nSource management commands:" "Cyan"
        Write-ColorOutput "  .\manage-packages.ps1 sources add <name> <url>    - Add new source" "White"
        Write-ColorOutput "  .\manage-packages.ps1 sources remove <name>       - Remove source" "White"
        Write-ColorOutput "  .\manage-packages.ps1 sources update <name> <url> - Update source" "White"
        
    }
    catch {
        Write-ColorOutput "Failed to manage sources: $($_.Exception.Message)" "Red"
    }
}

# Function to clean package cache
function Invoke-CleanCache {
    param([string]$NuGetPath)
    
    Write-ColorOutput "Cleaning NuGet package cache..." "Cyan"
    
    try {
        $cleanArgs = @("locals", "all", "-clear")
        $output = & $NuGetPath $cleanArgs 2>$null
        
        if ($LASTEXITCODE -eq 0) {
            Write-ColorOutput "Package cache cleaned successfully" "Green"
        } else {
            Write-ColorOutput "Failed to clean package cache" "Red"
        }
        
    }
    catch {
        Write-ColorOutput "Failed to clean cache: $($_.Exception.Message)" "Red"
    }
}

# Main execution
try {
    Write-ColorOutput "========================================" "Magenta"
    Write-ColorOutput "NuGet Package Management" "Magenta"
    Write-ColorOutput "========================================" "Magenta"
    Write-ColorOutput "Action: $Action" "White"
    if ($Project) { Write-ColorOutput "Project: $Project" "White" }
    if ($Package) { Write-ColorOutput "Package: $Package" "White" }
    Write-ColorOutput "========================================" "Magenta"
    
    # Find NuGet CLI
    $nugetPath = Find-NuGet
    
    # Get solution file
    $solutionFile = Get-SolutionFile
    
    # Execute action based on parameter
    switch ($Action.ToLower()) {
        "check" {
            Invoke-CheckUpdates -NuGetPath $nugetPath -SolutionFile $solutionFile -SpecificProject $Project
        }
        "update" {
            Invoke-UpdatePackages -NuGetPath $nugetPath -SolutionFile $solutionFile -SpecificProject $Project
        }
        "update-all" {
            Invoke-UpdatePackages -NuGetPath $nugetPath -SolutionFile $solutionFile -SpecificProject $Project -UpdateAll
        }
        "update-major" {
            Invoke-UpdatePackages -NuGetPath $nugetPath -SolutionFile $solutionFile -SpecificProject $Project -UpdateMajor
        }
        "restore" {
            Write-ColorOutput "Restoring packages..." "Cyan"
            $restoreArgs = @("restore", $solutionFile)
            & $nugetPath $restoreArgs
        }
        "list" {
            Invoke-ListPackages -NuGetPath $nugetPath -SolutionFile $solutionFile -SpecificProject $Project
        }
        "sources" {
            Invoke-ManageSources -NuGetPath $nugetPath
        }
        "clean" {
            Invoke-CleanCache -NuGetPath $nugetPath
        }
        default {
            Write-ColorOutput "Unknown action: $Action" "Red"
            Write-ColorOutput "Valid actions: check, update, update-all, update-major, restore, list, sources, clean" "Yellow"
        }
    }
    
} catch {
    Write-ColorOutput "Operation failed: $($_.Exception.Message)" "Red"
    exit 1
}
