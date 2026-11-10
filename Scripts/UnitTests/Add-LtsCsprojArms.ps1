#Requires -Version 5.1
<#
.SYNOPSIS
    One-shot helper: insert LTS PackageId and NuGet ProjectReference arms into Extended module csprojs.
#>
$ErrorActionPreference = 'Stop'
$utf8Bom = New-Object System.Text.UTF8Encoding $true
$root = Join-Path $PSScriptRoot '..\..\Source\Krypton Toolkit' | Resolve-Path

$files = Get-ChildItem -LiteralPath $root -Recurse -Filter '*.csproj' |
    Where-Object {
        $_.Name -notmatch 'Backup' -and
        $_.FullName -match 'Krypton\.Toolkit\.Suite\.Extended' -and
        $_.FullName -notmatch '\\.*\.Tests\\'
    }

$pkgCount = 0
$nugetCount = 0
$notes = New-Object System.Collections.Generic.List[string]

foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    $original = $content

    $nightlyWhen = "<When Condition=`"'`$(Configuration)' == 'Nightly' Or '`$(Configuration)' == 'NightlyLite'`">"
    $canaryWhen = "<When Condition=`"'`$(Configuration)' == 'Canary' Or '`$(Configuration)' == 'CanaryLite'`">"
    $releaseWhen = "<When Condition=`"'`$(Configuration)' == 'Release' Or '`$(Configuration)' == 'ReleaseLite'`">"

    # PackageId: insert LTS When between Nightly and Release
    if ($content.Contains('.Nightly</PackageId>') -and -not $content.Contains('.LTS</PackageId>')) {
        $nightlyIdx = $content.IndexOf($nightlyWhen)
        $releaseIdx = if ($nightlyIdx -ge 0) { $content.IndexOf($releaseWhen, $nightlyIdx) } else { -1 }

        if ($nightlyIdx -ge 0 -and $releaseIdx -gt $nightlyIdx) {
            $nightlySection = $content.Substring($nightlyIdx, $releaseIdx - $nightlyIdx)
            if ($nightlySection -match '<PackageId>([^<]+)\.Nightly</PackageId>') {
                $baseId = $Matches[1]
                $iconLine = ''
                if ($nightlySection -match '<PackageIcon>') {
                    $iconLine = "`t`t`t`t<PackageIcon>Krypton Stable.png</PackageIcon>`r`n"
                }

                $sb = New-Object System.Text.StringBuilder
                [void]$sb.AppendLine("`t`t<When Condition=`"'`$(Configuration)' == 'LTS' Or '`$(Configuration)' == 'LTSLite'`">")
                [void]$sb.AppendLine("`t`t`t<PropertyGroup>")
                [void]$sb.AppendLine("`t`t`t`t<PackageId>$baseId.LTS</PackageId>")
                if ($iconLine) { [void]$sb.Append($iconLine) }
                [void]$sb.AppendLine("`t`t`t</PropertyGroup>")
                [void]$sb.AppendLine("`t`t</When>")
                [void]$sb.AppendLine()

                $content = $content.Insert($releaseIdx, $sb.ToString())
                $pkgCount++
            }
            else {
                $notes.Add("No Nightly PackageId capture: $($file.Name)")
            }
        }
        else {
            $notes.Add("Nightly/Release PackageId markers missing: $($file.Name)")
        }
    }

    # NuGet Standard dependency: insert LTS ProjectReference arm before Release When (inside NuGet Choose)
    $needsNuGetLts = $content.Contains('SolutionName.Endswith') -and
        ($content -notmatch "(?s)SolutionName\.Endswith.{0,2500}Configuration\)' == 'LTS'")

    if ($needsNuGetLts) {
        $nugetStart = $content.IndexOf('SolutionName.Endswith')
        $canaryIdx = $content.IndexOf($canaryWhen, $nugetStart)
        $releaseIdx = if ($canaryIdx -ge 0) { $content.IndexOf($releaseWhen, $canaryIdx) } else { -1 }

        if ($canaryIdx -ge 0 -and $releaseIdx -gt $canaryIdx) {
            $releaseSection = $content.Substring($releaseIdx, [Math]::Min(800, $content.Length - $releaseIdx))
            if ($releaseSection -match 'ProjectReference Include="([^"]+)"') {
                $projPath = $Matches[1]
                $sb = New-Object System.Text.StringBuilder
                [void]$sb.AppendLine("<When Condition=`"'`$(Configuration)' == 'LTS' Or '`$(Configuration)' == 'LTSLite'`">")
                [void]$sb.AppendLine("`t`t`t`t`t<!-- LTS uses the pinned Standard-Toolkit ProjectReference until a Standard LTS meta-package exists. -->")
                [void]$sb.AppendLine("`t`t`t`t`t<ItemGroup>")
                [void]$sb.AppendLine("`t`t`t`t`t`t<ProjectReference Include=`"$projPath`" />")
                [void]$sb.AppendLine("`t`t`t`t`t</ItemGroup>")
                [void]$sb.AppendLine("`t`t`t`t</When>")
                [void]$sb.AppendLine()
                [void]$sb.Append("`t`t`t`t")

                $content = $content.Insert($releaseIdx, $sb.ToString())
                $nugetCount++
            }
            else {
                $notes.Add("Release ProjectReference missing under NuGet: $($file.Name)")
            }
        }
        else {
            $notes.Add("NuGet Canary/Release markers missing: $($file.Name)")
        }
    }

    if ($content -ne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $content, $utf8Bom)
        Write-Host "Updated $($file.Name)"
    }
}

Write-Host ""
Write-Host "PackageId LTS arms inserted: $pkgCount"
Write-Host "NuGet LTS arms inserted: $nugetCount"
Write-Host "Notes: $($notes.Count)"
$notes | ForEach-Object { Write-Host "  $_" }
