using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    class SellDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert data in database
        public bool Insert(TempBLL t)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO temp(discount) VALUES (@discount)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                // cmd.Parameters.AddWithValue("@c_name", t.c_name);
                /* cmd.Parameters.AddWithValue("@p_name", t.p_name);
                 cmd.Parameters.AddWithValue("@contact", t.price);
                 cmd.Parameters.AddWithValue("@p_by_dr", t.p_by_dr);
                 cmd.Parameters.AddWithValue("@mfg_name", t.mfg_name);
               //  cmd.Parameters.AddWithValue("@e_date", t.e_date);
                 cmd.Parameters.AddWithValue("@b_no", t.b_no);
                 cmd.Parameters.AddWithValue("@price", t.price);
                 cmd.Parameters.AddWithValue("@qty", t.qty);
                 cmd.Parameters.AddWithValue("@s_total", t.s_total);

                 cmd.Parameters.AddWithValue("@gst", t.gst);
                 cmd.Parameters.AddWithValue("@total", t.total);
                 */
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;

                }
                else
                {
                    issuccess = false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }
            return issuccess;

        }
        #endregion




       
    }
}
