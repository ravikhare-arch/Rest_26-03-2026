<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Dine_In.aspx.cs" Inherits="Admin_Dine_In" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../assets/plugins/dropdown-autocomplete/Scripts/jquery.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons"
        rel="stylesheet" />
    
    <link href="css/customize-model.css" rel="stylesheet" />    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 
     <input type="hidden" runat="server" id="hdnApiurl" />    
    <div id="exampleModal" class="modal">
        <div class="modal-dialog modal-lg" role="dialog">
            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
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
                    <input type="button" class="btn btn-primary" id="closetable" name="closetable" value="Close" />

                </div>
            </div>
        </div>
    </div>
    <div id="dinearea">
        <%--<div class="text-center center-block">
            <a class="tabspl active" onclick="openCity('London')">Secound Floor</a>
            <a class="tabspl" onclick="openCity('Paris')">Ground</a>
            <a class="tabspl" onclick="openCity('Tokyo')">Vip</a>
        </div>--%>
    </div>
    <div id="London" class="tab-pane city">
    </div>
    <div id="Paris" class="tab-pane city" style="display: none">
    </div>
    <div id="Tokyo" class="tab-pane city" style="display: none">
    </div>
<script type="text/javascript">
        var apiUrl = $("[id$='hdnApiurl']").val();
        $(document).ready(function () {
            // Get Area Name from Area Master
            var orderType = getUrlVars()["orderType"];
            GetAreaName(orderType);
            // Get Table from Master DineIn mapped from Area Master
            $(document.body).on("click", ".tabspl", function () {
                var areaID = $(this).closest('a').attr('id');
                $(".tabspl").removeClass("active");
                $(this).addClass("active");
                GetTableName(areaID, orderType);
            });
            //tried by asif
            //$(document.body).on("click", ".tabspl",
            //    function f() {
            //        var areaID = $(this).closest('a').attr('id');
            //        $(".tabspl").removeClass("active");
            //        $(this).addClass("active");
            //        GetTableName(areaID);
            //        
            //window.onload = f;
            //$(this).children(".tabspl").first().addClass("active");
            //    });
            // Redirect to Take Away page 
            $(document.body).on("click", ".img-size", function () {
                var id = $(this).closest('div').attr('id');
                var tablename = $(this).closest('img').attr('id');
                var orderID = parseInt($(this).closest('div').find('.test').attr('id'));
                
                window.location.href = "/Take_away.aspx?orderType=" + orderType + "&TableID=" + id + "&tablename=" + tablename + "";
                //var checkCount = IsAlreadyPLacedOrder(orderID,orderType);
                //if (checkCount > 0)
                //{
                //    alert("Order Already placed for different transaction!!!"); 
                //}
                //else
                //    {
                    
                //}
                
            });


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
        debugger;
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
                        var busyicon = '';
                        if (data[i].TableStatus == 'True') {
                            busyicon = '<i class="material-icons hov text-success" style="cursor: pointer;" title="Busy Now">do_not_disturb_on_total_silence</i><i id="' + data[i].OrderID + '" class="material-icons hov text-primary" style="cursor: pointer;" title="Busy Now">info</i>';
                        }
                        _binddata += '<div class="col-md-2 col-xs-4" id="' + data[i].DineInTablemasterID + '"><div class="text-center center-block">' +
                        '<h3 id="' + data[i].TableName + '">' + data[i].TableName + ' </h3><i class="material-icons hov" style="cursor: pointer;" title="Change Table Name">find_replace </i>' +
                        '' + busyicon + '</div><img src="images/dinein.png" class="img-size" id="' + data[i].TableName + '"/><div class="test" id="' + data[i].OrderID + '"></div></div>';
                    });
                    _binddata += '</div>';
                    $("#London").html(_binddata);
                }
            });
        }

        function GetAreaName(ordertypeID) {
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/DineIn/GetAreaName/' + ordertypeID + '',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var activecss = "";
                    var _bindarea = '<div class="splbar mob-scroll" ><div class="text-center center-block">';
                    $.each(data, function (i) {
                        activecss = "";
                        if (i == 0)
                        {
                            activecss = 'active';
                            var areaID = data[i].DineAreaMasterID;
                            GetTableName(areaID, ordertypeID);
                        }
                        _bindarea += '<a class="tabspl ' + activecss + '" id="' + data[i].DineAreaMasterID + '">' + data[i].AreaName + '</a>';
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

        function IsAlreadyPLacedOrder(orderID,orderType) {
            var count = 0;
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/Item/IsAlreadyPLacedOrder/' + orderID + '?ordertype=' + orderType,
                dataType: "json", contentType: "application/json;charset=utf-8",
                async: false,
                success: function (response) {
                    if (parseInt(response) > 0) {
                        count = parseInt(response);
                    }
                }
            });
            return count;
        }

    </script>
</asp:Content>


