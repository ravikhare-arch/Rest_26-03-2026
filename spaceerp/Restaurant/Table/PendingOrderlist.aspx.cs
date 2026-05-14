using System;
//using MailSMS;



public partial class PendingOrderlist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnApiurl.Value = clsConfiguration.ApiUrl;
    }
   
}
