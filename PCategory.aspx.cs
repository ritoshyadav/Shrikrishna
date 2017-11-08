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
    public partial class PCategory : System.Web.UI.Page
    {
        string spname = "sp_pcategory", operation="";
        int iResult = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    gridload();

                for (int i = 0; i < 101; i++)
                {
                    ddlgstrate.Items.Add(Convert.ToString(i));
                }
                    ddlgstrate.Items.Insert(0, new ListItem("--Select GST Rate--", "0"));

                }
                else
                {
                    btnsave.Enabled = false;
                    Button2.Enabled = false;
                    
                }

            }

        }

       

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearfiled();
        }
        private void gridload()
        {
            string op = "loadall";
            DataTable dt = new DataTable();
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", op);

            dt = connection.GetData(spname, objsql);
            if(dt!=null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if (e.CommandName == "recordedit")
            {
                fill(Id);
                btnsave.Text = "Update";
                Label2.Text = e.CommandArgument.ToString();
            }
            else if (e.CommandName == "recorddelete")
            {
                operation = "delete";
                SqlParameter[] objsql2 = new SqlParameter[2];
                objsql2[0] = new SqlParameter("@operation", operation);
                objsql2[1] = new SqlParameter("@sr", e.CommandArgument);
                iResult = connection.ExecuteQuery(spname, objsql2);
                if (iResult > 0)
                {
                    Label1.Text = "Record Deleted";
                }
                gridload();
                //Label1.Text = "";
            }
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridload();
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                operation = "insert";
                SqlParameter[] objsql1 = new SqlParameter[4];
                objsql1[0] = new SqlParameter("@operation", operation);
                objsql1[1] = new SqlParameter("@pcategory", txtproductcategory.Text);
                objsql1[2] = new SqlParameter("@hsncode", txthsncode.Text);
                objsql1[3] = new SqlParameter("@gstrate", ddlgstrate.Text);

                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Saved Record";
                }
            }
            else if(btnsave.Text=="Update")
            {
                operation = "update";
                SqlParameter[] objsql1 = new SqlParameter[5];
                objsql1[0] = new SqlParameter("@operation", operation);
                objsql1[1] = new SqlParameter("@sr", Label2.Text);
                objsql1[2] = new SqlParameter("@pcategory", txtproductcategory.Text);
                objsql1[3] = new SqlParameter("@hsncode", txthsncode.Text);
                objsql1[4] = new SqlParameter("@gstrate", ddlgstrate.Text);

                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Updated Record";
                    btnsave.Text = "Save";
                    Label1.Text = "";

                }
            }
            gridload();
            // Label1.Text = "";
            clearfiled();
        }
        private void fill(string id)
        {
            operation = "loadbykey";
            spname = "sp_pcategory";
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("@operation", operation);
            obj[1] = new SqlParameter("@sr", id);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, obj);
            if(dt!=null)
            {
                if (dt.Rows[0]["pcategory"] != DBNull.Value) 
                {
                    txtproductcategory.Text = dt.Rows[0]["pcategory"].ToString();
                }
                if (dt.Rows[0]["hsncode"] != DBNull.Value) 
                {
                    txthsncode.Text = dt.Rows[0]["hsncode"].ToString();
                }
                if (dt.Rows[0]["gstrate"] != DBNull.Value) 
                {
                    ddlgstrate.SelectedValue = dt.Rows[0]["gstrate"].ToString();
                }
            }
        }
        private void clearfiled()
        {
            txtproductcategory.Text = "";
            txthsncode.Text = "";
            ddlgstrate.SelectedIndex = 0;
        }
    }
}