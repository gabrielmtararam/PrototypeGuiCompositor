using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeGuiCompositor30
{
    public static class ProgramManager
    {
        public static List<IScreen> screens;
        public static int activeScreen;
        public static void InitializeProgram()
        {
            screens = ScreensFactory.LoadScreenList();
            activeScreen = 0;
        }

    }
}
