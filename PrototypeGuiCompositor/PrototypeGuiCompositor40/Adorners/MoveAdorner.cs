using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PrototypeGuiCompositor30
{
    class MoveAdorner : Adorner
    {
        public MoveAdorner(UIElement adornedElement) : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this);
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
            double renderRadius = 5.0;
            Pen dashed_pen = new Pen(Brushes.Black, 2);
            dashed_pen.DashStyle = DashStyles.Dash;
            drawingContext.DrawLine(dashed_pen, new Point(adornedElementRect.TopLeft.X, adornedElementRect.TopLeft.Y-3), new Point(adornedElementRect.TopRight.X, adornedElementRect.TopRight.Y - 3));
            drawingContext.DrawLine(dashed_pen, new Point(adornedElementRect.TopRight.X +3, adornedElementRect.TopRight.Y -3 ), new Point(adornedElementRect.BottomRight.X + 3, adornedElementRect.BottomRight.Y + 3));
            drawingContext.DrawLine(dashed_pen, new Point(adornedElementRect.TopLeft.X - 3, adornedElementRect.TopLeft.Y - 3), new Point(adornedElementRect.BottomLeft.X - 3, adornedElementRect.BottomLeft.Y + 3));
            drawingContext.DrawLine(dashed_pen, new Point(adornedElementRect.BottomLeft.X, adornedElementRect.BottomLeft.Y + 3), new Point(adornedElementRect.BottomRight.X, adornedElementRect.BottomRight.Y + 3));
        }
    }
}
