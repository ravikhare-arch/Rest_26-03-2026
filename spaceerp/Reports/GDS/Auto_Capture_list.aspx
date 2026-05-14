<%@ Page Title="Page Master" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Auto_Capture_list.aspx.cs" Inherits="Auto_Capture_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
      <%--<style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top: 0px;
            margin-bottom: 0;
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
        .form-control{
            padding: 6px 5px;
        }
    </style>--%>
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

        .btn-primary {
            background: linear-gradient(to left, #0e6390, #00bcd4);
            border: none !important;
        }

            .btn-primary:hover, .btn-primary:focus {
                background: linear-gradient(to left, #0e6390, #00bcd4);
                border: none !important;
            }

        .btn-warning {
            background: linear-gradient(to left, #862359, #f0ad4e);
        }

            .btn-warning:hover {
                background: linear-gradient(to left, #423f9c, #f0ad4e);
            }

        .btn-danger {
            background: linear-gradient(to left, #c82333, #ff568f);
        }

            .btn-danger:hover {
                background: linear-gradient(to left, #ff568f, #c82333);
            }

        .btn-default {
            background: linear-gradient(to left, #00bcd4, #0e6390);
            border: none !important;
            color: white !important;
        }

            .btn-default:hover {
                background: linear-gradient(to left, #0e6390, #00bcd4);
                border: none !important;
            }


        .frm_sec {
            border: 1px solid #0098da;
            margin: 0;
            border-radius: 4px;
            box-shadow: 0 4px 3px 0;
        }

        .destination {
            border-right: 1px solid #0098da;
        }
    </style>
    <style>
        .modal {
            top: 50% !important;
            left: 22% !important;
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
        .row {
            display: -ms-flexbox;
            display: inherit;
        }
    </style>

    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>
            <h4 class="panel-title">Auto Capture (AIR File)</h4>
                    </div>
        <div class="panel-body">
          <div class="col-sm-12 text-center center-block well-sm">
              
              <div class="col-md-3">
                          <asp:TextBox ID="txtfromdate" runat="server" Width="100%" CssClass="form-control datepicker"  placeholder="DD/MM/YYYY"></asp:TextBox>
              </div>
              <div class="col-md-3">
                               <asp:TextBox ID="txttodate" runat="server" Width="100%" CssClass="form-control datepicker"  placeholder="DD/MM/YYYY"></asp:TextBox>
               </div>
               <div class="col-md-2">
                                <label>&nbsp;</label>
                                <input type="button" id="btnsearch" class="btn btn-primary form-control mt-2" style="background-color: #004080" title="Search" value="Search" />
                            </div>   
              <div class="col-md-6">
                  <asp:Button ID="btnexcel" CssClass="btn btn-primary" style="background-color:#004080" runat="server" Text="Excel" OnClick="btnexcel_Click1"  />
               <asp:Button ID="btnpdf" CssClass="btn btn-primary" style="background-color:#004080" runat="server" Text="Pdf"  />
               <asp:Button ID="btnprint" CssClass="btn btn-primary" style="background-color:#004080" runat="server" Text="Print"  />
                   <asp:Button ID="btnsendmail" CssClass="btn btn-primary" style="background-color:#004080" runat="server" Text="sendmail"  />            
                 </div>     
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
                                        <div class="row">
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
                                        <asp:Button ID="btnSend" runat="server" Text="Send" Style="color: black;" />
                                        <asp:Button ID="btnClose" runat="server" Text="Close" Style="color: black;" />
                                    </div>
                                </asp:Panel>         
                               
             </div>
            <div>
                <div id="divagentlist"></div>
            </div>
        </div>
    </div>

    <script type="text/javascript">


        $(document.body).ready(function () {
            $("#btnsearch").on("click", function () {
                loaddata();
            });
        });


        function loaddata() {
            var fromdate = $("#ctl00_ContentPlaceHolder1_txtfromdate").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttodate").val();
            $.ajax({
                url: '<%=ResolveUrl("Auto_Capture_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate }),
                 contentType: "application/json;charset=utf-8",
                 dataType: "json",
                 success: function (mainlist) {
                     var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Journey Type</td><td>Air Numeric</td><td>Air PNR</td><td >PAX Name</td><td>PAX Mob</td><td>PAX Email</td><td>Travel Date</td><td>Return Date</td><td>Booking Sign</td><td>IATA Comm.</td><td>AIR PLB</td><td>Fare Basis</td><td> Tax Details</td><td>Cancellation</td><td>Tour Code</td><td>Ticket No</td><td>PNR No</td><td>CRS</td><td>PCC</td><td>IATA No.</td><td>PAX Type</td><td>Sector From</td><td>Sector To</td><td>File Name</td><td>Process Date</td><td>Process Time</td><td>Staff Sign</td><td>Issue Date</td><td>Currency</td><td>Basic Fare</td><td> Total TAX</td><td>Grand Total</td><td>MF</td><td>Billig</td></tr></thead><tbody>";
                     var vcount = 0;
                     for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                         //html += '<tr data-name>';
                         vcount = vcount + 1;
                         html += '<tr>';
                         html += '<td >' + vcount + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].JourneyType + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].AirNumeric + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].AirPNRNo + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PAXName + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PAXMobile + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PAXEmail + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].TravelDate + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].ReturnDate + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].BookSign + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].IATAComm + '</td>';
                         html += '<td > </td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].FareBasis + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].Cancellation + '</td>';

                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].TourCode + '</td>';
                         html += '<td > </td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].TicketNo + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PNRNo + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].IATANo + '</td>';

                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].CRS + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PCC + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].PAXType + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].SectorFrom + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].SectorTO + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].FileName + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].ProcessDate + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].ProcessTime + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].StaffSign + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].IssueDate + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].Currency + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].BasicFare + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].TotalTax + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].GrandTotal + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].MF + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].Billing + '</td>';
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
                             searchPlaceholder: "Ticket No / PNR"
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
