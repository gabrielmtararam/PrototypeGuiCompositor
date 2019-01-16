﻿using System;
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

namespace MoveNoCopyAdorner
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
            DependencyProperty.Register(" IsSelectedCCC", typeof(bool), typeof(CanvasContentControl), new PropertyMetadata(false));

        public object Content2
        {
            get { return (object)GetValue(Content2Property); }
            set { SetValue(Content2Property, value); }
        }

        public static readonly DependencyProperty Content2Property =
            DependencyProperty.Register("Content2", typeof(object), typeof(CanvasContentControl), new PropertyMetadata(null));


        public MoveScaleAdorner CCCAdorner
        {
            get { return (MoveScaleAdorner)GetValue(CCCAdornerProperty); }
            set { SetValue(CCCAdornerProperty, value); }
        }

        public static readonly DependencyProperty CCCAdornerProperty =
            DependencyProperty.Register("CCCAdornerCCAdorner", typeof(MoveScaleAdorner), typeof(CanvasContentControl), new PropertyMetadata(null));

        public void OnLoaded(object sender, RoutedEventArgs e)
        {

            DependencyObject _myCanvas = VisualTreeHelper.GetParent(this);
            Canvas _myCanvasC = _myCanvas as Canvas;

             mouseEventHandler = new MouseEventHandler(_myCanvasC);
            _myCanvasC.PreviewMouseLeftButtonDown += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonDown;
            _myCanvasC.PreviewMouseMove += mouseEventHandler.MyCanvas_PreviewMouseMove;
            _myCanvasC.PreviewMouseLeftButtonUp += mouseEventHandler.MyCanvas_PreviewMouseLeftButtonUp;
            PreviewKeyDown += mouseEventHandler.window1_PreviewKeyDown;

            CCCAdorner = new MoveScaleAdorner(this);
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
            adornerLayer.Visibility = Visibility.Visible;

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
    }
}
