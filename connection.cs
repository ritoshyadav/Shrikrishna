using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


namespace Shrikrishna
{
    public class connection
    {
        public static string strConnection = @"server=DESKTOP-A1KQ2QV;database=shrikrishna;uid=sa;pwd=rockpari;Connect Timeout=200;pooling='true';Max Pool Size=500;Min Pool Size=5;";

        public static int ExecuteQuery(string strSPName, SqlParameter[] objSqlParameter)
        {
            int iResult = 0;

            try
            {


                SqlConnection objSqlConnection = new SqlConnection(strConnection);

                objSqlConnection.Open();

                SqlCommand objSqlCommand = new SqlCommand(strSPName, objSqlConnection);

                objSqlCommand.CommandType = CommandType.StoredProcedure;

                if (objSqlParameter != null)
                {
                    objSqlCommand.Parameters.AddRange(objSqlParameter);
                }

                iResult = objSqlCommand.ExecuteNonQuery();

                objSqlConnection.Close();
            }
            catch (Exception ex)
            {

                string strError = ex.Message;
            }

            return iResult;
        }



        public static DataTable GetData(string strSPName, SqlParameter[] objSqlParameters)
        {
            DataTable objDataTable = null;

            try
            {

                SqlConnection objSqlConnection = new SqlConnection(strConnection);
                SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter(strSPName, objSqlConnection);

                objSqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (objSqlParameters != null)
                {
                    objSqlDataAdapter.SelectCommand.Parameters.AddRange(objSqlParameters);
                }

                DataSet objDataSet = new DataSet();
                objSqlDataAdapter.Fill(objDataSet);

                if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0] != null && objDataSet.Tables[0].Rows.Count > 0)
                {
                    //objDataSet.WriteXml("g:\\StudentInfo.xml", XmlWriteMode.WriteSchema);
                    objDataTable = objDataSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }

            return objDataTable;
        }
    }
}