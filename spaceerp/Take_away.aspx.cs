using System;

public partial class Admin_Dine_in : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnApiurl.Value = clsConfiguration.ApiUrl;
    }
}