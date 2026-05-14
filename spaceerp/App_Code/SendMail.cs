using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mime;
using System.Net.Mail;
using System.IO;

public class SendMail : System.Web.UI.Page
{
    static string location1;
    public string Send(string vTo, string vCC, string vBCC, string vSubject, string vBody, string AttachFileName)
    {
        MailMessage m = new MailMessage();
        MailMessage MyMail = new MailMessage();
        SmtpClient sc = new SmtpClient();

        try
        {
            string sEmail = "webflyzonet@gmail.com";
            string pass = "Khan#1w2123";
            m.From = new MailAddress(sEmail, "Alnasa");
            m.To.Add(new MailAddress(vTo, ""));
            if (vCC != "")
                m.CC.Add(new MailAddress(vCC, ""));
            if (vBCC != "")
                m.Bcc.Add(new MailAddress(vBCC, ""));
            m.Subject = vSubject;
            m.IsBodyHtml = true;
            m.Body = vBody;

            if (AttachFileName != string.Empty)
            {
                location1 = Path.Combine(Server.MapPath("../Temp"), AttachFileName);
                //FileUpload1.SaveAs(location1);

                FileStream fs = new FileStream(location1,
                                   FileMode.Open, FileAccess.Read);
                Attachment a = new Attachment(fs, AttachFileName,
                                   MediaTypeNames.Application.Octet);
                a.ContentType = new ContentType("application/vnd.ms-excel");
                m.Attachments.Add(a);
            }
            sc.Host = "smtp.gmail.com";
            sc.Port = 587;
            sc.Credentials = new
            System.Net.NetworkCredential(sEmail, pass);
            sc.EnableSsl = true;
            sc.Send(m);
            return "1";
        }
        catch (Exception ex)
        {
            return ex.ToString();
        }
        finally
        {
        }
    }
}
