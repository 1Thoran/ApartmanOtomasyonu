using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApatmanOtomasyonuD
{

     class SqlHelper
    {
        private string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlHelper() 
        { 
            ConnectionString = "Data Source=AHMET\\SQLEXPRESS;Initial Catalog=Apartman;Integrated Security=True";
            Connection = new SqlConnection(ConnectionString);
        }
        public void ExecuteProc(String procName,params SqlParameter[] ps)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procName;
            cmd.Parameters.AddRange(ps);
            cmd.Connection = Connection;
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();
        }
        public DataTable GetTable(string query) 
        {
            SqlDataAdapter sda = new SqlDataAdapter(query,ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
