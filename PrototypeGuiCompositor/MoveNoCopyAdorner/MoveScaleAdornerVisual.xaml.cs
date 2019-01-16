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
        public MoveScaleAdornerVisual()
        {
          
            InitializeComponent();

        }
        public void OnLoaded(object sender, RoutedEventArgs e) { 


        }
            private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {

            //Console.WriteLine($"DataContext: {DataContext}");
            var s = sender as Thumb;
         
            FrameworkElement parentPanel = this.DataContext as FrameworkElement;

            var yadjust = parentPanel.Height + e.VerticalChange;
            var xadjust = parentPanel.Width + e.HorizontalChange;

            Console.WriteLine($"get left {Canvas.GetLeft(parentPanel)} get top {Canvas.GetTop(parentPanel)} ");
            if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Center"))
            {
                Console.WriteLine(" entrou aqui");
                Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));


                xadjust = parentPanel.Width - e.HorizontalChange;

                parentPanel.Width = xadjust;

            }
            else if ((s.HorizontalAlignment.ToString() == "Center") && (s.VerticalAlignment.ToString() == "Bottom"))
            {
                Console.WriteLine(" entrou aqu22222ai");

                parentPanel.Height = yadjust;

            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Bottom"))
            {
                Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));


                xadjust = parentPanel.Width - e.HorizontalChange;

                parentPanel.Width = xadjust;
                parentPanel.Height = yadjust;

            }
            else if ((s.HorizontalAlignment.ToString() == "Right") && (s.VerticalAlignment.ToString() == "Top"))
            {

                Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                yadjust = parentPanel.Height - e.VerticalChange;

                parentPanel.Width = xadjust;
                parentPanel.Height = yadjust;

            }
            else if (s.VerticalAlignment.ToString() == "Center")
                parentPanel.Width = xadjust;
            else if (s.HorizontalAlignment.ToString() == "Center")
            {
                Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                yadjust = parentPanel.Height - e.VerticalChange;
                parentPanel.Height = yadjust;
            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Top"))
            {
                yadjust = parentPanel.Height - e.VerticalChange;
                xadjust = parentPanel.Width - e.HorizontalChange;
                Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));

                parentPanel.Width = xadjust;
                parentPanel.Height = yadjust;
            }

            else if ((xadjust >= 0) && (yadjust >= 0))
            {
                Console.WriteLine(" 222entrou aqui");
                parentPanel.Width = xadjust;
                parentPanel.Height = yadjust;
            }
        }

        private void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0.5;
        }

        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0;
        }
    }
}
