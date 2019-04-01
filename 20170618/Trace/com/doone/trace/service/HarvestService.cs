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
    class HarvestService
    {
        public int queryCount(String produceName)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.queryCount(produceName);
        }

        public DataTable queryPage(String produceName, int pageSize, int pageIndex)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.queryPage(produceName, pageSize, pageIndex);
        }

        public bool doAdd(DynamicParameters d)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.doAdd(d);
        }

        public bool doUpdate(DynamicParameters d)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.doUpdate(d);
        }

        public bool batchDel(String ids)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.batchDel(ids);
        }

        public bool doHarv(DynamicParameters d)
        {
            HarvestDao harvDao = new HarvestDao();
            return harvDao.doHarv(d);
        }

        public List<dynamic> queryRecods()
        {
            RecordsDao recordDao = new RecordsDao();
            return recordDao.queryRecords();
        }
    }
}
