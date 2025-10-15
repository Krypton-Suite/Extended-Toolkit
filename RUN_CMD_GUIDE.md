# Krypton Extended Toolkit - Interactive Build System (run.cmd)

## 🚀 Quick Start

Just double-click **`run.cmd`** to start the interactive build system!

## 📋 Main Menu Options

When you run `run.cmd`, you'll see this menu:

```
Welcome to the Krypton Extended Toolkit Build system, version: 4.0 (MSBuild Edition)
Using MSBuild: C:\Program Files\Microsoft Visual Studio\2022\Enterprise\MSBuild\Current\Bin\MSBuild.exe

==============================================================================================

1. Clean project
2. Build Toolkit
3. Create NuGet packages
4. Build and Pack Toolkit
5. Debug project
6. Rebuild project
7. Show build information
8. Create Archives (ZIP/TAR)
9. End

Enter number (1 - 9):
```

## 🎯 Menu Options Explained

### 1. Clean Project
- Removes all build outputs
- Deletes `Bin/` folder
- Deletes `obj/` folders
- Deletes log files
- **Uses**: `msbuild Build.proj /t:Clean`

### 2. Build Toolkit
Opens **Build Menu** with configuration options:
- **Nightly** (alpha branch, -alpha suffix)
- **Canary** (canary branch, -beta suffix)
- **Stable** (master branch, no suffix)
- **Debug** (development builds)

### 3. Create NuGet Packages
Opens **Pack Menu** for creating packages from existing builds:
- Pack Nightly version
- Pack Canary version
- Pack Stable version

### 4. Build and Pack Toolkit
Opens **Build and Pack Menu** for complete CI pipelines:
- Build and Pack Nightly (Complete CI)
- Build and Pack Canary (Complete CI)
- Build and Pack Stable (Complete CI)
- **Build and Pack All Configurations** (builds all 3 at once!)

### 5. Debug Project
- Cleans and builds Debug configuration
- **Uses**: `msbuild Build.proj /t:Debug`

### 6. Rebuild Project
- Clean + Build in one step
- **Uses**: `msbuild Build.proj /t:Rebuild`

### 7. NuGet Package Manager
Opens the **NuGet Package Manager** for managing dependencies:
- Check for outdated packages
- Update all packages
- Clear NuGet cache
- Install dotnet-outdated tool
- Update specific packages
- Restore packages
- Show package sources

See [NUGET_UPDATE_GUIDE.md](NUGET_UPDATE_GUIDE.md) for details.

### 8. Show Build Information
Shows system information:
- MSBuild location
- Release channels
- Output locations
- Available targets

### 9. Create Archives (ZIP/TAR)
Archive management:
- Create ZIP archives for each configuration
- Show package locations
- Manage existing archives

### 10. End
Exit the build system

## 🌿 Release Channels

The system supports three release channels exactly as requested:

| Menu Option | Configuration | Branch | Package Suffix | Output Directory |
|------------|---------------|--------|----------------|------------------|
| **Nightly** | `Nightly` | `alpha` | `-alpha` | `Bin\Nightly\` |
| **Canary** | `Canary` | `canary` | `-beta` | `Bin\Canary\` |
| **Stable** | `Release` | `master` | _(none)_ | `Bin\Release\` |

## 📁 Output Locations

After building, find your files here:

```
Bin/
├── Release/              # Stable builds (master)
├── Canary/               # Canary builds (canary)
├── Nightly/              # Nightly builds (alpha)
├── Debug/                # Debug builds
└── NuGet Packages/
    ├── Release/          # Stable packages
    ├── Canary/           # Beta packages (-beta)
    └── Nightly/          # Alpha packages (-alpha)
```

## 🎯 Common Workflows

### Daily Development
1. Run `run.cmd`
2. Choose **5** (Debug project)
3. Test your changes

### Creating a Release
1. Run `run.cmd`
2. Choose **4** (Build and Pack Toolkit)
3. Choose **4** (Build and Pack All Configurations)
4. Wait for all three channels to build
5. Choose **8** (Create Archives) to create ZIP files

### Testing Specific Channel
1. Run `run.cmd`
2. Choose **4** (Build and Pack Toolkit)
3. Choose **1** (Nightly), **2** (Canary), or **3** (Stable)

### Quick Clean and Build
1. Run `run.cmd`
2. Choose **6** (Rebuild project)

## ✨ Features

### Automatic MSBuild Detection
The system automatically finds MSBuild from:
- Visual Studio 2022 Enterprise
- Visual Studio 2022 Professional
- Visual Studio 2022 Community
- System PATH

### Smart Error Handling
- Clear success/failure messages
- Helpful error information
- Graceful handling of missing files

### Visual Feedback
- Progress indicators
- Clear section headers
- Color-coded messages (✅ ❌)
- Organized output

### Archive Management
- Create ZIP files from packages
- Check for existing builds
- Show package locations

## 🔄 Integration with Build.proj

The `run.cmd` system uses the MSBuild `Build.proj` file under the hood:

```cmd
Clean project       → msbuild Build.proj /t:Clean
Build Nightly       → msbuild Build.proj /t:Build /p:Configuration=Nightly
Pack Canary         → msbuild Build.proj /t:Pack /p:Configuration=Canary
Complete CI Stable  → msbuild Build.proj /t:CI /p:Configuration=Release
Debug build         → msbuild Build.proj /t:Debug
Rebuild             → msbuild Build.proj /t:Rebuild
```

## 🎓 Tips

### First Time Use
1. Start with **7** (Show build information) to understand the system
2. Try **1** (Clean project) to start fresh
3. Use **4** → **3** (Build and Pack Stable) for your first build

### Regular Development
- Use **5** (Debug project) for testing changes
- Use **6** (Rebuild project) when you want a clean build
- Check **8** (Create Archives) → **5** (Show package locations) to see what you've built

### Creating Releases
- Use **4** → **4** (Build and Pack All Configurations) to build everything
- Use **8** → **4** (Create ZIP archives for all) to create distribution files

### Troubleshooting
- Check **7** (Show build information) to verify MSBuild is found
- Use **1** (Clean project) if builds are acting strange
- Look at the console output for detailed error messages

## 🎉 Ready to Use!

Just double-click `run.cmd` and start building! The interactive menu makes it easy to:

- ✅ Build any configuration
- ✅ Create packages
- ✅ Manage outputs
- ✅ Create archives
- ✅ Clean up

**No command-line knowledge required** - just follow the menus! 🚀
