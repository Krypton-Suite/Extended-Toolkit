using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    /// <summary>
    /// Collection of Hints.
    /// This is temporary buffer for currently displayed hints.
    /// </summary>
    public class Hints : ICollection<Hint>, IDisposable
    {
        FastColouredTextBox tb;
        List<Hint> items = new List<Hint>();

        public Hints(FastColouredTextBox tb)
        {
            this.tb = tb;
            tb.TextChanged += OnTextBoxTextChanged;
            tb.KeyDown += OnTextBoxKeyDown;
            tb.VisibleRangeChanged += OnTextBoxVisibleRangeChanged;
        }

        protected virtual void OnTextBoxKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Escape && e.Modifiers == System.Windows.Forms.Keys.None)
                Clear();
        }

        protected virtual void OnTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            Clear();
        }

        public void Dispose()
        {
            tb.TextChanged -= OnTextBoxTextChanged;
            tb.KeyDown -= OnTextBoxKeyDown;
            tb.VisibleRangeChanged -= OnTextBoxVisibleRangeChanged;
        }

        void OnTextBoxVisibleRangeChanged(object sender, EventArgs e)
        {
            if (items.Count == 0)
                return;

            tb.NeedRecalc(true);
            foreach (var item in items)
            {
                LayoutHint(item);
                item.HostPanel.Invalidate();
            }
        }

        private void LayoutHint(Hint hint)
        {
            if (hint.Inline)
            {
                if (hint.Range.Start.iLine < tb.LineInfos.Count - 1)
                    hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
                else
                    hint.HostPanel.Top = tb.TextHeight + tb.Paddings.Top - hint.HostPanel.Height - tb.VerticalScroll.Value;
            }
            else
            {
                if (hint.Range.Start.iLine > tb.LinesCount - 1) return;
                if (hint.Range.Start.iLine == tb.LinesCount - 1)
                {
                    var y = tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value + tb.CharHeight;

                    if (y + hint.HostPanel.Height + 1 > tb.ClientRectangle.Bottom)
                    {
                        hint.HostPanel.Top = Math.Max(0, tb.LineInfos[hint.Range.Start.iLine].startY - tb.VerticalScroll.Value - hint.HostPanel.Height);
                    }
                    else
                        hint.HostPanel.Top = y;

                }
                else
                {
                    hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.VerticalScroll.Value;
                    if (hint.HostPanel.Bottom > tb.ClientRectangle.Bottom)
                        hint.HostPanel.Top = tb.LineInfos[hint.Range.Start.iLine + 1].startY - tb.CharHeight - hint.TopPadding - hint.HostPanel.Height - tb.VerticalScroll.Value;
                }
            }

            if (hint.Dock == DockStyle.Fill)
            {
                hint.Width = tb.ClientSize.Width - tb.LeftIndent - 2;
                hint.HostPanel.Left = tb.LeftIndent;
            }
            else
            {
                var p1 = tb.PlaceToPoint(hint.Range.Start);
                var p2 = tb.PlaceToPoint(hint.Range.End);
                var cx = (p1.X + p2.X) / 2;
                var x = cx - hint.HostPanel.Width / 2;
                hint.HostPanel.Left = Math.Max(tb.LeftIndent, x);
                if (hint.HostPanel.Right > tb.ClientSize.Width)
                    hint.HostPanel.Left = Math.Max(tb.LeftIndent, x - (hint.HostPanel.Right - tb.ClientSize.Width));
            }
        }

        public IEnumerator<Hint> GetEnumerator()
        {
            foreach (var item in items)
                yield return item;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Clears all displayed hints
        /// </summary>
        public void Clear()
        {
            items.Clear();
            if (tb.Controls.Count != 0)
            {
                var toDelete = new List<Control>();
                foreach (Control item in tb.Controls)
                    if (item is UnfocusablePanel)
                        toDelete.Add(item);

                foreach (var item in toDelete)
                    tb.Controls.Remove(item);

                for (int i = 0; i < tb.LineInfos.Count; i++)
                {
                    var li = tb.LineInfos[i];
                    li.bottomPadding = 0;
                    tb.LineInfos[i] = li;
                }
                tb.NeedRecalc();
                tb.Invalidate();
                tb.Select();
                tb.ActiveControl = null;
            }
        }

        /// <summary>
        /// Add and shows the hint
        /// </summary>
        /// <param name="hint"></param>
        public void Add(Hint hint)
        {
            items.Add(hint);

            if (hint.Inline/* || hint.Range.Start.iLine >= tb.LinesCount - 1*/)
            {
                var li = tb.LineInfos[hint.Range.Start.iLine];
                hint.TopPadding = li.bottomPadding;
                li.bottomPadding += hint.HostPanel.Height;
                tb.LineInfos[hint.Range.Start.iLine] = li;
                tb.NeedRecalc(true);
            }

            LayoutHint(hint);

            tb.OnVisibleRangeChanged();

            hint.HostPanel.Parent = tb;

            tb.Select();
            tb.ActiveControl = null;
            tb.Invalidate();
        }

        /// <summary>
        /// Is collection contains the hint?
        /// </summary>
        public bool Contains(Hint item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Hint[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Count of hints
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Hint item)
        {
            throw new NotImplementedException();
        }
    }
}