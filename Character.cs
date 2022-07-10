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
    enum Kind
    {
        None = 0,
        Character = 1,
        Ghost = 2
    }
    class Character
    {
        public Character(Kind kind,Grid UpperLayerOfMap)
        {
            this.kind = kind;
            x = 375;
            y = 200;
            icon = new();
            icon.HorizontalAlignment = HorizontalAlignment.Left;
            icon.VerticalAlignment = VerticalAlignment.Top;
            icon.Margin = new(x, y, 0, 0);
            icon.Width = 20;
            icon.Height = 20;
            switch(kind)
            {
                case Kind.Character:
                    {
                        icon.Stroke = Brushes.Orange;
                        icon.Fill = Brushes.Orange;
                    }
                    break;
                case Kind.Ghost:
                    {
                        icon.Stroke = Brushes.Black;
                        icon.Fill = Brushes.DarkBlue;
                    }
                    break;
                default:break;
            }
            UpperLayerOfMap.Children.Add(icon);
        }

        public void Move(int deltaX,int deltaY)
        {
            icon.Margin = new(x + deltaX, y + deltaY, 0, 0);
            x += deltaX;
            y += deltaY;
        }

        public Kind Kind { get => kind; }
        public int X { get => x; }
        public int Y { get => y; }
        private Kind kind;
        private int x;
        private int y;
        private Ellipse icon;
    }
}
