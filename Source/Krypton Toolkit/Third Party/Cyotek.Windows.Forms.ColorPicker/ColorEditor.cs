using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Cyotek.Windows.Forms
{
  // Cyotek Color Picker controls library
  // Copyright © 2013-2017 Cyotek Ltd.
  // http://cyotek.com/blog/tag/colorpicker

  // Licensed under the MIT License. See license.txt for the full text.

  // If you use this code in your applications, donations or attribution are welcome

  /// <summary>
  /// Represents a control that allows the editing of a color in a variety of ways.
  /// </summary>
  [DefaultProperty("Color")]
  [DefaultEvent("ColorChanged")]
  public partial class ColorEditor : UserControl, IColorEditor
  {
    #region Constants

    private static readonly object _eventColorChanged = new object();

    private static readonly object _eventOrientationChanged = new object();

    private static readonly object _eventShowAlphaChannelChanged = new object();

    private static readonly object _eventShowColorSpaceLabelsChanged = new object();

    private const int _minimumBarWidth = 30;

    #endregion

    #region Fields

    private Color _color;

    private HslColor _hslColor;

    private Orientation _orientation;

    private bool _showAlphaChannel;

    private bool _showColorSpaceLabels;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorEditor"/> class.
    /// </summary>
    public ColorEditor()
    {
      this.InitializeComponent();

      _color = Color.Black;
      _orientation = Orientation.Vertical;
      this.Size = new Size(200, 260);
      _showAlphaChannel = true;
      _showColorSpaceLabels = true;
    }

    #endregion

    #region Events

    [Category("Property Changed")]
    public event EventHandler OrientationChanged
    {
      add { this.Events.AddHandler(_eventOrientationChanged, value); }
      remove { this.Events.RemoveHandler(_eventOrientationChanged, value); }
    }

    [Category("Property Changed")]
    public event EventHandler ShowAlphaChannelChanged
    {
      add { this.Events.AddHandler(_eventShowAlphaChannelChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowAlphaChannelChanged, value); }
    }

    /// <summary>
    /// Occurs when the ShowColorSpaceLabels property value changes
    /// </summary>
    [Category("Property Changed")]
    public event EventHandler ShowColorSpaceLabelsChanged
    {
      add { this.Events.AddHandler(_eventShowColorSpaceLabelsChanged, value); }
      remove { this.Events.RemoveHandler(_eventShowColorSpaceLabelsChanged, value); }
    }

    #endregion

    #region Properties

    /// <summary>
    /// Gets or sets the component color as a HSL structure.
    /// </summary>
    /// <value>The component color.</value>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual HslColor HslColor
    {
      get { return _hslColor; }
      set
      {
        if (this.HslColor != value)
        {
          _hslColor = value;

          if (!this.LockUpdates)
          {
            this.LockUpdates = true;
            this.Color = value.ToRgbColor();
            this.LockUpdates = false;
            this.UpdateFields(false);
          }
          else
          {
            this.OnColorChanged(EventArgs.Empty);
          }
        }
      }
    }

    /// <summary>
    /// Gets or sets the orientation of the editor.
    /// </summary>
    /// <value>The orientation.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Orientation), "Vertical")]
    public virtual Orientation Orientation
    {
      get { return _orientation; }
      set
      {
        if (this.Orientation != value)
        {
          _orientation = value;

          this.OnOrientationChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Behavior")]
    [DefaultValue(true)]
    public virtual bool ShowAlphaChannel
    {
      get { return _showAlphaChannel; }
      set
      {
        if (_showAlphaChannel != value)
        {
          _showAlphaChannel = value;

          this.OnShowAlphaChannelChanged(EventArgs.Empty);
        }
      }
    }

    [Category("Appearance")]
    [DefaultValue(true)]
    public bool ShowColorSpaceLabels
    {
      get { return _showColorSpaceLabels; }
      set
      {
        if (_showColorSpaceLabels != value)
        {
          _showColorSpaceLabels = value;

          this.OnShowColorSpaceLabelsChanged(EventArgs.Empty);
        }
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether input changes should be processed.
    /// </summary>
    /// <value><c>true</c> if input changes should be processed; otherwise, <c>false</c>.</value>
    protected bool LockUpdates { get; set; }

    #endregion

    #region Methods

    /// <summary>
    /// Raises the <see cref="ColorChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnColorChanged(EventArgs e)
    {
      EventHandler handler;

      this.UpdateFields(false);

      handler = (EventHandler)this.Events[_eventColorChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.DockChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnDockChanged(EventArgs e)
    {
      base.OnDockChanged(e);

      this.ResizeComponents();
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);

      this.SetDropDownWidth();
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="OrientationChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnOrientationChanged(EventArgs e)
    {
      EventHandler handler;

      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventOrientationChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="E:System.Windows.Forms.Control.PaddingChanged" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnPaddingChanged(EventArgs e)
    {
      base.OnPaddingChanged(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="E:Resize" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);

      this.ResizeComponents();
    }

    /// <summary>
    /// Raises the <see cref="ShowAlphaChannelChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowAlphaChannelChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowAlphaChannelChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Raises the <see cref="ShowColorSpaceLabelsChanged" /> event.
    /// </summary>
    /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
    protected virtual void OnShowColorSpaceLabelsChanged(EventArgs e)
    {
      EventHandler handler;

      this.SetControlStates();
      this.ResizeComponents();

      handler = (EventHandler)this.Events[_eventShowColorSpaceLabelsChanged];

      handler?.Invoke(this, e);
    }

    /// <summary>
    /// Resizes the editing components.
    /// </summary>
    protected virtual void ResizeComponents()
    {
      try
      {
        int group1HeaderLeft;
        int group1BarLeft;
        int group1EditLeft;
        int group2HeaderLeft;
        int group2BarLeft;
        int group2EditLeft;
        int barWidth;
        int editWidth;
        int top;
        int innerMargin;
        int columnWidth;
        int rowHeight;
        int labelOffset;
        int colorBarOffset;
        int editOffset;
        int barHorizontalOffset;

        top = this.Padding.Top;
        innerMargin = 3;
        editWidth = TextRenderer.MeasureText("0000W", this.Font).Width + 6; // magic 6 for interior spacing+borders
        rowHeight = Math.Max(Math.Max(rLabel.Height, rColorBar.Height), rNumericUpDown.Height);
        labelOffset = (rowHeight - rLabel.Height) >> 1;
        colorBarOffset = (rowHeight - rColorBar.Height) >> 1;
        editOffset = (rowHeight - rNumericUpDown.Height) >> 1;
        barHorizontalOffset = _showAlphaChannel ? aLabel.Width : hLabel.Width;

        switch (this.Orientation)
        {
          case Orientation.Horizontal:
            columnWidth = (this.ClientSize.Width - (this.Padding.Horizontal + innerMargin)) >> 1;
            break;
          default:
            columnWidth = this.ClientSize.Width - this.Padding.Horizontal;
            break;
        }

        group1HeaderLeft = this.Padding.Left;
        group1EditLeft = columnWidth - editWidth;
        group1BarLeft = group1HeaderLeft + barHorizontalOffset + innerMargin;

        if (this.Orientation == Orientation.Horizontal)
        {
          group2HeaderLeft = this.Padding.Left + columnWidth + innerMargin;
          group2EditLeft = this.ClientSize.Width - (this.Padding.Right + editWidth);
          group2BarLeft = group2HeaderLeft + barHorizontalOffset + innerMargin;
        }
        else
        {
          group2HeaderLeft = group1HeaderLeft;
          group2EditLeft = group1EditLeft;
          group2BarLeft = group1BarLeft;
        }

        barWidth = group1EditLeft - (group1BarLeft + innerMargin);

        this.SetBarStates(barWidth >= _minimumBarWidth);

        // RGB header
        if (_showColorSpaceLabels)
        {
          rgbHeaderLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          top += rowHeight + innerMargin;
        }

        // R row
        rLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        rColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        rNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // G row
        gLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        gColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        gNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // B row
        bLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        bColorBar.SetBounds(group1BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        bNumericUpDown.SetBounds(group1EditLeft + editOffset, top, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // Hex row
        hexLabel.SetBounds(group1HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        hexTextBox.SetBounds(hexLabel.Right + innerMargin, top + colorBarOffset, barWidth + editOffset + editWidth - (hexLabel.Right - group1BarLeft), 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // reset top
        if (this.Orientation == Orientation.Horizontal)
        {
          top = this.Padding.Top;
        }

        // HSL header
        if (_showColorSpaceLabels)
        {
          hslLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
          top += rowHeight + innerMargin;
        }

        // H row
        hLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        hColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        hNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // S row
        sLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        sColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        sNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // L row
        lLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        lColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        lNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        top += rowHeight + innerMargin;

        // A row
        aLabel.SetBounds(group2HeaderLeft, top + labelOffset, 0, 0, BoundsSpecified.Location);
        aColorBar.SetBounds(group2BarLeft, top + colorBarOffset, barWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
        aNumericUpDown.SetBounds(group2EditLeft, top + editOffset, editWidth, 0, BoundsSpecified.Location | BoundsSpecified.Width);
      }
      // ReSharper disable EmptyGeneralCatchClause
      catch
      // ReSharper restore EmptyGeneralCatchClause
      {
        // ignore errors
      }
    }

    /// <summary>
    /// Updates the editing field values.
    /// </summary>
    /// <param name="userAction">if set to <c>true</c> the update is due to user interaction.</param>
    protected virtual void UpdateFields(bool userAction)
    {
      if (!this.LockUpdates)
      {
        try
        {
          this.LockUpdates = true;

          // RGB
          if (!(userAction && rNumericUpDown.Focused))
          {
            rNumericUpDown.Value = this.Color.R;
          }
          if (!(userAction && gNumericUpDown.Focused))
          {
            gNumericUpDown.Value = this.Color.G;
          }
          if (!(userAction && bNumericUpDown.Focused))
          {
            bNumericUpDown.Value = this.Color.B;
          }
          rColorBar.Value = this.Color.R;
          rColorBar.Color = this.Color;
          gColorBar.Value = this.Color.G;
          gColorBar.Color = this.Color;
          bColorBar.Value = this.Color.B;
          bColorBar.Color = this.Color;

          // HTML
          if (!(userAction && hexTextBox.Focused))
          {
            hexTextBox.Text = this.Color.IsNamedColor ? this.Color.Name : string.Format("{0:X2}{1:X2}{2:X2}", this.Color.R, this.Color.G, this.Color.B);
          }

          // HSL
          if (!(userAction && hNumericUpDown.Focused))
          {
            hNumericUpDown.Value = (int)this.HslColor.H;
          }
          if (!(userAction && sNumericUpDown.Focused))
          {
            sNumericUpDown.Value = (int)(this.HslColor.S * 100);
          }
          if (!(userAction && lNumericUpDown.Focused))
          {
            lNumericUpDown.Value = (int)(this.HslColor.L * 100);
          }
          hColorBar.Value = (int)this.HslColor.H;
          sColorBar.Color = this.Color;
          sColorBar.Value = (int)(this.HslColor.S * 100);
          lColorBar.Color = this.Color;
          lColorBar.Value = (int)(this.HslColor.L * 100);

          // Alpha
          if (!(userAction && aNumericUpDown.Focused))
          {
            aNumericUpDown.Value = this.Color.A;
          }
          aColorBar.Color = this.Color;
          aColorBar.Value = this.Color.A;
        }
        finally
        {
          this.LockUpdates = false;
        }
      }
    }

    private void AddColorProperties<T>()
    {
      Type type;
      Type colorType;

      type = typeof(T);
      colorType = typeof(Color);

      // ReSharper disable once LoopCanBePartlyConvertedToQuery
      foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Static))
      {
        if (property.PropertyType == colorType)
        {
          Color color;

          color = (Color)property.GetValue(type, null);
          if (!color.IsEmpty)
          {
            hexTextBox.Items.Add(color.Name);
          }
        }
      }
    }

    private string AddSpaces(string text)
    {
      string result;

      //http://stackoverflow.com/a/272929/148962

      if (!string.IsNullOrEmpty(text))
      {
        StringBuilder newText;

        newText = new StringBuilder(text.Length * 2);
        newText.Append(text[0]);
        for (int i = 1; i < text.Length; i++)
        {
          if (char.IsUpper(text[i]) && text[i - 1] != ' ')
          {
            newText.Append(' ');
          }
          newText.Append(text[i]);
        }

        result = newText.ToString();
      }
      else
      {
        result = null;
      }

      return result;
    }

    private void FillNamedColors()
    {
      this.AddColorProperties<SystemColors>();
      this.AddColorProperties<Color>();
      this.SetDropDownWidth();
    }

    private void hexTextBox_DrawItem(object sender, DrawItemEventArgs e)
    {
      // TODO: Really, this should be another control - ColorComboBox or ColorListBox etc.

      if (e.Index != -1)
      {
        Rectangle colorBox;
        string name;
        Color color;

        e.DrawBackground();

        name = (string)hexTextBox.Items[e.Index];
        color = Color.FromName(name);
        colorBox = new Rectangle(e.Bounds.Left + 1, e.Bounds.Top + 1, e.Bounds.Height - 3, e.Bounds.Height - 3);

        using (Brush brush = new SolidBrush(color))
        {
          e.Graphics.FillRectangle(brush, colorBox);
        }
        e.Graphics.DrawRectangle(SystemPens.ControlText, colorBox);

        TextRenderer.DrawText(e.Graphics, this.AddSpaces(name), this.Font, new Point(colorBox.Right + 3, colorBox.Top), e.ForeColor);

        //if (color == Color.Transparent && (e.State & DrawItemState.Selected) != DrawItemState.Selected)
        //  e.Graphics.DrawLine(SystemPens.ControlText, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);

        e.DrawFocusRectangle();
      }
    }

    private void hexTextBox_DropDown(object sender, EventArgs e)
    {
      if (hexTextBox.Items.Count == 0)
      {
        this.FillNamedColors();
      }
    }

    private void hexTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Up:
        case Keys.Down:
        case Keys.PageUp:
        case Keys.PageDown:
          if (hexTextBox.Items.Count == 0)
          {
            this.FillNamedColors();
          }
          break;
      }
    }

    private void hexTextBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (hexTextBox.SelectedIndex != -1)
      {
        this.LockUpdates = true;
        this.Color = Color.FromName((string)hexTextBox.SelectedItem);
        this.LockUpdates = false;
      }
    }

    private void SetBarStates(bool visible)
    {
      rColorBar.Visible = visible;
      gColorBar.Visible = visible;
      bColorBar.Visible = visible;
      hColorBar.Visible = visible;
      sColorBar.Visible = visible;
      lColorBar.Visible = visible;
      aColorBar.Visible = _showAlphaChannel && visible;
    }

    private void SetControlStates()
    {
      aLabel.Visible = _showAlphaChannel;
      aColorBar.Visible = _showAlphaChannel;
      aNumericUpDown.Visible = _showAlphaChannel;

      rgbHeaderLabel.Visible = _showColorSpaceLabels;
      hslLabel.Visible = _showColorSpaceLabels;
    }

    private void SetDropDownWidth()
    {
      if (hexTextBox.Items.Count != 0)
      {
        hexTextBox.DropDownWidth = hexTextBox.ItemHeight * 2 + hexTextBox.Items.Cast<string>().Max(s => TextRenderer.MeasureText(s, this.Font).Width);
      }
    }

    /// <summary>
    /// Change handler for editing components.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    private void ValueChangedHandler(object sender, EventArgs e)
    {
      if (!this.LockUpdates)
      {
        bool useHsl;
        bool useRgb;
        bool useNamed;

        useHsl = false;
        useRgb = false;
        useNamed = false;

        this.LockUpdates = true;

        if (sender == hexTextBox)
        {
          string text;
          int namedIndex;

          text = hexTextBox.Text;
          if (text.StartsWith("#"))
          {
            text = text.Substring(1);
          }

          if (hexTextBox.Items.Count == 0)
          {
            this.FillNamedColors();
          }

          namedIndex = hexTextBox.FindStringExact(text);

          if (namedIndex != -1 || text.Length == 6 || text.Length == 8)
          {
            try
            {
              Color color;

              color = namedIndex != -1 ? Color.FromName(text) : ColorTranslator.FromHtml("#" + text);
              aNumericUpDown.Value = color.A;
              rNumericUpDown.Value = color.R;
              bNumericUpDown.Value = color.B;
              gNumericUpDown.Value = color.G;

              useRgb = true;
            }
            // ReSharper disable EmptyGeneralCatchClause
            catch
            { }
            // ReSharper restore EmptyGeneralCatchClause
          }
          else
          {
            useNamed = true;
          }
        }
        else if (sender == aColorBar || sender == rColorBar || sender == gColorBar || sender == bColorBar)
        {
          aNumericUpDown.Value = (int)aColorBar.Value;
          rNumericUpDown.Value = (int)rColorBar.Value;
          gNumericUpDown.Value = (int)gColorBar.Value;
          bNumericUpDown.Value = (int)bColorBar.Value;

          useRgb = true;
        }
        else if (sender == aNumericUpDown || sender == rNumericUpDown || sender == gNumericUpDown || sender == bNumericUpDown)
        {
          useRgb = true;
        }
        else if (sender == hColorBar || sender == lColorBar || sender == sColorBar)
        {
          hNumericUpDown.Value = (int)hColorBar.Value;
          sNumericUpDown.Value = (int)sColorBar.Value;
          lNumericUpDown.Value = (int)lColorBar.Value;

          useHsl = true;
        }
        else if (sender == hNumericUpDown || sender == sNumericUpDown || sender == lNumericUpDown)
        {
          useHsl = true;
        }

        if (useRgb || useNamed)
        {
          Color color;

          color = useNamed ? Color.FromName(hexTextBox.Text) : Color.FromArgb((int)aNumericUpDown.Value, (int)rNumericUpDown.Value, (int)gNumericUpDown.Value, (int)bNumericUpDown.Value);

          this.Color = color;
          this.HslColor = new HslColor(color);
        }
        else if (useHsl)
        {
          HslColor color;

          color = new HslColor((int)aNumericUpDown.Value, (double)hNumericUpDown.Value, (double)sNumericUpDown.Value / 100, (double)lNumericUpDown.Value / 100);
          this.HslColor = color;
          this.Color = color.ToRgbColor();
        }

        this.LockUpdates = false;
        this.UpdateFields(true);
      }
    }

    #endregion

    #region IColorEditor Interface

    [Category("Property Changed")]
    public event EventHandler ColorChanged
    {
      add { this.Events.AddHandler(_eventColorChanged, value); }
      remove { this.Events.RemoveHandler(_eventColorChanged, value); }
    }

    /// <summary>
    /// Gets or sets the component color.
    /// </summary>
    /// <value>The component color.</value>
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "0, 0, 0")]
    public virtual Color Color
    {
      get { return _color; }
      set
      {
        /*
         * If the color isn't solid, and ShowAlphaChannel is false
         * remove the alpha channel. Not sure if this is the best
         * place to do it, but it is a blanket fix for now
         */
        if (value.A != 255 && !_showAlphaChannel)
        {
          value = Color.FromArgb(255, value);
        }

        if (_color != value)
        {
          _color = value;

          if (!this.LockUpdates)
          {
            this.LockUpdates = true;
            this.HslColor = new HslColor(value);
            this.LockUpdates = false;
            this.UpdateFields(false);
          }
          else
          {
            this.OnColorChanged(EventArgs.Empty);
          }
        }
      }
    }

    #endregion
  }
}
