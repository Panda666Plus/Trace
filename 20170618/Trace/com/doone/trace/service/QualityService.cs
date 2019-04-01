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
    class QualityService
    {


        public int queryCount(String qualityName)
        {
            QualityDao qualityDao = new QualityDao();
            return qualityDao.queryCount(qualityName);
        }

        public DataTable queryPage(String qualityName, int pageSize, int pageIndex)
        {
            QualityDao qualityDao = new QualityDao();
            return qualityDao.queryPage(qualityName, pageSize, pageIndex);
        }

        public bool doAdd(DynamicParameters d)
        {
            QualityDao qualityDao = new QualityDao();
            return qualityDao.doAdd(d);
        }

        public bool doUpdate(DynamicParameters d)
        {
            QualityDao qualityDao = new QualityDao();
            return qualityDao.doUpdate(d);
        }

        public bool batchDel(String ids)
        {
            QualityDao qualityDao = new QualityDao();
            return qualityDao.batchDel(ids);
        }
    }
}
