# Krypton Toolkit Suite Extended Ultimate Lite Package

## Overview

The **Ultimate Lite Package** is a streamlined version of the Ultimate all-in-one NuGet package that includes **all** Extended Toolkit assemblies and their dependencies, targeting modern frameworks only.

## Difference from Ultimate Package

| Package | Target Frameworks |
|---------|-------------------|
| **Ultimate** | net472, net48, net481, net8.0-windows, net9.0-windows, net10.0-windows |
| **Ultimate.Lite** | net48, net481, net8.0-windows, net9.0-windows, net10.0-windows |

**Key Difference:** Ultimate.Lite excludes .NET Framework 4.7.2, resulting in:
- ✅ Smaller package size (~15-20% reduction)
- ✅ Faster download and restore times
- ✅ Same complete functionality for supported frameworks
- ⚠️ Not suitable for .NET Framework 4.7.2 projects

## What's Included

This package includes **every** Extended Toolkit component (same as Ultimate):

### Core & Foundation
- Krypton.Toolkit.Suite.Extended.Core
- Krypton.Toolkit.Suite.Extended.Common  
- Krypton.Toolkit.Suite.Extended.Shared

### All Components
- All 58+ Extended Toolkit library projects
- All UI controls and components
- All utilities and tools
- All dialogs and notifications
- All navigation and layout components
- All data visualization controls
- All themes and appearance tools
- Complete file operations support
- Networking and update components
- Error reporting and debugging tools
- Additional features (PDF, Scintilla.NET, etc.)

See the [Ultimate package documentation](../Krypton.Toolkit.Suite.Extended.Ultimate/README.md) for the complete list.

## Supported Frameworks

- ✅ .NET Framework 4.8
- ✅ .NET Framework 4.8.1
- ✅ .NET 8 (Windows)
- ✅ .NET 9 (Windows)
- ✅ .NET 10 (Windows)

## Installation

### From NuGet

**Stable Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Lite
```

**Canary (Beta) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Lite.Canary
```

**Nightly (Alpha) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Lite.Nightly
```

### Using .NET CLI

```bash
dotnet add package Krypton.Toolkit.Suite.Extended.Ultimate.Lite
```

## When to Use This Package

### ✅ Use Ultimate.Lite When:
- Your project targets .NET Framework 4.8+ or .NET 6+
- You don't need .NET Framework 4.7.2 support
- You want a smaller package size
- You need the complete Extended Toolkit

### ⚠️ Use Full Ultimate When:
- You need .NET Framework 4.7.2 support
- You want maximum framework compatibility

### 📦 Use Individual Packages When:
- You only need 1-2 specific components
- You want to minimize your application's footprint
- You have strict package size requirements

## Package Comparison

| Feature | Individual Packages | Ultimate.Lite | Ultimate |
|---------|-------------------|---------------|----------|
| Components Included | Selected only | All | All |
| Framework Coverage | Varies | Modern only | All |
| Package Size | Small | Medium | Large |
| Setup Complexity | High | Low | Low |
| Update Simplicity | Medium | High | High |
| .NET Framework 4.7.2 | ✓ | ✗ | ✓ |
| .NET Framework 4.8+ | ✓ | ✓ | ✓ |
| .NET 8+ | ✓ | ✓ | ✓ |

## Usage

Once installed, all Extended Toolkit components are immediately available:

```csharp
using Krypton.Toolkit.Suite.Extended.Core;
using Krypton.Toolkit.Suite.Extended.Common;
using Krypton.Toolkit.Suite.Extended.Buttons;
// Add other namespaces as needed
```

## Version Information

Get package information programmatically:

```csharp
using Krypton.Toolkit.Suite.Extended.Ultimate.Lite;

// Get version info
string version = UltimateLitePackageInfo.AssemblyVersion;
string packageName = UltimateLitePackageInfo.PackageName;

// Check supported frameworks
string[] frameworks = UltimateLitePackageInfo.SupportedFrameworks;
bool supportsNet48 = UltimateLitePackageInfo.IsFrameworkSupported("net48");

// Get component list
string[] components = UltimateLitePackageInfo.IncludedComponents;

// Understand the difference
string difference = UltimateLitePackageInfo.DifferenceFromUltimate;
```

## Benefits

### ✅ Smaller Package Size
- Reduced download time
- Faster NuGet restore
- Less disk space usage

### ✅ Complete Feature Set
- All Extended Toolkit components
- No missing functionality
- All dependencies included

### ✅ Modern Framework Focus
- Optimized for current frameworks
- No legacy overhead
- Better performance

### ✅ Simplified Management
- Single package to install
- Single package to update
- No version conflicts

## Dependencies

This package automatically includes:
- Krypton.Toolkit (Standard Toolkit)
- Krypton.Ribbon
- Krypton.Navigator
- Krypton.Docking
- All required third-party dependencies

Version matching is automatic based on your build configuration.

## Build Configurations

| Configuration | Suffix | Description |
|--------------|---------|-------------|
| **Release** | *(none)* | Stable production release |
| **Canary** | `-beta` | Beta preview with latest features |
| **Nightly** | `-alpha` | Daily builds with cutting-edge features |

## Migration from Other Packages

### From Individual Packages
1. Remove individual Extended Toolkit package references
2. Install `Krypton.Toolkit.Suite.Extended.Ultimate.Lite`
3. No code changes needed - all namespaces remain the same

### From Ultimate to Ultimate.Lite
Simply replace the package reference:
```xml
<!-- Before -->
<PackageReference Include="Krypton.Toolkit.Suite.Extended.Ultimate" Version="80.25.10.286" />

<!-- After -->
<PackageReference Include="Krypton.Toolkit.Suite.Extended.Ultimate.Lite" Version="80.25.10.286" />
```

**Important:** Only migrate if you don't need .NET Framework 4.7.2 support!

## Support

- **Documentation**: [Extended Toolkit Docs](https://github.com/Krypton-Suite/Extended-Toolkit)
- **Issues**: [GitHub Issues](https://github.com/Krypton-Suite/Extended-Toolkit/issues)
- **Discussions**: [GitHub Discussions](https://github.com/Krypton-Suite/Extended-Toolkit/discussions)

## License

BSD 3-Clause License

Copyright © 2017-2025, Krypton Suite

See LICENSE file for details.

## Changelog

See the main [CHANGELOG.md](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Documents/Help/Changelog.md) for all changes.

