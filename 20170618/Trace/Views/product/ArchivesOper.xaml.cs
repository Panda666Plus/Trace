using Dapper;
using Microsoft.Win32;
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
using Trace.com.doone.trace.service;
using Trace.Common;

namespace Trace.Views.product
{
    /// <summary>
    /// Interaction logic for ArchivesOper.xaml
    /// </summary>
    public partial class ArchivesOper : Window
    {
        public int oper;

        private Archives _p;

        public ArchivesOper()
        {
            InitializeComponent();
        }

        public ArchivesOper(Archives arch)
        {
            InitializeComponent();
            this._p = arch;
        }

        #region 初始化数据
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RecordsService recordsService = new RecordsService();
            //企业信息选择
            List<dynamic> produceList = recordsService.queryProduce();
            produceId.ItemsSource = produceList;

            if (oper != -1)
            {
                ArchivesService ser = new ArchivesService();
                dynamic mod = ser.queryById(oper);

                this.productHid.Text = mod[0].CORP_PRODUCT_ID + "";
                this.productName.Text = mod[0].PRODUCT_NAME;
                this.produceId.SelectedValue = mod[0].PRODUCE_ID;
                this.orginDesc.Text = mod[0].ORIGIN_DESC;
                this.remark.Text = mod[0].REMARK;
                int _lb = Convert.ToInt32(mod[0].PRODUCT_SOURCE);
                if (_lb == 0)
                    this.rbA.IsChecked = true;
                else
                    this.rbB.IsChecked = true;
            }
            else
            {
                produceId.SelectedIndex = 0;
            }
        }
        #endregion

        #region 取消
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 新增
        private void doAdd_Click(object sender, RoutedEventArgs e)
        {
            DynamicParameters d = new DynamicParameters();
            d.Add("productName", productName.Text.Trim());
            d.Add("imageId", "");
            d.Add("produceId", produceId.SelectedValue);
            d.Add("productSource", getRadioVal());
            //MessageBox.Show(this.rbA.Uid);
            d.Add("orginDesc", orginDesc.Text.Trim());
            d.Add("remark", remark.Text.Trim());

            //缓存中获取企业id
            d.Add("enterpriseId", PubData.USER_ID_FIRST);

            ArchivesService archService = new ArchivesService();
            //新增
            if (oper == -1)
            {
                archService.doAdd(d);
                this.Close();
                MessageBox.Show("新增成功!");
            }
            else
            {
                d.Add("corpProductId", productHid.Text.Trim());
                //修改
                //archService.doModify(d);
                MessageBox.Show("修改成功!");
                this.Close();
            }
            //刷新父类窗口
            _p.initSearch();
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Forms.OpenFileDialog ofld = new System.Windows.Forms.OpenFileDialog();
            //if (ofld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    string text = ofld.FileName;
            //    //string s = System.IO.Path.GetFileNameWithoutExtension(ofld.FileName).ToString();
            //    if (text != "" || text != null)
            //    {
            //        this.tbPath.Text = text;
            //    }

            //}
        }

        private void btnSelectUrl_Click(object sender, RoutedEventArgs e)
        {

        }

        #region 获取RadioButton选中的值
        private int getRadioVal()
        {
            int _v = 0;
            if ((bool)rbA.IsChecked)
                _v = Convert.ToInt32(rbA.Uid);
            if ((bool)rbB.IsChecked)
                _v = Convert.ToInt32(rbB.Uid);
            return _v;
        }
        #endregion

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void MainWindow_MouseLefButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
