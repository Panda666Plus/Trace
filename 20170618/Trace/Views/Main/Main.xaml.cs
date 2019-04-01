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
using Trace.Views.product;

namespace Trace.Views.main
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Home HomeFrame = new Home(this);
            MainFrame.Navigate(HomeFrame);

            RightMenu rightMenuFrame = new RightMenu(this);
            FunctionFrame.Navigate(rightMenuFrame);

            Archives archivesFrame = new Archives(this);
            ProductFrame.Navigate(archivesFrame);

            LeftMenu leftMenuFrame = new LeftMenu(this);
            UserFrame.Navigate(leftMenuFrame);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if(MainFrame.Visibility == Visibility.Visible)
            {
                // 如果是主界面则提示是否退出程序
                if (MessageBox.Show("您确定要退出程序吗?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    System.Environment.Exit(System.Environment.ExitCode);
                    this.Close();
                }
            }
            else
            {
                ShowFrame("HomeFrame");
            }
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void MainWindow_MouseLefButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void ShowFrame(string frmName)
        {
            // 切换菜单
            if(frmName == "ProductFrame")
            {
                HideHomePage();
                FunctionFrame.Visibility = Visibility.Hidden;

                ProductFrame.Visibility = Visibility.Visible;
            }
            else if (frmName == "HomeFrame")
            {
                ProductFrame.Visibility = Visibility.Hidden;
                FunctionFrame.Visibility = Visibility.Hidden;

                ShowHomePage();
            }      
        }

        public static Boolean ShowRightView = false;
        public static Boolean ShowLeftView = false;

        public void ShowHomePage()
        {
            MainFrame.Visibility = Visibility.Visible;
            Home home = (Home)MainFrame.Content;
            home.ShowHomeChart();
        }

        public void HideHomePage()
        {
            MainFrame.Visibility = Visibility.Hidden;
            Home home = (Home)MainFrame.Content;
            home.HideHomeChart();
        }

        public void ShowRightMenu()
        {
            // 显示右侧功能菜单
            if (ShowRightView == true)
            {
                FunctionFrame.Visibility = Visibility.Hidden;
                ShowRightView = false;
                Home home = (Home)MainFrame.Content;
                home.ShowHomeChart();
            }
            else
            {
                FunctionFrame.Visibility = Visibility.Visible;
                ShowRightView = true;
                Home home = (Home)MainFrame.Content;
                home.HideHomeChart();
            }
        }

        public void ShowLeftMenu()
        {
            // 显示左侧用户信息
            if (ShowLeftView == true)
            {
                UserFrame.Visibility = Visibility.Hidden;
                ShowLeftView = false;
                Home home = (Home)MainFrame.Content;
                home.ShowHomeChart();
            }
            else
            {
                UserFrame.Visibility = Visibility.Visible;
                ShowLeftView = true;
                Home home = (Home)MainFrame.Content;
                home.HideHomeChart();
            }
        }

        private void RightBottomButton_Click(object sender, RoutedEventArgs e)
        {
            if(ShowRightView == true)
            {
                FunctionFrame.Visibility = Visibility.Hidden;
                ShowRightView = false;
            }
            else
            {
                FunctionFrame.Visibility = Visibility.Visible;
                ShowRightView = true;
            }
            
        }
    }
}
