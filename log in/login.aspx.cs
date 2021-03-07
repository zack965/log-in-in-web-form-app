using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace log_in
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        ADO d = new ADO();
        protected void Button1_Click(object sender, EventArgs e)
        {
            d.Connecter();
            res.Text = string.Empty;
            //select * from users where username = '"+username.Text+"' and password = '"+password.Text+"'
            //select * from users
            d.cmd.CommandText = "select pass from users where username = @un and password=@pwd";
            d.cmd.Parameters.AddWithValue("@un", txtusername.Text);
            d.cmd.Parameters.AddWithValue("@pwd", txtpassword.Text);
            d.cmd.Connection = d.cnx;
            d.dr = d.cmd.ExecuteReader();
            d.dt.Load(d.dr);
            foreach (DataRow dataRow in d.dt.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    //Console.WriteLine(item);
                    res.Text = item.ToString();
                }
            }
            if (res.Text == "admin")
            {
                //Response.Redirect("Redirectform.aspx");
                Response.Redirect("adminform.aspx");
            }else if(res.Text == "opera")
            {
                Response.Redirect("operaform.aspx");
            }else if(res.Text == string.Empty)
            {
                res.Text ="invalid log in ";
            }
            /*
             d.dt.Load(d.dr);
        
            GridView1.DataSource = d.dt;
            GridView1.DataBind();

             */
            /*if(res.Text != string.Empty)
            {
                //Response.Redirect("Redirectform.aspx");
                Response.Redirect("Redirectform.aspx?pwd=" + txtpassword.Text + "");
            }
            */
            d.Deconnecter();
        }
    }
}