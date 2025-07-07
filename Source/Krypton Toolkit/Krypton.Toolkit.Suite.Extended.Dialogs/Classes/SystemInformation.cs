

namespace Krypton.Toolkit.Suite.Extended.Dialogs;

internal class SystemInformationUtilities
{
    #region Public

    public string? CPUName { get; set; }

    public long InstalledMemoryMB { get; set; }
    public string[] Drives { get; set; }
    public string?[] GraphicsProcessorUnits { get; set; }
    public string OperatingSystem { get; set; }
    public string OperatingSystemArchitecture { get; set; }

    #endregion

    #region Implementation

    public static SystemInformationUtilities CollectSystemInformation()
    {
        var info = new SystemInformationUtilities(); 
        info.CPUName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "Unknown")?.ToString();

        GetPhysicallyInstalledSystemMemory(out long memKb);
        info.InstalledMemoryMB = memKb / 1024;

        var drives = DriveInfo.GetDrives();
        info.Drives = new string[drives.Length];
        for (int i = 0; i < drives.Length; i++)
        {
            if (drives[i].IsReady)
                info.Drives[i] = $"{drives[i].Name} - {drives[i].DriveType}, {drives[i].TotalSize / 1024 / 1024 / 1024} GB";
            else
                info.Drives[i] = $"{drives[i].Name} - Not Ready";
        }

        var gpus = new List<string?>();
        using (var key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E968-E325-11CE-BFC1-08002BE10318}"))
        {
            foreach (var subkeyName in (key != null ? key.GetSubKeyNames() : null)!)
            {
                using (var subkey = key?.OpenSubKey(subkeyName))
                {
                    var driverDesc = subkey?.GetValue("DriverDesc")?.ToString();
                    if (!string.IsNullOrEmpty(driverDesc))
                        gpus.Add(driverDesc);
                }
            }
        }
        info.GraphicsProcessorUnits = gpus.ToArray();

#if NET471_OR_GREATER
        info.OperatingSystem = Environment.OSVersion + " / " + RuntimeInformation.OSDescription;
        info.OperatingSystemArchitecture = RuntimeInformation.OSArchitecture.ToString();
#else
        info.OperatingSystem = Environment.OSVersion.ToString();

        info.OperatingSystemArchitecture = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
#endif

        return info;
    }

    public string ToJSON() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    public string ToXML()
    {
        using (var stringWriter = new StringWriter())
        {
            var serializer = new XmlSerializer(typeof(SystemInformationUtilities));
            serializer.Serialize(stringWriter, this);
            return stringWriter.ToString();
        }
    }

    [DllImport("kernel32.dll")]
    private static extern void GetPhysicallyInstalledSystemMemory(out long totalMemoryInKb);

#endregion
}