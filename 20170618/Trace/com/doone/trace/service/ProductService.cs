using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class ProductService
    {
        #region 新增图片
        public bool daoAddProduct(DynamicParameters d)
        {
            ProductDao productDao = new ProductDao();
            return productDao.daoAddProduct(d);
        }
        #endregion
    }
}