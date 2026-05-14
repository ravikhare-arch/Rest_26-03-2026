<%@ Page Title="Item Ledger" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="titem_ledger_list.aspx.cs" Inherits="titem_ledger_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <link href="../css/customize-model.css" rel="stylesheet" />
    <link href="../css/CustomModal.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
      

    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Item Ledger </h4>
        </div>
        <div class="panel-body">
            <div class="form-group row m-b-15">
                <div class="form-group row m-b-15">
                    <div class="col-md-3 col-sm-3">
                        <label class="col-form-label" for="email">Item Name  :</label>
                        <asp:DropDownList ID="ddlItemName" runat="server" CssClass="form-control js-example-placeholder-single">
                        </asp:DropDownList>
                        <label id="lblitemname" style="color: darkred; display: none;">Select Item</label>
                    </div>
                    <div class="col-md-2 col-sm-3" style="z-index: 9999;">


                        <label class="col-form-label" for="email">From Date :</label>
                        <asp:TextBox ID="txtdtFrom" runat="server" CssClass="form-control"></asp:TextBox>

                        <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                            TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                        </asp:RegularExpressionValidator>
                        <label id="lblfromdate" style="color: darkred; display: none;">*</label>

                    </div>
                    <div class="col-md-1 col-sm-1" style="padding-top: 23px; padding-left: 0px">
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="Img4" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />
                        <asp:ImageButton ID="Img4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                            Width="32" Height="32" />
                    </div>
                    <div class="col-md-2  col-sm-3">
                        <label class="col-form-label" for="email">To Date :</label>
                        <asp:TextBox ID="txtdtToDate" runat="server" CssClass="form-control"></asp:TextBox>


                        <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                            TargetControlID="txtdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                        <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtToDate"
                            ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                            ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                        </asp:RegularExpressionValidator>
                        <label id="lbltodate" style="color: darkred; display: none;">*</label>
                    </div>
                    <div class="col-md-1 col-sm-1" style="padding-top: 23px; padding-left: 0px">
                        <AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                            PopupButtonID="Img3" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />
                        <asp:ImageButton ID="Img3" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                            Width="32" Height="32" />
                    </div>
                    <div class="col-md-2">
                        <label class="col-form-label" for="email">&nbsp;</label>
                        <input type="button" id="btnsearch" class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />

                    </div>
                </div>
                <div class="col-md-15 col-md-push-2 text-center">
                    <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
                    <asp:Button Text="Export To PDF" runat="server" CssClass="btn btn-primary" ID="btnpdf" OnClick="btnpdf_Click" />
                    <asp:Button ID="btnsendmail" CssClass="btn btn-primary"  runat="server" Text="Send Email" OnClick="btnsendmail_Click" />
                    <asp:Button ID="btnReset" CssClass="btn btn-primary"  runat="server" Text="Reset" />
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
                <div class="col-md-12 col-sm-12">
                    <div id="divagentlist" class="display nowrap mytables"></div>
                </div>

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
                    <h4 style="font-family: Calibri;"><b>Ledger Name :- Sales Return Invoice  </b></h4>
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

                            <asp:BoundField DataField="sSalesReturnNo" HeaderText="Invoice No" />
                             <asp:TemplateField HeaderText="Invoice Date">
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btnsearch").on("click", function () {
                if (validatedata()) {
                    loaddata();
                }
            });
        });

        function validatedata() {
            var itemname = document.getElementById("<%=ddlItemName.ClientID %>").value;
            var fromdt = document.getElementById("<%=txtdtFrom.ClientID %>").value;
            var todate = document.getElementById("<%=txtdtToDate.ClientID %>").value;
            var validation = true;
            if (itemname == "" || itemname == "0") {
                $("#lblitemname").show();
                validation = false;
            }
            if (fromdt == "" || fromdt == "0") {
                $("#lblfromdate").show();
                validation = false;
            }
            if (todate == "" || todate == "0") {
                $("#lbltodate").show();
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
            var itemid = $("#ctl00_ContentPlaceHolder1_ddlItemName option:selected").val();
            $.ajax({
                url: '<%=ResolveUrl("titem_ledger_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate, itemid: itemid }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Invoice Date</td><td>Invoice No</td><td>Vendor / Customer</td><td>Item Name</td><td>P. Qty</td><td>P. Rate</td><td>S. Qty</td><td>S. Rate</td><td>Balance Qty</td><td>G Total</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].InvoiceDate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].InvoiceNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Customer + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].ItemName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PQty + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PRate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SQty + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SRate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].BalQty + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].GTotal + '</td>';
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
    <script>
        function validation() {

            var z = 0;
            if ($("#ctl00_ContentPlaceHolder1_ddlItemName option:selected").val() == "0") {
                if ($("#ctl00_ContentPlaceHolder1_ddlItemName").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_ddlItemName").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_ddlItemName").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the Item.</span>");

                }
                z++;
            }


            if ($("#ctl00_ContentPlaceHolder1_txtdtFrom").val() == "") {
                if ($("#ctl00_ContentPlaceHolder1_txtdtFrom").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_txtdtFrom").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_txtdtFrom").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please enter Start date.</span>");
                    $("#ctl00_ContentPlaceHolder1_txtdtFrom").focus();
                }
                z++;
            }
            if ($("#ctl00_ContentPlaceHolder1_txtdtToDate").val() == "") {
                if ($("#ctl00_ContentPlaceHolder1_txtdtToDate").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_txtdtToDate").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_txtdtToDate").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please enter End Date.</span>");
                    $("#ctl00_ContentPlaceHolder1_txtdtToDate").focus();
                }
                z++;
            }

            return z;
        }
    </script>


</asp:Content>
