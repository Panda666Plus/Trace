using System;
using System.Collections.Generic;
using System.IO;
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

namespace Trace.Views.productMaintenance
{
/*
    Author: 协助人员
    Time: June 13, 2017
    E-mail: sheng-hu.wu @doone.com.cn  
*/
    public partial class AddImages : Window
    {
        public AddImages()
        {
            InitializeComponent();
        }
        private void ShowSelectedPicture(string path)
        {
            FileStream fs = File.OpenRead(path); //OpenRead
            int filelength = 0;
            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(image);
            bitmapImage.EndInit();
         //   var pictureWindow = new PictureWindow();//自己创建的窗口
           // pictureWindow.myImage.Source = bitmapImage;//myImage窗口中的图片空间
            //pictureWindow.myImage.Width = bitmapImage.PixelWidth;
            //pictureWindow.myImage.Height = bitmapImage.PixelHeight;
           // pictureWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
           // pictureWindow.ShowDialog();
        }


        private void MyImage_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            double ScaleX = 0;
            double ScaleY = 0;
            double dbl_ZoomX = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).ScaleX;
            double dbl_ZoomY = ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).ScaleY;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).CenterX = e.GetPosition(this.myImage).X;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).CenterY = e.GetPosition(this.myImage).Y;


            if (e.Delta < 0)
            {
                ScaleX = dbl_ZoomX - 0.1 < 0.2 ? 0.1 : dbl_ZoomX - 0.1;
                ScaleY = dbl_ZoomY - 0.1 < 0.2 ? 0.1 : dbl_ZoomY - 0.1;
            }
            else if (e.Delta > 0)
            {
                ScaleX = dbl_ZoomX + 0.1 > 10.0 ? 10.0 : dbl_ZoomX + 0.1;
                ScaleY = dbl_ZoomY + 0.1 > 10.0 ? 10.0 : dbl_ZoomY + 0.1;
            }


              ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).ScaleX = ScaleX;
            ((ScaleTransform)(((TransformGroup)(((UIElement)(this.myImage)).RenderTransform)).Children[0])).ScaleY = ScaleY;
        }

        private void UploadImage(string Path)
        {
            FileStream fullfs;
            string pictureName = GetPictureName();
            //string pictureFullPath = storePath;// GetPicturePath(rtdto.BusinessIndex, rtdto.ProviderIndex);
            //string pictureFullName = pictureFullPath + @"\" + pictureName;
            //fullfs = new FileStream(pictureFullName, FileMode.Create);
            //BinaryWriter fullbw = new BinaryWriter(fullfs);
            //fullbw.Write(pidto.PictureData);
            //fullbw.Close();
            //fullfs.Close();
        }
        private string GetPicturePath(int businessindex, int providerindex)
        {
            string currentPath = AppDomain.CurrentDomain.BaseDirectory + @"\Image";
            if (!System.IO.Directory.Exists(currentPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(currentPath);
                }
                catch
                {
                    currentPath = AppDomain.CurrentDomain.BaseDirectory;//创建目录失败，存入根目录中
                }
            }
            string filePath = currentPath + @"\" + businessindex + "_" + providerindex;
            if (!System.IO.Directory.Exists(filePath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(filePath);
                }
                catch
                {
                    filePath = currentPath;//创建目录失败，存入根目录中
                }

            }
            return filePath;
        }
        private string GetPictureName()
        {
            string imageGuid = Guid.NewGuid().ToString() + ".jpg";
            return imageGuid;
        }

    }
}
