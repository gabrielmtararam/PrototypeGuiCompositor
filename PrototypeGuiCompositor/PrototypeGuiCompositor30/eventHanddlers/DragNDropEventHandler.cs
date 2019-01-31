using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace PrototypeGuiCompositor30.eventHanddlers
{
    public class DragNDropEventHandler
    {
        FrameworkElement parentPanel;
        Canvas canvas;

        public DragNDropEventHandler(FrameworkElement _parentPanel, Canvas _canvas)
        {
            parentPanel = _parentPanel;
            canvas = _canvas;
            Console.WriteLine($"event handler {_canvas} _parentPanel {_parentPanel} ");
        }
        public void OnDragDelta(object sender, DragDeltaEventArgs e){

            Console.WriteLine($" e source {e.Source} ee{ e.ToString()} Mouse over {Mouse.DirectlyOver}");

            var s = sender as Thumb;
            var yadjust = parentPanel.Height + e.VerticalChange;
            var xadjust = parentPanel.Width + e.HorizontalChange;
            bool isOnTopCorner = false;
            bool isOnLeftCorner = false;
            bool isOnBottonCorner = false;
            bool isOnRightCorner = false;

            if (e.VerticalChange + Canvas.GetTop(parentPanel) < 0)
            {
                //Console.WriteLine($"distancia da borda top {e.VerticalChange + Canvas.GetTop(parentPanel) }");
                isOnTopCorner = true;
            }

            if (e.HorizontalChange + Canvas.GetLeft(parentPanel) < 0)
            {
                //Console.WriteLine($"distancia da borda left {e.HorizontalChange + Canvas.GetLeft(parentPanel) }");
                isOnLeftCorner = true;
            }

            if ((e.HorizontalChange + Canvas.GetLeft(parentPanel) + parentPanel.ActualWidth) > canvas.ActualWidth)
            {
                //Console.WriteLine($"distancia da borda right {e.HorizontalChange + Canvas.GetRight(parentPanel) }");
                isOnRightCorner = true;
            }

            if ((e.VerticalChange + Canvas.GetTop(parentPanel) + parentPanel.ActualHeight) > canvas.ActualHeight)
            {
                //Console.WriteLine($"distancia da borda top {e.VerticalChange + Canvas.GetTop(parentPanel) }");
                isOnBottonCorner = true;
            }

            if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Center"))
            {
                if (!isOnLeftCorner)
                {
                    Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    xadjust = parentPanel.Width - e.HorizontalChange;
                    parentPanel.Width = xadjust;
                }
            }
            else if ((s.HorizontalAlignment.ToString() == "Center") && (s.VerticalAlignment.ToString() == "Bottom"))
            {
                if (!isOnBottonCorner)
                    parentPanel.Height = yadjust;
            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Bottom"))
            {

                if (!isOnLeftCorner)
                {
                    Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    xadjust = parentPanel.Width - e.HorizontalChange;
                    parentPanel.Width = xadjust;
                }

                if (!isOnBottonCorner)
                {
                    parentPanel.Height = yadjust;
                }

            }
            else if ((s.HorizontalAlignment.ToString() == "Right") && (s.VerticalAlignment.ToString() == "Top"))
            {

                if (!isOnRightCorner)
                {
                    parentPanel.Width = xadjust;
                }

                if (!isOnTopCorner)
                {
                    Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                    yadjust = parentPanel.Height - e.VerticalChange;
                    parentPanel.Height = yadjust;
                }

            }
            else if (s.VerticalAlignment.ToString() == "Center")
            {
                if (!isOnRightCorner)
                    parentPanel.Width = xadjust;
            }
            else if (s.HorizontalAlignment.ToString() == "Center")
            {
                if (!isOnTopCorner)
                {
                    Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                    yadjust = parentPanel.Height - e.VerticalChange;
                    parentPanel.Height = yadjust;
                }
            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Top"))
            {
                yadjust = parentPanel.Height - e.VerticalChange;
                xadjust = parentPanel.Width - e.HorizontalChange;

                if (!isOnLeftCorner)
                {
                    Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    parentPanel.Width = xadjust;
                }

                if (!isOnTopCorner)
                {
                    parentPanel.Height = yadjust;
                    Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                }


            }

            else if ((xadjust >= 0) && (yadjust >= 0))
            {

                if (!isOnRightCorner)
                {
                    parentPanel.Width = xadjust;
                }

                if (!isOnBottonCorner)
                {
                    parentPanel.Height = yadjust;
                }
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
