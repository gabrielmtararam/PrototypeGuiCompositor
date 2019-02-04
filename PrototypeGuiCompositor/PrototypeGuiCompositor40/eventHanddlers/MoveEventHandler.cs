using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PrototypeGuiCompositor30
{
    class MouseEventHandler
    {
        private bool _isDown;
        private bool _isDragging;
        private UIElement _MovedElement;
        private double _originalLeft;
        private double _originalTop;
        private Adorner _overlayElement;

        double nextLeftOffset;
        double nextTopOffset;
        FrameworkElement _FrMovedElement;

        private Point _previousMousePosition;
        private Canvas _myCanvas;


        List<double> scaleBefore;
        List<double> LastOne;
        List<double> result;


        public MouseEventHandler(Canvas myCanvas)
        {
            _myCanvas = myCanvas;
            _previousMousePosition.X = 0;
            _previousMousePosition.Y = 0;

        }


        public void window1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
       //     Console.WriteLine("here4");
            if (e.Key == Key.Escape && _isDragging)
            {
                DragFinished(true);
            }
        }

        public void MyCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
        //    Console.WriteLine("here3");
            if (_isDown)
            {
                DragFinished(true);
                e.Handled = true;

            }
        }

        public void DragFinished(bool cancelled)
        {
        //    Console.WriteLine("here2");

            Mouse.Capture(null);
            if (_isDragging)
            {
                AdornerLayer.GetAdornerLayer(_overlayElement.AdornedElement).Remove(_overlayElement);

                if (cancelled == false)
                {
                    _isDragging = false;
                    _isDown = false;
                    Canvas.SetTop(_MovedElement, _originalTop);
                    Canvas.SetLeft(_MovedElement, _originalLeft);
                  
                }
                _overlayElement = null;
            }
            _isDragging = false;
            _isDown = false;
          
            //  CommandManager.AddCommand(new MoveCommand(_FrMovedElement, nextTopOffset, nextLeftOffset, _originalTop, _originalLeft));

        }

        public List<List<double>> MyCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {

         
            if (_isDown)
            {
           //     Console.WriteLine("here1");
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(_myCanvas).X - _originalLeft) >
                      SystemParameters.MinimumHorizontalDragDistance) ||
                     (Math.Abs(e.GetPosition(_myCanvas).Y - _originalTop) >
                      SystemParameters.MinimumVerticalDragDistance)))
                {
               //     Console.WriteLine("here11");
                    DragStarted();
                }else
                if (_isDragging)
                {
                   
                    return DragMoved();
                }
            }
            return null;
        }
        public void DragStarted()
        {
          //  Console.WriteLine("here5");
            _isDragging = true;
            _originalLeft = Canvas.GetLeft(_MovedElement);
            _originalTop = Canvas.GetTop(_MovedElement);

            _overlayElement = new SimpleCircleAdorner(_MovedElement);
            var layer = AdornerLayer.GetAdornerLayer(_MovedElement);
            layer.Add(_overlayElement);
        }



        public List<List<double>> DragMoved()
        {
           
            _FrMovedElement = _MovedElement as FrameworkElement;

            (_MovedElement as CanvasContentControl).IsSelectedCCC = true;

            nextTopOffset = MoveCalculator.getNextOffset(Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, _myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y);
            nextLeftOffset = MoveCalculator.getNextOffset(Canvas.GetLeft(_MovedElement), _FrMovedElement.ActualWidth, _myCanvas.ActualWidth, Mouse.GetPosition(_MovedElement).X, Mouse.GetPosition(_myCanvas).X, _previousMousePosition.X);



            if (LastOne == null)
                LastOne = new List<double>();
            if (result == null)
                result = new List<double>();

            LastOne.Clear();
            //LastOne.Add(_MovedElement.ActualHeight);
            // LastOne.Add(_MovedElement.ActualWidth);
            LastOne.Add(Canvas.GetTop(_MovedElement));
            LastOne.Add(Canvas.GetLeft(_MovedElement));
            result.Clear();
            result.Add(nextTopOffset);
            result.Add(nextLeftOffset);
            List<List<double>> finalResult = new List<List<double>>();
            finalResult.Add(result);
            finalResult.Add(LastOne);
            //return finalResult;
            //Console.WriteLine("here6");

            //Console.WriteLine($"nextOfsset moved {_MovedElement} last0 {LastOne[0]} last1 {LastOne[1]} frLen {finalResult[0].Count}");
            //foreach (double i in (finalResult[0]))
            //{
            //    Console.WriteLine($"11element {i.ToString()}");
            //}
            //foreach (double i in (finalResult[1]))
            //{
            //    Console.WriteLine($"222element {i.ToString()}");
            //}
        


            return finalResult;

            Canvas.SetTop(_MovedElement, nextTopOffset);
            Canvas.SetLeft(_MovedElement, nextLeftOffset);
            _previousMousePosition = Mouse.GetPosition(_myCanvas);
        }
        public void MyCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          //  Console.WriteLine("here7");
            DependencyObject parent;
            CanvasContentControl _MovedElementCCC = e.Source as CanvasContentControl;
            _MovedElement = e.Source as UIElement;
            parent = VisualTreeHelper.GetParent(_MovedElement);
            if (e.Source == _myCanvas)
            {
            }
            else
            {

                if (e.ClickCount == 2)
                {
          //          Console.WriteLine("here15");
                    _MovedElementCCC.IsSelectedCCC = !_MovedElementCCC.IsSelectedCCC;

                }
                else
                {
                _isDown = true;
                 _myCanvas.CaptureMouse();
                }

               

                e.Handled = true;
            }
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)

        {
         //   Console.WriteLine("here8");
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Hand;


        }


        public void Move_MouseLeave(object sender, MouseEventArgs e)

        {
        //    Console.WriteLine("here9");
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Arrow;

        }




    }
}
