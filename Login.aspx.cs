using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Shrikrishna
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            //DataTable d = null;
            //SqlParameter[] key = new SqlParameter[1];
            //key[0] = new SqlParameter("@Operation", "Auth");
            //d = connection.GetData("UserInfoSp", key);
            //if (d != null)
            //{
            //    if (d.Rows[0]["cnt"] == DBNull.Value || Convert.ToUInt32(d.Rows[0]["cnt"]) <= 1)
            //    {
            //        Response.Redirect("About.aspx");
            //    }
            //    else
            //    {
            //        System.Diagnostics.Process run = new System.Diagnostics.Process();
            //        run.StartInfo.UseShellExecute = false;
            //        run.StartInfo.FileName = "D:\\mybackup\\mybat.bat";
            //        //run.StartInfo.Arguments="del d:\\mybackup\\C*.*";
            //        run.StartInfo.RedirectStandardOutput = true;
            //        run.Start();

                    DataTable dt = null;
                    SqlParameter[] o = new SqlParameter[3];

                    o[0] = new SqlParameter("@username", txtuser.Text);
                    o[1] = new SqlParameter("@password", txtpass.Text);
                    o[2] = new SqlParameter("@Operation", "Login");
                    dt = connection.GetData("UserInfoSp", o);
                    if (dt != null)
                    {
                        //if (Convert.ToInt32(dt.Rows[0]["cnt"]) == 1)
                        //{
                        //    SqlParameter[] ob = new SqlParameter[1];
                        //    ob[0] = new SqlParameter("@Operation", "backup");
                        //    connection.ExecuteQuery("UserinfoSp", ob);
                            Session["usr"] = txtuser.Text;
                            Session["pws"] = txtpass.Text;
                            Response.Redirect("Dashboard.aspx");

                        //}

                //    }
                //}
            }
            else
            {
                Response.Redirect("About.aspx");
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            txtuser.Text = "";
            txtpass.Text = "";
            msg.Text = "";


        }
    }
}