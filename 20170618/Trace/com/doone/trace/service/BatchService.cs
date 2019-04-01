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
    class BatchService
    {
        public List<dynamic> queryBatchRecord(int corpId)
        {
            BatchDao dao = new BatchDao();
            return dao.queryBatchRecord(corpId);
        }

        public List<dynamic> queryQualitys(int corpId)
        {
            BatchDao dao = new BatchDao();
            return dao.queryQualitys(corpId);
        }

        public int doAddProduction(DynamicParameters d)
        {
            //插入production
            BatchDao dao = new BatchDao();
            int id = dao.doAddProduction(d);

            d.Add("productionId", id);
            int qualityId = dao.doAddQuality(d);//插入检测记录

            //新增检测项目及值 tf_production_quality_item(农残检测特有)
            d.Add("qualityId", qualityId);
            int itemId = dao.doAddItemVal(d);

            //2、更新采收harvest_date harvest_amount 根据production_id
            dao.doUpdHarvest(d);
            //3、新增销售去向 包括production_id
            int saleId = dao.doAddSales(d);

            //上传数据
            //tf_production
            StringBuilder productionSql = new StringBuilder();
            productionSql.Append("select production_id,corp_product_id,production_code,quality_result,");
            productionSql.Append("strftime('%Y-%m-%d', harvest_date, 'localtime') HARVEST_DATE,harvest_amount,harvest_amount_unit,status,");
            productionSql.Append("strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE,create_staff_id,");
            productionSql.Append("strftime('%Y-%m-%d', state_date, 'localtime') STATE_DATE ");
            productionSql.Append(" from tf_production where production_id=").Append(id).Append(";");
            //doUploadData("tf_production", "add", Convert.ToString(id), "PRODUCTION_ID", productionSql.ToString());

            DataItem item1 = new DataItem();
            item1.tabName = "tf_production";
            item1.tabIdType = "add";
            item1.tabId = Convert.ToString(id);
            item1.tabIdName = "PRODUCTION_ID";
            item1.sql = productionSql.ToString();
            Thread t = new Thread(new ThreadStart(item1.H));
            t.Start();

            //tf_production_quality
            StringBuilder qualitySql = new StringBuilder();
            qualitySql.Append("select quality_id,production_id,quality_code,check_name,check_type,sample_type,");
            qualitySql.Append("strftime('%Y-%m-%d', check_date, 'localtime') CHECK_DATE,check_person,");
            qualitySql.Append("status,strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE,create_staff_id ");
            qualitySql.Append(" from tf_production_quality where quality_id=").Append(qualityId).Append(";");
            //doUploadData("tf_production_quality", "add", Convert.ToString(qualityId), "QUALITY_ID", qualitySql.ToString());
            DataItem item2 = new DataItem();
            item2.tabName = "tf_production_quality";
            item2.tabIdType = "add";
            item2.tabId = Convert.ToString(qualityId);
            item2.tabIdName = "QUALITY_ID";
            item2.sql = qualitySql.ToString();
            Thread t2 = new Thread(new ThreadStart(item2.H));
            t2.Start();

            //tf_production_quality_item
            StringBuilder itemSql = new StringBuilder();
            itemSql.Append("select quality_item_id,quality_id,check_item_id,check_item_value,status from tf_production_quality_item ");
            itemSql.Append("  where quality_item_id=").Append(itemId).Append(";");
            //doUploadData("tf_production_quality_item", "add", Convert.ToString(itemId), "QUALITY_ITEM_ID", itemSql.ToString());
            DataItem item3 = new DataItem();
            item3.tabName = "tf_production_quality_item";
            item3.tabIdType = "add";
            item3.tabId = Convert.ToString(itemId);
            item3.tabIdName = "QUALITY_ITEM_ID";
            item3.sql = itemSql.ToString();
            Thread t3 = new Thread(new ThreadStart(item3.H));
            t3.Start();

            //tf_production_sales
            StringBuilder saleSql = new StringBuilder();
            saleSql.Append("select production_sales_id,production_id,sales_type,");
            saleSql.Append("strftime('%Y-%m-%d', sales_date, 'localtime') SALES_DATE,buy_unit,contact_way,loco,status,");
            saleSql.Append("strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE,create_staff_id from tf_production_sales ");
            saleSql.Append(" where production_sales_id=").Append(saleId).Append(";");
            //doUploadData("tf_production_sales", "add", Convert.ToString(saleId), "PRODUCTION_SALES_ID", saleSql.ToString());
            DataItem item4 = new DataItem();
            item4.tabName = "tf_production_sales";
            item4.tabIdType = "add";
            item4.tabId = Convert.ToString(saleId);
            item4.tabIdName = "PRODUCTION_SALES_ID";
            item4.sql = saleSql.ToString();
            Thread t4 = new Thread(new ThreadStart(item4.H));
            t4.Start();
            return id;
        }

        public bool doEditProduction(DynamicParameters d)
        {
            BatchDao dao = new BatchDao();
            //修改表tf_production数据
            dao.doEcitProduction(d);
            //修改表tf_production_quality数据
            dao.doEditQuality(d);
            //修改表tf_production_quality_item
            dao.doEditQalityItem(d);
            //修改表tf_production
            dao.doUpdHarvest(d);
            //修改表tf_production_sales
            dao.doUpdSales(d);
            return true;
        }

        public bool doUpdHarvest(DynamicParameters d)
        {
            BatchDao dao = new BatchDao();
            return dao.doUpdHarvest(d);
        }

        public int doAddSales(DynamicParameters d)
        {
            BatchDao dao = new BatchDao();
            return dao.doAddSales(d);
        }

        public bool doUpdSales(DynamicParameters d)
        {
            BatchDao dao = new BatchDao();
            return dao.doUpdSales(d);
        }

        public bool delProduction(int productionId)
        {
            BatchDao dao = new BatchDao();
            return dao.delProduction(productionId);
        }

        public dynamic queryProductionById(int productionId)
        {
            BatchDao dao = new BatchDao();
            return dao.queryProductionById(productionId);
        }

        public dynamic queryEnterAndProduceCode(int corpProductId)
        {
            BatchDao dao = new BatchDao();
            return dao.queryEnterAndProduceCode(corpProductId);
        }
    }
}
