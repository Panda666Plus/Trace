using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.ViewsModel
{
    public class Myobjcts
    {
        private string hARVEST_DATE;
        public string HARVEST_DATE
        {
            get { return this.hARVEST_DATE; }
            set { hARVEST_DATE = value; }
        }

        private string pRODUCTION_CODE;
        public string PRODUCTION_CODE
        {
            get { return this.pRODUCTION_CODE; }
            set { pRODUCTION_CODE = value; }
        }

        private string pRODUCTION_CODEs;
        public string PRODUCTION_CODEs
        {
            get { return this.pRODUCTION_CODEs; }
            set { pRODUCTION_CODEs = value; }
        }

        private int pRODUCTION_ID;
        public int PRODUCTION_ID
        {
            get { return this.pRODUCTION_ID; }
            set { pRODUCTION_ID = value; }
        }
    }
}
