#Requires -Version 5.1
<#
.SYNOPSIS
    Add LTS / LTSLite solution configurations to Extended .sln files by cloning Nightly / NightlyLite mappings.
#>
$ErrorActionPreference = 'Stop'
$utf8Bom = New-Object System.Text.UTF8Encoding $true
$slnDir = Join-Path $PSScriptRoot '..\..\Source\Krypton Toolkit' | Resolve-Path
$slns = @(
    'Krypton Toolkit Suite Extended 2022 - VS2022.sln'
    'Krypton Toolkit Suite Extended 2022 - VS2022 - Dev.sln'
    'Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln'
)

foreach ($name in $slns) {
    $path = Join-Path $slnDir $name
    if (-not (Test-Path -LiteralPath $path)) {
        Write-Warning "Missing $path"
        continue
    }

    $content = [System.IO.File]::ReadAllText($path)
    if ($content -match 'LTS\|Any CPU') {
        Write-Host "Already has LTS: $name"
        continue
    }

    # Insert LTS platforms after NightlyLite platforms in SolutionConfigurationPlatforms
    $platformBlock = @'
		NightlyLite|Any CPU = NightlyLite|Any CPU
		NightlyLite|x64 = NightlyLite|x64
		NightlyLite|x86 = NightlyLite|x86
		LTS|Any CPU = LTS|Any CPU
		LTS|x64 = LTS|x64
		LTS|x86 = LTS|x86
		LTSLite|Any CPU = LTSLite|Any CPU
		LTSLite|x64 = LTSLite|x64
		LTSLite|x86 = LTSLite|x86
'@
    $content = $content.Replace(
        "`t`tNightlyLite|Any CPU = NightlyLite|Any CPU`r`n`t`tNightlyLite|x64 = NightlyLite|x64`r`n`t`tNightlyLite|x86 = NightlyLite|x86",
        $platformBlock)

    # For each project GUID block, after NightlyLite lines, insert LTS/LTSLite cloned from Nightly/NightlyLite
    # Match per-project NightlyLite triple (Any CPU, x64, x86) ActiveCfg+Build and append LTS mappings
    $rx = [regex]'(?m)(\{[0-9A-Fa-f\-]+\})\.NightlyLite\|x86\.ActiveCfg = NightlyLite\|Any CPU\r?\n\t\t\1\.NightlyLite\|x86\.Build\.0 = NightlyLite\|Any CPU'

    $content = $rx.Replace($content, {
        param($m)
        $guid = $m.Groups[1].Value
        $extra = @"
$($m.Value)
		$guid.LTS|Any CPU.ActiveCfg = LTS|Any CPU
		$guid.LTS|Any CPU.Build.0 = LTS|Any CPU
		$guid.LTS|x64.ActiveCfg = LTS|Any CPU
		$guid.LTS|x64.Build.0 = LTS|Any CPU
		$guid.LTS|x86.ActiveCfg = LTS|Any CPU
		$guid.LTS|x86.Build.0 = LTS|Any CPU
		$guid.LTSLite|Any CPU.ActiveCfg = LTSLite|Any CPU
		$guid.LTSLite|Any CPU.Build.0 = LTSLite|Any CPU
		$guid.LTSLite|x64.ActiveCfg = LTSLite|Any CPU
		$guid.LTSLite|x64.Build.0 = LTSLite|Any CPU
		$guid.LTSLite|x86.ActiveCfg = LTSLite|Any CPU
		$guid.LTSLite|x86.Build.0 = LTSLite|Any CPU
"@
        return $extra
    })

    # Some projects may only have ActiveCfg without Build.0 for NightlyLite - also handle Debug-mapped projects
    # Fallback: projects that map NightlyLite -> Debug (TestForm pattern)
    $rxDebug = [regex]'(?m)(\{[0-9A-Fa-f\-]+\})\.NightlyLite\|x86\.ActiveCfg = Debug\|Any CPU(?:\r?\n\t\t\1\.NightlyLite\|x86\.Build\.0 = Debug\|Any CPU)?'
    $content = $rxDebug.Replace($content, {
        param($m)
        if ($m.Value -match '\.LTS\|') { return $m.Value }
        $guid = $m.Groups[1].Value
        $hasBuild = $m.Value -match 'Build\.0'
        $extra = $m.Value
        if ($hasBuild) {
            $extra += @"

		$guid.LTS|Any CPU.ActiveCfg = Debug|Any CPU
		$guid.LTS|Any CPU.Build.0 = Debug|Any CPU
		$guid.LTS|x64.ActiveCfg = Debug|Any CPU
		$guid.LTS|x64.Build.0 = Debug|Any CPU
		$guid.LTS|x86.ActiveCfg = Debug|Any CPU
		$guid.LTS|x86.Build.0 = Debug|Any CPU
		$guid.LTSLite|Any CPU.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|Any CPU.Build.0 = Debug|Any CPU
		$guid.LTSLite|x64.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|x64.Build.0 = Debug|Any CPU
		$guid.LTSLite|x86.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|x86.Build.0 = Debug|Any CPU
"@
        }
        else {
            $extra += @"

		$guid.LTS|Any CPU.ActiveCfg = Debug|Any CPU
		$guid.LTS|x64.ActiveCfg = Debug|Any CPU
		$guid.LTS|x86.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|Any CPU.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|x64.ActiveCfg = Debug|Any CPU
		$guid.LTSLite|x86.ActiveCfg = Debug|Any CPU
"@
        }
        return $extra
    })

    [System.IO.File]::WriteAllText($path, $content, $utf8Bom)
    Write-Host "Updated $name (LTS present: $($content -match 'LTS\|Any CPU'))"
}
