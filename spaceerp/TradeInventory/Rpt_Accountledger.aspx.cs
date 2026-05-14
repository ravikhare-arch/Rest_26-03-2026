using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Web.Services;

//using CommonTbo;
//using HotelWebserviceTbo;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
//using MailSMS;
using System.Configuration;
using System.Text;


using System.Xml;
using ClosedXML.Excel;
using OfficeOpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Drawing;
using OfficeOpenXml.Style;


using System.Net.Mail;
using System.Net;

public partial class Admin_Rpt_Accountledger : System.Web.UI.Page
{

    
    validation valobj = new validation();
    public static string strcreditbalance = string.Empty;
    public static string strdebitbalance = string.Empty;
    public static string strbalance = string.Empty;
    SmtpClient sc = new SmtpClient();
    SendMail objsendmail = new SendMail();
    //Mail objmail = new Mail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
        }

    }
   

}
