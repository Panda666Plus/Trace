using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class RecordsService
    {
        #region 查询总数
        public int doQueryCount(String enterpriseName, String farmLandName, String produceName)
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.doQueryCount(enterpriseName, farmLandName, produceName);
        }
        #endregion

        #region 分页查询
        public DataTable doQeuryPage(String enterpriseName, String farmLandName, String produceName, int pageSize, int pageIndex)
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.doQeuryPage(enterpriseName, farmLandName, produceName, pageSize, pageIndex);
        }
        #endregion

        #region 新增记录
        public bool doAdd(DynamicParameters d)
        {
            RecordsDao recordsDao = new RecordsDao();
            recordsDao.doAdd(d);
            return true;
        }
        #endregion

        #region 修改记录
        public bool doModify(DynamicParameters d)
        {
            RecordsDao recordsDao = new RecordsDao();
            recordsDao.doModify(d);
            return true;
        }
        #endregion

        # region 批量删除
        public bool delBatch(String ids)
        {
            RecordsDao recordsDao = new RecordsDao();
            recordsDao.delBatch(ids);
            return true;
        }
        #endregion

        # region 查询所有企业信息
        public List<dynamic> queryEnterprise()
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.queryEnterprise();
        }
        #endregion

        # region 查询所有田块信息
        public List<dynamic> queryFarmland()
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.queryFarmland();
        }
        #endregion

        # region 查询所有农产品信息
        public List<dynamic> queryProduce()
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.queryProduce();
        }
        #endregion

        # region 查询所有农产品信息
        public List<dynamic> queryRecords()
        {
            RecordsDao recordsDao = new RecordsDao();
            return recordsDao.queryRecords();
        }
        #endregion
    }
}
