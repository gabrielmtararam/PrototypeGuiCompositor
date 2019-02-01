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
    public partial class dragNDropContentControl : UserControl
    {


        DragNDropEventHandler dragNDropEventHandler;
       

        public object DragNDropContent
        {
            get { return (object)GetValue(DragNDropContentProperty); }
            set { SetValue(DragNDropContentProperty, value); }
        }

        public static readonly DependencyProperty DragNDropContentProperty =
            DependencyProperty.Register("DragNDropContent", typeof(object), typeof(dragNDropContentControl), new PropertyMetadata(null));



        public void OnLoaded(object sender, RoutedEventArgs e)
        {
            DragNDropAdorner cccDragNDropAdorner = new DragNDropAdorner(this);
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
            adornerLayer.Add(cccDragNDropAdorner);
            adornerLayer.Visibility = Visibility.Visible;
        }

        public dragNDropContentControl()
        {
            InitializeComponent();
        }

    }
}
