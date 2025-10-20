# Krypton Toolkit Suite Extended Ultimate Package

## Overview

The **Ultimate Package** is an all-in-one NuGet package that includes **all** Extended Toolkit assemblies and their dependencies bundled together for maximum convenience.

## What's Included

This package includes **every** Extended Toolkit component:

### Core & Foundation
- Krypton.Toolkit.Suite.Extended.Core
- Krypton.Toolkit.Suite.Extended.Common  
- Krypton.Toolkit.Suite.Extended.Shared

### Utilities & Tools
- Developer Utilities
- Global Utilities
- CheckSum Tools
- General Utilities & Tools

### UI Controls
- All buttons and toggle switches
- ComboBox extensions
- Circular progress bars
- Panels and containers

### Data Visualization
- DataGridView extensions
- AdvancedDataGridView
- TreeGridView
- VirtualTreeColumnView
- Outlook Grid
- Gages and visualizations

### Dialogs & Notifications
- Extended dialogs
- Specialized dialogs
- Task dialogs
- Input boxes
- Message boxes
- Toast notifications
- General notifications

### Navigation & Layout
- Navigator extensions
- Navi Suite
- Wizard controls
- Ribbon extensions
- Floating toolbars
- Tool strip items
- Dock extender

### Themes & Appearance
- Theme support
- Theme switcher
- Palette selectors

### File Operations
- File I/O utilities
- File explorer
- File copier
- Compression utilities

### Additional Features
- Networking components
- Software updater
- Error reporting
- Debugging tools
- PDF support
- Scintilla.NET integration
- And much more!

## Supported Frameworks

- .NET Framework 4.7.2
- .NET Framework 4.8
- .NET Framework 4.8.1
- .NET 8 (Windows)
- .NET 9 (Windows)
- .NET 10 (Windows)

## Installation

### From NuGet

**Stable Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate
```

**Canary (Beta) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Canary
```

**Nightly (Alpha) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Ultimate.Nightly
```

### Using .NET CLI

```bash
dotnet add package Krypton.Toolkit.Suite.Extended.Ultimate
```

## Usage

Once installed, all Extended Toolkit components are immediately available in your project. Simply add the necessary using directives:

```csharp
using Krypton.Toolkit.Suite.Extended.Core;
using Krypton.Toolkit.Suite.Extended.Common;
// Add other namespaces as needed
```

## Benefits of the Ultimate Package

### ✅ Convenience
- Single package installation
- No need to manage individual component packages
- All components guaranteed to be compatible versions

### ✅ Complete Feature Set
- Access to **every** Extended Toolkit feature
- No missing dependencies
- All referenced assemblies included

### ✅ Simplified Updates
- Update all components with a single package update
- No version conflicts between components

### ✅ Performance
- All assemblies target specific framework versions
- Optimized for each supported platform

## When to Use This Package

**Use the Ultimate Package when:**
- You need multiple Extended Toolkit components
- You want the complete toolkit without managing dependencies
- You're building a comprehensive application
- You want simplified package management

**Consider Individual Packages when:**
- You only need 1-2 specific components
- You want to minimize your application's footprint
- You have strict package size requirements

## Package Size

The Ultimate package is larger than individual component packages because it includes all Extended Toolkit assemblies. However, unused code will still be trimmed by the linker in Release builds if you use .NET 6+ with trimming enabled.

## Dependencies

This package automatically includes:
- Krypton.Toolkit (Standard Toolkit)
- Krypton.Ribbon
- Krypton.Navigator
- Krypton.Docking
- All required third-party dependencies

Version matching is automatic based on your build configuration (Release/Canary/Nightly).

## Build Configurations

The package is available in three build configurations:

| Configuration | Suffix | Description |
|--------------|---------|-------------|
| **Release** | *(none)* | Stable production release |
| **Canary** | `-beta` | Beta preview with latest features |
| **Nightly** | `-alpha` | Daily builds with cutting-edge features |

## Support

- **Documentation**: [Extended Toolkit Docs](https://github.com/Krypton-Suite/Extended-Toolkit)
- **Issues**: [GitHub Issues](https://github.com/Krypton-Suite/Extended-Toolkit/issues)
- **Discussions**: [GitHub Discussions](https://github.com/Krypton-Suite/Extended-Toolkit/discussions)

## License

BSD 3-Clause License

Copyright © 2017-2025, Krypton Suite

See LICENSE file for details.

## Version Information

To get version information programmatically:

```csharp
using Krypton.Toolkit.Suite.Extended.Ultimate;

string version = UltimatePackageInfo.AssemblyVersion;
string[] frameworks = UltimatePackageInfo.SupportedFrameworks;
string[] components = UltimatePackageInfo.IncludedComponents;
```

## Changelog

See the main [CHANGELOG.md](https://github.com/Krypton-Suite/Extended-Toolkit/blob/master/Documents/Help/Changelog.md) for all changes across Extended Toolkit components.

