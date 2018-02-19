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
    public partial class BIIING : System.Web.UI.Page
    {
        string spanme = "", operation = "";
        double cgst = 0, sgst=0 , igst1=0,igst2=0,mtotal=0;
        int no, Defultrow,iResult=0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["pws"] != null)
                {

                    if (Request.QueryString["bill"] != null)
                    {
                        int billno = Convert.ToInt32(Request.QueryString["bill"].ToString());
                        Label10.Text = DateTime.Now.ToShortDateString();        // date
                        Label9.Text = billno.ToString();                        // invoice
                        lbldmno.Text = billno.ToString();                                                           // invoice

                        custdetail(billno);                         // name ,state,gstno
                        vehicaldetails(billno);
                        DataTable dt1 = new DataTable();
                        DataRow dr;
                        DataTable dtresult = new DataTable();
                        dtresult.Columns.Add(new DataColumn("P_NAME", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("HSNCODE", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("GSTRATE", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("QTY", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("UNIT", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("RATE", typeof(string)));
                        dtresult.Columns.Add(new DataColumn("TOTAL", typeof(string)));
                        spanme = "sp_MainSale";
                        operation = "loadbillno";
                        SqlParameter[] objsql = new SqlParameter[2];
                        objsql[0] = new SqlParameter("@operation", operation);
                        objsql[1] = new SqlParameter("@bill_no", billno);
                        DataTable dt = new DataTable();
                        dt = connection.GetData(spanme, objsql);
                        if (dt != null)
                        {
                            no = dt.Rows.Count;
                            for (int i = 0; i < no; i++)
                            {
                                spanme = "sp_MainSale";
                                operation = "printbillfor";
                                SqlParameter[] objsql1 = new SqlParameter[4];
                                objsql1[0] = new SqlParameter("@operation", operation);
                                if (dt.Rows[i]["Type_Id"] != DBNull.Value)
                                {
                                    objsql1[1] = new SqlParameter("@Type_Id", dt.Rows[i]["Type_Id"].ToString());
                                }
                                if (dt.Rows[i]["S_G_Name"] != DBNull.Value)
                                {
                                    
                                    objsql1[2] = new SqlParameter("@S_G_Name", dt.Rows[i]["S_G_Name"].ToString());
                                }
                                if (dt.Rows[i]["bill_no"] != DBNull.Value)
                                {
                                    objsql1[3] = new SqlParameter("@bill_no", dt.Rows[i]["bill_no"].ToString());
                                }
                               
                                
                                dt1 = connection.GetData(spanme, objsql1);
                                if (dt1 != null)
                                {
                                  
                                    dr = dtresult.NewRow();
                                    dr["P_NAME"] = dt1.Rows[0]["P_NAME"].ToString();
                                    dr["HSNCODE"] = dt1.Rows[i]["HSNCODE"].ToString();
                                    dr["GSTRATE"] = dt1.Rows[i]["GSTRATE"].ToString();
                                    dr["QTY"] = dt1.Rows[i]["QTY"].ToString();
                                    dr["UNIT"] = dt1.Rows[i]["UNIT"].ToString();
                                    dr["RATE"] = dt1.Rows[i]["RATE"].ToString();
                                    dr["TOTAL"] = dt1.Rows[i]["TOTAL"].ToString();
                                    if(Label5.Text=="27" || Label5.Text=="027")
                                    {
                                        sgst = (Convert.ToDouble(((Convert.ToDouble(dr["GSTRATE"]) * (Convert.ToDouble(dr["TOTAL"])) / 100))));
                                        cgst = cgst + sgst;
                                        mtotal = mtotal + (Convert.ToDouble(dr["TOTAL"])+sgst);
                                    }
                                    else
                                    {
                                        igst1 =igst1+ (Convert.ToDouble(((Convert.ToDouble(dr["GSTRATE"]) * (Convert.ToDouble(dr["TOTAL"])) / 100))));
                                        igst2 = igst2 + igst1;
                                        mtotal = mtotal + (Convert.ToDouble(dr["TOTAL"])+igst1);
                                    }

                                    dtresult.Rows.Add(dr);
                                }


                         }
                            Defultrow = dtresult.Rows.Count;

                            for (int j = Defultrow+1; j < 19; j++)
                            {
                                if(j==13)
                                {
                                    dr = dtresult.NewRow();
                                dr["P_NAME"] ="SGST"+"  " + (Convert.ToDouble((cgst) / 2)).ToString();
                                dr["HSNCODE"] =string.Empty;
                                dr["GSTRATE"] = string.Empty;
                                dr["QTY"] = string.Empty;
                                dr["UNIT"] = string.Empty;
                                dr["RATE"] = string.Empty;
                                dr["TOTAL"] = (Convert.ToDouble((cgst) / 2)).ToString();
                                dtresult.Rows.Add(dr);
                                }
                                else if (j == 14)
                                {
                                    dr = dtresult.NewRow();
                                    dr["P_NAME"] = "CGST"+"  " + (Convert.ToDouble((cgst) / 2)).ToString();
                                    dr["HSNCODE"] =string.Empty;
                                    dr["GSTRATE"] = string.Empty;
                                    dr["QTY"] = string.Empty;
                                    dr["UNIT"] = string.Empty;
                                    dr["RATE"] = string.Empty;
                                    dr["TOTAL"] =  (Convert.ToDouble((cgst) / 2)).ToString();
                                    dtresult.Rows.Add(dr);
                                }
                               else if (j == 15)
                                {
                                    dr = dtresult.NewRow();
                                    dr["P_NAME"] = "IGST"+ "  "+ (Convert.ToDouble((igst2))).ToString();
                                    dr["HSNCODE"] = string.Empty;
                                    dr["GSTRATE"] = string.Empty;
                                    dr["QTY"] = string.Empty;
                                    dr["UNIT"] = string.Empty;
                                    dr["RATE"] = string.Empty;
                                    dr["TOTAL"] = (Convert.ToDouble((igst2))).ToString();
                                    dtresult.Rows.Add(dr);
                                }
                               else if (j == 17)
                                {
                                    dr = dtresult.NewRow();
                                    dr["P_NAME"] = "TOTAL";
                                    dr["HSNCODE"] = string.Empty;
                                    dr["QTY"] = string.Empty;
                                    dr["UNIT"] = string.Empty;
                                    dr["RATE"] = string.Empty;
                                    dr["TOTAL"] = (Convert.ToDouble((mtotal))).ToString();
                                    dtresult.Rows.Add(dr);
                                }
                                else
                                { 
                                dr = dtresult.NewRow();
                                dr["P_NAME"] = string.Empty;
                                dr["HSNCODE"] = string.Empty;
                                dr["GSTRATE"] = string.Empty;
                                dr["QTY"] = string.Empty;
                                dr["UNIT"] = string.Empty;
                                dr["RATE"] = string.Empty;
                                dr["TOTAL"] = string.Empty;
                                dtresult.Rows.Add(dr);
                                }
                            }
                           
                            GridView1.DataSource = dtresult;
                            GridView1.DataBind();
                        }

                    }
                }
                else
                {

                }
            }
            else
            {
            }

        }

        protected void btnbill_Click1(object sender, EventArgs e)
        {
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

        private void custdetail( int no)
        {
            spanme = "sp_customer";
            operation = "loadcutdetail";
            SqlParameter[] objsql1 = new SqlParameter[2];
            objsql1[0] = new SqlParameter("@operation", operation);
            objsql1[1] = new SqlParameter("@id", no);
            DataTable dt = new DataTable();
            dt = connection.GetData(spanme, objsql1);
            if(dt!=null)
            {
                if(dt.Rows[0]["name"]!=DBNull.Value)
                {
                    Label2.Text = dt.Rows[0]["name"].ToString();
                    Label6.Text = dt.Rows[0]["name"].ToString();
                }
                if (dt.Rows[0]["state"] != DBNull.Value)
                {
                    Label4.Text = dt.Rows[0]["state"].ToString();
                    Label7.Text = dt.Rows[0]["state"].ToString();
                }
                if (dt.Rows[0]["statecode"] != DBNull.Value)
                {
                    Label5.Text = dt.Rows[0]["statecode"].ToString();
                    Label8.Text = dt.Rows[0]["statecode"].ToString();
                }

                if (dt.Rows[0]["gst_no"] != DBNull.Value)
                {
                    Label1.Text = dt.Rows[0]["gst_no"].ToString();
                    
                }
                if (dt.Rows[0]["address"] != DBNull.Value)
                {
                    lblofficeaddress.Text = dt.Rows[0]["address"].ToString();

                }
                if (dt.Rows[0]["saddress"] != DBNull.Value)
                {
                    lblsupplyaddress.Text = dt.Rows[0]["saddress"].ToString();

                }
            }
        }

        private void vehicaldetails(int vno)
        {
            spanme = "sp_MainSale";
            operation = "loadV_IdTable";
            SqlParameter[] objsql1 = new SqlParameter[2];
            objsql1[0] = new SqlParameter("@operation", operation);
            objsql1[1] = new SqlParameter("@Bill_no", vno);
            DataTable dt = new DataTable();
            dt = connection.GetData(spanme, objsql1);
            if (dt != null)
            {
                if (dt.Rows[0]["n_transport"] != DBNull.Value)
                {
                    Label11.Text = dt.Rows[0]["n_transport"].ToString();
                
                }
                if (dt.Rows[0]["v_no"] != DBNull.Value)
                {
                    Label12.Text = dt.Rows[0]["v_no"].ToString();
                  
                }
                //if (dt.Rows[0]["lr_no"] != DBNull.Value)
                //{
                //    Label5.Text = dt.Rows[0]["lr_no"].ToString();
                //    Label8.Text = dt.Rows[0]["lr_no"].ToString();
                //}
            }

        }
    }
}