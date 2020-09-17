using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Billing_System
{
    class TempBLL
    {
        public int id { get; set; }

        public string c_name { get; set; }


        public string p_name { get; set; }

        public string p_by_dr { get; set; }

        public string mfg_name { get; set; }

        public string e_date { get; set; }

        public string b_no { get; set; }

        public decimal price { get; set; }

        public decimal qty { get; set; }

        public decimal s_total { get; set; }

        public decimal discount { get; set; }

        public decimal gst { get; set; }

        public decimal  total  { get; set; }

        public decimal grand_total { get; set; }
        public DateTime b_date { get; set; }
    }
}
