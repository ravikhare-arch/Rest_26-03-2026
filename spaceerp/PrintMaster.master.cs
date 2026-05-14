using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PrintMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] == null)
        {
            Response.Redirect("../default.aspx");
        }
        else if (Session["ConfigID"] == null)
        {
            Response.Redirect(Page.ResolveUrl("~/default.aspx"));

        }
            
    }
}
