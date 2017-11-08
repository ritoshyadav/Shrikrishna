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
        string spanme = "sp_sale", operation = "loadall";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlParameter[] objsql = new SqlParameter[2];
            objsql[0] = new SqlParameter("@operation", operation);
            objsql[1] = new SqlParameter("@bill_no", 1);
            DataTable dt = new DataTable();
            dt = connection.GetData(spanme, objsql);
            if (dt != null)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

        }

        protected void btnbill_Click1(object sender, EventArgs e)
        {

        }
    }
}