<%@ Page Title="quotation" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tquotation.aspx.cs" Inherits="Transcation_quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    
    <link href="../css/CustomModal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <!-- begin row -->
    <div class="row">
        <!-- begin col-6 -->
        <div class="col-lg-12">
            <!-- begin panel -->
            <div class="panel panel-inverse">
                <!-- begin panel-heading -->
                <div class="panel-heading">
                    <div class="panel-heading-btn pull-left">
                        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Quotation Details</h4>
                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel class="tbl" ID="tblmain" runat="server">
                        <div>
                            <asp:UpdatePanel ID="UP1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group row m-b-0">
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Quotation No. * :</label>
                                            <asp:TextBox ID="txtQuotationNo" CssClass="form-control" runat="server" Width="100%" Enabled="false" required=""> </asp:TextBox>


                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 100">
                                            <label class="col-form-label" for="fullname">Quotation Date :</label>
                                            <asp:TextBox ID="dtQuotation" CssClass="form-control" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="dtQuotation_TextChanged"></asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                                TargetControlID="dtQuotation" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="dtQuotation"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>

                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="dtQuotation" TargetControlID="dtQuotation" PopupPosition="BottomLeft" />


                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index: 100">
                                            <label class="col-form-label" for="fullname">Expiry Date :</label>
                                            <asp:TextBox ID="dtQuotationExpiry" CssClass="form-control" runat="server" Width="100%" required placeholder="dd/mm/yyyy"> </asp:TextBox>
                                            <AjaxToolKit:MaskedEditExtender ID="MEE5" runat="server"
                                                TargetControlID="dtQuotationExpiry" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV5" ControlToValidate="dtQuotationExpiry"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="dtQuotationExpiry" TargetControlID="dtQuotationExpiry" PopupPosition="BottomLeft" />

                                        </div>
                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Quotation Type  :</label>
                                            <asp:DropDownList Width="100%" CssClass="form-control" ID="ddlType" runat="server">
                                                <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddlType" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <%--    <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Status  :</label>
                                            <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" required></asp:TextBox>
                                        </div>--%>

                                        <div class="col-md-2 col-sm-4">
                                            <label class="col-form-label" for="fullname">Customer Name  :</label>
                                            <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomerName_SelectedIndexChanged"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCustomerName" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>


                                        </div>

                                        <div class="col-md-2  col-sm-4">
                                            <label class="col-form-label" for="fullname">Balance :</label>
                                            <asp:TextBox ID="txtBalance" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                        </div>

                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div class="form-group row m-b-0">
                                        <div class="col-md-2 col-sm-4">
                                            <label class="col-form-label" for="fullname">Location  :</label>
                                            <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-1 col-sm-1 mt-30">
                                            <label class="col-form-label" for="fullname">Attantion</label>
                                            <asp:CheckBox ID="chkAttantion" CssClass="form-control" runat="server"  OnCheckedChanged="chkAttantion_CheckedChanged" AutoPostBack="true" Text="Attn" />

                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">Attantion</label>
                                            <asp:TextBox ID="txtAttention" CssClass="form-control" runat="server" Width="100%"  Enabled="false"></asp:TextBox>



                                        </div>

                                        <div class="col-md-1 col-sm-1 p-t-40">
                                            <label class="col-form-label" for="fullname">Note</label>
                                            <asp:CheckBox ID="chkNote" CssClass="form-control" runat="server"  OnCheckedChanged="chkNote_CheckedChanged" AutoPostBack="true" Text="Note" />


                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">Note</label>
                                            <asp:TextBox ID="txtNote" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>



                                        </div>
                                        <div class="col-md-4 col-sm-4">
                                            <label class="col-form-label" for="fullname">Remarks  :</label>
                                            <asp:TextBox ID="txtRemarks" Text="Remarks" CssClass="form-control" runat="server" Width="100%" TextMode="SingleLine"></asp:TextBox>


                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>



                        <asp:Panel class="tbl" ID="tblDet" runat="server">
                            <div>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group row m-b-0">

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Item Name * :</label>

                                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="True" OnSelectedIndexChanged="ddlItem_SelectedIndexChanged"></asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlItem" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Unit   :</label>
                                                <asp:DropDownList Width="100%" CssClass="form-control" ID="ddlUnit" runat="server" Enabled="false"></asp:DropDownList>
                                            </div>

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Current  Stock :</label>
                                                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" Width="100%" onkeypress="return fun_AllowOnlyAmountAndDot(this.id);" Enabled="false"></asp:TextBox>

                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Quantity :</label>
                                                <asp:TextBox ID="txtQty" CssClass="form-control" runat="server" Width="100%" OnTextChanged="txtQty_TextChanged" AutoPostBack="true" required></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtQty"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtQty"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                                <asp:CompareValidator ID="RangeValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Stock Not Available" ValidationGroup="A" ControlToValidate="txtQty" Type="Integer" ControlToCompare="txtStock"
                                                    Operator="LessThanEqual"></asp:CompareValidator>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Unit Price :</label>
                                                <asp:TextBox ID="txtUnitPrice" CssClass="form-control" runat="server" Width="100%" OnTextChanged="txtUnitPrice_TextChanged" AutoPostBack="true" required></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUnitPrice"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtUnitPrice"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Total Price :</label>
                                                <asp:TextBox ID="txtTotalPrice" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtTotalPrice"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTotalPrice"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <div class="form-group row m-b-15">

                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Name * :</label>
                                                <asp:DropDownList ID="ddlTaxName" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlTaxName_SelectedIndexChanged"></asp:DropDownList>
                                            </div>

                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Type   :</label>
                                                <asp:DropDownList Width="100%" CssClass="form-control" ID="ddlTaxType" Enabled="false" runat="server">
                                                    <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Amount"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="% Percentage"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Tax Value :</label>
                                                <asp:TextBox ID="txtTaxValue" CssClass="form-control" runat="server" Width="100%" Text="0" Enabled="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtTaxValue"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTaxValue"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-3 col-sm-3">
                                                <label class="col-form-label" for="fullname">Taxable Amount :</label>
                                                <asp:TextBox ID="txtTaxableAmount" CssClass="form-control" runat="server" Width="100%" Text="0" Enabled="true"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtTaxableAmount"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtTaxableAmount"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>

                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group row m-b-0">
                                    <div class="col-md-12 col-sm-12" style="text-align: center">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />

                                        <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" />
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
                                        <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />
                                        <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />
                                        <asp:Button ID="btnDeleteDet" runat="server" CssClass="btn btn-primary" Text="Delete" ValidationGroup="A" OnClick="btnDeleteDet_Click" ToolTip="Delete" />

                                        <AjaxToolKit:ConfirmButtonExtender ID="btnDeleteDet_ConfirmButtonExtender" runat="server"
                                            DisplayModalPopupID="btnDeleteDet_modalpopupextender" TargetControlID="btnDeleteDet" />
                                        <AjaxToolKit:ModalPopupExtender ID="btnDeleteDet_modalpopupextender" runat="server"
                                            BackgroundCssClass="modalBackground" CancelControlID="ButtonCancelDet" OkControlID="ButtonOkD"
                                            PopupControlID="PNL1" TargetControlID="btnDeleteDet" />
                                        <br />
                                        <asp:Panel ID="PNL1" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                            Are you sure you want to delete?
 <br />
                                            <br />
                                            <div style="text-align: right;">
                                                <asp:Button ID="ButtonOkD" runat="server" Text="OK" />
                                                <asp:Button ID="ButtonCancelDet" runat="server" Text="Cancel" />
                                            </div>
                                        </asp:Panel>

                                    </div>
                                </div>


                            </div>


                        </asp:Panel>
                        <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server">

                            <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                            <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:GridView ID="GridView2" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                DataKeyNames="nQuotationDetID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                OnPageIndexChanging="GridView2_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="nQuotationDetID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nQuotationDetID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="sItemName" HeaderText="Item Name" />
                                    <asp:BoundField DataField="sItemUnit" HeaderText="Unit" />
                                    <asp:BoundField DataField="nQuantity" HeaderText="Quantity" />
                                    <asp:BoundField DataField="nUnitPrice" HeaderText="Unit Price" />
                                    <asp:BoundField DataField="sTaxName" HeaderText="Tax Name" />
                                    <asp:BoundField DataField="nTaxableAmount" HeaderText="Tax Amount" />
                                    <asp:BoundField DataField="nTotalPrice" HeaderText="Total Price" />
                                    <asp:TemplateField HeaderText="Edit/Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btngdEditDet" runat="server" OnClick="btngdEditDet_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btngdDeleteDet" runat="server" OnClick="btngdDeleteDet_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                            </asp:LinkButton>
                                            <AjaxToolKit:ConfirmButtonExtender ID="btngdDeleteDet_confirmbuttonextender" runat="server"
                                                DisplayModalPopupID="btngdDeleteDet_modalpopupextender" TargetControlID="btngdDeleteDet" />
                                            <AjaxToolKit:ModalPopupExtender ID="btngdDeleteDet_modalpopupextender" runat="server"
                                                BackgroundCssClass="modalBackground" CancelControlID="ButtonCancelDet" OkControlID="ButtonOkDet"
                                                PopupControlID="PNL0" TargetControlID="btngdDeleteDet" />
                                            <br />
                                            <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;top: 0px !important">
                                                Are you sure you want to delete?
 <br />
                                                <br />
                                                <div style="text-align: right;">
                                                    <asp:Button ID="ButtonOkDet" runat="server" Text="OK" />
                                                    <asp:Button ID="ButtonCancelDet" runat="server" Text="Cancel" />
                                                </div>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </asp:Panel>
                        <asp:Panel ID="tblbootomPage" runat="server">
                            <div style="border: 1px solid #fbe2bf; padding: 10px;">
                                <asp:UpdatePanel ID="up10" runat="server">
                                    <ContentTemplate>

                                        <div class="form-group row m-b-15">
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Sub Total :</label>
                                                <asp:TextBox ID="txtSubTot" runat="server" Width="100%" Text="0" Enabled="false"></asp:TextBox>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Shipping & Pack Cost :</label>
                                                <asp:TextBox ID="txtShippimngCost" runat="server" Text="0" CssClass="form-control" Enabled="true" AutoPostBack="True" OnTextChanged="txtShippimngCost_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtShippimngCost"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtShippimngCost"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>


                                            </div>


                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Other Charges :</label>
                                                <asp:TextBox ID="txtOtherCharges" runat="server" Width="100%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtOtherCharges_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtOtherCharges"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtOtherCharges"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-1 col-sm-1">
                                                <label class="col-form-label" for="fullname">Discount :</label>
                                                <asp:TextBox ID="txtDiscount" runat="server" Width="100%" Text="0" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtDiscount"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtDiscount"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Tax :</label>
                                                <asp:TextBox ID="txtTaxTotal" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                            </div>
                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Grand Total</label>
                                                <asp:TextBox ID="txtGrandTot" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                            </div>
                                            <div class="col-md-1 col-sm-1 text-center m-t-30">

                                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="B" OnClick="btnUpdate_Click" ToolTip="Save" />

                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="form-group row m-b-15">
                                </div>

                            </div>
                        </asp:Panel>
                    </asp:Panel>
                    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                        <div class="form-group row m-b-20">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Customer Name  :</label>
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlCustSearch" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Quotation No.  :</label>
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlQuotation" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">
                                <label class="col-form-label" for="fullname">From Date :</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="img8" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtFroms" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtdtFroms"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="img8" TargetControlID="txtdtFroms" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txtdtFroms" TargetControlID="txtdtFroms" PopupPosition="BottomLeft" />

                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                        TargetControlID="txtdtFroms" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-2" style="z-index: 9999;">
                                <label class="col-form-label" for="fullname">To Date :</label>
                                <div class="input-group">
                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="img6" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtTo" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtdtTo"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="img6" TargetControlID="txtdtTo" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txtdtTo" TargetControlID="txtdtTo" PopupPosition="BottomLeft" />
                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                        TargetControlID="txtdtTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="fullname">Search</label><br />
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" ToolTip="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="nQuotationID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                            OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="nQuotationID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nQuotationID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="sQuotationNo" HeaderText="PO No." />
                                <asp:TemplateField HeaderText="QuotationNo Date">
                                    <ItemTemplate>
                                        <%#validation.TextToDate(Eval("dtQuotation").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Expiry Date">
                                    <ItemTemplate>
                                        <%#validation.TextToDate(Eval("dtQuotationExpiry").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="sAccountTitle" HeaderText="Customer Name" />
                                <asp:TemplateField HeaderText="Edit/Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                           <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span> </asp:LinkButton>
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

                </div>
                <!-- end panel-body -->

            </div>
            <!-- end panel -->
        </div>
        <!-- end col-6 -->

    </div>
    <!-- end row -->





</asp:Content>
