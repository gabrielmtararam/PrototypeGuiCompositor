using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PrototypeGuiCompositor30
{
    public partial class MoveScaleAdornerVisual : UserControl
    {
        ScaleEventHandler scaleEventHandler;
        public MoveScaleAdornerVisual()
        {
            InitializeComponent();
        }
        public void OnLoaded(object sender, RoutedEventArgs e) {
            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this.DataContext as FrameworkElement);
            Canvas _myCanvasC = _myCanvas as Canvas;
            Console.WriteLine($"canvas do data context {_myCanvas}");
            scaleEventHandler = new ScaleEventHandler(this.DataContext as FrameworkElement, _myCanvasC);
        }
            private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            scaleEventHandler.OnDragDelta(sender, e);
        }

        private void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            scaleEventHandler.OnDragStarted(sender, e);
        }

        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            scaleEventHandler.OnDragCompleted(sender, e);
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {

            scaleEventHandler.Move_MouseEnter(sender, e);
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {

            scaleEventHandler.Move_MouseLeave(sender, e);
        }

    }
}
