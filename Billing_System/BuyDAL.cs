using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    class BuyDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region select data from  database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM products ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion
        #region Insert data in database
        public bool Insert(BuyBLL u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO products(name,expiry_date, price,name_of_mfg ,batch_no) VALUES (@name, @expiry_date, @price, @name_of_mfg,@batch_no)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@expiry_date", u.expiry_date);
                cmd.Parameters.AddWithValue("@price", u.price);
                cmd.Parameters.AddWithValue("@name_of_mfg", u.name_of_mfg);
                cmd.Parameters.AddWithValue("@batch_no", u.batch_no);


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
        #region Update data in database
        public bool update(BuyBLL u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
           
            try
            {
                string sql = "UPDATE PRODUCTS SET name=@name, name_of_mfg=@name_of_mfg, batch_no=@batch_no,expiry_date=@expiry_date, price=@price WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@name_of_mfg", u.name_of_mfg);
                cmd.Parameters.AddWithValue("@batch_no", u.batch_no);
                cmd.Parameters.AddWithValue("@expiry_date", u.expiry_date);
                cmd.Parameters.AddWithValue("@price", u.price);
                cmd.Parameters.AddWithValue("@id", u.id);

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
        #region delete data from database
        public bool delete(BuyBLL u)
        {
            bool issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
           
            try
            {
                string sql = "DELETE FROM PRODUCTS WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", u.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
                }
            }
            catch(Exception ex)
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
        #region Search user from database
        public DataTable Search(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM products WHERE name LIKE '%"+keywords+ "%' OR name_of_mfg LIKE '%" + keywords + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region METHOD TO SEARCH PRODUCT IN TRANSACTION MODULE
        public BuyBLL GetProductsForTransaction(string keyword)
        {
            //Create an object of productsBLL and return it
            BuyBLL p = new BuyBLL();
            //SqlConnection
            SqlConnection conn = new SqlConnection(myconnstrng);
            //Datatable to store data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Write the Query to Get the detaisl
                string sql = "SELECT name, name_of_mfg, batch_no,price, expiry_date FROM products WHERE name LIKE '%" + keyword + "%'";
                //Create Sql Data Adapter to Execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open DAtabase Connection
                conn.Open();

                //Pass the value from adapter to dt
                adapter.Fill(dt);

                //If we have any values on dt then set the values to productsBLL
                if (dt.Rows.Count > 0)
                {
                    p.name = dt.Rows[0]["name"].ToString();
                    p.price = decimal.Parse(dt.Rows[0]["price"].ToString());
                    p.expiry_date = DateTime.Parse(dt.Rows[0]["expiry_date"].ToString());
                    p.name_of_mfg = dt.Rows[0]["name_of_mfg"].ToString();
                    p.batch_no = dt.Rows[0]["batch_no"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }

            return p;
        }
        #endregion



    }
}

