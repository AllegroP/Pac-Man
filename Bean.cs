using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
namespace TestWpfApp
{
    class Bean
    {
        public Bean(int X,int Y,Grid UpperLayerOfMap)
        {
            x = X;
            y = Y;
            icon = new();
            icon.HorizontalAlignment = HorizontalAlignment.Left;
            icon.VerticalAlignment = VerticalAlignment.Top;
            icon.Margin = new(X, Y, 0, 0);
            icon.Width = 8;
            icon.Height = 8;
            icon.Stroke = Brushes.Green;
            icon.Fill = Brushes.Green;
            UpperLayerOfMap.Children.Add(icon);
        }
        public int X { get => x; }
        public int Y { get => y; }
        private int x;
        private int y;
        private Ellipse icon;
    }
}
