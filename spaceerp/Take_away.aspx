<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Take_away.aspx.cs" Inherits="Admin_Dine_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    <link href="css/floating-form.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <link href="css/font-awesome.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />    
    <script src="js/jquery-3.6.0.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <link href="css/customRestro.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    
    <link href="css/CustomTake.css" rel="stylesheet" />
    <link href="css/floating-form.css" rel="stylesheet" />
<style>

    .search-container-relative {
        position: relative;
    }

    /* 🔥 FORCED UPWARD DROPDOWN */
    .ui-autocomplete.custom-room-dropdown {

        position: absolute !important;

        left: 0 !important;

        width: 100% !important;

        background: #ffffff !important;

        border: 1px solid #cbd5e1 !important;

        border-radius: 6px !important;

        box-shadow: 0 -6px 16px rgba(0,0,0,0.15) !important;

        max-height: 180px;

        overflow-y: auto;

        overflow-x: hidden;

        z-index: 99999999 !important;

        padding: 4px 0;
    }

    .ui-autocomplete.custom-room-dropdown .ui-menu-item-wrapper {

        padding: 8px 14px !important;

        border-bottom: 1px solid #f1f5f9;

        cursor: pointer;

        font-size: 13px;

        color: #334155;

        font-family: 'Plus Jakarta Sans', sans-serif !important;
    }

    .ui-autocomplete.custom-room-dropdown .ui-menu-item:last-child .ui-menu-item-wrapper {
        border-bottom: none;
    }

    .ui-autocomplete.custom-room-dropdown .ui-state-active {

        background-color: #1b4aab !important;

        color: #ffffff !important;

        border: none !important;

        border-radius: 0px !important;

        margin: 0 !important;
    }

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        // 🛠️ REUSABLE FUNCTION TO LOCK/UNLOCK ROOM INPUT FIELD & CLOSE POPUP
        function checkNcAndLockRoom() {
            var $ncCheckbox = $("[id$='nc']");
            var isNcChecked = $ncCheckbox.is(":checked");

            // Safe URL parameters evaluation layer
            var urlParams = new URLSearchParams(window.location.search);
            var roomFromUrl = urlParams.get('roomNo');

            // Clean value check string check safely
            var hasValidRoomUrl = (roomFromUrl && roomFromUrl !== "" && roomFromUrl !== "-" && roomFromUrl !== "null" && roomFromUrl !== "undefined");

            var $roomInput = $("[id$='txtRoomNo']");
            var $ncNameInput = $("[id$='txtNCName']");

            if (isNcChecked) {
                // Input disable karo, value clear karo, aur pointer-events block karke lock karo
                $roomInput.val("").prop("disabled", true).css({
                    "background-color": "#eeeeee",
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                });

                // Force close autocomplete menu if open
                if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                    $roomInput.autocomplete("close");
                }

                $ncNameInput.prop("disabled", false).css({
                    "background-color": "#ffffff",
                    "cursor": "auto",
                    "pointer-events": "auto"
                });

                $("[id$='hdnRTID']").val("");
                $("[id$='hdnGCID']").val("");
            } else {
                // LOCK ONLY IF REDIRECTED WITH VALID ROOM
                if (hasValidRoomUrl) {
                    $roomInput.prop("disabled", true).css({
                        "background-color": "#eeeeee",
                        "cursor": "not-allowed",
                        "pointer-events": "none"
                    });
                    if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                        $roomInput.autocomplete("close");
                    }
                } else {
                    // Fresh First-Time Order case
                    $roomInput.prop("disabled", false).css({
                        "background-color": "#ffffff",
                        "cursor": "auto",
                        "pointer-events": "auto"
                    });
                }

                $ncNameInput.val("").prop("disabled", true).css({
                    "background-color": "#eeeeee",
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                });
            }
        }

        $(document).ready(function () {
            function getUrlParameter(name) {
                name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
                var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
                var results = regex.exec(location.search);
                return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
            }

            var urlParams = new URLSearchParams(window.location.search);
            var ncRadioVal = urlParams.get('ncRadio');
            var existingOrderId = urlParams.get('id');

            var $ncCheckbox = $("[id$='nc']");

            if (ncRadioVal === "NC") {
                $ncCheckbox.prop('checked', true);
                localStorage.setItem("isNCSelected", "true");
            }

            var roomFromUrl = getUrlParameter('roomNo');
            var ncFromUrl = getUrlParameter('ncName');
            var ncRadioFromUrl = getUrlParameter('ncRadio');

            var $roomInput = $("[id$='txtRoomNo']");

            if (roomFromUrl !== "" && roomFromUrl !== "null" && roomFromUrl !== "undefined" && roomFromUrl !== "-") {
                $roomInput.val(roomFromUrl).prop("disabled", true).css({
                    "background-color": "#eeeeee",
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                }).trigger('input').trigger('change');

                setTimeout(function () {
                    if ($roomInput.data("ui-autocomplete") || $roomInput.autocomplete("instance")) {
                        $roomInput.autocomplete("close");
                    }
                }, 100);

                $("[id$='Room_Serv']").prop("checked", true);
                console.log("Redirected Order: Room field populated and locked successfully.", roomFromUrl);
            } else {
                $roomInput.prop("disabled", false).css({
                    "background-color": "#ffffff",
                    "cursor": "auto",
                    "pointer-events": "auto"
                });
                console.log("Fresh Counter Order: Room field is unlocked for search.");
            }

            if (ncFromUrl !== "") {
                var $ncInput = $("[id$='txtNCName']");
                $ncInput.val(ncFromUrl).trigger('change');
            }

            if (ncRadioFromUrl === "NC") {
                $ncCheckbox.prop('checked', true);
                localStorage.setItem("isNCSelected", "true");
            }

            // 🔥 MASTER ID ENGINE FIX: Agar existing order load ho rha h, toh NC button lock ho par baaki saare action buttons ENALBED ho jayein!
            if (existingOrderId && existingOrderId !== "" && existingOrderId !== "0") {
                // 1. NC button ko un-check hone se lock karo
                $ncCheckbox.prop("disabled", true).css({
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                }).parent().css({
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                });

                // 2. 🔥 BUTTON ENABLE FIX: Saare action buttons ko strictly force enable karo taaki operation block na ho
                $("#closetable, #printbill, #saveKot, #printviewbill, #printwithoutgst, #gotopendorder, #gotodine, #gotodash, #gotocancel")
                    .prop("disabled", false)
                    .removeAttr("disabled")
                    .show()
                    .css({
                        "pointer-events": "auto",
                        "cursor": "pointer",
                        "opacity": "1"
                    });

                console.log("Existing Order Flow: NC frozen, Action buttons forced ENABLED.");
            }

            // Trigger structural initial verification layer
            checkNcAndLockRoom();

            // MASTER ENGINE CLICK SYNC BOUNDARY
            var lastChecked = null;
            $ncCheckbox.on('click', function () {
                if (lastChecked === this) {
                    this.checked = false;
                    lastChecked = null;
                    localStorage.removeItem("isNCSelected");
                } else {
                    lastChecked = this;
                    if (this.id.toLowerCase().indexOf('nc') !== -1 || $(this).val() === "NC") {
                        localStorage.setItem("isNCSelected", "true");
                    } else {
                        localStorage.removeItem("isNCSelected");
                    }
                }
                checkNcAndLockRoom();
            });
        });
    </script>



    <input type="hidden" runat="server" id="hdnApiurl" />
    <div id="RemarkModal" class="modal">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Item Remarks </h4>
                </div>
                <div class="modal-body">
                    <div class="floating-label">
                        <input type="text" id="txtremarks" class="floating-input" placeholder="" />
                        <span class="highlight"></span>
                        <label>Enter Remarks Here<span></span></label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="closeremark" class="btn btn-primary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary saveRemark" data-dismiss="modal">Save</button>
                </div>
            </div>
        </div>
    </div>

    <input type="hidden" id="hdnOrderID" value="" />
    <input type="hidden" id="hiddenGroupID" value="" />
    <div class="col-md-12 well">
        <div class="col-md-4 col-sm-8 col-xs-12 mopad">
            <input class="form-control topsrch" id="Destopsearch" onblur="this.placeholder = ''" onfocus="this.placeholder = 'Search Item Name (Ex: Aloo Gobi)'" style="width: 100%" type="search" placeholder="" />
        </div>
        <div class="col-md-2 col-sm-4 mobi-marginTop-10" id="divacnonac" style="display:none;">
            <select id="ddlacnonac" name="ddlacnonac" class="form-control js-example-placeholder-single" style="padding: 0px !important;">
                <option value="0">Select AC / NON-AC </option>
                <option value="1">NON - AC</option>
                <option value="2">AC</option>
            </select>

        </div>
        <div class="col-md-5 col-xs-12 mopai_none mopad">
            <div class="col-md-3 col-xs-3">
                <div id="divtablename" class="colpsbox_one_top" style="padding-left: 35px;">
                    <div class="icon_corner">
                        <i class="material-icons">event_seat</i>
                    </div>
                    <span id="lbltablename"></span>
                </div>
            </div>
            <div class="col-md-4 col-xs-4">
                <div class="colpsbox_one_top" style="padding-left: 35px;">
                    <div class="icon_corner">
                        <i class="material-icons">local_dining</i>
                    </div>
                    <span id="lblheading"></span>
                </div>
            </div>
            <div class="col-md-5 col-xs-5">
                <div class="colpsbox_one_top" style="padding-left: 30px;">
                    <div class="icon_corner">
                        <i class="material-icons">access_time </i>
                    </div>
                    <span class="dateTime">
                        <span id="time"></span>
                        <span id="date"></span>
                    </span>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-2 col-sm-2 col-xs-4 mopad">
        <div class="scroll-box mob-height300" style="width: 100%; float: left; height: 400px;">
            <div class="custom-widgets">
                <div class="row-one" id="GroupData">

                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-5 col-sm-5 col-xs-8 nopad mobipad-2">
        <div class="scroll-box mob-height300" style="width: 100%; float: left; height: 400px;">
            <div id="GroupItemData" class="custom-widgets">
                <div class="row-one">
                    <div class="clearfix"></div>
                </div>
            </div>

        </div>
    </div>
    <div class="col-md-5 col-sm-5 col-xs-12 padSm-0">
        <div class="scroll-box" style="width: 100%; float: left; height: 300px;">
            <table class="table cart-table table-responsive-xs" id="itemloaded">
                <thead>
                    <tr class="table-head">
                        <th scope="col" class="w-30">Item Name</th>
                        <th scope="col">Unit Price</th>
                        <th scope="col"><span class="mobiBlock">Item</span>Quantity</th>
                        <th scope="col" class="w-10">Remarks</th>
                        <th scope="col">Total</th>
                    </tr>
                </thead>
                <tbody id="OrderRow">
                </tbody>
            </table>
        </div>
        

        <table class="table cart-table table-responsive-md">
            <tfoot class="bt1">
                <tr>
                    <td>Dish Total Amount (Rs.) :</td>
                    <td>
                        <label id="lbltotalamount"></label>
                    </td>
                </tr>
            </tfoot>
        </table>
        

        <div class=" col-md-12 text-center mt-5">
            <input type="button" class="btn btn-primary" id="closetable" name="closetable" value="Close Table" />
            <input type="button" class="btn btn-primary" id="printbill" name="printbill" value="Print Bill" />
            <input type="button" class="btn btn-primary" id="saveKot" name="saveKot" value="Save KOT" />
            <input type="button" class="btn btn-primary" id="printviewbill" name="printviewbill" value="Print/ View Bill" />
            <input type="button" class="btn btn-primary" id="printwithoutgst" name="printwithoutgst" value="Print Bill" />
            <input type="button" class="btn btn-primary" id="gotopendorder" name="gotopendorder" value="Go To Pend Order" />
            <input type="button" class="btn btn-primary" id="gotodine" name="gotodine" value="Go To Dine-In" />
            <input type="button" class="btn btn-primary" id="gotodash" name="gotodash" value="Go To Dashboard" />
            <input type="button" class="btn btn-primary" id="gotocancel" name="gotocancel" value="Go To Cancelled Order" />
        </div>
       <div class="col-md-12 well" style="padding: 10px; background: #f9f9f9; border: 1px solid #ddd;">
            <div class="row">
            <div class="col-md-4">

    <!-- 🔥 IMPORTANT -->
    <div class="search-container-relative">

        <div class="input-group">

            <span class="input-group-addon" style="font-weight:bold;">
                Room No:
            </span>

            <input type="text"
                   id="txtRoomNo"
                   class="form-control room-input"
                   placeholder="Search Room..."
                   autocomplete="off" />

        </div>

    </div>

    <input type="hidden" id="hdnRTID" />

    <input type="hidden" id="hdnGCID" />

</div>
            <div class="col-md-8">
                <div class="input-group">
                    <span class="input-group-addon" style="font-weight:bold;">NC Name:</span>
                    <input type="text" id="txtNCName" class="form-control" placeholder="Enter NC Name..." autocomplete="off" />
                </div>
               
             </div>
             
            </div>
        </div>
     <td>
    <input type="radio" id="nc" name="fav_language" value="NC" />
    <label for="nc">NC</label>
</td>
        <div style="margin: 10px;">
            <table>
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
        
    </div>

    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel">Modal title</h4>
                </div>
                <div class="modal-body">
                    ...
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary">Save changes</button>
                </div>
            </div>
        </div>
    </div>

    <%--Date & Time by asif --%>
    <script>
        var myVar = setInterval(myTimer, 1000);
        function myTimer() {
            var d = new Date();
            var t = d.toLocaleTimeString(navigator.language, { hour: '2-digit', minute: '2-digit' });
            document.getElementById("date").innerHTML = d.toLocaleDateString();
            document.getElementById("time").innerHTML = t;
        }
    </script>
    <%--// Group Item active inactive button  By asif --%>
    <script>
        $(document).ready(function () {
            $(document).on("click", ".spltab", function () {
                $(".spltab").removeClass("active");
                $(this).addClass("active");
            });
        });
    </script>
    <script>
        $(function () {
            $("#ApplyGST").click(function () {
                if ($(this).is(":checked")) {
                    $("#Drop-of").css('display', 'block');
                } else {
                    $("#Drop-of").css('display', 'none');
                }
            });
        });
    </script>
    <script src="js/takeaway-min.js"></script>
    
</asp:Content>