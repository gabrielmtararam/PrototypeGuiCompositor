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
        

       public  MouseEventHandler(Canvas myCanvas)
        {
            _myCanvas = myCanvas;
            _previousMousePosition.X = 0;
            _previousMousePosition.Y = 0;
          
        }


        public void window1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && _isDragging)
            {
                DragFinished(true);
            }
        }

        public void MyCanvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDown)
            {
                DragFinished(true);
                e.Handled = true;

            }
        }

        public void DragFinished(bool cancelled)
        {
            
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
            CommandManager.AddCommand(new MoveCommand(_FrMovedElement, nextTopOffset, nextLeftOffset, _originalTop, _originalLeft));
         
        }

        public void MyCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) &&
                    ((Math.Abs(e.GetPosition(_myCanvas).X - _originalLeft) >
                      SystemParameters.MinimumHorizontalDragDistance) ||
                     (Math.Abs(e.GetPosition(_myCanvas).Y - _originalTop) >
                      SystemParameters.MinimumVerticalDragDistance)))
                {
                    DragStarted();
                }
                if (_isDragging)
                {
                    DragMoved();
                }
            }
        }
        public void DragStarted()
        {
            _isDragging = true;
            _originalLeft = Canvas.GetLeft(_MovedElement);
            _originalTop = Canvas.GetTop(_MovedElement);

            _overlayElement = new SimpleCircleAdorner(_MovedElement);
            var layer = AdornerLayer.GetAdornerLayer(_MovedElement);
            layer.Add(_overlayElement);
        }
     


        public void DragMoved()
        {
             _FrMovedElement = _MovedElement as FrameworkElement;


            nextTopOffset = MoveCalculator.getNextOffset(Canvas.GetTop(_MovedElement), _FrMovedElement.ActualHeight, _myCanvas.ActualHeight, Mouse.GetPosition(_MovedElement).Y, Mouse.GetPosition(_myCanvas).Y, _previousMousePosition.Y);
            nextLeftOffset = MoveCalculator.getNextOffset(Canvas.GetLeft(_MovedElement), _FrMovedElement.ActualWidth, _myCanvas.ActualWidth, Mouse.GetPosition(_MovedElement).X, Mouse.GetPosition(_myCanvas).X, _previousMousePosition.X);


            Canvas.SetTop(_MovedElement, nextTopOffset);
            Canvas.SetLeft(_MovedElement, nextLeftOffset);
            _previousMousePosition = Mouse.GetPosition(_myCanvas);
        }
        public void MyCanvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent;
            CanvasContentControl _MovedElementCCC = e.Source as CanvasContentControl;
            _MovedElement = e.Source as UIElement;    
            parent = VisualTreeHelper.GetParent(_MovedElement);
            if (e.Source == _myCanvas)
            {
            }
            else
            {
                _isDown = true;

                if (e.ClickCount == 2)
                {
                   
                    _MovedElementCCC.IsSelectedCCC = !_MovedElementCCC.IsSelectedCCC;
                    if (_MovedElementCCC.IsSelectedCCC == true)
                    {

                        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_MovedElementCCC);

                        adornerLayer.Add(_MovedElementCCC.cccMoveScaleAdorner);
                        adornerLayer.Add(_MovedElementCCC.cccRotateAdorner);

                        Console.WriteLine($"moved_element 2click  {_MovedElementCCC.Name} adornerLayer  { adornerLayer.GetHashCode()}" +
                            $" CCC1  {(_myCanvas.Children[0] as CanvasContentControl).GetHashCode()}"+
                            $" CCC2  { (_myCanvas.Children[1] as CanvasContentControl).GetHashCode() }"+
                            $" adornerLayerccc1  { AdornerLayer.GetAdornerLayer((_myCanvas.Children[0] as CanvasContentControl)).GetHashCode()}"+
                            $" adornerLayerccc2 { AdornerLayer.GetAdornerLayer((_myCanvas.Children[1] as CanvasContentControl)).GetHashCode()}" 

                            );
                    }
                    else
                    {
                        AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(_MovedElementCCC);
                        adornerLayer.Remove(_MovedElementCCC.cccMoveScaleAdorner);
                        adornerLayer.Remove(_MovedElementCCC.cccRotateAdorner);
                    }
                }

                _myCanvas.CaptureMouse();

                e.Handled = true;
            }
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)

        {

            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Hand;
          

        }


        public void Move_MouseLeave(object sender, MouseEventArgs e)

        {
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)

                Mouse.OverrideCursor = Cursors.Arrow;

        }
      

    }
}
