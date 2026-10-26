# Krypton Toolkit Suite Extended Toggle Switch Package

## Overview

The **Toggle Switch Package** provides customizable toggle switch controls for Windows Forms applications, extending the Krypton Standard Toolkit with modern toggle switch functionality.

## What's Included

This package includes:

- **KryptonToggleSwitchVersion1** - Original toggle switch control
- **KryptonToggleSwitchVersion2** - Enhanced toggle switch control
- Multiple renderer styles (Metro, Modern, iOS, Android, OSX, Carbon, Fancy, Brushed Metal, Plain and Simple)
- Support for both Krypton-themed and vanilla rendering modes
- Customizable appearance, animations, and behavior

## Supported Frameworks

- .NET Framework 4.6.2
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
Install-Package Krypton.Toolkit.Suite.Extended.Toggle.Switch
```

**Canary (Beta) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Toggle.Switch.Canary
```

**Nightly (Alpha) Release:**
```powershell
Install-Package Krypton.Toolkit.Suite.Extended.Toggle.Switch.Nightly
```

### Using .NET CLI

```bash
dotnet add package Krypton.Toolkit.Suite.Extended.Toggle.Switch
```

## Usage

Once installed, add the necessary using directive:

```csharp
using Krypton.Toolkit.Suite.Extended.Toggle.Switch;
```

### Basic Example

```csharp
// Create a toggle switch control
var toggleSwitch = new KryptonToggleSwitchVersion1
{
    Checked = false,
    Style = ToggleSwitchStyle.Metro,
    UseAnimation = true
};

// Handle checked changed event
toggleSwitch.CheckedChanged += (sender, e) =>
{
    MessageBox.Show($"Toggle switch is now: {toggleSwitch.Checked}");
};

// Add to form
this.Controls.Add(toggleSwitch);
```

## Features

### Multiple Renderer Styles
- Metro
- Modern
- iOS 5
- iPhone
- Android
- OSX
- Carbon
- Fancy
- Brushed Metal
- Plain and Simple

### Customization Options
- Animation support with configurable intervals and steps
- Custom text for on/off states
- Custom images for buttons and sides
- Alignment options
- Color customization
- Threshold percentage for toggle behavior
- Krypton-themed or vanilla rendering modes

## Dependencies

This package requires:
- Krypton.Toolkit (Standard Toolkit)

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

MIT License

Copyright © 2017-2026, Krypton Suite

See LICENSE file for details.

## Version Information

To view all of the extended toolkit package latest version information, please visit: https://github.com/Krypton-Suite/Krypton-Toolkit-Suite-Version-Dashboard/blob/main/Documents/Modules/Extended/Krypton-Toolkit-Suite-Extended-Modules.md
