#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class FCTBTypeDescriptor : CustomTypeDescriptor
    {
        ICustomTypeDescriptor parent;
        object instance;

        public FCTBTypeDescriptor(ICustomTypeDescriptor parent, object instance)
            : base(parent)
        {
            this.parent = parent;
            this.instance = instance;
        }

        public override string GetComponentName()
        {
            var ctrl = (instance as Control);
            return ctrl == null ? null : ctrl.Name;
        }

        public override EventDescriptorCollection GetEvents()
        {
            var coll = base.GetEvents();
            var list = new EventDescriptor[coll.Count];

            for (int i = 0; i < coll.Count; i++)
                if (coll[i].Name == "TextChanged")//instead of TextChanged slip BindingTextChanged for binding
                    list[i] = new FooTextChangedDescriptor(coll[i]);
                else
                    list[i] = coll[i];

            return new EventDescriptorCollection(list);
        }
    }
}