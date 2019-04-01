using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;
using Trace.Common;
using Trace.Common.thread;
//using Trace.Common.thread;

namespace Trace.com.doone.trace.service
{
    class MaintenanceService
    {

        #region 新增施肥记录
        public int doAdd(DynamicParameters d)
        {
            MaintenanceDao archDao = new MaintenanceDao();
            int sfId = archDao.doAdd(d);

            //上传数据
            StringBuilder upSql = new StringBuilder();
            upSql.Append("select product_detail_id, corp_product_id, action_type, action_id, action_value,");
            upSql.Append("amount, amount_unit, area, thickness, order_seq, status,");
            upSql.Append("strftime('%Y-%m-%d', action_date, 'localtime') ACTION_DATE,action_staff_id,");
            upSql.Append(" strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE ");
            upSql.Append("from tf_enterprise_product_detail where product_detail_id=").Append(sfId).Append(";");
            //doUploadData("tf_enterprise_product_detail", "add", Convert.ToString(sfId), "PRODUCT_DETAIL_ID", upSql.ToString());

            DataItem item = new DataItem();
            item.tabName = "tf_enterprise_product_detail";
            item.tabIdType = "add";
            item.tabId = Convert.ToString(sfId);
            item.tabIdName = "PRODUCT_DETAIL_ID";
            item.sql = upSql.ToString();
            Thread t = new Thread(new ThreadStart(item.H));
            t.Start();

            return sfId;
        }
        #endregion

        public List<dynamic> queryFertilization(string actionType, int produceId)
        {
            MaintenanceDao dao = new MaintenanceDao();
            return dao.queryFertilization(actionType,produceId);
        }

        public bool doAddFertilization(DynamicParameters d)
        {
            MaintenanceDao archDao = new MaintenanceDao();
            return archDao.doAddFertilization(d);
        }

        public List<dynamic> queryPestRecord(string actionType, int produceId)
        {
            MaintenanceDao dao = new MaintenanceDao();
            return dao.queryPestRecord(actionType,produceId);
        }

        #region 新增施药记录
        public int doAddApplying(DynamicParameters d)
        {
            MaintenanceDao archDao = new MaintenanceDao();
            int syId = archDao.doAddApplying(d);

            //上传数据
            StringBuilder upSql = new StringBuilder();
            upSql.Append("select product_detail_id, corp_product_id, action_type, action_id, action_value,");
            upSql.Append("amount, amount_unit, area, thickness, order_seq, status,");
            upSql.Append("strftime('%Y-%m-%d', action_date, 'localtime') ACTION_DATE,action_staff_id,");
            upSql.Append(" strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE ");
            upSql.Append("from tf_enterprise_product_detail where product_detail_id=").Append(syId).Append(";");

            //doUploadData("tf_enterprise_product_detail", "add", Convert.ToString(syId), "PRODUCT_DETAIL_ID", upSql.ToString());
            DataItem item = new DataItem();
            item.tabName = "tf_enterprise_product_detail";
            item.tabIdType = "add";
            item.tabId = Convert.ToString(syId);
            item.tabIdName = "PRODUCT_DETAIL_ID";
            item.sql = upSql.ToString();
            Thread t = new Thread(new ThreadStart(item.H));
            t.Start();

            return syId;
        }
        #endregion
    }
}
