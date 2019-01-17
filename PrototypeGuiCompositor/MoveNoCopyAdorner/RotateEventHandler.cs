using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MoveNoCopyAdorner
{
    class RotateEventHandler
    {
       


        private double initialAngle;
        private RotateTransform rotateTransform;
        private Vector startVector;
        private Point centerPoint;


        Canvas canvas;
        Point _origin;
        FrameworkElement parentPanel;

        Line myLine;

        public RotateEventHandler(FrameworkElement _parentPanel, Canvas _canvas)
        {
            parentPanel = _parentPanel;
            canvas = _canvas; 
        }
        public void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            canvas.Children.Remove(myLine);
            myLine = new Line();

            var s = sender as Thumb;
            Point _currentPos = Mouse.GetPosition(canvas);

            var p = _origin;
            double currentLeft = p.X;
            double currentTop = p.Y;

            myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            myLine.X1 = p.X - s.ActualWidth / 2 ;
            myLine.X2 = _currentPos.X;
            myLine.Y1 = p.Y - s.ActualHeight / 2;
            myLine.Y2 = _currentPos.Y;
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            canvas.Children.Add(myLine);


            var y = -(_currentPos.Y - p.Y + s.ActualHeight / 2);
            var x = _currentPos.X - p.X + s.ActualWidth / 2;
            //  y = Math.Abs(y);
            //  x = Math.Abs(x);


            double tg = y / x;
            double radians = Math.Atan(tg);
            double angle = radians * (180 / Math.PI);

            if (y < 0 && x > 0)
                angle = angle + 360;
            else if (y < 0)
                angle = angle + 180;
            else if (y > 0 && x < 0)
                angle = angle + 180;

            RotateTransform rotateTransform1 = new RotateTransform(-angle, parentPanel.ActualWidth / 2, parentPanel.ActualHeight / 2);

            Console.WriteLine($" parentePanel {parentPanel }  origin {_origin} parentPanel.ActualWidth {parentPanel.ActualWidth } parentPanel.ActualHeight {parentPanel.ActualHeight } ");
            parentPanel.RenderTransform = rotateTransform1;
        }


        public void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var s = sender as Thumb;

            _origin = parentPanel.TranslatePoint(new Point(0, 0), canvas);
            _origin.X += parentPanel.ActualWidth / 2;
            _origin.Y += parentPanel.ActualHeight;

        }

        public void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0;
        }

        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.SizeAll;
        }


        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {
            FrameworkElement senderFE = sender as FrameworkElement;
            if (senderFE.Cursor != Cursors.Wait)
                Mouse.OverrideCursor = Cursors.Arrow;
        }


    }
}
