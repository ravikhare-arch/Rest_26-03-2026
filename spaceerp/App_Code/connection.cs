using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public class connection
{
    public SqlConnection conn;

    public SqlConnection makeConnection()
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        conn.Open();
        return conn;
    }
    public SqlConnection closeConnection()
    {
        conn.Close();
        return conn;
    }

    public void FillGrid(Repeater vGrd, string sql)
    {
        conn = makeConnection();
        DataSet ds = new DataSet();
        SqlDataAdapter daAdapter = new SqlDataAdapter();
        daAdapter.SelectCommand = new SqlCommand(sql, conn);
        daAdapter.Fill(ds);
        daAdapter.Dispose();
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    vGrd.DataSource = ds;
                    vGrd.DataBind();
                }
            }
        }
        ds.Dispose();
        closeConnection();
    }


}
