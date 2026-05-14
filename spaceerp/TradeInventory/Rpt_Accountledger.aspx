<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Rpt_Accountledger.aspx.cs" Inherits="Admin_Rpt_Accountledger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%-- <link href="../Admin/css/bootstrap.css" rel="stylesheet" />--%>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
   
       
      <%--  <script src=" https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css"></script>--%>
    <script src="https://cdn.datatables.net/buttons/1.6.2/css/buttons.dataTables.min.css"></script>
         <link href="../DataTables/datatables.css" rel="stylesheet" />   
         <link href="../DataTables/datatables.min.css" rel="stylesheet" />
        <script src="../DataTables/datatables.js"></script>
        <script src="../DataTables/datatables.min.js"></script>   
        <script src="../DataTables/TableTools.js"></script>
    
   
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        	
   /*loader css style start*/
        .overlay {
            position: fixed;
            z-index: 99;
            top: 0px;
            left: 0px;
            background-color: #FFFFFF;
            width: 100%;
            height: 100%;
            filter: Alpha(Opacity=90);
            opacity: 0.9;
            -moz-opacity: 0.9;
        }

        /*loader css style end*/
 
th { white-space: nowrap; }
        /*.card-title {
                        text-align: center;
                        padding: 10px;
                        font-weight: 600;
                        border: 1px solid #0098da;
                    }*/
        .nav-tabs > li > a:hover {
            background: #0098da;
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

        .nav-tabs {
            border-bottom: 1px solid #003580;
            background: blue;
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
            border: 1px solid #0d6795;
        }

        .table {
            text-align: center !important;
            border: 1px solid #0098da !important;
            background: white;
            /*margin-left: 15px;*/
        }

            .table th {
                background: blue !important;
                color: white !important;
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

        .btn-primary {
    background: linear-gradient(to left, #0098da, #003580);
    border: none !important;
    color: white !important;
}

            .btn-primary:hover, .btn-primary:focus {
                background: linear-gradient(to left, #003580, #0098da);
                border: none !important;
            }

        .btn-warning {
            background: linear-gradient(to left, #ffcc00, #f0ad4e);
        }

            .btn-warning:hover {
                background: linear-gradient(to left, #f0ad4e, #ffcc00);
            }

        .btn-danger {
            background: linear-gradient(to left, #c82333, #ff568f);
        }

            .btn-danger:hover {
                background: linear-gradient(to left, #ff568f, #c82333);
            }

        .btn-default {
            background: linear-gradient(to left, #0098da, #0e6390);
            border: none !important;
            color: white !important;
        }

            .btn-default:hover {
                background: linear-gradient(to left, #0e6390, #0098da);
                border: none !important;
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
    <div class="tab-success">
                <%--to copy--%>
        <style>
        .bg-blue{
            background:blue;
        }
        .well {
            padding: 0px;
        }
    </style>
        <div class="well text-center bg-blue">       
        <h3 class="text-white">Search Agent Wise Cash/Online  Account Ledger </h3>
        </div>
        <%--  loader div start--%>
             <div class="overlay" style="display: none">
        <div class="center-block" style="position: fixed; left: 50%; top: 50%; font-size: 15px">
            <div>
                <img src="../images/Preloader_2.gif" width="100%"  />
            </div>

        </div>
    </div>

          <%-- loader div end--%>
        <%--to copy--%>
       
         <div id="divlist"></div>
        <div class="col-sm-12 well-sm" id="divcontrols" runat="server">
                         
                <AjaxToolKit:ConfirmButtonExtender ID="btnSendMail_confirmbuttonextender" runat="server"
                                    DisplayModalPopupID="btnSendMail_modalpopupextender" TargetControlID="btnSendMail" />
                                <AjaxToolKit:ModalPopupExtender ID="btnSendMail_modalpopupextender" runat="server"
                                    BackgroundCssClass="modalBackground" CancelControlID="btnClose" OkControlID="btnSend"
                                    PopupControlID="PNL0" TargetControlID="btnSendMail" />
                              
                                  <br />
                                <asp:Panel ID="PNL0" runat="server" Style="display: none; background-color: white; width: 400px; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
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
                                        <div class="text-center">
                                           <%-- <asp:CheckBox ID="chkexcel" runat="server" Text="Excel" /> 
                                                 <asp:CheckBox ID="chkpdf" runat="server" Text="Pdf" />--%>  
                                                 <asp:LinkButton ID="lnkAttachment" runat="server" Style="font-size: 11px; color: black;" Visible="false"></asp:LinkButton>
                                             <asp:LinkButton ID="lnkpdf" runat="server" Style="font-size: 11px; color: black;" Visible="false" ></asp:LinkButton>
                                             <asp:RadioButton runat="server" ID="rbexcel" Text="Excel" />
                                            <asp:RadioButton runat="server" ID="rbpdf" Text="pdf" />
                                          </div>

                                        </div>
                                    </div>
                                    <div style="text-align: right;">
                                        <asp:Button ID="btnSend" runat="server" Text="Send" Style="color: black;display:none;" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" Style="color: black;" />
                                    </div>
                                </asp:Panel>  
                                 </div>
    </div>
    
     <!--mail success Modal -->
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
        <span style="color:black">Email has been sent successfully</span>
          <asp:Label runat="server" ID="lblerrormsg" ></asp:Label>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal" id="popupclose">Close</button>      
      </div>
    </div>
  </div>
</div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).ajaxStart(function () {
                $(".overlay").show();
            }).ajaxStop(function () {
                $(".overlay").hide();
            });
            //   //redio button click and unclick
            $("#ctl00_ContentPlaceHolder1_rbexcel").on("click", function () {

                var previousValue = $(this).attr('previousValue');
                var name = $(this).attr('name');

                if (previousValue == 'checked') {
                    $(this).removeAttr('checked');
                    $(this).attr('previousValue', false);
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_rbexcel").attr('previousValue', false);
                    $(this).attr('previousValue', 'checked');
                }
            });

            $("#ctl00_ContentPlaceHolder1_rbpdf").on("click", function () {

                var previousValue = $(this).attr('previousValue');
                var name = $(this).attr('name');

                if (previousValue == 'checked') {
                    $(this).removeAttr('checked');
                    $(this).attr('previousValue', false);
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_rbpdf").attr('previousValue', false);
                    $(this).attr('previousValue', 'checked');
                }
            });

            
              $.ajax({
                url: '<%=ResolveUrl("Rpt_Accountledger.aspx/getdata1") %>',
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    // if(data.d !=""){
                    var val = [];
                    if (data.d != "") {


                        var strval = data.d.split(',');
                        val = val.concat(strval);
                        $('li.class1').hide(); $('li.class2').hide(); $('li.class3').hide(); $('li.class4').hide(); $('li.class5').hide(); $('li.class6').hide(); $('li.class7').hide(); $('li.class8').hide(); $('li.class9').hide(); $('li.class10').hide(); $('li.class11').hide(); $('li.class12').hide(); $('li.class13').hide(); $('li.class14').hide(); $('li.class15').hide(); $('li.class16').hide();
                        $('li.class17').hide(); $('li.class19').hide(); $('li.class21').hide(); $('li.class23').hide(); $('li.class25').hide(); $('li.class27').hide(); $('li.class29').hide(); $('li.class31').hide(); $('li.class33').hide(); $('li.class35').hide(); $('li.class37').hide(); $('li.class39').hide(); $('li.class41').hide();
                        $('li.class18').hide(); $('li.class20').hide(); $('li.class22').hide(); $('li.class24').hide(); $('li.class26').hide(); $('li.class28').hide(); $('li.class30').hide(); $('li.class32').hide(); $('li.class34').hide(); $('li.class36').hide(); $('li.class38').hide(); $('li.class40').hide(); $('li.class42').hide();

                        for (var i = 0; i < val.length; i++) {
                            var cls = "class" + val[i] + "";
                            //  alert(cls);
                            $("li.class" + val[i] + "").show();

                          
                        }
                       
                    }
                },
                error: function (errormessage) {
                    alert("error");
                }
              });
      
    
            $(document.body).on("change", "#ctl00_ContentPlaceHolder1_txtTo", function () {
                $("#ctl00_ContentPlaceHolder1_btnSend").css('display', '');
            });


            $("#popupclose").on("click", function () {
                $("#btnsearch").trigger("click");
            });

            $("#ctl00_ContentPlaceHolder1_ddluser").change(function () {

                if ($(this).val() == "0") {
                    if ($(this).parent().find("span").length > 0) {
                        //do Nothing
                    }
                    else {
                        $(this).css("border-color", "red");
                        $(this).parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the User.</span>");

                    }
                }
                else {
                    $(this).css("border-color", "");
                    $(this).parent().find("span").remove();
                }
            });
            $("#ctl00_ContentPlaceHolder1_ddlAgent").change(function () {

                if ($(this).val() == "0") {
                    if ($(this).parent().find("span").length > 0) {
                        //do Nothing
                    }
                    else {
                        $(this).css("border-color", "red");
                        $(this).parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the Agent.</span>");

                    }
                }
                else {
                    $(this).css("border-color", "");
                    $(this).parent().find("span").remove();
                }
            });
            $("#ctl00_ContentPlaceHolder1_txtFromDate").change(function () {

                if ($(this).val() == "") {
                    if ($(this).parent().find("span").length > 0) {
                        //do Nothing
                    }
                    else {
                        $(this).css("border-color", "red");
                        $(this).parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the Date.</span>");

                    }
                }
                else {
                    $(this).css("border-color", "");
                    $(this).parent().find("span").remove();
                }
            });
            $("#ctl00_ContentPlaceHolder1_txtToDate").change(function () {

                if ($(this).val() == "") {
                    if ($(this).parent().find("span").length > 0) {
                        //do Nothing
                    }
                    else {
                        $(this).css("border-color", "red");
                        $(this).parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the Date.</span>");

                    }
                }
                else {
                    $(this).css("border-color", "");
                    $(this).parent().find("span").remove();
                }
            });
            $("#btnsearch").on("click", function () {
                var k = validation();
                if (k != 0) {
                    return false;
                }
                else {

                    var fromdate = $("#ctl00_ContentPlaceHolder1_txtFromDate").val();
                    var todate = $("#ctl00_ContentPlaceHolder1_txtToDate").val();
                    var usertype = $("#ctl00_ContentPlaceHolder1_ddluser option:selected").val();
                    var agentid = $("#ctl00_ContentPlaceHolder1_ddlAgent option:selected").val();
                    $.ajax({
                        url: '<%=ResolveUrl("Rpt_Accountledger.aspx/accountdata") %>',
                        type: "post",
                        data: JSON.stringify({ fromdate: fromdate, todate: todate, usertype: usertype, agentid: agentid }),

                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (mainlist) {
                            var html = "<table id='tblagentlist' class='table table-bordered table-striped'><thead style='background: linear-gradient(90deg, #ff0015 31%, #595959 69%); color: white'><tr><th style='color: white;display:none'>user id</th><th style='color: white;display:none'>UserType ID</th><th style='color: white'>Ref No</th><th style='color: white'>Agency Name</th><th style='color: white'>Date of Deposit</th><th style='color: white'>Description</th><th style='color: white'>Debit Amount</th><th style='color: white'>Credit amount</th><th style='color: white;'>Balance</th></tr></thead><tbody>";
                            for (i = 0; i < mainlist.d.listdata.length; i++) {
                                html += '<tr>';
                                html += '<td style="display:none" >' + mainlist.d.listdata[i].objnuerid + '</td>';
                                html += '<td style="display:none" >' + mainlist.d.listdata[i].objnusertypeid + '</td>';
                                html += '<td  style="color:black">' + mainlist.d.listdata[i].objref + '</td>';
                                html += '<td style="color:black" >' + mainlist.d.listdata[i].objagencyname + '</td>';
                                html += '<td style="color:black" >' + mainlist.d.listdata[i].objdtDateOfDeposit + '</td>';
                                html += '<td style="color:black">' + mainlist.d.listdata[i].objdescription + '</td>';
                                if (i == 0) {
                                    html += '<td style="color:black"></td>';

                                }
                                else {
                                    html += '<td style="color:black">' + mainlist.d.listdata[i].objdebit + '</td>';
                                }

                                html += '<td style="color:black">' + mainlist.d.listdata[i].objcreditamount + '</td>';

                                if (i == 0) {
                                    html += '<td style="color:black"></td>';
                                }
                                else {
                                    html += '<td style="color:black">' + mainlist.d.listdata[i].objbalance + '</td>';
                                }

                            }
                            //   html += "</tbody><tfoot><tr> <th colspan='3' style='text-align:right'>Total:</th><th colspan='4' style='text-align:right'>" + mainlist.d.listbalancedata[0].objcredit + "</th><th colspan='5' style='text-align:right'>" + mainlist.d.listbalancedata[0].objdebit + "</th><th colspan='6' style='text-align:right'>" + mainlist.d.listbalancedata[0].objbalance + "</th></tr></tfoot></table>";
                            //  html += "</tbody><tfoot></tfoot></table>";
                            html += "</tbody><tfoot style='background-color:#ccc'>";
                            for (var j = 0; j < mainlist.d.listbalancedata.length; j++) {
                                html += '<tr>';
                                html += '<td style="display:none"></td><td style="display:none" ></td><td></td><td></td><td></td><td  style="text-align: right;color:black"><b> Total</b></td> <td style="text-align: center;font-weight:bold;color:black"><b>' + mainlist.d.listbalancedata[0].objdebit + '</b></td><td style="color:black">' + mainlist.d.listbalancedata[0].objcredit + '</td><td style="color:black">' + mainlist.d.listbalancedata[0].objbalance + '</td>'
                                //html += '<td style="display:none">' + invoicelistdemo.d.invoiceid[j].Totalvalue + '</td>';
                                html += '</tr>';
                            }
                            html += "</tfoot></table>";
                            $("#divlist").html(html);
                            var table = $("#tblagentlist").DataTable({
                                //"pageLength": 10,
                                //"orderCellsTop": true,
                                //"bLengthChange": false,
                                "bRetrieve": true,
                                "retrieve": true,
                                "orderCellsTop": true,
                                "bRetrieve": true,
                                "bLengthChange": false,

                                //"scrollX": true,
                                // "pageLength": 20,
                                //"scrollY": calcDataTableHeight(),
                                "scrollCollapse": true,
                                //  "sScrollXInner": "80%",
                                //  "scrollX": true,
                                "paging": true,
                                //"columnDefs": [{
                                //    "targets": 1,
                                //    "data": "img",

                                //    'render': function (data, type, full, meta) {
                                //        return '<img src="' + data + '';
                                //    }
                                //}],
                                //"columnDefs" : [{
                                //    "targets" : 0 ,
                                //    "data": "img",
                                //    "render": function (url, type, full) {
                                //        return '<img height="75%" width="75%" src="' + full[1] + '"/>';
                                //    }
                                //    }]
                                //language: {
                                //    searchPlaceholder: "Agency Name/Id/Agent Name/City"
                                //},
                                //             dom: 'Bfrtip',
                                //             buttons: [
                                //'copy', 'csv', 'excel', 'pdf', 'print'
                                //             ]
                            });
                            //$(".input[type=search]").attr("placeholder", "Agent name")


                        },
                        error: function (errormessage) {
                            alert("error");
                        }
                    });
                }
            });

            $(".datepicker-2").datepicker({

                formatDate: 'dd-mm-yyyy',
                autoClose: true,
                limitNextMonth: 3,
                numCalendar: 1,
                dateRangesHover: false
            });



        });

    </script>
    <script>
        function validation() {

            var z = 0;
            if ($("#ctl00_ContentPlaceHolder1_ddluser option:selected").val() == "0") {
                if ($("#ctl00_ContentPlaceHolder1_ddluser").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_ddluser").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_ddluser").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the user.</span>");

                }
                z++;
            }

            if ($("#ctl00_ContentPlaceHolder1_ddlAgent option:selected").val() == "0") {
                if ($("#ctl00_ContentPlaceHolder1_ddlAgent").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_ddlAgent").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_ddlAgent").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the Agent.</span>");

                }
                z++;
            }

            if ($("#ctl00_ContentPlaceHolder1_txtFromDate").val() == "") {
                if ($("#ctl00_ContentPlaceHolder1_txtFromDate").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_txtFromDate").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_txtFromDate").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please select the date.</span>");
                    $("#ctl00_ContentPlaceHolder1_txtFromDate").focus();
                }
                z++;
            }
            if ($("#ctl00_ContentPlaceHolder1_txtToDate").val() == "") {
                if ($("#ctl00_ContentPlaceHolder1_txtToDate").parent().find("span").length > 1) {
                    //do nothing
                }
                else {
                    $("#ctl00_ContentPlaceHolder1_txtToDate").css("border-color", "red");
                    $("#ctl00_ContentPlaceHolder1_txtToDate").parent().append("<span style='color:red;font-size:15px' class='spanerror'>Please enter the Date.</span>");
                    $("#ctl00_ContentPlaceHolder1_txtToDate").focus();
                }
                z++;
            }

            return z;
        }
    </script>
</asp:Content>

