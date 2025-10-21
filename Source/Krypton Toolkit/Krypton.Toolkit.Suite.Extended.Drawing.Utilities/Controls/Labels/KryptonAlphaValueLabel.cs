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

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

public class KryptonAlphaValueLabel : KryptonLabel
{
    #region Variables
    private bool _showCurrentColourValue, _showColon;

    private Font _textSize;

    private int _value;

    private string _extraText;
    #endregion

    #region Properties

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowCurrentColourValue
    {
        get => _showCurrentColourValue;

        set
        {
            _showCurrentColourValue = value;
                
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowColon
    {
        get => _showColon;
            
        set
        {
            _showColon = value; 
                
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Font Typeface
    {
        get => _textSize;

        set
        {
            _textSize = value;
                
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int AlphaValue
    {
        get => _value;

        set
        {
            _value = value;
                
            Invalidate();
        }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string ExtraText
    {
        get => _extraText;

        set
        {
            _extraText = value;
                
            Invalidate();
        }
    }
    #endregion

    #region Constructor
    public KryptonAlphaValueLabel()
    {
        Typeface = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold);

        AlphaValue = 0;

        ExtraText = "Alpha Value";

        ShowColon = false;
    }
    #endregion

    #region Methods
    private void ShowCurrentColourValueOnLabel(bool value, string text = "Alpha Value", bool showColon = false)
    {
        if (value)
        {
            Text = $"{text}: {AlphaValue}";
        }
        else if (_showColon)
        {
            Text = $"{text}";
        }
        else
        {
            Text = $"{text}:";
        }
    }

    private void AlterLabelTypeface(Font typeface)
    {
        StateCommon.LongText.Font = typeface;

        StateCommon.ShortText.Font = typeface;
    }
    #endregion

    #region Overrides
    protected override void OnPaint(PaintEventArgs? e)
    {
        string tmpText = Text;

        ShowCurrentColourValueOnLabel(_showCurrentColourValue, _extraText, _showColon);

        AlterLabelTypeface(_textSize);

        if (ShowColon)
        {
            if (!tmpText.EndsWith(":"))
            {
                Text = $"{tmpText}:";
            }
        }
        else
        {

        }

        base.OnPaint(e);
    }
    #endregion
}