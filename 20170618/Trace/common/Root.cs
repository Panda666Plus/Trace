using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.common
{
    public class ProductionDetailAddHead
    {
        /// <summary>
        /// 
        /// </summary>
        public string resTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ticket { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string respCode { get; set; }
    }

    public class ProductionDetailAddItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int PRODUCTION_ID { get; set; }
        /// <summary>
        /// 公斤
        /// </summary>
        public string AMOUNT_UNIT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string STATUS { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACTION_DATE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CREATE_DATE { get; set; }
        /// <summary>
        /// 1#田块(绿茶)
        /// </summary>
        public string PRODUCTION_NAME { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int DETAIL_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AMOUNT { get; set; }
        /// <summary>
        /// 王厂长
        /// </summary>
        public string ACTION_STAFF_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ORDER_SEQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ACTION_ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACTION_TYPE { get; set; }
    }

    public class ProductionDetailAddRespData
    {
        /// <summary>
        /// 
        /// </summary>
        public int pageNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int startRow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int endRow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductionDetailAddItem> list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int firstPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int prePage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int nextPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int lastPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isFirstPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string isLastPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hasPreviousPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string hasNextPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int navigatePages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> navigatepageNums { get; set; }
    }

    public class ProductionDetailAddModel
    {
        /// <summary>
        /// 
        /// </summary>
        public ProductionDetailAddModelHead head { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int respData { get; set; }
    }

    public class ProductionDetailAddModelHead
    {
        public string resTime { get; set; }
        public string ticket { get; set; }
        public string respCode { get; set; }
    }
}
