<%@ Page Title="Umrah Mofa Entries" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tmofa_booking_list.aspx.cs" Inherits="tmofa_booking_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .modal-header {
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background: #1b82ec;
            color: #fff;
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
            background: #1b82ec;
            padding-bottom: 5px;
            padding-top: 5px;
        }

        .modal-xl {
            width: 80% !important;
            max-width: 1200px;
        }

        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .close {
            float: right;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: 2;
        }

        .btnspl {
            min-width: 217px;
            padding: 10px 50px;
        }

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
    <%--<style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top:0px;
            margin-bottom:0px;
        padding:0px;
        }
        .enlarged #wrapper .content-page {
            margin-left: 0px;
        }
        .topbar {
            display: none;
        }

        .footer {
            display: none;
        }
        .side-menu {
            display: none;
        }
    </style>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <style>
        .modal {
            /*top: 50% !important;
            left: 22% !important;*/
            /*left: 183px;*/
            position: absolute;
            /*top: 75.5px;*/
            z-index: 10000007;
            opacity: 1;
            /* display: block;*/
        }

        .modal-open .modal {
            background: none;
            border: none;
        }

        .modal-xl {
            min-width: 90%;
            margin-top: 20%;
        }
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Umrah Mofa Entries </h4>
        </div>
        <div class="panel-body">

            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div class="col-md-12 ml-auto mr-auto">
                        <div class="clearfix form-group">
                            <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Report For :</label>
                                <asp:DropDownList ID="ddlStReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlStReportFor_SelectedIndexChanged">
                                    <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>

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
            <div class="col-sm-12 text-center center-block well-sm" id="divprint">


                <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
                <asp:Button Text="Export To PDF" runat="server" CssClass="btn btn-primary" ID="btnpdf" OnClick="btnpdf_Click" />
                <asp:Button ID="btnprint" CssClass="btn btn-primary" Style="background-color: #004080" runat="server" Text="Print" OnClick="btnPrint_Click"/>
                <asp:Button ID="btnsendmail" CssClass="btn btn-primary" Style="background-color: #004080" runat="server" Text="Send Email" OnClick="btnsendmail_Click" />

                <AjaxToolKit:ConfirmButtonExtender ID="btnSendMail_confirmbuttonextender" runat="server"
                    DisplayModalPopupID="btnSendMail_modalpopupextender" TargetControlID="btnSendMail" />
                <AjaxToolKit:ModalPopupExtender ID="btnSendMail_modalpopupextender" runat="server"
                    BackgroundCssClass="modalBackground" CancelControlID="btnCloseemail" OkControlID="btnSend"
                    PopupControlID="PNL0" TargetControlID="btnSendMail" />

                <br />
                <asp:Panel ID="PNL0" runat="server" Style="display: none; background-color: white; width: 300px; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
                    <div class="form-group row">
                        <label class="control-label col-sm-3" for="email" style="color: black;">To</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Style="color: black;" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3" for="email" style="color: black;">CC</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCC" runat="server" CssClass="form-control" Style="color: black;" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3" for="email" style="color: black;">BCC</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtBCC" runat="server" CssClass="form-control" Style="color: black;" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3" for="email" style="color: black;">Subject</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtSub" runat="server" CssClass="form-control" Style="color: black;" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="control-label col-sm-3" for="email" style="color: black;">Body</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" CssClass="form-control" Style="color: black;" />
                            <div class="row">
                                <%-- <asp:CheckBox ID="chkexcel" runat="server" Text="Excel" /> 
                                                 <asp:CheckBox ID="chkpdf" runat="server" Text="Pdf" />--%>
                                <asp:LinkButton ID="lnkAttachment" runat="server" Style="font-size: 11px; color: black;" Visible="false"></asp:LinkButton>
                                <asp:LinkButton ID="lnkpdf" runat="server" Style="font-size: 11px; color: black;" Visible="false"></asp:LinkButton>
                                <asp:RadioButton runat="server" ID="rbexcel" Text="Excel" />
                                <asp:RadioButton runat="server" ID="rbpdf" Text="pdf" />
                            </div>

                        </div>
                    </div>
                    <div style="text-align: right;">
                        <asp:Button ID="btnSend" runat="server" Text="Send" Style="color: black;" />
                        <asp:Button ID="btnCloseemail" runat="server" Text="Close" Style="color: black;" />
                    </div>
                </asp:Panel>

            </div>
           
            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
        </div>
    </div>
      <div id="griddiv" runat="server" visible="false">
        <!-- begin invoice -->
        <div class="invoice" id="scndgrddiv" runat="server">
            <!-- begin invoice-company -->
            <div class="invoice-company text-inverse f-w-600">

                <h1 style="text-align: center">Supplier Name: Alnasa Technlogy</h1>
                <div class="text-center" style="text-align: center">
                    <h4 style="font-family: Calibri;"><b>Ledger Name :- Mofa Booking  </b></h4>
                    <h4>
                        <asp:Label runat="server" ID="lbldates"></asp:Label></h4>
                    <h4>Agency Name :
                        <asp:Label runat="server" ID="lblagencyname"></asp:Label></h4>
                </div>
            </div>
            
            <div class="invoice-header">
                <div class="invoice-from">
                </div>

            </div>

            <div class="invoice-content">

                <div class="table-responsive">

                    <asp:GridView ID="GridViewexcel" CssClass="table" runat="server" AutoGenerateColumns="False"
                        Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                        <Columns>

                            <asp:BoundField DataField="sMofaBookingNo" HeaderText="Invoice No" />
                             <asp:TemplateField HeaderText="Invoice Date">
                                <ItemTemplate>
                                    <%#validation.TextToDate(Eval("dtBookingDate").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="sAgent" HeaderText="Agent Name" />
                            <asp:BoundField DataField="sSupplier" HeaderText="Supplier Name" />
                            <asp:BoundField DataField="sBranchName" HeaderText="Branch Name" />
                            <asp:BoundField DataField="nBuyingRate" HeaderText="Buying Cost" />
                            <asp:BoundField DataField="nSellingRate" HeaderText="Selling Cost" />
                            <asp:BoundField DataField="nPaidAmount" HeaderText="Paid Amount" />
                            <asp:BoundField DataField="nBalance" HeaderText="Balance" />
                            <asp:BoundField DataField="sPaid" HeaderText="Paid Status" />
                            
                           

                            
                        </Columns>
                    </asp:GridView>


                </div>


            </div>

        </div>

    </div>
     <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
        <div class="modal-dialog  modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLongTitle1">Email</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <span>Email has been sent successfully</span>
                    <asp:Label runat="server" ID="lblerrormsg"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnpopupclose">Close</button>
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

                $(document.body).on("click", ".editbtn", function () {
                    var tr = $(this).closest('tr td');
                    var id = $(this).closest('tr').find('td:eq(12)').text();
                    $("#accountledgerid").val(id);
                    var datastring = 'ID=' + id;
                    $.ajax({
                        type: "POST",
                        url: "tmofa_booking.aspx",
                        data: datastring,
                        cache: false,
                        success: function (html) {
                            window.location.href = "../Travel/tmofa_booking.aspx?" + datastring + "";
                        }
                    });
                });

                $(document.body).on("click", ".deletebtn,.Inactivebtn", function () {

                    var tr = $(this).closest('tr td');
                    var id = $(this).closest('tr').find('td:eq(12)').text();
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
                        url: '<%=ResolveUrl("tmofa_booking.aspx/DeleteVoucher") %>',
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




            });

        }
        function loaddata() {
            var fromdate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var Reportfor = document.getElementById("<%=ddlStReportFor.ClientID %>").value;
            var AgentID = document.getElementById("<%=ddlAgentID.ClientID %>").value;
            $.ajax({
                url: '<%=ResolveUrl("tmofa_booking_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, Reportfor: Reportfor, AgentID: AgentID }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Invoice No</td><td>Invoice Date</td><td>Agent Name </td><td>Guest Name</td><td>Branch Name</td><td>Buying Cost </td><td>Selling Cost </td><td>Paid Amount</td><td>Balance </td><td>Paid Status </td><td style='width:3%'>Edit/Delete</td><td style='display:none'>TicketID</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].InvoiceNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].InvoiceDate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].AgentName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Supplier + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].BranchName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].BuyingCost + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SellingCost + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PaidAmount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Balance + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PaidStatus + '</td>';
                        html += '<td >' + '<a href="tvisa.aspx" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].TicketID + '</td>';

                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlist").html(html);

                    var table = $("#tblagentlist").DataTable({
                        //"aLengthMenu": [[25, 50, 75, -1], [25, 50, 75, "All"]],
                        //"iDisplayLength": 25,

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
                url: '<%=ResolveUrl("tticketing_list.aspx/loaddetdata") %>',
                type: "post",
                data: JSON.stringify({ AccountLedgerID: subagentid }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlistdet' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><tr> <th style='width:2%'>Sr No.</th><th>Ticket No</th><th>Book Type</th><th>Pax Type</th><th>Pax Name</th><th>Sector</th><th>Buying Cost</th><th>Selling Cost</th><th>Edit / Delete</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th><th style='display:none'>Amount</th></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlistnew.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].TicketPNR + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].BookType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].PaxType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].CustomerName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].Sector + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].BuyingCost + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlistnew[i].SellingCost + '</td>';
                        html += '<td >' + '<a href="#" class="editbtndet" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].TicketDetID + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].CarrierID + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].FareBasis + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ProfitType + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ProfitAmount + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].Discount + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].Remarks + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupScType + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupSCAmount + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].bSupTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupCGst + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].SupSGst + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupIGst + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].bClntTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntCGst + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntSGst + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntIGst + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].AirComm + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].Airplb + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].YqTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].YrTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].OtherTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupTdsAmount + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].ClntTdsType + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntTdsAmount + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].K3Tax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].AirlinePnr + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClientSC2Amount + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntOtherChrgs + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].ClntBasicFare + '</td>';


                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntYQTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntYRTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntK3Tax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntAirCom + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].ClntAirPlb + '</td>';


                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].ClntOtherTax + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].FlightNo + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].TktBookFrom + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].clntTktFare + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].SupTktFare + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].SupDiscount + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].PaxType + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].LPONo + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].PCC + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].AirlineCodeID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].Designator + '</td>';

                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].GalPNRNo + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].IATANo + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].StaffSign + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].TourCode + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].TravelDate + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].ReturnDate + '</td>';
                        html += '<td style="display:none;">' + mainlist.d.mpagemasterobjlistnew[i].FareBasis + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].FileName + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlistnew[i].ReturnDate + '</td>';

                        //magentobjnew.Cost = dtnew.Rows[i]["nTicketingID"].ToString();
                        //magentobjnew.Total = dtnew.Rows[i]["nTicketingID"].ToString();

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
    </script>

</asp:Content>
