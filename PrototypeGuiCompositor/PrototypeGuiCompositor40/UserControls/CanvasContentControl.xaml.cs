using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PrototypeGuiCompositor30
{ 
    public partial class CanvasContentControl : UserControl
    {
       
        MouseEventHandler mouseEventHandler;
        public bool IsSelectedCCC
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(" IsSelectedCCC", typeof(bool), typeof(CanvasContentControl), new FrameworkPropertyMetadata(
     false,
     new PropertyChangedCallback(OnIsSelectedCCCPropertyChanged)));

        public object Content2
        {
            get { return (object)GetValue(Content2Property); }
            set { SetValue(Content2Property, value); }
        }

        public static readonly DependencyProperty Content2Property =
            DependencyProperty.Register("Content2", typeof(object), typeof(CanvasContentControl), new PropertyMetadata(null));


        public MoveScaleAdorner cccMoveScaleAdorner
        {
            get { return (MoveScaleAdorner)GetValue(cccMoveScaleAdornerProperty); }
            set { SetValue(cccMoveScaleAdornerProperty, value); }
        }

        public static readonly DependencyProperty cccMoveScaleAdornerProperty =
            DependencyProperty.Register("cccMoveScaleAdorner", typeof(MoveScaleAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));




        public rotateAdorner cccRotateAdorner
        {
            get { return (rotateAdorner)GetValue(cccRotateAdornerProperty); }
            set { SetValue(cccRotateAdornerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cccRotateAdorner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cccRotateAdornerProperty =
            DependencyProperty.Register("cccRotateAdorner", typeof(rotateAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));


        private static void OnIsSelectedCCCPropertyChanged(
           DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((sender as CanvasContentControl).IsSelectedCCC == true)
            {
              //  Console.WriteLine("here we are1");
                DependencyObject _myCanvas = VisualTreeHelper.GetParent((sender as CanvasContentControl));
                Canvas _myCanvasC = _myCanvas as Canvas;
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((sender as CanvasContentControl));

                adornerLayer.Add((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Add((sender as CanvasContentControl).cccRotateAdorner);

                //Console.WriteLine($"moved_element 2click  {(sender as CanvasContentControl).Name} adornerLayer  { adornerLayer.GetHashCode()}" +
                //    $" CCC1  {(_myCanvasC.Children[0] as CanvasContentControl).GetHashCode()}" +
                //    $" CCC2  { (_myCanvasC.Children[1] as CanvasContentControl).GetHashCode() }" +
                //    $" adornerLayerccc1  { AdornerLayer.GetAdornerLayer((_myCanvas._myCanvasC[0] as CanvasContentControl)).GetHashCode()}" +
                //    $" adornerLayerccc2 { AdornerLayer.GetAdornerLayer((_myCanvas._myCanvasC[1] as CanvasContentControl)).GetHashCode()}"

                //    );
            }
            else
            {
                AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(sender as CanvasContentControl);
                adornerLayer.Remove((sender as CanvasContentControl).cccMoveScaleAdorner);
                adornerLayer.Remove((sender as CanvasContentControl).cccRotateAdorner);
            }
        }

        public void OnLoaded(object sender, RoutedEventArgs e)
        {


            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this);
            Canvas _myCanvasC = _myCanvas as Canvas;

            mouseEventHandler = new MouseEventHandler(_myCanvasC);
            _myCanvasC.PreviewMouseLeftButtonDown += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonDown;
           _myCanvasC.PreviewMouseMove += PreviewMouseMove;
            _myCanvasC.PreviewMouseLeftButtonUp += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonUp;
            PreviewKeyDown += mouseEventHandler.window1_PreviewKeyDown;

            cccMoveScaleAdorner = new MoveScaleAdorner(this);
            cccRotateAdorner = new rotateAdorner(this);
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
            adornerLayer.Visibility = Visibility.Visible;

            //(CanvasElement as ImageElement).Height;

            //Binding bindingHeight = new Binding
            //{
            //    Source = (CanvasElement as ImageElement),
            //    Path = new PropertyPath("Height"),
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //};
            //(this).SetBinding(HeightProperty, bindingHeight);

            //Binding bindingWidth = new Binding
            //{
            //    Source = (CanvasElement as ImageElement),
            //    Path = new PropertyPath("Width"),
            //    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            //};
            //(this).SetBinding(WidthProperty, bindingWidth);
            //(this.Height) = ((CanvasElement as ImageElement).Height);


        }

        public void PreviewMouseMove(Object sender, MouseEventArgs e)
        {
           List<List<double>> result= mouseEventHandler.MyCanvas_PreviewMouseMove(sender,e);
            RaiseEvent(new MoveRoutedEventArgs(CanvasContentControl.MoveRoutedEvent, sender, result));
        }
        public CanvasContentControl()
        {
            InitializeComponent();
            this.IsSelectedCCC = false;

        }

        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {
           
            mouseEventHandler.Move_MouseEnter(sender, e);
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {
           
            mouseEventHandler.Move_MouseLeave(sender, e);
        }


        public static readonly RoutedEvent MoveRoutedEvent =
               EventManager.RegisterRoutedEvent(
                   "Move",
                   RoutingStrategy.Bubble,
                   typeof(RoutedEventHandler),
                   typeof(MoveScaleAdornerVisual));

        public event RoutedEventHandler Move
        {
            add { AddHandler(MoveRoutedEvent, value); }
            remove { RemoveHandler(MoveRoutedEvent, value); }
        }
    }

    public class MoveRoutedEventArgs : RoutedEventArgs
    {
        public MoveRoutedEventArgs(RoutedEvent routedEvent, Object source, List<List<double>> result) : base(routedEvent, source)
        {
            MyProperty = result; ;

        }
        public List<List<double>> MyProperty { get; set; }

    }
}
