# Add LTS configuration (#635)

## Summary

Adds Extended Toolkit `LTS` / `LTSLite` / `LTSAll` MSBuild configurations so long-term support NuGet packages can be produced with PackageIds `Krypton.Toolkit.Suite.Extended.*.LTS` and `*.Lite.LTS`, using stable major-120 calendar versioning (no `-alpha`/`-beta` suffix).

## Related issues

Closes #635

## Type of change

Feature / build & packaging

## Changes

- Root and Source `Directory.Build.props` / `.targets`: LTS TFMs, stable versioning, package output path, PackageId transforms
- `Scripts/Build/lts.proj`, `Extended.Orchestration.targets` (`IsLtsBuild`), and `build-lts.cmd` wrappers (VS2022 / Current / root)
- Per-module PackageId and NuGet-mode Standard `ProjectReference` arms for LTS (same Standard dependency approach as Release)
- Solutions (`*.sln`, NuGet `.slnx`) and workflows: `lts.yml`, `build.yml` branch map for `V*-LTS`, `release.yml` dispatch options
- Changelog and `AGENTS.md` configuration list

## Affected packages & target frameworks

- All packable `Krypton.Toolkit.Suite.Extended.*` modules (PackageId channel arms)
- Full LTS TFMs: `net472;net48;net481;net10.0-windows;net11.0-windows`
- LTSLite TFMs: excludes `net472`

## Validation

- TestForm demo: N/A (build/packaging only)
- Manual steps:
  1. `msbuild Scripts/Build/lts.proj /t:ShowConfiguration /p:Configuration=LTS`
  2. `msbuild /m Scripts/Build/lts.proj /t:Pack /p:Configuration=LTS /p:Platform="Any CPU"`
  3. Confirm packages under `Bin/NuGet Packages/LTS/` named `*.LTS.*.nupkg` with stable `120.*` versions
- Build command used: `msbuild /m Scripts/Build/lts.proj /t:Pack /p:Configuration=LTS /p:Platform="Any CPU"`
- Unit tests (if any): N/A

## Screenshots / GIFs

N/A

## Changelog

```markdown
* Implemented [#635](https://github.com/Krypton-Suite/Extended-Toolkit/issues/635), LTS / LTSLite / LTSAll build configurations for long-term support NuGet packages.
  - PackageIds use Extended channel naming: `….LTS` and `….Lite.LTS` (stable `120.yy.MM.dayOfYear` versions)
  - Channel scripts (`Scripts/Build/lts.proj`, `build-lts.cmd`) and GitHub Actions (`lts.yml`, `build.yml` / `release.yml` wiring)
```

## Breaking changes & migration

None. New configurations and package IDs only; existing Nightly/Canary/Release packages unchanged.

## Developer documentation

Local working notes may be added under `Documents/Development/` if needed; not included in the PR.
