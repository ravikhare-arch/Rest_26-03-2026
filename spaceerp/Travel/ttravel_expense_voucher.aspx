<%@ Page Title="travel_expense_voucher" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="ttravel_expense_voucher.aspx.cs" Inherits="Transcation_travel_expense_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
   <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .row {
    margin-right: 0px;
    margin-left: 0px;
}
        .table-hover th{            
    border-top: 1px solid #018fd4 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <asp:Label ID="lblmsg" runat="server" style="display:none"></asp:Label>
     <div class="container-fluid nopad"> 
           <!-- begin row -->
            <div class="row">
                <!-- begin col-6 -->
                <div class="col-lg-12 nopad">
                    <!-- begin panel -->
                    <div class="panel panel-inverse">
                        <!-- begin panel-heading -->
                        <div class="panel-heading">
                            <div class="panel-heading-btn pull-left">
            <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
            <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
        </div>
                            <div class="panel-heading-btn">
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                            </div>
                            <h4 class="panel-title text-center">Expense Voucher</h4>
                        </div>
                        <!-- end panel-heading -->
                        <!-- begin panel-body -->
                        <div class="panel-body">       
                            <asp:Panel class="tbl" ID="tblmain" runat="server">          
                            <div>
                                <div class="form-group row">
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Voucher No  * :</label>
                                        <asp:UpdatePanel ID="UP1" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txtVoucherNo" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtVoucherNo" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Voucher Type * :</label>
                                        <asp:DropDownList ID="ddlVoucherTypeID" runat="server" CssClass="form-control js-example-placeholder-single">

                                            <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Expense" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="General" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="ddlVoucherTypeID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                    </div>

                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Cash Account  * :</label>
                                        <asp:DropDownList ID="ddlCashAccountID" runat="server" CssClass="form-control js-example-placeholder-single">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlCashAccountID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Status  * :</label>
                                        <asp:DropDownList ID="ddlStatusID" runat="server" CssClass="form-control js-example-placeholder-single">
                                            <asp:ListItem Text="Select Status" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="New" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Pending" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Confimed" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlStatusID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Voucher Date * :</label>
                                        <asp:TextBox ID="txtdtVoucher" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/mm/yyyy" AutoPostBack="true" OnTextChanged="txtdtVoucher_TextChanged"></asp:TextBox>
                                        <%-- <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="Img5" TargetControlID="txtdtVoucher" PopupPosition="TopLeft" />--%>
                                        <AjaxToolKit:MaskedEditExtender ID="MEE5" runat="server"
                                            TargetControlID="txtdtVoucher" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                        <asp:RegularExpressionValidator ID="REV5" ControlToValidate="txtdtVoucher"
                                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                        </asp:RegularExpressionValidator>
                                        <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtdtVoucher" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <%-- <div class="col-md-1 col-sm-1" style="padding-top: 30px; padding-left: 0px">
                                    <asp:ImageButton ID="Img5" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                                        Width="32" Height="32" />

                                </div>--%>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Location * :</label>

                                        <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="ddlLocationID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Posted by * :</label>

                                        <asp:TextBox ID="txtPostedby" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="txtPostedby" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Amended by * :</label>
                                        <asp:TextBox ID="txtAmbedby" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmbedby" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <%--<div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12" style="text-align: center; padding: 10px;">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Save"
                                    ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update"  />
                            </div>
                        </div>--%>
                            <div>
                                <div class="form-group row m-b-15">
                                    <div class="col-md-2 col-sm-2">
                                        <label class="col-form-label">Driver Name * :</label>
                                        <asp:DropDownList ID="ddlDriverID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlDriverID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 col-sm-2" style="padding: 0px;">
                                        <label class="col-form-label">Vehicle No * :</label>
                                        <asp:DropDownList ID="ddlVehicleID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlVehicleID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Expense Account * :</label>
                                        <asp:DropDownList ID="ddlExpenseAccountID" runat="server" CssClass="form-control js-example-placeholder-single">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlExpenseAccountID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label">Expense Category  * :</label>
                                        <asp:DropDownList ID="ddlExpenseCatID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlExpenseCatID" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label class="col-form-label">Amount  * :</label>
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV6" runat="server" ControlToValidate="txtAmount"
                                            SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                            ValidationGroup="B"></asp:RegularExpressionValidator>
                                        <AjaxToolKit:FilteredTextBoxExtender ID="FTBE6" runat="server"
                                            Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                            ValidChars=".-">
                                        </AjaxToolKit:FilteredTextBoxExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAmount" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>

                                </div>
                                <div class="form-group row m-b-15">
                                    <div class="col-md-6 col-sm-6">
                                        <label class="col-form-label">Description  * :</label>
                                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDescription" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6 col-sm-6">
                                        <label class="col-form-label">Remarks</label>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Fill out this field." Display="Dynamic" SetFocusOnError="True" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row m-b-15">
                                <div class="col-md-12 col-sm-12" style="text-align: center; padding: 10px;">
                                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A"
                                        OnClick="btnAdd_Click" ToolTip="Add" />

                                    <asp:Button ID="btnAddDet" runat="server" CssClass="btn btnspl btn-primary" Text="Add" ValidationGroup="B" OnClick="btnAddDet_Click" ToolTip="Add" />
                                    <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="B" OnClick="btnUpdateDet_Click" ToolTip="Update" />

                                    <%-- <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete"
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
                                </asp:Panel>--%>
                                </div>
                            </div>

                            <asp:Panel class="tbl table-responsive" ID="tblGridDet" runat="server" Style="margin-top: 20px;">

                                <asp:Label ID="lblpgsDet" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSizeDet" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSizeDet_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView2" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nTravelExpenseVoucherDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView2_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nTravelExpenseVoucherDetID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDetID" runat="server" Text='<%# Eval("nTravelExpenseVoucherDetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sDriverName" HeaderText="Driver Name" />
                                        <asp:BoundField DataField="sVehicleNo" HeaderText="Vehicle No" />
                                        <asp:BoundField DataField="sExpenseCat" HeaderText="Expense Category" />
                                        <asp:BoundField DataField="sDescription" HeaderText="Description" />
                                        <asp:BoundField DataField="nAmount" HeaderText="Debit" />

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
                            </asp:Panel>

                            <div class="form-group row m-b-15">
                                <div class="col-md-12 col-sm-12" style="text-align: right; padding: 10px 50px 0 0;">
                                    <asp:Label ID="lblTotAmount" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
                                </div>
                            </div>                 
        </asp:Panel>
        <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
            
            <div class="col-md-12 ml-auto mr-auto" >
                                        <div class="clearfix form-group">  
                                            <div class="col-md-3">
                                    <label>Agency Name</label>
                                    <asp:TextBox ID="txtAName" placeHolder="Agency Name" AutoComplete="off" CssClass="form-control" runat="server" ></asp:TextBox>

                                </div>                                                                                 
                                            <div class="col-md-3">
                                                <label for="form-1-3" class="col-form-label">Agent ID</label>
                                                     <asp:TextBox ID="txtagentname" placeholder="Agent Name" runat="server" CssClass="search_filter form-control" autocomplete="off"></asp:TextBox>
                               
                                            </div>
                                            <div class="col-md-2">
                                                <label for="form-1-3" class="col-form-label">From Date</label>
                                                <div class="timepicker-input" >
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
                                            </div>
                                             <div class="col-md-2">
                                                <label for="form-1-3" class="col-form-label">To Date</label>                                  
                                    <div class="timepicker-input">
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
                                            </div>
                                            <div class="col-md-2">
                                                <label>&nbsp;</label>
                                                 <input type="button" name="BtnHotelSearch" value="Search" id="BtnSearch" class="btn btn-primary form-control no-mrg-btm"  />
                                                 
                                            </div>
                                        </div>
                                        
                                    </div>
            <div class=" col-md-12 text-center">
                    <br />
                  
              <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>
                       <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Export To Excel" />
               <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF"  />
               <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false"/>
                   <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />            
             
                                          </div>
            <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            </asp:DropDownList>
            <div>&nbsp;</div>
            <asp:GridView ID="GridView1" CssClass="table table-hover m-b-0 text-inverse" runat="server"
                AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nTravelExpenseVoucherID"
                Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="nTravelExpenseVoucherID" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTravelExpenseVoucherID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sVoucherNo" HeaderText="VoucherNo" />
                    <asp:TemplateField HeaderText="Voucher Date">
                        <ItemTemplate>
                            <%#validation.TextToDate(Eval("dtVoucher").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="sPostedby" HeaderText="Postedby" />
                    <asp:BoundField DataField="sAmbedby" HeaderText="Ambedby" />
                    <asp:TemplateField HeaderText="Edit/Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                            </asp:LinkButton>
                            <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                           <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span>
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
    </div>
                        </div>
                    </div>
                </div>
         </div>
</asp:Content>
