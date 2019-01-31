// // Copyright (c) Microsoft. All rights reserved.
// // Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace PrototypeGuiCompositor30
{
    public class DragNDropAdorner : Adorner
    {
        private VisualCollection visualChildren;
        DragNDropAdornerVisual customControl;
        UIElement _adornedElement;

        public DragNDropAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            _adornedElement = adornedElement;
            //Console.WriteLine($"here adorned {adornedElement}");
            var brush = new VisualBrush(adornedElement);

            var animation = new DoubleAnimation(0.3, 1, new Duration(TimeSpan.FromSeconds(1)))
            {
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };
            brush.BeginAnimation(Brush.OpacityProperty, animation);
            visualChildren = new VisualCollection(this);
            customControl = new DragNDropAdornerVisual();
            customControl.DataContext = _adornedElement;
            visualChildren.Add(customControl);

        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            double x = 0;
            double y = 0;
            FrameworkElement _adornedElementFE = _adornedElement as FrameworkElement;
            customControl.Arrange(new Rect(x, y, _adornedElementFE.ActualWidth, _adornedElementFE.ActualHeight)); 
            return finalSize;
        }
        protected override int VisualChildrenCount { get { return visualChildren.Count; } }
        protected override Visual GetVisualChild(int index) { return visualChildren[index]; }
    }

}