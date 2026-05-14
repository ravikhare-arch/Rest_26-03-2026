using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Web;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;


public class validation : System.Web.UI.Page
{
    static string strReturn, tm, dt, day, month, year, dateReturn, sec, min, hour, timeReturn;
    string vmsgty, FileName;

    public void showMsg(string msg, string msgType, Label lblMsg)
    {
        lblMsg.Visible = true;
        if (msgType.ToUpper() == "FAIL")
        {
            vmsgty = "<div class=\"panel-body\"><div class=\"alert alert-danger fade show m-b-0\"><span class=\"close\" data-dismiss=\"alert\">×</span><strong>Failure! </strong>" + msg + "</div></div>";
        }
        else if (msgType.ToUpper() == "SUCC")
        {
            vmsgty = "<div class=\"panel-body\"><div class=\"alert alert-success fade show m-b-0\"><span class=\"close\" data-dismiss=\"alert\">×</span><strong>Success! </strong>" + msg + "</div></div>";
        }

        lblMsg.Text = vmsgty;

    }

    public void showMsg(string msg, Label lblMsg)
    {
        string txtmsg = string.Empty;
        lblMsg.Text = "";
        string vmsgtyp, vcolor;
        lblMsg.Visible = true;
        var vmsg = msg.Split(',');
        if (vmsg[0] == "0")
        {
            vmsgty = "<div class=\"panel-body\" style='font-size: 14px;position:fixed;top:0;left:0;width:100%;z-index:100000;'><div class=\"alert alert-danger fade show m-b-0\"><span class=\"close\" data-dismiss=\"alert\">×</span><strong>Failure!</strong> " + vmsg[1] + "</div></div>";
         }
        else if (vmsg[0] == "1")
        {
            vmsgty = "<div class=\"panel-body\" style='font-size: 14px;position:fixed;top:0;left:0;width:100%;z-index:100000;'><div class=\"alert alert-success fade show m-b-0\"><span class=\"close\" data-dismiss=\"alert\">×</span><strong>Success!</strong> " + vmsg[1] + "</div></div>";
         }
        else
        {
            vmsgty = "<div class=\"panel-body\" style='font-size: 14px;position:fixed;top:0;left:0;width:100%;z-index:100000;'><div class=\"alert alert-warning  fade show m-b-0\"><span class=\"close\" data-dismiss=\"alert\">×</span><strong>Warning!</strong> " + vmsg[1] + "</div></div>";
     
        }
        if (vmsg.Length == 1)
        {
            txtmsg = vmsg[0];
        }
        else
        {
            txtmsg = vmsg[1];
        }
        lblMsg.Text =  vmsgty;
    }

    public void showMsg1(string msg, string msgType, Label lblMsg)
    {
        lblMsg.Visible = true;
        if (msgType.ToUpper() == "FAIL")
        {
            vmsgty = "<img src=\"img/error.gif\" />";
        }
        else if (msgType.ToUpper() == "SUCC")
        {
            vmsgty = "<img src=\"img/success.gif\" />";
        }

        lblMsg.Text = "<table align='center' style='background-color:Gray;'> " +
                         "<tr><td>" + vmsgty + "</td><td><font color='white'><b>" + msg + "</b></font></td></tr></table>";
    }

    public void showMsg1(string msg, Label lblMsg)
    {
        string txtmsg = string.Empty;
        lblMsg.Text = "";
        string vmsgtyp, vcolor;
        lblMsg.Visible = true;
        var vmsg = msg.Split(',');
        if (vmsg[0] == "0")
        {
            vmsgtyp = "<img src=\"img/error.gif\" />";
            vcolor = "#cc0033";
        }
        else if (vmsg[0] == "1")
        {
            vmsgtyp = "<img src=\"img/success.gif\" />";
            vcolor = "yellow";
        }
        else
        {
            vmsgtyp = "<img src=\"img/error1.gif\" />";
            vcolor = "pink";
        }
        if (vmsg.Length == 1)
        {
            txtmsg = vmsg[0];
        }
        else
        {
            txtmsg = vmsg[1];
        }
        lblMsg.Text = "<table align='center' style='background-color:" + vcolor + ";'> " +
                         "<tr><td>" + vmsgtyp + "</td><td><font color='black'><b>" + txtmsg + "</b></font></td></tr></table>";
    }

    public static void hideMsg(Label lblMsg)
    {
        lblMsg.Visible = false;
    }
    public static bool validateDate(string vDate)
    {
        try
        {
            System.DateTime myDateTimeUS = default(System.DateTime);

            System.Globalization.CultureInfo format = new System.Globalization.CultureInfo("en-gb", true);

            myDateTimeUS = System.DateTime.Parse(vDate, format);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool validateTime(string vTime)
    {
        try
        {
            System.DateTime myDateTimeUS = default(System.DateTime);

            System.Globalization.CultureInfo format = new System.Globalization.CultureInfo("en-gb", true);
            //System.Globalization.CultureInfo format = new System.Globalization.CultureInfo(2, true);

            myDateTimeUS = System.DateTime.Parse(vTime, format);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static bool validateTimeFor(string vTime)
    {
        string tm, hour, min;
        tm = vTime;
        if (tm.Length == 5)
        {
            hour = tm.Substring(0, 2);
            min = tm.Substring(3, 2);
            if (int.Parse(hour) > 12)
                return false;
            else if (int.Parse(min) > 59)
                return false;

            return true;
        }
        else
            return false;
    }

    public static void showLinks(Label vlink, string[] vlinks)
    {
        int i;
        vlink.Text = "<center><table align=left ><tr>";
        for (i = 0; i <= vlinks.Length - 1; i++)
        {
            vlink.Text += "<td width=10 class=bul></td><td align=left><a href=" + vlinks[i] + ">";
            i += 1;
            vlink.Text += vlinks[i] + "</a></td>";
        }
        vlink.Text += "</tr></table></center><br>";
    }

    public static string fillDate()
    {
        string sday, smon, syear, sdate;
        sday = DateTime.Now.Day.ToString();
        smon = DateTime.Now.Month.ToString();
        syear = DateTime.Now.Year.ToString();

        if ((sday.Length) < 2)
        {
            sday = "0" + sday;
        }
        if ((smon.Length) < 2)
        {
            smon = "0" + smon;
        }
        sdate = sday + "/" + smon + "/" + syear;
        return sdate;
    }
    public static string fillTextDate()
    {
        string sday, smon, syear, sdate;
        sday = DateTime.Now.Day.ToString();
        smon = DateTime.Now.Month.ToString();
        syear = DateTime.Now.Year.ToString();

        if ((sday.Length) < 2)
        {
            sday = "0" + sday;
        }
        if ((smon.Length) < 2)
        {
            smon = "0" + smon;
        }
        sdate = syear + smon + sday;
        return sdate;
    }
    public static string fillTime()
    {
        string shour, smin, ssec, stime;
        shour = DateTime.Now.Hour.ToString();
        smin = DateTime.Now.Minute.ToString();
        //ssec = DateTime.Now.Second.ToString();

        if ((shour.Length) < 2)
        {
            shour = "0" + shour;
        }
        if ((smin.Length) < 2)
        {
            smin = "0" + smin;
        }
        //if ((ssec.Length) < 2)
        //{
        //    ssec = "0" + ssec;
        //}
        stime = shour + ":" + smin;
        return stime;
    }
    public static string dateToText(string tDate)
    {
        dt = tDate;
        if (dt != "")
        {
            day = dt.Substring(0, 2);
            month = dt.Substring(3, 2);
            year = dt.Substring(6, 4);
            dateReturn = year + month + day;
        }
        else
            dateReturn = tDate;

        return dateReturn;
    }
    public static string TextToDate(string tDate)
        {
        dt = tDate;
        if (dt.Length == 8)
        {
            year = dt.Substring(0, 4);
            month = dt.Substring(4, 2);
            day = dt.Substring(6, 2);
            dateReturn = day + "/" + month + "/" + year;
        }
        else
            dateReturn = tDate;

        return dateReturn;
    }

    public static string stringToDBString(string str)
    {
        if (str != "")
        {
            string pn1;
            pn1 = str.Replace("'", "''");
            strReturn = pn1.Replace("\"\"", "\"\"\"\"");
            //strReturn = pn2.Replace("&", "&");
        }
        else
        {
            strReturn = "";
        }
        return strReturn;
    }

    public string AddImage(FileUpload FU)
    {
        try
        {
            FileName = "";
            string dirname1 = null;
            if (FU.HasFile)
            {
                string UploadImageType = FU.PostedFile.ContentType.ToString().ToLower();
                string UploadImageFileName = FU.PostedFile.FileName;

                FileName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() +
                           DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() +
                           DateTime.Now.TimeOfDay.Seconds.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString() + "_" + FU.FileName;

                FileName = FileName.ToLower();
                FileName = FileName.Replace("__", "_");


                dirname1 = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath + "\\" + "Uploads");
                FU.PostedFile.SaveAs(dirname1 + "\\" + FileName);

            }
            else
            { }
            return FileName;
        }
        catch (Exception ex)
        {
            return "error";
        }
    }

    public string UpdateImage(FileUpload FU, Label lbl)
    {
        try
        {
            FileName = "";
            if ((FU.HasFile) && (lbl.Text != ""))
            {
                Deleteimg(lbl.Text);
                return FileName = AddImage(FU);
            }
            else if ((FU.HasFile) && (lbl.Text == ""))
            {
                return FileName = AddImage(FU);
            }
            else
            {
                return lbl.Text;
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    public void Deleteimg(string vFileName)
    {
        if (vFileName != "")
        {
            string fileName = vFileName;
            fileName = Path.Combine(Server.MapPath(HttpContext.Current.Request.ApplicationPath + "\\" + "Uploads"), fileName);
            File.Delete(fileName);
        }
    }

    public static string fillTimeAMPM()
    {
        string shour, smin, ssec, stime;
        shour = DateTime.Now.Hour.ToString();
        smin = DateTime.Now.Minute.ToString();
        ssec = DateTime.Now.Second.ToString();

        if ((shour.Length) < 2)
        {
            shour = "0" + shour;
        }
        if ((smin.Length) < 2)
        {
            smin = "0" + smin;
        }
        if ((ssec.Length) < 2)
        {
            ssec = "0" + ssec;
        }
        stime = shour + ":" + smin;
        return stime;
    }
    public string AutoCapture(FileUpload FU)
    {
        try
        {
            FileName = "";
            string dirname1 = null;
            if (FU.HasFile)
            {
                
                FileName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() +
                           DateTime.Now.TimeOfDay.Hours.ToString() + DateTime.Now.TimeOfDay.Minutes.ToString() +
                           DateTime.Now.TimeOfDay.Seconds.ToString() + DateTime.Now.TimeOfDay.Milliseconds.ToString() + "_" + FU.FileName;

                FileName = FileName.ToLower();
                FileName = FileName.Replace("__", "_");


                dirname1 = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath + "\\" + "AutoCapture");
                FU.PostedFile.SaveAs(dirname1 + "\\" + FileName);

            }
            else
            { }
            return FileName;
        }
        catch (Exception ex)
        {
            return "error";
        }
    }
    public static string slashdateToText(string tDate)
    {
        dt = tDate;
        if (dt != "")
        {
            day = dt.Substring(0, 2);
            month = dt.Substring(3, 2);
            year = "20" + dt.Substring(6, 2);
            dateReturn = year + month + day;
        }
        else
            dateReturn = tDate;

        return dateReturn;
    }
    public static string HyphendateToText(string getdate)
    {
        string month, day, year;
        string returnval = string.Empty;
        if (getdate != "")
        {
            var dt = getdate.Split('-');
            year = dt[0];
            month = dt[1];
            day = dt[2];
            returnval = year + month + day ;
            return returnval;
        }
        return returnval;
    }
}

