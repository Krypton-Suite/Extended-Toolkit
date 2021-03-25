﻿using System;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPNodeInformation
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public DateTime DateModified { get; set; }
        public FTPNodeType NodeType { get; set; }
    }
}