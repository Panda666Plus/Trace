using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace Trace.common
{

/*
     Author: wushenghu
     Time: June 21, 2017
     E-mail: sheng-hu.wu @doone.com.cn
*/
    /// <summary>
    /// 图像处理相关
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 快速读取图像分辨率大小
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static Size GetImageSize(FileInfo file)
        {

            using (FileStream stm = file.OpenRead())
            {
                return GetImageSize(stm);
            }

        }

        /// <summary>
        /// 快速读取图像分辨率大小
        /// </summary>
        /// <param name="ImageStream"></param>
        /// <returns></returns>
        public static Size GetImageSize(Stream ImageStream)
        {
            Size imgSize;
            long position = ImageStream.Position;


            byte[] bin = new byte[2];
            ImageStream.Read(bin, 0, 2);
            ImageStream.Seek(-2, SeekOrigin.Current);

            int Fmt = bin[0] << 8 | bin[1];


            switch (Fmt)
            {
                case 0xFFd8://jpg
                    if (GetJpegSize(ImageStream, out imgSize))
                        return imgSize;
                    break;
                case 0x8950://png
                    if (GetPngSize(ImageStream, out imgSize))
                        return imgSize;
                    break;
                case 0x4749://gif
                    if (GetGifSize(ImageStream, out imgSize))
                        return imgSize;
                    break;
                case 0x424D://bmp
                    if (GetBmpSize(ImageStream, out imgSize))
                        return imgSize;
                    break;
            }


            ImageStream.Position = position;
            Image img = null;
            try
            {
                img = Image.FromStream(ImageStream);
                return img.Size;
            }
            catch (Exception)
            {
                return new Size();
            }
            finally
            {
                if (img != null)
                    img.Dispose();
            }
        }

        /// <summary>
        /// 快速读取jpg图像分辨率大小
        /// </summary>
        /// <param name="JpegStream"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool GetJpegSize(Stream JpegStream, out System.Drawing.Size size)
        {
            size = new System.Drawing.Size();
            byte[] bin = new byte[2];
            JpegStream.Read(bin, 0, 2);

            if (bin[0] != 0xff && bin[1] != 0xd8)//SOI，Start of Image，图像开始
                return false;
            int flag;
            int DataLen = 0;
            while (JpegStream.CanRead)
            {
                int c = JpegStream.Read(bin, 0, 2);
                if (c != 2)//end of file;
                    break;
                if (bin[0] != 0xfF)//Error File!
                    break;
                flag = bin[1];

                if (flag == 0xD9 || flag == 0xDA)//图像结整或图像数据开始
                    break;
                switch (flag)
                {
                    case 0xC0://SOF0，Start of Frame，帧图像开始
                        JpegStream.Read(bin, 0, 2);
                        DataLen = bin[0] << 8 | bin[1];
                        DataLen -= 2;
                        byte[] data = new byte[DataLen];
                        JpegStream.Read(data, 0, DataLen);
                        DataLen = 0;
                        size.Height = data[1] << 8 | data[2];
                        size.Width = data[3] << 8 | data[4];
                        return true;//无需读取其它数据

                    //case 0xD9://EOI，End of Image，图像结束 2字节
                    //case 0xDA://Start of Scan，扫描开始 12字节 图像数据，通常，到文件结束,遇到EOI标记
                    case 0xC4://DHT，Difine Huffman Table，定义哈夫曼表
                    case 0xDD:// DRI，Define Restart Interval，定义差分编码累计复位的间隔
                    case 0xDB:// DQT，Define Quantization Table，定义量化表
                    case 0xE0://APP0，Application，应用程序保留标记0。版本，DPI等信息
                    case 0xE1://APPn，Application，应用程序保留标记n，其中n=1～15(任选)
                        JpegStream.Read(bin, 0, 2);
                        DataLen = bin[0] << 8 | bin[1];
                        DataLen -= 2;
                        break;
                    default:
                        if (flag > 0xE1 && flag < 0xEF)//APPx
                            goto case 0xE1;
                        //格式错误？？
                        break;
                }
                if (DataLen != 0)
                {
                    JpegStream.Seek(DataLen, System.IO.SeekOrigin.Current);
                    DataLen = 0;
                }
            }
            return !size.IsEmpty;
        }

        /// <summary>
        /// 快速读取png图像分辨率大小
        /// </summary>
        /// <param name="JpegStream"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool GetPngSize(Stream PngStm, out Size size)
        {
            size = new System.Drawing.Size();
            const uint PNG_HEAD = 0x89504e47;
            const uint PNG_HEAD_2 = 0x0d0a1a0a;// PNG标识签名 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A;

            byte[] bin = new byte[64];
            int c = PngStm.Read(bin, 0, 8);
            if (c != 8)
                return false;

            if ((uint)Bytes2Int(bin, 0) != PNG_HEAD || (uint)Bytes2Int(bin, 4) != PNG_HEAD_2) //其它格式
                return false;

            while (PngStm.CanRead)
            {

                c = PngStm.Read(bin, 0, 8);
                if (c != 8)
                    return false;
                int dataLen = Bytes2Int(bin, 0) + 4;
                string Field = System.Text.ASCIIEncoding.ASCII.GetString(bin, 4, 4);
                switch (Field)
                {
                    case "IHDR"://文件头数据块 
                        c = PngStm.Read(bin, 0, dataLen);
                        if (c != dataLen)
                            return false;
                        size.Width = Bytes2Int(bin, 0);
                        size.Height = Bytes2Int(bin, 4);
                        dataLen = 0;
                        return true;
                    case "sBIT":
                    case "pHYs":
                    case "tEXt":
                    case "IDAT"://LZ77图片数据
                    case "IEND"://文件结尾
                    default:
                        break;
                }
                if (dataLen != 0)
                {
                    PngStm.Seek(dataLen, System.IO.SeekOrigin.Current);
                }

            }
            return !size.IsEmpty;
        }

        /// <summary>
        /// 快速读取gif图像分辨率大小
        /// </summary>
        /// <param name="PngStm"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool GetGifSize(Stream PngStm, out Size size)
        {
            size = new System.Drawing.Size();


            byte[] bin = new byte[32];
            int c = PngStm.Read(bin, 0, 32);
            if (c != 32)
                return false;

            if (bin[0] != 'G' || bin[1] != 'I' || bin[2] != 'F') //其它格式
                return false;

            size.Width = bin[6] | bin[7] << 8;
            size.Height = bin[8] | bin[9] << 8;

            return !size.IsEmpty;
        }

        /// <summary>
        /// 快速读取bmp图像分辨率大小
        /// </summary>
        /// <param name="PngStm"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool GetBmpSize(Stream PngStm, out Size size)
        {
            size = new System.Drawing.Size();

            byte[] bin = new byte[32];
            int c = PngStm.Read(bin, 0, 32);
            if (c != 32)
                return false;

            if (bin[0] != 'B' || bin[1] != 'M') //其它格式
                return false;

            size.Width = bin[18] | bin[19] << 8 | bin[20] << 16 | bin[21] << 24;
            size.Height = bin[22] | bin[23] << 8 | bin[24] << 16 | bin[25] << 24;

            return !size.IsEmpty;
        }

        static int Bytes2Int(byte[] bin, int offset)
        {
            return bin[offset + 0] << 24 | bin[offset + 1] << 16 | bin[offset + 2] << 8 | bin[offset + 3];
        }
    }
}
