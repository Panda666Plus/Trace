using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
using Trace.common;
using Trace.Views.product;

namespace Trace.Views.batch
{
    /// <summary>
    /// Interaction logic for BatchOper.xaml
    /// </summary>
    public partial class BatchOper : Window
    {
        public int id;
        private Archives parent;

        public dynamic batch;

        public BatchOper()
        {
            InitializeComponent();
        }

        public BatchOper(Archives arc)
        {
            InitializeComponent();
            this.parent = arc;
        }

        #region 农残检测查询历史记录
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //加载历史记录
            BatchService ser = new BatchService();
            //DataTable data = ser.queryQualitys(id);
            //if (data.Rows.Count > 0)
            //{
            //    dataGrid.ItemsSource = data.DefaultView;
            //}

            //加载编辑的数据
            if (batch != null)
            {
                this.Title = "编辑批次";
                qualityAdd.Content = "修改";//编辑按钮名称
                harvestAdd.Content = "修改";//编辑按钮名称
                salesAdd.Content = "修改";//编辑按钮名称

                //写表单数据吧
                //MessageBox.Show("ok"+batch[0].PRODUCTION_ID);
                hproId.Text = batch[0].PRODUCTION_ID + "";
                string chkMd = batch[0].CHECK_MODE + "";
                if ("Q01".Equals(chkMd))
                {
                    rbZ.IsChecked = true;
                }
                else
                {
                    rbS.IsChecked = true;
                }
                string qltRe = batch[0].QUALITY_RESULT;
                if ("Y".Equals(qltRe))
                {
                    qrY.IsSelected = true;
                }
                else
                {
                    qrN.IsSelected = true;
                }
                this.checkItemVal.Text = batch[0].CHECK_ITEM_VALUE + "";

                this.checkPerson.Text = batch[0].CHECK_PERSON + "";
                this.checkDate.Text = batch[0].CHECK_DATE + "";

                this.harvestDate.Text = batch[0].HARVEST_DATE + "";
                this.harvestAmout.Text = batch[0].HARVEST_AMOUNT + "";

                string hau = batch[0].HARVEST_AMOUNT_UNIT + "";
                if ("U01".Equals(hau))
                {
                    hUnitX.IsSelected = true;
                }
                else
                {
                    hUnitY.IsSelected = true;
                }

                this.salesDate.Text = batch[0].SALES_DATE + "";

                var st = batch[0].SALES_TYPE + "";
                if ("S01".Equals(st))
                {
                    rbSaleA.IsChecked = true;
                }
                if ("S02".Equals(st))
                {
                    rbSaleB.IsChecked = true;
                }
                if ("S03".Equals(st))
                {
                    rbSaleC.IsChecked = true;
                }

                var smpt = batch[0].SAMPLE_TYPE;//采样方式
                if ("S01".Equals(smpt))
                {
                    sp01.IsChecked = true;
                }
                if ("S02".Equals(smpt))
                {
                    sp02.IsChecked = true;
                }
                if ("S03".Equals(smpt))
                {
                    sp03.IsChecked = true;
                }
                if ("S04".Equals(smpt))
                {
                    sp04.IsChecked = true;
                }
                var queRlt = batch[0].QUALITY_RESULT + "";
                if ("1".Equals(queRlt))
                {
                    qrY.IsSelected = true;
                }
                else
                {
                    qrN.IsSelected = true;
                }
                this.buyUnit.Text = batch[0].BUY_UNIT + "";
                this.contactWay.Text = batch[0].CONTACT_WAY + "";
                this.loco.Text = batch[0].LOCO + "";

            }
        }
        #endregion

        #region 农残检测 
        private void qualityCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void qualityAdd_Click(object sender, RoutedEventArgs e)
        {
            DynamicParameters d = getParameters();

            BatchService ser = new BatchService();
            if ("".Equals(hproId.Text))
            {
                BatchService ser2 = new BatchService();
                dynamic codeData = ser2.queryEnterAndProduceCode(id);
                //获取厂商识别码与物品识别码   根据规则生成追溯码
                string zsCode = Tools.getQrcodeRule(codeData[0].ENTERPRISE_CODE, codeData[0].PRODUCE_CODE);
                d.Add("productionCode", zsCode);//追溯码生成

                //1、新增production and quality
                int productionId = ser.doAddProduction(d);//返回productionId

                //4、提示新增成功
                if (productionId > 0)
                {
                    MessageBox.Show("新增成功！");
                    this.Close();
                }
            }
            else
            {

                d.Add("productionId", hproId.Text);
                d.Add("qualityId", batch[0].QUALITY_ID);
                ser.doEditProduction(d);
                MessageBox.Show("修改成功！");
                this.Close();
            }

        }
        #endregion

        #region 采收 提交
        private void harvestCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void harvestAdd_Click(object sender, RoutedEventArgs e)
        {
            DynamicParameters d = getParameters();

            BatchService ser = new BatchService();
            if (!"".Equals(hproId.Text))
            {

                d.Add("productionId", hproId.Text);
                if (ser.doUpdHarvest(d))
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
            }
            else
            {
                BatchService ser2 = new BatchService();
                dynamic codeData = ser2.queryEnterAndProduceCode(id);
                //获取厂商识别码与物品识别码   根据规则生成追溯码
                string zsCode = Tools.getQrcodeRule(codeData[0].ENTERPRISE_CODE, codeData[0].PRODUCE_CODE);
                d.Add("productionCode", zsCode);//追溯码生成

                //1、新增production and quality
                int productionId = ser.doAddProduction(d);//返回productionId
                //2、更新采收harvest_date harvest_amount 根据production_id
                d.Add("productionId", productionId);
                ser.doUpdHarvest(d);
                //3、新增销售去向 包括production_id
                ser.doAddSales(d);
                //4、提示新增成功
                if (productionId > 0)
                {
                    MessageBox.Show("新增成功！");
                    this.Close();
                }
            }

        }
        #endregion

        #region 销售去向 提交
        private void salesCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void salesAdd_Click(object sender, RoutedEventArgs e)
        {
            DynamicParameters d = getParameters();

            BatchService ser = new BatchService();
            if (!"".Equals(hproId.Text))
            {

                d.Add("productionId", hproId.Text);
                if (ser.doUpdSales(d))
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                }
            }
            else
            {
                BatchService ser2 = new BatchService();
                dynamic codeData = ser2.queryEnterAndProduceCode(id);
                //获取厂商识别码与物品识别码   根据规则生成追溯码
                string zsCode = Tools.getQrcodeRule(codeData[0].ENTERPRISE_CODE, codeData[0].PRODUCE_CODE);
                d.Add("productionCode", zsCode);//追溯码生成

                //1、新增production and quality
                int productionId = ser.doAddProduction(d);//返回productionId
                //2、更新采收harvest_date harvest_amount 根据production_id
                d.Add("productionId", productionId);
                ser.doUpdHarvest(d);
                //3、新增销售去向 包括production_id
                ser.doAddSales(d);
                //4、提示新增成功
                if (productionId > 0)
                {
                    MessageBox.Show("新增成功！");
                    this.Close();
                }
            }
        }
        #endregion

        #region 动态参数
        private DynamicParameters getParameters()
        {
            DynamicParameters d = new DynamicParameters();
            //质量检测参数  start
            d.Add("sampleType", getSampleTypeVal());
            d.Add("checkMode", getCheckModeVal());
            d.Add("checkItemValue", checkItemValue.Tag);
            d.Add("checkItemVal", checkItemVal.Text.Trim());//检测值
            ComboBoxItem item = qualityResult.SelectedItem as ComboBoxItem;
            d.Add("qualityResult", item.Tag);
            d.Add("checkPerson", checkPerson.Text.Trim());
            d.Add("checkDate", Convert.ToDateTime(checkDate.Text).ToString("yyyy-MM-dd"));
            d.Add("corpProductId", id);
            //质量检测参数 end

            //采收参数 start
            d.Add("harvestDate", Convert.ToDateTime(harvestDate.Text).ToString("yyyy-MM-dd"));
            d.Add("harvestAmout", harvestAmout.Text.Trim());
            ComboBoxItem item1 = harvestAmountUnit.SelectedItem as ComboBoxItem;
            d.Add("harvestAmountUnit", item1.Tag);
            //d.Add("productionId", hproId.Text.Trim());
            //采收参数 end

            //销售去向参数 start
            d.Add("salesDate", Convert.ToDateTime(salesDate.Text).ToString("yyyy-MM-dd"));
            d.Add("salesType", getSalesTypeVal());
            d.Add("buyUnit", buyUnit.Text.Trim());
            d.Add("contactWay", contactWay.Text.Trim());
            d.Add("loco", loco.Text.Trim());
            //d.Add("productionId", hproId.Text);
            //销售去向参数 end
            return d;
        }
        #endregion

        #region 获取检测模式RadioButton选中的值
        private string getCheckModeVal()
        {
            string _v = "";
            if ((bool)rbZ.IsChecked)
                _v = rbZ.Uid;
            if ((bool)rbS.IsChecked)
                _v = rbS.Uid;
            return _v;
        }
        #endregion

        #region 获取销售方式RadioButton选中的值
        private string getSalesTypeVal()
        {
            string _v = "";
            if ((bool)rbSaleA.IsChecked)
                _v = rbSaleA.Uid;
            if ((bool)rbSaleB.IsChecked)
                _v = rbSaleB.Uid;
            if ((bool)rbSaleC.IsChecked)
                _v = rbSaleC.Uid;
            return _v;
        }
        #endregion

        #region 获取采样方式RadioButton选中的值
        private string getSampleTypeVal()
        {
            string _v = "";
            if ((bool)sp01.IsChecked)
                _v = sp01.Uid;
            if ((bool)sp02.IsChecked)
                _v = sp02.Uid;
            if ((bool)sp03.IsChecked)
                _v = sp03.Uid;
            if ((bool)sp04.IsChecked)
                _v = sp04.Uid;
            return _v;
        }
        #endregion

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //e.Row.GetIndex() + 1
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void MainWindow_MouseLefButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
