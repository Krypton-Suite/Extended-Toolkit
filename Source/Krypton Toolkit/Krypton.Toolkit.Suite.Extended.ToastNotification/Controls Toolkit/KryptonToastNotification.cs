using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.ToastNotification
{
    public class KryptonToastNotification
    {
        public static void ShowBasicToastNotification(KryptonBasicToastNotificationData data) =>
            VisualToastNotificationBasicForm.InternalShow(data);

        public static void ShowBasicProgressBarNotification(KryptonBasicToastNotificationData data)
        {
            VisualToastNotificationBasicPBForm.InternalShow(data);
        }
    }
}
