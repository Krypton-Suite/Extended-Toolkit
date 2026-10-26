# Checks out the pinned Standard-Toolkit submodule at the repository root.
# Dev and main solutions ProjectReference that tree. The superproject gitlink is the pin.
# alpha, canary, master, gold, and V105-LTS each store a SHA from the Standard Toolkit branch of the same name.
# This script checks out that SHA. It does not select a branch.
$ErrorActionPreference = 'Stop'

$repoRoot = if ($env:GITHUB_WORKSPACE) {
    $env:GITHUB_WORKSPACE
} else {
    Split-Path (Split-Path $PSScriptRoot -Parent) -Parent
}

Set-Location -LiteralPath $repoRoot

if (-not (Test-Path -LiteralPath (Join-Path $repoRoot '.gitmodules'))) {
    Write-Error 'Missing .gitmodules. Standard-Toolkit must be a submodule of this repository.'
}

Write-Host 'Checking out pinned Standard-Toolkit submodule'
git submodule update --init --depth 1 -- Standard-Toolkit
if ($LASTEXITCODE -ne 0) {
    Write-Error 'Failed to check out the Standard-Toolkit submodule.'
}
