using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;

namespace TestWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            timer1 = new DispatcherTimer
            {
                Interval = new TimeSpan(20000)//每20ms刷新一次
            };
            timer1.Tick += new EventHandler(Refresh1);    //定时器初始化
            timer1.Start();

            timer2 = new DispatcherTimer
            {
                Interval = new TimeSpan(100000000)//每1s刷新一次
            };
            timer2.Tick += new EventHandler(Refresh2);    //定时器初始化
            timer2.Start();

            timer3 = new DispatcherTimer
            {
                Interval = new TimeSpan(800000)//每1.6s刷新一次
            };
            timer3.Tick += new EventHandler(Refresh3);    //定时器初始化
            timer3.Start();

            myCharacter =new(Kind.Character,Test);
            life = 1000;
            ghost1 = new(Kind.Ghost, Test);
            ghost1.Move(200, 200);
            for(int i=0;i<5;i++)
            {
                Random rx = new();
                Random ry = new();
                Bean bean=new(rx.Next(100, 700), ry.Next(50, 400), Test);
            }

            Score.Content = $"得分：{score}\n生命：{life}"; ;
        }

        private void KeyBoardControl(object sender, KeyEventArgs e)
        {
            if (life > 0)
            {
                if (e.Key == Key.W)
                {
                    if (myCharacter.Y > 10)
                        myCharacter.Move(0, -10);
                }
                if (e.Key == Key.A)
                {
                    if (myCharacter.X > 10)
                        myCharacter.Move(-10, 0);
                }
                if (e.Key == Key.S)
                {
                    if (myCharacter.Y < 390)
                        myCharacter.Move(0, 10);
                }
                if (e.Key == Key.D)
                {
                    if (myCharacter.X < 750)
                        myCharacter.Move(10, 0);
                }
            }
        }

        private void Refresh1(object? sender, EventArgs e)
        {
            for (int num = 0; num < Test.Children.Count; num++)
            {
                UIElement i = Test.Children[num];
                if (i is Ellipse)
                {
                    Ellipse? ellipse = i as Ellipse;
                    if (ellipse != null)
                    {
                        if ((ellipse.Margin.Left - myCharacter.X) * (ellipse.Margin.Left - myCharacter.X) + (ellipse.Margin.Top - myCharacter.Y) * (ellipse.Margin.Top - myCharacter.Y) < 196)
                        {
                            if (ellipse.Width == 8)
                            {
                                Test.Children.Remove(i);
                                num--;
                                score++;
                                Score.Content = $"得分：{score}\n生命：{life}";
                            }
                            if(ellipse.Width==20&&ellipse.Fill==Brushes.DarkBlue)
                            {
                                life -= 5;
                                Score.Content = $"得分：{score}\n生命：{life}";
                            }
                        }
                    }
                }
            }
            if (life < 0)
            {
                Score.Content = $"得分：{score}\n生命：寄！";
            }
        }

        private void Refresh2(object? sender, EventArgs e)
        {
            Random rx = new();
            Random ry = new();
            Bean bean = new(rx.Next(100, 700), ry.Next(50, 400), Test);
            if (life < 0)
            {
                Application.Current.Shutdown();
            }
        }

        private void Refresh3(object? sender, EventArgs e)
        {
            if (life >= 0)
            {
                double theta1 = Math.Atan2(myCharacter.Y - ghost1.Y, myCharacter.X - ghost1.X);
                ghost1.Move(Convert.ToInt32(10 * Math.Cos(theta1)), Convert.ToInt32(10 * Math.Sin(theta1)));
            }
        }
        private Character myCharacter;
        private Character ghost1;
        private DispatcherTimer timer1,timer2,timer3;
        private int score,life;
    }
}
