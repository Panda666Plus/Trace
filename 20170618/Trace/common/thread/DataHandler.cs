using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.service;

namespace Trace.Common
{
    class DataHandler
    {
        public void doUploadData(string tabName, string tabIdType, string tabId, string tabIdName, string sql)
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            dict.Add("tabName", tabName);//表名
            dict.Add("tabIdType", tabIdType);// add, edit, del（类型）
            dict.Add("tabId", tabId);//新增返回Id
            dict.Add("tabIdName", tabIdName);//主键

            DataHandlerService dls = new DataHandlerService();
            List<dynamic> datas = new List<dynamic>();
            if (!"".Equals(sql))
            {
                dict.Add("sql", sql);//上传数据查询sql
                datas = dls.queryBySql(dict);//1、查询要上传的数据
            }

            //2、转化为json
            //3、判断网络是否通
            if (IsNetWork())
            {
                if (datas.Count > 0)
                {
                    dict.Add("tabValue", datas[0]);//需要上传的数据
                }
                //4、创建一个任务
                Task<string> task = new Task<string>(() =>
                {
                    Console.WriteLine("#####>>>>" + JsonConvert.SerializeObject(dict));
                    return HttpHelper.postReqeustJson(PubData.DATA_UPLOAD_URL, dict);
                });
                //启动任务,并安排到当前任务队列线程中执行任务(System.Threading.Tasks.TaskScheduler)
                task.Start();
                //5、获得任务的执行结果
                Console.WriteLine("任务执行结果：{0}", task.Result.ToString());
                //6、上传成功后更新上传状态
                if ("true".Equals(task.Result.ToString()))
                {
                    dls.updateState(dict);
                }
            }

        }


        #region ping网络是否通
        public bool IsNetWork()
        {
            string url = "www.baidu.com";
            System.Net.NetworkInformation.Ping ping;
            System.Net.NetworkInformation.PingReply res;
            ping = new System.Net.NetworkInformation.Ping();
            try
            {
                res = ping.Send("www.baidu.com");
                if (res.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
