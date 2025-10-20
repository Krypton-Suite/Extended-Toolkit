# Krypton Extended Toolkit - Build System Documentation

This document describes how to use the MSBuild project file (`Build.proj`) to build the Krypton Extended Toolkit.

## 🎯 Overview

The `Build.proj` file is a master MSBuild project that orchestrates building the entire toolkit across all configurations and release channels. It provides a consistent, scriptable way to build, package, and release the toolkit.

## 🌿 Release Channels

The toolkit supports three release channels, each mapped to a specific branch and package suffix:

| Configuration | Branch | Package Suffix | Purpose |
|--------------|--------|----------------|---------|
| **Release** | `master` | _(none)_ | Stable production releases |
| **Canary** | `canary` | `-beta` | Beta pre-releases for testing |
| **Nightly** | `alpha` | `-alpha` | Alpha builds for early adopters |

Additionally, there's a **Debug** configuration for local development.

## 📋 Available Targets

### Basic Build Targets

- **`Build`** - Builds the main solution with the specified configuration
- **`BuildNuGet`** - Builds the NuGet solution (includes Build)
- **`BuildDev`** - Builds the development solution (includes Build)
- **`BuildUltimate`** - Builds the Ultimate all-in-one packages (includes BuildNuGet)

### Package Creation Targets

- **`Pack`** - Creates NuGet packages for all library projects and Ultimate packages
- **`PackUltimateOnly`** - Creates only the Ultimate and Ultimate.Lite packages

### Maintenance Targets

- **`Clean`** - Removes build artifacts for the specified configuration
- **`Rebuild`** - Performs a clean build (Clean + Build)
- **`Restore`** - Restores NuGet packages for all solutions

### Batch Targets

- **`BuildAll`** - Builds all configurations (Release, Canary, Nightly, Debug)
- **`CIAll`** - Runs complete CI pipeline for all three release channels

### Utility Targets

- **`CI`** - Complete CI pipeline (Clean, Build, BuildNuGet, BuildUltimate, Pack)
- **`ShowConfiguration`** - Displays current build configuration
- **`ListPackages`** - Lists all generated NuGet packages
- **`Help`** - Displays usage information

## 🚀 Usage Examples

### Quick Start

```bash
# Show help
msbuild Build.proj /t:Help

# Build with default configuration (Release)
msbuild Build.proj

# Show current configuration
msbuild Build.proj /t:ShowConfiguration
```

### Building Specific Configurations

```bash
# Build Release (for master branch)
msbuild Build.proj /p:Configuration=Release

# Build Canary (for canary branch)
msbuild Build.proj /p:Configuration=Canary

# Build Nightly (for alpha branch)
msbuild Build.proj /p:Configuration=Nightly

# Build Debug
msbuild Build.proj /p:Configuration=Debug
```

### Building and Packaging

```bash
# Complete CI pipeline for Release
msbuild Build.proj /t:CI /p:Configuration=Release

# Complete CI pipeline for Canary
msbuild Build.proj /t:CI /p:Configuration=Canary

# Complete CI pipeline for Nightly
msbuild Build.proj /t:CI /p:Configuration=Nightly

# Build and pack only Ultimate packages
msbuild Build.proj /t:PackUltimateOnly /p:Configuration=Release
```

### Advanced Scenarios

```bash
# Build all configurations sequentially
msbuild Build.proj /t:BuildAll

# Run CI for all three release channels
msbuild Build.proj /t:CIAll

# Clean and rebuild
msbuild Build.proj /t:Rebuild /p:Configuration=Release

# List generated packages
msbuild Build.proj /t:ListPackages /p:Configuration=Canary

# Build with detailed logging
msbuild Build.proj /t:CI /p:Configuration=Release /v:detailed

# Build without parallel builds
msbuild Build.proj /p:BuildInParallel=false
```

## 📦 Output Locations

Build outputs are organized by configuration:

```
Bin/
├── Release/               # Release builds (master)
│   ├── net481/
│   ├── net8.0-windows/
│   └── ...
├── Canary/                # Canary builds (canary)
├── Nightly/               # Nightly builds (alpha)
├── Debug/                 # Debug builds
└── NuGet Packages/
    ├── Release/           # Stable packages
    ├── Canary/            # Beta packages (-beta suffix)
    └── Nightly/           # Alpha packages (-alpha suffix)
```

## 🔧 Customization

### Properties You Can Override

```bash
# Change platform (default: "Any CPU")
msbuild Build.proj /p:Platform="x64"

# Change build verbosity (quiet, minimal, normal, detailed, diagnostic)
msbuild Build.proj /p:BuildVerbosity=detailed

# Disable parallel builds
msbuild Build.proj /p:BuildInParallel=false

# Continue on error
msbuild Build.proj /p:ContinueOnError=true
```

### Modifying the Build Process

The `Build.proj` file is fully customizable. You can:

1. **Add new library projects** to the `<LibraryProject>` item group
2. **Create custom targets** for specific workflows
3. **Modify build order** using `DependsOnTargets` attributes
4. **Add pre/post-build steps** as custom targets

Example - Add a custom validation target:

```xml
<Target Name="ValidateCode" BeforeTargets="Build">
  <Message Text="Running code validation..." Importance="high" />
  <!-- Add your validation steps here -->
</Target>
```

## 🔄 Integration with CI/CD

### GitHub Actions

The build system integrates seamlessly with GitHub Actions:

```yaml
# .github/workflows/build.yml
- name: Build Release
  run: msbuild Build.proj /t:CI /p:Configuration=Release

- name: Build Canary  
  run: msbuild Build.proj /t:CI /p:Configuration=Canary

- name: Build Nightly
  run: msbuild Build.proj /t:CI /p:Configuration=Nightly
```

### Local Development

For daily development, you can still use Visual Studio with the `.sln` files. The `Build.proj` is primarily for:

- CI/CD pipelines
- Release builds
- Building multiple configurations
- Automated packaging

## 📊 Build Process Flow

### Standard Build (`/t:Build`)

```
ShowConfiguration → Restore → Build (Main Solution)
```

### Complete CI (`/t:CI`)

```
ShowConfiguration
    ↓
Restore
    ↓
Build (Main Solution)
    ↓
BuildNuGet (NuGet Solution)
    ↓
BuildUltimate (Ultimate Packages)
    ↓
Pack (All NuGet Packages)
    ↓
Success Message
```

### Full Release (`/t:CIAll`)

```
CI (Configuration=Release)  → Outputs to Bin/Release
    ↓
CI (Configuration=Canary)   → Outputs to Bin/Canary
    ↓
CI (Configuration=Nightly)  → Outputs to Bin/Nightly
```

## 🎁 Ultimate Packages

The build system automatically builds two "all-in-one" packages:

### Ultimate Package

- **Frameworks**: net472, net48, net481, net8.0-windows, net9.0-windows, net10.0-windows
- **Package Names**:
  - `Krypton.Toolkit.Suite.Extended.Ultimate` (Release)
  - `Krypton.Toolkit.Suite.Extended.Ultimate.Canary` (Beta)
  - `Krypton.Toolkit.Suite.Extended.Ultimate.Nightly` (Alpha)

### Ultimate Lite Package

- **Frameworks**: net48, net481, net8.0-windows, net9.0-windows, net10.0-windows _(excludes net472)_
- **Package Names**:
  - `Krypton.Toolkit.Suite.Extended.Ultimate.Lite` (Release)
  - `Krypton.Toolkit.Suite.Extended.Ultimate.Lite.Canary` (Beta)
  - `Krypton.Toolkit.Suite.Extended.Ultimate.Lite.Nightly` (Alpha)

Both packages include all 58+ Extended Toolkit libraries and their dependencies.

## 🐛 Troubleshooting

### Build Fails

```bash
# Try with detailed logging
msbuild Build.proj /t:CI /p:Configuration=Release /v:detailed

# Clean and rebuild
msbuild Build.proj /t:Clean /p:Configuration=Release
msbuild Build.proj /t:Build /p:Configuration=Release
```

### Restore Issues

```bash
# Manually restore packages
msbuild Build.proj /t:Restore

# Or use dotnet CLI
dotnet restore "Source/Krypton Toolkit/Krypton Toolkit Suite Extended 2022 - VS2022.sln"
```

### Packaging Issues

```bash
# Ensure projects are built first
msbuild Build.proj /t:Build /p:Configuration=Release

# Then pack
msbuild Build.proj /t:Pack /p:Configuration=Release
```

### Package Not Found

```bash
# List all generated packages
msbuild Build.proj /t:ListPackages /p:Configuration=Release
```

## 📝 Best Practices

### For Development

- Use Visual Studio with `.sln` files for day-to-day coding
- Use `Build.proj` for testing full builds locally
- Run `Build.proj /t:CI` before submitting pull requests

### For Releases

- Always use `Build.proj /t:CI` for release builds
- Verify configuration with `/t:ShowConfiguration`
- Check packages with `/t:ListPackages`
- Test packages before publishing

### For CI/CD

- Use `/t:CI` for single-configuration builds
- Use `/t:CIAll` to build all release channels at once
- Set appropriate verbosity (`/v:minimal` for cleaner logs)
- Archive artifacts from `Bin/NuGet Packages/`

## 🔗 Related Files

- **`Build.proj`** - Master build project (this system)
- **`Directory.Build.props`** - Version and configuration properties
- **`Directory.Build.targets`** - NuGet packaging configuration
- **`.github/workflows/build.yml`** - CI workflow
- **`.github/workflows/release.yml`** - Release workflow
- **`WORKFLOW_IMPLEMENTATION.md`** - Workflow documentation

## 📚 Additional Resources

- [MSBuild Reference](https://docs.microsoft.com/en-us/visualstudio/msbuild/)
- [.NET CLI Pack](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-pack)
- [NuGet Package Versioning](https://docs.microsoft.com/en-us/nuget/concepts/package-versioning)

---

**Need Help?** Run `msbuild Build.proj /t:Help` to see all available options!

