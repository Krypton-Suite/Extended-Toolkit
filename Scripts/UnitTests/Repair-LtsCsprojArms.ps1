#Requires -Version 5.1
$ErrorActionPreference = 'Stop'
$utf8Bom = New-Object System.Text.UTF8Encoding $true
$root = Join-Path $PSScriptRoot '..\..\Source\Krypton Toolkit' | Resolve-Path

$files = Get-ChildItem -LiteralPath $root -Recurse -Filter '*.csproj' |
    Where-Object {
        $_.Name -notmatch 'Backup' -and
        $_.FullName -match 'Krypton\.Toolkit\.Suite\.Extended' -and
        $_.FullName -notmatch '\\.*\.Tests\\'
    }

$repaired = 0
foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    $original = $content

    # Remove corrupted scriptblock residue left by a bad -replace MatchEvaluator attempt
    $corruptRx = [regex]'(?ms)\r?\n\s*param\(\$m\)\s*\$id = \$m\.Groups\[1\]\.Value.*?\$iconOut`r`n`t`t`t</PropertyGroup>`r`n`t`t</When>"\s*\r?\n'

    if ($corruptRx.IsMatch($content)) {
        # Derive base package id from Nightly PackageId
        if ($content -match '<PackageId>([^<]+)\.Nightly</PackageId>') {
            $baseId = $Matches[1]
            $hasIcon = $content -match "(?s)<When Condition=`"'\$\(Configuration\)' == 'Nightly' Or '\$\(Configuration\)' == 'NightlyLite'`">.*?<PackageIcon>"
            $iconXml = if ($hasIcon -and $baseId -match 'Ultimate') {
                "`r`n`t`t`t`t<PackageIcon>Krypton Stable.png</PackageIcon>"
            } elseif ($content -match "<PackageId>$([regex]::Escape($baseId))\.Nightly</PackageId>\s*<PackageIcon>") {
                "`r`n`t`t`t`t<PackageIcon>Krypton Stable.png</PackageIcon>"
            } else {
                ''
            }

            # Ultimate / Ultimate.Lite include PackageIcon in PackageId Choose
            if ($file.Name -match 'Ultimate') {
                $iconXml = "`r`n`t`t`t`t<PackageIcon>Krypton Stable.png</PackageIcon>"
            }

            $ltsBlock = @"

		<When Condition="'`$(Configuration)' == 'LTS' Or '`$(Configuration)' == 'LTSLite'">
			<PropertyGroup>
				<PackageId>$baseId.LTS</PackageId>$iconXml
			</PropertyGroup>
		</When>

"@
            $content = $corruptRx.Replace($content, $ltsBlock)
            $repaired++
        }
    }

    # Also handle case where LTS block is missing entirely (corrupt removed Nightly->Release gap without LTS)
    if ($content.Contains('.Nightly</PackageId>') -and -not $content.Contains('.LTS</PackageId>')) {
        $nightlyWhen = "<When Condition=`"'`$(Configuration)' == 'Nightly' Or '`$(Configuration)' == 'NightlyLite'`">"
        $releaseWhen = "<When Condition=`"'`$(Configuration)' == 'Release' Or '`$(Configuration)' == 'ReleaseLite'`">"
        $nightlyIdx = $content.IndexOf($nightlyWhen)
        $releaseIdx = if ($nightlyIdx -ge 0) { $content.IndexOf($releaseWhen, $nightlyIdx) } else { -1 }
        if ($nightlyIdx -ge 0 -and $releaseIdx -gt $nightlyIdx -and $content -match '<PackageId>([^<]+)\.Nightly</PackageId>') {
            $baseId = $Matches[1]
            $iconXml = if ($file.Name -match 'Ultimate') { "`r`n`t`t`t`t<PackageIcon>Krypton Stable.png</PackageIcon>" } else { '' }
            $ltsBlock = @"

		<When Condition="'`$(Configuration)' == 'LTS' Or '`$(Configuration)' == 'LTSLite'">
			<PropertyGroup>
				<PackageId>$baseId.LTS</PackageId>$iconXml
			</PropertyGroup>
		</When>

"@
            $content = $content.Insert($releaseIdx, $ltsBlock)
            $repaired++
        }
    }

    if ($content -ne $original) {
        [System.IO.File]::WriteAllText($file.FullName, $content, $utf8Bom)
        Write-Host "Repaired $($file.Name)"
    }
}

Write-Host "Repaired: $repaired"
