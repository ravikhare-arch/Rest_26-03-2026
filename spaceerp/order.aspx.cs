using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Agent_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnApiurl.Value = clsConfiguration.ApiUrl;
        hidCompanyId.Value = clsConfiguration.CompanyId;
        hidDomainUrl.Value = clsConfiguration.DomainUrl;
    }
}