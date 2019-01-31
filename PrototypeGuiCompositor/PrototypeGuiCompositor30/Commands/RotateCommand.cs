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
    class RotateCommand:ICommand
    {

        FrameworkElement _element;
        RotateTransform _nextRotateTransform;
        RotateTransform _oldRotateTransform;
     
        public RotateCommand(FrameworkElement element, RotateTransform nextRotateTransform, RotateTransform oldRotateTransform)
        {
            _element = element;
            _nextRotateTransform = nextRotateTransform;
            _oldRotateTransform = oldRotateTransform;
            Execute();
        }
        public void Execute()
        {

            _element.RenderTransform = _nextRotateTransform;
        }
        public void Undo()
        {

            _element.RenderTransform = _oldRotateTransform;

        }
        public void Redo()
        {
            Execute();
        }

    }
}
