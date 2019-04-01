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
    class ShipmentService
    {
        #region 查询总数
        public int queryCount(String quality)
        {
            ShipmentDao shipmentDao = new ShipmentDao();
            return shipmentDao.queryCount(quality);
        }
        #endregion

        #region 分页查询
        public DataTable queryPage(String quality, int pageSize, int pageIndex)
        {
            ShipmentDao shipmentDao = new ShipmentDao();
            return shipmentDao.queryPage(quality, pageSize, pageIndex);
        }
        #endregion

        #region 新增
        public bool doAdd(DynamicParameters d)
        {
            ShipmentDao shipmentDao = new ShipmentDao();
            return shipmentDao.doAdd(d);
        }
        #endregion

        #region 更新
        public bool doUpdate(DynamicParameters d)
        {
            ShipmentDao shipmentDao = new ShipmentDao();
            return shipmentDao.doUpdate(d);
        }
        #endregion

        #region 批量删除
        public bool batchDel(String ids)
        {
            ShipmentDao shipmentDao = new ShipmentDao();
            return shipmentDao.batchDel(ids);
        }
        #endregion
    }
}
