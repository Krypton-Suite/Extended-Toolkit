using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace Krypton.Toolkit.Suite.Extended.Dialogs;

public static class SystemInformationCollector
{
    #region Implementation

    public static string CollectSystemInformation()
    {
        var sb = new StringBuilder();

        sb.AppendLine("System Information:");

        sb.AppendLine("=== CPU ===");
        sb.AppendLine("Name: " + Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "Unknown"));

        GetPhysicallyInstalledSystemMemory(out long memKb);
        sb.AppendLine("=== RAM ===");
        sb.AppendLine($"Installed Memory: {memKb / 1024 / 1024} GB");
        sb.AppendLine("=== Drives ===");
        foreach (DriveInfo d in DriveInfo.GetDrives())
        {
            if (d.IsReady)
            {
                sb.AppendLine($"{d.Name} - {d.DriveType}, {d.TotalSize / 1024 / 1024 / 1024} GB");
            }
        }

        sb.AppendLine("=== GPU (Registry) ===");
        try
        {
            using (RegistryKey? key =
                   Registry.LocalMachine.OpenSubKey(
                       @"SYSTEM\CurrentControlSet\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}"))
            {
                if (key != null)
                {
                    foreach (var subkeyName in key.GetSubKeyNames())
                    {
                        using (var subkey = key.OpenSubKey(subkeyName))
                        {
                            var driverDesc = subkey?.GetValue("DriverDesc")?.ToString();
                            if (!string.IsNullOrEmpty(driverDesc))
                                sb.AppendLine(driverDesc);
                        }
                    }
                }
                else
                {
                    sb.AppendLine("Failed to open GPU registry key.");
                }
            }
        }
        catch (Exception ex)
        {
            sb.AppendLine("Failed to read GPU info: " + ex.Message);
        }

        sb.AppendLine("=== Operating System ===");

        sb.AppendLine("OS Version: " + Environment.OSVersion);
        sb.AppendLine("OS Platform: " + Environment.OSVersion.Platform);
        sb.AppendLine("OS Service Pack: " + Environment.OSVersion.ServicePack);
        sb.AppendLine("OS Version String: " + Environment.OSVersion.VersionString);

#if NET471_OR_GREATER
        sb.AppendLine("OS Description: " + RuntimeInformation.OSDescription);
        sb.AppendLine("OS Architecture: " + RuntimeInformation.OSArchitecture);
#else
        sb.AppendLine("OS Description: " + Environment.OSVersion);
        sb.AppendLine("OS Architecture: " + (Environment.Is64BitOperatingSystem ? "x64" : "x86"));
#endif

        return sb.ToString();
    }

    [DllImport("kernel32.dll")]
    private static extern void GetPhysicallyInstalledSystemMemory(out long totalMemoryInKb);

#endregion
}