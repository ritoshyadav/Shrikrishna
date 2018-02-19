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
    public partial class Billing : System.Web.UI.Page
    {
        string spanme = "",operation="";
        protected void Page_Load(object sender, EventArgs e)
        {
            int lno = 11;
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", operation);
            objsql[1] = new SqlParameter("@id",1);
            DataTable dt = new DataTable();
            dt = connection.GetData(spanme, objsql);
            if(dt!=null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = lno; j < 24; j++)
                    {
                        //Label(lno).text
                        lno = lno + 1;
                    }

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void btnbill_Click(object sender, EventArgs e)
        {

        }

        protected void btnbill_Click1(object sender, EventArgs e)
        {
            //btnbill.Visible = false;
         
            
        }
    }
}