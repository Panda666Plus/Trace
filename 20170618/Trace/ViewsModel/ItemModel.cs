using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.ViewsModel
{
    class ItemModel : NotifyProperty
    {
        private double? number;

        public double? Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;

                this.OnPropertyChanged("Number");
            }
        }
    }
}
