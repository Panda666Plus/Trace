using DotNet4.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trace.com.doone.trace.service;
using Trace.Views.main;
using Trace.com.doone.trace.service;

namespace Trace
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {

        public static string USER_NAME_HIT = "请输入用户名";

        public Login()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                InitializeComponent();   
               // txtUser.Focus();                 
            }));
        }

        private void txtUser_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUser.Clear();
        }

        private void txtPasw_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtPassWord.Background = null as Brush;
            TxtPassWord.Clear();

        }
      
        public void Login1_Loaded(object sender, RoutedEventArgs e)
        {
                      
            string userandpwd = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "account.txt");
            userandpwd = Regex.Replace(userandpwd, @"\s", "");
            if (userandpwd != string.Empty)
            {
                userandpwd = LoginService.DecryptDES(userandpwd, "ab123456");
                var strs = userandpwd.Split(new string[] { "----" }, StringSplitOptions.RemoveEmptyEntries);

                if (Convert.ToBoolean(strs[2]))
                {
                    txtUser.Text = strs[0];
                    TxtPassWord.Password = strs[1];
                    TxtPassWord.Password = strs[1];
                }
                chbPassWord.IsChecked = Convert.ToBoolean(strs[2]);
            }

            //progressbar1.Maximum = 100;
            //Thread t = new Thread(new ThreadStart(Show_ProgressBar));
            //t.Start();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            PasswordBox sdf = new PasswordBox();
            TextBox badf = new TextBox();

            // TxtPassWord.Background = TxtPassWord.Resources["HelpBrush"] as Brush;
            // TxtPassWord.Background = null as Brush; 
            if (Convert.ToBoolean(chbPassWord.IsChecked) == true)
            {
                TxtPassWord.Background = null as Brush;
            }
            else
            {
                TxtPassWord.Background = TxtPassWord.Resources["HelpBrush"] as Brush;
            }
           
        }

        private void Login1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private async void imgbtnLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (txtUser.Text.Trim().Equals("") || USER_NAME_HIT.Equals(txtUser.Text.Trim()))
            {
                MessageBox.Show("请输入用户名！");
                //MsgTip.Visibility = Visibility.Visible;
                //MsgTipLabel.Content = "请输入用户名！";
                txtUser.Focus();
                return;
            }
            if (TxtPassWord.Password.Trim() == "")
            {
                MessageBox.Show("请输入密码！");
                TxtPassWord.Focus();
                return;
            }
            // 容器隐藏
            Login2.Visibility = Visibility.Hidden;
            Login3.Visibility = Visibility.Visible;
            progressbar1.Visibility = Visibility.Visible;

                new Thread(() =>
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        LoginService loginService = new LoginService();
                        JObject j1 = loginService.login(txtUser.Text.Trim(), TxtPassWord.Password.Trim());
                        Main mainView = new Main();
                        mainView.Show();
                        this.Close();
                    }));
                }).Start();
            }));
        }

        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtPassWord.Password))
            {
                // TxtPassWord.Background = TxtPassWord.Resources["HelpBrush"] as Brush;
                TxtPassWord.Background = null as Brush;
            }
            else
            {
                TxtPassWord.Background = new SolidColorBrush(Color.FromArgb(1, 54, 34, 25));
            }

        }

        #region 关闭
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Close();
        }
        #endregion

        #region Enter 事件
        private void TxtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (e.Key == Key.Enter)
            {
                imgbtnLogin_Click(sender, e);
            }

            }));
        }

        #endregion

      
    }
}
