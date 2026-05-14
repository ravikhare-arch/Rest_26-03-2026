<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="Agent_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <!-- Graph CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <script src="js/jquery-3.6.0.js"></script>
    <!--//skycons-icons-->

    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    
    <link href="css/floating-form.css" rel="stylesheet" />

    <link href="css/customRestro.css" rel="stylesheet" />
    <link href="../../css/customOrder.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.css">
        <script src="https://code.jquery.com/ui/1.13.2/jquery-ui.js"></script>
        <style>
    .disc-charge-wrapper {
        margin-top: 20px;
    }

    .disc-charge-table {
        border-collapse: separate;
        border-spacing: 15px 12px; /* Horizontal + Vertical Gap */
    }

    .disc-charge-table td {
        padding: 5px 8px;
        vertical-align: middle;
    }

    .disc-charge-table span {
        font-weight: 500;
    }

    .disc-charge-table input {
        width: 120px;
        padding: 6px 8px;
        border: 1px solid #ccc;
        border-radius: 6px;
        transition: 0.3s;
    }

    .disc-charge-table input:focus {
        border-color: #007bff;
        outline: none;
        box-shadow: 0 0 5px rgba(0,123,255,0.3);
    }
    .ui-autocomplete {
    z-index: 9999 !important;
    max-height: 200px;
    overflow-y: auto;
    background-color: white;
    border: 1px solid #ccc;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
    <input type="hidden" runat="server" id="hidCompanyId" />
    <input type="hidden" runat="server" id="hidDomainUrl" />
    <input type="hidden" id="hdnGSTpercent" value="" />
    <input type="hidden" id="hdnIsApplyGST" value="true" />
     <input type="hidden" id="hdnGrandTotal" value="0" />
    <div class="col-md-12 well">
        <div class="col-md-6 text-left">
            <div class="col-md-3">
                <div id="divtablename" class="colpsbox_one_top" style="padding-left: 30px;">
                    <div class="icon_corner">
                        <i class="material-icons">event_seat</i>
                    </div>
                    <span id="lbltablename"></span>&nbsp;
                </div>
            </div>

        </div>
        <div class="col-md-5 text-right">
            <input type="button" class="btn btn-primary" id="gototorderlist" name="gototorderlist" />
            <asp:Button Text="Send Order To Rider" runat="server" CssClass="btn btn-primary" ID="Button6" />
            <input type="button" class="btn btn-primary" id="btnback" name="btnback" value="Back To Menu" />
            <input type="button" class="btn btn-primary" id="gotovoid" name="gotovoid" value="Go to Void Orders" />
        </div>
    </div>
    <div class="col-md-6">
        <div class="scroll-box" style="width: 100%; float: left; height: 250px;">
            <table class="table cart-table table-responsive-xs">
                <thead>
                    <tr class="table-head">
                        <th scope="col">Item Name</th>
                        <th scope="col">Unit Price</th>
                        <th scope="col">Quantity</th>
                        <th scope="col">Dish Discount</th>
                        <th scope="col">Total</th>
                    </tr>
                </thead>
                <tbody id="OrderRow">
                </tbody>

            </table>
        </div>
        <div>
            <table class="table cart-table table-responsive-xs">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <a href="#">Sub-Total  </a>
                        </td>
                        <td>
                            <label id="subtotal"></label>
                        </td>
                        <td><a href="#">Bill Amount </a></td>
                        <td>
                            <label id="billamount"></label>
                        </td>
                         <td><a href="#">Total After Disc.</a></td>
                         <td>
                             <label id="Total_aft_Dis"></label>
                         </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td colspan="3">
                            <a href="#">CGST </a>
                        </td>
                        <td>
                            <label id="lblCGST"></label>
                        </td>
                        <td>
                            <a href="#">SGST </a>
                        </td>
                        <td>
                            <label id="lblSGST"></label>
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td colspan="3">
                            <a href="#">Discount </a>
                        </td>
                        <td>
                            <label id="lbldiscount"></label>
                        </td>
                        <td><a href="#">Offer :</a> </td>
                        <td>(No Offer)
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td colspan="3">
                            <a href="#">Charges </a>
                        </td>
                        <td>
                            <label id="lblcharge"></label>
                        </td>

                    </tr>
                </tbody>
                <tbody>
                    <tr>
    <td colspan="3"><a href="#">Round Off</a></td>
    <td><label id="lblRoundOff">0.00</label></td> <td><a href="#">Grand Total</a></td>
    <td><label id="lblgrandtotal"></label></td>
</tr>
                </tbody>
                <tbody>
                    <tr>
                        <td colspan="3">
                            <a href="#">Given Amount</a>
                        </td>
                        <td>
                            <input type="text" id="txtgivenamount" class="floating-input" placeholder=" " onchange="GivenReturnCalculation()" />

                        </td>
                        <td><a href="#">Return Amount :</a> </td>
                        <td>
                            <label id="lblreturnamount"></label>
                        </td>
                    </tr>
                </tbody>

            </table>
        </div>
        <div id="wrapper1">
                <div id="div1">
                </div>
            </div>
            <div id="wrapper2">
                <div id="div2">
        <div id="divpayment">
        <table class="table cart-table table-responsive-xs">
            <tbody>
                <tr>
                    <td>
                        <input type="radio" id="cash" name="fav_language" value="CASH" />
                        <label for="card">Cash</label>


                    </td>
                    <td>
                        <input type="radio" id="card" name="fav_language" value="CARD" />
                        <label for="card">Card</label>

                    </td>
                    <td>
                        <input type="radio" id="paytm" name="fav_language" value="PAYTM" />
                        <label for="card">PAYTM</label>
                    </td>
                    <td>
                        <input type="radio" id="phonepe" name="fav_language" value="PHONEPE" />
                        <label for="card">PHONEPE</label>
                    </td>
                    <td>
                        <input type="radio" id="lending" name="fav_language" value="LENDING" />
                        <label for="card">NC</label>
                    </td>
                    <td>
                        <input type="radio" id="multiple" name="fav_language" value="MULTIPLE" />
                        <label for="card">Room Serv</label>
                    </td>
                    <td>
                        <input type="radio" id="gpay" name="fav_language" value="GPAY" />
                        <label for="card">GPAY</label>
                    </td>

                    <%--<td>
                    <input type="radio" id="nc" name="fav_language" value="NC" />
                    <label for="card">NC</label>
                     </td>--%>
                </tr>
            </tbody>
        </table>

        </div>
            </div>
                </div>
        <div class=" col-md-12 text-center">

            <input type="button" class="btn btn-primary" id="closetable" name="closetable" value="Close Table" />
            <input type="button" class="btn btn-primary" id="printbill" name="printbill" value="Print With GST Bill" />
            <input type="button" class="btn btn-primary" id="chargelist" name="chargelist" value="Edit Chargelist" />
            <input type="button" class="btn btn-primary" id="printwithoutgst" name="printwithoutgst" value=" KOT RE-Print Bill" />
          

            <%--<asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="" />--%>
        </div>
    </div>
    <div class="col-md-6 splcontent ">
        <div class="text-center center-block pt-2">
            <h4><b style="color: red; border-bottom: 1px solid red;">*Note</b>
                :To Save the Customer Details Contact Number is Mandatory.</h4>
        </div>
        <div class="floating-label">
            <%--<asp:TextBox ID="txtcustname" runat="server" class="floating-input" type="text" placeholder=" " />--%>
            <input type="text" id="txtcustname" class="floating-input" placeholder=" " />
            <span class="highlight"></span>
            <label>Customer Name<span class="req">*</span></label>
        </div>
        <div class="floating-label">

            <input type="text" id="txtcustnumber" class="floating-input" placeholder=" " />
            <span class="highlight"></span>
            <label>Customer Number<span class="req">*</span></label>
        </div>
        <div class="floating-label">

            <input type="text" id="txtcustaddress" class="floating-input" placeholder=" " />
            <span class="highlight"></span>
            <label>Customer Address<span class="req">*</span></label>
        </div>
        <div class="floating-label">
            <input type="text" id="txtcustgst" class="floating-input" placeholder=" " />

            <span class="highlight"></span>
            <label>Customer GSTIN<span class="req">*</span></label>
            <span class="highlight"></span>
        </div>
        <div class="floating-label">
            <input type="text" id="txtcustemail" class="floating-input" placeholder=" " />

            <span class="highlight"></span>
            <label>Customer Email<span class="req">*</span></label>

        </div>
        <br />
        <div class="floating-label">
    <input type="text" id="txtRoomNoDisplay" class="floating-input" placeholder=" " readonly style="background-color: #f9f9f9; font-weight: bold; border: 1px solid #ccc;" />
    <span class="highlight"></span>
    <label style="color:red;">Allocated Room Number</label>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-12">
                <input type="checkbox" name="isApplyGST" id="isApplyGST" checked="checked" value="true" /><span>Apply GST</span>
            </div>
        </div>
        <div class="disc-charge-wrapper">
    <table id="tbldisccharge" class="disc-charge-table">
        <tbody>
            <tr>
                <td><span>Discount %</span></td>
                <td>
                    <input type="text" id="txtdiscount"
                           onchange="return CalculateDisc()" />
                </td>

                <td><span>Discount Value</span></td>
                <td>
                    <input type="text" id="txtdisccountvalue"
                           onchange="return CalculateDiscountbasedonValue()" />
                </td>
            </tr>

            <tr>
                <td><span>Charges %</span></td>
                <td>
                    <input type="text" id="txtchargepercent"
                           onchange="return CalculateChargebasedonPercent()" />
                </td>

                <td><span>Charges</span></td>
                <td>
                    <input type="text" id="txtcharges"
                           onchange="return CalculateCharge()" />
                </td>

            <td>
                <span>Room No</span>
            </td>
            <td>
                <input type="text" id="txtRoomNo" />
                <input type="hidden" id="hdnRTID" />
                <input type="hidden" id="hdnGCID" />
            </td>
            </tr>
        </tbody>
    </table>
</div>
        <div></div>
    </div>

<script type="text/javascript">
    
    var apiUrl = $("[id$='hdnApiurl']").val();
    $(document).ready(function ()
    {

        var urlParams = getUrlVars();
        // --- 1. Parameters Capture (Single Source) ---
      
        var id = urlParams["id"];
        var tablestatus = urlParams["status"];
        var orderType = urlParams["orderType"];
        var mode = urlParams["mode"];
        var roomFromUrl = urlParams["roomNo"];
        var ncNameFromUrl = urlParams["ncName"];
        var ncRadioFromUrl = urlParams["ncRadio"];

        console.log("URL Data Received:", { id, roomFromUrl, ncRadioFromUrl, mode });

        // --- 2. Readonly Mode Logic ---
        if (mode === "readonly") {
            console.log("Readonly mode active.");
            setTimeout(function () {
                HideControls();
                $("#closetable").hide();
                $("#btnback").val("Back to List");
            }, 1500);
        }

        // --- 3. NC (Non-Chargeable) Autofill Logic ---
        // Pehle URL check karo, agar wahan nahi hai toh Storage check karo
        if (ncRadioFromUrl === "NC") {
            $("#lending").prop('checked', true);
            console.log("NC Mode: Selected from URL");
        } else if (localStorage.getItem("isNCSelected") === "true") {
            $("#lending").prop("checked", true);
            console.log("NC Mode: Selected from Storage");
            localStorage.removeItem("isNCSelected"); // Use ke baad clear karo
        }

        // --- 4. Room Number Priority Logic ---
        var dataLoadedFromUrl = false;
        if (roomFromUrl && roomFromUrl !== "-" && roomFromUrl !== "null" && roomFromUrl !== "undefined") {
            var decodedRoom = decodeURIComponent(roomFromUrl).replace(/\+/g, ' ');
            $("#txtRoomNoDisplay").val(decodedRoom);
            $("[id$='txtRoomNo']").val(decodedRoom);
            $("#multiple").prop("checked", true);    // Room Service select
            dataLoadedFromUrl = true;
            console.log("Room No: Priority URL used.");
        }

        // Agar URL me nahi hai, tabhi LocalStorage se uthao
        //if (!dataLoadedFromUrl) {
        //    var savedRoom = localStorage.getItem("bill_roomNo");
        //    if (savedRoom && savedRoom !== "null") {
        //        $("[id$='txtRoomNo']").val(savedRoom);
        //        $("#txtRoomNoDisplay").val(savedRoom);
        //        $("#multiple").prop("checked", true);
        //        console.log("Room No: Fallback to Storage.");
        //    }
        //}

        // 3. NC (Non-Chargeable) Auto-selection Logic
        if (isNCFromStorage === "true") {
            // Hum 'lending' ya 'nc' radio button ko check karenge
            // Aapke order.aspx mein id="lending" hai NC ke liye
            $("#lending").prop("checked", true);
            console.log("NC Mode auto-selected");

            // Clear storage after use so it doesn't affect next orders
            localStorage.removeItem("isNCSelected");
        }

        // 4. Customer Name Logic
        if (ncNameFromUrl) {
            $("#txtcustname").val(decodeURIComponent(ncNameFromUrl).replace(/\+/g, ' '));
        }

        // --- Base Code Setup ---
        $("#divtablename").hide();
        $("#gotovoid").hide();

        // 🔥 FIX 2: In variables ko global scope (ready block ke andar) rakhein taaki click events use kar sakein
        var SGST = 0, CGST = 0, grandTotal = 0, tablename = "";
        var id = urlParams["id"];
        var tablestatus = urlParams["status"];
        var orderType = urlParams["orderType"];
        var voidorder = urlParams["voidorder"];
        var tableID = urlParams["TableID"];
        var temptablename = urlParams["tablename"];

        if (temptablename != undefined && temptablename != null) {
            tablename = temptablename.replace(/%20/g, " ");
            localStorage.setItem("current_tableName", tablename);
        } else if (tableID != undefined && tableID != "0") {
            tablename = GetTableName(tableID);
            localStorage.setItem("current_tableName", tablename);
        }

        if (voidorder == "0") { $("#gotovoid").show(); }

        DisplayOrderItems(id);
        SetButtonTextValue(orderType, tablename);

        // --- API Calls ---
        if (tablestatus == 'Completed' && id != "") {
            HideControls();
            $.ajax({
                type: "GET",
                url: apiUrl + '/api/Item/PendingOrCompletedSalesOrder/' + id,
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    if (data && data.length > 0) {
                        let r = data[0];
                        grandTotal = r.GrandTotal;
                        SGST = r.SGST;
                        CGST = r.CGST;
                        $("#subtotal").html(r.SubTotal);
                        $("#billamount").html(r.TotalOrderAmount);
                        $("#lblCGST").html(r.CGST);
                        $("#lblSGST").html(r.SGST);
                        $("#hdnGSTpercent").val(r.GSTPercent);
                        $("#lblgrandtotal").html(r.GrandTotal);
                        $("#txtcustname").val(r.NCName);
                        var roomValue = r.RoomNo || r.RoomNumber || "Not Assigned";
                        $("#txtRoomNoDisplay").val(roomValue);
                        $("[id$='txtRoomNo']").val(roomValue);
                        $("#txtRoomNoDisplay").attr("disabled", "disabled");
                        $("#txtcustaddress").val(r.CustomerAddress);
                        $("#txtcustemail").val(r.CustomerEmail);
                        $("#txtcustgst").val(r.CustomerGST);
                        $("#txtcustnumber").val(r.CustomerNumber);
                        $("#lbldiscount").html(r.TotalDiscount);
                        $("#lblcharge").html(r.Charge);
                        $("#txtgivenamount").val(r.GivenAmount);
                        $("#lblreturnamount").html(r.ReturnAmount);
                        SetPaymentMode(r.PayMode);
                    }
                }
            });
        } else {
            if (id != null && id != "") {
                $.ajax({
                    type: "GET",
                    url: apiUrl + '/api/Item/SummationofOrders/' + id,
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        if (data && data.length > 0) {
                            let r = data[0];
                            $("#subtotal").html(r.ActualCost);
                            $("#billamount").html(r.TotalAmount);
                            $("#Total_aft_Dis").html(parseFloat(r.Total_aft_Dis).toFixed(2));
                            $("#SavedGrandTotal").html(parseFloat(r.SavedGrandTotal).toFixed(2));
                            $("#lblCGST").html(r.CGST);
                            $("#lblSGST").html(r.SGST);
                            $("#hdnGSTpercent").val(r.GSTPercent);
                            $("#lblgrandtotal").html(r.GSTGrandTotal);
                            $("#hdnGrandTotal").val(r.GSTGrandTotal);
                            grandTotal = r.GSTGrandTotal;
                            SGST = r.SGST;
                            CGST = r.CGST;
                            $("#txtcustname").val(r.NCName);
                        }
                    }
                });

                $('#isApplyGST').off('change').on('change', function () {
                    if (this.checked) {
                        if (confirm("Are you sure?")) {
                            $("#lblgrandtotal").html(grandTotal);
                            $("#lblCGST").html(CGST);
                            $("#lblSGST").html(SGST);
                            $("#hdnIsApplyGST").val('true');
                        } else {
                            $(this).prop("checked", false);
                        }
                    } else {
                        $("#lblgrandtotal").html((grandTotal - CGST - SGST).toFixed(2));
                        $("#lblCGST").html("0.0");
                        $("#lblSGST").html("0.0");
                        $("#hdnIsApplyGST").val('false');
                    }
                });
            }
        }



        $(document.body).on("click", "#closetable", function () {
            var id = getUrlVars()["id"];

           
            var selectedPaymentMode = $("input[name='fav_language']:checked").val() || "CASH";

            var isDirectPayment = ["CASH", "CARD", "PAYTM", "PHONEPE", "GPAY", "MULTIPLE", "NC"]
                .includes(selectedPaymentMode);

            var salesOrder = {};
            var salesOrderList = [];

            // ------------------ 1. UI VALUES ------------------
            var currentSubTotal = parseFloat($("#subtotal").html()) || 0;
            var finalCharges = parseFloat($("#lblcharge").html()) || 0;
            var currentDiscount = parseFloat($("#lbldiscount").html()) || 0;
            var currentCGST = parseFloat($("#lblCGST").html()) || 0;
            var currentSGST = parseFloat($("#lblSGST").html()) || 0;

            // ❌ No Math.round here (avoid double rounding)
            var currentGrandTotal = parseFloat($("#lblgrandtotal").html()) || 0;

            var isGstApplied = $('#isApplyGST').is(':checked');

            // ------------------ 2. ORDER OBJECT ------------------
            salesOrder.OrderID = id;
            salesOrder.nLoginID = localStorage.getItem("nLoginId");
            salesOrder.sUserFullName = localStorage.getItem("sUserFullName");
            salesOrder.TableName = localStorage.getItem("current_tableName") || $("#lbltablename").text().trim() || "";
            salesOrder.CustomerName = $("#txtcustname").val();
            salesOrder.PayMode = selectedPaymentMode;

            salesOrder.GrandTotal = Math.round(currentGrandTotal); // final save me round kar sakta hai
            salesOrder.SubTotal = currentSubTotal;
            salesOrder.TotalDiscount = currentDiscount;
            salesOrder.Charge = finalCharges;
            salesOrder.CGST = currentCGST;
            salesOrder.SGST = currentSGST;
            salesOrder.isApplyGST = isGstApplied;
            salesOrder.CustomerNumber = $("#txtcustnumber").val();
            salesOrder.CustomerAddress = $("#txtcustaddress").val();
            salesOrder.RoomNumber = $("#txtRoomNo").val();

            salesOrderList.push(salesOrder);

            // ------------------ 3. BILL PAYLOAD ------------------
            var billPayloadArray = [];

            var today = new Date();
            var formattedDate =
                today.getDate().toString().padStart(2, '0') + '/' +
                (today.getMonth() + 1).toString().padStart(2, '0') + '/' +
                today.getFullYear();

            var discountRatio = currentSubTotal > 0 ? (currentDiscount / currentSubTotal) : 0;

            var rows = $("#OrderRow tr");
            var totalItems = rows.length;
            var runningTotal = 0;

            rows.each(function (index) {

                var menuDesc = $(this).find("td:eq(0)").text().trim();
                var menuId = $(this).find("td:eq(0)").attr("menuid");
                var rate = parseFloat($(this).find(".OneUnitPrice").text()) || 0;
                var qty = parseFloat($(this).find("td:eq(2)").text()) || 0;

                // -------- Amount --------
                var itemTotalRaw = rate * qty;

                // -------- Discount --------
                var itemDiscount = itemTotalRaw * discountRatio;
                var itemAfterDiscount = itemTotalRaw - itemDiscount;

                // -------- GST --------
                var itemSgst = 0;
                var itemCgst = 0;

                if (isGstApplied) {
                    itemSgst = Number((itemAfterDiscount * 0.025).toFixed(2));
                    itemCgst = Number((itemAfterDiscount * 0.025).toFixed(2));
                }

                // -------- Final --------
                var itemNetTotal = Number((itemAfterDiscount + itemSgst + itemCgst).toFixed(2));

                var finalItemNetTotal = 0;
                var roundOff = 0;

                if (index === totalItems - 1) {
                    // 🔥 LAST ITEM → adjust to match Grand Total
                    finalItemNetTotal = parseFloat((currentGrandTotal - runningTotal).toFixed(2));
                    roundOff = parseFloat((finalItemNetTotal - itemNetTotal).toFixed(2));
                } else {
                    // ✅ Normal items → exact value
                    finalItemNetTotal = parseFloat(itemNetTotal.toFixed(2));
                    runningTotal += finalItemNetTotal;
                    roundOff = 0;
                }

                billPayloadArray.push({
                    "companyid": 1067,
                    "kotno": id,
                    "tablename": localStorage.getItem("current_tableName") || "",
                    "billno": id,
                    "date": formattedDate,
                    "MenuDescription": menuDesc,
                    "rate": rate,
                    "quantity": qty,
                    "guest": $("#txtcustname").val() || "Walk-in Guest",
                    "total": parseFloat(itemAfterDiscount.toFixed(2)),
                    "sgst": parseFloat(itemSgst.toFixed(2)),
                    "cgst": parseFloat(itemCgst.toFixed(2)),
                    "nettotal": finalItemNetTotal,
                    "roundoff": roundOff,
                    "gcid": parseInt($("#hdnGCID").val()) || 0,
                    "menuid": menuId,
                    "paymentMode": selectedPaymentMode
                });
            });

            // --- 4. AJAX CALLS ---
            $.ajax({
                type: "POST",
                data: JSON.stringify(salesOrderList),
                url: apiUrl + '/api/Item/UpdateOrderStatus/' + id,
                contentType: "application/json;charset=utf-8",
                success: function (response) {
                    var isRoomAssigned = parseInt($("#hdnGCID").val()) > 0;

                    if (isDirectPayment && !isRoomAssigned) {
                        $.ajax({
                            type: "POST",
                            url: "https://hotelpremierinn.rstpms.com/Hotel/API/AddCashFoodBill",
                            data: JSON.stringify(billPayloadArray),
                            contentType: "application/json",
                            success: function (res) {
                                alert("Bill Closed! Total: " + currentGrandTotal);
                                HideControls();
                            }
                        });
                    } else if (isRoomAssigned) {
                        debugger;
                        $.ajax({
                            type: "POST",
                            url: "https://hotelpremierinn.rstpms.com/Hotel/API/AddRestaurantBill",
                            data: JSON.stringify(billPayloadArray),
                            contentType: "application/json",
                            success: function (res) {
                                alert("Hotel Bill Saved! Total: " + currentGrandTotal);
                                HideControls();
                            }
                        });
                    } else {
                        alert("Order Updated Successfully!");
                        HideControls();
                    }
                }
            });
        });
            //Back to the Order
            $(document.body).on("click", "#btnback", function () {
                window.location.href = "/Take_away.aspx?status=" + tablestatus + "&orderType=" + orderType + "&id=" + id + "&tablename=" + tablename + "";
            });
            $(document.body).on("click", "#gototorderlist", function () {
                window.location.href = "/Restaurant/Table/Orderlist.aspx?orderType=" + orderType + "";
            });
            $(document.body).on("click", "#printbill", function () {
                window.location.href = "/Print.aspx?id=" + id + "";
            });
            $(document.body).on("click", "#gotovoid", function () {
                window.location.href = "/Restaurant/Table/VoidOrderlist.aspx";
            });
    });
        function DisplayOrderItems(id) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/OrderDetailbyOrderID/' + id + '',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var orderDetail = "";
                    $.each(data, function (i) {
                        orderDetail +=
                            '<tr><td menuId="' + data[i].ItemMasterID +'"><a href="#">' + data[i].ProductName + '</a></td><td id="' + data[i].SalesOrderDetailID + '" class="OneUnitPrice">' + data[i].ActualCost + '</td><td class="ng-tns-c8-2" >' + data[i].ProductQty + '</td>' +
                   '</td><td class="discount">0</td><td class="totalPrice">' + data[i].TotalAmount + ' </td></tr>'

                    });

                    $("#OrderRow").append(orderDetail);

                }

            });
        };
        //function CalculateDisc() {
        //    var discgrandtotal = 0;
        //    var disctotal = 0;
        //    var grandtotal = 0;
        //    var discount = $("#txtdiscount").val()
        //    grandtotal = $("#billamount").html();
        //    if (discount == "")
        //    {
        //        discount = 0;
        //    }
        //    disctotal = grandtotal * discount / 100;
        //    discgrandtotal = grandtotal - disctotal;
        //    $("#lblgrandtotal").html(discgrandtotal);
        //    $("#lbldiscount").html(disctotal);
    //};
    // Global Variables (AJAX success mein inko populate zaroori hai)
    // ✅ Master Recalculation Function
    // ✅ Enhanced Master Recalculation Function with Rounding Logic
    function recalculateAll(subTotal, discountAmount, charges) {
        // 1. Math Calculations
        var totalAfterDisc = subTotal - discountAmount;
        var isGstChecked = $('#isApplyGST').is(':checked');
        var cgst = 0, sgst = 0;

        if (isGstChecked) {
            cgst = (totalAfterDisc * 2.5) / 100;
            sgst = (totalAfterDisc * 2.5) / 100;
        }

        var exactTotal = totalAfterDisc + cgst + sgst + charges;
        var roundedGrandTotal = Math.round(exactTotal);
        var roundOffValue = roundedGrandTotal - exactTotal;

        // 2. UI Updates
        $("#Total_aft_Dis").html(totalAfterDisc.toFixed(2));
        $("#lbldiscount").html(discountAmount.toFixed(2));
        $("#lblCGST").html(cgst.toFixed(2));
        $("#lblSGST").html(sgst.toFixed(2));
        $("#lblcharge").html(charges.toFixed(2));
        $("#lblgrandtotal").html(roundedGrandTotal.toFixed(2));
        $("#hdnGrandTotal").val(roundedGrandTotal);

        var displayRoundOff = (roundOffValue >= 0 ? "+" : "") + roundOffValue.toFixed(2);
        $("#lblRoundOff").html(displayRoundOff);

        // 3. 🔥 LocalStorage me Save karna (Values ko safe rakhne ke liye)
        var orderId = getUrlVars()["id"]; // Har order ke liye alag save hoga
        var billingData = {
            discountPercent: $("#txtdiscount").val() || "0",
            discountValue: discountAmount.toFixed(2),
            chargePercent: $("#txtchargepercent").val() || "0",
            chargeValue: charges.toFixed(2),
            roundOff: roundOffValue.toFixed(2),
            grandTotal: roundedGrandTotal
        };

        localStorage.setItem("bill_data_" + orderId, JSON.stringify(billingData));

        console.log("Data Saved to LocalStorage for Order " + orderId);
    }

    function CalculateDisc() {
        // .trim() use karein taaki white-space issue na ho
        var discountPercent = $("#txtdiscount").val().trim();
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentCharges = parseFloat($("#lblcharge").html()) || 0;

        if (discountPercent !== "" && !isNaN(discountPercent) && parseFloat(discountPercent) >= 0) {
            $("#txtdisccountvalue").val("").prop("disabled", true);
            var discountAmount = (subTotal * parseFloat(discountPercent)) / 100;
            recalculateAll(subTotal, discountAmount, currentCharges);
        } else {
            // Agar value 0 ya empty hai to reset karein
            ResetToOriginalTotal();
        }
    }

    function CalculateDiscountbasedonValue() {
        var discountValue = $("#txtdisccountvalue").val();
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentCharges = parseFloat($("#lblcharge").html()) || 0;

        if (discountValue !== "" && !isNaN(discountValue)) {
            $("#txtdiscount").val("").prop("disabled", true);
            var discountAmount = parseFloat(discountValue);
            recalculateAll(subTotal, discountAmount, currentCharges);
        } else {
            $("#txtdiscount").prop("disabled", false);
            ResetToOriginalTotal();
        }
    }

    function ResetToOriginalTotal() {
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var charges = parseFloat($("#lblcharge").html()) || 0;

        // Inputs clear
        $("#txtdiscount").val("");
        $("#txtdisccountvalue").val("");
        $("#txtdisccountvalue").prop("disabled", false);
        $("#txtdiscount").prop("disabled", false);

        // Refresh with 0 discount
        recalculateAll(subTotal, 0, charges);
    }
        //function CalculateCharge() {
        //    var charge = $("#txtcharges").val();
        //    if (charge == "") {
        //        charge = 0;
        //    }
        //    var grandtotal = $("#lblgrandtotal").html();
        //    var chargewithgrandtot = Number(grandtotal) + Number(charge);
        //    $("#lblgrandtotal").html(chargewithgrandtot);
        //    $("#lblcharge").html(charge);
    //};
    function CalculateCharge() {
        var chargeVal = parseFloat($("#txtcharges").val()) || 0;
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentDisc = parseFloat($("#lbldiscount").html()) || 0;

        if (chargeVal >= 0) {
            // Agar value hai to percent wala disable kar do
            $("#txtchargepercent").val("").prop("disabled", (chargeVal > 0));

            // Label update
            $("#lblcharge").html(chargeVal.toFixed(2));

            // 🔥 MASTER CALL: Isi se Round-off aur Grand Total sahi hoga
            recalculateAll(subTotal, currentDisc, chargeVal);
        } else {
            $("#txtchargepercent").prop("disabled", false);
            ResetToOriginalTotal();
        }
    }
        //function CalculateChargebasedonPercent() {
        //    var discgrandtotal = 0;
        //    var disctotal = 0;
        //    var grandtotal = 0;
        //    var discount = $("#txtchargepercent").val()
        //    grandtotal = $("#billamount").html();
        //    if (discount == "") {
        //        discount = 0;
        //    }
        //    disctotal = grandtotal * discount / 100;
        //    discgrandtotal = grandtotal - disctotal;
        //    $("#lblgrandtotal").html(discgrandtotal);
        //    $("#lblcharge").html(disctotal);
        //};
        //function CalculateDiscountbasedonValue() {
        //    var discval = $("#txtdisccountvalue").val();
        //    if (discval == "") {
        //        charge = 0;
        //    }
        //    var grandtotal = $("#hdnGrandTotal").val();
        //    var chargewithgrandtot = Number(grandtotal) - Number(discval);
        //    $("#lblgrandtotal").html(chargewithgrandtot);
        //    $("#lbldiscount").html(discval);
    //};
    function CalculateChargebasedonPercent() {
        var chargePercent = parseFloat($("#txtchargepercent").val()) || 0;
        var subTotal = parseFloat($("#subtotal").html()) || 0; // Base amount for %
        var currentDisc = parseFloat($("#lbldiscount").html()) || 0;

        if (chargePercent > 0) {
            $("#txtcharges").val("").prop("disabled", true);

            // Percent calculate karo subtotal par
            var calculatedCharge = (subTotal * chargePercent) / 100;

            // Label update
            $("#lblcharge").html(calculatedCharge.toFixed(2));

            // 🔥 MASTER CALL
            recalculateAll(subTotal, currentDisc, calculatedCharge);
        } else {
            $("#txtcharges").prop("disabled", false);
            ResetToOriginalTotal();
        }
    }
            function CalculateDiscountbasedonValue() {
                var discountValue = parseFloat($("#txtdisccountvalue").val()) || 0;
                var billAmount = parseFloat($("#billamount").html()) || 0;

                if (discountValue > 0) {
                    // Disable and clear Percent-based discount
                    $("#txtdiscount").val("").prop("disabled", true);

                    var newGrandTotal = billAmount - discountValue;

                    $("#lbldiscount").html(discountValue.toFixed(2));
                    $("#lblgrandtotal").html(newGrandTotal.toFixed(2));
                } else {
                    // Re-enable if cleared
                    $("#txtdiscount").prop("disabled", false);
                    ResetTotals();
                }
    }
    function ResetTotals() {
        var billAmount = $("#billamount").html();
        $("#lblgrandtotal").html(billAmount);
        $("#lbldiscount").html("0");
        $("#txtdiscount").prop("disabled", false);
        $("#txtdisccountvalue").prop("disabled", false);
    }
        function GivenReturnCalculation() {
            var givenamnt = 0;
            var returnamount = 0;
            var grandtot = 0;
            givenamnt = $('#txtgivenamount').val();
            grandtot = $("#lblgrandtotal").html();
            if (givenamnt > 0) {
                returnamount = givenamnt - grandtot;
                $('#lblreturnamount').html(returnamount);
            }
            else {
                $('#lblreturnamount').html(returnamount);
                $('#txtgivenamount').val(givenamnt);
            }
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
    //function HideControls()
    //{
    //        $("#closetable").hide();
    //        $("#chargelist").hide();
    //        $("#tbldisccharge").hide();
    //        $("#txtRoomNo").attr("disabled", "disabled");
    //        $("#txtRoomNoDisplay").attr("disabled", "disabled");
    //        $("#txtcustname").attr("disabled", "disabled");
    //        $("#txtcustaddress").attr("disabled", "disabled");
    //        $("#txtcustgst").attr("disabled", "disabled");
    //        $("#txtcustemail").attr("disabled", "disabled");
    //        $("#txtcustnumber").attr("disabled", "disabled");
    //        $("#divpayment *").prop('disabled', true);
    //        $("#txtgivenamount").attr("disabled", "disabled");
    //        $("#btnback").hide();            
    //}

    function HideControls() {
        debugger;
        console.log("Applying HideControls Logic...");

        // 1. Saare inputs, selects, textareas ko lock karein
        $("input, select, textarea").prop("disabled", true).attr("disabled", "disabled");

        // 2. Sirf Navigation aur Print Buttons ko enable rakhein
        $(".btn-primary, #printbill, #printwithoutgst, #gototorderlist, #btnback").prop("disabled", false).removeAttr("disabled").show();

        // 3. Billing aur Order Action buttons ko hide karein
        $("#closetable, #chargelist, #Button6, #isApplyGST").hide();

        // 4. Radio buttons (Payment Mode) block karein
        $("#divpayment").css({
            "pointer-events": "none",
            "opacity": "0.8"
        });

        // 5. Visual Styling for better UX
        $(".floating-input, #txtRoomNo, #txtcustname, #txtgivenamount").css({
            "background-color": "#f1f1f1",
            "border-bottom": "1px solid #999",
            "cursor": "not-allowed",
            "color": "#555"
        });

        // 6. Delete icons (trash) ya edit icons ko hide karein agar table me hain
        $(".deletebtn, .fa-trash, .fa-pencil, .icon").hide();
    }
        function SetPaymentMode(PayMode) {
            var jsLang = PayMode;
            // Saare payment radio buttons ko disable karein
            $("input[name='fav_language']").attr("disabled", "disabled");
            switch (jsLang) {
                case 'CASH':
                    $("#cash").prop("checked", true);
                    break;
                case 'CARD':
                    $("#CARD").prop("checked", true);
                    break;
                case 'PAYTM':
                    $("#paytm").prop("checked", true);
                    break;
                case 'PHONEPE':
                    $("#phonepe").prop("checked", true);
                    break;
                case 'LENDING':
                    $("#lending").prop("checked", true);
                    break;
                case 'MULTIPLE':
                    $("#multiple").prop("checked", true);
                    break;
                case 'GPAY':
                    $("#gpay").prop("checked", true);
                    break;
                case 'NC':
                    $("#nc").prop("checked", true);
                    break;
            }
        }
        function SetButtonTextValue(orderType,tablename) {
            var jsLang = orderType;
            switch (jsLang) {
                case "1":
                    $("#gototorderlist").prop('value', 'Back to Take Away Report');
                    break;
                case "2":
                    $("#gototorderlist").prop('value', 'Back to Door Delivery Report ');
                    break;
                case "3":
                    $("#divtablename").show();
                    $("#lbltablename").html(tablename);
                    $("#gototorderlist").prop('value', 'Back to Dine-In Report');
                    break;
                case "4":
                    $("#divtablename").show();
                    $("#lbltablename").html(tablename);
                    $("#gototorderlist").prop('value', 'Back to Dastarkhan Report');
                    break;
            }
        }
        function GetTableName(tableID)
        {
                       var rettablename = "";
                        $.ajax({
                            type: "GET",
                            url: apiUrl+'/api/DineIn/GetTableName/' + tableID + '',
                            dataType: "json", contentType: "application/json;charset=utf-8",
                            async: false,
                            success: function (response) {
                                if (response != "") {
                                    rettablename = response;
                                }
                            }
                        });
                        return rettablename;
        }
  
    $("#txtRoomNo").autocomplete({
        minLength: 1,
        source: function (request, response) {
            console.log("API call hone ja rahi hai...");

            $.ajax({
                url: "https://hotelpremierinn.rstpms.com/Hotel/API/GetOccupiedRooms",
                type: "GET",
                dataType: "json",
                data: {
                    companyid: 1067   // direct query string banega ?companyid=1067
                },
                success: function (data) {
                    console.log("API se ye data aaya:", data);

                    var uniqueRooms = [];
                    var roomSet = new Set();

                    $.each(data, function (index, item) {
                        if (!roomSet.has(item.RoomNo)) {
                            roomSet.add(item.RoomNo);
                            uniqueRooms.push(item);
                        }
                    });

                    response($.map(uniqueRooms, function (item) {
                        return {
                            label: item.RoomNo,
                            value: item.RoomNo,
                            rtId: item.RTID,
                            gcid: item.GCID
                        };
                    }));
                },
                error: function (xhr) {
                    console.log("Error:", xhr.responseText);
                }
            });
        },
        select: function (event, ui) {
            $("#txtRoomNo").val(ui.item.value);
            $("#hdnRTID").val(ui.item.rtId);
            $("#hdnGCID").val(ui.item.gcid);
            return false;
        }
    });
    // 1. Function to trigger the local Thermal Printer API
    function openWindowForPrint(url) {
        var myWindow = window.open(url, "myWindow", "width=200,height=100");
        setTimeout(function () {
            if (myWindow) myWindow.close();
        }, 200);
    }

    // 2. Helper function to check if the cart has items
    function GetItemCountfromCart() {
        return $('#OrderRow tr').length;
    }

    // 3. Helper function for validation message
    function GetInvalidCartMessage() {
        alert("The cart is empty. Cannot generate a print!");
    }




    //start prin thermal  by ravi

    $(document.body).on("click", "#printwithoutgst", function ()
    {
        if (GetItemCountfromCart() > 0)
        {
            // Get the Order ID from the URL
            var orderID = getUrlVars()["id"];

            if (orderID) {
                // Call the local printing service
                var printUrl = "http://127.0.0.1:62351/api/Printing/Print/" + orderID + "?printerName=LAN1";
                openWindowForPrint(printUrl);
            } else {
                alert("Order ID not found in URL!");
            }
        }
        else {
            GetInvalidCartMessage();
        }
    });

    // 5. Optional: Click Event for the regular 'Print Bill' 
    $(document.body).on("click", "#printbill", function ()
    {
        if (GetItemCountfromCart() > 0)
        {
            var orderID = getUrlVars()["id"];
            // Using the same thermal logic, or change the URL if GST print API is different
            var printUrl = "http://127.0.0.1:62351/api/Printing/PrintWithGst/" + orderID + "?printerName=LAN1";
            openWindowForPrint(printUrl);
        }
        else
        {
            GetInvalidCartMessage();
        }
    });
  



    // end print thermal by ravi 

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



    
