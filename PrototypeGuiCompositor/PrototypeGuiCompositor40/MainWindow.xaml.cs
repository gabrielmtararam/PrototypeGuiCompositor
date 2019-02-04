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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //int currentScreen = 0;
        //List<IScreen> screens;
        public MainWindow()
        {

            InitializeComponent();
            //Console.WriteLine($"scc  {screens}  as");

            // screens = ScreensFactory.LoadScreenList();
            ProgramManager.InitializeProgram();
            canvasContainer.Screen = ProgramManager.screens[ProgramManager.activeScreen];

            // appContainer.Children.Add(screens[currentScreen].Screen);
            // Grid.SetRow(screens[currentScreen].Screen, 1);
            //  Grid.SetColumn(screens[currentScreen].Screen, 1);
            AddHandler(CanvasContentControl.MoveRoutedEvent, new RoutedEventHandler(this.MoveEvent));

            AddHandler(MoveScaleAdornerVisual.MoveScaleRoutedEvent, new RoutedEventHandler(this.ScaleEvent));
            //  MoveScaleAdornerVisual.MoveScaleRoutedEvent
            //MoveScaleAdornerVisual.MoveScaleRoutedEvent += this.moveEvent;
            //   MoveScaleAdornerVisual.MoveScale += moveEvent;
        }
        public void MoveEvent(object sender, RoutedEventArgs e)
        {
          //  Console.WriteLine("aaaaaaaaaaentrou aqui");
             MoveRoutedEventArgs argumentos = e as MoveRoutedEventArgs;

            if (argumentos.MyProperty != null)
            {
                //  double ScaleX = argumentos.MyProperty[0][1] - argumentos.MyProperty[1][1];
                //  double ScaleY = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
                double nextTop = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
                double nextBot = argumentos.MyProperty[0][1] - argumentos.MyProperty[1][1];

                foreach (ImageElement element in canvasContainer.Screen.elements)
                {
                    CanvasContentControl cccElement = (element.CanvasUserControl as CanvasContentControl);
                    if (cccElement.IsSelectedCCC == true)
                    {
                        //   cccElement.Width = cccElement.ActualWidth + ScaleX;
                        //   cccElement.Height = cccElement.ActualHeight + ScaleY;
                        Console.WriteLine($"nextTop {nextTop}  Canvas.GetTop(cccElement) {Canvas.GetTop(cccElement)}");
                        Canvas.SetTop(cccElement, Canvas.GetTop(cccElement)+ nextTop);
                //        Canvas.SetLeft(cccElement, Canvas.GetLeft(cccElement) + nextBot);
                    }
                }
                //foreach (double i in (argumentos.MyProperty[0]))
                //{
                //    Console.WriteLine($"11element {i.ToString()}");
                //}
                //foreach (double i in (argumentos.MyProperty[1]))
                //{
                //    Console.WriteLine($"222element {i.ToString()}");
                //}
                // e.Handled = false;
            }
        }

        public void ScaleEvent(object sender, RoutedEventArgs e)
        {
            MoveScaleRoutedEventArgs argumentos = e as MoveScaleRoutedEventArgs;

            double ScaleX = argumentos.MyProperty[0][1] -argumentos.MyProperty[1][1];
            double ScaleY = argumentos.MyProperty[0][0] - argumentos.MyProperty[1][0];
            double nextTop = argumentos.MyProperty[0][2] - argumentos.MyProperty[1][2];
            double nextBot = argumentos.MyProperty[0][3] - argumentos.MyProperty[1][3];

            foreach (ImageElement element in canvasContainer.Screen.elements)
            {
                CanvasContentControl cccElement = (element.CanvasUserControl as CanvasContentControl);
                if (cccElement.IsSelectedCCC == true)
                {
                    cccElement.Width = cccElement.ActualWidth + ScaleX;
                    cccElement.Height = cccElement.ActualHeight + ScaleY;
                    Canvas.SetTop(cccElement, Canvas.GetTop(cccElement) + nextTop);
                    Canvas.SetLeft(cccElement, Canvas.GetLeft(cccElement) + nextBot);
                }
            }
            //foreach (double i in (argumentos.MyProperty[0]))
            //{
            //    Console.WriteLine($"11element {i.ToString()}");
            //}
            //foreach (double i in (argumentos.MyProperty[1]))
            //{
            //    Console.WriteLine($"222element {i.ToString()}");
            //}
            // e.Handled = false;
        }

        private void OnImageInsertSelect(object sender, RoutedEventArgs e)
        {
            
            if (sender.GetType() == typeof(Button))
            {
               
                //Console.WriteLine($"button id {GetButtonId((sender as Button).Name)}");
                //int value = Int32.Parse((sender as Button).Name);
                int value = GetButtonId((sender as Button).Name);
               // Console.WriteLine($"canvasContainer.InsertElementMode {canvasContainer.InsertElementMode}");
                if (canvasContainer.InsertElementMode == value)
                {
                    (sender as Button).Background = Brushes.Transparent;
                    canvasContainer.InsertElementMode = 0;
                }
                else
                {

                    (sender as Button).Background = Brushes.Blue;
                    canvasContainer.InsertElementMode = 1;
                }
            }
                
        }

        private void OnSelectAllClick(object sender, RoutedEventArgs e)
        {

            Console.WriteLine("aaaaaaaa");
        }

        private int GetButtonId(string name)
        {
            
            name = name.ToLower();
                string[] result = name.Split(new[] { "button" }, StringSplitOptions.None);


            int value = Int32.Parse(result[1]);
            return value;
        }

        private void OnUndoclick(object sender, RoutedEventArgs e)
        {
            CommandManager.UndoCommand();
        }

        private void OnRedoClick(object sender, RoutedEventArgs e)
        {
            CommandManager.RedoCommand();
        }
    }
}
