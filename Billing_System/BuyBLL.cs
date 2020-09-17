using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    class BuyBLL
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime expiry_date { get; set; }
        public decimal price { get; set; }

        public DateTime date { get; set; }
        public decimal qty { get; set; }

        public string  name_of_mfg { get; set; }

        public string batch_no { get; set; }
    }
}
