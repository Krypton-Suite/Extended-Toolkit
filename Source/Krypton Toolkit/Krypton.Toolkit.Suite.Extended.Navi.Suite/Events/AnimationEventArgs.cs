#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class AnimationEventArgs : EventArgs
    {
        #region Fields

        Dictionary<string, int> animatables;
        Graphics graphics;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the AnimationEventArgs class
        /// </summary>
        public AnimationEventArgs()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AnimationEventArgs class
        /// </summary>
        /// <param name="graphics"></param>
        public AnimationEventArgs(Graphics graphics)
           : this()
        {
            this.graphics = graphics;
        }

        /// <summary>
        /// Initializes a new instance of the AnimationEventArgs class
        /// </summary>
        /// <param name="graphics"></param>
        public AnimationEventArgs(Graphics graphics, Dictionary<string, int> animatables)
           : this(graphics)
        {
            this.animatables = animatables;
        }

        #endregion

        #region Properties

        public Dictionary<string, int> Animatables
        {
            get { return animatables; }
        }

        public Graphics Graphics
        {
            get { return graphics; }
        }

        #endregion

    }

    public delegate void AnimationEventHandler(object sender, AnimationEventArgs e);
}