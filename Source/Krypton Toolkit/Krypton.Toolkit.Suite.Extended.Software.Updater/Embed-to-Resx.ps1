param (
    [string]$InputFile,    # e.g. .\ZipExtractor.exe
    [string]$ResxFile      # e.g. .\Resources.resx
)

if (-not (Test-Path $InputFile)) {
    Write-Error "Input file not found: $InputFile"
    exit 1
}

# Read file bytes and convert to Base64
$bytes = [System.IO.File]::ReadAllBytes($InputFile)
$base64 = [System.Convert]::ToBase64String($bytes)

# Resource name = filename without extension
$resName = [System.IO.Path]::GetFileNameWithoutExtension($InputFile)

# Construct XML <data> entry
$entry = @"
<data name="$resName" type="System.Byte[], mscorlib">
  <value>$base64</value>
</data>
"@

# Insert into the resx (before </root>)
$resx = Get-Content $ResxFile
if ($resx -match "</root>") {
    $resx = $resx -replace "</root>", "$entry`r`n</root>"
    Set-Content -Path $ResxFile -Value $resx -Encoding UTF8
    Write-Host "Embedded $InputFile into $ResxFile as resource '$resName'."
} else {
    Write-Error "Invalid resx file: $ResxFile"
}
