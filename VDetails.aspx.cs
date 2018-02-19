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
    public partial class VDetails : System.Web.UI.Page
    {
        string spname = "sp_vehicel", operation = "";
        int iResult = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {
                    gridload();
                    operation = "loadbyp";
                    DataTable dt = new DataTable();
                    SqlParameter[] objsql = new SqlParameter[1];
                    objsql[0] = new SqlParameter("@operation", operation);
                    dt = connection.GetData(spname, objsql);
                    if (dt != null)
                    {
                        ddlnot1.DataSource = dt;
                        // ddlpcategory.DataMember = "@pcategory";
                        ddlnot1.DataTextField = "n_transport";
                        //ddlnot1.DataValueField = "sr";
                        ddlnot1.DataBind();
                    }
                    ddlnot1.Items.Insert(0, new ListItem("--Other--", "0"));

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
            if(btnsave.Text=="Update")
            {
                operation = "update";
                SqlParameter[] objsql = new SqlParameter[5];
                objsql[0] = new SqlParameter("@operation", operation);
                objsql[1] = new SqlParameter("@sr", Label2.Text);
                objsql[2] = new SqlParameter("@v_no", txtvehicelno.Text);
                objsql[3] = new SqlParameter("@lr_no", txtlrno.Text);
                objsql[4] = new SqlParameter("@n_transport", Txtnot.Text);
                iResult = connection.ExecuteQuery(spname, objsql);
                if(iResult>0)
                {
                    Label1.Text = "Record Updated";
                    btnsave.Text = "Save";
                    clearfiled();
                }
            }
            else if(btnsave.Text=="Save")
            {
                operation = "insert";
                SqlParameter[] objsql = new SqlParameter[4];
                objsql[0] = new SqlParameter("@operation", operation);
                //objsql[1] = new SqlParameter("@sr", null);
                objsql[1] = new SqlParameter("@v_no", txtvehicelno.Text);
                objsql[2] = new SqlParameter("@lr_no", txtlrno.Text);
                objsql[3] = new SqlParameter("@n_transport", Txtnot.Text);
                iResult = connection.ExecuteQuery(spname, objsql);
                if (iResult > 0)
                {
                    Label1.Text = "Record Updated";
                    btnsave.Text = "Save";
                    clearfiled();
                }

            }
            gridload();
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
                SqlParameter[] objsql = new SqlParameter[2];
                objsql[0] = new SqlParameter("@operation", operation);
                objsql[1] = new SqlParameter("@sr", Id);
                iResult = connection.ExecuteQuery(spname, objsql);
                if(iResult>0)
                {
                    Label1.Text = "Record Deleted";
                }
                gridload();

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

        private void fill(string id)
        {
            operation = "loadbykey";
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", operation);
            objsql[1] = new SqlParameter("@sr", id);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, objsql);
            if(dt!=null)
            {
                if(dt.Rows[0]["v_no"]!=DBNull.Value)
                {
                    txtvehicelno.Text = dt.Rows[0]["v_no"].ToString();
                }
                if (dt.Rows[0]["lr_no"] != DBNull.Value)
                {
                    txtlrno.Text = dt.Rows[0]["lr_no"].ToString();
                }
                if (dt.Rows[0]["n_transport"] != DBNull.Value)
                {
                    Txtnot.Text = dt.Rows[0]["n_transport"].ToString();
                }
            }

        }
        private void gridload()
        {
            operation = "loadall";
            SqlParameter[] objsql = new SqlParameter[1];

            objsql[0] = new SqlParameter("@operation", operation);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, objsql);
            if(dt!=null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        protected void ddlnot1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlnot1.SelectedIndex != 0)
            {
                Txtnot.Visible = false;
                Txtnot.Text = ddlnot1.SelectedItem.Text;
            }
            else if (ddlnot1.SelectedIndex == 0)
            {
                Txtnot.Visible = true;
                Txtnot.Text = "";

            }

        }

        private void clearfiled()
        {
            txtlrno.Text = "";
            Txtnot.Text = "";
            txtvehicelno.Text = "";
            Label1.Text = "";
            ddlnot1.SelectedIndex = 0;
        }
    }
}