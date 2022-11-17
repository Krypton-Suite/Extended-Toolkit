﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#if NETSTANDARD && NETCOREAPP3_1_OR_GREATER
using System.Text.Json;
#else
using Newtonsoft.Json;
#endif

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    class JSONConfiguration : Configuration
    {
        private string _savePath;

        /// <summary>
        /// The constructor reads out all configured values
        /// </summary>        
        /// <param name="referenceAssembly">the reference assembly name</param>
        public JSONConfiguration(string referenceAssembly)
            : this(referenceAssembly, true)
        { }

        /// <inheritdoc/>
        public JSONConfiguration(string referenceAssembly, bool isReflectionBasedAssemblyAccessorUsed)
            : this(referenceAssembly, isReflectionBasedAssemblyAccessorUsed, string.Empty)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="referenceAssembly">the name of the reference assembly</param>
        /// <param name="isReflectionBasedAssemblyAccessorUsed"><c>true</c> if reflection is used to access the assembly.</param>
        /// <param name="savePath"><c>true</c> if reflection is used to access the assembly.</param>
        public JSONConfiguration(string referenceAssembly, bool isReflectionBasedAssemblyAccessorUsed, string savePath)
            : base(referenceAssembly, isReflectionBasedAssemblyAccessorUsed)
        {
            _savePath = savePath ?? GetSavePath();
            try
            {
                // get the save path
                _savePath = GetSavePath();
                // load the values
                LoadValuesFromPath(_savePath);
            }
            catch (NetSparkleException)
            {
                // disable update checks when exception occurred -- can't read/save necessary update file 
                CheckForUpdate = false;
                throw;
            }
        }

        /// <summary>
        /// Touches to profile time
        /// </summary>
        public override void TouchProfileTime()
        {
            base.TouchProfileTime();
            // save the values
            SaveValuesToPath(GetSavePath());
        }

        /// <summary>
        /// Touches the check time to now, should be used after a check directly
        /// </summary>
        public override void TouchCheckTime()
        {
            base.TouchCheckTime();
            // save the values
            SaveValuesToPath(GetSavePath());
        }

        /// <summary>
        /// This method allows to skip a specific version
        /// </summary>
        /// <param name="version">the version to skeip</param>
        public override void SetVersionToSkip(string version)
        {
            base.SetVersionToSkip(version);
            SaveValuesToPath(GetSavePath());
        }

        /// <summary>
        /// Reloads the configuration object
        /// </summary>
        public override void Reload()
        {
            LoadValuesFromPath(GetSavePath());
        }

        /// <summary>
        /// This function build a valid registry path in dependecy to the 
        /// assembly information
        /// </summary>
        public virtual string GetSavePath()
        {
            if (!string.IsNullOrEmpty(_savePath))
            {
                return _savePath;
            }
            else
            {
                AssemblyAccessor accessor = new AssemblyAccessor(ReferenceAssembly, UseReflectionBasedAssemblyAccessor);

                if (string.IsNullOrEmpty(accessor.AssemblyCompany) || string.IsNullOrEmpty(accessor.AssemblyProduct))
                {
                    throw new NetSparkleException("Error: SparkleUpdater is missing the company or productname tag in " + ReferenceAssembly);
                }
                var applicationFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.DoNotVerify);
                var saveFolder = Path.Combine(applicationFolder, accessor.AssemblyCompany, accessor.AssemblyProduct, "NetSparkleUpdater");
                if (!Directory.Exists(saveFolder))
                {
                    Directory.CreateDirectory(saveFolder);
                }
                var saveLocation = Path.Combine(saveFolder, "data.json");
                return saveLocation;
            }
        }

        /// <summary>
        /// This method loads the values from registry
        /// </summary>
        /// <param name="saveLocation">the saved file location</param>
        /// <returns><c>true</c> if the items were loaded</returns>
        private bool LoadValuesFromPath(string saveLocation)
        {
            if (File.Exists(saveLocation))
            {
                try
                {
                    string json = File.ReadAllText(saveLocation);
#if NETSTANDARD
                    var data = JsonSerializer.Deserialize<SavedConfigurationData>(json);
#else
                    var data = JsonConvert.DeserializeObject<SavedConfigurationData>(json);
#endif
                    CheckForUpdate = true;
                    LastCheckTime = data.LastCheckTime;
                    LastVersionSkipped = data.LastVersionSkipped;
                    DidRunOnce = data.DidRunOnce;
                    IsFirstRun = !DidRunOnce;
                    LastConfigUpdate = data.LastConfigUpdate;
                    PreviousVersionOfSoftwareRan = data?.PreviousVersionOfSoftwareRan ?? "";
                    if (IsFirstRun)
                    {
                        SaveDidRunOnceAsTrue(saveLocation);
                    }
                    else
                    {
                        SaveValuesToPath(saveLocation); // so PreviousVersion is set to proper value
                    }
                    return true;
                }
                catch (Exception) // just in case...
                {
                }
            }
            CheckForUpdate = true;
            LastCheckTime = DateTime.Now;
            LastVersionSkipped = string.Empty;
            DidRunOnce = false;
            IsFirstRun = true;
            SaveDidRunOnceAsTrue(saveLocation);
            LastConfigUpdate = DateTime.Now;
            PreviousVersionOfSoftwareRan = "";
            return true;
        }

        private void SaveDidRunOnceAsTrue(string saveLocation)
        {
            var initialValue = DidRunOnce;
            DidRunOnce = true;
            SaveValuesToPath(saveLocation); // save it so next time we load DidRunOnce is true
            DidRunOnce = initialValue; // so data is correct to user of Configuration class
        }

        /// <summary>
        /// This method stores the information to disk as json
        /// </summary>
        /// <param name="savePath">the save path to the json file</param>
        /// <returns><c>true</c> if the values were saved to disk</returns>
        private bool SaveValuesToPath(string savePath)
        {
            var savedConfig = new SavedConfigurationData()
            {
                CheckForUpdate = true,
                LastCheckTime = this.LastCheckTime,
                LastVersionSkipped = this.LastVersionSkipped,
                DidRunOnce = this.DidRunOnce,
                LastConfigUpdate = DateTime.Now,
                PreviousVersionOfSoftwareRan = InstalledVersion
            };
            LastConfigUpdate = savedConfig.LastConfigUpdate;

#if NETSTANDARD
            string json = JsonSerializer.Serialize(savedConfig);
#else
            string json = JsonConvert.SerializeObject(savedConfig);
#endif
            try
            {
                File.WriteAllText(savePath, json);
            }
            catch (Exception) // just in case...
            {
                return false;
            }

            return true;
        }
    }
}