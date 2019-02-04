using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrototypeGuiCompositor30
{
    public class MoveCommand:ICommand
    {
        FrameworkElement _movedElement;
        double _top;
        double _left;
        double _originalLeft;
        double _originalTop;
   
        public MoveCommand(FrameworkElement movedElement, double top, double left, double originalTop, double originalLeft)
        {
            _movedElement = movedElement;
            _top = top;
            _left = left;
            _originalTop = originalTop;
            _originalLeft = originalLeft;
     

            Execute();
        }
        public void Execute()
        {
            //Console.WriteLine("executando o command");
         

            Canvas.SetTop(_movedElement, _top);
            Canvas.SetLeft(_movedElement, _left);

          //  Console.WriteLine($"move exec _top {_top} _left{_left} ");
        }
        public void Undo()
        {
           

            Canvas.SetTop(_movedElement, _originalTop);
            Canvas.SetLeft(_movedElement, _originalLeft);
            Console.WriteLine($"move undo _top {_originalTop} _left{_originalLeft} ");
        }
        public void Redo()
        {
            Execute();
        }

    }
}
