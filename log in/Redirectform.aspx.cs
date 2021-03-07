using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace log_in
{
    public partial class Redirectform : System.Web.UI.Page
    {
        ADO d = new ADO();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            d.Connecter();
            //d.cmd.CommandText="select "
            //Response.Write(Request.QueryString["pwd"]);
            //RemplirGrid();
            d.cmd.CommandText = "select pass from users where password=@pass";
            d.cmd.Connection = d.cnx;
            d.cmd.Parameters.AddWithValue("@pass", Request.QueryString["pwd"]);
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            passuser.Text = d.dt.Rows[0].ToString();
            passuser.Text = string.Empty;
            foreach (DataRow dataRow in d.dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    //Console.WriteLine(item);
                    passuser.Text = item.ToString();
                }
            }

            //passuser.Text = d.cmd.ExecuteReader().ToString();
            d.Deconnecter();
        }
    }
}