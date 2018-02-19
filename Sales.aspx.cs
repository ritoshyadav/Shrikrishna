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
    public partial class Sales : System.Web.UI.Page
    {
        string spname = "", opreation = "";int gstrate=0,hsncode=0;
        int iResult = 0,no=0, pcatsr=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }


                if (Session["pws"] != null)
                {
                    SqlParameter[] objsql = new SqlParameter[1];
                DataTable dt = new DataTable();
                opreation = "loadall";
                spname = "sp_customer";
                objsql[0] = new SqlParameter("@operation", opreation);

                dt = connection.GetData(spname, objsql);
                if (dt != null)
                {
                    ddlname.DataSource = dt;
                    // ddlpcategory.DataMember = "@pcategory";
                    ddlname.DataTextField = "name";
                    ddlname.DataValueField = "id";
                    ddlname.DataBind();
                }
                ddlname.Items.Insert(0, new ListItem("--Select Name Of Customer--", "0"));


                SqlParameter[] objsql1 = new SqlParameter[1];
                DataTable dt1 = new DataTable();
                opreation = "loadall";
                spname = "sp_product";
                objsql1[0] = new SqlParameter("@operation", opreation);

                dt1 = connection.GetData(spname, objsql1);
                if (dt1 != null)
                {
                    Ddlgoodname.DataSource = dt1;
                    // ddlpcategory.DataMember = "@pcategory";
                    Ddlgoodname.DataTextField = "itemname";
                    Ddlgoodname.DataValueField = "sr";
                    Ddlgoodname.DataBind();
                }
                Ddlgoodname.Items.Insert(0, new ListItem("--Select Product--", "0"));

                }
                else
                {
                    btnsave.Enabled = false;
                    btnbill.Enabled = false;
                    Button2.Enabled = false;
                }

            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            opreation = "loadhgst";
            spname = "sp_pcategory";
            SqlParameter[] objsql2 = new SqlParameter[2];
            objsql2[0] = new SqlParameter("@operation", opreation);
            objsql2[1] = new SqlParameter("@sr", Ddlgoodname.SelectedValue);
            DataTable dt1 = new DataTable();
            dt1 = connection.GetData(spname, objsql2);
            if (dt1 != null)
            {
                if (dt1.Rows[0]["gstrate"] != DBNull.Value)
                {
                    gstrate = Convert.ToInt32(dt1.Rows[0]["gstrate"].ToString());
                }
                if (dt1.Rows[0]["hsncode"] != DBNull.Value)
                {
                    hsncode = Convert.ToInt32(dt1.Rows[0]["hsncode"].ToString());
                }
            }
            int total = (Convert.ToInt32(Txtrate.Text) * Convert.ToInt32(Txtqty.Text));
            if (btnsave.Text == "ADD")
            {
                spname = "sptempsale";
                opreation = "maxid";
                DataTable dtmaxid= new DataTable();
                SqlParameter[] objmaxid = new SqlParameter[1];
                objmaxid[0] = new SqlParameter("@operation", opreation);
                dtmaxid = connection.GetData(spname,objmaxid);
                if (dtmaxid != null)
                {
                    if (dtmaxid.Rows[0]["id"] != DBNull.Value)
                    {
                        no = Convert.ToInt32(dtmaxid.Rows[0]["id"]);
                        no = no + 1;

                    }
                }
                else
                {
                    no = no + 1;
                }

                opreation = "insert";
                spname = "sptempsale";
                SqlParameter[] objsql1 = new SqlParameter[10];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@pname", Ddlgoodname.SelectedItem.ToString());
                objsql1[2] = new SqlParameter("@qty", Txtqty.Text);
                objsql1[3] = new SqlParameter("@unit", Txtunit.Text);
                objsql1[4] = new SqlParameter("@rate", Txtrate.Text);
                objsql1[5] = new SqlParameter("@cid", ddlname.SelectedValue);
                objsql1[6] = new SqlParameter("@id", no);
                objsql1[7] = new SqlParameter("@total",total);
              
                objsql1[8] = new SqlParameter("@hsncode", hsncode);
                objsql1[9] = new SqlParameter("@gstrate", gstrate);
                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Record Saved";
                    stopinsert();

                }
                gridload();
                newitem();



            }
            else if(btnsave.Text == "Update")
            {
                opreation = "update";
                spname = "sptempsale";
                SqlParameter[] objsql1 = new SqlParameter[10];
                objsql1[0] = new SqlParameter("@operation", opreation);

                objsql1[1] = new SqlParameter("@pname", Ddlgoodname.SelectedItem.ToString());
                objsql1[2] = new SqlParameter("@qty", Txtqty.Text);
                objsql1[3] = new SqlParameter("@unit", Txtunit.Text);
                objsql1[4] = new SqlParameter("@rate", Txtrate.Text);
                objsql1[5] = new SqlParameter("@cid", ddlname.SelectedValue);
                objsql1[6] = new SqlParameter("@id", Label2.Text);
                objsql1[7] = new SqlParameter("@total",total);
                
                objsql1[8] = new SqlParameter("@hsncode", hsncode);
                objsql1[9] = new SqlParameter("@gstrate", gstrate);
                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Record Update";
                    btnsave.Text = "ADD";
                    stopinsert();
                }
                gridload();
                newitem();
            }
        }

        private void stopinsert()
        {
           int idcout = 0;
            SqlParameter[] objsql = new SqlParameter[1];
            opreation = "stop";
            spname = "sptempsale";
            objsql[0] = new SqlParameter("@operation", opreation);

            idcout = connection.ExecuteQuery(spname, objsql);
            if(idcout >0)
            {
                if(idcout==11)
                {
                    btnsave.Enabled = false;
                    Button2.Enabled = false;
                }
                else
                {

                }
            }
        }
        private void gridload()
        {
            //DataTable dt = new DataTable();
            //dt.Rows[0]["id"] = 1;
            //dt.Rows[0]["pname"] = Ddlgoodname.SelectedItem.Text;
            //dt.Rows[0]["qty"] = Txtqty.Text;
            //dt.Rows[0]["unit"] = Txtunit.Text;
            //dt.Rows[0]["rate"] = Txtrate.Text;
            //GridView1.DataSource = dt;
            //GridView1.DataBind();
            DataTable dt = new DataTable();
            opreation = "loadall";
            spname = "sptempsale";
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", opreation);
            dt = connection.GetData(spname, objsql);
            if(dt!=null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            newitem();
        }
        private void newitem()
        {
            clearcust();
            cleargood();
            Txtqty.Text = "";
            Txtunit.Text = "";
        }

        

        protected void Ddlgoodname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddlgoodname.SelectedIndex > 0)
            {
                opreation = "loadbykey";
                spname = "sp_product";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@sr", Ddlgoodname.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["rate"] != DBNull.Value)
                    {
                        Txtrate.Text = dt.Rows[0]["rate"].ToString();
                    }
                    if (dt.Rows[0]["pcategorysr"] != DBNull.Value)
                    {
                        pcatsr = Convert.ToInt32(dt.Rows[0]["pcategorysr"].ToString());
                    }
                }
               

            }
            else
            {
                cleargood();
            }
            }

       

        protected void ddlname_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (ddlname.SelectedIndex > 0)
            {
                opreation = "loadbykey";
                spname = "sp_customer";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@id", ddlname.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["address"] != DBNull.Value)
                    {
                        txtAddress.Text = dt.Rows[0]["address"].ToString();
                    }
                    if (dt.Rows[0]["contact"] != DBNull.Value)
                    {
                        Txtcontact.Text = dt.Rows[0]["contact"].ToString();
                    }
                    //if (dt.Rows[0]["name"] != DBNull.Value)
                    //{
                    //    txtname.Text = dt.Rows[0]["name"].ToString();
                    //}
                    if (dt.Rows[0]["gst_no"] != DBNull.Value)
                    {
                        Txtgstno.Text = dt.Rows[0]["gst_no"].ToString();
                    }
                    if (dt.Rows[0]["email"] != DBNull.Value)
                    {
                        txtemail.Text = dt.Rows[0]["email"].ToString();
                    }

                }
            }
            else
            {
                clearcust();

            }
        }

        protected void ddlname_SelectedIndexChanged2(object sender, EventArgs e)
        {
           
        }

        protected void Ddlgoodname_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Ddlgoodname.SelectedIndex > 0)
            {
                opreation = "loadbykey";
                spname = "sp_product";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@sr", Ddlgoodname.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["rate"] != DBNull.Value)
                    {
                        Txtrate.Text = dt.Rows[0]["rate"].ToString();
                    }
                    if (dt.Rows[0]["pcategorysr"] != DBNull.Value)
                    {
                        pcatsr = Convert.ToInt32(dt.Rows[0]["pcategorysr"].ToString());
                    }
                }


            }
        }

        protected void Ddlgoodname_SelectedIndexChanged2(object sender, EventArgs e)
        {
            if (Ddlgoodname.SelectedIndex > 0)
            {
                opreation = "loadbykey";
                spname = "sp_product";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@sr", Ddlgoodname.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["rate"] != DBNull.Value)
                    {
                        Txtrate.Text = dt.Rows[0]["rate"].ToString();
                    }
                    if (dt.Rows[0]["pcategorysr"] != DBNull.Value)
                    {
                        pcatsr = Convert.ToInt32(dt.Rows[0]["pcategorysr"].ToString());
                    }
                }


            }
            else
            {
                cleargood();
            }
        }

        protected void ddlname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlname.SelectedIndex > 0)
            {
                opreation = "loadbykey";
                spname = "sp_customer";
                SqlParameter[] objsql1 = new SqlParameter[2];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@id", ddlname.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["address"] != DBNull.Value)
                    {
                        txtAddress.Text = dt.Rows[0]["address"].ToString();
                    }
                    if (dt.Rows[0]["contact"] != DBNull.Value)
                    {
                        Txtcontact.Text = dt.Rows[0]["contact"].ToString();
                    }
                    //if (dt.Rows[0]["name"] != DBNull.Value)
                    //{
                    //    txtname.Text = dt.Rows[0]["name"].ToString();
                    //}
                    if (dt.Rows[0]["gst_no"] != DBNull.Value)
                    {
                        Txtgstno.Text = dt.Rows[0]["gst_no"].ToString();
                    }
                    if (dt.Rows[0]["email"] != DBNull.Value)
                    {
                        txtemail.Text = dt.Rows[0]["email"].ToString();
                    }

                }
            }
            else
            {
                clearcust();

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "recordedit")
            {
                perfill(e.CommandArgument.ToString());
                btnsave.Text = "Update";
                Label2.Text = e.CommandArgument.ToString();

            }
            else if (e.CommandName == "Recorddelete")
            {
                opreation = "delete";
                spname = "sptempsale";
                SqlParameter[] objsql = new SqlParameter[2];
                objsql[0] = new SqlParameter("@operation", opreation);
                objsql[1] = new SqlParameter("@id", e.CommandArgument.ToString());
                iResult = connection.ExecuteQuery(spname, objsql);
                if (iResult > 0)
                {
                    Label1.Text = "Record Deleted";
                    gridload();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        private void clearcust()
        {
            txtAddress.Text = "";
            Txtcontact.Text = "";
            txtemail.Text = "";
            Txtgstno.Text = "";
           
        }

        protected void btnbill_Click(object sender, EventArgs e)
        {
            int billno = 0;
            spname = "sp_sale";
            opreation = "maxid";
            DataTable dtmaxid = new DataTable();
            SqlParameter[] objmaxid = new SqlParameter[1];
            objmaxid[0] = new SqlParameter("@operation", opreation);
            dtmaxid = connection.GetData(spname, objmaxid);
            if (dtmaxid != null)
            {
                if (dtmaxid.Rows[0]["id"] != DBNull.Value)
                {
                    billno = Convert.ToInt32(dtmaxid.Rows[0]["id"]);
                    billno = billno + 1;

                }
            }
            else
            {
                billno = billno + 1;
            }
            spname = "sptempsale";
            opreation = "loadall";
            SqlParameter[] objsql1 = new SqlParameter[1];
            DataTable dtall = new DataTable();
            objsql1[0] = new SqlParameter("@operation", opreation);
            dtall = connection.GetData(spname, objsql1);
            if( dtall!=null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    spname = "sp_sale";
                    opreation = "insert";
                    SqlParameter[] objsqlsale = new SqlParameter[10];
                    objsqlsale[0] = new SqlParameter("@operation", opreation);
                    objsqlsale[1] = new SqlParameter("@cid",dtall.Rows[i]["cid"].ToString());
                    objsqlsale[2] = new SqlParameter("@pname", dtall.Rows[i]["pname"].ToString());
                    objsqlsale[3] = new SqlParameter("@qty", dtall.Rows[i]["qty"].ToString());
                    objsqlsale[4] = new SqlParameter("@unit", dtall.Rows[i]["unit"].ToString());
                    objsqlsale[5] = new SqlParameter("@rate", dtall.Rows[i]["rate"].ToString());
                    objsqlsale[6] = new SqlParameter("@bill_no",billno);
                    objsqlsale[7] = new SqlParameter("@total", dtall.Rows[i]["total"].ToString());
                    objsqlsale[8] = new SqlParameter("@hsncode", dtall.Rows[i]["hsncode"].ToString());
                    objsqlsale[9] = new SqlParameter("@gstrate", dtall.Rows[i]["gstrate"].ToString());
                    iResult = connection.ExecuteQuery(spname, objsqlsale);
                    iResult = iResult + 1;
                }
               if(iResult>0)
                {
                    Label3.Text = "Bill Saved" + " "+"Billno :-"+billno;
                }
                int delrecord = 0;
                opreation = "deleteall";
                spname = "sptempsale";
                SqlParameter[] objsqldel = new SqlParameter[1];
                objsqldel[0] = new SqlParameter("@operation", opreation);
                delrecord = connection.ExecuteQuery(spname, objsqldel);

                btnbill.Enabled = false;
            }
            else
            {

            }
        }

        private void cleargood()
        {
            Txtqty.Text = "";
            Txtrate.Text = "";
            Txtunit.Text = "";
        }
       private void perfill(string a)
        {
            opreation = "loadbykey";
            spname = "sptempsale";
            DataTable dt = new DataTable();

            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", opreation);
            objsql[1] = new SqlParameter("@id",a);
            dt = connection.GetData(spname,objsql);
            if (dt!=null)
            {
                if (dt.Rows[0]["pname"] != DBNull.Value)
                {
                    Ddlgoodname.SelectedValue = dt.Rows[0]["pname"].ToString();
                }
                if (dt.Rows[0]["qty"] != DBNull.Value)
                {
                    Txtqty.Text = dt.Rows[0]["qty"].ToString();
                }
                if (dt.Rows[0]["unit"] != DBNull.Value)
                {
                    Txtunit.Text = dt.Rows[0]["unit"].ToString();
                }
                if (dt.Rows[0]["rate"] != DBNull.Value)
                {
                    Txtrate.Text = dt.Rows[0]["rate"].ToString();
                }
                if (dt.Rows[0]["cid"] != DBNull.Value)
                {
                    ddlname.SelectedValue = dt.Rows[0]["cid"].ToString();
                }
                
            }
        }
    }
}