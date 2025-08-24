# Build Scripts Directory

This directory contains all the build automation scripts for the Krypton Extended Toolkit project.

## Scripts Overview

### Core Build Scripts

- **`build.cmd`** - Main batch build script for Windows Command Prompt
- **`build.ps1`** - Main PowerShell build script with advanced features
- **`test-build.cmd`** - Test script to verify all build configurations work

### Package Management

- **`manage-packages.ps1`** - Comprehensive NuGet package management script

### Configuration

- **`build-config.json`** - Central build configuration file
- **`BUILD_SYSTEM.md`** - Complete documentation for the build system

## Usage

### From Root Directory

```cmd
# Quick build menu (recommended for most users)
quick-build.cmd

# Direct script calls
Scripts\build.cmd Release AnyCPU net8.0-windows
Scripts\test-build.cmd
```

### From Scripts Directory

```cmd
# Build scripts
build.cmd Release AnyCPU net8.0-windows
test-build.cmd

# PowerShell scripts
.\build.ps1 -Configuration Release
.\manage-packages.ps1 check
```

## Directory Structure

```
Scripts/
├── build.cmd              # Main batch build script
├── build.ps1              # Main PowerShell build script
├── test-build.cmd         # Build testing script
├── manage-packages.ps1    # NuGet package management
├── build-config.json      # Build configuration
├── BUILD_SYSTEM.md        # Complete documentation
└── README.md              # This file
```

## Notes

- All scripts are designed to work from the project root directory
- The `quick-build.cmd` file remains in the root for easy access
- Scripts automatically handle relative path references to source files
- Clean script (`clean.cmd`) remains in root directory for compatibility
