using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Provides data for TaskMouseEvent
    /// </summary>
    public class TaskMouseEventArgs : MouseEventArgs
    {
        /// <summary>
        /// Subject Task of the event
        /// </summary>
        public Task Task { get; private set; }
       
        /// <summary>
        /// Rectangle bounds of the Task
        /// </summary>
        public RectangleF Rectangle { get; private set; }
       
        /// <summary>
        /// Initialize a new instance of TaskMouseEventArgs with the MouseEventArgs parameters and the Task involved.
        /// </summary>
        public TaskMouseEventArgs(Task task, RectangleF rectangle, MouseButtons buttons, int clicks, int x, int y, int delta) : base(buttons, clicks, x, y, delta)
        {
            Task = task;
            
            Rectangle = rectangle;
        }
    }
}