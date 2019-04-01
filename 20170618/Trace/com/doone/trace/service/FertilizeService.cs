using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    //施肥业务层
    class FertilizeService
    {
        //施肥动作
        public bool doFertilize(DynamicParameters d)
        {
            FertilizeDao fDao = new FertilizeDao();
            return fDao.doFertilize(d);
        }
    }
}
