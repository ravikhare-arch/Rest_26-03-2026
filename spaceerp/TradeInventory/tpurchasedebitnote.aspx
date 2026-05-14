<%@ Page Title="Purchase Debit Note" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tpurchasedebitnote.aspx.cs" Inherits="Transcation_tpurchasedebitnote" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
     
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel class="tbl" ID="tblmain" runat="server">
        <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading">
                        <div class="panel-heading-btn pull-left">
                            <asp:LinkButton ID="lnkAdd" runat="server" CausesValidation="false" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                            <asp:LinkButton ID="lnkList" runat="server" CausesValidation="false" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                        </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>

                        <h4 class="panel-title text-center">Purchase Debit Notes</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">  
                                    <div class="form-group row m-b-0">

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">GST Type * :</label>


                                            <asp:TextBox CssClass="form-control" ID="txtgsttype" runat="server" Width="100%" required> </asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgsttype" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ></asp:RequiredFieldValidator>

                                        </div>
                                         <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Vendor  * :
                                            </label>

                                            <asp:DropDownList ID="ddlAgentID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="ddlAgentID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Branch   * :
                                            </label>

                                            <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ></asp:RequiredFieldValidator>

                                        </div>
                                        <div class="col-md-2 col-sm-2" style="z-index:100">
                                            <label class="col-form-label" for="fullname"> Date :</label>
                                            <div>
                                                <asp:TextBox CssClass="form-control" ID="txttSalesOrder" runat="server" Width="100%" ></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txttSalesOrder"
                                                   Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttSalesOrder" TargetControlID="txttSalesOrder" PopupPosition="BottomLeft" />

                                                <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                                    TargetControlID="txttSalesOrder" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            </div>
                                        </div>

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Reference No.  :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtReferenceNo" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                         <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Ref Date :</label>


                                            <asp:TextBox CssClass="form-control" ID="txttDelivery" runat="server" Width="100%"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="REV5" ControlToValidate="txttDelivery"
                                                 Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>

                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txttDelivery" TargetControlID="txttDelivery" PopupPosition="TopLeft" />

                                            <AjaxToolKit:MaskedEditExtender ID="MEE5" runat="server"
                                                TargetControlID="txttDelivery" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />

                                        </div>
                                       
                                    </div>
                                
                            
                                    <div class="form-group row m-b-0">
                                         <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                Agent  * :
                                            </label>

                                            <asp:DropDownList ID="ddlClient" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlClient" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">Email :</label>
                                             <asp:TextBox CssClass="form-control" ID="txtemail" runat="server" Width="100%" ></asp:TextBox>
                                            
                                        </div>
                                        
                                        <div class="col-md-2 col-sm-1">
                                            <label class="col-form-label" for="fullname">Against Bill :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtagainstbill" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                      <div class="col-md-2 col-sm-2" style="z-index:100">
                                            <label class="col-form-label" for="fullname">Against Bill Date :</label>
                                            <div>

                                                <asp:TextBox CssClass="form-control" ID="txtagainstbilldate" runat="server" Width="100%" ></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtagainstbilldate"
                                                   Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="TextBox3" TargetControlID="txtagainstbilldate" PopupPosition="BottomLeft" />

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                                    TargetControlID="txtagainstbilldate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            </div>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">Currency :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtBalance" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                        <div class="col-md-2 col-sm-1">
                                            <label class="col-form-label" for="fullname">Conversion Rate :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtconversionrate" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                    </div>
                            <div class="form-group row m-b-0">
                                <div class="col-md-2 col-sm-1">
                                            <label class="col-form-label" for="fullname">Billing Address :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtbillingaddress" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                <div class="col-md-2 col-sm-1">
                                            <label class="col-form-label" for="fullname">Shipping Address :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtshippingaddress" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">Payment Terms :</label>
                                             <asp:TextBox CssClass="form-control" ID="txtpaymentterms" runat="server" Width="100%" ></asp:TextBox>
                                            
                                        </div>
                                        
                                        
                                      <div class="col-md-2 col-sm-2" style="z-index:100">
                                            <label class="col-form-label" for="fullname">Due Date :</label>
                                            <div>

                                                <asp:TextBox CssClass="form-control" ID="txtduedate" runat="server" Width="100%" ></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtduedate"
                                                   Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender8" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="TextBox3" TargetControlID="txtduedate" PopupPosition="BottomLeft" />

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender4" runat="server"
                                                    TargetControlID="txtduedate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            </div>
                                        </div>
                                        <div class="col-md-2 col-sm-1">
                                            <label class="col-form-label" for="fullname">DN/CN Return Reason :</label>
                                            <asp:TextBox CssClass="form-control" ID="txtreturnreason" runat="server" Width="100%" ></asp:TextBox>

                                        </div>
                                        
                                    </div>
                               
                            <div class="form-group row m-b-0" runat="server" visible="false">
                                <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                                <div class="col-md-8 col-sm-8">

                                    
                                    <asp:Button ID="btnDelete" Visible="false" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" />
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

                        

                        <asp:Panel class="tbl" ID="tblDet" runat="server">
                            <!-- begin row -->

                            <div>                               
                                       <%-- <div class="form-group row m-b-0">

                                            <div class="col-md-2 col-sm-2">
                                                <label class="col-form-label" for="fullname">Item  * :</label>
                                                <asp:DropDownList ID="ddlItem" runat="server" CssClass="form-control js-example-placeholder-single" ></asp:DropDownList>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlItem" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </div>

                                          
                                        </div>--%>
                                    <div class="form-group row m-b-10">
                                                        <fieldset class="the-fieldset">
                                                           <div class="form-group row">

                                                                <div class="col-md-1 col-sm-1">
                                                                    <label class="col-form-label" for="fullname">
                                                                        Tax
                                                                    </label>
                                                                    <asp:CheckBox ID="chkClntTax" runat="server" Width="100%" ></asp:CheckBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        CGST
                                                                    </label>
                                                                    <asp:TextBox ID="txtClntCgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>

                                                                <div class="col-md-4 col-sm-4">
                                                                    <label class="col-form-label" for="fullname">
                                                                        SGST
                                                                    </label>
                                                                    <asp:TextBox ID="txtClntSgst" CssClass="form-control" runat="server" Width="95%" Text="0" Enabled="false"></asp:TextBox>

                                                                </div>
                                                                <div class="col-md-3 col-sm-3">
                                                                    <label class="col-form-label" for="fullname">
                                                                        IGST
                                                                    </label>
                                                                    <asp:TextBox ID="txtClntIgst" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                                </div>
                                                            </div>
                                                        </fieldset>
                                                    </div>
                                
                                <div class="form-group row m-b-0">
                                    <div class="col-md-12 col-sm-12" style="text-align: center;">
                                        <div>&nbsp;</div>
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" OnClick="btnAdd_Click" ToolTip="Add" />
                                       <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-primary" Text="Update"  OnClick="btnUpdate_Click" ToolTip="Update" />
                                        <%--<asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdateDet_Click" ToolTip="Update" />--%>
                                        <%--<asp:Button ID="btnDeleteDet" runat="server" CssClass="btn btn-primary" Text="Delete" ValidationGroup="A" OnClick="btnDeleteDet_Click" ToolTip="Delete" />--%>

                           

                                    </div>
                                </div>
                            </div>

                           <%-- <div class="form-group row m-b-0">
                                <div class="col-md-12 col-sm-12">
                                    <br />
                                    <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server">

                                        <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                        <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:GridView ID="GridView2" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                            DataKeyNames="nSalesOrderDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                            OnPageIndexChanging="GridView2_PageIndexChanging">
                                            <Columns>
                                                <asp:TemplateField HeaderText="nSalesOrderDetID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nSalesOrderDetID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="sItemName" HeaderText="Item Name" />
                                                <asp:BoundField DataField="sItemUnit" HeaderText="Unit" />
                                                <asp:BoundField DataField="nQuantity" HeaderText="Quantity" />
                                                <asp:BoundField DataField="nUnitPrice" HeaderText="Unit Price" />
                                                <asp:BoundField DataField="nTotalPrice" HeaderText="Total Price" />
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
                                                        <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
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
                                        <asp:Panel class="tbl table-responsive" Visible="false" ID="tblGridTax" runat="server">



                                            <asp:GridView ID="gridTax" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="nTaxTemplateDetID" Width="100%" AllowSorting="True">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="nTaxTemplateDetID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIDDet" runat="server" Text='<%# Eval("nTaxTemplateDetID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lblTaxName" runat="server" Text='<%# Eval("sTaxName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <% if (Eval("nTaxTypeID").ToString() == "2")
                                                               { %>
                                                            <asp:TextBox CssClass="form-control" ID="txtTaxPer" runat="server" Text='<%# Eval("nTaxValue") %>'></asp:TextBox>
                                                            <%
                                                               }
                                                            %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>

                                                            <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" Text='<%# Eval("nAmount") %>'></asp:TextBox>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                            </div>--%>
                           <%-- <asp:Panel ID="tblbootomPage" runat="server">
                                <div style=" padding: 10px;">
                                    <asp:UpdatePanel ID="up10" runat="server">
                                        <ContentTemplate>

                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Sub Total :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtSubTot" runat="server" Width="100%" Text="0" Enabled="false"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Shipping & Pack Cost :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtShippimngCost" runat="server" Text="0" Width="100%" Enabled="true" AutoPostBack="True" OnTextChanged="txtShippimngCost_TextChanged"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control" ID="txtOtherCharges" runat="server" Width="100%" Text="0" Enabled="true" AutoPostBack="True" OnTextChanged="txtOtherCharges_TextChanged"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control" ID="txtDiscount" runat="server" Width="100%" Text="0" AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
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
                                                    <asp:TextBox CssClass="form-control" ID="txtTaxTotal" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="fullname">Grand Total</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtGrandTot" runat="server" Width="100%" Enabled="false" Text="0"></asp:TextBox>

                                                </div>
                                                <div class="col-md-1 col-sm-1 text-center m-t-30">

                                                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Save" />

                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group row m-b-15">
                                    </div>

                                </div>
                            </asp:Panel>--%>


                        </asp:Panel>



                    </div>
                    <!-- end panel-body -->

                </div>
                <!-- end panel -->
            </div>
        </div>

        <!-- end col-6 -->


        <!-- end row -->
    </asp:Panel>
 
</asp:Content>
