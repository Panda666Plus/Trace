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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebBrowserOnTransparentWindow;

namespace Trace.Views.main
{
    /// <summary>
    /// Home.xaml 的交互逻辑
    /// </summary>
    public partial class Home : Page
    {
        private Main ParentFrame { get; set; }

        public Home()
        {
            InitializeComponent();
        }

        public Home(Main parent)
        {
            InitializeComponent();
            this.ParentFrame = parent;
        }

        private void btnTraceFile_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Zsda_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Console.Write("进入追朔档案管理界面");
            ParentFrame.ShowFrame("ProductFrame");
        }

        private void ButtonZhuis_Click(object sender, RoutedEventArgs e)
        {
            Console.Write("进入追朔档案管理界面");
            ParentFrame.ShowFrame("ProductFrame");
        }

        private void RightBottomButton_Click(object sender, RoutedEventArgs e)
        {
            ParentFrame.ShowRightMenu();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            ParentFrame.ShowLeftMenu();
        }

        public void HideHomeChart()
        {
            // 隐藏主界面图表浏览器
            webOverlay.Form.Visible = false;
        }

        public void ShowHomeChart()
        {
            // 显示主界面图表浏览器
            webOverlay.Form.Visible = true;
        }

        private WebBrowserOverlayWF webOverlay = null;
        private System.Windows.Forms.WebBrowser webForm = null;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            webOverlay = new WebBrowserOverlayWF(this.body_web);
            webForm = webOverlay.WebBrowser;
            webForm.Navigate(new Uri("http://59.173.8.184:20081/trace/wap/cs/home"));
            webForm.ScrollBarsEnabled = false;
            webForm.ObjectForScripting = new HandleScript();
        }

        [System.Runtime.InteropServices.ComVisibleAttribute(true)]
        public partial class HandleScript
        {
            public void AddSong(string musicInfo)
            {
                MessageBox.Show(musicInfo, "AddSong");
            }
        }


    }
}
