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
