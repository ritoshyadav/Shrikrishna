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
    public partial class NProduct : System.Web.UI.Page
    {
        string operation = "",spname= "sp_pcategory";
        int iResult = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    operation = "loadall";
                    DataTable dt = new DataTable();
                    SqlParameter[] objsql = new SqlParameter[1];
                    objsql[0] = new SqlParameter("@operation", operation);
                    dt = connection.GetData(spname, objsql);
                    if (dt != null)
                    {
                        ddlpcategory.DataSource = dt;
                        // ddlpcategory.DataMember = "@pcategory";
                        ddlpcategory.DataTextField = "pcategory";
                        ddlpcategory.DataValueField = "sr";
                        ddlpcategory.DataBind();
                    }
                    ddlpcategory.Items.Insert(0, new ListItem("--Select Product Category--", "0"));
                    gridload();
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
            // txthsncode.Text = ddlpcategory.SelectedValue;
            if (btnsave.Text=="Save")
            {
                spname = "sp_product";
                operation = "insert";
                SqlParameter[] objsql2 = new SqlParameter[4];
                objsql2[0] = new SqlParameter("@operation", operation);
                objsql2[1] = new SqlParameter("@itemname", txtproductname.Text);
                objsql2[2] = new SqlParameter("@rate", txtrate.Text);
                objsql2[3] = new SqlParameter("@pcategorysr", ddlpcategory.SelectedValue);
                iResult = connection.ExecuteQuery(spname, objsql2);
                if (iResult > 0)
                {
                    Label1.Text = "Record Saved";
                    gridload();
                    clearfiled();
                }
            }
            else if(btnsave.Text== "Update")
            {
                
                recordedit(Label2.Text);
                btnsave.Text = "Save";
                clearfiled();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            clearfiled();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridload();
        }

      
        private void gridload()
        {
            operation = "loadgrid";
            spname = "sp_product";
            DataTable dt = new DataTable();
            SqlParameter[] objsql3 = new SqlParameter[1];
            objsql3[0] = new SqlParameter("@operation", operation);
            dt = connection.GetData(spname, objsql3);
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
                Label2.Text = Id;
                btnsave.Text = "Update";
                filledit(Id);
                //recordedit(Id);

            }
            else if (e.CommandName == "recorddelete") 
            {
                recorddel(Id);
                gridload();
            }
        }

        private void recorddel(string id)
        {
            operation = "delete";
            spname = "sp_product";
            SqlParameter[] objsqldel = new SqlParameter[2];
            objsqldel[0] = new SqlParameter("@operation", operation);
            objsqldel[1] = new SqlParameter("@sr", id);
            iResult = connection.ExecuteQuery(spname, objsqldel);
            if(iResult >0)
            {
                Label1.Text = "Record Deleted";
                gridload();
            }
        }
        private void recordedit(string id)
        {
            operation = "update";
            spname = "sp_product";
            SqlParameter[] objsqldel = new SqlParameter[5];
            objsqldel[0] = new SqlParameter("@operation", operation);
            objsqldel[1] = new SqlParameter("@sr", id);
            objsqldel[2] = new SqlParameter("@itemname", txtproductname.Text);
            objsqldel[3] = new SqlParameter("@rate", txtrate.Text);
            objsqldel[4] = new SqlParameter("@pcategorysr", ddlpcategory.SelectedValue);
            iResult = connection.ExecuteQuery(spname, objsqldel);
            if (iResult > 0)
            {
                Label1.Text = "Record Updated";
                gridload();
            }

        }

      
        

        

        protected void ddlpcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlpcategory.SelectedIndex > 0)
            {
                operation = "loadbykey";
                spname = "sp_pcategory";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", operation);
                objsql1[1] = new SqlParameter("@sr", ddlpcategory.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["hsncode"] != DBNull.Value)
                    {
                        txthsncode.Text = dt.Rows[0]["hsncode"].ToString();
                    }
                    if (dt.Rows[0]["gstrate"] != DBNull.Value)
                    {
                        Txtgstrate.Text = dt.Rows[0]["gstrate"].ToString();
                    }
                }
            }
            else
            {
                txthsncode.Text = "";
                txtrate.Text = "";

            }
        }

        private void filledit(string id)
        {
            operation = "loadbykey";
            spname = "sp_product";
            DataTable dt = new DataTable();
            SqlParameter[] objsqledit = new SqlParameter[2];
            objsqledit[0] = new SqlParameter("@operation", operation);
            objsqledit[1] = new SqlParameter("@sr", id);

            dt = connection.GetData(spname, objsqledit);
            if(dt!=null)
            {
                if(dt.Rows[0]["itemname"]!=DBNull.Value)
                {
                    txtproductname.Text = dt.Rows[0]["itemname"].ToString();
                }
                if(dt.Rows[0]["rate"] != DBNull.Value)
                {
                    txtrate.Text = dt.Rows[0]["rate"].ToString();
                }
               

                if (dt.Rows[0]["pcategorysr"] != DBNull.Value)
                {
                    spname = "sp_pcategory";
                    operation = "loadbykey";
                    ddlpcategory.SelectedValue = dt.Rows[0]["pcategorysr"].ToString();
                    SqlParameter[] objsql5 = new SqlParameter[2];
                    objsql5[0] = new SqlParameter("operation", operation);
                    objsql5[1] = new SqlParameter("@sr", ddlpcategory.SelectedValue);
                    DataTable dt1 = new DataTable();
                    dt1 = connection.GetData(spname, objsql5);
                    if (dt1 != null)
                    {
                        if (dt1.Rows[0]["hsncode"] != DBNull.Value)
                        {
                            txthsncode.Text = dt1.Rows[0]["hsncode"].ToString();
                        }
                        if (dt1.Rows[0]["gstrate"] != DBNull.Value)
                        {
                            Txtgstrate.Text = dt1.Rows[0]["gstrate"].ToString();
                        }
                    }

                }

            }


        }
        private void clearfiled()
        {
            txtproductname.Text = "";
            Txtgstrate.Text = "";
            txthsncode.Text = "";
            txtrate.Text = "";
            ddlpcategory.SelectedIndex = 0;


        }

    }
}