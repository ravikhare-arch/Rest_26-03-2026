<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill</title>
    <script src="js/jquery-3.6.0.js"></script>
    <!--//skycons-icons-->
    
    <link href="css/customprint.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    
    <style>
       #mid {
    width: 100%;
    max-width: 450px; /* Adjust as per your printer width */
    font-family: "Comic Sans MS", "Chalkboard SE", cursive; /* Same as your image */
    padding: 5px;
    color: #000;
}

.headerSubTitle {
    text-align: center;
    font-weight: bold;
    font-size: 22px;
    margin-bottom: 10px;
}

.info-row {
    display: flex;
    justify-content: space-between;
    margin-bottom: 8px;
    font-size: 18px;
    font-weight: bold;
}

/* Date section specific fix */
.date-row {
    display: flex;
    align-items: center;
    font-size: 18px;
    font-weight: bold;
    margin-top: 5px;
    white-space: nowrap; /* Prevents wrapping */
}

.label {
    flex-shrink: 0; /* Label ko dabne nahi dega */
}

#lbldatetime {
    margin-left: 5px;
    display: inline-block;
}

/* Formatting for the dashed line at bottom if needed */
.bottom-border {
    border-bottom: 1px dashed #000;
    margin-top: 10px;
}
.title td {
    white-space: nowrap; /* Isse text ek hi line mein rahega */
    padding: 2px 5px;
}
.title span {
    display: inline-block;
    width: 100%;
    text-align: right;
}
.info-row div {
    width: 50%; /* Dono sides ko barabar jagah milegi */
    display: inline-block;
    vertical-align: top;
}

.label {
    font-weight: bold;
}
.single-row {
    width: 100% !important;
    display: flex;
    align-items: center;
    gap: 5px;
}

.single-row .label {
    white-space: nowrap;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <input type="hidden" runat="server" id="hdnApiurl" />
        <div id="invoice-POS">
            <div id="top">
      <div class="info">         
        <div class="headerTitle">Hotel Premier Inn</div>
          <div class="headerAddress"> 
            SHOP NO. 4B-4C, Opp Kalpana Cinema
            L.B.S Marg, Kurla (West), Mumbai 400070<br />
           <%-- Email   : JohnDoe@gmail.com<br>--%>
            Ph: 555-555-5555, 222-222-2222<br />
        </div>

      </div><!--End Info-->
    </div>
            <!--End InvoiceTop-->

           <%-- <div id="mid">
                <div class="info">
                   <div class="headerSubTitle">Cash Memo</div>
                    <div class="orderNo">
    Token No.# <span id="Order #"></span>:<span id="lblorderno"></span>
  </div>            
                           <div class="tableNo">
    Table No. : <span></span>:<span id="lblheading"></span>
  </div>    
          <div class="orderNo">
            Captain Name. <span></span>:<span></span>
          </div>         
          <div class="orderNo">
             Room No. <span></span>:<span id="RoomNumber"></span>
          </div>            
                           <div class="orderNo">
    Date &amp; Time: <span></span>:<span id="lbldatetime"></span>
  </div>                    
                    
                </div>
            </div>--%>

            <div id="mid">
    <div class="info">
        <div class="headerSubTitle">Cash Memo</div>
        
        <div class="info-row">
            <div>
                <span class="label">Token No.# :</span>
                <span id="lblorderno"></span>
            </div>
            <div>
                <span class="label">Table No. :</span>
                <span id="lblTableName"></span>
            </div>
        </div>

        <div class="info-row">
            <div>
                <span class="label">Captain Name. :</span>
                <span id="sUserFullName"></span>
            </div>
            <div>
                <span class="label">Room No. :</span>
                <span id="RoomNumber"></span>
            </div>
        </div>

        <div class="date-row">
            <span class="label">Order Date & Time :</span>
            <span id="lblNewdatetime"></span>
        </div>
         <div class="date-row">
    <span class="label">Customer Name:</span>
    <span id="CustomerName"></span> </div>
        
        <div class="bottom-border"></div>
    </div>
</div>
            <!--End InvoiceTop-->
            <!--End Invoice Mid-->

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

    <div class="title">
        <table style="width: 100%; border-collapse: collapse;">
            <tbody>
                    <tr>
    <td>&nbsp;</td>
    <td style="text-align: right; padding-right: 10px; white-space: nowrap;">Total</td>
    <td style="text-align: right;"><span id="lblTotalPaid"></span></td>
</tr>
                    <tr>
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px; white-space: nowrap;">Service Charge</td>
                    <td style="text-align: right;"><span id="ServiceChargeValue"></span></td>
                </tr>
                <tr>
                    <td style="width: 50%;">&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px;">Sub-Total</td>
                    <td style="text-align: right;"><span id="subtotal_val"></span></td>
                </tr>
                <tr id="row_discount">
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px;">Discount (%)</td>
                    <td style="text-align: right;"><span id="billDiscount"></span></td>
                </tr>
                <tr id="row_after_discount" style="background-color: #f9f9f9;">
                                <td>&nbsp;</td>
                                <td class="text-right bold-text">Total After Disc.</td>
                                <td class="text-right bold-text"><span id="after_disc_total">0.00</span></td>
                            </tr>
                <tr id="showcgst">
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px; white-space: nowrap;">CGST (2.5%)</td>
                    <td style="text-align: right;"><span id="lblCGST"></span></td>
                </tr>
                <tr id="showsgst">
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px; white-space: nowrap;">SGST (2.5%)</td>
                    <td style="text-align: right;"><span id="lblSGST"></span></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px; white-space: nowrap;">Round Off</td>
                    <td style="text-align: right;"><span id="RoundOffValue"></span></td>
                </tr>

                 
                <tr class="tabletitle" style="border-top: 1px dashed #000;">
                    <td>&nbsp;</td>
                    <td style="text-align: right; padding-right: 10px; white-space: nowrap;"><strong>Grand Total</strong></td>
                    <td style="text-align: right;"><strong><span id="lblgrandtotal"></span></strong></td>
                </tr>
            </tbody>
        </table>
    </div>

    <div id="legalcopy" style="text-align:center; margin-top:10px;">
        <p class="legal"><strong>Thank you. Do visit again.</strong></p>
    </div>
               <div class="info-row">
    <div class="single-row">
        <span class="label">Print Date & Time :</span>
        <span id="lbldatetime"></span>
    </div>
</div>
      
</div>
        </div>
    </form>
    <script type="text/javascript">

        var apiUrl = $("[id$='hdnApiurl']").val();

        $(function () {

            $(document).bind('keydown', function (e) {
                var code = (e.keyCode ? e.keyCode : e.which);
                if (code == 80) {
                   
                   
                }
            });
        });

        $(document).ready(function () {
            var id = getUrlVars()["id"];
            var ApplyGST;
            //var billtype = getUrlVars()["billtype"];
            //if (billtype != null && billtype != "")
            //{
            //    $("#showcgst").hide();
            //    $("#showsgst").hide();
            //    $("#showroundoff").hide();
            //    $("#showrgrandtotal").hide();
            //}
            //Contains Items from that Order
            var orderType = getUrlVars()["orderType"];
            SetTextValue(orderType);
            DisplayOrderItems(id);
            //$("#lbldatetime").html(setdate);
            $("#lbldatetime").html(setdate());
            if (id != null && id != "") {

                //Get Summation of Data from SalesOrderDetail so that we can avoid Loop
                // Get Summation of Data from SalesOrderDetail
                $.ajax({
                    type: "GET",
                    url: apiUrl + '/api/Item/SummationofOrders/' + id + '',
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    async: false,
                    success: function (data) {
                        
                        for (let r of data) {
                            var rawSubTotal = parseFloat(r.ActualCost) || parseFloat(r.TotalAmount) || 0;
                            var discount = parseFloat(r.TotalDiscount) || 0;
                            var afterDisc = rawSubTotal - discount;
                            
                            var formattedDate = formatDateTime(r.CreatedDate);
                            $("#lblNewdatetime").html(formattedDate);
                            $("#subtotal_val").html(rawSubTotal.toFixed(2));
                            $("#billDiscount").html(discount.toFixed(2));
                            $("#after_disc_total").html(afterDisc.toFixed(2));

                            $("#lblCGST").html(parseFloat(r.CGST).toFixed(2));
                            $("#lblSGST").html(parseFloat(r.SGST).toFixed(2));
                            $("#lblgrandtotal").html(parseFloat(r.GSTGrandTotal).toFixed(2));

                            $("#RoomNumber").html(r.RoomNumber || "N/A");
                            $("#CustomerName").html(r.NCName || "Guest");
                            $("#RoundOffValue").html(r.RoundOffValue || "");
                            $("#sUserFullName").html(r.sUserFullName || "Admin");
                            $("#lblTableName").html(r.TableName || "");
                            $("#lblorderno").html(r.OrderNo);
                            $("#lblTotalPaid").html(r.TotalPaid);
                            
                            $("#ServiceChargeValue").html(
                                parseFloat(r.ServiceChargeValue || 0).toFixed(2)
                            );

                            // GST Hide/Show Logic
                            if (r.IsApplyGST == false) {
                                $("#showcgst, #showsgst").hide();
                            }
                        }
                    },
                    error: function (err) {
                        console.log("Error fetching summation:", err);
                    }
                });

                if (ApplyGST == false) {
                    $("#showcgst").hide();
                    $("#showsgst").hide();
                }
            }

        });
        function DisplayOrderItems(id) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/OrderDetailbyOrderID/' + id + '',
                //url: `http://localhost:5000/api/Item/OrderDetailbyOrderID/${id}`,
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
        function HideControls() {
            $("#closetable").hide();
            $("#chargelist").hide();
            $("#tbldisccharge").hide();
            $("#txtcustname").attr("disabled", "disabled");
            $("#txtcustaddress").attr("disabled", "disabled");
            $("#txtcustgst").attr("disabled", "disabled");
            $("#txtcustemail").attr("disabled", "disabled");
            $("#txtcustnumber").attr("disabled", "disabled");
            $("#btnback").hide();
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
        function formatDateTime(dateString) {
            if (!dateString) return "";
            var d = new Date(dateString);
            var day = d.getDate().toString().padStart(2, '0');
            var month = (d.getMonth() + 1).toString().padStart(2, '0');
            var year = d.getFullYear();

            var hours = d.getHours();
            var minutes = d.getMinutes().toString().padStart(2, '0');
            var ampm = hours >= 12 ? 'PM' : 'AM';
            hours = hours % 12;
            hours = hours ? hours : 12; // 0 ko 12 banao

            return day + '/' + month + '/' + year + ' ' + hours + ':' + minutes + ' ' + ampm;
        }
        function setdate() {
            var d = new Date();

            var day = ("0" + d.getDate()).slice(-2);
            var month = ("0" + (d.getMonth() + 1)).slice(-2);
            var year = d.getFullYear();

            var hours = ("0" + d.getHours()).slice(-2);
            var minutes = ("0" + d.getMinutes()).slice(-2);
            var seconds = ("0" + d.getSeconds()).slice(-2);

            return day + "-" + month + "-" + year + " : " + hours + ":" + minutes + ":" + seconds;
        }
    </script>
</body>
</html>
