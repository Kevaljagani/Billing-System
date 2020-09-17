
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Billing_System
{
    public partial class Sell : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        string cs = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public Sell()
        {
            InitializeComponent();
            Autocomplete();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection(myconnstrng);
        BuyDAL pDAL = new BuyDAL();
        DataTable transactionDT = new DataTable();
        TempBLL t = new TempBLL();
        SellDAL sDAL = new SellDAL();
        DataTable transactionDT2 = new DataTable();

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
                



            

            //Get the keyword from productsearch textbox
            string keyword = textBox4.Text;

            //Check if we have value to txtSearchProduct or not
            if (keyword == "")
            {
                textBox4.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";


                return;
            }

            //Search the product and display on respective textboxes
            BuyBLL p = pDAL.GetProductsForTransaction(keyword);

            //Set the values on textboxes based on p object
            textBox4.Text = p.name;
            textBox6.Text = p.qty.ToString();
            textBox5.Text = p.price.ToString();
            textBox3.Text = p.expiry_date.ToString();
            textBox11.Text = p.name_of_mfg;
            textBox12.Text = p.batch_no;
            
      
        }


        void Autocomplete()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "SELECT * FROM products";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader dr  = cmd.ExecuteReader();
            while(dr.Read())
            {
                 coll.Add(dr.GetString(1));

            }
            textBox4.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox4.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox4.AutoCompleteCustomSource = coll;
            con.Close();

        }

        private void label11_Click(object sender, EventArgs e)
        {
            
            string b = textBox3.Text;
            DateTime c = DateTime.Parse(b);
            DateTime a = dateTimePicker1.Value;
            if (a > c)
            {
                MessageBox.Show("Product expired");
            }


            else
            {
               


                //Get Product Name, Rate and Qty customer wants to buy
                string Name = textBox4.Text;
                decimal Price = decimal.Parse(textBox5.Text);
                decimal Qty = decimal.Parse(textBox6.Text);
                string name_of_mfg = textBox11.Text;
                string batch_no = textBox12.Text;
                DateTime expiry_date = DateTime.Parse(textBox3.Text);
                String Date_Of_Expiry = string.Format( "{0 : dd-mm-yyyy}", expiry_date);
                string c_name = textBox1.Text;
                string b_no = textBox12.Text;
                string discount = textBox9.Text;
                string gst = textBox7.Text;
                





                decimal Total = Price * Qty; //Total=RatexQty

                //Display the Subtotal in textbox
                //Get the subtotal value from textbox
                decimal subTotal = decimal.Parse(textBox8.Text);
                subTotal = subTotal + Total;

                //Check whether the product is selected or not
                if (Name == "")
                {
                    //Display error MEssage
                    MessageBox.Show("Select the product first. Try Again.");
                }
                

                else
                {
                    
                    //Add product to the dAta Grid View
                    transactionDT.Rows.Add(Name, Qty, name_of_mfg, batch_no , Date_Of_Expiry, Price , Total ,c_name,b_no,subTotal,discount,gst);
                   
                    //Show in DAta Grid View
                    dataGridView2.DataSource = transactionDT;
                    //Display the Subtotal in textbox
                    textBox8.Text = subTotal.ToString();
                    textBox10.Text = subTotal.ToString();


                    string subtotal = textBox8.Text;
                    


                    //Clear the Textboxes
                    textBox4.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";




                }
            }
        }

        private void Sell_Load(object sender, EventArgs e)
        {
            
            transactionDT.Columns.Add("Name");
            transactionDT.Columns.Add("Qty");
            transactionDT.Columns.Add("name_of_mfg");
            transactionDT.Columns.Add("batch_no");
            transactionDT.Columns.Add("Date_Of_Expiry");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Total");
            transactionDT.Columns.Add("c_name");
            transactionDT.Columns.Add("b_no");
            transactionDT.Columns.Add("subtotal");
            transactionDT.Columns.Add("discount");
            transactionDT.Columns.Add("gst");
            transactionDT.Columns.Add("grand_total");


        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string value = textBox9.Text;

            if (value == "")
            {
                //Display Error Message
                MessageBox.Show("Please Add Discount (%)");
            }
            else
            {
               
               

                decimal subTotal = decimal.Parse(textBox8.Text);

                //Get the discount in decimal value
                decimal discount = decimal.Parse(textBox9.Text);

                //Calculate the grandtotal based on discount
                decimal grandTotal = ((100 - discount) / 100) * subTotal;

                //Display the GrandTotla in TextBox
                textBox10.Text = grandTotal.ToString();

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    dataGridView2.Rows[i].Cells[10].Value = textBox9.Text;
                }



            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string check = textBox7.Text;
            if (check == "")
            {
                //Display the error message to calcuate discount
                MessageBox.Show("Please enter Tax (%) ");
            }
            else
            {
                //Calculate VAT
                //Getting the VAT Percent first
                decimal previousGT = decimal.Parse(textBox10.Text);
                decimal vat = decimal.Parse(textBox7.Text);
                decimal grandTotalWithVAT = ((100 + vat) / 100) * previousGT;

                //Displaying new grand total with vat
                textBox10.Text = grandTotalWithVAT.ToString();

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    dataGridView2.Rows[i].Cells[11].Value = textBox7.Text;
                }
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {
            bool a;
            try
            {
                XtraReport1 report = new XtraReport1();
                ReportPrintTool printTool = new ReportPrintTool(report);
                printTool.ShowPreview();
                a = true;
                if(a=true)
                {
                    MessageBox.Show("print executed");
                    
                }
                else
                {
                    MessageBox.Show("Print failed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SqlConnection con = new SqlConnection(cs);
            try
            {
               

                SqlCommand cmd = new SqlCommand("DELETE  FROM temp ");

                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            bool b;
            SqlConnection con = new SqlConnection(cs);
            try
            {
                 t.discount = decimal.Parse(textBox9.Text);
                int i;
                for (i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO temp (p_name ,c_name,e_date,mfg_name,b_no,qty,price,total,s_total,discount,gst,grand_total)VALUES( '" + dataGridView2.Rows[i].Cells[0].Value + "', '" + dataGridView2.Rows[i].Cells[7].Value + "', '" + dataGridView2.Rows[i].Cells[4].Value + "', '" + dataGridView2.Rows[i].Cells[2].Value + "', '" + dataGridView2.Rows[i].Cells[3].Value + "', '" + dataGridView2.Rows[i].Cells[1].Value + "', '" + dataGridView2.Rows[i].Cells[5].Value + "', '" + dataGridView2.Rows[i].Cells[6].Value + "', '" + dataGridView2.Rows[i].Cells[9].Value + "', '" + dataGridView2.Rows[i].Cells[10].Value + "', '" + dataGridView2.Rows[i].Cells[11].Value + "', '" + dataGridView2.Rows[i].Cells[12].Value +"')");


                   
                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    b = true;
                    if(b=true)
                    {
                        MessageBox.Show("Product sucessfully added to database");
                    }
                   else
                    {
                        MessageBox.Show("failed to add product to database");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView2.DataSource = null;
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox1.Text = "";
        }
        /*
        private void label22_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            try
            {

               
                    SqlCommand cmd = new SqlCommand("DELETE  FROM temp ");

                    con.Open();
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    con.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        */
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count-1; i++)
            {
                dataGridView2.Rows[i].Cells[12].Value = textBox10.Text;
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
