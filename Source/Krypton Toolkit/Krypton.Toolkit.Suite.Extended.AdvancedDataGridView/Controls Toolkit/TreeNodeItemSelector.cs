#region Original License
/*
 *
 * Microsoft Public License (Ms-PL)
 *
 * This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
 *
 * 1. Definitions 
 *
 * The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
 *
 * A "contribution" is the original software, or any additions or changes to the software.
 *
 * A "contributor" is any person that distributes its contribution under this license.
 *
 * "Licensed patents" are a contributor's patent claims that read directly on its contribution.
 *
 * 2. Grant of Rights
 *
 * (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
 *
 * (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
 *
 * 3. Conditions and Limitations
 *
 * (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
 *
 * (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
 *
 * (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
 *
 * (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
 *
 * (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
 *
 */
#endregion

#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

// ReSharper disable ConvertTypeCheckToNullCheck
namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

internal class TreeNodeItemSelector : TreeNode
{
    #region public enum

    public enum CustomNodeType : byte
    {
        Default,
        SelectAll,
        SelectEmpty,
        DateTimeNode
    }

    #endregion


    #region class properties

    private CheckState _checkState = CheckState.Unchecked;
    private TreeNodeItemSelector? _parent;

    #endregion


    #region constructor

    /// <summary>
    /// TreeNodeItemSelector constructor
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="state"></param>
    /// <param name="nodeType"></param>
    private TreeNodeItemSelector(string? text, object? value, CheckState state, CustomNodeType nodeType)
        : base(text)
    {
        CheckState = state;
        NodeType = nodeType;
        Value = value;
    }

    #endregion


    #region public clone method

    /// <summary>
    /// Clone a Node
    /// </summary>
    /// <returns></returns>
    public new TreeNodeItemSelector? Clone()
    {
        TreeNodeItemSelector? n = new TreeNodeItemSelector(Text, Value, _checkState, NodeType)
        {
            NodeFont = NodeFont
        };

        if (GetNodeCount(false) > 0)
        {
            foreach (TreeNodeItemSelector? child in Nodes)
            {
                if (child != null)
                {
                    n.AddChild(child.Clone());
                }
            }
        }

        return n;
    }

    #endregion


    #region public getters / setters

    /// <summary>
    /// Get Node NodeType
    /// </summary>
    public CustomNodeType NodeType { get; private set; }

    /// <summary>
    /// Get Node value
    /// </summary>
    public object? Value { get; private set; }

    /// <summary>
    /// Get Node parent
    /// </summary>
    public new TreeNodeItemSelector? Parent
    {
        get => _parent;
        set => _parent = value;
    }

    /// <summary>
    /// Node is Checked
    /// </summary>
    public new bool Checked
    {
        get => _checkState == CheckState.Checked;
        set => CheckState = value == true ? CheckState.Checked : CheckState.Unchecked;
    }

    /// <summary>
    /// Get or Set the current Node CheckState
    /// </summary>
    public CheckState CheckState
    {
        get => _checkState;
        set
        {
            _checkState = value;
            switch (_checkState)
            {
                case CheckState.Checked:
                    StateImageIndex = 1;
                    break;

                case CheckState.Indeterminate:
                    StateImageIndex = 2;
                    break;

                default:
                    StateImageIndex = 0;
                    break;
            }
        }
    }

    #endregion


    #region public create nodes methods

    /// <summary>
    /// Create a Node
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="state"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static TreeNodeItemSelector CreateNode(string? text, object? value, CheckState state, CustomNodeType type)
    {
        return new TreeNodeItemSelector(text, value, state, type);
    }

    /// <summary>
    /// Create a child Node
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public TreeNodeItemSelector? CreateChildNode(string? text, object? value, CheckState state)
    {
        TreeNodeItemSelector? n = null;

        //specific method for datetimenode
        if (NodeType == CustomNodeType.DateTimeNode)
        {
            n = new TreeNodeItemSelector(text, value, state, CustomNodeType.DateTimeNode);
        }

        if (n != null)
        {
            AddChild(n);
        }

        return n;
    }
    public TreeNodeItemSelector? CreateChildNode(string? text, object? value)
    {
        return CreateChildNode(text, value, _checkState);
    }

    /// <summary>
    /// Add a child Node to this Node
    /// </summary>
    /// <param name="child"></param>
    protected void AddChild(TreeNodeItemSelector? child)
    {
        child!.Parent = this;
        Nodes.Add(child);
    }

    #endregion
}