using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ThoughtWorks.QRCode.Codec;
using Trace.Common;

namespace Trace.Views.dangan
{
/*
    Author: wushenghu
    Time: June 21, 2017
    E-mail: sheng-hu.wu @doone.com.cn
*/
    public partial class QrcodePage : Window
    {

        public string param;
        public string produceId;
        PrintDocument printdoc;
        PrintPreviewDialog printPreviewDialog;
        public QrcodePage()
        {
            InitializeComponent();
            //  Loaded += MainWindow_Loaded;

        }


        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            printdoc = new PrintDocument();
            printdoc.PrintPage += printdocument_PrintPage;
            // printDocument1 为 打印控件
            //设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            this.printdoc.DefaultPageSettings.PaperSize = new PaperSize("Custum", 800, 800);
            this.printdoc.PrintPage += new PrintPageEventHandler(this.printdocument_PrintPage);
            //将写好的格式给打印预览控件以便预览
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printdoc;

            QRCodeDecoder qc = new QRCodeDecoder();

            // printPreviewDialog.PrintDocument();
            //显示打印预览
            DialogResult result = printPreviewDialog.ShowDialog();

            //if (result == DialogResult.)
            // this.MyPrintDocument.Print();

        }
        void printdocument_PrintPage(object sender, PrintPageEventArgs e)
        {


            Font FoolterWorkCode = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            e.Graphics.DrawString("武汉市农产品质量安全追溯码", new Font(new System.Drawing.FontFamily("黑体"), 9), System.Drawing.Brushes.Black, 129, 5);
            e.Graphics.DrawString("产品名称: 西瓜(早春红一号)", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 32);
            e.Graphics.DrawString("生产厂家: 家事宜农业科技有限公司", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 48);
            e.Graphics.DrawString("产    地: 湖北省武汉市江夏区", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 65);
            e.Graphics.DrawString("生产日期: 2017-04-12", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 80);
            e.Graphics.DrawString("查询网址:", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 84, 137);
            e.Graphics.DrawString("www.02712316.com", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 84, 154);
            e.Graphics.DrawString("追溯码:", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 200, 137);
            e.Graphics.DrawString("1003 0010 0117 0618 0021", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 200, 154);
            e.Graphics.DrawString("武汉市农委  印制", new Font(new System.Drawing.FontFamily("黑体"), 9), System.Drawing.Brushes.Black, 147, 181);

            //e.Graphics.DrawString("产品名称:稻乡鱼", FoolterWorkCode, System.Drawing.Brushes.Black, 50, 60);
            //e.Graphics.DrawString("厂家:开元村合作社", FoolterWorkCode, System.Drawing.Brushes.Black, 50, 60);
            //e.Graphics.DrawString("追溯码:43243594895840600", FoolterWorkCode, System.Drawing.Brushes.Black, 50, 60);
            //e.Graphics.DrawString("生产日期:2017-04-12", FoolterWorkCode, System.Drawing.Brushes.Black, 50, 60);

            var ms = new MemoryStream();
          //  var source = (BitmapSource)qrcode.Source;
            BitmapEncoder enc = new BmpBitmapEncoder();
          //  enc.Frames.Add(BitmapFrame.Create(source));
            enc.Save(ms);

            var bitmap = new Bitmap(ms);
            //  bitmap.Save("C:\\1.bmp");

            e.Graphics.DrawImage(bitmap, new System.Drawing.Rectangle(79, 28, 75, 75));
            e.Graphics.DrawLine(Pens.Black, new PointF(65, 20), new PointF(400, 20));
            e.Graphics.DrawLine(Pens.Black, new PointF(65, 175), new PointF(400, 175));

        }

        #region 生成二维码
        PrintDocument printdocument;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded += MainWindow_Loaded;
            //string url = "http://59.173.8.184:20081/plat";
            //string url = "http://59.173.8.184:20081/trace/wap/qrcode/toListArchives";
            //string link = (param == string.Empty ? string.Empty : "?qrcode=" + param);
            //qrcode.Source = BitmapToBitmapImage(GetDimensionalCode(url, link));
            string link = (param == string.Empty ? string.Empty : "?productionCode=" + param);
            //qrcode.Source = BitmapToBitmapImage(GetDimensionalCode(PubData.QR_CODE_URL, link));


            if ("66".Equals(produceId))
            {
                imagePrint.Visibility = Visibility.Visible;

                //System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("Trace;component/Res_/Images/二维码 -番茄.jpg");
                //MemoryStream stream = new MemoryStream();
                //bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                //ImageBrush imageBrush = new ImageBrush();
                //ImageSourceConverter imageSourceConverter = new ImageSourceConverter();
                //imageBrush.ImageSource = (ImageSource)imageSourceConverter.ConvertFrom(stream);
                //button.Background = imageBrush;
                //  Image.ImageSource = "/Trace;component/Res_/Images/二维码 -番茄.jpg";

                // ImageBrush imageBrush = new ImageBrush();
                // imageBrush.ImageSource = new BitmapImage(new Uri(@"Res_\Images\二维码 -番茄.jpg", UriKind.Relative));
                //// imagePrint1.Source = imageBrush;
            }
            if ("67".Equals(produceId))
            {
                imagePrint2.Visibility = Visibility.Visible;
            }
            if ("69".Equals(produceId))
            {
                imagePrint3.Visibility = Visibility.Visible;
            }
            if ("68".Equals(produceId))
            {
                imagePrint4.Visibility = Visibility.Visible;
            }

        }

        /// <summary>
        /// bitMap转bitMapImage
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {

            //System.Drawing.Size rederSize = multiWriter.GetEncodeSize(url, com.google.zxing.BarcodeFormat.QR_CODE, scale, scale);
            //             int middleImgW = Math.Min((int)(rederSize.Width / 3.5), middleImg.Width);
            //             int middleImgH = Math.Min((int)(rederSize.Height / 3.5), middleImg.Height);

            //             int middleImgL = (bitQRImg.Width - middleImgW) / 2;
            //             int middleImgT = (bitQRImg.Height - middleImgH) / 2;



            Bitmap bitmapSource = new Bitmap(bitmap.Width + 200, bitmap.Height + 200);
            int i, j;
            for (i = 0; i < bitmap.Width; i++)
                for (j = 0; j < bitmap.Height; j++)
                {
                    System.Drawing.Color pixelColor = bitmap.GetPixel(i, j);
                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    //if (i < bitmapSource.Width - 200 && j < bitmapSource.Height - 200)
                    //newColor = System.Drawing.Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                    //else
                    //newColor = System.Drawing.Color.FromArgb(256, 256, 256);
                    //在这里绘画需要显示的信息



                    //e.Graphics.DrawString("产品名称: 西瓜(早春红一号)", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 32);
                    //e.Graphics.DrawString("生产厂家: 家事宜农业科技有限公司", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 48);
                    //e.Graphics.DrawString("产    地: 湖北省武汉市江夏区", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 65);
                    //e.Graphics.DrawString("生产日期: 2017-04-12", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 161, 80);
                    //e.Graphics.DrawString("查询网址:", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 84, 137);
                    //e.Graphics.DrawString("www.02712316.com", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 84, 154);
                    //e.Graphics.DrawString("追溯码:", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 200, 137);
                    //e.Graphics.DrawString("1003 0010 0117 0618 0021", new Font(new System.Drawing.FontFamily("黑体"), 7), System.Drawing.Brushes.DimGray, 200, 154);
                    //e.Graphics.DrawString("武汉市农委  印制", new Font(new System.Drawing.FontFamily("黑体"), 9), System.Drawing.Brushes.Black, 147, 181);


                    bitmapSource.SetPixel(i, j, newColor);
                    //设置显示
                }

            for (int x = bitmap.Width; x < bitmapSource.Width; x++)
                for (int y = bitmap.Height; y < bitmapSource.Height; y++)
                {
                    System.Drawing.Color newColor = System.Drawing.Color.FromArgb(255, 255, 255);
                    bitmapSource.SetPixel(x, y, newColor);
                }

            Graphics e = Graphics.FromImage(bitmapSource);

            e.DrawString("武汉市农产品质量安全追溯码", new Font(new System.Drawing.FontFamily("黑体"), 9), System.Drawing.Brushes.Black, bitmapSource.Width - 100, bitmapSource.Height - 100);

            MemoryStream ms = new MemoryStream();
            bitmapSource.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(ms.ToArray());
            bitmapImage.EndInit();

            //qrcode = bitmapImage;
            return bitmapImage;
        }

        /// <summary>
        /// 根据链接获取二维码
        /// </summary>
        /// <param name="link">链接</param>
        /// <returns>返回二维码图片</returns>
        private Bitmap GetDimensionalCode(string url, string link)
        {
            Bitmap bmp = null;
            // url = FactoryRecord121._STURLInterface + "/production/showCode";
            url = "http://59.173.8.184:20081/trace/wap/qrcode/toListArchives?";
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                bmp = qrCodeEncoder.Encode(url + link);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("版本错误!");
            }
            return bmp;
        }
        #endregion

        RenderTargetBitmap RenderVisaulToBitmap(Visual imagePrint, int width, int height)
        {
            var rtb = new RenderTargetBitmap(width, height, 96*10, 96*10, PixelFormats.Default);
            rtb.Render(imagePrint);

            return rtb;
        }
         public enum ImageFormat { JPG, BMP, PNG, GIF, TIF }
        void GenerateImage(BitmapSource bitmap, ImageFormat format, Stream destStream)
        {
            BitmapEncoder encoder = null;

            switch (format)
            {
                case ImageFormat.JPG:
                    encoder = new JpegBitmapEncoder();
                    break;
                case ImageFormat.PNG:
                    encoder = new PngBitmapEncoder();
                    break;
                case ImageFormat.BMP:
                    encoder = new BmpBitmapEncoder();
                    break;
                case ImageFormat.GIF:
                    encoder = new GifBitmapEncoder();
                    break;
                case ImageFormat.TIF:
                    encoder = new TiffBitmapEncoder();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            encoder.Frames.Add(BitmapFrame.Create(bitmap));
            encoder.Save(destStream);
        }
        #region
        public int left = 0, top = 0, width = 80, height = 100, right = 4;
        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //,BitmapSource bitmap, ImageFormat format, Stream destStream

         

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender1, e1) =>
            {
                var source = RenderVisaulToBitmap(this.root, 1400*2, 1000*2);
                /* 正常在写法
                 * 直接把IMG 读入bitmap,全充填，bitmap
                 * bitmap = new Bitmap(1080,1920);
                 * 直接定义 尺寸， 在把 memorystream流文件 充填进去就可以了
                 * DrawImage(bitmap, new PointF(0, 0));
                 * 
                 
                 */

                var ms = new MemoryStream();
                GenerateImage(source, ImageFormat.JPG, ms);
             
                 
              
                 
                e1.Graphics.FillRectangle(System.Drawing.Brushes.White, new System.Drawing.Rectangle(0, 0, 1400 * 2, 1000 * 2));
                var bitmap = new Bitmap(ms);

                e1.Graphics.DrawImage(bitmap, new PointF(0, 0));
                bitmap.Save("123.jpg");
                //e1.Graphics.DrawImage(bitmap, 0, 0,5,8);
               
                e1.Graphics.DrawImage(bitmap, new PointF(0, 0));
                
               // System.Drawing.Bitmap image = new System.Drawing.Bitmap(150, 200);
                bitmap.Dispose();
            };
            pd.Print();

            //PrintDocument pd = new PrintDocument();
            //pd.PrintPage += printdocument_PrintPage;
            //try
            //{
            //    pd.Print();

            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.Message, "打印出错", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //            MainWindow_Loaded(sender, e);
            //printdocument.Print();
            //BarcodeReader reader = new BarcodeReader();
            //Result result = reader.Decode((Bitmap)pictureBox.Image);
            //MessageBox.Show(result.Text);
            // printdoc = new PrintDocument();
            //printdoc.PrintPage += printdocument_PrintPage;
            //// printDocument1 为 打印控件
            ////设置打印用的纸张 当设置为Custom的时候，可以自定义纸张的大小，还可以选择A4,A5等常用纸型
            //this.printdoc.DefaultPageSettings.PaperSize = new PaperSize("Custum", 200, 200);
            ////    this.printdoc.DefaultPageSettings.HardMarginX=new H(left, right, top);
            //this.printdoc.PrintPage += new PrintPageEventHandler(this.printdocument_PrintPage);
            ////将写好的格式给打印预览控件以便预览y
            //printPreviewDialog = new PrintPreviewDialog();
            //printPreviewDialog.Document = printdoc;
            ////printPreviewDialog.PrintDocument()
            ////显示打印预览
            //DialogResult result = printPreviewDialog.ShowDialog();
            ////if (result == System.Windows.Forms.DialogResult.)
            //try
            //{
            //    this.printdoc.Print();
            //}
            //catch (Exception ex)
            //{
            //    System.Windows.Forms.MessageBox.Show(ex.ToString());
            //}
        }
    }

      
        #endregion
    }

