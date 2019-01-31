using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    public static class ControlsFactory
    {
        public static Button LoadDefaultButton()
        {
            Button button = new Button();
            button.MinHeight = 40;
            button.MinWidth = 40;
            return button;
        }
    }
}
