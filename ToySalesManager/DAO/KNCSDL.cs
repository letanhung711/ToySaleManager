using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ToySalesManager.DAO
{
    class KNCSDL
    {
        private static SqlConnection cnn = new SqlConnection();
        public static void openConnection()
        {
            try
            {
                string sqlcon = @"Data Source=.\SQLEXPRESS;Initial Catalog=ToySalesManager;Integrated Security=True";
                cnn.ConnectionString = sqlcon;
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();
            }
            catch(Exception)
            {
                MessageBox.Show("Kết nối không thành công!!!","Thông báo");
            }
        }
        public static void closeConnection()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        public static DataTable readData(string sql)
        {
            openConnection();
            SqlCommand cd = new SqlCommand(sql, cnn);
            SqlDataReader dr = cd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            closeConnection();
            return dt;
        }
        public static void executeQuery(string sql)
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmd.ExecuteNonQuery();
            closeConnection();
        }
    }
}
