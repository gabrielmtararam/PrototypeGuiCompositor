using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    public interface ICanvasContentControl
    {
         UserControl CanvasUserControl { get; set; }
       //  bool isSelected{ get; set; }
        // int Width { get; set; }
        // int Height { get; set; }
        // Point Position { get; set; }
        // int Rotation { get; set; }
        // void Move();
        // void Rotate();
        // void Resize();

    }
}
