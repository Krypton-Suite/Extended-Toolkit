using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.IO
{
    public interface ICopyFileDetails
    {
        ISynchronizeInvoke SynchronizationObject { get; set; }
    }
}