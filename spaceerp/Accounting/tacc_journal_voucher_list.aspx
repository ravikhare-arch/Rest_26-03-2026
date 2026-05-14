<%@ Page Title="Journal Voucher" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tacc_journal_voucher_list.aspx.cs" Inherits="tacc_journal_voucher_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

 <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    <link href="../css/customize-model.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">

                <a href="#" class="btn btn-info btn-xs" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Journal Voucher</h4>
        </div>
        <div class="panel-body">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="col-md-12 ml-auto mr-auto">
                        <div class="clearfix form-group">
                            <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Report For :</label>
                                <asp:DropDownList ID="ddlStReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlStReportFor_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="OTHERS" Value="-1"></asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">
                                    Agent Name :</label>
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlAgentID" runat="server">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                                <label for="form-1-3" class="col-form-label">From Date</label>
                                <div class="timepicker-input">
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
                                <label class="col-form-label">&nbsp;</label>
                                <input type="button" id="btnsearch" class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class=" col-md-12 text-center">
                <br />

                
                <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="Button1" OnClick="btnexcel_Click" />

                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF" />
                <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false" />
                <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />

            </div>
            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
        </div>
    </div>
    

    <!--create/edit Modal popup -->

    <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background: #164e7f; color: #fff;">
                    <h5 class="modal-title" id="exampleModalLongTitle"></h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="pdd-horizon-15 pdd-vertical-20">
                        <div class="card-block">
                            <div class="row">

                                <div class="form-group row m-b-5">

                                    <div class="col-md-2 col-sm-3">
                                        <asp:UpdatePanel ID="up1" runat="server">
                                            <ContentTemplate>


                                                <label class="col-form-label" for="email">Journal Voucher No * :</label>
                                                <asp:TextBox CssClass="form-control" ID="txtJournalVoucherNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtJournalVoucherNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-md-2 col-sm-3">
                                        <label class="col-form-label" for="email">Voucher Type * :</label>
                                        <asp:DropDownList CssClass="form-control" ID="ddlVoucherTypeID" runat="server" Width="100%">
                                            <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Journal Voucher" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlVoucherTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 col-sm-2">
                                        <label class="col-form-label" for="email">Voucher Date * :</label>
                                        <asp:TextBox CssClass="form-control" ID="txttJournalVoucher" runat="server" Width="100%" OnTextChanged="txttJournalVoucher_TextChanged" AutoPostBack="true"></asp:TextBox>


                                        <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                            TargetControlID="txttJournalVoucher" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                        <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txttJournalVoucher"
                                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                        </asp:RegularExpressionValidator>
                                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                            PopupButtonID="txttJournalVoucher" TargetControlID="txttJournalVoucher" PopupPosition="TopLeft" />
                                        <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txttJournalVoucher" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>


                                    <div class="col-md-2 col-sm-3">
                                        <label class="col-form-label" for="email">Account Type (Debtor)* :</label>
                                        <asp:DropDownList ID="ddlAccountType" CssClass="js-ex ample-basic-single form-control" runat="server" Width="100%">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlAccountType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 col-sm-3">
                                        <label class="col-form-label" for="email">Posted by * :</label>
                                        <asp:TextBox ID="txtPostedby" CssClass="form-control" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                    </div>
                                    <%--<div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="email">Amended by * :</label>
                                    <asp:TextBox ID="txtAmendedby" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>--%>
                                    <div class="col-md-2 col-sm-3">
                                        <label class="col-form-label" for="email">Location :</label>
                                        <asp:DropDownList ID="ddlLocation" CssClass="form-control" runat="server" Width="100%"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlLocation" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div style="border: 1px solid #e0e0d9; padding: 5px; margin-top: 10px;">

                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label">Account Title(Creditor) * :</label>
                                                    <asp:DropDownList CssClass="form-control" ID="ddlAccountCodeID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAccountCodeID_SelectedIndexChanged" Width="100%"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlAccountCodeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Account Type not same as Account Title" Display="Dynamic" ControlToValidate="ddlAccountCodeID" ValidationGroup="A" ControlToCompare="ddlAccountType" Operator="NotEqual" ForeColor="Red"></asp:CompareValidator>

                                                </div>
                                                <%--<div class="col-md-2 col-sm-2">
                                    <label class="col-form-label">Account Title * :</label>
                                    <asp:TextBox ID="txtAccountTitle" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAccountTitle" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>--%>

                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Balance  * :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtBalance" runat="server" Width="100%" Enabled="False"></asp:TextBox>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Job No.</label>
                                                    <asp:DropDownList CssClass="form-control" ID="ddlJobID" runat="server" Width="100%"></asp:DropDownList>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Currency</label>
                                                    <asp:DropDownList ID="ddlCurrencyID" CssClass="form-control" runat="server" Width="100%" OnSelectedIndexChanged="ddlCurrencyID_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV6" runat="server" ControlToValidate="ddlCurrencyID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Rate</label>
                                                    <asp:TextBox ID="txtRate" CssClass="form-control" runat="server" Width="100%" AutoPostBack="True" OnTextChanged="txtRate_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV7" runat="server" ControlToValidate="txtRate"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE7" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtRate"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RFV7" runat="server" ControlToValidate="txtRate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Amount</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtAmount" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtAmount_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV8" runat="server" ControlToValidate="txtAmount"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE8" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Local Amount</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtLocalAmount" runat="server" Width="100%" Enabled="false"></asp:TextBox><asp:RegularExpressionValidator ID="REV9" runat="server" ControlToValidate="txtLocalAmount"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE9" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtLocalAmount"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="txtLocalAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label">Description  * :</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtDescription" runat="server" Width="100%"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV5" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label">Remarks.</label>
                                                    <asp:TextBox ID="txtRemarks" CssClass="form-control" runat="server" Width="100%"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <br />
                            <div class="row">
                                <div style="width: 100%;" id="divagentlistDet"></div>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="background: #164e7f; color: #fff;">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnclose">Close</button>
                    <button type="button" class="btn btn-primary" id="btnadd">Add</button>
                    <button type="button" class="btn btn-primary" id="btnupdate">Update</button>
                </div>
            </div>
        </div>
    </div>


    <!--Delete Modal popup -->
    <div class="modal fade" id="deleteModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Airlines</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to delete?</label>
                    <label style="color: black; display: none;" id="lblsucess">Deleted Successfully..!</label>
                    <label style="color: white; display: none" id="lblinactive">Are you sure you want to De-Active User?</label>
                    <label style="color: white; display: none;" id="lblinactivesucess">Your Account has been successfully De-Activated?</label>
                    <label id="accountledgerid" style="display: none"></label>
                    <label id="journalvoucherdetid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Delete</button>
                    <button type="button" class="btn btn-primary" id="inactivebutton">De-Activate</button>

                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">

        function pageLoad(sender, args) {
        $(document.body).ready(function () {
            $("#btnsearch").on("click", function () {
                loaddata();
            });
            $("#btnadd").on("click", function () {

                //if (validatedata()) {
                var obj = {
                    JournalVoucherNo: $("#ctl00_ContentPlaceHolder1_txtJournalVoucherNo").val(),
                    VoucherType: $("#ctl00_ContentPlaceHolder1_ddlVoucherTypeID").val(),
                    dtJournalVoucher: $("#ctl00_ContentPlaceHolder1_txttJournalVoucher").val(),
                    AccountType: $("#ctl00_ContentPlaceHolder1_ddlAccountType").val(),
                    Location: $("#ctl00_ContentPlaceHolder1_ddlLocation").val(),
                    Postedby: $("#ctl00_ContentPlaceHolder1_txtPostedby").val(),
                    AccountCode: $("#ctl00_ContentPlaceHolder1_ddlAccountCodeID").val(),
                    Amendedby: $("#ctl00_ContentPlaceHolder1_txtBalance").val(),
                    JobID: $("#ctl00_ContentPlaceHolder1_ddlJobID").val(),
                    CurrencyID: $("#ctl00_ContentPlaceHolder1_ddlCurrencyID").val(),
                    Rate: $("#ctl00_ContentPlaceHolder1_txtRate").val(),
                    LocalAmount: $("#ctl00_ContentPlaceHolder1_txtLocalAmount").val(),
                    Description: $("#ctl00_ContentPlaceHolder1_txtDescription").val(),
                    VoucherAmount: $("#ctl00_ContentPlaceHolder1_txtAmount").val(),
                    Remarks: $("#ctl00_ContentPlaceHolder1_txtRemarks").val()
                }

                $.ajax({
                    url: '<%=ResolveUrl("tacc_journal_voucher_list.aspx/AddJournalVoucher") %>',
                        data: JSON.stringify({ list: obj }),
                        type: "post",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "1") {
                                $("#btnadd").hide();
                                $("#lbelsucess").show();
                                $('#lbelupdatesucess').hide();
                                $("#lblrequirefield").hide();
                                loaddata();

                            }
                            else {
                                alert(data.d);
                            }

                        },
                        error: function (data) {
                            alert(data.d);
                        }
                    });
                //} validate data


            });

            $(document.body).on("click", "#lnklist", function () {
                // cleardata();
                $('#btnupdate').hide();
                $("#lbelsucess").hide();
                $("#lbelupdatesucess").hide();
                $("#btnadd").show();


            });

            $(document.body).on("click", ".editbtn", function () {
                cleardata();
                cleardetdata();
                $('#lbelupdatesucess').hide();

                $("#lbelsucess").hide();
                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(8)').text();
                //var CAid = $(this).closest('tr').find('td:eq(9)').text();
                $("#accountledgerid").val(id);
                ////$("#CAccountID").val(CAid);

                //$("#btnadd").css("display", "none");
                $("#ctl00_ContentPlaceHolder1_txtJournalVoucherNo").val($(this).closest('tr').find('td:eq(1)').text());
                $("#ctl00_ContentPlaceHolder1_ddlVoucherTypeID").val($(this).closest('tr').find('td:eq(10)').text());
                $("#ctl00_ContentPlaceHolder1_txttJournalVoucher").val($(this).closest('tr').find('td:eq(2)').text());
                $("#ctl00_ContentPlaceHolder1_ddlAccountType").val($(this).closest('tr').find('td:eq(11)').text());
                $("#ctl00_ContentPlaceHolder1_ddlLocation").val($(this).closest('tr').find('td:eq(9)').text());
                $("#ctl00_ContentPlaceHolder1_txtPostedby").val($(this).closest('tr').find('td:eq(4)').text());
                //$("#ctl00_ContentPlaceHolder1_ddlAccountCodeID").val($(this).closest('tr').find('td:eq(10)').text());
                //$("#ctl00_ContentPlaceHolder1_ddlJobID").val($(this).closest('tr').find('td:eq(12)').text());
                //$("#ctl00_ContentPlaceHolder1_ddlCurrencyID").val($(this).closest('tr').find('td:eq(13)').text());
                //$("#ctl00_ContentPlaceHolder1_txtRate").val($(this).closest('tr').find('td:eq(13)').text());
                //$("#ctl00_ContentPlaceHolder1_txtLocalAmount").val($(this).closest('tr').find('td:eq(12)').text());
                //$("#ctl00_ContentPlaceHolder1_txtDescription").val($(this).closest('tr').find('td:eq(13)').text());
                //$("#ctl00_ContentPlaceHolder1_txtAmount").val($(this).closest('tr').find('td:eq(13)').text());
                //$("#ctl00_ContentPlaceHolder1_txtRemarks").val($(this).closest('tr').find('td:eq(13)').text());



                $('#btnupdate').hide();
                loadDetdata();

            });

            $(document.body).on("click", ".deletebtn,.Inactivebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(8)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").show();
                $("#inactivebutton").hide();

            });
            $(document.body).on("click", ".Inactivebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(8)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").hide();
                $("#inactivebutton").show();
                $("#lblinactive").css("display", "block");
                $("#lbldelete").hide();

            });

            // // end
            // // //delete the agent
            $(document.body).on("click", "#deletebutton", function () {
                var subagentid = $("#accountledgerid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("tacc_journal_voucher_list.aspx/DeleteVoucher") %>',
                    data: JSON.stringify({ AccountLedgerID: subagentid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            $("#lblsucess").css("display", "block");
                            $("#lbldelete").hide();
                            loaddata();
                            $("#deletebutton").hide();
                            $("#accountledgerid").val('');
                        }
                        else {
                            $("#lblsucess").css("display", "block");
                            $("#lblsucess").val(data.d);
                            $("#lbldelete").hide();
                        }
                    },
                    error: function (data) {
                        alert(data.d);
                    }
                });
            });

            //EditDet Button Start
            $(document.body).on("click", ".editbtndet", function () {
                cleardetdata();
                $('#lbelupdatesucess').hide();
                $("#lbelsucess").hide();
                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(11)').text();
                //var CAid = $(this).closest('tr').find('td:eq(9)').text();
                $("#journalvoucherdetid").val(id);
                ////$("#CAccountID").val(CAid);

                $("#btnadd").css("display", "none");

                $("#ctl00_ContentPlaceHolder1_ddlAccountCodeID").val($(this).closest('tr').find('td:eq(6)').text());
                $("#ctl00_ContentPlaceHolder1_ddlJobID").val($(this).closest('tr').find('td:eq(12)').text());
                $("#ctl00_ContentPlaceHolder1_ddlCurrencyID").val($(this).closest('tr').find('td:eq(7)').text());
                $("#ctl00_ContentPlaceHolder1_txtRate").val($(this).closest('tr').find('td:eq(8)').text());
                $("#ctl00_ContentPlaceHolder1_txtLocalAmount").val($(this).closest('tr').find('td:eq(10)').text());
                $("#ctl00_ContentPlaceHolder1_txtDescription").val($(this).closest('tr').find('td:eq(2)').text());
                $("#ctl00_ContentPlaceHolder1_txtAmount").val($(this).closest('tr').find('td:eq(4)').text());
                $("#ctl00_ContentPlaceHolder1_txtRemarks").val($(this).closest('tr').find('td:eq(9)').text());



                $('#btnupdate').show();


            });
            //EditDet Button End

            // // // update code start
            $(document.body).on("click", "#btnupdate", function () {
                var obj = {
                    JournalVoucherNo: $("#ctl00_ContentPlaceHolder1_txtJournalVoucherNo").val(),
                    VoucherType: $("#ctl00_ContentPlaceHolder1_ddlVoucherTypeID").val(),
                    dtJournalVoucher: $("#ctl00_ContentPlaceHolder1_txttJournalVoucher").val(),
                    AccountType: $("#ctl00_ContentPlaceHolder1_ddlAccountType").val(),
                    Location: $("#ctl00_ContentPlaceHolder1_ddlLocation").val(),
                    Postedby: $("#ctl00_ContentPlaceHolder1_txtPostedby").val(),
                    AccountCode: $("#ctl00_ContentPlaceHolder1_ddlAccountCodeID").val(),
                    Amendedby: $("#ctl00_ContentPlaceHolder1_txtBalance").val(),
                    JobID: $("#ctl00_ContentPlaceHolder1_ddlJobID").val(),
                    CurrencyID: $("#ctl00_ContentPlaceHolder1_ddlCurrencyID").val(),
                    Rate: $("#ctl00_ContentPlaceHolder1_txtRate").val(),
                    LocalAmount: $("#ctl00_ContentPlaceHolder1_txtLocalAmount").val(),
                    Description: $("#ctl00_ContentPlaceHolder1_txtDescription").val(),
                    VoucherAmount: $("#ctl00_ContentPlaceHolder1_txtAmount").val(),
                    Remarks: $("#ctl00_ContentPlaceHolder1_txtRemarks").val(),
                    JournalVoucherID: $("#accountledgerid").val(),
                    JournalVoucherDetID: $("#journalvoucherdetid").val(),
                }

                $.ajax({
                    url: '<%=ResolveUrl("tacc_journal_voucher_list.aspx/UpdateJournalVoucher") %>',
                    data: JSON.stringify({ list: obj }),
                    type: "post",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == "1") {
                            alert("Updated Successfully..!");
                            loaddata();
                            $('#btnupdate').hide();
                            $('#lbelupdatesucess').hide();
                        }
                        else {
                            alert(data.d);
                        }

                    },
                    error: function (data) {
                        alert(data.d);
                    }
                });

            });
            // // // update code 
        });
        }
        function cleardata() {
            $("#ctl00_ContentPlaceHolder1_txtJournalVoucherNo").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlVoucherTypeID").val(''),
            $("#ctl00_ContentPlaceHolder1_txttJournalVoucher").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlAccountType").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlLocation").val('')

        }

        function cleardetdata() {
            $("#ctl00_ContentPlaceHolder1_ddlAccountCodeID").val(''),
            $("#ctl00_ContentPlaceHolder1_txtBalance").val(''),
             $("#ctl00_ContentPlaceHolder1_ddlJobID").val(''),
             $("#ctl00_ContentPlaceHolder1_ddlCurrencyID").val(''),
             $("#ctl00_ContentPlaceHolder1_txtRate").val(''),
             $("#ctl00_ContentPlaceHolder1_txtLocalAmount").val(''),
            $("#ctl00_ContentPlaceHolder1_txtAmount").val(''),
              $("#ctl00_ContentPlaceHolder1_txtDescription").val(''),
              $("#ctl00_ContentPlaceHolder1_txtRemarks").val('')
        }

        function loaddata() {
            var fromdate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var Reportfor = document.getElementById("<%=ddlStReportFor.ClientID %>").value;
            var AgentID = document.getElementById("<%=ddlAgentID.ClientID %>").value;
            $.ajax({
                url: '<%=ResolveUrl("tacc_journal_voucher_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, Reportfor: Reportfor, AgentID: AgentID }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Voucher No</td><td>Voucher Date</td><td>Voucher Type </td><td>Posted By </td><td>Ammended By</td><td>Voucher Amount</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>VoucherID</td><td style='display:none'>VouherTypeID</td><td style='display:none'>LocationID</td><td style='display:none'>AccountType</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].JournalVoucherNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].dtJournalVoucher + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].VoucherType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Postedby + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Amendedby + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].VoucherAmount + '</td>';
                        html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" data-toggle="modal" data-target="#exampleModalCenter"></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].JournalVoucherID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].Location + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].VoucherTypeID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].AccountType + '</td>';

                        //html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].Latitude + '</td>';
                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlist").html(html);

                    var table = $("#tblagentlist").DataTable({
                        "aLengthMenu": [[25, 50, 75, -1], [25, 50, 75, "All"]],
                        "iDisplayLength": 25,

                        //"bRetrieve": true,
                        //"retrieve": true,
                        //"orderCellsTop": true,

                        //"bLengthChange": false,

                        //"scrollX": true,

                        //"scrollCollapse": true,

                        //"paging": true,

                        language: {
                            searchPlaceholder: ""
                        },

                    });

                },
                error: function (data) {
                    alert(data.d);
                }
            });
        }

        function loadDetdata() {
            var subagentid = $("#accountledgerid").val();
            $.ajax({
                url: '<%=ResolveUrl("tacc_journal_voucher_list.aspx/loaddetdata") %>',
                type: "post",
                data: JSON.stringify({ AccountLedgerID: subagentid }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlistdet' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><tr> <th style='width:2%'>Sr No.</th><th>Account Title</th><th>Description</th><th>Currency</th><th>Amount</th><th>Edit / Delete</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlistnew.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].AccountCode + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].Description + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].Currency + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].Amount + '</td>';
                        html += '<td >' + '<a href="#" class="editbtndet" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].AccountCodeID + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].CurrencyID + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].Rate + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].Remarks + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].LocalAmount + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].JournalVoucherDetID + '</td>';
                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlistDet").html(html);


                },
                error: function (data) {
                    alert(data.d);
                }
            });
        }


        $("#<%=ddlAccountCodeID.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });

        $("#<%=ddlAccountType.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });

        $("#<%=ddlLocation.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });
    </script>
    <%-- <script>
        $(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_pageLoaded(function () {
                $(".js-example-placeholder-single").select2({
                    placeholder: "Select a state",
                    allowClear: true
                });
            });
        });

    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".js-example-basic-single").select2();
        });
    </script>
</asp:Content>
