using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.com.doone.trace.dao;

namespace Trace.com.doone.trace.service
{
    class DictService
    {
        public List<dynamic> queryDictByType(string type)
        {
            DictDao dao = new DictDao();
            return dao.queryDictByType(type);
        }
    }
}
