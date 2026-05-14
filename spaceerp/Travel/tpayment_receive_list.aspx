<%@ Page Title="PAYMENT RECEIVE" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tpayment_receive_list.aspx.cs" Inherits="tpayment_receive_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style>
        /*.modal-xl{ 
                 max-width :75%;
                 max-height:60vh;
             }*/
        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }
    </style>
    <style>
        .form-control {
            border: 1px solid #00bcd4;
            width: 90%;
        }

        .nopad {
            padding: 0;
        }

        .full-wdth {
            width: 100% !important;
        }
    </style>


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>

    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
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
            margin-top: 10%;
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

            <h4 class="panel-title text-center">Search Agent Payment Receive List </h4>
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

                
                <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />

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

    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
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
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div style="border: 1px solid #e0e0d9; padding: 5px; margin-top: 10px;">
                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="email">Client * :</label>
                                                    <asp:DropDownList ID="ddlClient" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlClient" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="email">Pay For * :</label>
                                                    <asp:DropDownList ID="ddlPayFor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPayFor_SelectedIndexChanged">
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
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClient" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="email">Voucher No * :</label>
                                                    <asp:TextBox ID="txtPaymentVoucherNo" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtPaymentVoucherNo" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label" for="email">Voucher Date * :</label>
                                                    <asp:TextBox ID="txttJournalVoucher" runat="server" Width="100%" OnTextChanged="txttJournalVoucher_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                                            </div>
                                            <div class="form-group row m-b-15">
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="email">Payment Mode :</label>
                                                    <asp:DropDownList ID="ddlPaymentMode" runat="server" Width="100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Cash Payment" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Bank Payment" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPaymentMode" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-3">
                                                    <label class="col-form-label" for="email">Payment Account * :</label>
                                                    <asp:DropDownList ID="ddlPayAccount" runat="server" Width="100%" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged">
                                                        <asp:ListItem Text="Select Voucher Type" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Cash Payment" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Bank Payment" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlPayAccount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-2 col-sm-2">
                                                    <label class="col-form-label">Amount</label>
                                                    <asp:TextBox ID="txtAmount" runat="server" Width="100%" AutoPostBack="true" OnTextChanged="txtAmount_TextChanged"></asp:TextBox><asp:RegularExpressionValidator ID="REV8" runat="server" ControlToValidate="txtAmount"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE8" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAmount"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                    <asp:RequiredFieldValidator ID="RFV8" runat="server" ControlToValidate="txtAmount" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-md-4 col-sm-4">
                                                    <label class="col-form-label">Remarks.</label>
                                                    <asp:TextBox ID="txtRemarks" runat="server" Width="100%"></asp:TextBox>
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
    <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
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
                var id = $(this).closest('tr').find('td:eq(7)').text();
                $("#accountledgerid").val(id);
                var datastring = 'ID=' + id;
                $.ajax({
                    type: "POST",
                    url: "tpayment_receive.aspx",
                    data: datastring,
                    cache: false,
                    success: function (html) {
                        window.location.href = "../Travel/tpayment_receive.aspx?" + datastring + "";
                    }
                });
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
                    url: '<%=ResolveUrl("tpayment_receive_list.aspx/DeleteVoucher") %>',
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
                url: '<%=ResolveUrl("tpayment_receive_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, Reportfor: Reportfor, AgentID: AgentID }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Voucher No</td><td>Voucher Date</td><td>Agency Name </td><td>Pay For</td><td>Voucher Amount</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>AccountType</td><td style='display:none'>AccountType</td><td style='display:none'>AccountType</td><td style='display:none'>AccountType</td><td style='display:none'>AccountType</td><td style='display:none'>AccountType</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PaymentReceiveNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].dtVoucher + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].AgetName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PayFor + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Amount + '</td>';
                        html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].PaymentReceiveID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].AgentID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].PayFor + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].PaymentModeID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].CashAccountID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].Remarks + '</td>';
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


        $("#<%=ddlClient.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });
        $("#<%=ddlPayFor.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });

    </script>


</asp:Content>
