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
    public partial class Select_Bill : System.Web.UI.Page
    {
        string spname = "", operation = "",custname="",Dtdate="",s_name="";
        int mainloop = 0,secondloop=0,gstrate=0,bilno=0;
        double Total = 0;
        DataRow dr;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    loadgrid();
                }
                else
                {
                    btnsave.Enabled = false;
                    Button2.Enabled = false;
                }

                }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int billno = Convert.ToInt32(Txtbillno.Text);
            spname = "sp_MainSale"; operation = "loadbillno";
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", operation);
            objsql[1] = new SqlParameter("@bill_no", billno);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {


                int Bill = Convert.ToInt32(dt.Rows[0]["bill_no"].ToString());
                Response.Redirect("BIIING.aspx?bill=" + Bill);
            }
            else
            {
                Label1.Text = "Record Not Found";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        private void loadgrid()
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            dt5.Columns.Add(new DataColumn("Name Of Customer", typeof(string)));
            dt5.Columns.Add(new DataColumn("Date", typeof(string)));
            dt5.Columns.Add(new DataColumn("Total", typeof(string)));

            spname = "sp_MainSale"; operation = "SLOBN";
            
            SqlParameter[] objsql1 = new SqlParameter[1];
            objsql1[0] = new SqlParameter("@operation", operation);
            dt1 = connection.GetData(spname, objsql1);
            if(dt1!=null)
            {
                mainloop = dt1.Rows.Count;
            }
            for (int i = 1; i < mainloop; i++)
            {
                spname = "sp_MainSale"; operation = "Get1SLOBN";

                SqlParameter[] objsql2 = new SqlParameter[2];
                objsql2[0] = new SqlParameter("@operation", operation);
                objsql2[1] = new SqlParameter("@Bill_no", Convert.ToInt32(dt1.Rows[i]["Bill_no"].ToString()));
                dt2 = connection.GetData(spname, objsql2);
                    if (dt2 != null)
                    {
                        secondloop = dt2.Rows.Count;
                    if(dt2.Rows[0]["Bill_no"]!=DBNull.Value)
                    {
                        bilno = Convert.ToInt32(dt2.Rows[0]["Bill_no"].ToString());
                    }
                    if (dt2.Rows[0]["S_G_Name"] != DBNull.Value)
                    {
                        s_name =dt2.Rows[0]["S_G_Name"].ToString();
                    }
                }
                    for (int j = 1; j <=secondloop; j++)
                     {


                             spname = "sp_MainSale"; operation = "Get1FType";

                        SqlParameter[] objsql3 = new SqlParameter[3];
                        objsql3[0] = new SqlParameter("@operation", operation);
                        objsql3[1] = new SqlParameter("@Bill_no", bilno);
                        objsql3[0] = new SqlParameter("@S_G_Name", s_name);
                            dt3 = connection.GetData(spname, objsql3);
                            if (dt3 != null)
                            {
                                if (dt3.Rows[j]["gstrate"] != DBNull.Value)
                                {
                                    gstrate =gstrate+(Convert.ToInt32(dt3.Rows[j]["gstrate"].ToString()));
                                }
                                if (dt2.Rows[i]["Total"] != DBNull.Value)
                                {
                                    Total = Total + (Convert.ToInt32(dt2.Rows[i]["Total"].ToString()));
                                }
                                if (dt2.Rows[i]["Date"] != DBNull.Value)
                                {
                                    Dtdate = dt2.Rows[i]["Date"].ToString();
                                }

                    }

                   
                }
                spname = "sp_MainSale"; operation = "Get2FCust";

                SqlParameter[] objsql4 = new SqlParameter[3];
                objsql4[0] = new SqlParameter("@operation", operation);
                objsql4[1] = new SqlParameter("@Bill_no", bilno);
                objsql4[0] = new SqlParameter("@S_G_Name", s_name);
                dt4 = connection.GetData(spname, objsql4);
                if (dt4 != null)
                {
                    if (dt4.Rows[i]["name"] != DBNull.Value)
                    {
                        custname = dt4.Rows[i]["name"].ToString();
                    }
                }

                dr = dt5.NewRow();
                dr["Name Of Customer"] = custname;
                dr["Date"] = Convert.ToString(Dtdate);
                dr["Total"] = Convert.ToString(Total);

            }
            GridView1.DataSource = dt5;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}