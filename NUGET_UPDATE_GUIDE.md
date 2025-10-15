# NuGet Package Update Guide

## 🚀 Quick Start

### Using the Interactive Menu

1. **Run the build system**:
   ```cmd
   run.cmd
   ```

2. **Choose option 7** (NuGet Package Manager)

3. **Select what you want to do**:
   - Check for outdated packages
   - Update all packages
   - Clear NuGet cache
   - And more!

### Using the Standalone Tool

You can also run the NuGet manager directly:
```cmd
update-nuget.cmd
```

## 📋 Available Options

### 1. Check for Outdated Packages ✅

**What it does**: Shows which packages have newer versions available

**How**:
- Uses `dotnet-outdated` tool (recommended)
- Falls back to basic `dotnet list package --outdated` if tool not installed
- Shows current version vs. latest version
- Color-coded output for easy identification

**When to use**: Before updating, to see what will change

### 2. Update All NuGet Packages 🔄

**What it does**: Forces update of all NuGet packages to latest versions

**Process**:
1. Clears local NuGet cache
2. Restores packages with `--force` flag
3. Downloads latest compatible versions

**Warning**: This updates ALL packages. Test thoroughly after!

**When to use**: 
- Major version updates
- After long periods without updates
- Fresh start needed

### 3. Clear NuGet Cache 🧹

**What it does**: Removes all cached NuGet packages

**Clears**:
- http-cache
- global-packages
- temp
- plugins-cache

**When to use**:
- Package corruption issues
- Download problems
- Before fresh restore
- Disk space cleanup

### 4. List All Packages 📦

**What it does**: Shows all installed packages across all projects

**Output includes**:
- Package name
- Version number
- Project using it

**When to use**:
- Audit dependencies
- Documentation
- Understanding project structure

### 5. Install dotnet-outdated Tool 🔧

**What it does**: Installs the recommended package checking tool

**Tool**: `dotnet-outdated-tool`

**Benefits**:
- Better formatting than default
- More detailed information
- Easier to read
- Shows dependency tree

**When to use**: First time setup, or if tool is missing

### 6. Update Specific Package 🎯

**What it does**: Updates a single package in a specific project

**Requires**:
- Project file path
- Package name

**Example**:
```
Project: Source\Krypton Toolkit\Krypton.Toolkit.Suite.Extended.Core\Krypton.Toolkit.Suite.Extended.Core 2022.csproj
Package: Newtonsoft.Json
```

**When to use**:
- Targeted updates
- Testing specific package versions
- Fixing known issues

### 7. Restore Packages (Normal) 📥

**What it does**: Standard NuGet restore without forcing updates

**Process**:
- Downloads missing packages
- Uses existing versions
- Respects lock files

**When to use**:
- After cloning repo
- After pulling changes
- Build errors about missing packages

### 8. Show NuGet Sources 🌐

**What it does**: Lists configured package sources

**Shows**:
- Source name
- Source URL
- Enabled/disabled status

**Additional info**: Commands to add/remove sources

**When to use**:
- Verify package sources
- Troubleshoot download issues
- Configure private feeds

## 🎯 Common Workflows

### First Time Setup

1. Run `update-nuget.cmd`
2. Choose **5** (Install dotnet-outdated tool)
3. Choose **7** (Restore packages)
4. Done!

### Regular Updates

1. Run `update-nuget.cmd`
2. Choose **1** (Check for outdated packages)
3. Review what will be updated
4. Choose **2** (Update all) if acceptable
5. Test your build: `run.cmd` → Build

### Troubleshooting Package Issues

1. Run `update-nuget.cmd`
2. Choose **3** (Clear NuGet cache)
3. Choose **7** (Restore packages)
4. If still issues, choose **2** (Update all)

### Updating Specific Package

1. Run `update-nuget.cmd`
2. Choose **6** (Update specific package)
3. Enter project path (use Tab for autocomplete in console)
4. Enter package name
5. Confirm update

## 📝 Command Line Alternatives

If you prefer command line:

### Check Outdated (with tool)
```bash
dotnet outdated "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln"
```

### Check Outdated (basic)
```bash
dotnet list "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" package --outdated
```

### Force Update All
```bash
dotnet nuget locals all --clear
dotnet restore "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" --force
```

### Update Specific Package
```bash
dotnet add "Source\Krypton Toolkit\[PROJECT]\[PROJECT].csproj" package [PACKAGENAME]
```

### List All Packages
```bash
dotnet list "Source\Krypton Toolkit\Krypton Toolkit Suite Extended 2022 - VS2022.sln" package
```

## ⚠️ Important Notes

### Before Updating

1. **Commit your changes** - Always have a clean git state
2. **Backup** - Consider creating a branch for updates
3. **Read release notes** - Check breaking changes
4. **Test plan** - Know how you'll verify the update

### After Updating

1. **Build** - Ensure project still builds
2. **Test** - Run your test suite
3. **Check breaking changes** - Look for API changes
4. **Update docs** - Note version changes

### Breaking Changes

Major version updates (e.g., 1.x → 2.x) may have breaking changes:
- Review package changelog
- Test thoroughly
- Update code as needed
- May require code refactoring

### Version Pinning

If you need specific versions, edit `.csproj` files:
```xml
<PackageReference Include="PackageName" Version="1.2.3" />
```

To allow updates within a range:
```xml
<PackageReference Include="PackageName" Version="1.2.*" />
<PackageReference Include="PackageName" Version="1.*" />
```

## 🔧 Integration with Build System

The NuGet Package Manager is integrated into `run.cmd`:

```
Main Menu → Option 7 → NuGet Package Manager
```

After updating packages:
1. Return to main menu
2. Choose **1** (Clean project)
3. Choose **4** → **3** (Build and Pack Stable)
4. Test your build

## 📚 Additional Resources

### dotnet-outdated Tool
- GitHub: https://github.com/dotnet-outdated/dotnet-outdated
- Documentation: Shows outdated packages in solution

### NuGet Documentation
- Package Management: https://docs.microsoft.com/nuget/
- CLI Reference: https://docs.microsoft.com/nuget/reference/dotnet-commands

### Troubleshooting

**Issue**: Tool not found
```bash
dotnet tool install --global dotnet-outdated-tool
```

**Issue**: Packages not updating
```bash
dotnet nuget locals all --clear
dotnet restore --force
```

**Issue**: Version conflicts
- Check `.csproj` files for version pins
- Review package compatibility
- Use `dotnet outdated` to see dependency tree

## 🎉 Quick Reference Card

| Task | Menu Option | Command Alternative |
|------|-------------|-------------------|
| Check outdated | 1 | `dotnet outdated [sln]` |
| Update all | 2 | `dotnet restore [sln] --force` |
| Clear cache | 3 | `dotnet nuget locals all --clear` |
| List packages | 4 | `dotnet list [sln] package` |
| Install tool | 5 | `dotnet tool install --global dotnet-outdated-tool` |
| Update one | 6 | `dotnet add [proj] package [name]` |
| Restore | 7 | `dotnet restore [sln]` |
| Show sources | 8 | `dotnet nuget list source` |

---

**Need Help?** 

Run `update-nuget.cmd` and choose option 1 to see what packages can be updated!

