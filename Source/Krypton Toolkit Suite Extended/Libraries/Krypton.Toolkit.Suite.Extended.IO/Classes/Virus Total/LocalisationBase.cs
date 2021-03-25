﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    internal class LocalisationBase
    {
        public string MainForm_DragFile = "Drag a File Here";
        public string MainForm_More = "More";

        public string SettingsForm_Title = "Settings";
        public string SettingsForm_General = "General settings";
        public string SettingsForm_Key = "API key";
        public string SettingsForm_Get = "Get API key";
        public string SettingsForm_Language = "Language";
        public string SettingsForm_Save = "Save";
        public string SettingsForm_Open = "Open settings file";
        public string SettingsForm_DirectUpload = "Direct file upload";

        public string UploadForm_Info = "File information";
        public string UploadForm_Upload = "Upload";
        public string UploadForm_Cancel = "Cancel";
        public string UploadForm_NoApiKey = "You have not entered an API key. Please go to settings and add one.";
        public string UploadForm_InvalidLength = "Invalid API key length. The key must contain 64 characters.";
        public string UploadForm_InvalidKey = "Invalid API key";

        public string Message_Idle = "Idle.";
        public string Message_Init = "Initialising...";
        public string Message_Check = "Checking...";
        public string Message_Upload = "Uploading...";
        public string Message_NoLink = "No permalink found in response!";
        public string Message_NoSettings = "No settings file exists.";
        public string Message_Saved = "Settings saved.";
    }
}