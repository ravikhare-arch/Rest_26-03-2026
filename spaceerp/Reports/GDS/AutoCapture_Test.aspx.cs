using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Reports_AutoCapture : System.Web.UI.Page
{
    cls_tticketcapture objClass = new cls_tticketcapture();
    validation valobj = new validation();
    string cond;
    protected void Page_Load(object sender, EventArgs e)
    {
        //displayGridDet();
    }
    //public void displayGridDet()
    //{
    //    try
    //    {
    //        objClass.FillGrid(objClass, GridView1, "ShowGrid", "");
    //        //objClass.FillGrid(objClass, GridView1, "ShowGrid", Session["eid"].ToString());
    //        GridView1.Enabled = true;
    //    }
    //    catch (Exception ex)
    //    {
    //        valobj.showMsg(ex.Message, lblmsg);
    //    }
    //}
}