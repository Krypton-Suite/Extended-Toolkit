# Pins a repo-root global.json to the newest installed 11.x, then 10.x, then 9.x SDK.
$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent (Split-Path -Parent $PSScriptRoot)
if ($env:GITHUB_WORKSPACE) {
    $repoRoot = $env:GITHUB_WORKSPACE
}

function Get-ListedSdkVersion([string]$Prefix) {
    $hit = dotnet --list-sdks |
        Where-Object { $_ -like "$Prefix*" } |
        Select-Object -Last 1
    if (-not $hit) { return $null }
    $line = $hit.TrimEnd()
    if ($line -match '^(\S+)\s') { return $Matches[1] }
    return (($line -split '\s+', 2)[0])
}

$sdkVersion = Get-ListedSdkVersion '11.0'
if (-not $sdkVersion) { $sdkVersion = Get-ListedSdkVersion '10.0' }
if (-not $sdkVersion) { $sdkVersion = Get-ListedSdkVersion '9.0' }
if (-not $sdkVersion) {
    Write-Error 'Could not resolve an SDK version for global.json.'
}

Write-Host "Using SDK $sdkVersion"
$json = @"
{
  "sdk": {
    "version": "$sdkVersion",
    "rollForward": "latestFeature"
  }
}
"@
$path = Join-Path $repoRoot 'global.json'
$utf8 = New-Object System.Text.UTF8Encoding $false
[System.IO.File]::WriteAllText($path, $json, $utf8)
Write-Host "Wrote $path"
