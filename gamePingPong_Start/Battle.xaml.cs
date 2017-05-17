using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace gamePingPong_Start
{
    /// <summary>
    /// Battle.xaml 的交互逻辑
    /// </summary>
    public partial class Battle : Window
    {
        public Battle()
        {
            InitializeComponent();
        }
        double x = 100, y = 150, t, bx1, by1, bx2, by2 = 100, bx, by, k, x_, y_, b2_x, b2_y,d;
        
        int p1,p2;
        bool state=true;
        private void bat(object sender, KeyEventArgs e)
        {
            t++;
            if ( Keyboard.IsKeyDown(Key.A) )
            {               
                x = x - 20;
                if (x < 60)
                {
                    x = 60;
                }
            }

            if (Keyboard.IsKeyDown(Key.D))
            {
                x = x + 20;
                if (x > 400)
                {
                    x = 400;
                }
            }
            Canvas.SetLeft(this.b1, x);
            auto_move();
            message.Visibility = Visibility.Collapsed;
        }
        void auto_move()
        {
            y = y+5*System.Math.Cos(t * Math.PI/50);
            Canvas.SetLeft(this.b2, y);
        }

        void ball_move(double X_, double Y_,double K,double i)
        {
            bx = bx + X_*i;
            by = by + K* Y_ * i ;
            Canvas.SetLeft(this.ball, bx);
            Canvas.SetTop(this.ball,  by);           
        }
        DispatcherTimer timer = new DispatcherTimer();

        void drawBall()
        {   
            check_ball();
            check_points();
            ball_move(x_, y_, k, d);
        }
        void showMessage()
        {
            this.message.Visibility = Visibility.Visible;
            this.message.Content = "请发球";
        }
        
         void Button_Click(object sender, RoutedEventArgs e)
        {

            start();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TimeSpan.FromSeconds(0.1);   //设置刷新的间隔时间
            timer.Start();
         
        }
        void restart_click(object sender, RoutedEventArgs e)
        {
            GameWindow gwin = new GameWindow();
            gwin.Show();
            this.Close();
            this.Close();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            drawBall();
        }
        void check_points()
        {

            if (p1 >= 6)
            {
                state = false;
                message.Content = "you lost!";
                message.Visibility = Visibility.Visible;
                restart.Visibility = Visibility.Visible;
            }
            if (p2 >= 6)
            {
                state = false;
                message.Content = "you  won!";
                message.Visibility = Visibility.Visible;
                restart.Visibility = Visibility.Visible;
            }
           
        }
        void check_ball()
        {
            
            if (state == true)
            {
                if ((bx - b2_x) * (bx - b2_x) + (by - b2_y) * (by - b2_y) > 500)
                {
                    state = true;
                    
                       // time++;
                }
                if ((bx - b2_x) * (bx - b2_x) + (by - b2_y) * (by - b2_y) < 500)
                {
                    state = true;
                    //time++
                    d = -d;
                }
                if ((bx - x) * (bx - x) + (by - by1) * (by - by1) < 500)
                {
                   state = true;
                    //time++;
                    if (d == -1)
                    {
                        d = -d;

                    }   
                   }
                if (by < 50)
                {
                    this.ball.Visibility = Visibility.Collapsed;
                    p2++;
                    this.point2.Content = p2;
                    bx = x;
                    bx1 = x;

                    by1 = by = 400;
                    state = false;


                }
                if (by > 500)
                {
                    this.ball.Visibility = Visibility.Collapsed;
                    p1++;
                    this.point1.Content = p1;
                    bx = x;
                    bx1 = x;
                    by1 = by = 400;
                    state = false;
                }
            }
                if(state == false)
                {
                    showMessage();
                }
            
        }

        void start()
        {
            message.Visibility = Visibility.Collapsed;
            b2_x = Canvas.GetLeft(this.b2);
            b2_y = Canvas.GetTop(this.b2);
            this.ball.Visibility = Visibility.Visible;
            state = true;
            bx=bx1 = Canvas.GetLeft(this.b1);
            by=by1 = Canvas.GetTop(this.b1);
            bx2 = bx1 - 50;
            k = (by2 - by1) / (bx2 - bx1);
            x_= (bx2 - bx1) / 200;
            y_ = k * (bx2 - bx1)  / 200;
            d = 1;
            
        }
    }
   
}
