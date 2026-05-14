<%@ Page Title="General Ledger" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tgeneral_ledger_list.aspx.cs" Inherits="tgeneral_ledger_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    
    <link href="../css/customize-model.css" rel="stylesheet" />
    <link href="../css/CustomFinance.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    

    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">General Ledger </h4>
        </div>


        <div class="panel-body">




            <div class="form-group row m-b-15">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                <div class="form-group row m-b-15">
                    <div class="col-md-2 col-sm-4">
                        <label class="col-form-label" for="email">Report For :</label>
                        <asp:DropDownList ID="ddlReportFor" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlReportFor_SelectedIndexChanged">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                            <asp:ListItem Text="SUPPLIER" Value="7"></asp:ListItem>
                            <asp:ListItem Text="CLIENT" Value="3"></asp:ListItem>
                            <asp:ListItem Text="AIRLINE" Value="12"></asp:ListItem>
                            <asp:ListItem Text="OTHERS" Value="-1"></asp:ListItem>

                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3 col-sm-4">
                        <label class="col-form-label" for="email">Account Title  :</label>
                        <asp:DropDownList ID="ddlAccountTitle" runat="server" CssClass="form-control js-example-placeholder-single">
                        </asp:DropDownList>
                         <label id="lblitemname" style="color: darkred; display: none;">Select Item</label>
                    </div>
                    <div class="col-md-3 col-sm-4">
                        <label class="col-form-label" for="email">Account Type  :</label>
                        <asp:DropDownList ID="ddlAccType" runat="server" CssClass="form-control js-example-placeholder-single">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2 col-sm-2" style="z-index: 9999;">


                        <label class="col-form-label" for="email">From Date :</label>
                        <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                            TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                        </asp:RegularExpressionValidator>
                        <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                        

                    </div>

                    <div class="col-md-2  col-sm-2">
                        <label class="col-form-label" for="email">To Date :</label>
                        <asp:TextBox ID="txtdtToDate" runat="server" CssClass="form-control datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                        <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                            TargetControlID="txtdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                        <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtToDate"
                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                        </asp:RegularExpressionValidator>
                        <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                        
                    </div>
                    
                </div>
                     </ContentTemplate>
            </asp:UpdatePanel>
                <div class="col-md-15 col-md-push-2 text-center">
                    <input type="button" id="btnsearch" class="btn btn-primary" style="background-color: #004080" title="Search" value="Search" />
                    <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
                    <%-- <asp:Button Text="Export To PDF" runat="server" CssClass="btn btn-primary" ID="btnpdf" OnClick="btnpdf_Click" />
                    <asp:Button ID="btnsendmail" CssClass="btn btn-primary"  runat="server" Text="Send Mail" OnClick="btnsendmail_Click" />--%>
                    <asp:Button ID="btnReset" CssClass="btn btn-primary" runat="server" Text="Reset" />
                </div>
                <div class="col-md-12 col-sm-12">
                    <div id="divagentlist" class="display nowrap mytables"></div>
                </div>

            </div>
        </div>


    </div>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                $("#btnsearch").on("click", function () {

                    if (validatedata()) {

                        loaddata();
                    }
                });
            });
        }
        function validatedata() {
            var Acctitle = document.getElementById("<%=ddlAccountTitle.ClientID %>").value;
            var AccountType = document.getElementById("<%=ddlAccType.ClientID %>").value;
            var fromdt = document.getElementById("<%=txtdtFrom.ClientID %>").value;
            var todate = document.getElementById("<%=txtdtToDate.ClientID %>").value;
            var validation = true;
            if (Acctitle == "" || Acctitle == "0") {
                //$("#lblitemname").show();
                validation = false;
            }
            
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
            $("#lblitemname").hide();
            $("#lblfromdate").hide();
            $("#lbltodate").hide();
            var fromdate = $("#ctl00_ContentPlaceHolder1_txtdtFrom").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txtdtToDate").val();
            var AccountTitle = $("#ctl00_ContentPlaceHolder1_ddlAccountTitle option:selected").val();
            var AccountType = $("#ctl00_ContentPlaceHolder1_ddlAccType option:selected").val();
            $.ajax({
                url: '<%=ResolveUrl("tgeneral_ledger_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, AccountTitle: AccountTitle, AccountType: AccountType }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Voucher Date</td><td>Voucher No</td><td>Voucher Type</td><td>Description</td><td>Debit Amount</td><td>Credit Amount</td><td>Balance</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].VoucherDate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].VoucherNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].VoucherType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Description + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].DebitAmount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].CreditAmount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Balance + '</td>';
                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlist").html(html);

                    var table = $("#tblagentlist").DataTable({
                        "aLengthMenu": [[10, 15, 25, 50, 75, -1], [10, 15, 25, 50, 75, "All"]],
                        "iDisplayLength": 10,

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
    </script>
    


</asp:Content>
