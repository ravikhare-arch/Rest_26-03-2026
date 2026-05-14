using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class massetcategory_masters : System.Web.UI.Page
{
    //mcreditcard_Class objCreditCard = new mcreditcard_Class();
    //mCountry_Class objCountry = new mCountry_Class();
    validation valobj = new validation();
    string cond;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());

                Session["mcreditcard"] = aa;
                //tblmain.Visible = false;
                //tblGrd.Visible = true;
                displayGrid();
                btnVisible();
                //objCountry.ddlOperation(objCountry, "Show", "", ddlCountry);
                if (GridView1.Rows.Count < 25)
                {
                    ddlPageSize.Visible = false;
                    lblpgs.Visible = false;
                }
                else
                {
                    ddlPageSize.Visible = true;
                    lblpgs.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["mcreditcard"] = Session["mcreditcard"];
    }

    public void para()
    {
        //objCreditCard.sCurrencyName = validation.stringToDBString(txtCurrencyName.Text.Trim());
        //objCreditCard.sCurrencyCode = validation.stringToDBString(txtCurrencyCode.Text.Trim());
        //objCreditCard.nSellingPrice = txtSellingPrice.Text.Trim();
        //objCreditCard.nBuyingPrice = txtBuyingPrice.Text.Trim();
        //objCreditCard.nCountryID = ddlCountry.SelectedValue;
    }

    public void clrfield()
    {
        //txtCurrencyName.Text = "";
        //txtCurrencyCode.Text = "";
        //txtSellingPrice.Text = "";
        //txtBuyingPrice.Text = "";
        //ddlCountry.SelectedValue = "0";
        //Session["eid"] = "";
    }

    public void GetFormData()
    {
        //DataTable dt = objCreditCard.viewData(objCreditCard, "show", Session["eid"].ToString());
        //if (dt.Rows.Count > 0)
        //{
        //    txtCurrencyName.Text = dt.Rows[0][1].ToString();
        //    txtCurrencyCode.Text = dt.Rows[0][2].ToString();
        //    txtSellingPrice.Text = dt.Rows[0][3].ToString();
        //    txtBuyingPrice.Text = dt.Rows[0][4].ToString();
        //    ddlCountry.SelectedValue = dt.Rows[0][5].ToString();
       // }
    }

    public void btnVisible()
    {
        btnAdd.Visible = true;
        btnUpdate.Visible = false;
        btnDelete.Visible = false;
        clrfield();
    }

    public void displayGrid()
    {
        try
        {
            //objCreditCard.FillGrid(objCreditCard, GridView1, "ShowGrid", "");
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, lblmsg);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GridView1.PageIndex = e.NewPageIndex;
            displayGrid();
        }
        catch (Exception ex)
        {
            lblmsg.Text = ex.Message.ToString();
        }
        finally
        {
        }
    }

    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView1.PageSize = int.Parse(ddlPageSize.SelectedValue);
        displayGrid();
    }

    public void DeleteRecord()
    {
        //objCreditCard.nCurrencyID = Session["eid"].ToString();
        //var vres = objCreditCard.User_Operation(objCreditCard, "DeActive");
        //valobj.showMsg(vres, lblmsg);
        displayGrid();
        btnVisible();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["mcurrency"].ToString() == ViewState["mcurrency"].ToString())
            {
                para();
                //var abc = objCreditCard.User_Operation(objCreditCard, "add");
                //valobj.showMsg(abc, lblmsg);
                //displayGrid();
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["mcurrency"] = aa;
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            //objCreditCard.nCurrencyID = Session["eid"].ToString();
            //var abc = objCreditCard.User_Operation(objCreditCard, "edit");
            //valobj.showMsg(abc, lblmsg);
            //displayGrid();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            DeleteRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }

    protected void btngdEdit_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;

            btnAdd.Visible = false;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            GetFormData();
            lblmsg.Text = "";
            tblmain.Visible = true;
            tblGrd.Visible = false;
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void btngdDelete_Click(object sender, EventArgs e)
    {
        try
        {
            Session["eid"] = "";
            LinkButton thisbtn = (LinkButton)sender;
            GridViewRow thisgrdR = (GridViewRow)thisbtn.Parent.Parent;
            int row = thisgrdR.RowIndex;
            Label ID = (Label)GridView1.Rows[row].Cells[0].FindControl("lblID");
            Session["eid"] = ID.Text;

            DeleteRecord();
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }

    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = true;
        tblGrd.Visible = false;
        clrfield();
        btnVisible();
    }

    protected void lnkList_Click(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        tblmain.Visible = false;
        tblGrd.Visible = true;
        displayGrid();
    }
}