using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class HarmlesService
    {
        #region 新增
        public bool doAdd(DynamicParameters dp)
        {
            HarmlesDao harmlesDao = new HarmlesDao();
            harmlesDao.doAdd(dp);
            return true;
        }
        #endregion

        #region 修改
        public bool doModify(DynamicParameters dp)
        {
            HarmlesDao harmlesDao = new HarmlesDao();
            harmlesDao.doModify(dp);
            return true;
        }
        #endregion

        #region 删除
        public bool delBatch(String ids)
        {
            HarmlesDao harmlesDao = new HarmlesDao();
            harmlesDao.delBatch(ids);
            return true;
        }
        #endregion

        #region 查询所有生产者
        public List<dynamic> queryProducer()
        {
            HarmlesDao harmlesDao = new HarmlesDao();
            return harmlesDao.queryProducer();  
        }
        #endregion
    }
}
