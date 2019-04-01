using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Trace;
using Trace.com.doone.trace.service;

namespace Trace
{
    class Program
    {
      public  static void ProgramMain()

        {
            WebClient wb = new WebClient();
            wb.Encoding = Encoding.UTF8;

            string url = LoginService._STURL + "/api/prodcution/qryQuality";

            //string url = "/api/prodcution/qryQuality";

            var reqModel = new Jobject()
            {
                head = new head
                {
                    channelCode = "010200000000010000000001",
                    userIp = "192.168.1.165",
                    reqTime = "20170101120000111",
                    ticket = "WT2017010112000011100000000",
                    token = "abeadedf-dcd8-4f22-a035-569168006ec1"
                    
                },
                body = new body
                {
                    produceName = "",
                    farmlandName = ""
                }
            };

            var json = "requestBody=" + JsonConvert.SerializeObject(reqModel);
            MessageBox.Show(json);
          ////  MessageBox.Show(HttpHelper.PostWebRequest(url, json, Encoding.UTF8));
          // Console.WriteLine(HttpHelper.PostWebRequest(url, json, Encoding.UTF8));
          //  Console.ReadLine();


        }
    }
}
