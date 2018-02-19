using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Shrikrishna
{
    public partial class Setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
        //{
        //    if(!IsPostBack)
        //    {

        //    }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = Session["pws"].ToString();
            if (txtold.Text == Session["pws"].ToString())
            {
                SqlParameter[] p = new SqlParameter[2];
                p[0] = new SqlParameter("@Operation", "changepws");
                p[1] = new SqlParameter("@password", txtnew.Text);
                int i = connection.ExecuteQuery("UserinfoSp", p);
                if (i > 0)
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                Label1.Text = "Invalid Old Password";
            }
        }
    }
}