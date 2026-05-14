<%@ Page Title="Visa Booking Details" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tvisa_list.aspx.cs" Inherits="tvisa_list" %>

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

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <style type="text/css">
        .card-title {
            text-align: center;
            /*padding: 10px;*/
            font-weight: 600;
            border: 1px solid #0098da;
        }

        .text-white {
            color: red !important;
        }

        .nav-tabs > li > a:hover {
            background: #00bcd4;
        }

        label {
            color: black;
            padding-top: 8px;
        }

        .radio-inline, .checkbox-inline {
            margin-top: -8px;
        }

        .well {
            background: white;
            border: 1px solid #0098da;
        }


            .well .fa {
                color: Black;
            }

        .nav-tabs .nav-link.active, .nav-tabs .nav-item.show .nav-link {
            color: white !important;
        }

        .card-block {
            color: black;
        }

        .card {
            background: whitesmoke !important;
        }

        .form-control {
            border: 1px solid #00bcd4;
        }

        .table {
            text-align: center !important;
            border: 1px solid #0098da !important;
            /*background: white;*/
            /*margin-left: 15px;*/
        }

            .table th {
                background: linear-gradient(90deg, #ff0015 31%, #595959 69%) !important;
                /*color: white;*/
                border: 1px solid white;
                border-bottom: none;
                padding: 5px;
            }

            .table td {
                padding: 5px;
            }

            .table tr:nth-of-type(even) {
                background-color: rgba(94, 93, 82, 0.1);
            }


        .frm_sec {
            border: 1px solid #0098da;
            margin: 0;
            border-radius: 4px;
            box-shadow: 0 4px 3px 0 #0e6390c7;
        }

        .destination {
            border-right: 1px solid #0098da;
        }
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <%--<div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;
             <i class="fa fa-plus"></i></a>
            </div>--%>
            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Visa Booking </h4>




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
                                <label>&nbsp;</label>
                         <input type="button" id="btnsearch"  class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />
                           
                               
                            </div>
                        </div>

                    </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
                    <div class=" col-md-12 text-center">
                        <br />

                        <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>
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
                    url: "tvisa.aspx",
                    data: datastring,
                    cache: false,
                    success: function (html) {
                        window.location.href = "../Travel/tvisa.aspx?" + datastring + "";
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
                    url: '<%=ResolveUrl("tvisa_list.aspx/DeleteVoucher") %>',
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

        function validatedata() {
            var Acctitle = document.getElementById("<%=ddlAgentID.ClientID %>").value;
            var fromdt = document.getElementById("<%=txttLastPurchase.ClientID %>").value;
            var todate = document.getElementById("<%=txttLastOrder.ClientID %>").value;
            var validation = true;
            //if (Acctitle == "" || Acctitle == "0") {
            //    //$("#lblitemname").show();
            //    validation = false;
            //}

            if (fromdt == "" || fromdt == "0") {
                //$("#lblfromdate").show();
                validation = false;
            }
            if (todate == "" || todate == "0") {
                //$("#lbltodate").show();
                validation = false;
            }
            return validation;
        }

        function loaddata() {
            var fromdate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var Reportfor = document.getElementById("<%=ddlStReportFor.ClientID %>").value;
            var AgentID = document.getElementById("<%=ddlAgentID.ClientID %>").value;

            $.ajax({
                url: '<%=ResolveUrl("tvisa_list.aspx/loaddata") %>',
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
                            "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                            "iDisplayLength": 5,

                            "columnDefs": [
                {
                    "targets": [3],
                    "visible": false,
                    "searchable": false
                },
                {
                    "targets": [4],
                    "visible": false
                }
                            ],
                            //"bRetrieve": true,
                            //"retrieve": true,
                            //"orderCellsTop": true,

                            //"bLengthChange": false,

                            //"scrollX": true,

                            //"scrollCollapse": true,

                            "paging": true,

                            language: {
                                searchPlaceholder: "Visa"
                            },

                        });

                    },
                    error: function (data) {
                        alert(data.d);
                    }
                });
            }


    </script>

</asp:Content>
