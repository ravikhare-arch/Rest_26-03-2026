<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintwithoutGST.aspx.cs" Inherits="Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Bootstrap Core CSS -->

    <title>Bill</title>
    <script src="js/jquery-3.6.0.js"></script>
    <!--//skycons-icons-->
    <link href="css/customprint.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />

    <style media="print">
        .nav-tabs {
            display: none;
        }
    </style>
    <script>

        $(document).ready(function () {
            window.print();
        });

    </script>
    <style>
        @media print {
            body, embed, html{
                overflow: hidden !important;
            }
            td {
                /*padding: 5px 0 5px 15px;*/
                border-bottom: 1px dashed black;
            }
            .title {
                border-top: 1px dashed black;
                margin-top: 20px;
            }
            #OrderRow td {
                border: none !important;
            }
            .tabletitle {
                font-size: .5em;
                background: lightgrey;
            }
            #menutab {
                display: none !important;
                visibility: hidden !important;
            }
            .nav-tabs {
                display: none !important;
            }
            #invoice-POS {
                width: 100% !important;
                margin: 0 !important;
                box-shadow: none !important;
            }
            .nav-tabs .nav-link {
                display: none !important;
            }
            .content-page .content {
                margin-top: 0px !important;
            }
            .enlarged #wrapper .left.side-menu{
                display: none !important;
                width: 0 !important;
            }
            .enlarged #wrapper .content-page {
                margin-left: 0px !important;
            }

        }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <input type="hidden" runat="server" id="hdnApiurl" />
        <div id="invoice-POS">
            <div id="top">
                <div class="info">
                    <div class="headerTitle">Redaan Restaurant</div>
                    <div class="headerAddress">
                        SHOP NO. 4B-4C, Opp Kalpana Cinema
            L.B.S Marg, Kurla (West), Mumbai 400070<br />
                        <%-- Email   : JohnDoe@gmail.com<br>--%>
            Ph: 555-555-5555, 222-222-2222<br />
                    </div>

                </div>
                <!--End Info-->
            </div>
            <!--End InvoiceTop-->

            <div id="mid">
                <div class="info">
                    <div class="headerSubTitle">K.O.T Print</div>
                    <div class="orderNo">
                        Token No.# <span id="Order #"></span>:<span id="lblorderno"></span>
                    </div>
                    <div class="tableNo">
                        Table No. : <span></span>:<span id="lblheading"></span>
                    </div>
                    <div class="orderNo">
                        Captain Name. <span></span>:<span> Veer Chandra</span>
                    </div>
                    <div class="tableNo">
                        Date &amp; Time: <span></span>:<span id="lbldatetime"></span>
                    </div>

                </div>
            </div>
            <div id="bot">
                <div id="table">
                    <table>
                        <thead>
                            <tr class="tabletitle">
                                <th scope="col">Particulars</th>
                                <th scope="col">Rate</th>
                                <th scope="col">Qty.</th>
                                <th scope="col">Total</th>
                            </tr>
                        </thead>
                        <tbody id="OrderRow">
                        </tbody>

                    </table>
                </div>
                <div class="flex">
                    <div class="totals">
                        <div class="section">
                            <div class="row">
                                <div class="col1"></div>
                                <div class="col2">Sub-Total</div>
                                <div class="col3"><strong id="billamount"></strong></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="legalcopy">
                    <div class="keepItl">
                        <strong>Thank you.Do visit again.</strong>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">

        var apiUrl = $("[id$='hdnApiurl']").val();

        $(document).ready(function () {
            var id = getUrlVars()["id"];
            var orderType = getUrlVars()["orderType"];
            SetTextValue(orderType);
            //Contains Items from that Order
            DisplayOrderItems(id);
            $("#lbldatetime").html(setdate);
            if (id != null && id != "") {

                //Get Summation of Data from SalesOrderDetail so that we can avoid Loop
                $.ajax({
                    type: "GET",
                    url: apiUrl + '/api/Item/SummationofOrders/' + id + '',
                    dataType: "json", contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        for (let r of data)
                        {
                            $("#billamount").html(r.TotalAmount);
                            $("#lblCGST").html(r.CGST);
                            $("#lblSGST").html(r.SGST);
                            $("#lblgrandtotal").html(r.GrandTotal);
                            $("#lblorderno").html(r.OrderNo);
                        }
                    }
                });
            }

        });
        function DisplayOrderItems(id) {
            $.ajax({
                type: "GET",
                url: apiUrl + '/api/Item/OrderDetailbyOrderID/' + id + '',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var orderDetail = "";
                    $.each(data, function (i) {
                        orderDetail +=
                                   '<tr><td><a href="#">' + data[i].ProductName + '</a></td><td id="' + data[i].SalesOrderDetailID + '" class="OneUnitPrice">' + data[i].ActualCost + '</td><td class="ng-tns-c8-2" >' + data[i].ProductQty + '</td>' +
                   '<td class="totalPrice">' + data[i].TotalAmount + ' </td></tr>'

                    });

                    $("#OrderRow").append(orderDetail);

                }

            });
        };

        function getUrlVars() {
            var vars = [], hash;
            var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < hashes.length; i++) {
                hash = hashes[i].split('=');
                vars.push(hash[0]);
                vars[hash[0]] = hash[1];
            }
            return vars;
        }
        function SetTextValue(orderType) {
            var jsLang = orderType;
            switch (jsLang) {
                case "1":
                    $("#lblheading").html('Take Away');
                    break;
                case "2":
                    $("#lblheading").html('Door Delivery');
                    break;
                case "3":
                    $("#lblheading").html('Dine-In');
                    break;
            }
        }
        function setdate() {
            var d = new Date(),
    minutes = d.getMinutes().toString().length == 1 ? '0' + d.getMinutes() : d.getMinutes(),
    hours = d.getHours().toString().length == 1 ? '0' + d.getHours() : d.getHours(),
    ampm = d.getHours() >= 12 ? 'pm' : 'am',
    months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
    days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
            return days[d.getDay()] + ' ' + months[d.getMonth()] + ' ' + d.getDate() + ' ' + d.getFullYear() + ' ' + hours + ':' + minutes + ampm;
        }

    </script>
</body>
</html>
