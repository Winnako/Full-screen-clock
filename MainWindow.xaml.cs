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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace 屏上时钟
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer(); //定义时钟
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromMilliseconds(10); //设置timer周期时间
            timer.Tick += tmTick; //设置timer触发
            timer.Start(); //启动timer
            if(File.Exists(@"C:\Users\Public\Documents\clock.clk") == true) //判断文件是否存在
            {
                var close = (Storyboard)FindResource("wincl"); //播放动画wincl
                close.Begin();
            }
        }

        private void tmTick(object sender, EventArgs e)
        {
            if(lsc == false)
            {
                time.Text = System.DateTime.Now.ToString("T");//获取长时间 00:00:00
            }
            else
            {
                time.Text = System.DateTime.Now.ToString("t");//获取短时间 00:00
            }
        }

        bool setting = false; //布尔 设置 打开状况 关
        private void Settings(object sender, RoutedEventArgs e)
        {
            //设定按钮单击时
            if(setting == false)
            {
                var setop = (Storyboard)FindResource("setop"); //播放动画setop
                setop.Begin();
                setting = true;
            }
            else
            {
                var setcl = (Storyboard)FindResource("setcl"); //播放动画setcl
                setcl.Begin();
                setting = false;
            }
        }
        bool lsc = false; //长短时间,true为短,false为长
        private void ltstc(object sender, RoutedEventArgs e)
        {
            if(lsc == false)
            {
                var right = (Storyboard)FindResource("right"); //播放动画right
                right.Begin();
                lsc = true;
            }
            else
            {
                var left = (Storyboard)FindResource("left"); //播放动画left
                left.Begin();
                lsc = false;
            }
        }

        private void eixt(object sender, RoutedEventArgs e)
        {
            this.Close(); //关闭窗口
        }

        private void fsap(object sender, RoutedEventArgs e)
        {
            int size = int.Parse(fontsize.Text);
            time.FontSize = size; //应用time的字体大小为用户所提供的值
        }

        private void sd(object sender, RoutedEventArgs e)
        {
            var sdan = (Storyboard)FindResource("sdan"); //播放动画sdan
            sdan.Begin();
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F12) //判断按下的案件是否为F12
            {
                var dean = (Storyboard)FindResource("dean"); //播放动画dean
                dean.Begin();
            }
        }

        private void winbut(object sender, RoutedEventArgs e)
        {
            File.WriteAllText(@"C:\Users\Public\Documents\clock.clk", "屏上时钟储存文件,用于判断是否为第一次进入。");
            var close = (Storyboard)FindResource("wincl"); //播放动画wincl
            close.Begin();
        }
    }
}
