using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace qldtnckh
{
    class DataConnect
    {
         string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLDTNCKH;Integrated Security=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
        public DataTable GetDataTable(String query)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = GetConnection();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,conn);
                sqlDataAdapter.Fill(dt);
            }
            catch (Exception) { MessageBox.Show("Error"); }
            return dt;
        }
        public DataSet GetDataSet(String query)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = GetConnection();
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(ds);
            }
            catch (Exception) { MessageBox.Show("Error"); }
            return ds;
        }
        public bool fix(String query)
        {
            
            SqlConnection conn = GetConnection();
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
             
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return false; }
            finally { conn.Close(); }
            return true;
        }
    }
}
