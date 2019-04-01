using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Trace.com.doone.trace.model
{
    class Product
    {
        // 产品档案资料
        public string corpProductId { get; set; }
        public string productName { get; set; }
        public string plantDate { get; set; }
        public BitmapImage imagePath { get; set; }
    }
}
