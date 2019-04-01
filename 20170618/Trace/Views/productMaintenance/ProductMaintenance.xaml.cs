using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Trace.com.doone.trace.service;
using System.Data;
using Dapper;
using Trace.Common;
using System.IO;

namespace Trace.Views.productMaintenance
{

/*
     Author: wushenghu
     Time: June 21, 2017
     E-mail: sheng-hu.wu @doone.com.cn
*/

    public partial class ProductMaintenance : Window
    {
        public int id;
        public dynamic batch;
        public ProductMaintenance()
        {
            InitializeComponent();
        }

        #region 初始化页面
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            RecordsService recordsService = new RecordsService();
            //企业信息选择
            List<dynamic> produceList = recordsService.queryProduce();
            produceId.ItemsSource = produceList;

            ArchivesService ser = new ArchivesService();
            dynamic mod = ser.queryById(id);

            this.hproId.Text = mod[0].CORP_PRODUCT_ID + "";
            this.productName.Text = mod[0].PRODUCT_NAME;
            this.produceId.SelectedValue = mod[0].PRODUCE_ID;
            this.orginDesc.Text = mod[0].ORIGIN_DESC;
            this.txtRemark.Text = mod[0].REMARK;

            initFertData(Convert.ToInt32(mod[0].PRODUCE_ID));

            initPestData(Convert.ToInt32(mod[0].PRODUCE_ID));
              //Console.Write("======" + id);
            //66西红柿 67黄瓜 69马铃薯 68小白菜
            if (66.Equals(id))
            {
               // BigImage.Visibility = Visibility.Visible;
                //BigImage1.Visibility = Visibility.Collapsed;
                //BigImage2.Visibility = Visibility.Collapsed;
                //BigImage3.Visibility = Visibility.Collapsed;

                //btn_01.Visibility = Visibility.Collapsed;
                //btn_01_1.Visibility = Visibility.Visible;
                //btn_01_2.Visibility = Visibility.Collapsed;
                //btn_01_3.Visibility = Visibility.Collapsed;

                //btn_02.Visibility = Visibility.Visible;
                //btn_02_01.Visibility = Visibility.Collapsed;
                //btn_02_02.Visibility = Visibility.Collapsed;
                //btn_02_03.Visibility = Visibility.Collapsed;
            }
            if (67.Equals(id))
            {
               // BigImage.Visibility = Visibility.Collapsed;
                //BigImage1.Visibility = Visibility.Collapsed;
                //BigImage2.Visibility = Visibility.Collapsed;
                //BigImage3.Visibility = Visibility.Visible;

                //btn_01.Visibility = Visibility.Collapsed;
                //btn_01_1.Visibility = Visibility.Collapsed;
                //btn_01_2.Visibility = Visibility.Collapsed;
                //btn_01_3.Visibility = Visibility.Visible;

                //btn_02.Visibility = Visibility.Collapsed;
                //btn_02_01.Visibility = Visibility.Collapsed;
                //btn_02_02.Visibility = Visibility.Collapsed;
                //btn_02_03.Visibility = Visibility.Visible;

            }
            if (69.Equals(id))
            {
               // BigImage.Visibility = Visibility.Collapsed;
                //BigImage1.Visibility = Visibility.Visible;
                //BigImage2.Visibility = Visibility.Collapsed;
                //BigImage3.Visibility = Visibility.Collapsed;

                //btn_01.Visibility = Visibility.Visible;
                //btn_01_1.Visibility = Visibility.Collapsed;
                //btn_01_2.Visibility = Visibility.Collapsed;
                //btn_01_3.Visibility = Visibility.Collapsed;

                //btn_02.Visibility = Visibility.Collapsed;
                //btn_02_01.Visibility = Visibility.Visible;
                //btn_02_02.Visibility = Visibility.Collapsed;
                //btn_02_03.Visibility = Visibility.Collapsed;

                //btn_03.Visibility = Visibility.Visible;
                //btn_03_01.Visibility = Visibility.Visible;

            }
            if (68.Equals(id))
            {
               // BigImage.Visibility = Visibility.Collapsed;
                //BigImage1.Visibility = Visibility.Collapsed;
                //BigImage2.Visibility = Visibility.Visible;
                //BigImage3.Visibility = Visibility.Collapsed;

                //btn_01.Visibility = Visibility.Collapsed;
                //btn_01_1.Visibility = Visibility.Collapsed;
                //btn_01_2.Visibility = Visibility.Visible;
                //btn_01_3.Visibility = Visibility.Collapsed;

                //btn_02.Visibility = Visibility.Collapsed;
                //btn_02_01.Visibility = Visibility.Collapsed;
                //btn_02_02.Visibility = Visibility.Visible;
                //btn_02_03.Visibility = Visibility.Collapsed;
            }

        }
        #endregion

        #region 施肥
        private void initFertData(int produceId)
        {
            //1.施肥
            MaintenanceService mtser = new MaintenanceService();
            List<dynamic> data = mtser.queryFertilization(PubData.PRODUCT_ACTION_TYPE_P02, produceId);
            if (data.Count > 0)
            {
                dataGridFert.ItemsSource = data;
            }
        }
        #endregion

        #region 查询施药记录
        private void initPestData(int produceId)
        {
            //施药
            MaintenanceService mtser = new MaintenanceService();
            List<dynamic> datap = mtser.queryPestRecord(PubData.PRODUCT_ACTION_TYPE_P01, produceId);
            if (datap.Count > 0)
            {
                dataGridPest.ItemsSource = datap;
            }
        }
        #endregion

        #region 保存
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            DynamicParameters d = new DynamicParameters();
            TabItem item = tabControl.SelectedItem as TabItem;
            if ("ProductInfo".Equals(item.Header))//产品信息 
            {
                //MessageBox.Show("产品信息");
                d.Add("produceId", produceId.SelectedValue);
                d.Add("productName", productName.Text.Trim());
                d.Add("orginDesc", orginDesc.Text.Trim());
                d.Add("remark", txtRemark.Text.Trim());
                d.Add("corpProductId", this.hproId.Text.Trim());

                ArchivesService aser = new ArchivesService();
                aser.doModify(d, hproId.Text);
                this.Close();
            }
            if ("GrowPeriod".Equals(item.Header))//生长期图片
            {
                MessageBox.Show("生长期图片");
            }
            if ("FertRecord".Equals(item.Header))//施肥记录
            {
                //MessageBox.Show("施肥记录");

                DynamicParameters df = new DynamicParameters();
                df.Add("productId", hproId.Text);
                df.Add("actionValue", actionValue.Text.Trim());
                df.Add("amount", amount.Text.Trim());
                df.Add("actionId", produceId.SelectedValue);
                df.Add("actionType", PubData.PRODUCT_ACTION_TYPE_P02);
                ComboBoxItem itm = harvestAmountUnit.SelectedItem as ComboBoxItem;
                df.Add("amountUnit", itm.Tag);
                df.Add("area", area.Text.Trim());
                df.Add("actionDate", Convert.ToDateTime(actionDate.Text).ToString("yyyy-MM-dd"));
                df.Add("actionPerson", actionPerson.Text.Trim());

                MaintenanceService mtaService = new MaintenanceService();
                mtaService.doAdd(df);

                initFertData(Convert.ToInt32(produceId.SelectedValue));
                //MessageBox.Show("保存成功!");
                //this.Close();


            }
            if ("PestRecord".Equals(item.Header))//施药记录
            {
                //MessageBox.Show("施药记录");

                DynamicParameters dy = new DynamicParameters();
                dy.Add("productId", hproId.Text);
                dy.Add("actionValue", actionValue2.Text.Trim());
                dy.Add("thinckNess", thinckNess.Text.Trim());
                dy.Add("amount", amount2.Text.Trim());
                dy.Add("actionId", produceId.SelectedValue);
                dy.Add("actionType", PubData.PRODUCT_ACTION_TYPE_P01);
                ComboBoxItem itm2 = amountUnit2.SelectedItem as ComboBoxItem;
                dy.Add("amountUnit", itm2.Tag);
                dy.Add("area", area2.Text.Trim());
                dy.Add("actionDate", Convert.ToDateTime(actionDate2.Text).ToString("yyyy-MM-dd"));
                dy.Add("actionPerson", actionPerson2.Text.Trim());

                MaintenanceService mtaService = new MaintenanceService();
                mtaService.doAddApplying(dy);

                initPestData(Convert.ToInt32(produceId.SelectedValue));

            }
            if ("EnvData".Equals(item.Header))//环境数据
            {
                MessageBox.Show("环境数据");
            }
            if ("ProductCert".Equals(item.Header))//产品认证
            {
                MessageBox.Show("产品认证");
            }





        }
        #endregion

        #region 取消
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 添加图片
        private void AddImages_Click(object sender, RoutedEventArgs e)
        {
            //AddImages imge = new AddImages();
            //imge.ShowDialog();
        }
        #endregion

        //刷新父类窗口
        // _p.initSearch();
        private void btnAddFertilization_Click(object sender, RoutedEventArgs e)
        {
            //DynamicParameters d = new DynamicParameters();
            //d.Add("actionValue", textBox3.Text.Trim());
            //d.Add("amount", textBox4.Text.Trim());
            //d.Add("AREA", textBox5.Text.Trim());
            //d.Add("ACTION_DATE", textBox6.Text.Trim());
            //d.Add("ORDER_SEQ", textBox7.Text.Trim());

            //MaintenanceService mtaService = new MaintenanceService();
            //mtaService.doAdd(d);
            //this.Close();
            //MessageBox.Show("保存成功!");
            //this.Close();
        }

        #region 关闭
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 窗体可拖动
        private void MainWindow_MouseLefButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region 添加图片
        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "选择图片";
            openFileDialog.Filter = "jpg|*.jpg|jpeg|*.jpeg|png|*.png";
            openFileDialog.FileName = string.Empty;
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = "jpg";

            System.Windows.Forms.DialogResult result = openFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            string fileSource = openFileDialog.FileName;
            string fileName = System.IO.Path.GetFileName(fileSource);

            string targetPath = Directory.GetCurrentDirectory() + @"\Images\" + fileName;
            System.IO.File.Copy(fileSource, targetPath);

            ImageButton.Visibility = Visibility.Visible;
            //添加图片
            DynamicParameters d = new DynamicParameters();
            d.Add("productLifeId", fileName);
            d.Add("corpProductId", fileName);
            d.Add("imageName", fileName);
            d.Add("realPath", targetPath);
            d.Add("path", fileName);
            d.Add("imageSize", fileName);
            d.Add("imageBlob", fileName);
            d.Add("orderSeq", fileName);
            d.Add("status", fileName);
            d.Add("createDate", System.DateTime.Now);
            d.Add("createStaffId", fileName);
            d.Add("remark", fileName);
            d.Add("uploadState", "使用");
            d.Add("uploadDate", System.DateTime.Now);
      
            ProductService pds = new ProductService();         
            pds.daoAddProduct(d);

           // AddNewImage(targetPath);
            //通过Tag为0或1来表示是否加载了图片
            for (int i = 0; i < ProductImages.Children.Count; i++)
            {
                Button button = (Button)ProductImages.Children[i];
                if (button.Tag.ToString() == "0")
                {

                    ImageBrush image = new ImageBrush();

                    ImageButton.Visibility = Visibility.Visible;

                    image.ImageSource = new BitmapImage(new Uri(targetPath, UriKind.RelativeOrAbsolute));
                    button.Background = image;
                    button.Tag = "1";
                    return;
                }
            }
        }

        /// <summary>
        /// 快速读取图像分辨率大小
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        //public static Size GetImageSize(FileInfo file)
        //{

        //    using (FileStream stm = file.OpenRead())
        //    {
        //       // return GetImageSize(stm);
        //    }

        //}

        /// <summary>
        /// 快速读取图像分辨率大小
        /// </summary>
        /// <param name="ImageStream"></param>
        /// <returns></returns>
        //public static Size GetImageSize(Stream ImageStream)
        //{
        //    Size imgSize;
        //    long position = ImageStream.Position;


        //    byte[] bin = new byte[2];
        //    ImageStream.Read(bin, 0, 2);
        //    ImageStream.Seek(-2, SeekOrigin.Current);

        //    int Fmt = bin[0] << 8 | bin[1];


        //    switch (Fmt)
        //    {
        //        case 0xFFd8://jpg
        //            //if (GetJpegSize(ImageStream, out imgSize))
        //            //    return imgSize;
        //            break;
        //        case 0x8950://png
        //            //if (GetPngSize(ImageStream, out imgSize))
        //            //    return imgSize;
        //            break;
        //        case 0x4749://gif
        //            //if (GetGifSize(ImageStream, out imgSize))
        //            //    return imgSize;
        //            //break;
        //        case 0x424D://bmp
        //            //if (GetBmpSize(ImageStream, out imgSize))
        //            //    return imgSize;
        //            break;
        //    }


        //    ImageStream.Position = position;
        //    Image img = null;
        //    try
        //    {
        //        //img = Image.FromStream(ImageStream);
        //        //return img.Size;
        //    }
        //    catch (Exception)
        //    {
        //        return new Size();
        //    }
        //    finally
        //    {
        //        if (img != null)
        //            img.Dispose();
        //    }
        //}


        private void AddNewImage(string path)
        {
            Button button = new Button();
            button.Width = 85;
            button.Height = 85;
            ImageBrush image = new ImageBrush();

            image.ImageSource = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            button.Background = image;
            ProductImages.Children.Add(button);


        }
        #endregion

        #region 加载图片
        private void ImageTabItem_Loaded(object sender, RoutedEventArgs e)
        {
            //查询文件夹下的所有图片路径，临时
            //正常做法是将图片路径保存在数据库的表中

            List<string> imageList = new List<string>();
            DirectoryInfo theFolder = new DirectoryInfo(Directory.GetCurrentDirectory() + @"\Images\");

            //  //66西红柿 67黄瓜 69马铃薯 68小白菜
            //    if (66.Equals(id))
            //    {

            //    }
            //    if (67.Equals(id))
            //    {
            //     }
            //if (69.Equals(id))
            //{

            //}
            //if (68.Equals(id))
            //{

            //}

            if (67.Equals(id))
            {
                FileInfo[] fileInfo = theFolder.GetFiles();
                foreach (FileInfo file in fileInfo)
                {
                    if (file.Name != "background.jpg")
                        imageList.Add(Directory.GetCurrentDirectory() + @"\Images\cucumber\" + file.Name);
                    if (file.Name.Substring(0, 3) == "Big")
                    {
                        ImageBrush image = new ImageBrush();
                        image.ImageSource = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + @"\Images\cucumber\" + file.Name, UriKind.RelativeOrAbsolute));
                        BigImage.Background = image;
                    }

                }
                int count = imageList.Count;

                for (int i = 0; i < ProductImages.Children.Count; i++)
                {
                    Button button = (Button)ProductImages.Children[i];
                    if (i == count) return;
                    if (button.Tag.ToString() == "0")
                    {

                        ImageBrush image = new ImageBrush();
                        image.ImageSource = new BitmapImage(new Uri(imageList[i], UriKind.RelativeOrAbsolute));
                        button.Background = image;
                        button.Tag = "1";

                    }
                }
            }
        }
        #endregion
    }
}