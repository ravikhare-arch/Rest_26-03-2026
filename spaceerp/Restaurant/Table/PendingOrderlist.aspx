<%@ Page Title="Pending Orders" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="PendingOrderlist.aspx.cs" Inherits="PendingOrderlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
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
        #div1, #div2 {
            width: 1500px !important;
        }
    </style>
    <link href="../../css/customDataTable.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
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
           
            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server"  CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                 
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Pending Sales Order</h4>




        </div>
        <div class="panel-body">
            <div id="wrapper1">
                <div id="div1">
                </div>
            </div>
            <div id="wrapper2">
                <div id="div2">
                <div id="divpendingorders"></div>
            </div>
          </div>
        </div>
    </div>

     <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Cancel Order</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to Cancel Order?</label>
                    <label style="color: black; display: none;" id="lblsucess">Order Cancelled..!!!</label>


                    <label id="orderid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Cancel</button>

                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">        

        var storedData = localStorage.getItem("CompanyListObj"); // Agar localStorage use kiya toh localStorage likhna

        if (storedData) {
            // String ko wapas JSON array/object me convert kiya
            var companyDataArray = JSON.parse(storedData);
            console.log(companyDataArray);

            // Ab tum is loop chala ke bind kar sakte ho dropdown ya table jahan bhi karna hai
        } else {
            console.log("Data nahi mila bhai, pehle main page visit karna padega.");
        }
        // 1. Global Variables for Company Data
        var compName = "", compAddress = "", compCity = "", compContact = "";
        var apiUrl = $("[id$='hdnApiurl']").val();
        $(document.body).ready(function () {

            var storedData = sessionStorage.getItem("CompanyListObj") || localStorage.getItem("CompanyListObj");

            if (storedData) {
                // String ko wapas JSON array/object me convert kiya
                var companyDataArray = JSON.parse(storedData);
                console.log("Data mil gaya bhai: ", companyDataArray);

                if (companyDataArray.length > 0) {
                    var comp = companyDataArray[0];
                    compName = comp.Name || "";
                    compAddress = comp.Address || "";
                    compCity = comp.City || "";
                    compContact = comp.Contactno || "";

                    // UI ke liye HTML format
                    var uiHtml = "<strong style='color: #004080; font-size:14px;'>" + compName + "</strong><br/>" +
                        compAddress + ", " + compCity + "<br/>" +
                        "<i class='fa fa-phone'></i> " + compContact;

                    $("#companySummaryUI").html(uiHtml);

                    // Hidden fields me set karna taaki C# (backend) Excel export me use kar sake
                    $("[id$='hdnCompName']").val(compName);
                    $("[id$='hdnCompAddress']").val(compAddress + ", " + compCity);
                    $("[id$='hdnCompContact']").val(compContact);

                    // Export (Excel/PDF) ke liye Plain Text format
                    exportMessage = compAddress + ", " + compCity + "\nMobile: " + compContact;
                }
            } else {
                console.log("Dono me se kisi bhi storage me data nahi hai bhai, pehle main page visit karna padega.");
            }



            loaddata();
            // 1. Get exact Order ID when Delete (Cancel) button is clicked
            $(document.body).on("click", ".deletebtn", function () {
                // 19 is the exact index of your hidden Order ID column
                var id = $(this).closest('tr').find('td:eq(19)').text().trim();

                // Use .text() instead of .val() for labels
                $("#orderid").text(id);
                $("#deletebutton").show();
            });

            // 2. Call the API when the Confirm button is clicked
            $(document.body).on("click", "#deletebutton", function () {
                // Read the ID using .text() 
                var id = $("#orderid").text().trim();

                // Safety check to ensure ID is not empty before making the API call
                if (!id) {
                    alert("Order ID missing. Cannot cancel order!");
                    return;
                }

                $.ajax({
                    type: "POST",
                    url: apiUrl + '/api/Item/CancelOrder/' + id,
                    contentType: "application/json; charset=utf-8",
                    // dataType: "json", <-- Remove this if your API returns a plain integer
                    success: function (response) {
                        if (parseInt(response) > 0) {
                            $("#lblsucess").css("display", "block");
                            $("#lbldelete").hide();
                            loaddata();
                            $("#deletebutton").hide();
                            $("#orderid").text(''); // Clear the label
                        } else {
                            $("#lblsucess").css("display", "block");
                            $("#lblsucess").text("Order could not be cancelled.");
                            $("#lbldelete").hide();
                        }
                    },
                    error: function (response) {
                        console.log(response);
                        alert("Error in API Call");
                    }
                });
            });
           
        });
        //function loaddata() {
        //    var tableStatus = "Pending";

        //    $.ajax({
        //        url: apiUrl + '/api/Item/PendingSalesOrder?tableStatus=' + tableStatus,
        //        type: "GET",
        //        contentType: "application/json;charset=utf-8",
        //        dataType: "json",
        //        success: function (data) {
        //            var vcount = 0;
        //            var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'>" +
        //                "<thead><tr>" +
        //                "<td style='width:2%'>Sr No.</td>" +
        //                "<td>Order ID</td>" +
        //                "<td>Room Number</td>" + // Room No Column
        //                "<td>Order Date</td>" +
        //                "<td>Start Time</td>" +
        //                "<td>Running Timer</td>" +
        //                "<td>Order Type</td>" +
        //                "<td>Customer</td>" +
        //                "<td>Table Name</td>" +
        //                "<td>Table Status</td>" +
        //                "<td>Total Amount</td>" +
        //                "<td>Total Discount</td>" +
        //                "<td>Charge</td>" +
        //                "<td>Total GST</td>" +
        //                "<td>Total Paid</td>" +
        //                "<td>Payment Status</td>" +
        //                "<td style='width:3%'>Go to Menu</td>" +
        //                "<td>Close Order</td>" +
        //                "<td>Cancel Order</td>" +
        //                "<td style='display:none;'>Order ID</td>" +
        //                "</tr></thead><tbody>";

        //            $.each(data, function (i) {
        //                vcount = vcount + 1;

        //                // 🔹 Ab sirf API wala data use hoga, LocalStorage hta diya hai
        //                var roomFromApi = data[i].RoomNumber;

        //                html += "<tr>";
        //                html += "<td> " + vcount + "</td>";
        //                html += "<td> " + data[i].OrderNo + "</td>";

        //                // Agar API se 0 ya null aaye toh "-" dikhayega, warna Room No
        //                html += "<td style='font-weight:bold;'> " + (roomFromApi && roomFromApi !== "0" ? roomFromApi : "-") + "</td>";

        //                html += "<td> " + data[i].OrderDate + " </td>";
        //                html += "<td> " + data[i].OrderTime + " </td>";
        //                html += "<td><b class='order-timer' data-start-time='" + data[i].OrderDate + " " + data[i].OrderTime + "'>00:00:00</b></td>";
        //                html += "<td> " + data[i].OrderTypeName + "</td>";
        //                html += "<td> " + data[i].CustomerName + "</td>";
        //                html += "<td> " + data[i].TableName + "</td>";
        //                html += "<td> " + data[i].TableStatus + "</td>";
        //                html += "<td> " + data[i].TotalOrderAmount + "</td>";
        //                html += "<td> </td>";
        //                html += "<td> " + data[i].Charge + "</td>";
        //                html += "<td> </td>";
        //                html += "<td> " + data[i].TotalPaid + "</td>";
        //                html += "<td> " + data[i].PaymentStatus + "</td>";

        //                // Action Buttons
        //                html += '<td><a href=/Take_away.aspx?orderType=' + data[i].OrderType + '&id=' + data[i].OrderID + '&status=' + data[i].TableStatus + '&TableID=' + data[i].TableID + ' class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green"></i></a></td>';
        //                // Close Order link mein roomNo parameter add kiya
        //                html += '<td><a href="/order.aspx?orderType=' + data[i].OrderType +
        //                    '&id=' + data[i].OrderID +
        //                    '&status=' + data[i].TableStatus +
        //                    '&TableID=' + data[i].TableID +
        //                    '&roomNo=' + (data[i].RoomNumber || "") + '" class="editbtn" title="Edit">' +
        //                    '<i class="glyphicon glyphicon-edit" style="color: green"></i></a></td>';
        //                html += '<td><a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a></td>';

        //                html += "<td style='display:none;'> " + data[i].OrderID + "</td>";
        //                html += "</tr>";
        //            });
        //            html += "</tbody><tfoot></tfoot></table>";

        //            $("#divpendingorders").html(html);

        //            $("#tblagentlist").DataTable({
        //                "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
        //                "iDisplayLength": 5,
        //                "paging": true,
        //                "ordering": true
        //            });
        //        },
        //        error: function (data) {
        //            alert("Error loading orders!");
        //        }
        //    });
        //}

        function loaddata() {
            var tableStatus = "Pending";

            $.ajax({
                url: apiUrl + '/api/Item/PendingSalesOrder?tableStatus=' + tableStatus,
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var vcount = 0;
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'>" +
                        "<thead><tr>" +
                        "<td style='width:2%'>Sr No.</td>" +
                        "<td>Order ID</td>" +
                        "<td>Room Number</td>" +
                        "<td>Order Date</td>" +
                        "<td>Start Time</td>" +
                        "<td>Running Timer</td>" +
                        "<td>Order Type</td>" +
                        "<td>Customer</td>" +
                        "<td>Table Name</td>" +
                        "<td>Table Status</td>" +
                        "<td>Total Amount</td>" +
                        "<td>Total Discount</td>" +
                        "<td>Charge</td>" +
                        "<td>Total GST</td>" +
                        "<td>Total Paid</td>" +
                        "<td>Payment Status</td>" +
                        "<td style='width:3%'>Go to Menu</td>" +
                        "<td>Close Order</td>" +
                        "<td>Cancel Order</td>" +
                        "<td style='display:none;'>Order ID</td>" +
                        "</tr></thead><tbody>";

                    $.each(data, function (i) {
                        vcount = vcount + 1;
                        var item = data[i]; // Short reference
                        var roomFromApi = item.RoomNumber;

                        // 1. Capture NC status and Encode for safety
                        var ncRadioVal = encodeURIComponent(item.NCRadio || "");

                        html += "<tr>";
                        html += "<td> " + vcount + "</td>";
                        html += "<td> " + item.OrderNo + "</td>";
                        html += "<td style='font-weight:bold;'> " + (roomFromApi && roomFromApi !== "0" ? roomFromApi : "-") + "</td>";
                        html += "<td> " + item.OrderDate + " </td>";
                        html += "<td> " + item.OrderTime + " </td>";
                        html += "<td><b class='order-timer' data-start-time='" + item.OrderDate + " " + item.OrderTime + "'>00:00:00</b></td>";
                        html += "<td> " + item.OrderTypeName + "</td>";
                        html += "<td> " + item.CustomerName + "</td>";
                        html += "<td> " + item.TableName + "</td>";
                        html += "<td> " + item.TableStatus + "</td>";
                        html += "<td> " + item.TotalOrderAmount + "</td>";
                        html += "<td> </td>";
                        html += "<td> " + item.Charge + "</td>";
                        html += "<td> </td>";
                        html += "<td> " + item.TotalPaid + "</td>";
                        html += "<td> " + item.PaymentStatus + "</td>";

                        // --- ACTION BUTTONS ME NC RADIO ADD KIYA ---

                        // Go to Menu Button (Take_away.aspx)
                        html += '<td><a href="/Take_away.aspx?orderType=' + item.OrderType +
                            '&id=' + item.OrderID +
                            '&status=' + item.TableStatus +
                            '&TableID=' + item.TableID +
                            '&roomNo=' + (item.RoomNumber || "") +
                            '&ncRadio=' + ncRadioVal + '" class="editbtn" title="Edit">' +
                            '<i class="glyphicon glyphicon-edit" style="color: green"></i></a></td>';

                        // Close Order Button (order.aspx)
                        html += '<td><a href="/order.aspx?orderType=' + item.OrderType +
                            '&id=' + item.OrderID +
                            '&status=' + item.TableStatus +
                            '&TableID=' + item.TableID +
                            '&roomNo=' + (item.RoomNumber || "") +
                            '&ncRadio=' + ncRadioVal + '" class="editbtn" title="Edit">' +
                            '<i class="glyphicon glyphicon-edit" style="color: green"></i></a></td>';

                        html += '<td><a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a></td>';
                        html += "<td style='display:none;'> " + item.OrderID + "</td>";
                        html += "</tr>";
                    });

                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divpendingorders").html(html);

                    $("#tblagentlist").DataTable({
                        "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                        "iDisplayLength": 5,
                        "paging": true,
                        "ordering": true
                    });
                },
                error: function (data) {
                    alert("Error loading orders!");
                }
            });
        }
        setInterval(function () {
            $(".order-timer").each(function () {
                var startTimeStr = $(this).attr("data-start-time");

                if (startTimeStr) {
                    try {
                        // Format handle karna: DD/MM/YYYY HH:MM:SS
                        var parts = startTimeStr.split(' ');
                        var dateParts = parts[0].split('/');
                        var timeParts = parts[1].split(':');

                        // JS Date (Year, Month-1, Day, Hour, Minute, Second)
                        var start = new Date(dateParts[2], dateParts[1] - 1, dateParts[0], timeParts[0], timeParts[1], timeParts[2] || 0);
                        var now = new Date();

                        var diff = Math.floor((now - start) / 1000);

                        if (diff >= 0) {
                            var hours = Math.floor(diff / 3600);
                            var minutes = Math.floor((diff % 3600) / 60);
                            var seconds = diff % 60;

                            var display = (hours < 10 ? "0" + hours : hours) + ":" +
                                (minutes < 10 ? "0" + minutes : minutes) + ":" +
                                (seconds < 10 ? "0" + seconds : seconds);

                            $(this).html(display);

                            // 15 Min alert logic
                            if (minutes >= 15 || hours > 0) {
                                $(this).css("color", "red");
                            } else {
                                $(this).css("color", "#28a745"); // Green
                            }
                        }
                    } catch (e) { console.error("Timer Error:", e); }
                }
            });
        }, 1000);
        

        
    </script>
    <script>
        var wrapper1 = document.getElementById('wrapper1');
        var wrapper2 = document.getElementById('wrapper2');
        wrapper1.onscroll = function () {
            wrapper2.scrollLeft = wrapper1.scrollLeft;
        };
        wrapper2.onscroll = function () {
            wrapper1.scrollLeft = wrapper2.scrollLeft;
        };
    </script>
</asp:Content>
