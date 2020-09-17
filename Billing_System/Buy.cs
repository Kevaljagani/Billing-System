using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Billing_System
{
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }
        BuyBLL u = new BuyBLL();
        BuyDAL dal = new BuyDAL();

        private void Buy_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["qty"].Visible = false;

        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";


        }


        private void label6_Click(object sender, EventArgs e)
        {
            DateTime k = DateTime.Parse(textBox3.Text);
            u.name = textBox1.Text;
            u.price = decimal.Parse(textBox2.Text);
            u.expiry_date = k;
            u.name_of_mfg = textBox6.Text;
            u.batch_no = textBox7.Text;

            bool success = dal.Insert(u);
            if (success == true)
            {
                MessageBox.Show("Successfully added");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add product");
            }

            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;





            dataGridView1.Columns["qty"].Visible = false;





        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(textBox5.Text);
            u.name = textBox1.Text;
            u.name_of_mfg = textBox6.Text;
            u.batch_no = textBox7.Text;
            u.price = decimal.Parse(textBox2.Text);
            u.expiry_date = DateTime.Parse(textBox3.Text);

            bool success = dal.update(u);
            if (success == true)
            {
                MessageBox.Show("Successfully updated");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to Update");
            }
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["qty"].Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(textBox5.Text);
            u.name = textBox1.Text;
            u.name = textBox1.Text;
            u.name_of_mfg = textBox6.Text;
            u.price = decimal.Parse(textBox2.Text);
            u.expiry_date = DateTime.Parse(textBox3.Text);

            bool success = dal.delete(u);
            if (success == true)
            {
                MessageBox.Show("successfully deleted");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete");

            }
            DataTable dt = dal.Select();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["qty"].Visible = false;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string keywords = textBox4.Text;

            //Chec if the keywords has value or not
            if (keywords != null)
            {
                //Show user based on keywords
                DataTable dt = dal.Search(keywords);
                dataGridView1.DataSource = dt;
            }
            else
            {
                //show all users from the database
                DataTable dt = dal.Select();
            }
        }
    }
}
