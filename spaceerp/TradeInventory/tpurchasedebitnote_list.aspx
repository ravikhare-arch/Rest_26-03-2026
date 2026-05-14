<%@ Page Title="Purchase Debit Note" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tpurchasedebitnote_list.aspx.cs" Inherits="tpurchasedebitnote_list" %>

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

        .btn {
            padding: 0px 12px;
        }
        /*.modal-body {
    position: relative;
    padding: 0px;
}*/
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

            <h4 class="panel-title text-center">Purchase Debit Note</h4>




        </div>
        <div class="panel-body">
            <div class="col-md-12 ml-auto mr-auto">
                <div class="clearfix form-group">
                    <div class="col-md-4 col-sm-3">
                        <label class="col-form-label" for="fullname">Custome Name  :</label>
                        <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="form-control js-example-placeholder-single" ></asp:DropDownList>
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
                        <input type="button" name="btnsearch" value="Search" id="btnsearch" class="btn btn-primary form-control no-mrg-btm" />

                    </div>
                </div>

            </div>

            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
        </div>
    </div>
    <div class="col-sm-12 text-center center-block well-sm">


        <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
                           <asp:Button Text="Export To PDF" runat="server" CssClass="btn btn-primary" ID="btnpdf" OnClick="btnpdf_Click"  />
        <asp:Button ID="btnprint" CssClass="btn btn-primary" Style="background-color: #004080" runat="server" Text="Print" OnClick="btnPrint_Click" />
        <asp:Button ID="btnsendmail" CssClass="btn btn-primary" Style="background-color: #004080" runat="server" Text="sendmail" OnClick="btnsendmail_Click"  />

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
     

        <div id="griddiv" runat="server" visible="false">
        <!-- begin invoice -->
        <div class="invoice" id="scndgrddiv" runat="server">
            <!-- begin invoice-company -->
            <div class="invoice-company text-inverse f-w-600">

                <h1 style="text-align: center">Supplier Name: Alnasa Technlogy</h1>
                <div class="text-center" style="text-align: center">
                    <h4 style="font-family: Calibri;"><b>Ledger Name :- Purchase Debit Note  </b></h4>
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

                            <asp:BoundField DataField="sPurchaseDebitNoteNo" HeaderText="Debit Note No" />
                             <asp:TemplateField HeaderText="Debit Note Date">
                                <ItemTemplate>
                                    <%#validation.TextToDate(Eval("dtDebitNote").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>
                             
                            <asp:BoundField DataField="sGSTType" HeaderText="GST Type" />
                            <asp:BoundField DataField="sReferenceno" HeaderText="Reference No" />
                            <asp:TemplateField HeaderText="Reference Date">
                                <ItemTemplate>
                                    <%#validation.TextToDate(Eval("dtReference").ToString())%>
                                </ItemTemplate>
                            </asp:TemplateField>               
                        </Columns>
                    </asp:GridView>


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
    <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog  modal-dialog-centered" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle1">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <span>Email has been sent successfully</span>
          <asp:Label runat="server" ID="lblerrormsg" ></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnpopupclose">Close</button>      
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
                var id = $(this).closest('tr').find('td:eq(7)').text();
                $("#accountledgerid").val(id);
                var datastring = 'ID=' + id;
                $.ajax({
                    type: "POST",
                    url: "tsalesdebitnote.aspx",
                    data: datastring,
                    cache: false,
                    success: function (html) {
                        window.location.href = "../tradeinventory/tpurchasedebitnote.aspx?" + datastring + "";
                    }
                });
            });

            $(document.body).on("click", ".deletebtn,.Inactivebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(7)').text();
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
                    url: '<%=ResolveUrl("tpurchasedebitnote_list.aspx/DeleteVoucher") %>',
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

       

        function loaddata() {
             var fromdate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var Reportfor = document.getElementById("<%=ddlCustomerName.ClientID %>").value;
            $.ajax({
                url: '<%=ResolveUrl("tpurchasedebitnote_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, Reportfor: Reportfor }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Debit Note No</td><td>Debit Note Date</td><td>GST Type</td><td>Reference No</td><td>Reference Date</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>TicketID</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SalesDebitNoteNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].DebitNotedate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].GSTType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Referenceno + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Referencedate + '</td>';
                        html += '<td >' + '<a href="tsalesdebitnote.aspx" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].SalesDebitNoteID + '</td>';
                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlist").html(html);

                    var table = $("#tblagentlist").DataTable({
                        "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                        "iDisplayLength": 5,

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
