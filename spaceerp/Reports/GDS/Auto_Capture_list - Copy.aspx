<%@ Page Title="Page Master" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="Auto_Capture_list.aspx.cs" Inherits="Auto_Capture_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" rel="stylesheet" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


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
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">

            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Auto Capture (AIR File) </h4>




        </div>
        
        <div class="panel-body">
            <div class="tab-success">
                <ul class="nav nav-tabs" style="background: linear-gradient(90deg, #595959 109%) !important;" role="tablist">

                    <li class="nav-item tab2">

                        <a href="#" class="nav-link" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New</a>

                    </li>

                </ul>

            </div>
                

            <div>
               
                <div id="divagentlist"></div>
            </div>
            <!--create/edit Modal popup -->

           
        </div>
    </div>
    <script type="text/javascript">


        $(document.body).ready(function () {
            loaddata();            
        });
              

         function loaddata() {

             $.ajax({
                 url: '<%=ResolveUrl("Auto_Capture_list.aspx/loaddata") %>',
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Journey Type</td><td>Air Numeric</td><td>Air PNR</td><td >PAX Name</td><td>PAX Mob</td><td>PAX Email</td><td>Travel Date</td><td>Return Date</td><td>Booking Sign</td><td>IATA Comm.</td><td>AIR PLB</td><td>Fare Basis</td><td> Tax Details</td><td>Cancellation</td><td>MF</td><td>Billig</td><td>Tour Code</td><td>Ticket No</td><td>PNR No</td><td>CRS</td><td>PCC</td><td>IATA No.</td><td>PAX Type</td><td>Sector From</td><td>Sector To</td><td>File Name</td><td>Process Date</td><td>Process Time</td><td>Staff Sign</td><td>Issue Date</td><td>Currency</td><td>Basic Fare</td><td> Total TAX</td><td>Grand Total</td></tr></thead><tbody>";
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
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].MF + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Billing + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].TourCode + '</td>';
                        html += '<td > </td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].TicketNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PNRNo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].IATANo + '</td>';
                       
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].CRS + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PCC + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].PAXType + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SectorFrom + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].SectorTo + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].FileName + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].ProcessDate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].ProcessTime + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].StaffSign + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].IssueDate + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].Currency + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].BasicFare + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].TotalTax + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].GrandTotal + '</td>';
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
