using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace log_in
{
    public class ADO
    {
        public SqlConnection cnx = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlCommandBuilder cb = new SqlCommandBuilder();
        public DataTable dt = new DataTable();
        public DataRow dtr;
        public SqlDataReader dr;
        public DataSet ds = new DataSet();
        public SqlDataAdapter dap = new SqlDataAdapter();
        // method connecter
        public void Connecter()
        {
            if (cnx.State == ConnectionState.Broken || cnx.State == ConnectionState.Closed)
            {
                cnx.ConnectionString = "Data Source=DESKTOP-RKVCGVV;Initial Catalog=tdiadonetdevtechnology;Integrated Security=True";
                cnx.Open();
            }
        }
        // method deconnecter
        public void Deconnecter()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
    }
}