﻿namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>Specifies the input box icon type.</summary>
    public enum InputBoxIconType
    {
        /// <summary>No icon.</summary>
        NONE = 0,
        /// <summary>Specifies a custom icon.</summary>
        CUSTOM = 1,
        /// <summary>Specifies the critical icon.</summary>
        CRITICAL = 2,
        /// <summary>Specifies a hand icon.</summary>
        HAND = 3,
        /// <summary>Specifies a information icon.</summary>
        INFORMATION = 4,
        /// <summary>Specifies a ok icon.</summary>
        OK = 5,
        /// <summary>Specifies a question icon.</summary>
        QUESTION = 6,
        /// <summary>Specifies a stop icon.</summary>
        STOP = 7,
        ERROR = 8,
        /// <summary>Specifies a warning icon.</summary>
        EXCLAMATION = 9
    }

    public enum InputBoxIconImageSize
    {
        CUSTOM = 0,
        THIRTYTWO = 1,
        FOURTYEIGHT = 2,
        SIXTYFOUR = 3,
        ONEHUNDREDANDTWENTYEIGHT = 4
    }

    public enum InputBoxInputType
    {
        COMBOBOX,
        TEXTBOX,
        MASKEDTEXTBOX,
        NONE
    }

    public enum InputBoxButtons
    {
        OK,
        OKCANCEL,
        YESNO,
        YESNOCANCEL
    }

    public enum InputBoxLanguage
    {
        CZECH,
        ENGLISH,
        FRENCH,
        GERMAN,
        SLOVAKIAN,
        SPANISH,
        CUSTOM
    }

    public enum InputBoxTextAlignment
    {
        LEFT,
        CENTRE,
        RIGHT
    }

    public enum InputBoxNormalMessageTextAlignment
    {
        INHERIT,
        NEARNEAR,
        NEARCENTRE,
        NEARFAR,
        CENTRENEAR,
        CENTRECENTRE,
        CENTREFAR,
        FARNEAR,
        FARCENTRE,
        FARFAR,
        INHERITNEAR,
        INHERITCENTRE,
        INHERITFAR,
        NEARINHERIT,
        CENTREINHERIT,
        FARINHERIT
    }

    public enum InputBoxWrappedMessageTextAlignment
    {
        TOPLEFT,
        TOPCENTRE,
        TOPRIGHT,
        MIDDLELEFT,
        MIDDLECENTRE,
        MIDDLERIGHT,
        BOTTOMLEFT,
        BOTTOMCENTRE,
        BOTTOMRIGHT
    }

    public enum InputBoxMessageDisplayType
    {
        LABEL = 0,
        BORDEREDLABEL = 1,
        WRAPPEDLABEL = 2
    }
}