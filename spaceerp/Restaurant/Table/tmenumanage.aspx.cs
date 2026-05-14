using System;
using System.Data;
using System.Web.UI;

public partial class Restaurant_tmenumanage : System.Web.UI.Page
{
    tmenumanage_Class objClass = new tmenumanage_Class();
    cls_ordertype objordertype = new cls_ordertype();
    validation valobj = new validation();
    string cond;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            hdnApiurl.Value = clsConfiguration.ApiUrl;
            if (!IsPostBack)
            {

                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tmenumanage"] = aa;
                objordertype.ddlOperation(objordertype, "Show", "", ddlDeliveryType);
                //objAccount.ddlOperation(objAccount, "ddlCustomer", "", ddlClient);
                //objBranch.ddlOperation(objBranch, "Showddl", "", ddlLocationID);
                //objAccount.ddlOperation(objAccount, "ddlVendor", "", ddlAgentID);



                var ID = Request.QueryString["ID"];
                if (!string.IsNullOrEmpty(ID))
                {
                    Session["eid"] = ID;
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    GetFormData();
                    ddlgst_SelectedIndexChanged(sender, e);
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
    public void GetFormData()
    {
        
        DataTable dt = objClass.viewData(objClass, "Show", Session["eid"].ToString());
        if (dt.Rows.Count > 0)
        {
            txtproductcode.Text = dt.Rows[0]["sProductCode"].ToString();
            txtproduct.Text = dt.Rows[0]["sProduct"].ToString();
            hfSelectedValue.Value = dt.Rows[0]["GroupID"].ToString();
            ddlcategory.SelectedValue = dt.Rows[0]["nCategoryID"].ToString();
            ddlfoodtype.SelectedValue = dt.Rows[0]["nFoodTypeID"].ToString();
            txtprice.Text = dt.Rows[0]["nPrice"].ToString();
            txtactualcost.Text = dt.Rows[0]["nActualCost"].ToString();
            if (dt.Rows[0]["bApplyOffer"].ToString() == "True")
                chkoffer.Checked = true;
            else
                chkoffer.Checked = false;
            if (dt.Rows[0]["isActive"].ToString() == "True")
                chkoffer.Checked = true;
            else
                chkoffer.Checked = false;
            ddlgst.SelectedValue = dt.Rows[0]["GSTID"].ToString();
            txtgstcost.Text = dt.Rows[0]["GSTCost"].ToString();
            txtgstpercent.Text = dt.Rows[0]["GSTPercent"].ToString();
            hCGST.Value = dt.Rows[0]["CGST"].ToString();
            hSGST.Value = dt.Rows[0]["SGST"].ToString();
            hIGST.Value = dt.Rows[0]["IGST"].ToString();
            ddlDeliveryType.SelectedValue = dt.Rows[0]["DeliveryType"].ToString();
            ddlacnonac.SelectedValue = dt.Rows[0]["acnonac"].ToString();
        }
    }

    public void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["tmenumanage"] = Session["tmenumanage"];
    }
    protected void lnkList_Click(object sender, EventArgs e)
    {
        Response.Redirect("tmenumanage_list.aspx");
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            lblmsg.Text = "";
            if (Session["tmenumanage"].ToString() == ViewState["tmenumanage"].ToString())
            {
                para();
                var abc = objClass.User_Operation(objClass, "add");
                valobj.showMsg(abc, lblmsg);
                string aa = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["tmenumanage"] = aa;
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
    //protected void btnDelete_Click(object sender, EventArgs e)
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        //valobj.showMsg(ex.Message, "FAIL", lblmsg);
    //    }
    //    finally
    //    {
    //    }
    //}

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            // 1. Jo item delete karna hai uski ID set karo (Session se ya QueryString se)
            objClass.MenuID = Session["eid"].ToString();

            // 2. Database me 'Delete' ka command bhejo
            var msg = objClass.User_Operation(objClass, "Delete");

            // 3. Agar message mein "1,Delete Successfully" aaya, toh list page pe bhej do
            if (msg.Contains("1,"))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Item Deleted Successfully!'); window.location='tmenumanage_list.aspx';", true);
            }
            else
            {
                // Agar koi error aayi DB se, toh show karo
                valobj.showMsg(msg, "FAIL", lblmsg);
            }
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            para();
            objClass.MenuID = Request.QueryString["ID"];
            var abc = objClass.User_Operation(objClass, "edit");
            valobj.showMsg(abc, lblmsg);
            string aa = Server.UrlEncode(System.DateTime.Now.ToString());
            Session["tmenumanage"] = aa;
        }
        catch (Exception ex)
        {
            valobj.showMsg(ex.Message, "FAIL", lblmsg);
        }
        finally
        {
        }
    }
    public void para()
    {
        objClass.Product = txtproduct.Text;
        objClass.ProductCode = txtproductcode.Text;
        objClass.GroupID = hfSelectedValue.Value;
        objClass.CategoryID = ddlcategory.SelectedValue;
        objClass.FoodTypeID = ddlfoodtype.SelectedValue;
        objClass.Price = Convert.ToDouble(txtprice.Text);
        objClass.ActualCost = Convert.ToDouble(txtactualcost.Text);
        if (chkoffer.Checked == true)
            objClass.ApplyOffer = "1";
        else
            objClass.ApplyOffer = "0";
        objClass.GSTID = ddlgst.SelectedValue;
        objClass.isActive = "1";
        objClass.GSTCost = Convert.ToDouble(txtgstcost.Text);
        objClass.CGST = Convert.ToDouble(hCGST.Value);
        objClass.SGST = Convert.ToDouble(hSGST.Value);
        objClass.IGST = Convert.ToDouble(hIGST.Value);
        objClass.GSTpercent = Convert.ToDouble(txtgstpercent.Text);
        objClass.DeliveryType = Convert.ToInt16(ddlDeliveryType.SelectedValue);
        objClass.ACNONAC = ddlacnonac.SelectedValue;

    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {

    }
    protected void ddlgst_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlgst.SelectedValue == "1")
        {
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            txtgstpercent.Enabled = true;
            txtactualcost.Enabled = true;
        }
        else
        {
            RequiredFieldValidator6.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
            txtgstpercent.Enabled = false;
            txtactualcost.Enabled = false;
        }
        txtprice_TextChanged(sender, e);
    }
    public void Clearfields()
    {

    }
    protected void txtprice_TextChanged(object sender, EventArgs e)
    {
        txtgstpercent_TextChanged(sender, e);
    }
    protected void txtgstpercent_TextChanged(object sender, EventArgs e)
    {
        if (ddlgst.SelectedValue != "0" && ddlgst.SelectedValue != "")
        {
            double totcostgst, CGST, SGST, IGST;
            CGST = 0;
            SGST = 0;
            IGST = 0;
            hCGST.Value = "0";
            hSGST.Value = "0";
            hIGST.Value = "0";
            string Price = txtprice.Text;
            string GSTvalue = txtgstpercent.Text;
            if (ddlgst.SelectedValue == "1")
            {
                if (Price == "")
                {
                    Price = "0";
                }
                if (GSTvalue == "")
                {
                    GSTvalue = "0";
                }
                totcostgst = Convert.ToDouble(Price) * Convert.ToDouble(GSTvalue) / 100;
                SGST = totcostgst / 2;
                CGST = SGST;
                hCGST.Value = Convert.ToString(CGST);
                hSGST.Value = Convert.ToString(SGST);
                txtactualcost.Text = Convert.ToString(totcostgst);
                txtgstcost.Text = Convert.ToString(totcostgst + Convert.ToDouble(Price));
            }
            else
            {
                txtgstpercent.Text = "0";
                txtactualcost.Text = "0";
                txtgstcost.Text = Price;
            }

        }
    }
}