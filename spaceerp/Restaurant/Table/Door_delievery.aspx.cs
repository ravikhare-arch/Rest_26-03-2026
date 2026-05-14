using System;

public partial class Door_delievery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnApiurl.Value = clsConfiguration.ApiUrl;
    }
}