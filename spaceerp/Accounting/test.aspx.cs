using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Accounting_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        displayGrid();
    }
    public void displayGrid()
    {
        DataTable dt1 = new DataTable();

        dt1.Columns.Add("No");
        dt1.Columns.Add("Name");
        dt1.Columns.Add("Age");
        dt1.Columns.Add("Salary");

        dt1.Rows.Add("1", "Abdul", "25", "25000");
        dt1.Rows.Add("2", "Shaikh", "26", "25000");


        DataTable dt2 = dt1.Clone();

        dt2.Rows.Add("3", "Z", "27", "25000");
        dt2.Rows.Add("4", "Y", "28", "25000");


        DataTable dt3 = dt1.Clone();
        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            dt3.Rows.Add(dt1.Rows[i]["No"].ToString(), dt1.Rows[i]["Name"].ToString(), dt1.Rows[i]["Age"].ToString(), dt1.Rows[i]["Salary"].ToString());
        }
        for (int j = 0; j < dt1.Rows.Count; j++)
        {
            dt3.Rows.Add(dt2.Rows[j]["No"].ToString(), dt2.Rows[j]["Name"].ToString(), dt2.Rows[j]["Age"].ToString(), dt2.Rows[j]["Salary"].ToString());
        }


        GridView1.DataSource = dt3;
        GridView1.DataBind();
    }

}