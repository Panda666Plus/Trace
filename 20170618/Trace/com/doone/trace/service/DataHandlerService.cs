using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class DataHandlerService
    {
        #region 查询上传的数据
        public List<dynamic> queryBySql(Dictionary<String, Object> dict)
        {
            List<dynamic> list = new List<dynamic>();

            DataHandlerDao dao = new DataHandlerDao();
            foreach (var item in dict)
            {
                if ("sql".Equals(item.Key))
                {
                    list = dao.queryBySql(item.Value.ToString());
                }
            }
            return list;
        }
        #endregion

        #region 更新上传状态
        public void updateState(Dictionary<String, Object> dict)
        {
            DataHandlerDao dao = new DataHandlerDao();
            dao.updateState(dict);

        }
        #endregion
    }
}
