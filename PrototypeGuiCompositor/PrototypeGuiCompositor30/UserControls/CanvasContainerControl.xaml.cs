using PrototypeGuiCompositor30.eventHanddlers;
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
    public partial class CanvasContainerControl : UserControl
    {


        // DragNDropEventHandler dragNDropEventHandler;


       

        public IScreen Screen
        {
            get { return (IScreen)GetValue(ScreenProperty); }
            set { SetValue(ScreenProperty, value); }
        }

        public static readonly DependencyProperty ScreenProperty =
            DependencyProperty.Register("Screen", typeof(IScreen), typeof(CanvasContentControl), new PropertyMetadata(null));

        public int InsertElementMode
        {
            get { return (int)GetValue(InsertElementModeProperty); }
            set { SetValue(InsertElementModeProperty, value); }
        }

        public static readonly DependencyProperty InsertElementModeProperty =
            DependencyProperty.Register("InsertElementMode", typeof(int), typeof(CanvasContentControl), new PropertyMetadata(null));



        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.Content = Screen.Screen as Canvas;
            
            //this.AddChild(Screen.Screen);


            //dragNDropEventHandler = new DragNDropEventHandler();
            //this.PreviewMouseLeftButtonDown += dragNDropEventHandler.MyCanvas_PreviewMouseLeftButtonDown;
            //this.PreviewMouseMove += dragNDropEventHandler.MyCanvas_PreviewMouseMove;
            //this.PreviewMouseLeftButtonUp += dragNDropEventHandler.MyCanvas_PreviewMouseLeftButtonUp;
            //this.PreviewKeyDown += dragNDropEventHandler.window1_PreviewKeyDown;


          

        }

        public CanvasContainerControl()
        {
            InitializeComponent();

           
        }
        public void Move_MouseEnter(object sender, MouseEventArgs e)
        {
           
            //dragNDropEventHandler.Move_MouseEnter(sender, e);
        }
        public void Move_MouseLeave(object sender, MouseEventArgs e)
        {

            //dragNDropEventHandler.Move_MouseLeave(sender, e);
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.InsertElementMode == 1)
            {
                // Console.WriteLine("heeere");
                ICommand comando = new InsertButtonCommand(Screen, this, Mouse.GetPosition(this.Content as Canvas).X, Mouse.GetPosition(this.Content as Canvas).Y);

                CommandManager.AddCommand(comando);
            }
        }
    }
}
