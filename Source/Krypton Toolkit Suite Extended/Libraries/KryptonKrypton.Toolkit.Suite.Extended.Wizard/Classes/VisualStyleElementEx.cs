#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Identifies a control or user interface (UI) element that is drawn with visual styles.
    /// </summary>
    public static class VisualStyleElementEx
    {
        /// <summary>
        /// Contains classes that provide <see cref="VisualStyleElement"/> objects for navigation-related controls. This class cannot be inherited.
        /// </summary>
        public static class Navigation
        {
            private const string className = "NAVIGATION";

            /// <summary>
            /// Provides <see cref="VisualStyleElement"/> objects for the different states of the Back Button control. This class cannot be inherited. 
            /// </summary>
            public static class BackButton
            {
                private const int part = 1;

                /// <summary>Gets a visual style element that represents a back button in the normal state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a back button in the normal state.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, part, 1);
                /// <summary>Gets a visual style element that represents a back button in the hot state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a back button in the hot state.</value>
                public static VisualStyleElement Hot => VisualStyleElement.CreateElement(className, part, 2);
                /// <summary>Gets a visual style element that represents a back button in the pressed state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a back button in the pressed state.</value>
                public static VisualStyleElement Pressed => VisualStyleElement.CreateElement(className, part, 3);
                /// <summary>Gets a visual style element that represents a back button in the disabled state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a back button in the disabled state.</value>
                public static VisualStyleElement Disabled => VisualStyleElement.CreateElement(className, part, 4);
            }

            /// <summary>
            /// Provides <see cref="VisualStyleElement"/> objects for the different states of the Forward Button control. This class cannot be inherited. 
            /// </summary>
            public static class ForwardButton
            {
                private const int part = 2;

                /// <summary>Gets a visual style element that represents a forward button in the normal state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a forward button in the normal state.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, part, 1);
                /// <summary>Gets a visual style element that represents a forward button in the hot state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a forward button in the hot state.</value>
                public static VisualStyleElement Hot => VisualStyleElement.CreateElement(className, part, 2);
                /// <summary>Gets a visual style element that represents a forward button in the pressed state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a forward button in the pressed state.</value>
                public static VisualStyleElement Pressed => VisualStyleElement.CreateElement(className, part, 3);
                /// <summary>Gets a visual style element that represents a forward button in the disabled state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a forward button in the disabled state.</value>
                public static VisualStyleElement Disabled => VisualStyleElement.CreateElement(className, part, 4);
            }

            /// <summary>
            /// Provides <see cref="VisualStyleElement"/> objects for the different states of the Menu Button control. This class cannot be inherited. 
            /// </summary>
            public static class MenuButton
            {
                private const int part = 3;

                /// <summary>Gets a visual style element that represents a menu button in the normal state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a menu button in the normal state.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, part, 1);
                /// <summary>Gets a visual style element that represents a menu button in the hot state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a menu button in the hot state.</value>
                public static VisualStyleElement Hot => VisualStyleElement.CreateElement(className, part, 2);
                /// <summary>Gets a visual style element that represents a menu button in the pressed state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a menu button in the pressed state.</value>
                public static VisualStyleElement Pressed => VisualStyleElement.CreateElement(className, part, 3);
                /// <summary>Gets a visual style element that represents a menu button in the disabled state.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a menu button in the disabled state.</value>
                public static VisualStyleElement Disabled => VisualStyleElement.CreateElement(className, part, 4);
            }
        }

        /// <summary>
        /// Contains classes that provide <see cref="VisualStyleElement"/> objects for AeroWizard-related controls. This class cannot be inherited.
        /// </summary>
        public static class AeroWizard
        {
            private const string className = "AEROWIZARD";

            /// <summary>
            /// Provides a <see cref="VisualStyleElement"/> for the button of a wizard. This class cannot be inherited.
            /// </summary>
            public static class Button
            {
                /// <summary>Gets a visual style element that represents a button in a wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents a button in a wizard.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, 5, 0);
            }

            /// <summary>
            /// Provides a <see cref="VisualStyleElement"/> for the command area of a wizard. This class cannot be inherited.
            /// </summary>
            public static class CommandArea
            {
                /// <summary>Gets a visual style element that represents the command area of a wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the command area of a wizard.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, 4, 0);
            }

            /// <summary>
            /// Provides a <see cref="VisualStyleElement"/> for the content area of a wizard. This class cannot be inherited.
            /// </summary>
            public static class ContentArea
            {
                /// <summary>Gets a visual style element that represents the content area of a wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the content area of a wizard.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, 3, 0);
                /// <summary>Gets a visual style element that represents the content area of a wizard without a margin.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the content area of a wizard without a margin.</value>
                public static VisualStyleElement NoMargin => VisualStyleElement.CreateElement(className, 3, 1);
            }

            /// <summary>
            /// Provides a <see cref="VisualStyleElement"/> for the header area of a wizard. This class cannot be inherited.
            /// </summary>
            public static class HeaderArea
            {
                /// <summary>Gets a visual style element that represents the header area of a wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the header area of a wizard.</value>
                public static VisualStyleElement Normal => VisualStyleElement.CreateElement(className, 2, 0);
                /// <summary>Gets a visual style element that represents the header area of a wizard without a margin.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the header area of a wizard without a margin.</value>
                public static VisualStyleElement NoMargin => VisualStyleElement.CreateElement(className, 2, 1);
            }

            /// <summary>
            /// Provides a <see cref="VisualStyleElement"/> for each state of the titlebar of a wizard. This class cannot be inherited.
            /// </summary>
            public static class TitleBar
            {
                /// <summary>Gets a visual style element that represents the titlebar of an active wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the titlebar of an active wizard.</value>
                public static VisualStyleElement Active => VisualStyleElement.CreateElement(className, 1, 1);
                /// <summary>Gets a visual style element that represents the titlebar of an inactive wizard.</summary>
                /// <value>A <see cref="VisualStyleElement"/> that represents the titlebar of an inactive wizard.</value>
                public static VisualStyleElement Inactive => VisualStyleElement.CreateElement(className, 1, 2);
            }
        }
    }
}