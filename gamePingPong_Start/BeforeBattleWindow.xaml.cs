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
using System.Windows.Shapes;

namespace gamePingPong_Start
{
    /// <summary>
    /// BattleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class BattleWindow : Window
    {
        public BattleWindow()
        {
            InitializeComponent();
            
        }
        int count = 0;
        private void dBox1_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            count++;
         
            if (count == 1)
            {
                dBox1.Content = "我是你的助手";
            }
            if (count == 2)
            {
                dBox1.Content = "A,D键控制牌子方位";
            }
            if (count == 3)
            {
                dBox1.Content = "鼠标点击发球";
            }
            if (count == 4)
            {
                dBox1.Content = "先到6分就取得胜利哟";
            }

            if ( count == 5)
            {
                dBox1.Content = "先来进行一场练习赛吧！";
                btn_yes.Visibility = Visibility.Visible;
                btn_yes.Content = "好的";
            }
        }
        private void click_yes(object sender, RoutedEventArgs e)
        {
            Battle battle = new Battle();
            battle.Show();
            battle.WindowStartupLocation = WindowStartupLocation.Manual;
            battle.Left = 200;
            battle.Top = 200;
            this.Close();
        }

    }
}
