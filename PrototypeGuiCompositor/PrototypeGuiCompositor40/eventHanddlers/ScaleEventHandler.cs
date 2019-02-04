using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace PrototypeGuiCompositor30
{
    class ScaleEventHandler
    {
        FrameworkElement parentPanel;
        Canvas canvas;
        List<double> scaleBefore;
        List<double> LastOne;
        List<double> result;
     
        public ScaleEventHandler(FrameworkElement _parentPanel, Canvas _canvas)
        {
            parentPanel = _parentPanel;
            canvas = _canvas;
            LastOne = new List<double>();
            result = null;
           
        }


        // List<double> 0:altura 1:largura 2:nextTopOffset 3:nextLeftOffset
        public List<double> getNextScale(object sender, DragDeltaEventArgs e)
        {
            List<double> result = new List<double>();

            Console.WriteLine($"parente panel {parentPanel}");
            var s = sender as Thumb;
            var yadjust = parentPanel.ActualHeight + e.VerticalChange;
            var xadjust = parentPanel.ActualWidth + e.HorizontalChange;
            bool isOnTopCorner = false;
            bool isOnLeftCorner = false;
            bool isOnBottonCorner = false;
            bool isOnRightCorner = false;

            //default
            result.Add(yadjust);
            result.Add(xadjust);
            result.Add( Canvas.GetTop(parentPanel));
            result.Add(Canvas.GetLeft(parentPanel));

            //Console.WriteLine($"distancia da borda top {e.VerticalChange + Canvas.GetTop(parentPanel) }");

            if (e.VerticalChange + Canvas.GetTop(parentPanel) < 0)
            {
                Console.WriteLine($"distancia da borda top {e.VerticalChange + Canvas.GetTop(parentPanel) }");
                isOnTopCorner = true;
            }

            if (e.HorizontalChange + Canvas.GetLeft(parentPanel) < 0)
            {
                Console.WriteLine($"distancia da borda left {e.HorizontalChange + Canvas.GetLeft(parentPanel) }");
                isOnLeftCorner = true;
            }

            if ((e.HorizontalChange + Canvas.GetLeft(parentPanel) + parentPanel.ActualWidth) > canvas.ActualWidth)
            {
                Console.WriteLine($"distancia da borda right {e.HorizontalChange + Canvas.GetRight(parentPanel) }");
                isOnRightCorner = true;
            }

            if ((e.VerticalChange + Canvas.GetTop(parentPanel) + parentPanel.ActualHeight) > canvas.ActualHeight)
            {
                Console.WriteLine($"distancia da borda top {e.VerticalChange + Canvas.GetTop(parentPanel) }");
                isOnBottonCorner = true;
            }

            if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Center"))
            {
                if (!isOnLeftCorner)
                {
                    result[3] = e.HorizontalChange + Canvas.GetLeft(parentPanel);
                    //Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    result[0] = parentPanel.Height;
                    xadjust = parentPanel.Width - e.HorizontalChange;
                    result[1] = xadjust;
                   // parentPanel.Width = xadjust;
                }
            }
            else if ((s.HorizontalAlignment.ToString() == "Center") && (s.VerticalAlignment.ToString() == "Bottom"))
            {
                if (!isOnBottonCorner)
                    result[0] = yadjust;
                   // parentPanel.Height = yadjust;
            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Bottom"))
            {

                if (!isOnLeftCorner)
                {
                   // Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    xadjust = parentPanel.Width - e.HorizontalChange;
                   // parentPanel.Width = xadjust;
                    result[1] = xadjust;
                    result[3] = e.HorizontalChange + Canvas.GetLeft(parentPanel);
                }

                if (!isOnBottonCorner)
                {
                    result[0] = yadjust;
                    parentPanel.Height = yadjust;
                }

            }
            else if ((s.HorizontalAlignment.ToString() == "Right") && (s.VerticalAlignment.ToString() == "Top"))
            {


                if (!isOnRightCorner)
                {

                    result[1] = xadjust;
                    //parentPanel.Width = xadjust;
                }

                if (!isOnTopCorner)
                {
                    //Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                    yadjust = parentPanel.ActualHeight - e.VerticalChange;
                    //parentPanel.Height = yadjust;

                    result[2] = e.VerticalChange + Canvas.GetTop(parentPanel);
                    result[0] = yadjust;
                    
                }

            }
            else if (s.VerticalAlignment.ToString() == "Center")
            {
                if (!isOnRightCorner)
                    result[1] = xadjust;
                result[0] = parentPanel.Height;
                    //parentPanel.Width = xadjust;
            }
            else if (s.HorizontalAlignment.ToString() == "Center")
            {
                if (!isOnTopCorner)
                {
                    //Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                    yadjust = parentPanel.Height - e.VerticalChange;
                    //parentPanel.Height = yadjust;
                    result[2] = e.VerticalChange + Canvas.GetTop(parentPanel);
                    result[0] = yadjust;
                }
            }
            else if ((s.HorizontalAlignment.ToString() == "Left") && (s.VerticalAlignment.ToString() == "Top"))
            {
                yadjust = parentPanel.Height - e.VerticalChange;
                xadjust = parentPanel.Width - e.HorizontalChange;

                if (!isOnLeftCorner)
                {
                    // Canvas.SetLeft(parentPanel, e.HorizontalChange + Canvas.GetLeft(parentPanel));
                    // parentPanel.Width = xadjust;
                    result[3] = e.HorizontalChange + Canvas.GetLeft(parentPanel);
                    result[1] = xadjust;
                }

                if (!isOnTopCorner)
                {
                    //  parentPanel.Height = yadjust;
                    //  Canvas.SetTop(parentPanel, e.VerticalChange + Canvas.GetTop(parentPanel));
                    result[0] = yadjust;
                    result[2] = e.VerticalChange + Canvas.GetTop(parentPanel);
                }


            }

            else if ((xadjust >= 0) && (yadjust >= 0))
            {
                Console.WriteLine("aqui1");
                if (!isOnRightCorner)
                {
                    //parentPanel.Width = xadjust;
                    Console.WriteLine("aqui2");
                    result[1] = xadjust;
                }

                if (!isOnBottonCorner)
                {
                    Console.WriteLine("aqui3");
                    result[0] = yadjust;
                   // parentPanel.Height = yadjust;
                }
            }

            //result.Add(0);
            //result.Add(0);
            //result.Add(0);
            //result.Add(0);
            return result;

        }

        public List<List<double>> OnDragDelta(object sender, DragDeltaEventArgs e)
        {


           // List<double> result2 = new List<double>();

            var s = sender as Thumb;

            //LastOne.Clear();
            //if (result == null)
            //{
            //    LastOne = scaleBefore;
            //}
            //else
            //{
            //    foreach (double i in result)
            //        LastOne.Add(i);
            //}
            result = getNextScale(sender, e);
            // Canvas.SetTop(parentPanel, result[2]);
            // Canvas.SetLeft(parentPanel, result[3]);

            //   parentPanel.Height = result[0];
            //   parentPanel.Width = result[1];
            LastOne.Clear();
            LastOne.Add(parentPanel.ActualHeight);
            LastOne.Add(parentPanel.ActualWidth);
            LastOne.Add(Canvas.GetTop(parentPanel));
            LastOne.Add(Canvas.GetLeft(parentPanel));

            List<List<double>> finalResult = new List<List<double>>();
            finalResult.Add(result);
            finalResult.Add(LastOne);
            return finalResult;

        }

        public void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var s = sender as Thumb;
            s.Opacity = 0.5;
             scaleBefore = new List<double>();
            scaleBefore.Add(parentPanel.ActualHeight);
            scaleBefore.Add(parentPanel.ActualWidth);
            scaleBefore.Add(Canvas.GetTop(parentPanel));
            scaleBefore.Add(Canvas.GetLeft(parentPanel));
        }

        public void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {

            ICommand scaleComand = new ScaleElementCommand(parentPanel, result, scaleBefore);
            CommandManager.AddCommand(scaleComand);
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
