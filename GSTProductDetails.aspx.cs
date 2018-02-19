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
    public partial class GSTdetails : System.Web.UI.Page
    {
        string operation, spname;
        int iResult = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    //loadbyproduct();

                     gridload();
                }
                else
                {
                    btnsave.Enabled = false;
                    Button2.Enabled = false;

                }
            }
        }
        private void gridload()
        {
            operation = "loadall";
            spname = "sp_type";
            DataTable dt = new DataTable();
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", operation);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
      


        protected void Button1_Click(object sender, EventArgs e)
        {
            spname = "sp_type";
            if (btnsave.Text == "Save")
            {
                operation = "insert";

                SqlParameter[] objsql = new SqlParameter[4];
                objsql[0] = new SqlParameter("@operation", operation);
                objsql[1] = new SqlParameter("@Type", txtTypename.Text);
                objsql[2] = new SqlParameter("@Hsncode", txthsncode.Text);
                objsql[3] = new SqlParameter("@Gstrate", txtgstrate.Text);
                iResult = connection.ExecuteQuery(spname, objsql);
                if (iResult > 0)
                {
                    Label1.Text = "Saved Data";
                    gridload();
                    clear();
                }
            }
            else if(btnsave.Text=="Update")
            {
                operation = "update";
                SqlParameter[] objsql = new SqlParameter[5];
                objsql[0] = new SqlParameter("@operation", operation);
                objsql[1] = new SqlParameter("@Id", Label2.Text);
                objsql[2] = new SqlParameter("@Type", txtTypename.Text);
                objsql[3] = new SqlParameter("@Hsncode", txthsncode.Text);
                objsql[4] = new SqlParameter("@Gstrate", txtgstrate.Text);
                iResult = connection.ExecuteQuery(spname, objsql);
                if (iResult > 0)
                {
                    Label1.Text = "Update Data";
                    btnsave.Text = "Save";
                    gridload();
                    clear();
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                objsql2[1] = new SqlParameter("@Id", e.CommandArgument);
                iResult = connection.ExecuteQuery(spname, objsql2);
                if (iResult > 0)
                {
                    Label1.Text = "Record Deleted";
                }
                gridload();
                //Label1.Text = "";
            }
        }

        private void fill(string Id)
        {
          
            operation = "loadbyid";
            spname = "sp_type";
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("@operation", operation);
            obj[1] = new SqlParameter("@Id",Id);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, obj);
            if (dt != null)
            {
               if (dt.Rows[0]["hsncode"] != DBNull.Value)
                {
                    txthsncode.Text = dt.Rows[0]["hsncode"].ToString();
                }
                if (dt.Rows[0]["gstrate"] != DBNull.Value)
                {
                    txtgstrate.Text = dt.Rows[0]["gstrate"].ToString();
                }


                if (dt.Rows[0]["Type"] != DBNull.Value)
                {
                    txtTypename.Text = dt.Rows[0]["Type"].ToString();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridload();
        }
        private void clear()
        {
            txthsncode.Text = "";
            txtgstrate.Text = "";
            txtTypename.Text = "";
            Label1.Text = "";

        }
    }
}