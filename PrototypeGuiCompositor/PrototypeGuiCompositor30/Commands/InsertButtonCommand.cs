using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PrototypeGuiCompositor30
{
    class InsertButtonCommand:ICommand
    {
        double _top;
        double _left;
        IScreen _screen;
        ICanvasContentControl _element;
        UserControl _canvasContainerControl;
        CanvasContentControl _contentControl;
        

        public InsertButtonCommand(IScreen screen, UserControl canvasContainerControl, double left, double top)
        {
            _screen = screen;
            _top = top;
            _left = left;
            _element = new ImageElement();
            _canvasContainerControl = canvasContainerControl;
            _contentControl = (_element as ImageElement).CanvasUserControl as CanvasContentControl;

            _contentControl.Content2 = ControlsFactory.LoadDefaultButton();
            _contentControl.MinHeight = 40;
            _contentControl.MinWidth =40;
            Execute();
        }
        public void Execute()
        {
            _screen.elements.Add(_element);
            (_canvasContainerControl.Content as Canvas).Children.Add(((_element as ImageElement).CanvasUserControl as CanvasContentControl));
            Canvas.SetTop(_contentControl, _top);
            Canvas.SetLeft(_contentControl, _left);
        }
        public void Undo()
        {
            _screen.elements.Remove(_element);
            (_canvasContainerControl.Content as Canvas).Children.Remove(((_element as ImageElement).CanvasUserControl as CanvasContentControl));
        }
        public void Redo()
        {
            Execute();
        }
    }
}
