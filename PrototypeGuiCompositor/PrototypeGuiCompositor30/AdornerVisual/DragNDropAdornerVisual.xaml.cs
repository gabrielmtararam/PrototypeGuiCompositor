using PrototypeGuiCompositor30.eventHanddlers;
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
    public partial class DragNDropAdornerVisual : UserControl
    {
        DragNDropEventHandler dragNDropEventHandler;
        public DragNDropAdornerVisual()
        {
            Console.WriteLine("entrou aqui");
            this.Loaded += new RoutedEventHandler(OnLoaded);
            InitializeComponent();
            Console.WriteLine("entrou aqui3");

        }
        public void OnLoaded(object sender, RoutedEventArgs e) {
            Console.WriteLine("entrou aqui2");
            //DependencyObject contentPresenter = VisualTreeHelper.GetParent(this.DataContext as FrameworkElement);
            //DependencyObject grid = VisualTreeHelper.GetParent(contentPresenter as FrameworkElement);
            //DependencyObject boorder = VisualTreeHelper.GetParent(grid as FrameworkElement);
            //DependencyObject dragNDropContentControl = VisualTreeHelper.GetParent(boorder as FrameworkElement);
            //// Canvas _myCanvasC = _myCanvas as Canvas;
            //Console.WriteLine($" this.DataContext {this.DataContext} contentPresenter {contentPresenter.GetType()} canvas do data context {dragNDropContentControl.GetType()}");
            //
            dragNDropEventHandler = new DragNDropEventHandler(this.DataContext as FrameworkElement,new Canvas());
        }
            private void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            dragNDropEventHandler.OnDragDelta(sender, e);
        }

        private void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            dragNDropEventHandler.OnDragStarted(sender, e);
        }

        private void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            dragNDropEventHandler.OnDragCompleted(sender, e);
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {

            dragNDropEventHandler.Move_MouseEnter(sender, e);
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {

            dragNDropEventHandler.Move_MouseLeave(sender, e);
        }

    }
}
