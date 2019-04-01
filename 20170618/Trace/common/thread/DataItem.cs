using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.Common.thread
{
    class DataItem : DataHandler
    {
        public string tabName, tabIdType, tabId, tabIdName, sql;

        public void H()
        {
            doUploadData(tabName, tabIdType, tabId, tabIdName, sql);
        }
    }
}
