using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Trace.com.doone.trace.dao;
using Trace.com.doone.trace.model;
using Trace.Common;
using Trace.Common.thread;
//using Trace.Common.thread;

namespace Trace.com.doone.trace.service
{
    class ArchivesService
    {
        # region 查询产品档案
        public ObservableCollection<Product> queryArchives(string productName, string startDate, string endDate, int pageNo, int pageSize)
        {
            ArchivesDao dao = new ArchivesDao();
            JArray array = dao.queryArchives(productName, startDate, endDate, pageNo, pageSize);
            ObservableCollection<Product> list = new ObservableCollection<Product>();
            if(array != null)
            {
                foreach (var item in array)
                {
                    JObject jobj = (JObject) item;
                    Product product = new Product();
                    product.productName = jobj["PRODUCT_NAME"] != null ? jobj["PRODUCT_NAME"].ToString() : "";
                    product.plantDate = jobj["PLANT_DATE"] != null ? jobj["PLANT_DATE"].ToString() : "";
                    product.corpProductId = jobj["CORP_PRODUCT_ID"] != null ? jobj["CORP_PRODUCT_ID"].ToString() : "";
                    // 图片处理
                    string path = jobj["FILE_NAME"].ToString() != null ? jobj["FILE_NAME"].ToString() : "";
                    if(path != "")
                    {
                        product.imagePath = new BitmapImage(new Uri(path));
                    }   
                    list.Add(product);
                }
            }
            return list;
        }
        #endregion

        public int queryCount(string productName, string startDate, string endDate)
        {
            ArchivesDao dao = new ArchivesDao();
            return dao.queryCount(productName, startDate, endDate);
        }

        #region 查询Byid
        public dynamic queryById(int aid)
        {
            ArchivesDao archDao = new ArchivesDao();
            return archDao.queryById(aid);
        }
        #endregion

        #region 新增
        public bool doAdd(DynamicParameters d)
        {
            ArchivesDao archDao = new ArchivesDao();
            int tabId = archDao.doAdd(d);

            //上传数据
            StringBuilder upSql = new StringBuilder();
            upSql.Append("select corp_product_id, enterprise_id, produce_id, farmland_id, product_name, product_source, product_type,");
            upSql.Append("strftime('%Y-%m-%d', plant_date, 'localtime') PLANT_DATE,plant_area,plant_area_unit,seed_name,seed_amount,image_id,status,");
            upSql.Append("strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE,strftime('%Y-%m-%d', status_date, 'localtime') STATUS_DATE,");
            upSql.Append("origin_desc,remark from tf_enterprise_product where corp_product_id=").Append(tabId).Append(";");

            //doUploadData("tf_enterprise_product", "add", Convert.ToString(tabId), "CORP_PRODUCT_ID", upSql.ToString());
            DataItem item = new DataItem();
            item.tabName = "tf_enterprise_product";
            item.tabIdType = "add";
            item.tabId = Convert.ToString(tabId);
            item.tabIdName = "CORP_PRODUCT_ID";
            item.sql = upSql.ToString();
            Thread t = new Thread(new ThreadStart(item.H));
            t.Start();

            return true;
        }
        #endregion

        #region 修改
        public bool doModify(DynamicParameters d,string corpId)
        {
            ArchivesDao archDao = new ArchivesDao();
            bool isEdit = archDao.doModify(d);
            //上传数据
            StringBuilder editSql = new StringBuilder();
            editSql.Append("select corp_product_id, enterprise_id, produce_id, farmland_id, product_name, product_source, product_type,");
            editSql.Append("strftime('%Y-%m-%d', plant_date, 'localtime') PLANT_DATE,plant_area,plant_area_unit,seed_name,seed_amount,image_id,status,");
            editSql.Append("strftime('%Y-%m-%d', create_date, 'localtime') CREATE_DATE,strftime('%Y-%m-%d', status_date, 'localtime') STATUS_DATE,");
            editSql.Append("origin_desc,remark from tf_enterprise_product where corp_product_id=").Append(corpId).Append(";");

            //doUploadData("tf_enterprise_product", "edit", Convert.ToString(corpId), "CORP_PRODUCT_ID", editSql.ToString());

            DataItem item = new DataItem();
            item.tabName = "tf_enterprise_product";
            item.tabIdType = "edit";
            item.tabId = Convert.ToString(corpId);
            item.tabIdName = "CORP_PRODUCT_ID";
            item.sql = editSql.ToString();
            Thread t = new Thread(new ThreadStart(item.H));
            t.Start();

            return isEdit;
        }
        #endregion

        # region 批量删除
        public bool delBatch(String ids)
        {
            ArchivesDao archDao = new ArchivesDao();
            bool isDel = archDao.delBatch(ids);

            //上传数据
            //doUploadData("tf_enterprise_product", "del", Convert.ToString(ids), "CORP_PRODUCT_ID", "");
            DataItem item = new DataItem();
            item.tabName = "tf_enterprise_product";
            item.tabIdType = "del";
            item.tabId = Convert.ToString(ids);
            item.tabIdName = "CORP_PRODUCT_ID";
            item.sql = "";
            Thread t = new Thread(new ThreadStart(item.H));
            t.Start();

            return isDel;
        }
        #endregion
    }

}
