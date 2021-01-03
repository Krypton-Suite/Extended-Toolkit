#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    /// <summary>
    /// https://ourcodeworld.com/articles/read/439/how-to-list-all-windows-processes-and-their-attributes-task-manager-like-with-c-in-winforms
    /// </summary>
    /// <seealso cref="Krypton.Toolkit.KryptonForm" />
    public class KryptonTaskManager : KryptonForm
    {

        #region Old Code

        /*
        #region Designer Code
        private System.Windows.Forms.ListView lvProcesses;
        private System.Windows.Forms.ColumnHeader chProcessName;
        private System.Windows.Forms.ColumnHeader chPID;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ColumnHeader chUsername;
        private System.Windows.Forms.ColumnHeader chMemory;
        private System.Windows.Forms.ColumnHeader chDescription;

        private void InitializeComponent()
        {
            this.lvProcesses = new System.Windows.Forms.ListView();
            this.chProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUsername = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMemory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvProcesses
            // 
            this.lvProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProcessName,
            this.chPID,
            this.chStatus,
            this.chUsername,
            this.chMemory,
            this.chDescription});
            this.lvProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProcesses.HideSelection = false;
            this.lvProcesses.Location = new System.Drawing.Point(0, 0);
            this.lvProcesses.Name = "lvProcesses";
            this.lvProcesses.Size = new System.Drawing.Size(882, 595);
            this.lvProcesses.TabIndex = 0;
            this.lvProcesses.UseCompatibleStateImageBehavior = false;
            this.lvProcesses.View = System.Windows.Forms.View.Details;
            // 
            // chProcessName
            // 
            this.chProcessName.Text = "Process Name";
            this.chProcessName.Width = 185;
            // 
            // chPID
            // 
            this.chPID.Text = "PID";
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 114;
            // 
            // chUsername
            // 
            this.chUsername.Text = "Username";
            this.chUsername.Width = 126;
            // 
            // chMemory
            // 
            this.chMemory.Text = "Memory (Private Working Set)";
            this.chMemory.Width = 179;
            // 
            // chDescription
            // 
            this.chDescription.Text = "Description";
            this.chDescription.Width = 322;
            // 
            // KryptonTaskManager
            // 
            this.ClientSize = new System.Drawing.Size(882, 595);
            this.Controls.Add(this.lvProcesses);
            this.Name = "KryptonTaskManager";
            this.Load += new System.EventHandler(this.KryptonTaskManager_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private void KryptonTaskManager_Load(object sender, EventArgs e)
        {
            RenderProcessesOnListView();
        }

        #region Methods
        /// <summary>This method renders all the processes of Windows on a ListView with some values and icons.</summary>
        public void RenderProcessesOnListView()
        {
            // Create an array to store the processes
            Process[] processList = Process.GetProcesses();

            // Create an Imagelist that will store the icons of every process
            ImageList Imagelist = new ImageList();

            // Loop through the array of processes to show information of every process in your console
            foreach (Process process in processList)
            {
                // Define the status from a boolean to a simple string
                string status = (process.Responding == true ? "Responding" : "Not responding");

                // Retrieve the object of extra information of the process (to retrieve Username and Description)
                dynamic extraProcessInfo = GetProcessExtraInformation(process.Id);

                // Create an array of string that will store the information to display in our 
                string[] row = {
                    // 1 Process name
                    process.ProcessName,
                    // 2 Process ID
                    process.Id.ToString(),
                    // 3 Process status
                    status,
                    // 4 Username that started the process
                    extraProcessInfo.Username,
                    // 5 Memory usage
                    BytesToReadableValue(process.PrivateMemorySize64),
                    // 6 Description of the process
                    extraProcessInfo.Description
                };

                //
                // As not every process has an icon then, prevent the app from crash
                try
                {
                    Imagelist.Images.Add(
                        // Add an unique Key as identifier for the icon (same as the ID of the process)
                        process.Id.ToString(),
                        // Add Icon to the List 
                        System.Drawing.Icon.ExtractAssociatedIcon(process.MainModule.FileName).ToBitmap()
                    );
                }
                catch { }

                // Create a new Item to add into the list view that expects the row of information as first argument
                ListViewItem item = new ListViewItem(row)
                {
                    // Set the ImageIndex of the item as the same defined in the previous try-catch
                    ImageIndex = Imagelist.Images.IndexOfKey(process.Id.ToString())
                };

                // Add the Item
                lvProcesses.Items.Add(item);
            }

            // Set the imagelist of your list view the previous created list :)
            lvProcesses.LargeImageList = Imagelist;
            lvProcesses.SmallImageList = Imagelist;
        }

        /// <summary>
        /// Method that converts bytes to its human readable value
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string BytesToReadableValue(long number)
        {
            List<string> suffixes = new List<string> { " B", " KB", " MB", " GB", " TB", " PB" };

            for (int i = 0; i < suffixes.Count; i++)
            {
                long temp = number / (int)Math.Pow(1024, i + 1);

                if (temp == 0)
                {
                    return (number / (int)Math.Pow(1024, i)) + suffixes[i];
                }
            }

            return number.ToString();
        }

        /// <summary>
        /// Returns an Expando object with the description and username of a process from the process ID.
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        public ExpandoObject GetProcessExtraInformation(int processId)
        {
            // Query the Win32_Process
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            // Create a dynamic object to store some properties on it
            dynamic response = new ExpandoObject();
            response.Description = "";
            response.Username = "Unknown";

            foreach (ManagementObject obj in processList)
            {
                // Retrieve username 
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return Username
                    response.Username = argList[0];

                    // You can return the domain too like (PCDesktop-123123\Username using instead
                    //response.Username = argList[1] + "\\" + argList[0];
                }

                // Retrieve process description if exists
                if (obj["ExecutablePath"] != null)
                {
                    try
                    {
                        FileVersionInfo info = FileVersionInfo.GetVersionInfo(obj["ExecutablePath"].ToString());
                        response.Description = info.FileDescription;
                    }
                    catch { }
                }
            }

            return response;
        }
        #endregion
        */

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // KryptonTaskManager
            // 
            this.ClientSize = new System.Drawing.Size(953, 645);
            this.Name = "KryptonTaskManager";
            this.Load += new System.EventHandler(this.KryptonTaskManager_Load);
            this.ResumeLayout(false);

        }

        private void KryptonTaskManager_Load(object sender, EventArgs e)
        {

        }
    }
}