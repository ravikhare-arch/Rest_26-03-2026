using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Masters_UserManage : System.Web.UI.Page
{
    muser_Class objClass = new muser_Class();
    validation valobj = new validation();
    SqlConnection conn;
    SqlConnection conn1;
    SqlConnection conn2;
    connection connobj = new connection();

    protected void Page_Load(object sender, EventArgs e)
    {
        //var dbCommmod = new SqlCommand();
        
        try
        {
            
            conn = connobj.makeConnection();
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tuserconfigure"] = aa;
                tblmain.Visible = true;
                //tblGrd.Visible = false;

                //displayGrid();
                objClass.ddlOperation(objClass, "Show", "", ddlUser);
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    ddlUser.SelectedValue = Request.QueryString["id"];
                }
                
                //btnVisible();
                DisplayGrid(conn);
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
            //dbCommmod.Dispose();
            conn = connobj.closeConnection();
        }
    }
    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tuserconfigure"] = Session["tuserconfigure"];
    }
    public void DisplayGrid(SqlConnection conn)
    {
        var arrayvalues1 = string.Empty;
        var vcond = string.Empty;
        var vcolumn = string.Empty;
        var vchecked = string.Empty;
        int vcnt1;
        int vcnt;
        var dbComm = new SqlCommand();
        var dbComm1 = new SqlCommand();
        var dbComm2 = new SqlCommand();
        //vcond += " and mmodule.sModuleName='" + Request.QueryString["vMenuType"] + "' ";
        //vsql = " SELECT mpage_master.sPageUrl,mmodulegroup.sGroupName ,sPageMasterName from mmodule " +
        //            " INNER JOIN mpage_master  ON mpage_master.nModuleID=mmodule.nModuleID " +
        //            " INNER JOIN mmodulegroup ON (mmodulegroup.nModuleGroupID=mpage_master.nModuleGroupID)  " +
        //            " WHERE  mpage_master.bActive=1 " + vcond + " ORDER BY mmodulegroup.nModuleGroupID ";

        var vsql = " SELECT a.sModuleName FROM mmodule a where a.nModuleID in (  " +
                    " select Distinct nModuleID from mpage_master )  ";
        
        var dbCommmod = new SqlCommand(vsql, conn);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = dbCommmod;
        DataSet ds = new DataSet();
        da.Fill(ds, "viewmuser");

        try
        {
            var tempHead = string.Empty;
            int vsrcnter = 0;
           
            if (ds.Tables[0].Rows.Count > 0)
            {
                usertab.Visible = true;
                btnAdd.Visible = true;
                vcnt1 = 0;
                vcnt = 0;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    vcnt1 = vcnt1 + 1;
                    TableRow trstage = new TableRow();
                    TableRow trstage1 = new TableRow();
                    TableCell tcelstage = new TableCell();
                    
                    tcelstage.ColumnSpan = 3;
                    tcelstage.Style.Value = "width:2%;";
                    tcelstage.Text = "<input type=\"checkbox\"  name=\"chkmain" + vcnt1 + "\" id=\"chkmain" + vcnt1 + "\" onclick=\"ChangeAllCheckBoxStates1(this.checked,'CheckBoxIDs" + vcnt1 + "')\"/>&nbsp;" + "<b>" + ds.Tables[0].Rows[i][0].ToString() + "</b>&nbsp; ";
                    trstage.Cells.Add(tcelstage);
                    usertab.Rows.Add(trstage);
                    //'array to hold check box value                 
                    List<string> ArrayValues = new List<string>();
                    ArrayValues.Add(string.Concat("'chkmain", vcnt1, "'"));

                    var qry2 = " SELECT mmodule.sModulename, mmodulegroup.sGroupName ,sPageMasterName,nPageMasterID from mpage_master " +
                    " INNER JOIN mmodule  ON mpage_master.nModuleID=mmodule.nModuleID " +
                    " INNER JOIN mmodulegroup ON (mmodulegroup.nModuleGroupID=mpage_master.nModuleGroupID)  " +
                    " WHERE  mpage_master.bActive=1 and mmodule.sModulename ='" + ds.Tables[0].Rows[i][0].ToString() + "' ORDER BY mmodulegroup.nModuleGroupID ";

                    //var dbCommmodnew = new SqlCommand();
                    var dbCommmodnew = new SqlCommand(qry2, conn);

                    SqlDataAdapter danew = new SqlDataAdapter();
                    danew.SelectCommand = dbCommmodnew;
                    DataSet dsnew = new DataSet();
                    danew.Fill(dsnew, "viewmuser");

                    //conn1 = connobj.makeConnection();
                   
                    var vGroupHead = string.Empty;
                    if (dsnew.Tables[0].Rows.Count > 0)
                    {
                        for (int j = 0; j < dsnew.Tables[0].Rows.Count; j++)
                        {
                            
                            TableRow trow1 = new TableRow();
                            TableCell tcel5 = new TableCell();
                            TableCell tcel6 = new TableCell();
                            TableCell tcel7 = new TableCell();
                            if (vGroupHead != dsnew.Tables[0].Rows[j][1].ToString())
                            {
                                vsrcnter = vsrcnter + 1;
                                vGroupHead = dsnew.Tables[0].Rows[j][1].ToString();
                                TableRow trow = new TableRow();
                                TableCell tcel = new TableCell();
                                TableCell tcel2 = new TableCell();
                                TableCell tcel3 = new TableCell();
                                TableCell tcel4 = new TableCell();
                                tcel2.Style.Value = "width:5%;";
                                tcel2.Text = "";
                                trow.Cells.Add(tcel2);
                                tcel3.Text = "";
                                trow.Cells.Add(tcel3);

                                tcel4.Text = "<b>" + vGroupHead + "</b>";
                                trow.Cells.Add(tcel4);
                                usertab.Rows.Add(trow);

                            }
                            vcnt = vcnt + 1;
                            tcel7.Text = "";
                            trow1.Cells.Add(tcel7);

                            var SQLCHECK = "SELECT nLoginID  from tuserconfigure WHERE nLoginID = " + ddlUser.SelectedValue + " AND nPageMasterID = " + dsnew.Tables[0].Rows[j][3].ToString();
                            dbComm2 = new SqlCommand(SQLCHECK, conn);
                            SqlDataAdapter da1 = new SqlDataAdapter();
                            da1.SelectCommand = dbComm2;
                            DataSet ds1 = new DataSet();

                            DataTable dt = ds1.Tables["FooTable"];
                            da1.Fill(ds1, "FooTable");
                            dt = ds1.Tables["FooTable"];

                            if (dt.Rows.Count > 0)
                            {
                                 vchecked = "Checked=Checked";
                                 trow1.CssClass = "bgselect";
                            }
                            else
                            {
                                vchecked = string.Empty;
                            }
                            
                            tcel6.Style.Value = "width:3%;text-align:center;";
                            tcel6.Text = "<input type=\"checkbox\"  name=\"chkrem" + vcnt + "\" id=\"chkrem" + vcnt + "\" " + vchecked + "  onclick=\"ChangeRowColor1('chkrem" + vcnt + "'," + vcnt + ",'CheckBoxIDs" + vcnt1 + "')\"/>" + "<input type=\"Hidden\" Name=\"hremid" + vcnt + "\" value=\"" + dsnew.Tables[0].Rows[j][3].ToString() + "\"/>";

                            trow1.Cells.Add(tcel6);
                           
                            ArrayValues.Add(string.Concat("'chkrem", vcnt, "'"));
                            tcel5.ColumnSpan = 2;
                            tcel5.Text = dsnew.Tables[0].Rows[j][2].ToString();
                            trow1.Cells.Add(tcel5);

                            usertab.Rows.Add(trow1);
                        }
                        arrayvalues1 += String.Concat("var CheckBoxIDs", vcnt1, " =  new Array(", String.Join(",", ArrayValues.ToArray()), ");");
                    }

                }
                hidcount.Value = Convert.ToString(vcnt);
                //    
                var retScript = "<script type=\"text/javascript\">" + System.Environment.NewLine + "<!--" + System.Environment.NewLine + arrayvalues1 + System.Environment.NewLine + "// -->" + System.Environment.NewLine + "</script>";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "FocusScript", retScript);

            }
            else
            {
                usertab.Visible = false;
                btnAdd.Visible = false;
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
        finally
        {
            
            dbComm1.Dispose();
            dbComm2.Dispose();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var newabc = string.Empty;
        try
        {
            conn = connobj.makeConnection();
            lblmsg.Text = "";
            string vmoddetid = string.Empty;
            string vmoduledetid = string.Empty;
            
            //var abc;
            if (Session["tuserconfigure"].ToString() == ViewState["tuserconfigure"].ToString())
            {
                var vsql = "Delete from tuserconfigure where nLoginID = " + ddlUser.SelectedValue;
                var dbComm = new SqlCommand();
                dbComm = new SqlCommand(vsql, conn);
                dbComm.ExecuteNonQuery();

                if (checkSelected())
                {
                    int rcount;
                    rcount = Int32.Parse(hidcount.Value);
                    for (int i = 0; i <= rcount; i++)
                    {
                        vmoddetid = Request["chkrem" + i];
                        vmoduledetid = Request["hremid" + i];
                        if (!string.IsNullOrEmpty(vmoddetid))
                        {
                            objClass.nuserid = ddlUser.SelectedValue;
                            objClass.nPageMasterID = vmoduledetid;
                            var abc = objClass.User_Operation(objClass, "AddConfigUser");
                            newabc = abc;             
                        }
                    }                
                }
                else
                {
                    valobj.showMsg("Please Select atleast one Checkbox","FAIL", lblmsg);
                }
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tuserconfigure"] = aa;
                if (string.IsNullOrEmpty(newabc))
                {
                    newabc = "1,Configured Successfully";
                    valobj.showMsg(newabc, lblmsg);
                }        
                else
                {
                    valobj.showMsg(newabc, lblmsg);
                }
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
            conn = connobj.closeConnection();
        }
        Response.Redirect("UserManage.aspx?id=" + ddlUser.SelectedValue + "&vmsg=" + newabc);
    }

    public bool checkSelected()
    {
        int rcount;
        rcount = Int32.Parse(hidcount.Value);
        for (int i = 0; i <= rcount; i++)
        {
            var val = Request["chkrem" + i];
            if (!string.IsNullOrEmpty(val))
            {
                return true;
            }
        }
        return false;
    }
    public void CommonFunction(SqlConnection conn)
    {
         
       
        //SqlDataReader drmod;
        //drmod = dbCommmod.ExecuteReader();
        
    }

    protected void ddlUser_SelectedIndexChnage(object sender, EventArgs e)
    {

       try
       {
           conn = connobj.makeConnection();
           DisplayGrid(conn);
       }
       catch (Exception ex)
       {
           valobj.showMsg(ex.Message, "FAIL", lblmsg);
       }
       finally
       {
           conn = connobj.closeConnection();
       }
    }


}