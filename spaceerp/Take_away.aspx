<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Take_away.aspx.cs" Inherits="Admin_Dine_in" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">    
    <link href="css/floating-form.css" rel="stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet" />
    <!-- jQuery -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <link href="css/jquery-ui.min.css" rel="stylesheet" />    
    <script src="js/jquery-3.6.0.js"></script>
    <script src="js/jquery-ui.min.js"></script>
    <!--//skycons-icons-->
    <link href="css/customRestro.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    
    <link href="css/CustomTake.css" rel="stylesheet" />
    <link href="css/floating-form.css" rel="stylesheet" />
  <style>
      .tbClose {
          display: block;
          float: right;
      }
      /* Input field ko chota aur clean banane ke liye */
.room-input {
    width: 100% !important;
    max-width: 200px; /* Isse width control mein rahegi */
    height: 34px;
    padding: 6px 12px;
    font-size: 14px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
    transition: border-color ease-in-out .15s, box-shadow ease-in-out .15s;
}

.room-input:focus {
    border-color: #66afe9;
    outline: 0;
    box-shadow: inset 0 1px 1px rgba(0,0,0,.075), 0 0 8px rgba(102,175,233,.6);
}

/* Autocomplete dropdown (UI-Menu) ko sundar banane ke liye */
.ui-autocomplete {
    background: #ffffff !important;
    border: 1px solid #ddd !important;
    border-radius: 4px;
    box-shadow: 0 5px 10px rgba(0,0,0,0.2);
    max-height: 200px;
    overflow-y: auto;
    overflow-x: hidden;
    z-index: 9999 !important; /* Dialog ke upar dikhne ke liye */
}

.ui-menu-item {
    padding: 8px 12px;
    border-bottom: 1px solid #eee;
    cursor: pointer;
    font-size: 13px;
}

.ui-menu-item:last-child {
    border-bottom: none;
}

.ui-state-active, .ui-widget-content .ui-state-active {
    background-color: #337ab7 !important; /* Blue color highlight */
    color: #fff !important;
    border: none !important;
}
.well, .input-group {
    overflow: visible !important;
}
    ul.ui-autocomplete {
    position: absolute !important; 
    z-index: 999999 !important; /* Ek zero aur badha diya */
}
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        // 🛠️ CHHOTA REUSABLE FUNCTION TO LOCK/UNLOCK ROOM INPUT FIELD
        function checkNcAndLockRoom() {
            var isNcChecked = $("#nc").is(":checked");
            if (isNcChecked) {
                // Input disable karo, value clear karo, and pointer-events: none se bilkul unclickable bana do
                $("#txtRoomNo").val("").prop("disabled", true).css({
                    "background-color": "#eeeeee",
                    "cursor": "not-allowed",
                    "pointer-events": "none"
                });
                $("#hdnRTID").val("");
                $("#hdnGCID").val("");
            } else {
                // Wapas enable karo
                $("#txtRoomNo").prop("disabled", false).css({
                    "background-color": "#ffffff",
                    "cursor": "auto",
                    "pointer-events": "auto"
                });
            }
        }

        $(document).ready(function () {
            // Helper function to get URL parameters
            function getUrlParameter(name) {
                name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
                var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
                var results = regex.exec(location.search);
                return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
            }
            var urlParams = new URLSearchParams(window.location.search);
            var ncRadioVal = urlParams.get('ncRadio');

            if (ncRadioVal === "NC") {
                // Take_away page par id 'nc' hai
                $("#nc").prop('checked', true);

                // Agar pehle se koi logic hai storage ka toh sync rakho
                localStorage.setItem("isNCSelected", "true");
                console.log("Takeaway: NC Radio Autofilled");
            }
            // Capture values from URL
            var roomFromUrl = getUrlParameter('roomNo');
            var ncFromUrl = getUrlParameter('ncName');
            var ncRadioFromUrl = getUrlParameter('ncRadio');
            // Auto-fill the fields if values exist
            if (roomFromUrl !== "") {
                // Using [id$=''] because ASP.NET sometimes mangles IDs (e.g., ctl00_txtRoomNo)
                var $roomInput = $("#txtRoomNo").length ? $("#txtRoomNo") : $("[id$='txtRoomNo']");
                $roomInput.val(roomFromUrl).trigger('input').trigger('change');
                console.log("Auto-filled Room No:", roomFromUrl);
            }

            if (ncFromUrl !== "") {
                var $ncInput = $("#txtNCName").length ? $("#txtNCName") : $("[id$='txtNCName']");
                $ncInput.val(ncFromUrl).trigger('input').trigger('change');
                console.log("Auto-filled NC Name:", ncFromUrl);
            }
            // 3. 🔥 Auto-check NC Radio Button
            if (ncRadioFromUrl === "NC") {
                // Radio button ko id 'nc' se dhund kar check kar dega
                $("#nc").prop('checked', true);

                // Agar aapne niche koi custom logic likha hai localStorage ke liye, toh usey bhi update kar dega
                localStorage.setItem("isNCSelected", "true");
                console.log("Auto-selected NC Radio based on URL");
            }

            // Page load hotey hi state check karo (In case URL se NC select hoke aaya ho)
            checkNcAndLockRoom();
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
        <div class="col-md-5 col-xs-12 mobi_none mobad">
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
            <!--custom-widgets-->
            <div class="custom-widgets">
                <div class="row-one" id="GroupData">

                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-5 col-sm-5 col-xs-8 nopad mobipad-2">
        <div class="scroll-box mob-height300" style="width: 100%; float: left; height: 400px;">
            <!--custom-widgets-->
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

                <!---->
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
                    <div class="input-group">
                        <span class="input-group-addon" style="font-weight:bold;">Room No:</span>
                        <input type="text" id="txtRoomNo" class="form-control room-input" placeholder="Search Room..." autocomplete="off" />
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
    <!-- Added name="fav_language" to group it with others -->
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
    <script>
        $(document).ready(function () {

            $('#openBtn').click(function () {
                $('#myModal').modal({
                    show: true
                })
            });

            $(document).on('show.bs.modal', '.modal', function (event) {
                var zIndex = 1040 + (10 * $('.modal:visible').length);
                $(this).css('z-index', zIndex);
                setTimeout(function () {
                    $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
                }, 0);
            });
            // Variable to keep track of the last checked radio button
            var lastChecked = null;

            $('input[name="fav_language"]').on('click', function () {
                if (lastChecked === this) {
                    // If clicking the same one again, uncheck it
                    this.checked = false;
                    lastChecked = null;
                    localStorage.removeItem("isNCSelected");
                } else {
                    lastChecked = this;

                    // Check if the specific one clicked is 'nc'
                    if (this.id === 'nc') {
                        localStorage.setItem("isNCSelected", "true");
                    } else {
                        localStorage.removeItem("isNCSelected");
                    }
                }

                // 🔥 MERI ADDED LINE: Jab bhi radio click hoga, checkNcAndLockRoom run ho jayega
                checkNcAndLockRoom();
            });

        });
    </script>

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
            $(".spltab").click(function () {
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