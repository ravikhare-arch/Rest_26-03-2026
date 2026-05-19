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
                        <td>
                            <label id="lblRoundOff">0.00</label></td>
                        <td><a href="#">Grand Total</a></td>
                        <td>
                            <label id="lblgrandtotal"></label>
                        </td>
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
                                    <input type="radio" id="NC" name="fav_language" value="NC" />
                                    <label for="card">NC</label>
                                </td>
                                <td>
                                    <input type="radio" id="Room_Serv" name="fav_language" value="Room Service" />
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
            <label style="color: red;">Allocated Room Number</label>
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
    // Global Reference URL
    var apiUrl = $("[id$='hdnApiurl']").val();
    var SGST = 0, CGST = 0, grandTotal = 0, tablename = "";

    // 🔥 FIXED REUSABLE LOCK ENGINE
    //function checkNcAndLockRoom() {
    //    var $ncCheckbox = $("[id$='NC']");
    //    var isNcChecked = $ncCheckbox.is(":checked");

    //    var urlParams = getUrlVars();
    //    var roomFromUrl = urlParams["roomNo"];
    //    var savedRoom = localStorage.getItem("bill_roomNo");

    //    var $roomInput = $("[id$='txtRoomNo']");
    //    var $roomDisplay = $("[id$='txtRoomNoDisplay']");
    //    var $paymentContainer = $("#divpayment");

    //    if (isNcChecked) {
    //        $roomInput.val("").prop("disabled", true).attr("readonly", "readonly").css({
    //            "background-color": "#eeeeee",
    //            "cursor": "not-allowed",
    //            "pointer-events": "none"
    //        });

    //        if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
    //            $roomInput.autocomplete("close");
    //        }

    //        $roomDisplay.val("Not Applicable (NC)").prop("disabled", true).css({
    //            "background-color": "#eeeeee",
    //            "cursor": "not-allowed",
    //            "color": "#ff0000",
    //            "font-weight": "bold"
    //        });

    //        $("[id$='hdnRTID']").val("");
    //        $("[id$='hdnGCID']").val("");

    //        if ($paymentContainer.length) {
    //            $paymentContainer.find("input[type='radio']").prop("disabled", true);
    //        }
    //    } else {
    //        var hasRoom = (roomFromUrl && roomFromUrl !== "-" && roomFromUrl !== "null" && roomFromUrl !== "undefined") ||
    //            (savedRoom && savedRoom !== "null" && savedRoom !== "");

    //        if (hasRoom) {
    //            $roomInput.prop("disabled", true).attr("readonly", "readonly").css({
    //                "background-color": "#eeeeee",
    //                "cursor": "not-allowed",
    //                "pointer-events": "none"
    //            });

    //            if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
    //                $roomInput.autocomplete("close");
    //            }

    //            if ($paymentContainer.length) {
    //                $paymentContainer.find("input[type='radio']").not("#Room_Serv").prop("disabled", true);
    //                $("#Room_Serv").prop("disabled", false).prop("checked", true);
    //                $paymentContainer.css({
    //                    "opacity": "1",
    //                    "pointer-events": "auto",
    //                    "cursor": "auto"
    //                });
    //            }
    //        } else {
    //            $roomInput.prop("disabled", false).removeAttr("readonly").css({
    //                "background-color": "#ffffff",
    //                "cursor": "auto",
    //                "pointer-events": "auto"
    //            });

    //            if ($paymentContainer.length) {
    //                $paymentContainer.find("input[type='radio']").prop("disabled", false);
    //                $paymentContainer.css({
    //                    "opacity": "1",
    //                    "pointer-events": "auto",
    //                    "cursor": "auto"
    //                });
    //            }
    //        }

    //        if ($roomDisplay.val() === "Not Applicable (NC)") {
    //            $roomDisplay.val("");
    //        }
    //        $roomDisplay.css({
    //            "background-color": "#f9f9f9",
    //            "color": "black"
    //        });
    //    }
    //}
    function checkNcAndLockRoom() {
        var $ncCheckbox = $("[id$='NC']");
        var isNcChecked = $ncCheckbox.is(":checked");

        var urlParams = getUrlVars();
        var roomFromUrl = urlParams["roomNo"];
        var savedRoom = localStorage.getItem("bill_roomNo");

        var $roomInput = $("[id$='txtRoomNo']");
        var $roomDisplay = $("[id$='txtRoomNoDisplay']");
        var $paymentContainer = $("#divpayment");

        // Check kar rahe hain ki kya room ka data maujood hai
        var hasRoomData = (roomFromUrl && roomFromUrl !== "-" && roomFromUrl !== "null" && roomFromUrl !== "undefined" && roomFromUrl.trim() !== "") ||
            (savedRoom && savedRoom !== "null" && savedRoom.trim() !== "");

        if (!hasRoomData && !isNcChecked) {
            // ========================================================
            // BHAI AGAR SAB BLANK HAI TOH SIRF YEH 3 CHEEZIN BLOCK HONGI
            // ========================================================

            // 1. Room Number Input block kar do
            $roomInput.val("").prop("disabled", true).attr("readonly", "readonly").css({
                "background-color": "#eeeeee",
                "cursor": "not-allowed",
                "pointer-events": "none"
            });
            if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                $roomInput.autocomplete("close");
            }
            $roomDisplay.val("").css({
                "background-color": "#eeeeee",
                "color": "black"
            });

            // 2. NC Checkbox block kar do
            $ncCheckbox.prop("disabled", true).css({
                "cursor": "not-allowed"
            });

            // 3. Room Service (#Room_Serv) block kar do, baaki saare payment chalu rahenge
            if ($paymentContainer.length) {
                // Saare payment buttons ko pehle active karo (taaki dusre use ho sakein)
                $paymentContainer.find("input[type='radio']").prop("disabled", false);

                // Lekin sirf Room Service (#Room_Serv) ko specifically disabled aur uncheck kar do
                $("#Room_Serv").prop("disabled", true).prop("checked", false);

                // Pure payment container ko lock nahi karenge, use click hone denge
                $paymentContainer.css({
                    "opacity": "1",
                    "pointer-events": "auto",
                    "cursor": "auto"
                });
            }

            $("[id$='hdnRTID']").val("");
            $("[id$='hdnGCID']").val("");

        } else if (isNcChecked) {
            // Condition 2: Agar NC Checked hai (Pehle jaisa hi)
            $ncCheckbox.prop("disabled", false);

            $roomInput.val("").prop("disabled", true).attr("readonly", "readonly").css({
                "background-color": "#eeeeee",
                "cursor": "not-allowed",
                "pointer-events": "none"
            });

            if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                $roomInput.autocomplete("close");
            }

            $roomDisplay.val("Not Applicable (NC)").prop("disabled", true).css({
                "background-color": "#eeeeee",
                "cursor": "not-allowed",
                "color": "#ff0000",
                "font-weight": "bold"
            });

            $("[id$='hdnRTID']").val("");
            $("[id$='hdnGCID']").val("");

            if ($paymentContainer.length) {
                $paymentContainer.find("input[type='radio']").prop("disabled", true);
            }
        } else {
            // Condition 3: Agar Room Number data maujood hai (Pehle jaisa hi)
            $ncCheckbox.prop("disabled", false);

            $roomInput.prop("disabled", true).attr("readonly", "readonly").css({
                "background-color": "#eeeeee",
                "cursor": "not-allowed",
                "pointer-events": "none"
            });

            if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                $roomInput.autocomplete("close");
            }

            if ($paymentContainer.length) {
                $paymentContainer.find("input[type='radio']").not("#Room_Serv").prop("disabled", true);
                $("#Room_Serv").prop("disabled", false).prop("checked", true); // Room Service chalu aur select ho jayegi
                $paymentContainer.css({
                    "opacity": "1",
                    "pointer-events": "auto",
                    "cursor": "auto"
                });
            }

            if ($roomDisplay.val() === "Not Applicable (NC)") {
                $roomDisplay.val("");
            }
            $roomDisplay.css({
                "background-color": "#f9f9f9",
                "color": "black"
            });
        }
    }

    $(document).ready(function () {
        var urlParams = getUrlVars();

        var id = urlParams["id"];
        var tablestatus = urlParams["status"];
        var orderType = urlParams["orderType"];
        var mode = urlParams["mode"];
        var roomFromUrl = urlParams["roomNo"];
        var ncNameFromUrl = urlParams["ncName"];
        var ncRadioFromUrl = urlParams["ncRadio"];
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

        if (mode === "readonly") {
            setTimeout(function () {
                HideControls();
                $("#closetable").hide();
                $("#btnback").val("Back to List");
            }, 1500);
        }

        if (ncRadioFromUrl === "NC") {
            $("[id$='NC']").prop('checked', true);
        } else if (localStorage.getItem("isNCSelected") === "true") {
            $("[id$='NC']").prop("checked", true);
            localStorage.removeItem("isNCSelected");
        }

        checkNcAndLockRoom();

        if (!$("[id$='NC']").is(":checked")) {
            if (roomFromUrl && roomFromUrl !== "-" && roomFromUrl !== "null" && roomFromUrl !== "undefined") {
                var decodedRoom = decodeURIComponent(roomFromUrl).replace(/\+/g, ' ');
                $("#txtRoomNoDisplay").val(decodedRoom);
                $("[id$='txtRoomNo']").val(decodedRoom);
            } else {
                var savedRoom = localStorage.getItem("bill_roomNo");
                if (savedRoom && savedRoom !== "null" && savedRoom !== "") {
                    $("[id$='txtRoomNo']").val(savedRoom);
                    $("#txtRoomNoDisplay").val(savedRoom);
                }
            }
        }

        if (ncNameFromUrl) {
            $("#txtcustname").val(decodeURIComponent(ncNameFromUrl).replace(/\+/g, ' '));
        }

        $("#divtablename").hide();
        $("#gotovoid").hide();

        DisplayOrderItems(id);
        SetButtonTextValue(orderType, tablename);

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

                        if (!$("[id$='NC']").is(":checked")) {
                            $("#txtRoomNoDisplay").val(roomValue);
                            $("[id$='txtRoomNo']").val(roomValue);
                        }

                        $("#txtcustaddress").val(r.CustomerAddress);
                        $("#txtcustemail").val(r.CustomerEmail);
                        $("#txtcustgst").val(r.CustomerGST);
                        $("#txtcustnumber").val(r.CustomerNumber);
                        $("#lbldiscount").html(r.TotalDiscount);
                        $("#lblcharge").html(r.Charge);
                        $("#txtgivenamount").val(r.GivenAmount);
                        $("#lblreturnamount").html(r.ReturnAmount);
                        SetPaymentMode(r.PayMode);
                        if (r.PayMode === "NC") { $("[id$='NC']").prop("checked", true); }

                        checkNcAndLockRoom();
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
                            $("#lblCGST").html(r.CGST);
                            $("#lblSGST").html(r.SGST);
                            $("#hdnGSTpercent").val(r.GSTPercent);
                            $("#lblgrandtotal").html(r.GSTGrandTotal);
                            $("#hdnGrandTotal").val(r.GSTGrandTotal);
                            grandTotal = r.GSTGrandTotal;
                            SGST = r.SGST;
                            CGST = r.CGST;
                            $("#txtcustname").val(r.NCName);
                            if (r.NCRadio === "NC" || r.PayMode === "NC") { $("[id$='NC']").prop("checked", true); }

                            checkNcAndLockRoom();
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

        // --- 🚀 CLOSE TABLE MASTER LOGIC (WITH GCID FALLBACK PROTECTION) ---
        $(document.body).on("click", "#closetable", function () {
            var id = getUrlVars()["id"];
            var selectedPaymentMode = $("input[name='fav_language']:checked").val() || "CASH";

            // Direct payment modes list
            var isDirectPayment = ["CASH", "CARD", "PAYTM", "PHONEPE", "GPAY", "MULTIPLE", "NC"].includes(selectedPaymentMode);

            // --- 1. CURRENT UI VALUES ---
            var currentSubTotal = parseFloat($("#subtotal").html()) || 0;
            var finalCharges = parseFloat($("#lblcharge").html()) || 0;
            var currentDiscount = parseFloat($("#lbldiscount").html()) || 0;
            var currentCGST = parseFloat($("#lblCGST").html()) || 0;
            var currentSGST = parseFloat($("#lblSGST").html()) || 0;
            var currentGrandTotal = parseFloat($("#lblgrandtotal").html()) || 0;
            var finalRoundedGrandTotal = Math.round(currentGrandTotal);

            var isGstApplied = $('#isApplyGST').is(':checked');

            // --- 2. ROOM & GCID RESOLUTION WITH LIVE FALLBACK ---
            var inputRoomNo = $("#txtRoomNo").val() ? $("#txtRoomNo").val().toString().trim() : "";
            var displayRoomNo = $("#txtRoomNoDisplay").val() ? $("#txtRoomNoDisplay").val().toString().trim() : "";
            var finalRoomNo = inputRoomNo || displayRoomNo;

            var rawGcid = $("#hdnGCID").val();
            var gcidValue = parseInt(rawGcid ? rawGcid.toString().trim() : "0", 10);

            // 🔥 [CRITICAL RECOVERY]: अगर gcidValue 0 या null है, लेकिन रूम नंबर मौजूद है, तो API से लाइव मैच कराओ
            if ((gcidValue === 0 || isNaN(gcidValue)) && finalRoomNo !== "" && finalRoomNo.toLowerCase() !== "not assigned" && finalRoomNo.toLowerCase() !== "not applicable (nc)") {
                console.log("GCID 0 या Null मिला! लाइव रिकवरी इंजन शुरू हो रहा है रूम के लिए: " + finalRoomNo);

                $.ajax({
                    url: "https://hotelpremierinn.rstpms.com/Hotel/API/GetOccupiedRooms",
                    type: "GET",
                    dataType: "json",
                    async: false, // सिंक्रोनस रखेंगे ताकि GCID मिलने के बाद ही नीचे का कोड चले
                    data: { companyid: 1040 },
                    success: function (occupiedRoomsList) {
                        $.each(occupiedRoomsList, function (index, item) {
                            // रूम नंबर मैच होते ही GCID और RTID रिकवर कर लो
                            if (item.RoomNo.toString().trim() === finalRoomNo.toString().trim()) {
                                gcidValue = parseInt(item.GCID, 10);
                                $("#hdnGCID").val(gcidValue);
                                $("#hdnRTID").val(item.RTID);
                                console.log("Success! GCID रिकवर हो गया: " + gcidValue);
                                return false; // लूप ब्रेक करने के लिए
                            }
                        });
                    }
                });
            }

            // अब चेक करो कि रूम वैलिड असाइन हुआ है या पेमेंट मोड Room Service है
            var isRoomAssigned = (gcidValue > 0) || (finalRoomNo !== "" && finalRoomNo !== "0" && finalRoomNo.toLowerCase() !== "not assigned" && finalRoomNo.toLowerCase() !== "not applicable (nc)");

            if (selectedPaymentMode.toLowerCase() === "room service" || selectedPaymentMode.toLowerCase() === "room_serv") {
                isRoomAssigned = true;
            }

            // --- 3. SALES ORDER OBJECT CREATION ---
            var salesOrder = new Object();
            var salesOrderList = [];

            salesOrder.OrderID = id;
            salesOrder.nLoginID = localStorage.getItem("nLoginId");
            salesOrder.sUserFullName = localStorage.getItem("sUserFullName");
            salesOrder.TableName = localStorage.getItem("current_tableName") || $("#lbltablename").text().trim() || "";
            salesOrder.CustomerName = $("#txtcustname").val();
            salesOrder.PayMode = selectedPaymentMode;
            salesOrder.GrandTotal = finalRoundedGrandTotal;
            salesOrder.SubTotal = currentSubTotal;
            salesOrder.TotalDiscount = currentDiscount;
            salesOrder.Charge = finalCharges;
            salesOrder.CGST = currentCGST;
            salesOrder.SGST = currentSGST;
            salesOrder.isApplyGST = isGstApplied;
            salesOrder.CustomerNumber = $("#txtcustnumber").val();
            salesOrder.CustomerAddress = $("#txtcustaddress").val();
            salesOrder.RoomNumber = finalRoomNo;

            salesOrderList.push(salesOrder);

            // --- 4. PAYLOAD PREPARATION (Items Mapping) ---
            var billPayloadArray = [];
            var today = new Date();
            var formattedDate = today.getDate().toString().padStart(2, '0') + '/' + (today.getMonth() + 1).toString().padStart(2, '0') + '/' + today.getFullYear();

            var discountRatio = currentSubTotal > 0 ? (currentDiscount / currentSubTotal) : 0;
            var rows = $("#OrderRow tr");
            var totalItems = rows.length;
            var runningTotal = 0;

            rows.each(function (index) {
                var menuDesc = $(this).find("td:eq(0)").text().trim();
                var menuId = $(this).find("td:eq(0)").attr("menuid");
                var rate = parseFloat($(this).find(".OneUnitPrice").text()) || 0;
                var qty = parseFloat($(this).find("td:eq(2)").text()) || 0;

                var itemTotalRaw = rate * qty;
                var itemDiscount = itemTotalRaw * discountRatio;
                var itemAfterDiscount = itemTotalRaw - itemDiscount;

                var itemSgst = 0;
                var itemCgst = 0;
                if (isGstApplied) {
                    itemSgst = Number((itemAfterDiscount * 0.025).toFixed(2));
                    itemCgst = Number((itemAfterDiscount * 0.025).toFixed(2));
                }

                var itemNetTotal = Number((itemAfterDiscount + itemSgst + itemCgst).toFixed(2));
                var finalItemNetTotal = 0;
                var roundOff = 0;

                if (index === totalItems - 1) {
                    finalItemNetTotal = parseFloat((finalRoundedGrandTotal - runningTotal).toFixed(2));
                    roundOff = parseFloat((finalItemNetTotal - itemNetTotal).toFixed(2));
                } else {
                    finalItemNetTotal = parseFloat(itemNetTotal.toFixed(2));
                    runningTotal += finalItemNetTotal;
                    roundOff = 0;
                }

                billPayloadArray.push({
                    "companyid": 1040,
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
                    "gcid": gcidValue, // 🔥 अब यहाँ कभी भी 0 या null नहीं जाएगा!
                    "menuid": menuId,
                    "paymentMode": selectedPaymentMode
                });
            });

            // --- 5. AJAX PIPELINE SEND ---
            $.ajax({
                type: "POST",
                data: JSON.stringify(salesOrderList),
                url: apiUrl + '/api/Item/UpdateOrderStatus/' + id,
                contentType: "application/json;charset=utf-8",
                success: function (response) {

                    // 🏨 होटल रूम बिल रूटिंग
                    if (isRoomAssigned && gcidValue > 0) {
                        console.log("Executing Route -> AddRestaurantBill API with GCID: " + gcidValue);
                        $.ajax({
                            type: "POST",
                            url: "https://hotelpremierinn.rstpms.com/Hotel/API/AddRestaurantBill",
                            data: JSON.stringify(billPayloadArray),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (res) {
                                alert("Hotel Room Bill Saved Successfully! Total: " + finalRoundedGrandTotal);
                                HideControls();
                            },
                            error: function (xhr, status, error) {
                                console.error("AddRestaurantBill Error:", xhr.responseText);
                                alert("Error executing Hotel Restaurant Room Bill endpoint.");
                            }
                        });
                    }
                    // 💵 काउंटर/कैश बिल रूटिंग
                    else if (isDirectPayment) {
                        console.log("Executing Route -> AddCashFoodBill API");
                        $.ajax({
                            type: "POST",
                            url: "https://hotelpremierinn.rstpms.com/Hotel/API/AddCashFoodBill",
                            data: JSON.stringify(billPayloadArray),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (res) {
                                alert("Counter Bill Closed Successfully! Total: " + finalRoundedGrandTotal);
                                HideControls();
                            },
                            error: function (xhr, status, error) {
                                console.error("AddCashFoodBill Error:", xhr.responseText);
                                alert("Error executing Cash Food Bill endpoint.");
                            }
                        });
                    }
                    else {
                        alert("Order Updated Successfully!");
                        HideControls();
                    }
                },
                error: function (xhr, status, error) {
                    alert("Master Order Database Sync Failed.");
                }
            });
        });

        // Navigation Handlers
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

        // --- 🖨️ RAVI'S THERMAL PRINTER ROUTINES ---
        function openWindowForPrint(url) {
            var myWindow = window.open(url, "myWindow", "width=200,height=100");
            setTimeout(function () { if (myWindow) myWindow.close(); }, 200);
        }

        $(document.body).on("click", "#printwithoutgst", function () {
            if ($('#OrderRow tr').length > 0) {
                var orderID = getUrlVars()["id"];
                if (orderID) {
                    var printUrl = "http://127.0.0.1:8085/api/Printing/Print/" + orderID + "?printerName=LAN1";
                    openWindowForPrint(printUrl);
                } else {
                    alert("Order ID not found!");
                }
            } else {
                alert("The cart is empty. Cannot generate a print!");
            }
        });

        $(document.body).on("click", "#printbill", function () {
            if ($('#OrderRow tr').length > 0) {
                var orderID = getUrlVars()["id"];
                if (orderID) {
                    var printUrl = "http://127.0.0.1:8085/api/Printing/PrintWithGst/" + orderID + "?printerName=LAN1";
                    openWindowForPrint(printUrl);
                } else {
                    alert("Order ID not found!");
                }
            } else {
                alert("The cart is empty. Cannot generate a print!");
            }
        });
    });

    // Calculations Modules
    function recalculateAll(subTotal, discountAmount, charges) {
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

        $("#Total_aft_Dis").html(totalAfterDisc.toFixed(2));
        $("#lbldiscount").html(discountAmount.toFixed(2));
        $("#lblCGST").html(cgst.toFixed(2));
        $("#lblSGST").html(sgst.toFixed(2));
        $("#lblcharge").html(charges.toFixed(2));
        $("#lblgrandtotal").html(roundedGrandTotal.toFixed(2));
        $("#hdnGrandTotal").val(roundedGrandTotal);
        $("#lblRoundOff").html((roundOffValue >= 0 ? "+" : "") + roundOffValue.toFixed(2));

        var orderId = getUrlVars()["id"];
        var billingData = {
            discountPercent: $("#txtdiscount").val() || "0",
            discountValue: discountAmount.toFixed(2),
            chargePercent: $("#txtchargepercent").val() || "0",
            chargeValue: charges.toFixed(2),
            roundOff: roundOffValue.toFixed(2),
            grandTotal: roundedGrandTotal
        };
        localStorage.setItem("bill_data_" + orderId, JSON.stringify(billingData));
    }

    function CalculateDisc() {
        var discountPercent = $("#txtdiscount").val().trim();
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentCharges = parseFloat($("#lblcharge").html()) || 0;

        if (discountPercent !== "" && !isNaN(discountPercent) && parseFloat(discountPercent) >= 0) {
            $("#txtdisccountvalue").val("").prop("disabled", true);
            var discountAmount = (subTotal * parseFloat(discountPercent)) / 100;
            recalculateAll(subTotal, discountAmount, currentCharges);
        } else {
            ResetToOriginalTotal();
        }
    }

    function CalculateDiscountbasedonValue() {
        var discountValue = $("#txtdisccountvalue").val().trim();
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentCharges = parseFloat($("#lblcharge").html()) || 0;

        if (discountValue !== "" && !isNaN(discountValue) && parseFloat(discountValue) >= 0) {
            $("#txtdiscount").val("").prop("disabled", true);
            recalculateAll(subTotal, parseFloat(discountValue), currentCharges);
        } else {
            ResetToOriginalTotal();
        }
    }

    function CalculateCharge() {
        var chargeVal = parseFloat($("#txtcharges").val()) || 0;
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentDisc = parseFloat($("#lbldiscount").html()) || 0;

        if (chargeVal >= 0) {
            $("#txtchargepercent").val("").prop("disabled", (chargeVal > 0));
            $("#lblcharge").html(chargeVal.toFixed(2));
            recalculateAll(subTotal, currentDisc, chargeVal);
        } else {
            ResetToOriginalTotal();
        }
    }

    function CalculateChargebasedonPercent() {
        var chargePercent = parseFloat($("#txtchargepercent").val()) || 0;
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        var currentDisc = parseFloat($("#lbldiscount").html()) || 0;

        if (chargePercent > 0) {
            $("#txtcharges").val("").prop("disabled", true);
            var calculatedCharge = (subTotal * chargePercent) / 100;
            $("#lblcharge").html(calculatedCharge.toFixed(2));
            recalculateAll(subTotal, currentDisc, calculatedCharge);
        } else {
            ResetToOriginalTotal();
        }
    }

    function ResetToOriginalTotal() {
        var subTotal = parseFloat($("#subtotal").html()) || 0;
        $("#txtdiscount, #txtdisccountvalue, #txtcharges, #txtchargepercent").val("").prop("disabled", false);
        recalculateAll(subTotal, 0, 0);
    }

    function DisplayOrderItems(id) {
        $.ajax({
            type: "GET",
            url: apiUrl + '/api/Item/OrderDetailbyOrderID/' + id,
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                var orderDetail = "";
                $.each(data, function (i) {
                    orderDetail += '<tr><td menuId="' + data[i].ItemMasterID + '"><a href="#">' + data[i].ProductName + '</a></td><td id="' + data[i].SalesOrderDetailID + '" class="OneUnitPrice">' + data[i].ActualCost + '</td><td class="ng-tns-c8-2" >' + data[i].ProductQty + '</td><td class="discount">0</td><td class="totalPrice">' + data[i].TotalAmount + ' </td></tr>';
                });
                $("#OrderRow").html(orderDetail);
            }
        });
    }

    function GivenReturnCalculation() {
        var givenamnt = parseFloat($('#txtgivenamount').val()) || 0;
        var grandtot = parseFloat($("#lblgrandtotal").html()) || 0;
        if (givenamnt > 0) {
            $('#lblreturnamount').html((givenamnt - grandtot).toFixed(2));
        } else {
            $('#lblreturnamount').html("0.00");
        }
    }

    function getUrlVars() {
        var vars = [];
        window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
            vars[key] = value;
        });
        return vars;
    }

    function HideControls() {
        $("input, select, textarea").not("#btnback, #printbill, #printwithoutgst, #gototorderlist").prop("disabled", true).attr("disabled", "disabled");
        $("#closetable, #chargelist, #Button6, #isApplyGST").hide();
        $("#divpayment").css({ "pointer-events": "none", "opacity": "0.7" });
    }

    function SetPaymentMode(PayMode) {
        $("input[name='fav_language']").prop("checked", false);
        if (!PayMode) return;

        var cleanMode = PayMode.toLowerCase().trim();
        var targetId = "";

        if (cleanMode === "room service" || cleanMode === "room_serv" || cleanMode === "room serv") {
            targetId = "Room_Serv";
        } else if (cleanMode === "cash") {
            targetId = "cash";
        } else if (cleanMode === "card") {
            targetId = "card";
        } else if (cleanMode === "paytm") {
            targetId = "paytm";
        } else if (cleanMode === "phonepe") {
            targetId = "phonepe";
        } else if (cleanMode === "gpay") {
            targetId = "gpay";
        } else if (cleanMode === "nc") {
            targetId = "NC";
        }

        if (targetId !== "") {
            $("#" + targetId).prop("checked", true);
        }
    }

    function SetButtonTextValue(orderType, tablename) {
        if (orderType === "1") $("#gototorderlist").val('Back to Take Away Report');
        if (orderType === "2") $("#gototorderlist").val('Back to Door Delivery Report');
        if (orderType === "3" || orderType === "4") {
            $("#divtablename").show();
            $("#lbltablename").html(tablename);
            $("#gototorderlist").val(orderType === "3" ? 'Back to Dine-In Report' : 'Back to Dastarkhan Report');
        }
    }

    function GetTableName(tableID) {
        var rettablename = "";
        $.ajax({
            type: "GET",
            url: apiUrl + '/api/DineIn/GetTableName/' + tableID,
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (response) {
                if (response) rettablename = response;
            }
        });
        return rettablename;
    }

    $("#txtRoomNo").autocomplete({
        minLength: 1,
        source: function (request, response) {
            $.ajax({
                url: "https://hotelpremierinn.rstpms.com/Hotel/API/GetOccupiedRooms",
                type: "GET",
                dataType: "json",
                data: { companyid: 1040 }, // 🔥 FIXED BACK TO 1040
                success: function (data) {
                    var uniqueRooms = [];
                    var roomSet = new Set();
                    $.each(data, function (index, item) {
                        if (!roomSet.has(item.RoomNo)) {
                            roomSet.add(item.RoomNo);
                            uniqueRooms.push(item);
                        }
                    });
                    response($.map(uniqueRooms, function (item) {
                        return { label: item.RoomNo, value: item.RoomNo, rtId: item.RTID, gcid: item.GCID };
                    }));
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




