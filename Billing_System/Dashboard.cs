using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {

        }

        private void lblbuy_Click(object sender, EventArgs e)
        {
            Buy a = new Buy();
            a.Show();
        }

        private void lblSell_Click(object sender, EventArgs e)
        {
            Sell b = new Sell();
            b.Show();
        }
    }
}
