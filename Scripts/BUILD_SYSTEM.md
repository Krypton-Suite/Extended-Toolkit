# Krypton Extended Toolkit Build System

This document describes the build system for the Krypton Extended Toolkit, which provides automated building, packaging, and deployment capabilities similar to the [Krypton Standard Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit/tree/alpha).

## Overview

The build system consists of several components that work together to provide a comprehensive build solution:

- **Build Scripts**: Command-line scripts for building the toolkit
- **GitHub Actions**: CI/CD automation for continuous integration
- **Configuration Files**: JSON-based configuration for build settings
- **MSBuild Integration**: Leverages existing MSBuild infrastructure
- **NuGet Package Management**: Comprehensive package update and management capabilities

## Quick Start

### Prerequisites

- Visual Studio 2019/2022 or .NET SDK
- MSBuild (automatically detected)
- PowerShell 5.1+ (for PowerShell scripts)
- NuGet CLI (automatically downloaded if not found)

### Basic Usage

#### Using Command Prompt (build.cmd)

```cmd
# Build Release configuration (default)
build.cmd

# Build specific configuration
build.cmd Release

# Build with specific platform and framework
Scripts\build.cmd Release "Any CPU" net8.0-windows

# Build Canary configuration
build.cmd Canary

# Build Nightly configuration
build.cmd Nightly
```

#### Using PowerShell (build.ps1)

```powershell
# Build Release configuration (default)
.\build.ps1

# Build specific configuration
.\build.ps1 -Configuration Release

# Build with specific parameters
.\Scripts\build.ps1 -Configuration Canary -Platform "Any CPU" -TargetFramework net8.0-windows

# Clean only
.\build.ps1 -Clean

# Restore only
.\build.ps1 -Restore

# Build only (skip clean and restore)
.\build.ps1 -Build

# Pack only (skip clean, restore, and build)
.\build.ps1 -Pack

# Verbose output
.\build.ps1 -Verbose
```

#### NuGet Package Management

```powershell
# Check for package updates
.\build.ps1 -CheckUpdates

# Update packages safely
.\build.ps1 -UpdatePackages

# Update all packages
.\build.ps1 -UpdateAll

# Update including major versions
.\build.ps1 -UpdateMajor
```

#### Dedicated Package Management Script

```powershell
# Check for updates across all projects
.\Scripts\manage-packages.ps1 check

# Update packages in specific project
.\Scripts\manage-packages.ps1 update "Krypton.Toolkit.Suite.Extended.Core"

# Update all packages safely
.\Scripts\manage-packages.ps1 update-all

# Update including major versions
.\manage-packages.ps1 update-major

# List all installed packages
.\manage-packages.ps1 list

# Restore packages
.\manage-packages.ps1 restore

# Manage package sources
.\manage-packages.ps1 sources

# Clean package cache
.\manage-packages.ps1 clean
```

## Build Configurations

The build system supports four main configurations:

### 1. Debug
- **Purpose**: Development and debugging
- **Solution**: `Krypton Toolkit Suite Extended 2022 - VS2022.sln`
- **NuGet Packages**: ❌ Not generated
- **Optimization**: ❌ Disabled
- **Symbols**: ✅ Included

### 2. Release
- **Purpose**: Production releases
- **Solution**: `Krypton Toolkit Suite Extended 2022 - VS2022.sln`
- **NuGet Packages**: ✅ Generated
- **Optimization**: ✅ Enabled
- **Symbols**: ❌ Excluded

### 3. Canary
- **Purpose**: Testing new features
- **Solution**: `Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln`
- **NuGet Packages**: ✅ Generated (with `-beta` suffix)
- **Optimization**: ✅ Enabled
- **Symbols**: ❌ Excluded

### 4. Nightly
- **Purpose**: Continuous integration
- **Solution**: `Krypton Toolkit Suite Extended 2022 - VS2022 - NuGet.sln`
- **NuGet Packages**: ✅ Generated (with `-alpha` suffix)
- **Optimization**: ✅ Enabled
- **Symbols**: ❌ Excluded

## Target Frameworks

The build system supports multiple .NET versions:

| Framework | Description | Supported Configurations |
|-----------|-------------|-------------------------|
| `net48` | .NET Framework 4.8 | Debug, Release |
| `net481` | .NET Framework 4.8.1 | Debug, Release |
| `net8.0-windows` | .NET 8.0 Windows | All configurations |
| `net9.0-windows` | .NET 9.0 Windows | Canary, Nightly only |

## Build Output Structure

```
Bin/
├── Debug/
│   ├── net48/
│   ├── net481/
│   └── net8.0-windows/
├── Release/
│   ├── net48/
│   ├── net481/
│   └── net8.0-windows/
├── Canary/
│   ├── net8.0-windows/
│   └── net9.0-windows/
├── Nightly/
│   ├── net8.0-windows/
│   └── net9.0-windows/
└── NuGet Packages/
    ├── Release/
    ├── Canary/
    └── Nightly/
```

## Versioning System

The build system automatically generates version numbers based on the current date:

- **Major**: Fixed at 100 (configurable in `build-config.json`)
- **Minor**: Current year (e.g., 25 for 2025)
- **Build**: Current month (e.g., 01 for January)
- **Revision**: Day of year (e.g., 001 for January 1st)

### Version Examples

- **Release**: `100.25.01.001`
- **Canary**: `100.25.01.001-beta`
- **Nightly**: `100.25.01.001-alpha`

## NuGet Package Management

### Package Update Strategies

The build system provides multiple approaches to package updates:

#### 1. **Safe Updates** (Default)
- Updates packages to latest compatible versions
- Excludes major version updates that might break compatibility
- Recommended for production environments

#### 2. **All Updates**
- Updates all packages to latest versions
- May include breaking changes
- Use with caution and thorough testing

#### 3. **Major Version Updates**
- Includes major version updates
- Highest risk of breaking changes
- Requires comprehensive testing

### Package Management Commands

#### **Check for Updates**
```powershell
# Check all projects
.\Scripts\manage-packages.ps1 check

# Check specific project
.\Scripts\manage-packages.ps1 check "Krypton.Toolkit.Suite.Extended.Core"
```

#### **Update Packages**
```powershell
# Safe update (recommended)
.\manage-packages.ps1 update

# Update all packages
.\manage-packages.ps1 update-all

# Update including major versions
.\Scripts\manage-packages.ps1 update-major

# Update specific project
.\Scripts\manage-packages.ps1 update "Krypton.Toolkit.Suite.Extended.Core"
```

#### **Package Information**
```powershell
# List all packages
.\Scripts\manage-packages.ps1 list

# List packages in specific project
.\Scripts\manage-packages.ps1 list "Krypton.Toolkit.Suite.Extended.Core"
```

#### **Maintenance**
```powershell
# Restore packages
.\Scripts\manage-packages.ps1 restore

# Clean package cache
.\Scripts\manage-packages.ps1 clean

# Manage package sources
.\Scripts\manage-packages.ps1 sources
```

### Package Update Workflow

1. **Check for Updates**: Identify outdated packages
2. **Review Changes**: Understand what will be updated
3. **Update Packages**: Apply updates safely
4. **Restore Dependencies**: Ensure all packages are properly restored
5. **Test Build**: Verify everything still builds correctly
6. **Run Tests**: Ensure functionality is preserved

## GitHub Actions Integration

The build system includes GitHub Actions workflows for automated CI/CD:

### Triggers

- **Push**: Automatically builds on pushes to `main`, `develop`, `alpha`, and `nightly` branches
- **Pull Request**: Builds on PRs to `main` and `develop` branches
- **Manual**: Manual workflow dispatch with configurable parameters

### Jobs

1. **Build**: Matrix build across all configurations and target frameworks
2. **Test**: Runs tests (when implemented)
3. **Package**: Creates release packages for main/develop branches

### Matrix Strategy

The workflow uses a matrix strategy to build all combinations of:
- Configurations: Debug, Release, Canary, Nightly
- Target Frameworks: net48, net481, net8.0-windows, net9.0-windows

Exclusions are applied to prevent invalid combinations (e.g., .NET Framework with Canary/Nightly).

## Configuration Files

### build-config.json

Central configuration file that defines:
- Build configurations and their properties
- Target framework support
- MSBuild settings
- NuGet package settings
- Versioning rules
- Cleanup policies
- Artifact generation

### Directory.Build.props

MSBuild properties file that:
- Imports root-level properties
- Sets common project properties
- Configures assembly information
- Handles package metadata

### Directory.Build.targets

MSBuild targets file that:
- Defines version generation logic
- Configures build-specific properties
- Sets language version and analysis level

## Customization

### Adding New Configurations

1. Add configuration to `build-config.json`
2. Update `Directory.Build.targets` with version logic
3. Add configuration to build scripts
4. Update GitHub Actions workflow

### Adding New Target Frameworks

1. Add framework to `build-config.json`
2. Update supported configurations
3. Add framework to build scripts
4. Update GitHub Actions matrix

### Modifying Build Behavior

1. Edit `build-config.json` for general settings
2. Modify build scripts for script-specific behavior
3. Update MSBuild files for build-time behavior

### Customizing Package Updates

1. Modify `manage-packages.ps1` for custom update logic
2. Add project-specific update rules
3. Configure update exclusions for critical packages
4. Set up automated update workflows

## Troubleshooting

### Common Issues

#### MSBuild Not Found
- Ensure Visual Studio is installed
- Add MSBuild to PATH
- Use full path to MSBuild in scripts

#### Build Failures
- Check target framework compatibility
- Verify NuGet package restore
- Review build logs for specific errors

#### Version Conflicts
- Ensure consistent versioning across projects
- Check `Directory.Build.props` inheritance
- Verify assembly info generation

#### Package Update Issues
- Check NuGet CLI installation
- Verify package source accessibility
- Review package compatibility constraints
- Check for breaking changes in major updates

### Debug Mode

Enable verbose output for troubleshooting:

```powershell
.\build.ps1 -Verbose
.\manage-packages.ps1 check -Verbose
```

Or modify `build-config.json`:

```json
{
  "buildSettings": {
    "verbosity": "detailed"
  }
}
```

## Best Practices

1. **Always clean before building**: Use `-Clean` flag or run `clean.cmd`
2. **Use appropriate configurations**: Debug for development, Release for production
3. **Test multiple frameworks**: Ensure compatibility across .NET versions
4. **Monitor CI/CD**: Check GitHub Actions for build status
5. **Version consistently**: Use the built-in versioning system
6. **Update packages regularly**: Keep dependencies current and secure
7. **Test after updates**: Verify functionality after package updates
8. **Use safe updates**: Prefer safe updates for production environments
9. **Review breaking changes**: Understand impact of major version updates
10. **Maintain package cache**: Clean cache periodically to avoid issues

## Contributing

When contributing to the build system:

1. Test changes locally before committing
2. Update documentation for new features
3. Ensure backward compatibility
4. Test across different configurations
5. Validate GitHub Actions workflows
6. Test package update scenarios
7. Verify package compatibility

## Support

For build system issues:

1. Check this documentation
2. Review build logs and error messages
3. Consult the [Krypton Standard Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit) for reference
4. Open an issue with detailed error information
5. Check package update logs for compatibility issues

## License

This build system follows the same license as the Krypton Extended Toolkit project.
