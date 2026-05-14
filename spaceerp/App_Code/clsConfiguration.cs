using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for clsConfiguration
/// </summary>
public static class clsConfiguration
{
   public static readonly string ApiUrl;
    public static readonly string CompanyId;
    public static readonly string DomainUrl;
    static clsConfiguration()
    {
        ApiUrl= Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["ApiUrl"]);
        CompanyId = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["CompanyId"]);
        DomainUrl = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["DomainUrl"]);
    }
}