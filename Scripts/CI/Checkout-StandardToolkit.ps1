# Clones Standard-Toolkit as a sibling of this repo (../Standard-Toolkit).
# Extended Dev/main solutions ProjectReference that tree.
param(
    [string]$Branch,
    [string]$Destination
)

$ErrorActionPreference = 'Stop'

if (-not $Destination) {
    $repoRoot = if ($env:GITHUB_WORKSPACE) { $env:GITHUB_WORKSPACE } else { (Get-Location).Path }
    $Destination = Join-Path (Split-Path -Parent $repoRoot) 'Standard-Toolkit'
}

if (-not $Branch) {
    if ($env:GITHUB_BASE_REF) { $Branch = $env:GITHUB_BASE_REF }
    elseif ($env:GITHUB_REF_NAME) { $Branch = $env:GITHUB_REF_NAME }
    else { $Branch = 'alpha' }
}

switch -Regex ($Branch) {
    '^(alpha|canary|master|main|gold)$' { }
    default { $Branch = 'alpha' }
}

if ($Branch -eq 'main') { $Branch = 'master' }

Write-Host "Cloning Krypton-Suite/Standard-Toolkit (branch $Branch) to $Destination"
if (Test-Path -LiteralPath $Destination) {
    Write-Host "Destination already exists; skipping clone."
    exit 0
}

git clone --depth 1 --branch $Branch https://github.com/Krypton-Suite/Standard-Toolkit.git $Destination
if ($LASTEXITCODE -ne 0) {
    Write-Warning "Branch '$Branch' was not available; falling back to alpha."
    if (Test-Path -LiteralPath $Destination) {
        Remove-Item -LiteralPath $Destination -Recurse -Force -ErrorAction SilentlyContinue
    }
    git clone --depth 1 --branch alpha https://github.com/Krypton-Suite/Standard-Toolkit.git $Destination
    if ($LASTEXITCODE -ne 0) {
        Write-Error "Failed to clone Standard-Toolkit."
    }
}
