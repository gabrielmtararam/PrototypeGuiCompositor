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


namespace MoveNoCopyAdorner
{
    /// <summary>
    /// Interaction logic for MoveScaleAdornerVisual.xaml
    /// </summary>
    /// 

    public partial class MoveScaleAdornerVisual : UserControl
    {
        //MouseEventHandler mouseEventHandler;
        ScaleEventHandler scaleEventHandler;
        public MoveScaleAdornerVisual()
        {
            InitializeComponent();
        }
        public void OnLoaded(object sender, RoutedEventArgs e) {
            scaleEventHandler = new ScaleEventHandler(this.DataContext as FrameworkElement);
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
    }
}
