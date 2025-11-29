# Build System Files Index

This document provides an index of all build-related files in the Krypton Extended Toolkit.

## 🎯 Main Build File

| File | Description | Usage |
|------|-------------|-------|
| **[Build.proj](Build.proj)** | Master MSBuild project file | `msbuild Build.proj /t:CI` |

The central orchestration file for building the entire toolkit. Supports all three release channels and provides 15+ build targets.

## 📚 Documentation Files

| File | Description | Best For |
|------|-------------|----------|
| **[QUICK_START_BUILD.md](QUICK_START_BUILD.md)** | 5-minute quick start guide | First-time builders, quick reference |
| **[BUILD_SYSTEM.md](BUILD_SYSTEM.md)** | Complete build system documentation | Detailed understanding, customization |
| **[BUILD_PROJ_SUMMARY.md](BUILD_PROJ_SUMMARY.md)** | Overview of Build.proj implementation | Understanding what was created |
| **[BUILD_FILES_INDEX.md](BUILD_FILES_INDEX.md)** | This file - index of all build files | Finding the right documentation |

## 🔧 Configuration Files

| File | Description | Purpose |
|------|-------------|---------|
| **[Directory.Build.props](Directory.Build.props)** | Version and configuration properties | Automatic versioning by date |
| **[Directory.Build.targets](Directory.Build.targets)** | NuGet packaging configuration | Include dependencies in packages |

## 🚀 Convenience Batch Files (Windows)

Double-click these files to build without using the command line:

| File | Configuration | Branch | Package Suffix |
|------|--------------|--------|----------------|
| **[build-release.cmd](build-release.cmd)** | Release | master | _(none)_ |
| **[build-canary.cmd](build-canary.cmd)** | Canary | canary | -beta |
| **[build-nightly.cmd](build-nightly.cmd)** | Nightly | alpha | -alpha |
| **[build-all.cmd](build-all.cmd)** | All three | All | All |

Each batch file:
- ✅ Automatically finds MSBuild (VS 2022 Enterprise/Professional/Community)
- ✅ Runs complete CI pipeline (Build + Pack)
- ✅ Shows clear success/failure messages
- ✅ Displays output locations
- ✅ Pauses at end so you can see results

## 📂 Solution Files

These are the actual Visual Studio solution files built by Build.proj:

| File | Description |
|------|-------------|
| `Source/Krypton Toolkit/Krypton Toolkit Suite Extended 2022 - VS2022.sln` | Main solution |
| `Source/Krypton Toolkit/Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln` | NuGet solution |
| `Source/Krypton Toolkit/Krypton Toolkit Suite Extended 2022 - VS2022 - Dev.sln` | Development solution |

## 🔄 CI/CD Files

| File | Description |
|------|-------------|
| `.github/workflows/build.yml` | Continuous integration workflow |
| `.github/workflows/release.yml` | Release and publishing workflow |

## 📊 Other Related Documentation

| File | Description |
|------|-------------|
| **[WORKFLOW_IMPLEMENTATION.md](WORKFLOW_IMPLEMENTATION.md)** | Complete workflow implementation documentation |
| **[README.md](README.md)** | Main project README (now includes build section) |

## 🎓 Learning Path

### If you're new to the build system:
1. Start with **[QUICK_START_BUILD.md](QUICK_START_BUILD.md)** (5 minutes)
2. Try running `build-release.cmd` (if on Windows)
3. Read **[BUILD_PROJ_SUMMARY.md](BUILD_PROJ_SUMMARY.md)** for an overview

### If you want to understand everything:
1. Read **[BUILD_SYSTEM.md](BUILD_SYSTEM.md)** (complete documentation)
2. Examine **[Build.proj](Build.proj)** to see how it works
3. Review **[WORKFLOW_IMPLEMENTATION.md](WORKFLOW_IMPLEMENTATION.md)** for CI/CD details

### If you want to customize:
1. Read **[BUILD_SYSTEM.md](BUILD_SYSTEM.md)** - Customization section
2. Modify **[Build.proj](Build.proj)** for custom targets
3. Edit **[Directory.Build.targets](Directory.Build.targets)** for packaging changes

## 🔍 Quick Command Reference

```bash
# Show help
msbuild Build.proj /t:Help

# Build Release
msbuild Build.proj /t:CI /p:Configuration=Release

# Build Canary
msbuild Build.proj /t:CI /p:Configuration=Canary

# Build Nightly
msbuild Build.proj /t:CI /p:Configuration=Nightly

# Build all configurations
msbuild Build.proj /t:CIAll

# Show current configuration
msbuild Build.proj /t:ShowConfiguration /p:Configuration=Canary

# List generated packages
msbuild Build.proj /t:ListPackages /p:Configuration=Release
```

## 📁 Output Locations

After building, find your outputs here:

```
Bin/
├── Release/              # Release builds (master)
├── Canary/               # Canary builds (canary)
├── Nightly/              # Nightly builds (alpha)
├── Debug/                # Debug builds
└── NuGet Packages/
    ├── Release/          # Stable packages
    ├── Canary/           # Beta packages (-beta)
    └── Nightly/          # Alpha packages (-alpha)
```

## 🌿 Release Channel Mapping

| Configuration | Branch | Package Suffix | When to Use |
|--------------|--------|----------------|-------------|
| **Release** | `master` | _(none)_ | Stable production releases |
| **Canary** | `canary` | `-beta` | Beta testing, pre-releases |
| **Nightly** | `alpha` | `-alpha` | Daily builds, early testing |
| **Debug** | _any_ | N/A | Local development only |

## 💡 Tips

- **For daily development**: Use Visual Studio with `.sln` files
- **For testing builds**: Use `Build.proj` or batch files
- **For releases**: Use `Build.proj /t:CI` or `build-all.cmd`
- **For CI/CD**: Use GitHub workflows or `Build.proj` directly

## ❓ Need Help?

- Run: `msbuild Build.proj /t:Help`
- Read: [QUICK_START_BUILD.md](QUICK_START_BUILD.md)
- Check: [BUILD_SYSTEM.md](BUILD_SYSTEM.md)

---

**Quick Start**: If you just want to build right now, run:
```bash
msbuild Build.proj /t:CI
```

Or on Windows, double-click: `build-release.cmd`

