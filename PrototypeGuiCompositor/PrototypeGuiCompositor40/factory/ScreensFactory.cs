using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30
{
    public static class ScreensFactory
    {
        public static List<IScreen> LoadScreenList()
        {
            List<IScreen> screens = new List<IScreen>();
            screens.Add(new DefaultScreen());
            return screens;
        }
    }
}
