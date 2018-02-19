

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
    public partial class Sales_List : System.Web.UI.Page
    {
        string spname = "", opreation = "" ,VNo="",paymode="";  int billno = 0;
        int iResult = 0, no = 0, show=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Panel1.Visible = false;
                SqlParameter[] objsql = new SqlParameter[1];
                DataTable dt = new DataTable();
                opreation = "loadall";
                spname = "sp_customer";
                objsql[0] = new SqlParameter("@operation", opreation);

                dt = connection.GetData(spname, objsql);
                if (dt != null)
                {
                    ddlname.DataSource = dt;
                    ddlname.DataTextField = "name";
                    ddlname.DataValueField = "id";
                    ddlname.DataBind();
                }
                ddlname.Items.Insert(0, new ListItem("--Select Name Of Customer--", "0"));

                SqlParameter[] objsql1 = new SqlParameter[1];
                DataTable dt1 = new DataTable();
                opreation = "loadbymproduct";
                spname = "sp_pcategory";
                objsql1[0] = new SqlParameter("@operation", opreation);

                dt1 = connection.GetData(spname, objsql1);
                if (dt1 != null)
                {
                    Ddlgoodname.DataSource = dt1;
                    // ddlpcategory.DataMember = "@pcategory";
                    Ddlgoodname.DataTextField = "Name";
                    //Ddlgoodname.DataValueField = "sr";
                    Ddlgoodname.DataBind();
                }
                Ddlgoodname.Items.Insert(0, new ListItem("--Select Product--", "0"));


                loadvehical();
                ddlpaymode.Items.Insert(0,"--Select Payment Mode--");
                ddlpaymode.Items.Insert(1, "ToPay");
                ddlpaymode.Items.Insert(2, "For(Self)");
                
            }
         

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
           
                int total = (Convert.ToInt32(Txtrate.Text) * Convert.ToInt32(Txtqty.Text));
                if (btnsave.Text == "ADD")
                {
                    spname = "sp_sales";
                    opreation = "maxid";
                    DataTable dtmaxid = new DataTable();
                    SqlParameter[] objmaxid = new SqlParameter[1];
                    objmaxid[0] = new SqlParameter("@operation", opreation);
                    dtmaxid = connection.GetData(spname, objmaxid);
                if (dtmaxid != null)
                {
                    if (dtmaxid.Rows[0][0] != DBNull.Value)
                    {
                        no = Convert.ToInt32(dtmaxid.Rows[0][0]);
                        no = no + 1;

                    }


                    else if(dtmaxid.Rows[0][0] == DBNull.Value)
                    {
                        no = no + 1;
                    }

                }
                opreation = "insert";
                spname = "sp_sales";
                SqlParameter[] objsql1 = new SqlParameter[10];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@G_Name", Ddlgoodname.SelectedItem.ToString());
                objsql1[2] = new SqlParameter("@Qty", Txtqty.Text);

                objsql1[3] = new SqlParameter("@Rate", Txtrate.Text);
                objsql1[4] = new SqlParameter("@Cust_id", ddlname.SelectedValue);
                objsql1[5] = new SqlParameter("@Id", no);
                objsql1[6] = new SqlParameter("@Total", total);

                objsql1[7] = new SqlParameter("@S_G_Name", ddlsubtype.SelectedValue);
                objsql1[8] = new SqlParameter("@Type_Id", ddltxttype.SelectedValue);
                objsql1[9] = new SqlParameter("@Date", DateTime.Today.Date);
                iResult = connection.ExecuteQuery(spname, objsql1);
                if (iResult > 0)
                {
                    Label1.Text = "Record Saved";
                    stopinsert();
                
                }
                gridload();
                newitem();
       


            }
            else if (btnsave.Text == "Update")
            {
                opreation = "update";
                spname = "sp_sales";
                SqlParameter[] objsql1 = new SqlParameter[10];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@G_Name", Ddlgoodname.SelectedItem.ToString());
                objsql1[2] = new SqlParameter("@qty", Txtqty.Text);

                objsql1[3] = new SqlParameter("@rate", Txtrate.Text);
                objsql1[4] = new SqlParameter("@Cust_id", ddlname.SelectedValue);
                objsql1[5] = new SqlParameter("@Id", no);
                objsql1[6] = new SqlParameter("@total", total);

                objsql1[7] = new SqlParameter("@S_G_Name", ddlsubtype.SelectedValue);
                objsql1[8] = new SqlParameter("@Type_Id", ddltxttype.SelectedValue);
                objsql1[9] = new SqlParameter("@Date", DateTime.Today.Date.ToShortDateString());
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
            DataTable dt = new DataTable();
            int idcount = 0;
            SqlParameter[] objsql = new SqlParameter[1];
            opreation = "stop";
            spname = "sp_sales";
            objsql[0] = new SqlParameter("@operation", opreation);

            dt = connection.GetData(spname, objsql);
            if (dt !=null)
            {
                if (dt.Rows[0][0]!=DBNull.Value)
                {
                    idcount = Convert.ToInt32(dt.Rows[0][0]);
                    if (idcount == 10)
                    {
                        btnsave.Enabled = false;
                        Button2.Enabled = false;
                    }
                }
                else
                {

                }
            }
        }

        private void gridload()
        {
            GridView1.Visible = true;
            DataTable dt = new DataTable();
            opreation = "loadall";
            spname = "sp_sales";
            SqlParameter[] objsql = new SqlParameter[1];
            objsql[0] = new SqlParameter("@operation", opreation);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            newitem();
            clearcust();
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
                spname = "sp_sales";
                SqlParameter[] objsql = new SqlParameter[2];
                objsql[0] = new SqlParameter("@operation", opreation);
                objsql[1] = new SqlParameter("@Id", e.CommandArgument.ToString());
                iResult = connection.ExecuteQuery(spname, objsql);
                if (iResult > 0)
                {
                    Label1.Text = "Record Deleted";
                    gridload();
                }
            }
        }

        private void newitem()
        {

            cleargood();
            Txtqty.Text = "";

        }

        protected void btnbill_Click(object sender, EventArgs e)
        {
           

            spname = "sp_MainSale";
            opreation = "maxid";
            DataTable dtmaxid = new DataTable();
            SqlParameter[] objmaxid = new SqlParameter[1];
            objmaxid[0] = new SqlParameter("@operation", opreation);
            dtmaxid = connection.GetData(spname, objmaxid);
            if (dtmaxid != null)
            {
                if (dtmaxid.Rows[0][0] != DBNull.Value)
                {
                    billno = Convert.ToInt32(dtmaxid.Rows[0][0]);
                    billno = billno + 1;
                }
                else if(dtmaxid.Rows[0][0]==DBNull.Value)
                {
                    billno = billno + 1;
                }



            }
           
            spname = "sp_sales";
            opreation = "loadall";
            SqlParameter[] objsql1 = new SqlParameter[1];
            DataTable dtall = new DataTable();
            objsql1[0] = new SqlParameter("@operation", opreation);
            dtall = connection.GetData(spname, objsql1);
            if (dtall != null)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    spname = "sp_MainSale";
                    opreation = "insert";
                    SqlParameter[] objsqlsale = new SqlParameter[13];
                    objsqlsale[0] = new SqlParameter("@operation", opreation);
                    objsqlsale[1] = new SqlParameter("@Bill_no", billno);
                    objsqlsale[2] = new SqlParameter("@Cust_id", dtall.Rows[i]["Cust_id"].ToString());
                    objsqlsale[3] = new SqlParameter("@G_Name", dtall.Rows[i]["G_Name"].ToString());
                    objsqlsale[4] = new SqlParameter("@S_G_Name", dtall.Rows[i]["S_G_Name"].ToString());
                    objsqlsale[5] = new SqlParameter("@Type_Id", dtall.Rows[i]["Type_Id"].ToString());
                    objsqlsale[6] = new SqlParameter("@Rate", dtall.Rows[i]["Rate"].ToString());
                    objsqlsale[7] = new SqlParameter("@Qty", dtall.Rows[i]["Qty"].ToString());
                    objsqlsale[8] = new SqlParameter("@V_Id", ddlVno.SelectedValue);
                    objsqlsale[9] = new SqlParameter("@Total", dtall.Rows[i]["Total"].ToString());
                    objsqlsale[10] = new SqlParameter("@Date", dtall.Rows[i]["Date"].ToString());
                    objsqlsale[11] = new SqlParameter("@payamount", txtamout.Text);
                    objsqlsale[12] = new SqlParameter("@paymode", ddlpaymode.SelectedValue);
                    iResult = connection.ExecuteQuery(spname, objsqlsale);
                    iResult = iResult + 1;
                 
                }
                if (iResult > 0)
                {
                    Label3.Text = "Bill Saved" + " " + "Billno :-" + billno;
                }
                int delrecord = 0;
                opreation = "deleteall";
                spname = "sp_sales";
                SqlParameter[] objsqldel = new SqlParameter[1];
                objsqldel[0] = new SqlParameter("@operation", opreation);
                delrecord = connection.ExecuteQuery(spname, objsqldel);

                btnbill.Enabled = false;
                //gridload();
                GridView1.Visible = false;
                btnsave.Enabled = false;
                Button2.Enabled = false;
                clearcust();
                Panel1.Visible = false;
                btnshow.Enabled = false;
            }
            else
            {

            }
            //spanme = "sp_SaleList";
            //operation = "insert";
            //SqlParameter[] objsql1 = new SqlParameter[4];
            //objsql1[0] = new SqlParameter("@operation", operation);
            //objsql1[1] = new SqlParameter("@C_Name", Label2.Text);
            //objsql1[2] = new SqlParameter("@DOS", Label10.Text);
            //objsql1[3] = new SqlParameter("@Total", mtotal);
            //iResult = connection.ExecuteQuery(spanme, objsql1);
            //if(iResult>0)
            //{

            //}
            //else
            //{

            //}
        }

        protected void Ddlgoodname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Ddlgoodname.SelectedIndex > 0)
            {
                ddltxttype.SelectedValue = (0).ToString();

                Txtqty.Text = "";
                Txtrate.Text = "";
                DataTable dt = new DataTable();
                spname = "sp_pcategory";
                opreation = "loadbyproduct";
                SqlParameter[] objlistproduct = new SqlParameter[2];
                objlistproduct[0] = new SqlParameter("@operation", opreation);
                objlistproduct[1] = new SqlParameter("@Name", Ddlgoodname.Text);
                dt = connection.GetData(spname, objlistproduct);
                if (dt != null)
                {
                    ddlsubtype.DataSource = dt;
                    // ddlpcategory.DataMember = "@pcategory";
                    ddlsubtype.DataTextField = "pcategory";
                    //ddlsubtype.DataValueField = "Id";
                    ddlsubtype.DataBind();
                }
                ddlsubtype.Items.Insert(0, new ListItem("--Select Sub Product Type--", "0"));
                

            }
            else
            {
                cleargood();

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            gridload();
        }

        protected void ddlsubtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsubtype.SelectedIndex > 0)
            {

                Txtqty.Text = "";
                Txtrate.Text = "";

                opreation = "loadbytype";
                spname = "sp_pcategory";
                SqlParameter[] objsql1 = new SqlParameter[3];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@Name", Ddlgoodname.SelectedValue);
                objsql1[2] = new SqlParameter("@pcategory", ddlsubtype.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
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
            else
            {
                ddltxttype.SelectedValue = (0).ToString();
                RateToQty();
            }

        }

        protected void ddltxttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltxttype.SelectedIndex > 0)
            {
                RateToQty();
                opreation = "loadbyrate";
                spname = "sp_pcategory";
                SqlParameter[] objsql1 = new SqlParameter[3];
                objsql1[0] = new SqlParameter("@operation", opreation);
                objsql1[1] = new SqlParameter("@Name", Ddlgoodname.SelectedValue);
                objsql1[2] = new SqlParameter("@pcategory", ddlsubtype.SelectedValue);
                DataTable dt = new DataTable();
                dt = connection.GetData(spname, objsql1);
                if (dt != null)
                {
                    if (dt.Rows[0]["Rate"] != DBNull.Value)
                    {
                        Txtrate.Text = dt.Rows[0]["Rate"].ToString();
                    }
                }
            }
            else
            {

                RateToQty();
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



        protected void ddlVno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVno.SelectedIndex > 0)
            {
                VNo = ddlVno.SelectedValue;
            }
            else if (ddlVno.SelectedIndex == 0)
            {
                VNo = null;
            }
        }
      

        protected void ddlpaymode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlpaymode.SelectedIndex >0)
            {
                paymode = ddlpaymode.SelectedValue;
            }
            else if(ddlpaymode.SelectedIndex == 0)
            {
                paymode = null;
            }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
         
            if (Panel2.Visible == true)
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                btnsave.Enabled = false;
                Button2.Enabled = false;
              
            }
            else if (Panel2.Visible == false)
            {
                Panel2.Visible = true;
                Panel1.Visible = false;
                btnsave.Enabled = true;
                Button2.Enabled = true;

            }

        }
        //private void goodFvisible()
        //{
        //    ddlsubtype.Enabled = false;
        //    Ddlgoodname.Enabled = false;
        //    ddltxttype.Enabled = false;
        //    Txtqty.Enabled = false;
        //    Txtrate.Enabled = false;
        //}
        //private void goodTvisible()
        //{
        //    ddlsubtype.Enabled = true;
        //    Ddlgoodname.Enabled = true;
        //    ddltxttype.Enabled = true;
        //    Txtqty.Enabled = true;
        //    Txtrate.Enabled = true;
        //}
        private void loadvehical()
        {
            spname = "sp_vehicel";
            opreation = "loadbyp";
            DataTable dt2 = new DataTable();
            SqlParameter[] objsql2 = new SqlParameter[1];
            objsql2[0] = new SqlParameter("@operation", opreation);
            dt2 = connection.GetData(spname, objsql2);
            if (dt2 != null)
            {
                ddlnot1.DataSource = dt2;
                // ddlpcategory.DataMember = "@pcategory";
                ddlnot1.DataTextField = "n_transport";
                //ddlnot1.DataValueField = "sr";
                ddlnot1.DataBind();
            }
            ddlnot1.Items.Insert(0, new ListItem("--Select Transport Name--", "0"));
        }


        protected void ddlnot1_SelectedIndexChanged(object sender, EventArgs e)
        {
            spname = "sp_vehicel";
            opreation = "loadVno";
            DataTable dt = new DataTable();
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", opreation);
            objsql[1] = new SqlParameter("@n_transport", ddlnot1.SelectedValue);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                ddlVno.DataSource = dt;
                // ddlpcategory.DataMember = "@pcategory";
                ddlVno.DataTextField = "v_no";
                //ddlnot1.DataValueField = "sr";
                ddlVno.DataBind();
            }
            ddlVno.Items.Insert(0, new ListItem("--Select Vehical NO--", "0"));


        }

       

        private void clearcust()
        {
            txtAddress.Text = "";
            Txtcontact.Text = "";
            txtemail.Text = "";
            Txtgstno.Text = "";

        }
        private void cleargood()
        {
            Ddlgoodname.SelectedValue = (0).ToString();
            ddltxttype.SelectedValue = (0).ToString();
            ddlsubtype.SelectedValue = (0).ToString();
            Txtqty.Text = "";
            Txtrate.Text = "";

        }

        private void RateToQty()
        {
            Txtqty.Text = "";
            Txtrate.Text = "";
        }
        private void perfill(string a)
        {
            opreation = "loadbyid";
            spname = "sp_sales";
            DataTable dt = new DataTable();

            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", opreation);
            objsql[1] = new SqlParameter("@Id", a);
            dt = connection.GetData(spname, objsql);
            if (dt != null)
            {
                if (dt.Rows[0]["G_Name"] != DBNull.Value)
                {
                    Ddlgoodname.SelectedValue = dt.Rows[0]["G_Name"].ToString();
                }
                if (dt.Rows[0]["Qty"] != DBNull.Value)
                {
                    Txtqty.Text = dt.Rows[0]["Qty"].ToString();
                }

                if (dt.Rows[0]["Rate"] != DBNull.Value)
                {
                    Txtrate.Text = dt.Rows[0]["Rate"].ToString();
                }
                if (dt.Rows[0]["Cust_id"] != DBNull.Value)
                {
                    ddlname.SelectedIndex =Convert.ToInt32(dt.Rows[0]["Cust_id"].ToString());
                }
                if (dt.Rows[0]["Type_Id"] != DBNull.Value)
                {
                    ddltxttype.SelectedIndex = Convert.ToInt32(dt.Rows[0]["Type_Id"].ToString());
                }
                if (dt.Rows[0]["S_G_Name"] != DBNull.Value)
                {
                    ddlsubtype.SelectedValue = dt.Rows[0]["S_G_Name"].ToString();
                }
                              
            }
        }
    }
}