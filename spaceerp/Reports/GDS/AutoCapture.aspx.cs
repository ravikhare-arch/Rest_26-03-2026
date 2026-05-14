using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Reports_AutoCapture : System.Web.UI.Page
{
    cls_tticketcapture objClass = new cls_tticketcapture();
    validation valobj = new validation();
    string cond;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            displayGrid();
            //  objLocation.ddlOperation(objLocation, "Show", "", ddlLocation);
            //txtdtFrom.Text = validation.fillDate();
            //txtdtToDate.Text = validation.fillDate();
        }
       
    }

    public void displayGrid()
    {
        try
        {
            objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            displayGrid();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }
}