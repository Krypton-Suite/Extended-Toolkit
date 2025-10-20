# Quick Start - Building Krypton Extended Toolkit

This guide gets you building the toolkit in under 5 minutes!

## 🚀 Fastest Way to Build

```bash
# Build everything (Release)
msbuild Build.proj /t:CI
```

That's it! This command will:
- ✅ Restore NuGet packages
- ✅ Build all solutions
- ✅ Build Ultimate packages
- ✅ Create all NuGet packages

## 🌿 Release Channels

Choose your release channel:

```bash
# Release (for master branch) - Stable
msbuild Build.proj /t:CI /p:Configuration=Release

# Canary (for canary branch) - Beta (-beta suffix)
msbuild Build.proj /t:CI /p:Configuration=Canary

# Nightly (for alpha branch) - Alpha (-alpha suffix)
msbuild Build.proj /t:CI /p:Configuration=Nightly
```

## 📋 Common Tasks

### Just Build (No Packaging)

```bash
msbuild Build.proj /p:Configuration=Release
```

### Build All Channels

```bash
msbuild Build.proj /t:CIAll
```

### Clean and Rebuild

```bash
msbuild Build.proj /t:Rebuild /p:Configuration=Release
```

### Create Packages Only

```bash
msbuild Build.proj /t:Pack /p:Configuration=Release
```

### See What You Built

```bash
msbuild Build.proj /t:ListPackages /p:Configuration=Release
```

## 📍 Output Locations

After building, find your files here:

```
Bin/
├── Release/              # Compiled assemblies (Release)
├── Canary/               # Compiled assemblies (Canary)
├── Nightly/              # Compiled assemblies (Nightly)
└── NuGet Packages/
    ├── Release/          # *.nupkg files (Release)
    ├── Canary/           # *.nupkg files (Canary -beta)
    └── Nightly/          # *.nupkg files (Nightly -alpha)
```

## ❓ Need Help?

```bash
# Show all available options
msbuild Build.proj /t:Help
```

## 📚 More Information

- **[BUILD_SYSTEM.md](BUILD_SYSTEM.md)** - Complete build system documentation
- **[WORKFLOW_IMPLEMENTATION.md](WORKFLOW_IMPLEMENTATION.md)** - CI/CD and workflows
- **[README.md](README.md)** - Project overview

## 🎯 Development Workflow

### Daily Development
- Use **Visual Studio** with `.sln` files for coding
- Standard edit-compile-debug cycle

### Before Committing
```bash
# Test your changes with a full build
msbuild Build.proj /t:CI /p:Configuration=Debug
```

### Creating a Release
```bash
# Build all release channels
msbuild Build.proj /t:CIAll

# Or build specific channel
msbuild Build.proj /t:CI /p:Configuration=Release
```

## 🔧 Prerequisites

- **Windows** (required for .NET Framework and WinForms)
- **MSBuild** (included with Visual Studio)
- **.NET SDK** (for dotnet commands)
- **Visual Studio 2022** (recommended)

## ⚡ Pro Tips

1. **Parallel Builds** - Enabled by default for speed
2. **Minimal Output** - Use `/v:minimal` for cleaner logs
3. **Detailed Logs** - Use `/v:detailed` for troubleshooting
4. **Configuration Display** - Run `/t:ShowConfiguration` to verify settings

## 🎁 What Gets Built?

### Individual Library Packages (58+)
All individual components as separate NuGet packages:
- Krypton.Toolkit.Suite.Extended.Core
- Krypton.Toolkit.Suite.Extended.Controls
- Krypton.Toolkit.Suite.Extended.Dialogs
- ... and 55+ more

### Ultimate Packages (All-in-One)
Two mega-packages with everything included:
- **Ultimate** - All frameworks (net472, net48, net481, net8.0, net9.0, net10.0)
- **Ultimate.Lite** - Modern frameworks only (net48, net481, net8.0, net9.0, net10.0)

---

**Ready?** Run this now:
```bash
msbuild Build.proj /t:CI
```

🎉 Happy building!

