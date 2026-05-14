<%@ Page Title="Item Details" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="titem_details.aspx.cs" Inherits="Transcation_item_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

    <style>
        .btnspl {
            padding: 8px 20px !important;
            min-width: 200px;
        }

        .fade {
            opacity: 1;
        }

        .nav-pills > li > a.active.nav-link {
            color: #ffffff;
            background-color: #21212b;
            border-color: #21212b;
        }

        .m-t-5 {
            margin-top: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <div class="row">
        <!-- begin col-6 -->
        <div class="col-lg-12">
            <!-- begin nav-tabs -->
            <div class="panel panel-inverse">
                <div class="panel-heading">
                    <div class="panel-heading-btn pull-left">
                        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Item Details</h4>
                </div>
                <ul class="col-md-6 col-md-push-4 col-xs-12 col-xs-push-1 m-t-5 nav nav-pills" style="display:none;">
                    <li class="nav-items" id="ItemTab1" runat="server">
                        <a href="#ItemTab_1" data-toggle="tab"
                            class="nav-link active" runat="server" id="ItemTabe1" clientidmode="static"><span class="d-sm-none">Item Details</span> <span class="d-sm-block d-none">Item Details</span> </a></li>

                    <li class="nav-items" id="ItemTab3" runat="server">
                        <a href="#ItemTab_3" data-toggle="tab" runat="server" id="ItemTabe3" clientidmode="static"
                            class="nav-link"><span class="d-sm-none">Accounts</span>  </a></li>
                    <li class="nav-items" id="ItemTab4" runat="server">
                        <a href="#ItemTab_4" data-toggle="tab" runat="server" id="ItemTabe4" clientidmode="static"
                            class="nav-link"><span class="d-sm-none">Pictures</span> <span class="d-sm-block d-none">Pictures</span> </a></li>
                    <li class="nav-items" id="ItemTab5" runat="server" visible="false">
                        <a href="#ItemTab_5" runat="server" id="ItemTabe5" clientidmode="static"
                            data-toggle="tab" class="nav-link"><span class="d-sm-none">Item Group</span> <span
                                class="d-sm-block d-none">Item Group</span> </a></li>
                </ul>
                <!-- end nav-tabs -->
                <!-- begin tab-content -->
                <div class="tab-content hero-tab-pane">
                    <!-- begin tab-pane -->
                    <div class="row">
                        <div class="tab-pane active" runat="server" clientidmode="static" id="ItemTab_1">
                            <asp:UpdatePanel ID="up1" runat="server">
                                <ContentTemplate>
                                    <div class="col-md-12 ml-auto mr-auto">
                                        <div class="form-group row m-b-0">
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">
                                                    Item Name * :
                                                </label>
                                                <asp:TextBox ID="txtitemName" CssClass="form-control" runat="server" Width="100%" required></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="fullname">
                                                    Item Category :</label>
                                                <asp:DropDownList ID="ddlItemCategory" CssClass="form-control" runat="server" Width="100%" OnTextChanged="ddlItemCategory_TextChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>

                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="fullname">
                                                    Item Sub Category :</label>
                                                <asp:DropDownList ID="ddlItemSubCategory" CssClass="form-control" runat="server" Width="100%">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="fullname">
                                                    Item Type :</label>
                                                <asp:DropDownList ID="ddlItemType" CssClass="form-control" runat="server" Width="100%">
                                                    <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Normal Item" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Group Item" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-4">
                                                <label class="col-form-label" for="fullname">
                                                    Item Mark *:</label>
                                                <asp:TextBox ID="txtItemMark" CssClass="form-control" runat="server" Width="100%" required></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Sale Price * :</label>

                                                        <asp:TextBox ID="txtSalePrice" CssClass="form-control" runat="server" Width="100%" required></asp:TextBox><asp:RegularExpressionValidator
                                                            ID="REV14" runat="server" ControlToValidate="txtSalePrice" SetFocusOnError="True"
                                                            Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE14" runat="server" Enabled="True" FilterMode="ValidChars"
                                                            FilterType=" Custom,Numbers" TargetControlID="txtSalePrice" ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                        </div>
                                        <div class="form-group row m-b-0" style="display: none">
                                            <div class="col-md-2 col-sm-4 p-t-30" style="display: none">
                                                <label class="col-form-label hide" for="fullname">
                                                    Show Warrenty Remarks :</label>
                                                <asp:CheckBox ID="chkWarrentyRemarks" CssClass="form-control" Text=" Show Warrenty Remarks" runat="server"
                                                    Width="100%" />
                                            </div>
                                            <div class="col-md-3 col-sm-8">
                                                <label class="col-form-label" for="fullname">
                                                    Warrenty Remarks :</label>
                                                <asp:TextBox ID="txtWarrentyRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-8">
                                                <label class="col-form-label" for="fullname">
                                                    Specification Remarks:</label>
                                                <asp:TextBox ID="txtSpecificationRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-4 p-t-30" style="display: none">
                                                <label class="col-form-label hide" for="fullname">
                                                    Show Promotion Remarks :</label>
                                                <asp:CheckBox ID="chkPromotionRemarks" CssClass="form-control" Text="Show Promotion" runat="server" Width="100%" />
                                            </div>
                                            <div class="col-md-3 col-sm-8">
                                                <label class="col-form-label " for="fullname">
                                                    Promotion Remarks :</label>
                                                <asp:TextBox ID="txtPromotionRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-md-3 col-sm-8">
                                                <label class="col-form-label" for="fullname">
                                                    Item Remarks :</label>
                                                <asp:TextBox ID="txtItemRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row m-b-0">
                                            <div class="col-md-2 col-sm-4 p-t-30" style="display: none">
                                                <label class="col-form-label hide" for="fullname">
                                                    Show Item Remarks :</label>
                                                <asp:CheckBox ID="chkItemRemarks" CssClass="form-control" Text="Show Item Remarks" runat="server" Width="100%" />
                                            </div>
                                            <div class="col-md-2 col-sm-4 p-t-30" style="display: none">

                                                <asp:CheckBox ID="chkSpecificationRemarks" Text="Show Specification" runat="server"
                                                    Width="100%" />
                                            </div>
                                            

                                        </div>
                                        <div class="form-group row m-b-20">
                                            <div class="col-md-6 col-sm-12">
                                                <div class="form-group row m-b-0">                                                    
                                                    <div class="col-md-2 col-sm-3" style="display:none;">
                                                        <label class="col-form-label" for="fullname">
                                                            Avg Sale Price :</label>
                                                        <asp:TextBox ID="txtAvgSalePrice" CssClass="form-control" runat="server" Width="100%"></asp:TextBox><asp:RegularExpressionValidator
                                                            ID="REV15" runat="server" ControlToValidate="txtAvgSalePrice" SetFocusOnError="True"
                                                            Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE15" runat="server" Enabled="True" FilterMode="ValidChars"
                                                            FilterType=" Custom,Numbers" TargetControlID="txtAvgSalePrice" ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3" style="display:none;">
                                                        <label class="col-form-label" for="fullname">
                                                            Last Pur. Price :</label>

                                                        <asp:TextBox ID="txtLastPurchasePrice" CssClass="form-control" runat="server" Width="100%"></asp:TextBox><asp:RegularExpressionValidator
                                                            ID="REV16" runat="server" ControlToValidate="txtLastPurchasePrice" SetFocusOnError="True"
                                                            Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server" Enabled="True" FilterMode="ValidChars"
                                                            FilterType=" Custom,Numbers" TargetControlID="txtLastPurchasePrice" ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-3" style="display:none;">
                                                        <label class="col-form-label" for="fullname">
                                                            Avg Pur. Price</label>
                                                        <asp:TextBox ID="txtAvgPurchasePrice" CssClass="form-control" runat="server" Width="100%"></asp:TextBox><asp:RegularExpressionValidator
                                                            ID="REV17" runat="server" ControlToValidate="txtAvgPurchasePrice" SetFocusOnError="True"
                                                            Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE17" runat="server" Enabled="True" FilterMode="ValidChars"
                                                            FilterType=" Custom,Numbers" TargetControlID="txtAvgPurchasePrice" ValidChars=".-">
                                                        </AjaxToolKit:FilteredTextBoxExtender>
                                                    </div>
                                                    <div class="col-md-2 col-sm-4">
                                                    <label class="col-form-label" for="fullname">Item Unit :</label><br />
                                                    <asp:DropDownList ID="ddlItemUnit" CssClass="form-control" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                </div>
                                                    <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Item Size :</label><br />
                                                    <asp:DropDownList ID="ddlItemSize" CssClass="form-control" runat="server" Width="100%">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-2 col-sm-3" style="display:none;">
                                                    <label class="col-form-label" for="fullname">
                                                        Color :</label>
                                                    <asp:TextBox ID="txtColor" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                    
                                                </div>


                                            </div>

                                            <div class="col-md-6 col-sm-12" style="display: none">
                                                <div class="form-group row m-b-0">
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Last Purchase :</label>
                                                        <asp:TextBox ID="txttLastPurchase" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txttLastPurchase" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server" TargetControlID="txttLastPurchase"
                                                            Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV18" ControlToValidate="txttLastPurchase" ValidationGroup="A"
                                                            Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Last Order :</label>
                                                        <asp:TextBox ID="txttLastOrder" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender19" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txttLastOrder" TargetControlID="txttLastOrder" PopupPosition="TopLeft" />
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE19" runat="server" TargetControlID="txttLastOrder"
                                                            Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV19" ControlToValidate="txttLastOrder" ValidationGroup="A"
                                                            Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Last Sales :</label>
                                                        <asp:TextBox ID="txttLastSold" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender20" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txttLastSold" TargetControlID="txttLastSold" PopupPosition="TopLeft" />
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE20" runat="server" TargetControlID="txttLastSold"
                                                            Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV20" ControlToValidate="txttLastSold" ValidationGroup="A"
                                                            Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                    <div class="col-md-3 col-sm-3">
                                                        <label class="col-form-label" for="fullname">
                                                            Expiry Date :</label>
                                                        <asp:TextBox ID="txttExpiry" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender21" runat="server" Format="dd/MM/yyyy"
                                                            PopupButtonID="txttExpiry" TargetControlID="txttExpiry" PopupPosition="TopLeft" />
                                                        <AjaxToolKit:MaskedEditExtender ID="MEE21" runat="server" TargetControlID="txttExpiry"
                                                            Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                        <asp:RegularExpressionValidator ID="REV21" ControlToValidate="txttExpiry" ValidationGroup="A"
                                                            Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                        </asp:RegularExpressionValidator>
                                                    </div>
                                                </div>

                                            </div>
                                            <div class="form-group row m-b-15" style="display:none;">
                                                
                                                <div class="col-md-3 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Barcode :</label>
                                                    <asp:TextBox ID="txtbarcode" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Min. Order Level *:</label>
                                                    <asp:TextBox ID="txtMinOrder" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>

                                                <div class="col-md-2 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Delivery Qty :</label>
                                                    <asp:TextBox ID="txtDeliveryQty" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Redeem Point :</label>
                                                    <asp:TextBox ID="txtRedeemPoint" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>

                                            </div>
                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-4" style="display:none;">
                                                    <label class="col-form-label" for="fullname">
                                                        Vendor Name :</label>
                                                    <asp:TextBox ID="txtVendor" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>                                               
                                                <div class="col-md-1 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Tax Item :</label>
                                                    <asp:CheckBox ID="chkTaxItem" CssClass="form-control" Text="Tax Item" runat="server" Width="100%" Checked="true" AutoPostBack="true" OnCheckedChanged="chkTaxItem_CheckedChanged" />
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        GST TAX :</label><br />
                                                    <asp:DropDownList ID="ddlGSTTax" CssClass="form-control" runat="server" Width="100%" Enabled="true">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-1 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Cess Tax (%) :</label>
                                                    <asp:TextBox ID="txtCessTax" CssClass="form-control" runat="server" Width="100%" Enabled="true"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="fullname">
                                                        Other Tax :</label>
                                                    <asp:TextBox ID="txtOtherTax" CssClass="form-control" runat="server" Width="100%" Enabled="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-group row m-b-15">
                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Assets Stock Account :</label><br />
                                                    <asp:DropDownList ID="ddlAssetsAccount" runat="server" CssClass="form-control js-example-placeholder-single" Width="90%">
                                                        <%-- <asp:ListItem Text="Select Assets Stock Account" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Main Stock" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Expire Stock" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3 Months Stock" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Sales Revenue Account :</label><br />
                                                    <asp:DropDownList ID="ddlRevenueAccount" runat="server" CssClass="form-control js-example-placeholder-single" Width="90%">
                                                        <%-- <asp:ListItem Text="Select Revenue Account" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Business Revenue" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Item Revenue" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Main Revenue" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label" for="fullname">
                                                        Expense /COS AccountID :</label><br />
                                                    <asp:DropDownList ID="ddlExpenseAccount" runat="server" CssClass="form-control js-example-placeholder-single" Width="90%">
                                                        <%-- <asp:ListItem Text="Select Expense" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Exp Cat 1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Exp Cat 2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Exp Cat 3" Value="3"></asp:ListItem>--%>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">
                                                    Please Select Picture :</label>
                                            </div>
                                            <div class="col-md-4 col-sm-4">
                                                <asp:FileUpload ID="imgUpload" runat="server" class="btn btn-primary" />
                                                <asp:RegularExpressionValidator ID="regexValidator" Display="dynamic" runat="server" ControlToValidate="imgUpload"
                                                    ErrorMessage="Only JPEG images are allowed" ValidationExpression="(.*\.([Jj][Pp][Gg])|.*\.([Jj][Pp][Ee][Gg])$)">
                                                </asp:RegularExpressionValidator>
                                            </div>
                                            <div class="col-md-6 col-sm-6">
                                                <asp:Button ID="btnPicture" runat="server" CssClass="btn btn-primary" Text="Update"
                                                    ValidationGroup="A" OnClick="btnPicture_Click" ToolTip="Update" Visible="false" />
                                            </div>
                                        </div>
                                        <div class="form-group row" style="text-align: center;">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Image runat="server" ID="imgitem" CssClass="img-thumbnail" />
                                                <%--<img src="../assets/img/item-img/'<%# Eval("fileName") %>'" alt="Item Image" title="Item Image" width="50%" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- modal popup for show visa documents--%>
                                    <div class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true" id="visadocumentpopup">
                                        <div class="modal-dialog modal-lg">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h1>Visa Documents</h1>
                                                    <%-- <a id="popupContactClose1">x</a>--%>
                                                </div>
                                                <div class="modal-body">
                                                    <div id="divHistory1">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%-- upload modal--%>
                                    <!-- Modal -->
                                    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                                        <div class="modal-dialog" role="document">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                        <span aria-hidden="true">&times;</span>
                                                    </button>
                                                </div>
                                                <div class="modal-body">
                                                    <div>
                                                        <asp:FileUpload runat="server" ID="FUvisa" />
                                                        <asp:HiddenField runat="server" ID="visaid" />
                                                    </div>
                                                    <div>
                                                        <img class="fright" src="" height="40%" width="50%" alt=".jpg" id="visaclrimg">
                                                    </div>
                                                    <div>
                                                        <label style="color: green; display: none;" id="lblsuccess">Successfully updated</label>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                                                    <button type="button" class="btn btn-primary" id="btnvisaupload">Upload</button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class=" col-md-8" style="display: none">
                                        <div class="float-right">
                                            <input type="button" value="Upload Visa" id="uploadpopup" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal"><input type="button" value="View Visa Document" id="btnvisaviewdoc" class="btn btn-primary" data-toggle="modal" data-target="#visadocumentpopup">
                                        </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </div>
                        <!-- end tab-pane -->
                        <!-- begin tab-pane -->
                        <!-- end tab-pane -->
                        <!-- begin tab-pane -->
                        <div class="tab-pane fade" runat="server" clientidmode="static" id="ItemTab_3" visible="false">
                            <div class="form-group row m-b-15">
                            </div>
                            <div class="form-group row m-b-0">
                                <div class="col-md-12 col-sm-12 text-center">
                                    <asp:Button ID="btnUpdateAccount" runat="server" CssClass="btn btn-primary" Text="Update"
                                        ValidationGroup="A" OnClick="btnUpdateAccount_Click" ToolTip="Update" />
                                </div>
                            </div>
                        </div>
                        <!-- end tab-pane -->
                        <!-- begin tab-pane -->
                        <div class="tab-pane fade" id="ItemTab_4" runat="server" clientidmode="static">
                        </div>
                        <!-- end tab-pane -->
                        <!-- begin tab-pane -->
                        <%-- <div class="tab-pane fade" id="ItemTab_5">




                       


                        <div class="form-group row m-b-15">

                            <div class="col-md-12 col-sm-12">
                                <label class="col-form-label" for="fullname">Item Name :</label>
                                <asp:TextBox ID="txtGItemName" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txtGItemName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <div class="form-group row m-b-15">

                            <div class="col-md-12 col-sm-12">
                                <label class="col-form-label" for="fullname">Quantity :</label>
                                        <asp:TextBox ID="txtGQty" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV3" runat="server" ControlToValidate="txtGQty"
                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE3" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtGQty"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtGQty" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">

                            <div class="col-md-12 col-sm-12">
                                <label class="col-form-label" for="fullname">Sale Price :</label>SalePrice
                                        <asp:TextBox ID="txtGSalePrice" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV4" runat="server" ControlToValidate="txtSalePrice"
                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                            ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE4" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtGSalePrice"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="txtGSalePrice" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                       <div class="form-group row m-b-0">
                            <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                            <div class="col-md-8 col-sm-8">

                                <asp:Button ID="btnAddGroup" runat="server" CssClass="btn btn-primary"  Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
                                <asp:Button ID="btnUpdateGroup" runat="server" CssClass="btn btn-primary"  Text="Update" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                <asp:Button ID="btnDeleteGroup" runat="server" CssClass="btn btn-primary"  Text="Delete" OnClick="DeleteGroup_Click" ToolTip="Delete" />
                                <AjaxToolKit:ConfirmButtonExtender ID="btnDeleteGroup_ConfirmButtonExtender" runat="server"
                                    DisplayModalPopupID="btnDeleteGroup_modalpopupextender" TargetControlID="btnDeleteGroup" />
                                <AjaxToolKit:ModalPopupExtender ID="btnDeleteGroup_modalpopupextender" runat="server"
                                    BackgroundCssClass="modalBackground" CancelControlID="GCancel" OkControlID="GButtonOk"
                                    PopupControlID="PNL1" TargetControlID="btnDeleteGroup" />
                                <br />
                                <asp:Panel ID="PNL1" runat="server" Style="display: none; width: 200px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
                                    Are you sure you want to delete?
 <br />
                                    <br />
                                    <div style="text-align: right;">
                                        <asp:Button ID="GButtonOk" runat="server" Text="OK" />
                                        <asp:Button ID="GCancel" runat="server" Text="Cancel" />
                                    </div>
                                </asp:Panel>

                            </div>
                        </div>

                    </div>--%>
                        <!-- end tab-pane -->
                    </div>
                </div>

                <div class="form-group row m-b-0">

                                <div class="col-md-12 col-sm-8 text-center">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A"
                                        OnClick="btnAdd_Click" ToolTip="Add" />
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update"
                                        ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
                                        OnClick="btnDelete_Click" ToolTip="Delete" />
                                    <AjaxToolKit:ConfirmButtonExtender ID="btnDelete_confirmbuttonextender" runat="server"
                                        DisplayModalPopupID="btnDelete_modalpopupextender" TargetControlID="btnDelete" />
                                    <AjaxToolKit:ModalPopupExtender ID="btnDelete_modalpopupextender" runat="server"
                                        BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" OkControlID="ButtonOk"
                                        PopupControlID="PNL" TargetControlID="btnDelete" />
                                    <br />
                                    <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                        Are you sure you want to delete?
                                        <br />
                                        <br />
                                        <div style="text-align: right;">
                                            <asp:Button ID="ButtonOk" runat="server" Text="OK" />
                                            <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>

            </div>
            <!-- end tab-content -->
        </div>
        <!-- end col-6 -->
    </div>
    <!-- end row -->

    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
            CssClass="form-control">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False" DataKeyNames="nItemDetailsID" Width="100%" AllowPaging="true"
            AllowSorting="True" PageSize="25" EmptyDataText="No Records to display" OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nItemDetailsID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nItemDetailsID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sitemName" HeaderText="itemName" />
                <asp:BoundField DataField="sItemCategory" HeaderText="Item Category" />
                <asp:BoundField DataField="sItemSubCategory" HeaderText="ItemSub Category" />
                <asp:BoundField DataField="sItemType" HeaderText="ItemTypeID" />
                <asp:BoundField DataField="sItemMark" HeaderText="ItemMark" />
                <asp:BoundField DataField="nSalePrice" HeaderText="SalePrice" />
                <asp:TemplateField HeaderText="tExpiry">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtExpiry").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit/Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                        </asp:LinkButton>
                        <asp:LinkButton ID="btngdDelete" runat="server" OnClick="btngdDelete_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                        </asp:LinkButton>
                        <AjaxToolKit:ConfirmButtonExtender ID="btngdDelete_confirmbuttonextender" runat="server"
                            DisplayModalPopupID="btngdDelete_modalpopupextender" TargetControlID="btngdDelete" />
                        <AjaxToolKit:ModalPopupExtender ID="btngdDelete_modalpopupextender" runat="server"
                            BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel0" OkControlID="ButtonOk0"
                            PopupControlID="PNL0" TargetControlID="btngdDelete" />
                        <br />
                        <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                            Are you sure you want to delete?
                            <br />
                            <br />
                            <div style="text-align: right;">
                                <asp:Button ID="ButtonOk0" runat="server" Text="OK" />
                                <asp:Button ID="ButtonCancel0" runat="server" Text="Cancel" />
                            </div>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
