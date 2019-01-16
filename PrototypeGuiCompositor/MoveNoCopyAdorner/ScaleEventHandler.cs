using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MoveNoCopyAdorner
{
    class ScaleEventHandler
    {
        FrameworkElement parentPanel;

        public ScaleEventHandler(FrameworkElement _parentPanel)
        {

            parentPanel = _parentPanel;
        }
        public void OnDragDelta(object sender, DragDeltaEventArgs e)
        {

            //Console.WriteLine($"DataContext: {DataContext}");
            var s = sender as Thumb;

           

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

        public void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0.5;
        }

        public void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0;
        }


    }
}
