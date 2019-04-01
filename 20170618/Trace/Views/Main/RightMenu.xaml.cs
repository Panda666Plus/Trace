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

namespace Trace.Views.main
{
    /// <summary>
    /// RightMenu.xaml 的交互逻辑
    /// </summary>
    public partial class RightMenu : Page
    {
        private Main ParentFrame { get; set; }
        public RightMenu()
        {
            InitializeComponent();
        }

        public RightMenu(Main parent)
        {
            InitializeComponent();
            this.ParentFrame = parent;
        }

        private void ProductButton_Click(object sender, RoutedEventArgs e)
        {
            ParentFrame.ShowFrame("ProductFrame");
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ParentFrame.ShowFrame("HomeFrame");
        }
    }
}
