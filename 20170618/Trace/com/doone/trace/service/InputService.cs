using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class InputService
    {
        #region 新增
        public bool doAdd(DynamicParameters dp)
        {
            InputDao inputDao = new InputDao();
          return  inputDao.doAdd(dp);
        }
        #endregion

        #region 修改
        public bool doModify(DynamicParameters dp)
        {
            InputDao inputDao = new InputDao();
            inputDao.doModify(dp);
            return true;
        }
        #endregion

        #region 删除
        public bool delBatch(String ids)
        {
            InputDao inputDao = new InputDao();
            inputDao.delBatch(ids);
            return true;
        }
        #endregion
    }
}
