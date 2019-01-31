using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PrototypeGuiCompositor30
{
   public class DefaultScreen:IScreen
    {
       public UIElement Screen { get; set; }
       public List<ICanvasContentControl> elements { get; set; }
       public string Name { get; set; }
         public DefaultScreen()
        {
            this.Screen = new Canvas();
            (this.Screen as Canvas).Background = new SolidColorBrush(Colors.Blue);

            this.elements = new List<ICanvasContentControl>();
        }
    }
}
