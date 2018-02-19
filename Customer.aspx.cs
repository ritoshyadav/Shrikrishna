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
    public partial class Customer : System.Web.UI.Page
    {
        string Spname = "sp_customer", operation = "";
        int iResult = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    gridload();
                }
                else
                {
                    btnnew.Enabled = false;
                    btnsave.Enabled = false;
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                Spname = "sp_customer";
                operation = "insert";
                SqlParameter[] objsql2 = new SqlParameter[9];
                objsql2[0] = new SqlParameter("@operation", operation);
                objsql2[1] = new SqlParameter("@name", txtname.Text);
                objsql2[2] = new SqlParameter("@address", txtAddress.Text);
                objsql2[3] = new SqlParameter("@gst_no", Txtgstno.Text);
                objsql2[4] = new SqlParameter("@email", txtemail.Text);
                objsql2[5] = new SqlParameter("@contact", Txtcontact.Text);
                objsql2[6] = new SqlParameter("@state", Txtstate.Text);
                objsql2[7] = new SqlParameter("@statecode", Txtstatecode.Text);
                objsql2[8] = new SqlParameter("@saddress", txtsupplyaddress.Text);
                iResult = connection.ExecuteQuery(Spname, objsql2);
                if (iResult > 0)
                {
                    Label1.Text = "Record Saved";
                    gridload();
                    clearfiled();
                }
            }
            else if (btnsave.Text == "Update")
            {

                recordedit(Label2.Text);
                btnsave.Text = "Save";
                clearfiled();
            }
        }
      


        protected void Button2_Click(object sender, EventArgs e)
        {
            clear();
            gridload();
        }
        private void clear()
        {
            txtAddress.Text = "";
            Txtcontact.Text = "";
            txtemail.Text = "";
            Txtgstno.Text = "";
            txtname.Text = "";
            txtsupplyaddress.Text = "";
            Txtstate.Text = "";
            Txtstatecode.Text = "";
        }
        private void gridload()
        {
            operation = "loadall";
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", operation);
            DataTable dt = new DataTable();
            dt = connection.GetData(Spname, objsql);
            if(dt!=null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string Id = e.CommandArgument.ToString();
            if(e.CommandName=="recordedit")
            {
                perfill(Id);
                btnsave.Text = "Update";
                Label2.Text = e.CommandArgument.ToString();

            }
           else if (e.CommandName == "recorddelete") 
            {
                operation = "delete";
                SqlParameter[] objsql = new SqlParameter[2];
                objsql[0] = new SqlParameter("@operation", operation);
                objsql[1] = new SqlParameter("@id", e.CommandArgument.ToString());
                iResult = connection.ExecuteQuery(Spname, objsql);
                if(iResult>0)
                {
                    Label1.Text = "Record Deleted";
                    gridload();

                }
            }
        }
        private void perfill(string id)
        {
            operation = "loadbykey";
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", operation);
            objsql[1] = new SqlParameter("@id",id);
            DataTable dt = new DataTable();
            dt = connection.GetData(Spname, objsql);
            if(dt!=null)
            {
                if(dt.Rows[0]["name"]!=DBNull.Value)
                {
                    txtname.Text = dt.Rows[0]["name"].ToString();
                }
                if (dt.Rows[0]["address"] != DBNull.Value)
                {
                    txtAddress.Text = dt.Rows[0]["address"].ToString();
                }
                if (dt.Rows[0]["gst_no"] != DBNull.Value)
                {
                    Txtgstno.Text = dt.Rows[0]["gst_no"].ToString();
                }
                if (dt.Rows[0]["email"] != DBNull.Value)
                {
                    txtemail.Text = dt.Rows[0]["email"].ToString();
                }
                if (dt.Rows[0]["contact"] != DBNull.Value)
                {
                    Txtcontact.Text = dt.Rows[0]["contact"].ToString();
                }
                if (dt.Rows[0]["state"] != DBNull.Value)
                {
                    Txtstate.Text = dt.Rows[0]["state"].ToString();
                }
                if (dt.Rows[0]["statecode"] != DBNull.Value)
                {
                    Txtstatecode.Text = dt.Rows[0]["statecode"].ToString();
                }
            }
        }
        private void clearfiled()
        {
            txtname.Text = "";
            txtAddress.Text = "";
            Txtgstno.Text = "";
            txtemail.Text = "";
            Txtcontact.Text = "";

        }
        private void recordedit(String id)
        {
            Spname = "sp_customer";
            operation = "update";
            SqlParameter[] objsql2 = new SqlParameter[10];
            objsql2[0] = new SqlParameter("@operation", operation);
            objsql2[1] = new SqlParameter("@id", Label2.Text);
            objsql2[2] = new SqlParameter("@name", txtname.Text);
            objsql2[3] = new SqlParameter("@address", txtAddress.Text);
            objsql2[4] = new SqlParameter("@gst_no", Txtgstno.Text);
            objsql2[5] = new SqlParameter("@email", txtemail.Text);
            objsql2[6] = new SqlParameter("@contact", Txtcontact.Text);
            objsql2[7] = new SqlParameter("@state", Txtstate.Text);
            objsql2[8] = new SqlParameter("@statecode", Txtstatecode.Text);
            objsql2[9] = new SqlParameter("@saddress", txtsupplyaddress.Text);
            iResult = connection.ExecuteQuery(Spname, objsql2);
            if (iResult > 0)
            {
                Label1.Text = "Record Update";
                btnsave .Text="Save";
                gridload();
                clearfiled();
            }

        }
    }

}