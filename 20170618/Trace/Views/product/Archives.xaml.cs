using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using ThoughtWorks.QRCode.Codec;
using Trace.com.doone.trace.model;
using Trace.com.doone.trace.service;
using Trace.Views.batch;
using Trace.Views.dangan;
using Trace.Views.main;
using Trace.Views.productMaintenance;
using Trace.ViewsModel;

namespace Trace.Views.product
{
    /// <summary>
    /// Interaction logic for Archives.xaml
    /// </summary>
    public partial class Archives : Page
    {
        //-----分页变量-----//
        private int pageIndex = 0;
        private DataTable dt;
        //private Myobjcts newObject = null;
        //-----分页变量-----//
        private Main ParentFrame { get; set; }

        public Archives()
        {
            InitializeComponent();
        }

        public Archives(Main parent)
        {
            InitializeComponent();
            this.ParentFrame = parent;
        }

        #region 初始化ListBox数据
        public void initSearch()
        {
            LoadData2(1, 1000);
        }
        #endregion

        #region 点击查询按钮
        private void search_Click(object sender, RoutedEventArgs e)
        {
            this.initSearch();
        }
        #endregion

        #region 弹出新增档案窗口
        private void xjBtn_Click(object sender, RoutedEventArgs e)
        {
            ArchivesOper oper = new ArchivesOper(this);
            oper.oper = -1;
            oper.ShowDialog();
        }
        #endregion

        #region 弹出编辑窗口
        private void btnWh_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ProductMaintenance pm = new ProductMaintenance();
            pm.id = Convert.ToInt32(btn.Tag.ToString());
            pm.ShowDialog();
            //MessageBox.Show(btn.Tag.ToString());

            //ArchivesOper oper = new ArchivesOper(this);
            //oper.oper = Convert.ToInt32(btn.Tag.ToString());
            //oper.ShowDialog();
        }
        #endregion

        #region 删除产品档案
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Tag.ToString());
            if (btn.Tag != null)
            {
                if (MessageBox.Show("您确定要删除吗?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //执行删除操作
                    //ArchivesService ser = new ArchivesService();
                    //if (ser.delBatch(btn.Tag.ToString()))
                    //{
                    //    this.initSearch();
                    //    MessageBox.Show("删除成功!");
                    //}

                }
            }
        }
        #endregion

        #region 分页加载数据

        private int LoadData2(int pageNo, int pageSize)
        {
            string productName = productNameKey.Text.Trim();
            string startDate = "";
            string endDate = "";

            ArchivesService ser = new ArchivesService();
            ObservableCollection<Product> listViewData = ser.queryArchives(productName, startDate, endDate, pageNo, pageSize);
            listBox.ItemsSource = listViewData;
            return 1000;
        }
        #endregion

        #region dataGrid展开折叠
        private bool isSp00 = true;
        private bool isSp10 = true;
        private bool isSp20 = true;
        private void btnXl_Click00(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(sender.ToString());
            ToggleButton button = (ToggleButton)sender;
            
            //if (isSp00)
            //{
            //    int corpId = Convert.ToInt32(btnXl.Tag);
            //    BatchService ser = new BatchService();
            //    DataTable dt = ser.queryBatchRecord(corpId);
            //    this.dataGrid00.ItemsSource = dt.DefaultView;

            //    sp00.Visibility = Visibility.Visible;
            //    isSp00 = false;
            //}
            //else
            //{
            //    sp00.Visibility = Visibility.Collapsed;
            //    isSp00 = true;
            //}
        }

        private void btnXl_Click10(object sender, RoutedEventArgs e)
        {
            //if (isSp10)
            //{
            //    int corpId = Convert.ToInt32(btnXl1.Tag);
            //    //MessageBox.Show(btnXl1.Tag+"");
            //    BatchService ser = new BatchService();
            //    DataTable dt = ser.queryBatchRecord(corpId);
            //    this.dataGrid10.ItemsSource = dt.DefaultView;

            //    sp10.Visibility = Visibility.Visible;
            //    isSp10 = false;
            //}
            //else
            //{
            //    sp10.Visibility = Visibility.Collapsed;
            //    isSp10 = true;
            //}
        }

        private void btnXl_Click20(object sender, RoutedEventArgs e)
        {
            //if (isSp20)
            //{
            //    int corpId = Convert.ToInt32(btnXl2.Tag);
            //    //MessageBox.Show(corpId+"");
            //    BatchService ser = new BatchService();
            //    DataTable dt = ser.queryBatchRecord(corpId);
            //    this.dataGrid20.ItemsSource = dt.DefaultView;

            //    sp20.Visibility = Visibility.Visible;
            //    isSp20 = false;
            //}
            //else
            //{
            //    sp20.Visibility = Visibility.Collapsed;
            //    isSp20 = true;
            //}
        }
        #endregion

        #region 创建批次
        private void btnBatch_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int corpProductId = Convert.ToInt32(btn.Tag);

            BatchOper win = new BatchOper(this);
            win.id = corpProductId;
            win.Show();
        }
        #endregion

        #region 查看二维码
        private void view_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            MessageBox.Show(btn.Tag+"");
        }
        #endregion

        #region 删除production
        private void productionDel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Tag + "");
            if (MessageBox.Show("您确定要删除吗?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BatchService ser = new BatchService();
                int productionId = Convert.ToInt32(btn.Tag);
                //if (ser.delProduction(productionId))
                //{
                //    MessageBox.Show("删除成功！");

                //    int corpId = Convert.ToInt32(btn.Uid);
                //    BatchService ser2 = new BatchService();
                //    DataTable dt = ser2.queryBatchRecord(corpId);
                //    //this.dataGrid00.ItemsSource = dt.DefaultView;
                //}
            }
        }

        private void productionDel_Click1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("您确定要删除吗?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BatchService ser = new BatchService();
                int productionId = Convert.ToInt32(btn.Tag);
                if (ser.delProduction(productionId))
                {
                    MessageBox.Show("删除成功！");

                    int corpId = Convert.ToInt32(btn.Uid);
                    BatchService ser2 = new BatchService();
                   // DataTable dt = ser2.queryBatchRecord(corpId);
                    //this.dataGrid10.ItemsSource = dt.DefaultView;
                }
            }
        }

        private void productionDel_Click2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (MessageBox.Show("您确定要删除吗?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                BatchService ser = new BatchService();
                int productionId = Convert.ToInt32(btn.Tag);
                if (ser.delProduction(productionId))
                {
                    MessageBox.Show("删除成功！");

                    int corpId = Convert.ToInt32(btn.Uid);
                    BatchService ser2 = new BatchService();
                   // DataTable dt = ser2.queryBatchRecord(corpId);
                    //this.dataGrid20.ItemsSource = dt.DefaultView;
                }
            }
        }
        #endregion

        #region  编辑production
        private void productionEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            //BatchService ser = new BatchService();
            int productionId = Convert.ToInt32(btn.Tag);
            int corpId = Convert.ToInt32(btn.Uid);

        //  pm.id = Convert.ToInt32(btn.Tag.ToString());
            BatchService serv = new BatchService();
            dynamic dy = serv.queryProductionById(productionId);

            BatchOper oper = new BatchOper(this);
            oper.id = corpId;
            oper.batch = dy;
            oper.Show();

        }

        private void productionEdit_Click1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            BatchService ser = new BatchService();
            int productionId = Convert.ToInt32(btn.Tag);
            int corpId = Convert.ToInt32(btn.Uid);

            BatchService serv = new BatchService();
            dynamic dy = serv.queryProductionById(productionId);

            //BatchOper oper = new BatchOper(this);
            //oper.id = corpId;
            //oper.batch = dy;
            //oper.Show();
        }

        private void productionEdit_Click2(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            BatchService ser = new BatchService();
            int productionId = Convert.ToInt32(btn.Tag);
            int corpId = Convert.ToInt32(btn.Uid);

            BatchService serv = new BatchService();
            dynamic dy = serv.queryProductionById(productionId);

            //BatchOper oper = new BatchOper(this);
            //oper.id = corpId;
            //oper.batch = dy;
            //oper.Show();

        }
        #endregion

        #region 查看二维码
        private void btnQrcode_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string qcode = btn.Tag+"";
            string corProductId = btn.Uid + "";
            QrcodePage qp = new QrcodePage();
            qp.param = qcode;
            qp.produceId = corProductId;
            qp.ShowDialog();
          
        }
        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData2(1, 1000);
        }


        private void BatchButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // 批次列表显示
            StackPanel bacthPanel = (StackPanel)sender;
            StackPanel bacthPanel1 = (StackPanel) bacthPanel.Parent;
            StackPanel bacthPanel2 = (StackPanel)bacthPanel1.Parent;
            StackPanel bacthPanel3 = (StackPanel)bacthPanel2.Parent;
            ListBoxItem item = (ListBoxItem)bacthPanel3.Parent;
            int corpId = Convert.ToInt32(item.Tag);
            //MessageBox.Show("==Tag==" + corpId);
            StackPanel panel = (StackPanel) item.FindName("sp00");
            Image Arrow2 = (Image)item.FindName("Arrow2");
            Image Arrow1 = (Image)item.FindName("Arrow1");
            if (panel.Visibility == Visibility.Collapsed)
            {
                panel.Visibility = Visibility.Visible;
                Arrow2.Visibility = Visibility.Visible;
                Arrow1.Visibility = Visibility.Collapsed;
                DataGrid grid = (DataGrid)item.FindName("DetailGrid");
                if (corpId != null)
                {
                    BatchService ser = new BatchService();
                    //DataTable dt = ser.queryBatchRecord(corpId);
                    grid.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                panel.Visibility = Visibility.Collapsed;
                Arrow1.Visibility = Visibility.Visible;
                Arrow2.Visibility = Visibility.Collapsed;
            }
        }


        public void CopyObject(int indexs)
        {
            //if (dt.Rows.Count <= 0) return;
            //App.ObjectList.Clear();

            //for (int i = indexs; i < dt.Rows.Count; i++)
            //{
            //    App.ObjectList.Add(new Myobjcts() { HARVEST_DATE = dt.Rows[i]["HARVEST_DATE"].ToString(), PRODUCTION_CODE = dt.Rows[i]["PRODUCTION_CODE"].ToString(), PRODUCTION_CODEs = dt.Rows[i]["PRODUCTION_CODE"].ToString(), PRODUCTION_ID = Convert.ToInt32(dt.Rows[i]["PRODUCTION_ID"]) });
            //}


        }

        //首页
        private void firstPageBtn_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 0;
            CopyObject(pageIndex);
        }
        //上一页
        private void prePageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex > 0)
            {
                pageIndex = (pageIndex - 1);
                CopyObject(pageIndex * 2);
            }
        }
        //下一页
        private void nextPageBtn_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = (pageIndex + 1);
            CopyObject(pageIndex * 2);
        }
        //末页
        private void lastPageBtn_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = (pageIndex + 1);
            CopyObject(pageIndex * 2);
        }
        //前往
        private void gotoBtn_Click(object sender, RoutedEventArgs e)
        {
            TextBox txb = (TextBox)this.FindName("gototext");
            pageIndex = Convert.ToInt32(txb.Text) * 2;
            CopyObject(pageIndex);
        }
    }

}
