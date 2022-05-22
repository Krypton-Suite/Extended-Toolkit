#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal abstract class RedBackList : IEnumerable
    {
        private class MyEnumerator : IEnumerator
        {
            private TreeNode _node;

            private TreeNode _root;

            private bool _moved;

            public object Current
            {
                get
                {
                    if (_node == null)
                    {
                        throw new InvalidOperationException();
                    }
                    return _node.Key;
                }
            }

            internal MyEnumerator(TreeNode node)
            {
                _root = node;
            }

            public bool MoveNext()
            {
                if (!_moved)
                {
                    _node = ((_root != null) ? FindMinSubTree(_root) : null);
                    _moved = true;
                }
                else
                {
                    _node = ((_node != null) ? FindSuccessor(_node) : null);
                }
                return _node != null;
            }

            public void Reset()
            {
                _moved = false;
                _node = null;
            }
        }

        private class TreeNode
        {
            private object _key;

            private bool _isRed;

            private TreeNode _leftChild;

            private TreeNode _rightChild;

            private TreeNode _parent;

            internal TreeNode Left
            {
                get
                {
                    return _leftChild;
                }
                set
                {
                    _leftChild = value;
                    if (_leftChild != null)
                    {
                        _leftChild._parent = this;
                    }
                }
            }

            internal TreeNode Right
            {
                get
                {
                    return _rightChild;
                }
                set
                {
                    _rightChild = value;
                    if (_rightChild != null)
                    {
                        _rightChild._parent = this;
                    }
                }
            }

            internal TreeNode Parent
            {
                get
                {
                    return _parent;
                }
                set
                {
                    _parent = value;
                }
            }

            internal bool IsRed
            {
                get
                {
                    return _isRed;
                }
                set
                {
                    _isRed = value;
                }
            }

            internal object Key => _key;

            internal TreeNode(object key)
            {
                _key = key;
            }

            internal void CopyNode(TreeNode from)
            {
                _key = from._key;
            }
        }

        private enum NodeColor
        {
            BLACK,
            RED
        }

        private TreeNode _root;

        internal bool IsEmpty => _root == null;

        internal bool CountIsOne
        {
            get
            {
                if (_root != null && _root.Left == null)
                {
                    return _root.Right == null;
                }
                return false;
            }
        }

        internal bool ContainsMoreThanOneItem
        {
            get
            {
                if (_root != null)
                {
                    if (_root.Right == null)
                    {
                        return _root.Left != null;
                    }
                    return true;
                }
                return false;
            }
        }

        internal object First
        {
            get
            {
                if (_root == null)
                {
                    return null;
                }
                return FindMinSubTree(_root).Key;
            }
        }

        internal RedBackList()
        {
        }

        internal void Add(object key)
        {
            TreeNode treeNode = new TreeNode(key);
            treeNode.IsRed = true;
            InsertNode(_root, treeNode);
            FixUpInsertion(treeNode);
            _root = FindRoot(treeNode);
        }

        internal void Remove(object key)
        {
            TreeNode treeNode = FindItem(_root, key);
            if (treeNode == null)
            {
                throw new KeyNotFoundException();
            }
            TreeNode treeNode2 = DeleteNode(treeNode);
            FixUpRemoval(treeNode2);
            if (treeNode2 == _root)
            {
                if (_root.Left != null)
                {
                    _root = FindRoot(_root.Left);
                }
                else if (_root.Right != null)
                {
                    _root = FindRoot(_root.Right);
                }
                else
                {
                    _root = null;
                }
            }
            else
            {
                _root = FindRoot(_root);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_root);
        }

        protected abstract int CompareTo(object object1, object object2);

        private static TreeNode GetUncle(TreeNode node)
        {
            if (node.Parent == node.Parent.Parent.Left)
            {
                return node.Parent.Parent.Right;
            }
            return node.Parent.Parent.Left;
        }

        private static TreeNode GetSibling(TreeNode node, TreeNode parent)
        {
            if (node == parent.Left)
            {
                return parent.Right;
            }
            return parent.Left;
        }

        private static NodeColor GetColor(TreeNode node)
        {
            if (node != null)
            {
                if (!node.IsRed)
                {
                    return NodeColor.BLACK;
                }
                return NodeColor.RED;
            }
            return NodeColor.BLACK;
        }

        private static void SetColor(TreeNode node, NodeColor color)
        {
            if (node != null)
            {
                node.IsRed = (color == NodeColor.RED);
            }
        }

        private static void TakeParent(TreeNode node, TreeNode newNode)
        {
            if (node.Parent == null)
            {
                if (newNode != null)
                {
                    newNode.Parent = null;
                }
                return;
            }
            if (node.Parent.Left == node)
            {
                node.Parent.Left = newNode;
                return;
            }
            if (node.Parent.Right == node)
            {
                node.Parent.Right = newNode;
                return;
            }
            throw new InvalidOperationException();
        }

        private static TreeNode RotateLeft(TreeNode node)
        {
            TreeNode right = node.Right;
            node.Right = right.Left;
            TakeParent(node, right);
            right.Left = node;
            return right;
        }

        private static TreeNode RotateRight(TreeNode node)
        {
            TreeNode left = node.Left;
            node.Left = left.Right;
            TakeParent(node, left);
            left.Right = node;
            return left;
        }

        private static TreeNode FindMinSubTree(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        private static TreeNode FindSuccessor(TreeNode node)
        {
            if (node.Right == null)
            {
                while (node.Parent != null && node.Parent.Left != node)
                {
                    node = node.Parent;
                }
                if (node.Parent != null)
                {
                    return node.Parent;
                }
                return null;
            }
            return FindMinSubTree(node.Right);
        }

        private static TreeNode DeleteNode(TreeNode node)
        {
            if (node.Right == null)
            {
                TakeParent(node, node.Left);
                return node;
            }
            if (node.Left == null)
            {
                TakeParent(node, node.Right);
                return node;
            }
            TreeNode treeNode = FindSuccessor(node);
            node.CopyNode(treeNode);
            TakeParent(treeNode, treeNode.Right);
            return treeNode;
        }

        private TreeNode InsertNode(TreeNode node, TreeNode newNode)
        {
            if (node == null)
            {
                return newNode;
            }
            int num = CompareTo(newNode.Key, node.Key);
            if (num < 0)
            {
                node.Left = InsertNode(node.Left, newNode);
            }
            else
            {
                node.Right = InsertNode(node.Right, newNode);
            }
            return node;
        }

        private TreeNode FindItem(TreeNode node, object key)
        {
            if (node == null)
            {
                return null;
            }
            int num = CompareTo(key, node.Key);
            if (num == 0)
            {
                return node;
            }
            if (num < 0)
            {
                return FindItem(node.Left, key);
            }
            return FindItem(node.Right, key);
        }

        private TreeNode FindRoot(TreeNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
        }

        private void FixUpInsertion(TreeNode node)
        {
            FixInsertCase1(node);
        }

        private void FixInsertCase1(TreeNode node)
        {
            if (node.Parent == null)
            {
                node.IsRed = false;
            }
            else
            {
                FixInsertCase2(node);
            }
        }

        private void FixInsertCase2(TreeNode node)
        {
            if (GetColor(node.Parent) != 0)
            {
                TreeNode uncle = GetUncle(node);
                if (GetColor(uncle) == NodeColor.RED)
                {
                    SetColor(node.Parent, NodeColor.BLACK);
                    SetColor(uncle, NodeColor.BLACK);
                    SetColor(node.Parent.Parent, NodeColor.RED);
                    FixInsertCase1(node.Parent.Parent);
                }
                else
                {
                    FixInsertCase3(node);
                }
            }
        }

        private void FixInsertCase3(TreeNode node)
        {
            if (node == node.Parent.Right && node.Parent == node.Parent.Parent.Left)
            {
                RotateLeft(node.Parent);
                node = node.Left;
            }
            else if (node == node.Parent.Left && node.Parent == node.Parent.Parent.Right)
            {
                RotateRight(node.Parent);
                node = node.Right;
            }
            FixInsertCase4(node);
        }

        private void FixInsertCase4(TreeNode node)
        {
            SetColor(node.Parent, NodeColor.BLACK);
            SetColor(node.Parent.Parent, NodeColor.RED);
            if (node == node.Parent.Left)
            {
                RotateRight(node.Parent.Parent);
            }
            else
            {
                RotateLeft(node.Parent.Parent);
            }
        }

        private static void FixUpRemoval(TreeNode node)
        {
            TreeNode node2 = (node.Left == null) ? node.Right : node.Left;
            if (GetColor(node) == NodeColor.BLACK)
            {
                if (GetColor(node2) == NodeColor.RED)
                {
                    SetColor(node2, NodeColor.BLACK);
                }
                else if (node.Parent != null)
                {
                    FixRemovalCase2(GetSibling(node2, node.Parent));
                }
            }
        }

        private static void FixRemovalCase1(TreeNode node)
        {
            if (node.Parent != null)
            {
                FixRemovalCase2(GetSibling(node, node.Parent));
            }
        }

        private static void FixRemovalCase2(TreeNode sibling)
        {
            if (GetColor(sibling) == NodeColor.RED)
            {
                TreeNode parent = sibling.Parent;
                SetColor(parent, NodeColor.RED);
                SetColor(sibling, NodeColor.BLACK);
                if (sibling == parent.Right)
                {
                    RotateLeft(sibling.Parent);
                    sibling = parent.Right;
                }
                else
                {
                    RotateRight(sibling.Parent);
                    sibling = parent.Left;
                }
            }
            FixRemovalCase3(sibling);
        }

        private static void FixRemovalCase3(TreeNode sibling)
        {
            if (GetColor(sibling.Parent) == NodeColor.BLACK && GetColor(sibling) == NodeColor.BLACK && GetColor(sibling.Left) == NodeColor.BLACK && GetColor(sibling.Right) == NodeColor.BLACK)
            {
                SetColor(sibling, NodeColor.RED);
                FixRemovalCase1(sibling.Parent);
            }
            else
            {
                FixRemovalCase4(sibling);
            }
        }

        private static void FixRemovalCase4(TreeNode sibling)
        {
            if (GetColor(sibling.Parent) == NodeColor.RED && GetColor(sibling) == NodeColor.BLACK && GetColor(sibling.Left) == NodeColor.BLACK && GetColor(sibling.Right) == NodeColor.BLACK)
            {
                SetColor(sibling, NodeColor.RED);
                SetColor(sibling.Parent, NodeColor.BLACK);
            }
            else
            {
                FixRemovalCase5(sibling);
            }
        }

        private static void FixRemovalCase5(TreeNode sibling)
        {
            if (sibling == sibling.Parent.Right && GetColor(sibling) == NodeColor.BLACK && GetColor(sibling.Left) == NodeColor.RED && GetColor(sibling.Right) == NodeColor.BLACK)
            {
                SetColor(sibling, NodeColor.RED);
                SetColor(sibling.Left, NodeColor.BLACK);
                RotateRight(sibling);
                sibling = sibling.Parent;
            }
            else if (sibling == sibling.Parent.Left && GetColor(sibling) == NodeColor.BLACK && GetColor(sibling.Right) == NodeColor.RED && GetColor(sibling.Left) == NodeColor.BLACK)
            {
                SetColor(sibling, NodeColor.RED);
                SetColor(sibling.Right, NodeColor.BLACK);
                RotateLeft(sibling);
                sibling = sibling.Parent;
            }
            FixRemovalCase6(sibling);
        }

        private static void FixRemovalCase6(TreeNode sibling)
        {
            SetColor(sibling, GetColor(sibling.Parent));
            SetColor(sibling.Parent, NodeColor.BLACK);
            if (sibling == sibling.Parent.Right)
            {
                SetColor(sibling.Right, NodeColor.BLACK);
                RotateLeft(sibling.Parent);
            }
            else
            {
                SetColor(sibling.Left, NodeColor.BLACK);
                RotateRight(sibling.Parent);
            }
        }
    }
}