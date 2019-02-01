using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    class ImageElement :  ICanvasContentControl

    {
        //public Control Control { get; set; }
        //public double LeftOffset { get; set; }
        //public double TopOffset { get; set; }
        //public double Width { get; set; }
        //public  double Height { get; set; }
        //public  double Rotation { get; set; }

        public UserControl CanvasUserControl { get; set; }

        //public  string _name;

        public ImageElement( )
        {

            CanvasUserControl = new CanvasContentControl();
            //(CanvasUserControl as CanvasContentControl).Content2= 
           
            //_name = name;
            //Height = height;
            //Width = width;
            //Rotation = rotation;
            //LeftOffset = leftOffset;
            //TopOffset = topOffset;
            //Control = new Button() as Control;

        }
    }
}
