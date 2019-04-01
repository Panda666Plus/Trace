using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Trace;

namespace Load
{
	/// <summary>
	/// Window1.xaml 的交互逻辑
	/// </summary>
	public partial class Animation : Window
	{
		public Animation()
		{
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.InitializeComponent();
            this.Loaded += Animation_Loaded;
                // 在此点之下插入创建对象所需的代码。
            }));
        }

        private void Animation_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Loaded;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
            isOk = IsNetWork();
        }
        bool isOk = false;
        DispatcherTimer timer = new DispatcherTimer();
        int i = 0;
        private void Timer_Loaded(object sender, EventArgs e)
        {
            i++;
            if (i>2)
            {
                if (isOk)
                {
                    text.Text = "网络正常,正在跳转登录......";   
                    text.Foreground = Brushes.FloralWhite;
                    border.Child = text;
                    if (i < 4) return;
                    timer.Stop();
                    this.Hide();
                    Login login = new Login();
                    login.Show();

                }
                 else
                {
                    text.Text ="网络错误，请检查您的网络，程序正在退出...";
                    text.Foreground = Brushes.Red;
                    border.Child = text;
                    if (i < 4) return;               
                    this.Close();
                }


            }

         
        }

        TextBlock text = new TextBlock();

        public bool IsNetWork()
        {
           

            string url = "www.baidu.com";
            System.Net.NetworkInformation.Ping ping;
            System.Net.NetworkInformation.PingReply res;
            ping = new System.Net.NetworkInformation.Ping();
            try
            {
                res = ping.Send("www.baidu.com");

                if (res.Status == IPStatus.Success)
                {
                 
                    return true;
                }
                else
                {
    
                    return false;
                }



            }
            catch (Exception)
            {
                return false;
            }

        }


    }
}