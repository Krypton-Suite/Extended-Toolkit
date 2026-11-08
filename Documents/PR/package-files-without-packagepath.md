# Fix NuGet packing for files without PackagePath metadata

## Summary

Prevent NuGet package generation from failing when a packed item, such as ZipExtractor's application icon, does not define `PackagePath` metadata.

## Related issues

None provided.

## Type of change

Bug fix / build.

## Changes

- The shared Windows TFM package-path normalization now rewrites only package files with an existing `PackagePath` value.
- Items without `PackagePath` retain their existing NuGet packing behavior.

## Affected packages & target frameworks

- Shared package-generation targets; relevant to packable projects targeting Windows TFMs.

## Validation

- TestForm demo: Not applicable.
- Manual steps: ZipExtractor pack completed with the package ID explicitly set to bypass existing project metadata problems.
- Build command used: `dotnet build "Source\Krypton Toolkit\ZipExtractor\ZipExtractor.csproj"`; `dotnet pack "Source\Krypton Toolkit\ZipExtractor\ZipExtractor.csproj" -c Nightly --no-restore --no-build -p:PackageId=ZipExtractor`.
- Unit tests (if any): Not applicable.

## Screenshots / GIFs

Not applicable.

## Changelog

Resolved NuGet package generation failures when packed files do not define `PackagePath` metadata.

## Breaking changes & migration

None.

## Developer documentation

Not applicable.
