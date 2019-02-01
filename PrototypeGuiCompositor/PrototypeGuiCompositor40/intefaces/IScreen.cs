using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PrototypeGuiCompositor30
{
    public interface IScreen
    {
        UIElement Screen { get; set; }
        List<ICanvasContentControl> elements{get; set;}
         string Name { get; set; }
    }
}
