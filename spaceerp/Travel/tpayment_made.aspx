<%@ Page Title="Supplier Payment Voucher" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tpayment_made.aspx.cs" Inherits="Transcation_payment_voucher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
     
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

                    <h4 class="panel-title text-center">SUPPLIER PAYMENT VOUCHER </h4>
                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel CssClass="tbl" ID="tblmain" runat="server">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <div>
                                    <div class="form-group row m-b-10">

                                        <div class="col-md-3 col-sm-3 ">
                                            <label class="col-form-label" for="email">Supplier :</label>
                                            <asp:DropDownList ID="ddlSupplier" runat="server" Width="100%" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlSupplier_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSupplier" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="email">Pay For :</label>
                                            <asp:DropDownList ID="ddlPayFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlPayFor_SelectedIndexChanged">
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="Visa" Text="Visa"></asp:ListItem>
                                                <asp:ListItem Value="AirTicket" Text="Air Ticket"></asp:ListItem>
                                                <asp:ListItem Value="GroupAirTicket" Text="Group Air Ticket"></asp:ListItem>
                                                <asp:ListItem Value="Hotels" Text="Hotels"></asp:ListItem>
                                                <asp:ListItem Value="Excursion" Text="Excursion"></asp:ListItem>
                                                <asp:ListItem Value="Mofa" Text="Mofa"></asp:ListItem>
                                                <asp:ListItem Value="GroupMofa" Text="Group Mofa"></asp:ListItem>
                                                <asp:ListItem Value="Recruitement" Text="Recruitement"></asp:ListItem>
                                                <asp:ListItem Value="Insurance" Text="Insurance"></asp:ListItem>
                                                <asp:ListItem Value="Train" Text="Train Tickets"></asp:ListItem>
                                                <asp:ListItem Value="Bus" Text="Bus Tickets"></asp:ListItem>
                                                <asp:ListItem Value="Car" Text="Car Booking"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlPayFor" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label" for="email">Voucher No * :</label>
                                            <asp:TextBox ID="txtPaymentVoucherNo" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtPaymentVoucherNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-2">
                                            <label class="col-form-label" for="email">Voucher Date * :</label>


                                            <asp:TextBox ID="txtdtPaymentVoucher" runat="server" CssClass="datepicker" AutoCompleteType="None" Width="100%" OnTextChanged="txtdtPaymentVoucher_TextChanged" AutoPostBack="true" placeholder="DD/MM/YYYY"></asp:TextBox>
                                            <%--<asp:TextBox ID="txtdtPaymentVoucher" runat="server" Width="100%" CssClass="form-control" OnTextChanged="txtdtPaymentVoucher_TextChanged" AutoPostBack="true" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                  
                                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                        PopupButtonID="txtdtPaymentVoucher" TargetControlID="txtdtPaymentVoucher" PopupPosition="Left" />--%>
                                            <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                                TargetControlID="txtdtPaymentVoucher" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtPaymentVoucher"
                                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtdtPaymentVoucher" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="form-group row m-b-0">
                                        

                                        <div class="col-md-3 col-sm-3 ">
                                            <label class="col-form-label" for="email">Payment Mode * :</label>
                                            <asp:DropDownList ID="ddlPaymentMode" runat="server" Width="100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                                <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Cash Payment" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Bank Payment" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlPaymentMode" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Payment Account </label>
                                            <asp:DropDownList ID="ddlPayAccount" runat="server" CssClass="form-control" Width="100%" AutoPostBack="True"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPayAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3 col-sm-2">
                                            <label class="col-form-label">Amount</label>
                                            <asp:Label ID="lblAmount" runat="server" Visible="false"></asp:Label>
                                            <asp:TextBox ID="txtAmount" CssClass="form-control" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>

                                            <asp:RegularExpressionValidator ID="REV8" runat="server" ControlToValidate="txtAmount"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE8" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-3 col-sm-3">
                                            <label class="col-form-label">Remarks</label>
                                            <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                        </div>
                                    </div>



                                </div>
                                
                                <asp:Panel CssClass="tbl" ID="tblGridM" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <asp:GridView ID="GridView3" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="InvoiceID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                                OnPageIndexChanging="GridView3_PageIndexChanging" OnRowDataBound="GridView3_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="InvoiceID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblInvID" runat="server" Text='<%# Eval("InvoiceID") %>'></asp:Label>

                                                            <asp:Label ID="lblInvNo" runat="server" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                                                            <asp:Label ID="lblInvDate" runat="server" Text='<%# Eval("InvoiceDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select Invoice">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkInv" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Invoice Date">
                                                        <ItemTemplate>
                                                            <%#validation.TextToDate(Eval("InvoiceDate").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="InvoiceNo" HeaderText="Invoice No" />
                                                    <asp:BoundField DataField="nBuyingRate" HeaderText="Amount" />
                                                    <asp:BoundField DataField="nBalance" HeaderText="Due Amount" />
                                                    <asp:TemplateField HeaderText="Payment Value" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtBalance" Text='<%# Eval("nBalance") %>' runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Payment Value">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPaymentValue" Text="0" runat="server" AutoPostBack="true" OnTextChanged="txtPaymentValue_TextChanged"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel CssClass="tbl" ID="tblGridDet" runat="server">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12">
                                            <asp:GridView ID="GridView2" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                                DataKeyNames="nPaymentmadeDetID" Width="100%" AllowPaging="false" AllowSorting="True" EmptyDataText="No Records to display"
                                                OnRowDataBound="GridView2_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="nPaymentmadeDetID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPaymentDetID" runat="server" Text='<%# Eval("nPaymentmadeDetID") %>'></asp:Label>
                                                            <asp:Label ID="lblInvID" runat="server" Text='<%# Eval("nInvoiceID") %>'></asp:Label>

                                                            <asp:Label ID="lblInvNo" runat="server" Text='<%# Eval("sInvoiceNo") %>'></asp:Label>
                                                            <asp:Label ID="lblInvDate" runat="server" Text='<%# Eval("dtInvoiceDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Invoice Date">
                                                        <ItemTemplate>
                                                            <%#validation.TextToDate(Eval("dtInvoiceDate").ToString())%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="sInvoiceNo" HeaderText="Invoice No" />
                                                    <asp:BoundField DataField="nBuyingRate" HeaderText="Selling Rate" />
                                                    <asp:BoundField DataField="nBalance" HeaderText="Due Amount" />
                                                    <asp:TemplateField HeaderText="Payment Value" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtBalance" Text='<%# Eval("nBalance") %>' runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Payment Value">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPaymentValue" Text='<%# Eval("nAmount") %>' runat="server" AutoPostBack="true" OnTextChanged="txtPaymentValue_TextChanged"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12" style="text-align: center; padding: 10px;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Save" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />

                                <%-- <asp:Button ID="btnAddDet" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAddDet_Click" ToolTip="Add" />--%>
                                <asp:Button ID="btnUpdateDet" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="B" OnClick="btnUpdateDet_Click" ToolTip="Save" />
                                <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print" OnClick="btnPrint_Click" ToolTip="Print" Visible="false" />

                            </div>
                        </div>


                    </asp:Panel>
                    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                        <!-- begin row -->


                        <div class="form-group row m-b-15">

                            <div class="col-md-3 col-sm-3">

                                <label class="col-form-label" for="email">Voucher No * :</label>

                                <asp:DropDownList ID="ddlVoucherNoS" runat="server" CssClass="form-control js-example-placeholder-single">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3 ">
                                <label class="col-form-label" for="email">Voucher Type * :</label>
                                <asp:DropDownList ID="ddlVTypeS" runat="server" CssClass="form-control js-example-placeholder-single">
                                    <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Cash Payment" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Bank Payment" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3" style="z-index: 999;">
                                <label class="col-form-label" for="email">From Date * :</label>
                                <div class="input-group">

                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtFrom"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="ImageButton3" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />

                                    <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                        TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>

                            <div class="col-md-3 col-sm-3" style="z-index: 999999;">
                                <label class="col-form-label" for="email">To Date * :</label>
                                <div class="input-group">

                                    <div class="input-group-addon">
                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="16" Height="16" />
                                    </div>
                                    <asp:TextBox ID="txtdtTo" runat="server" CssClass="form-control"></asp:TextBox>

                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtdtTo"
                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="ImageButton4" TargetControlID="txtdtTo" PopupPosition="BottomRight" />

                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                        TargetControlID="txtdtTo" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">Search :</label><br />
                                <asp:Button ID="btnSearch" Text="Search" runat="server" OnClick="btnSearch_Click" CssClass="btn btn-primary" ToolTip="Search" ValidationGroup="B" />
                            </div>
                        </div>
                        <div class="form-group row m-b-15">

                            <div class="col-md-12 col-sm-12">
                                <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nPaymentMadeID" Width="95%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nPaymentMadeID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nPaymentMadeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Voucher Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtPayment").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sVoucherNo" HeaderText="Voucher No" />
                                        <asp:BoundField DataField="sAgencyName" HeaderText="Supplier Name" />
                                        <asp:BoundField DataField="sPayfor" HeaderText="Pay For" />
                                        <asp:BoundField DataField="nTotAmount" HeaderText="Total Amount" />

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
                            </div>
                        </div>

                        <!-- end row -->
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
