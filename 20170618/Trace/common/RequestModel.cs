using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trace
{
   public class Jobject
    {
        public head head { get; set; }

        public body body { get; set; }

        public string respData { get; set; }
    }

    public class RequestBody
    {
        public head head { get; set; }

        public Dictionary<string, Object> body { get; set; }

        public string respData { get; set; }
    }

    public class QueryRequestBody
    {
        public head head { get; set; }

        public string body { get; set; }

        public string respData { get; set; }
    }

    public class AsynRequestBody
    {
        public head head { get; set; }

        public List<dynamic> body { get; set; }

        public string respData { get; set; }
    }

    public class head
    {
        public string channelCode { get; set; }

        public string userIp { get; set; }

        public string reqTime { get; set; }

        public string ticket { get; set; }

        public string token { get; set; }

        public string respCode { get; set; }

    }

    public class body
    {

        //public string accNbr { get; set; }

        //public string accNbrType { get; set; }

        //public string cityCode { get; set; } 
        public string produceName { get; set; }
        public string farmlandName { get; set; }

        public long productionId { get; set; }
        public string dzType { get; set; }
        public object page { get; set; }

        public object pageSize { get; set; }
        public string actionType { get; set; }

        public string amount { get; set; }

        public string amountUnit { get; set; }

        public long orderSeq { get; set; }

        public DateTime actionDate { get; set; }

       // public object createtaffId { get; set; }

        public string actionStaffId { get; set; }

        public string remark { get; set; }

        public string status { get; set; }
      
        public object ids { get; set; }

        public string detailId { get; set; }

     
        public object area { get; set; }
      

        public object actionId { get; set; }
        public string farmName { get; set; }
        public string enterId { get;set; }
        public string areaCode { get; set;}

        public string farmLandId { get; set; }
        public string enterpriseId { get; set; }
        public string farmLandNbr { get; set; }
        public string farmLandName { get; set; }
        public string farmLandType { get; set; }
        public string areaId { get; set; }

       
       
    }
}

