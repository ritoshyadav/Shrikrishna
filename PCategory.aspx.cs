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
                    loadbymainproduct();
                    txtproductcategory.Visible = false;

                    //for (int i = 0; i < 101; i++)
                    //{
                    //    txtgstrate.Items.Add(Convert.ToString(i));
                    //}
                    //    txtgstrate.Items.Insert(0, new ListItem("--Select GST Rate--", "0"));
                    loadbytype();


                }
                else
                {
                    btnsave.Enabled = false;
                    Button2.Enabled = false;
                    
                }

            }

        }

        private void loadbytype()
        {
            operation = "loadall";
            spname = "sp_type";
            DataTable dt = new DataTable();
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", operation);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                ddltxttype.DataSource = dt;
                // ddlpcategory.DataMember = "@pcategory";
                ddltxttype.DataTextField = "Type";
                ddltxttype.DataValueField = "Id";
                ddltxttype.DataBind();
            }
            ddltxttype.Items.Insert(0, new ListItem("--Select Type--", "0"));
        }
        private void loadbymainproduct()
        {
            operation = "loadbymproduct";
            spname = "sp_pcategory";
            DataTable dt = new DataTable();
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", operation);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                ddlproductname.DataSource = dt;
                // ddlpcategory.DataMember = "@pcategory";
                ddlproductname.DataTextField = "Name";
                // ddlproductname.DataValueField = "Id";
                ddlproductname.DataBind();
            }
            ddlproductname.Items.Insert(0, new ListItem("--Other--", "0"));

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
                Txtnewproduct.Visible = true;
                txtproductcategory.Visible = true;
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
                SqlParameter[] objsql1 = new SqlParameter[7];
                objsql1[0] = new SqlParameter("@operation", operation);
                objsql1[1] = new SqlParameter("@Name", Txtnewproduct.Text);
                objsql1[2] = new SqlParameter("@pcategory", txtproductcategory.Text);
                objsql1[3] = new SqlParameter("@Type", ddltxttype.SelectedValue);
                objsql1[4] = new SqlParameter("@hsncode", txthsncode.Text);
                objsql1[5] = new SqlParameter("@gstrate", txtgstrate.Text);
                objsql1[6] = new SqlParameter("@Rate", txtrate.Text);

                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Saved Record";
                    Txtnewproduct.Visible = false;
                    ddlproductname.Visible = true;
                    txtproductcategory.Visible = false;
                    ddlsubtype.Visible = true;
                    ddltxttype.SelectedIndex = 0;
                }
            }
            else if(btnsave.Text=="Update")
            {
               
                operation = "update";
                SqlParameter[] objsql1 = new SqlParameter[8];
                objsql1[0] = new SqlParameter("@operation", operation);
                objsql1[1] = new SqlParameter("@sr", Label2.Text);
                objsql1[2] = new SqlParameter("@Name", Txtnewproduct.Text);
                objsql1[3] = new SqlParameter("@pcategory", txtproductcategory.Text);
                objsql1[4] = new SqlParameter("@Type", ddltxttype.SelectedValue);
                objsql1[5] = new SqlParameter("@hsncode", txthsncode.Text);
                objsql1[6] = new SqlParameter("@gstrate", txtgstrate.Text);
                objsql1[7] = new SqlParameter("@Rate", txtrate.Text);
                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Updated Record";
                    btnsave.Text = "Save";
                    Label1.Text = "";
                    ddlproductname.Visible = true;
                    Txtnewproduct.Visible = false;
                    ddltxttype.SelectedIndex = 0;
                    ddlproductname.SelectedIndex = 0;


                }
            }
            gridload();
            // Label1.Text = "";
            clearfiled();
        }
        private void fill(string id)
        {
            //ddltxttype.Visible = false;
            ddlproductname.Visible = false;
            ddlsubtype.Visible = false;
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
                    txtgstrate.Text = dt.Rows[0]["gstrate"].ToString();
                }
                if (dt.Rows[0]["Name"] != DBNull.Value)
                {
                    Txtnewproduct.Text = dt.Rows[0]["Name"].ToString();
                }
                if (dt.Rows[0]["Type"] != DBNull.Value)
                {
                    string tid = dt.Rows[0]["Type"].ToString();
                    loadddltxttype(tid);
                }
                if (dt.Rows[0]["Rate"] != DBNull.Value)
                {
                    txtrate.Text = dt.Rows[0]["Rate"].ToString();
                }

            }
        }
        private void loadddltxttype(string id)
        {
            operation = "loadbyid";
            spname = "sp_type";
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("@operation", operation);
            obj[1] = new SqlParameter("@Id", id);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, obj);
            if (dt != null)
            {
                if (dt.Rows[0]["Id"] != DBNull.Value)
                {
                    ddltxttype.SelectedIndex = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
                }
            }

            }
        protected void ddlproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlproductname.SelectedIndex != 0)
            {
                Txtnewproduct.Visible = false;
                txtproductcategory.Visible = false;
                ddlsubtype.Visible = true;
                Txtnewproduct.Text = ddlproductname.SelectedItem.Text;
                Loadsubtype();
            }
            else if (ddlproductname.SelectedIndex == 0)
            {
                Txtnewproduct.Visible = true;
                Txtnewproduct.Text = "";
                ddlsubtype.Visible = false;
                txtproductcategory.Visible = true;

            }
        }
        private void Loadsubtype()
        {
            DataTable dt = new DataTable();
            spname = "sp_pcategory";
            operation = "loadbyproduct";
            SqlParameter []objlistproduct = new SqlParameter[2];
            objlistproduct[0] = new SqlParameter("@operation", operation);
            objlistproduct[1] = new SqlParameter("@Name", ddlproductname.Text);
            dt = connection.GetData(spname, objlistproduct);
            if(dt!=null)
            {
                ddlsubtype.DataSource = dt;
                // ddlpcategory.DataMember = "@pcategory";
                ddlsubtype.DataTextField = "pcategory";
                // ddlproductname.DataValueField = "Id";
                ddlsubtype.DataBind();
            }
            ddlsubtype.Items.Insert(0, new ListItem("--Other--","0"));
            
        }

        protected void ddlsubtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubtype.SelectedIndex != 0)
            {

                txtproductcategory.Visible = false;
                txtproductcategory.Text = ddlsubtype.Text;

              //  Loadsubtype();
            }
            else if (ddlsubtype.SelectedIndex == 0)
            {
                //ddlsubtype.Visible = false;

                txtproductcategory.Visible = true;
                txtproductcategory.Text = "";
            }
        }

        protected void ddltxttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            operation = "loadbyid";
            spname = "sp_type";
            SqlParameter[] obj = new SqlParameter[2];
            obj[0] = new SqlParameter("@operation", operation);
            obj[1] = new SqlParameter("@Id", ddltxttype.SelectedIndex);
            DataTable dt = new DataTable();
            dt = connection.GetData(spname, obj);
            if (dt != null)
            {
                //if (dt.Rows[0]["Id"] != DBNull.Value)
                //{
                //   ddltxttype.SelectedIndex = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                //}

                if (dt.Rows[0]["hsncode"] != DBNull.Value)
                {
                    txthsncode.Text = dt.Rows[0]["hsncode"].ToString();
                }
                if (dt.Rows[0]["gstrate"] != DBNull.Value)
                {
                    txtgstrate.Text = dt.Rows[0]["gstrate"].ToString();
                }
            }
        }

        private void clearfiled()
        {
            txtproductcategory.Text = "";
            txthsncode.Text = "";
            txtgstrate.Text = "";
            ddltxttype.SelectedIndex = 0;
            ddlproductname.SelectedIndex = 0;
            Txtnewproduct.Text = "";
            txtrate.Text = "";
        }
    }
}