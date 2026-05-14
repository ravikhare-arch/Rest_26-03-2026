<%@ Page Title="" Language="C#" MasterPageFile="~/pagecontent.master" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="Server">
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <!-- Graph CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css' />
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <!-- //lined-icons -->
    <script src="js/jquery-1.10.2.min.js"></script>
    
    <link href="css/customize-model.css" rel="stylesheet" />
    <!--//skycons-icons-->
    <link href="../css/customdash.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <link href="css/CustomWelcome.css" rel="stylesheet" />   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <input type="hidden" runat="server" id="hdnApiurl" />
    <div class="outter-wp myTabs">
        <!--custom-widgets-->
        <div class="custom-widgets">
            <div class="row-one">
                <div class="col-md-3 widget">
                    <div class="stats-left ">
                        <h5>All Sales</h5>
                        <h4>
                            <span class="toggleHid"><span id="allsals">xxxxxx </span></span>
                            <span class="toggleHide">
                                <span id="passw">
                                    <input type="password" class="width-50" id="password" onkeydown="if (event.keyCode == 13) document.getElementsByClassName('bgEven').click()" />
                                    <input type="button" class="bgEven" value="Enter" onclick="if (document.getElementById('password').value == 'admin') {
    document.getElementById('passtog').classList.toggle('showIt'); document.getElementById('passw').style.display = 'none';
}
else { alert('Invalid Password!'); password.setSelectionRange(0, password.value.length); } " />
                                </span>
                                <span id="passtog"><span id="HIDDENDIV">₹<span id="allsales"> 0.00 </span></span></span>
                            </span>
                            <span><i class="fa fa-eye"></i></span>
                        </h4>
                    </div>
                    <div class="stats-right">
                        <label><i class="fa fa-cutlery"></i></label>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-3 widget states-mdl">
                    <div class="stats-left">
                        <h5>Total Dine-in Sales</h5>
                        <h4><span class="toggleHid"><span>xxxxxx </span></span>
                            <span class="toggleHide">₹<span id="dinein">0.00</span></span>
                            <i class="fa fa-eye"></i></h4>
                    </div>
                    <div class="stats-right">
                        <label><i class="fa fa-money"></i></label>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-3 widget states-thrd">
                    <div class="stats-left">
                        <h5>Total Room Service Sales</h5>
                        <h4><span class="toggleHid"><span>xxxxxx </span></span>
                            <span class="toggleHide">₹<span id="doordelivery">0.00</span></span>
                            <i class="fa fa-eye"></i></h4>
                    </div>
                    <div class="stats-right">
                        <label><i class="fa fa-database"></i></label>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="col-md-3 widget states-last">
                    <div class="stats-left">
                        <h5>Total TakeAway Sales</h5>
                        <h4><span class="toggleHid"><span>xxxxxx </span></span>
                            <span class="toggleHide">₹<span id="takeaway">0.00</span></span>
                            <i class="fa fa-eye"></i></h4>
                    </div>
                    <div class="stats-right">
                        <label><i class="fa fa-comments"></i></label>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="clearfix"></div>
            </div>
        </div>
        <div id="exampleModal" class="modal">
            <div class="modal-dialog modal-lg" role="dialog">
                <!-- Modal content -->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">×</button>
                        <h4 class="modal-title">Dine In Order</h4>
                    </div>
                    <div class="scroll-box" style="width: 100%; float: left; height: 360px;">
                        <div class="col-md-12 text-left">
                            <h5><strong>Table No.</strong>
                                <label id="lbltablename"></label>
                            </h5>
                            <h5><strong>Order No.:</strong>
                                <label id="lblordername"></label>
                            </h5>
                        </div>
                        <div class="col-md-12">
                            <div>
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




                                </table>
                            </div>




                            <div class=" col-md-12 text-right">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <input type="button" class="btn btn-primary" id="closetable" name="closetable" value="Close">
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12">
            <div class="card card-default mb-3">
                <div class="card-header tabs clps_desn">
                    <span class="tabspcl active" data-target="#tab-3" id="3"><i class="fa fa-cutlery fa-fw"></i>Dine In</span>
                   <%--  <span class="tabspcl" data-target="#tab-3"  id="4"><i class="fa fa-cutlery fa-fw"></i>Room Service</span>--%>
                    <a  href="Take_away.aspx?orderType=1"><i class="fa fa-cutlery fa-fw"></i>Take away</a>
                    <a  href="Take_away.aspx?orderType=2"><i class="fa fa-cutlery fa-fw"></i>Room Service</a>
                    <a  href="Restaurant/Table/PendingOrderlist.aspx"><i class="fa fa-cutlery fa-fw"></i>Pending Sales</a>
                </div>
                <div class="tab_container">
                    <div id="tab-3" class="tab-pane active">
                        <div id="dinearea">
                           
                        </div>

                        <div id="London" class="tab-pane city">
                        </div>
                       

                    </div>
                    <div id="tab-4">
<%--                        <iframe src="Dine_In.aspx?orderType=4" class="tab-pane fade in show" width="100%" height="100%" style="min-height: 500px; border: none;"></iframe>--%>
                    </div>
                </div>



            </div>
        </div>
        <div class="col-lg-12">
            <div class="card card-default mb-3">
                <div class="card-header tabs">
                    <a class="tabspcl active" data-target="#tab-1"><i class="fa fa-cutlery fa-fw"></i>Recent Orders</a>
                    <a class="tabspcl" data-target="#tab-2"><i class="fa fa-cutlery fa-fw"></i>Online Recent Orders</a>
                </div>
                <div class="tab_container">
                    <div id="tab-1" class="tab-pane active">
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Order Id</th>
                                        <th>Room No.</th>
                                        <th>Date</th>
                                        <th>Time</th>
                                          <th>Running Timer</th>
                                        <th>Order Type</th>
                                     
                                         <th>Table Name</th>
                                        <th>Total Paid Amount</th>
                                        <th>Payment Status</th>
                                        <th>Go to Menu</th>
                                        <th>Close Order</th>
                                    </tr>
                                </thead>
                                <tbody id="RecentOrders">
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div id="tab-2" class="tab-pane active">
                        <div class="speltab-bar">                            
                            <span style="">
                                <a class="speltab active" href="javascript:void(0)">Placed<span class="mdl-tabs__ripple-container mdl-layout__tab-ripple-container"><span class="mdl-ripple is-animating" style="width: 233.817px; height: 233.817px; transform: translate(-50%, -50%) translate(80px, 20px);"></span></span></a></span>
                            <span style="">  
                                <a class="speltab" href="javascript:void(0)">In Progress<span class="mdl-tabs__ripple-container mdl-layout__tab-ripple-container">
                                    <span class="mdl-ripple"></span></span></a></span>
                            <span style="">
                                <a class="speltab" href="javascript:void(0)">Completed<span class="mdl-tabs__ripple-container mdl-layout__tab-ripple-container"><span class="mdl-ripple"></span></span></a></span>
                            <span style="">
                                <a class="speltab" href="javascript:void(0)">Cancelled<span class="mdl-tabs__ripple-container mdl-layout__tab-ripple-container"><span class="mdl-ripple"></span></span></a></span>
                            <span style="">
                                <a class="speltab" href="javascript:void(0)">InFuture<span class="mdl-tabs__ripple-container mdl-layout__tab-ripple-container"><span class="mdl-ripple"></span></span></a></span>
                        </div>
                        <div class="table-responsive" style="width: 100%">
                            <table class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>Order Id</th>
                                        <th>Placed At</th>
                                        <th>Delivery Time</th>
                                        <th>Channel Name</th>
                                        <th>Order Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody id="OnlineOrders">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <%--toggle by Asif--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        // Short-form of `document.ready`
        $(function () {
            $(".toggleHide").hide();
            $(".fa-eye").on("click", function () {
                $(".toggleHid, .toggleHide").toggle();
            });
        });
    </script>

    <script>
        function resizeIframe(obj) {
            obj.style.height = obj.contentWindow.document.documentElement.scrollHeight + 'px';
        }
    </script>
    <script>
        $(function () {
            $('.tab-pane:first-child').show();
            $('.tabspcl:first-child').trigger('click');
            $('.tabspcl').bind('click', function (e) {
                $this = $(this);
                $tabs = $this.parent().parent().next();
                $target = $($this.data("target")); // get the target from data attribute
                $this.siblings().removeClass('active');
                $target.siblings().css("display", "none")
                $this.addClass('active');
                $target.fadeIn("fast");
                // Get Area Name from Area Master
                //var ordertypeID = $(this).closest('span').attr('id');
               
                //$(document.body).on("click", ".tabspcl", function () {
                //    ordertypeID = $(this).closest('a').attr('id');

                //});
               
            });
            //
           
        });
    </script>
    <link rel="stylesheet" href="css/vroom.css" />
    <script type="text/javascript" src="js/vroom.js"></script>
    <script type="text/javascript" src="js/TweenLite.min.js"></script>
    <script type="text/javascript" src="js/CSSPlugin.min.js"></script>
    <%--<script src="js/jquery.nicescroll.js"></script>--%>
    <script src="js/scripts.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap.min.js"></script>
    <!-- Include jQuery -->
    <script src="https://code.jquery.com/jquery-2.1.4.min.js"></script>

    <script type="text/javascript">
        var apiUrl = $("[id$='hdnApiurl']").val();
        $(document).ready(function () {
            $(document.body).on("click", ".tabspcl", function () {
                var ordertypeID = $(this).closest('span').attr('id');
                GetAreaName(ordertypeID);
            });
            
            // Get Table from Master DineIn mapped from Area Master
            $(document.body).on("click", ".tabspl", function () {
                var areaID = $(this).closest('a').attr('id');
                var ordertypeID = parseInt($(this).closest('div').find('.test').attr('id'));
                $(".tabspl").removeClass("active");
                $(this).addClass("active");
                GetTableName(areaID, ordertypeID);
            });


            // Redirect to Take Away page 
            //$(document.body).on("click", ".img-size", function () {
            //    var id = $(this).closest('div').attr('id');
            //    var tablename = $(this).closest('img').attr('id');
            //    window.location.href = "/Take_away.aspx?orderType=3&TableID=" + id + "&tablename=" + tablename + "";
            //});


            var modal = document.getElementById("exampleModal");
            $(document.body).on("click", ".material-icons", function () {
                $("#OrderRow").empty();
                var id = $(this).closest('i').attr('id');
                //$("#lbltablename").html(tableame);
                DisplayOrderItems(id);
                GetSummationofOrders(id)
                modal.style.display = "block";
            });
            $(document.body).on("click", "#closetable", function () {
                modal.style.display = "none";
            });
            $(document.body).on("click", ".modal", function () {
                modal.style.display = "none";
            });

            GetRecentOrders();
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
                                   '<tr><td><a href="#">' + data[i].ProductName + '</a></td><td id="' + data[i].SalesOrderDetailID + '" class="OneUnitPrice">' + data[i].ActualCost + '</td><td class="ng-tns-c8-2" >' + data[i].ProductQty + '</td>' +
                   '</td><td class="discount">0</td><td class="totalPrice">' + data[i].TotalAmount + ' </td></tr>'

                    });

                    $("#OrderRow").append(orderDetail);

                }

            });
        };

        function GetSummationofOrders(id) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/SummationofOrders/' + id + '',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    for (let r of data)
                    {
                        $("#subtotal").html(r.ActualCost);
                        $("#billamount").html(r.TotalAmount);
                        $("#lblCGST").html(r.CGST);
                        $("#lblSGST").html(r.SGST);
                    }
                }
            });
        };
        function GetTableName(areaID, orderType) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/GetTableNameAndOrderStatus/' + areaID + '?ordertype=' + orderType,
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var _binddata = '<div class="row">';
                    $.each(data, function (i) {
                        var href = "/Take_away.aspx?orderType=" + orderType + "&TableID=" + data[i].DineInTablemasterID + "&tablename=" + data[i].TableName + "";
                        var busyicon = '';
                        if (data[i].TableStatus == 'True') {
                            busyicon = '<i class="material-icons hov text-success" style="cursor: pointer;" title="Busy Now">do_not_disturb_on_total_silence</i><i id="' + data[i].OrderID + '" class="material-icons hov text-primary" style="cursor: pointer;" title="Busy Now">info</i>';
                        }
                        _binddata += '<div class="col-md-2 col-xs-4 clps_desn" id="' + data[i].DineInTablemasterID + '"><div class="text-center center-block">' +
                        '<h3 id="' + data[i].TableName + '">' + data[i].TableName + ' </h3><i class="material-icons hov" style="cursor: pointer;" title="Change Table Name">find_replace </i>' +
                        '' + busyicon + '</div><a href=' + href + '>';
                        if (orderType == 3)
                        {
                            _binddata += '<img src="images/dinein.png" class="img-size" id="' + data[i].TableName + '" alt="Dine-in"/>';
                        }
                        else if (orderType == 4)
                            {
                            _binddata += '<img src="images/dinein.png" class="img-size" id="' + data[i].TableName + '" alt="Room Service"/>';
                        }
                        _binddata+='</a></div>';
                    });
                    _binddata += '</div>';
                    $("#London").html(_binddata);
                }
            });
        }

        function GetAreaName(ordertypeID) {
           
                $.ajax({
                    type: "GET",
                    url: apiUrl + '/api/DineIn/GetAreaName/' + ordertypeID + '',
                    dataType: "json", contentType: "application/json;charset=utf-8",
                    success: function (data) {
                        var activecss = "";
                        var _bindarea = '<div class="splbar" ><div class="text-center center-block">';
                        $.each(data, function (i) {
                            activecss = "";
                            if (i == 0) {
                                activecss = 'active';
                                var areaID = data[i].DineAreaMasterID;
                                GetTableName(areaID, ordertypeID);
                            }
                            _bindarea += '<a class="tabspl ' + activecss + '" id="' + data[i].DineAreaMasterID + '">' + data[i].AreaName + '</a><span class="test" id="' + data[i].OrderTypeID + '"></span>';
                        });
                        _bindarea += '</div></div>';
                        $("#dinearea").html(_bindarea);
                    }
                });
            
        }
       
        function GetOrderStatus(orderID) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/GetOrderStatus/' + orderID + '',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (response) {
                    return response;
                }
            });
        }

        //function GetRecentOrders() {
        //    $.ajax({
        //        type: "GET",
        //        url: apiUrl+'/api/Item/GetRecentOrders',
        //        dataType: "json", contentType: "application/json;charset=utf-8",
        //        success: function (data) {
        //            var recentorder = "";
        //            $.each(data, function (i) {
        //                recentorder +=
        //                    '<tr><td><a href="#">' + data[i].OrderNo +
        //                '<td>' + (data[i].RoomNo != null ? data[i].RoomNo : '-') + '</td>' +
        //                '</a></td><td>' + data[i].OrderDate +
        //                '</td><td>' + data[i].OrderTime +
        //                '</td><td>' + data[i].OrderTypeName +
        //                '</td><td>' + data[i].TableName +
        //                '</td><td class="ng-tns-c8-2" >'
        //                + data[i].TotalPaid + '</td>' +
        //                '</td><td class="totalPrice">'
        //                + data[i].PaymentStatus +
        //                ' </td><td ><span style="display:none">'
        //                + data[i].OrderTypeName + '-'
        //                + data[i].OrderNo +
        //                '</span><a href=/Take_away.aspx?orderType='
        //                + data[i].OrderType + '&id='
        //                + data[i].OrderID +
        //                '&status=' +
        //                data[i].TableStatus +
        //                '&TableID='
        //                + data[i].TableID +
        //                '  class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>' + '</td><td >' + '<span style="display:none">' + data[i].OrderTypeName + '-' + data[i].OrderNo + '</span><a href=/order.aspx?orderType=' + data[i].OrderType + '&id=' + data[i].OrderID + '&status=' + data[i].TableStatus + '&TableID=' + data[i].TableID + '  class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>' + '</td></tr>'

        //            });

        //            $("#RecentOrders").append(recentorder);
        //        }
        //    });
        //}

        //function GetRecentOrders() {
        //    $.ajax({
        //        type: "GET",
        //        url: apiUrl + '/api/Item/GetRecentOrders',
        //        dataType: "json",
        //        success: function (data) {
        //            var recentorder = "";
        //            $.each(data, function (i) {
        //                // Encode values to handle spaces or special characters
        //                var roomQs = encodeURIComponent(data[i].RoomNo || "");
        //                var ncQs = encodeURIComponent(data[i].NCName || "");
        //                var orderId = data[i].OrderID;
        //                var oType = data[i].OrderType;
        //                var tStatus = data[i].TableStatus;
        //                var tID = data[i].TableID;
        //                var ncRadio = data[i].ncRadio;

        //                recentorder += '<tr>' +
        //                    '<td>' + data[i].OrderNo + '</td>' +
        //                    '<td>' + (data[i].RoomNo || '-') + '</td>' +
        //                    '<td>' + data[i].OrderDate + '</td>' +
        //                    '<td>' + data[i].OrderTime + '</td>' +
        //                    '<td><b class="order-timer" data-start-time="' + data[i].OrderDate + ' ' + data[i].OrderTime + '">00:00:00</b></td>' +
        //                    '<td>' + data[i].OrderTypeName + '</td>' +
        //                    '<td>' + data[i].TableName + '</td>' +
        //                    '<td>' + data[i].TotalPaid + '</td>' +
        //                    '<td>' + data[i].PaymentStatus + '</td>' +

        //                    // Button 1: Go to Menu (Take_away.aspx)
        //                    '<td>' +
        //                    '<a href="/Take_away.aspx?orderType=' + oType + '&id=' + orderId + '&status=' + tStatus + '&TableID=' + tID + '&roomNo=' + roomQs + '&ncName=' + '&ncRadio' + ncRadio + ncQs + '" class="editbtn">' +
        //                    '<i class="glyphicon glyphicon-edit" style="color: green"></i>' +
        //                    '</a></td>' +

        //                    // Button 2: Close Order (order.aspx or Take_away.aspx as per your need)
        //                    '<td>' +
        //                    '<a href="/order.aspx?orderType=' + oType + '&id=' + orderId + '&status=' + tStatus + '&TableID=' + tID + '&roomNo=' + roomQs + '&ncName=' + '&ncRadio' + ncRadio + ncQs + '" class="editbtn">' +
        //                    '<i class="glyphicon glyphicon-edit" style="color: blue"></i>' +
        //                    '</a></td>' +
        //                    '</tr>';
        //            });
        //            $("#RecentOrders").html(recentorder);
        //        }
        //    });
        //}




        function GetRecentOrders() {
            $.ajax({
                type: "GET",
                url: apiUrl + '/api/Item/GetRecentOrders',
                dataType: "json",
                success: function (data) {
                    debugger;
                    var recentorder = "";
                    $.each(data, function (i) {
                        // Encode values to handle spaces or special characters
                        var roomQs = encodeURIComponent(data[i].RoomNo || "");
                        var ncQs = encodeURIComponent(data[i].NCName || "");
                        var orderId = data[i].OrderID;
                        var oType = data[i].OrderType;
                        var tStatus = data[i].TableStatus;
                        var tID = data[i].TableID;
                        var ncRadio = encodeURIComponent(data[i].ncRadio || ""); // Isse bhi encode kar diya safer side ke liye

                        recentorder += '<tr>' +
                            '<td>' + data[i].OrderNo + '</td>' +
                            '<td>' + (data[i].RoomNo || '-') + '</td>' +
                            '<td>' + data[i].OrderDate + '</td>' +
                            '<td>' + data[i].OrderTime + '</td>' +
                            '<td><b class="order-timer" data-start-time="' + data[i].OrderDate + ' ' + data[i].OrderTime + '">00:00:00</b></td>' +
                            '<td>' + data[i].OrderTypeName + '</td>' +
                            '<td>' + data[i].TableName + '</td>' +
                            '<td>' + data[i].TotalPaid + '</td>' +
                            '<td>' + data[i].PaymentStatus + '</td>' +

                            // Button 1: Go to Menu (Take_away.aspx)
                            '<td>' +
                            '<a href="/Take_away.aspx?orderType=' + oType + '&id=' + orderId + '&status=' + tStatus + '&TableID=' + tID + '&roomNo=' + roomQs + '&ncName=' + ncQs + '&ncRadio=' + ncRadio + '" class="editbtn">' +
                            '<i class="glyphicon glyphicon-edit" style="color: green"></i>' +
                            '</a></td>' +

                            // Button 2: Close Order (order.aspx)
                            '<td>' +
                            '<a href="/order.aspx?orderType=' + oType + '&id=' + orderId + '&status=' + tStatus + '&TableID=' + tID + '&roomNo=' + roomQs + '&ncName=' + ncQs + '&ncRadio=' + ncRadio + '" class="editbtn">' +
                            '<i class="glyphicon glyphicon-edit" style="color: blue"></i>' +
                            '</a></td>' +
                            '</tr>';
                    });
                    $("#RecentOrders").html(recentorder);
                }
            });
        }

        setInterval(function () {
            $(".order-timer").each(function () {
                var startTimeStr = $(this).attr("data-start-time");

                if (startTimeStr) {
                    try {
                        // Expecting: DD/MM/YYYY HH:MM:SS or DD/MM/YYYY HH:MM
                        var parts = startTimeStr.split(' ');
                        if (parts.length < 2) return;

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

                            // Logic: 15 min alert
                            if (minutes >= 15 || hours > 0) {
                                $(this).css("color", "red");
                            } else {
                                $(this).css("color", "#28a745");
                            }
                        }
                    } catch (e) {
                        console.error("Timer Error on string: " + startTimeStr, e);
                    }
                }
            });
        }, 1000);

        $(document).ready(function () {

            $.ajax({
                type: "GET",
                url: apiUrl + '/api/dashboard/DashboardSales',
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var orderDetail = "";
                    $.each(data, function (i, v) {
                        switch (v.TableType) {
                            case 1:
                                $('#takeaway').html(v.TotalAmount);
                                break;
                            case 2:
                                $('#doordelivery').html(v.TotalAmount);
                                break;
                            case 3:
                                $('#dinein').html(v.TotalAmount);
                                break;
                            case -1:
                                $('#allsales').html(v.TotalAmount);
                                break;

                        }
                    });



                }

            });

        })
    </script>
   
</asp:Content>





