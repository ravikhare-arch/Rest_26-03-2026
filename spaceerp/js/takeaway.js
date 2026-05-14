
var apiUrl = $("[id$='hdnApiurl']").val();
//var apiUrl =  $('#<% =hdnApiurl.ClientID %>').val();

//alert(apiUrl);



$(document).ready(function () {
    HideControls();
    //Start loading first the Item Group from Master
    var orderType = getUrlVars()["orderType"];
    var Items;
    var salesOrder = {};
    let salesOrderList = [];
    let tempSalesOrderList = [];
    var tablename;
    var ItemMasterID = 0;
    var OrderIDfromtable = 0;
    var ItemRemarkID = 0;
    var id = getUrlVars()["id"];
    var tablestatus = getUrlVars()["status"];
    var tableID = getUrlVars()["TableID"];
    var temptablename = getUrlVars()["tablename"];
    var cancelorder = getUrlVars()["cancel"];
    //getItemGroup(orderType,Items);

    $("#ddlacnonac").prop('selectedIndex', 2);
    if (orderType == 1 || orderType == 2) {
        $("#ddlacnonac").prop('selectedIndex', 0);
        $("#divacnonac").hide();
    }

    $.ajax({
        type: "GET",
        url: apiUrl + '/api/ItemGroupMasters/GetItemGroupMasters',
        dataType: "json", contentType: "application/json;charset=utf-8",
        async: false,
        success: function (data) {
            var _binddata = "";
            var activecss = "";
            $.each(data, function (i) {
                activecss = "";
                if (i == 0) {
                    activecss = 'active';
                    var groupID = data[i].GroupID;
                    $("#hiddenGroupID").val(groupID);

                    var acnonac = $("#ddlacnonac").val();
                    //$("#ddlacnonac").val($("#ddlacnonac option:first").val());
                    //GetItemfromGroup(groupID, orderType,Items);
                    $.ajax({
                        type: "GET",
                        url: apiUrl + '/api/Item/GetItembyGroupId_Result/' + groupID + "?deliveryType=" + orderType + "&acnonac=" + acnonac,
                        dataType: "json", contentType: "application/json;charset=utf-8",
                        async: false,
                        success: function (data) {
                            Items = data;
                            var _binditemdata = "";
                            $.each(data, function (i) {
                                _binditemdata += ' <div  class="row-one"><div class="col-md-4 col-xs-6 widget splWidget" id="' + data[i].ItemMasterID + '"><div class="stats-left" id="' + data[i].ItemMasterID + '"><p>' + data[i].sProduct + ' </p></div><div class="stats-right" id="' + data[i].ItemMasterID + '">' +
                                    '<p class="text-danger"> ₹ ' + data[i].nActualCost + ' </p></div></div></div>';

                            });

                            // alert(_binddata);
                            $("#GroupItemData").html(_binditemdata);

                        }
                    });
                }
                _binddata += '<div class="spltab ' + activecss + '"  id="' + data[i].GroupID + '">' +
                    '<p class="text-danger ItemGroup">' + data[i].GroupName + ' </p></div>';
            });
            // alert(_binddata);
            $("#GroupData").html(_binddata);
        }
    });


    if (temptablename != undefined && temptablename != null) {
        tablename = temptablename.replace(/%20/g, " "); // tablename define ho gaya
        localStorage.setItem("current_tableName", tablename); // Storage mein save
        $("#lbltablename").html(tablename); // Label mein dikhao
    }
    //Read the Modal of Remarks and read ID 
    var modal = document.getElementById("RemarkModal");
    $(document.body).on("click", "#myBtn", function () {
        ItemRemarkID = parseInt($(this).closest('tr').find('.modalremarks').attr('id'));
        modal.style.display = "block";
    });
    $(document.body).on("click", "#closeremark", function () {
        modal.style.display = "none";
    });
    ////changed by Asif Adeeb 
    $(document.body).on("click", ".close", function () {
        modal.style.display = "none";
    });
    $(document.body).on("click", ".saveRemark", function () {
        var ind = salesOrderList.findIndex(obj => obj.ItemMasterID === ItemRemarkID);
        salesOrderList[ind].ItemRemarks = $("#txtremarks").val();
        modal.style.display = "none";
    });
    //END the Modal of Remarks and read ID //

    $('#Destopsearch').autocomplete({
        resolver: 'custom',
        minLength: 1,
        delay: 500,
        source:
            function (request, response) {
                $.ajax({
                    url: apiUrl + "/api/Item/ItemListByKey?keyValue=" + request.term + "&deliveryType=" + orderType,
                    dataType: "json",

                    //data: {
                    //    keyValue: request.term
                    //},
                    success: function (data) {
                        oldItems = Items;
                        Items = data;
                        response($.map(data, function (item) {
                            return {
                                label: item.sProduct,
                                value: item.ItemMasterID
                            };
                        }));
                    }
                });
            },
        select: function (event, ui) {
            event.preventDefault();
            $(this).val(ui.item.label);
            AddItemsToCart(Items, ui.item.value);
            Items = oldItems;

        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function (event) {
            event.preventDefault();
            Items = oldItems;
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        },




    });


    if (orderType != "3") {
        $("#gotodine").hide();
    }

    if (tableID == undefined || tableID == "" || tableID == 0) {
        tableID = 0;
    }
    else {
        //We had passed table from querystring in everywhere else, but here we used GetTableName Method fro API as its comog from Pending Sales, We can manipulate code later
        tablename = GetTableName(tableID);

        //Get OrderID , if it is comong from Dine-In....Now this FUNCTIONALITY can be removed as we have OrderID directly from Dine-In Store Procedure(We Need to implement this)
        OrderIDfromtable = GetOrderIDbasedonTableID(tableID);
        if (OrderIDfromtable > 0) {
            id = OrderIDfromtable;
        }
    }
    SetTextValue(orderType, tablename);
    if (id != null && id != "") {
        ShowControls();
        if (cancelorder == "0") {
            HideControlswhenCancel();
            $("#gotocancel").show();
        }

        $.ajax({
            type: "GET",
            url: apiUrl + '/api/Item/OrderDetailbyOrderID/' + id + '',
            dataType: "json", contentType: "application/json;charset=utf-8",
            success: function (data) {
                var orderDetail = "";
                $.each(data, function (i) {

                    salesOrder = new Object();
                    salesOrder.OrderID = data[i].OrderID
                    salesOrder.ItemMasterID = data[i].ItemMasterID
                    salesOrder.OrderType = parseInt(orderType); // 1 for TakeAway , 2 for Door Delivery , 3 for Dine-In
                    salesOrder.ProductName = data[i].ProductName;
                    salesOrder.ActualCost = data[i].ActualCost;
                    salesOrder.ProductQty = data[i].ProductQty;
                    salesOrder.OrderedUnit = data[i].ProductQty;
                    salesOrder.CGST = data[i].CGST;
                    salesOrder.SGST = data[i].SGST;
                    salesOrder.IGST = data[i].IGST;
                    salesOrder.GSTCost = data[i].GSTCost;
                    salesOrder.GSTpercent = data[i].GSTPercent;
                    salesOrderList.push(salesOrder);

                    orderDetail +=
                        '<tr><td menuId="' + salesOrder.ItemMasterID +'"><a href="#">' + data[i].ProductName + '</a></td><td id="' + data[i].ItemMasterID + '" class="OneUnitPrice">' + data[i].ActualCost + '</td><td class="countInput">' +
                        '<div class="sp-quantity"><span class="sp-minus fff"> <a class="ddd" href="javascript:void(0)">-</a></span>' +
                        '<span class="sp-input"><input type="text" style="width: 40%;" onkeypress="return isNumberKey(event)" class="quntity-input" value=' + data[i].ProductQty + '></span>' +
                        '<span class="sp-plus fff"> <a class="ddd" href="javascript:void(0)">+</a></span></div>' +
                        '</td><td class="w-10"><a href="javascript:void(0)" class="icon"><i class="fa fa-pencil"></i></a></td><td class="totalPrice">' + data[i].TotalAmount + ' </td></tr>'
                });
                $("#OrderRow").append(orderDetail);

                $('.sp-minus').hide();
                tempSalesOrderList = $.extend(true, {}, salesOrderList);
                OrderTotalAmount();

            }
        });
    }

    $(document.body).on("click", ".splWidget", function () {

        // salesOrder
        var id = $(this).closest('div').attr('id');
        AddItemsToCart(Items, id);

    });
    $("#ddlacnonac").change(function () {
        //getItemGroupbyACNONAC(orderType, Items)
        $("#GroupItemData").empty();
    });


    $(document.body).on("click", ".spltab", function () {
        //alert("Hello World");

        var groupID = $(this).closest('div').attr('id');
        $("#hiddenGroupID").val(groupID);
        $(".spltab").removeClass("active");
        $(this).addClass("active");
        var acnonac = $("#ddlacnonac").val();
        $.ajax({
            type: "GET",
            url: apiUrl + '/api/Item/GetItembyGroupId_Result/' + groupID + '?deliveryType=' + orderType + "&acnonac=" + acnonac,
            dataType: "json", contentType: "application/json;charset=utf-8",
            success: function (data) {
                Items = data;
                var _binditemdata = "";
                //var acnonac = $("#ddlacnonac").val();
                //alert(acnonac);
                $.each(data, function (i) {
                    _binditemdata += '<div class="col-md-4 col-xs-6 widget splWidget" id="' + data[i].ItemMasterID + '"><div class="stats-left" id="' + data[i].ItemMasterID + '"><p>' + data[i].sProduct + ' </p></div><div class="stats-right" id="' + data[i].ItemMasterID + '">' +
                        '<p class="text-danger"> ₹ ' + data[i].nActualCost + ' </p></div></div>';

                });

                // alert(_binddata);
                $("#GroupItemData").html(_binditemdata);

            }
        });

    });

    $(document.body).on("click", "#saveKot", function () {
        //alert("Order has been successfully saved");
        function jqAlert(outputMsg, titleMsg, onCloseCallback) {
            if (!outputMsg) return;

            var div = $('<div></div>');
            div.html(outputMsg).dialog({
                title: titleMsg,
                resizable: false,
                modal: true,
                buttons: {
                    "Close": function () {
                        $(this).dialog("close");
                    },
                    "Save KOT": function () {
                        if (GetItemCountfromCart() > 0) {
                            var roomNo = $("#txtRoomNo").val();
                            var rtid = $("#hdnRTID").val();
                            var gcid = $("#hdnGCID").val();
                            var nsNameValue = $("#txtNCName").val() || "";

                            salesOrderList.forEach(function (item) {
                                item.RoomNo = roomNo;
                                item.RTID = parseInt(rtid) || 0;
                                item.GCID = parseInt(gcid) || 0;
                                item.NCName = nsNameValue;
                                //item.TableName = localStorage.getItem("current_tableName") || tablename;
                            });
                            $.ajax({
                                type: "POST",
                                data: JSON.stringify(salesOrderList),
                                url: apiUrl + '/api/Item/SaveItemOrderDetail',
                                //url: 'http://localhost:62351/api/Item/SaveItemOrderDetail',

                                dataType: "json", contentType: "application/json;charset=utf-8",
                                success: function (response) {
                                    if (parseInt(response) > 0) {
                                        $('.sp-minus').hide();

                                        tempSalesOrderList = $.extend(true, {}, salesOrderList);

                                        ShowControls();

                                        $("#hdnOrderID").val(response);

                                        salesOrderList.forEach((item, index) => salesOrderList[index].OrderID = response)

                                        ///print content without loading 
                                        if (id == undefined) {
                                            id = parseInt($("#hdnOrderID").val());
                                        }


                                        $.ajax({
                                            type: "POST",
                                            url: "http://127.0.0.1:62351/Printing/Print/" + id,
                                            contentType: "application/json",
                                            success: (function () {
                                                console.log('print succeeded')
                                            })

                                        });




                                    }
                                    else {
                                        alert("Unable to save order");
                                    }

                                }
                            })
                        }
                        else {
                            GetInvalidCartMessage();
                        }
                        $(this).dialog("close");
                    }
                },
                close: onCloseCallback
            });
            if (!titleMsg) div.siblings('.ui-dialog-titlebar').hide();
        }
        jqAlert(' Do you want to save KOT ? ');
        //alert modal ended by asif

    });
    $(document.body).on("click", "#printwithoutgst", function () {
        if (GetItemCountfromCart() > 0) {
            if (id == undefined) {
                id = parseInt($("#hdnOrderID").val());
            }
            //window.location.href = "/PrintwithoutGST.aspx?id=" + id + "&orderType=" + orderType + "";
            openWindowForPrint("http://127.0.0.1:62351/api/Printing/Print/" + id + "?printerName=LAN1");
        }
        else {
            GetInvalidCartMessage();
        }
    });
    $(document.body).on("click", "#printviewbill", function () {
        if (id == undefined) {
            id = parseInt($("#hdnOrderID").val());
        }
        window.location.href = "/order.aspx?status=" + tablestatus + "&orderType=" + orderType + "&id=" + id + "&tablename=" + tablename + "";
    });
    $(document.body).on("click", "#gotopendorder", function () {
        //if (id == undefined) {
        //    id = parseInt($("#hdnOrderID").val());
        //}
        window.location.href = "/Restaurant/Table/PendingOrderlist.aspx";
    });
    $(document.body).on("click", "#gotodine", function () {
        //if (id == undefined) {
        //    id = parseInt($("#hdnOrderID").val());
        //}
        window.location.href = "/Dine_In.aspx";
    });
    $(document.body).on("click", "#gotodash", function () {
        //if (id == undefined) {
        //    id = parseInt($("#hdnOrderID").val());
        //}
        window.location.href = "/welcome.aspx";
    });
    $(document.body).on("click", "#gotocancel", function () {
        window.location.href = "/Restaurant/Table/CancelPendingOrder.aspx";
    });
    $(document.body).on("click", "a.icon", function () {
        event.preventDefault();
        //salesOrderList  
        // Need to remove from salesOrderList list array also 
        $(this).parent().parent().remove();

        var itemMasterid = parseInt($(this).closest('tr').find('.OneUnitPrice').attr('id'));
        removeByAttr(salesOrderList, 'ItemMasterID', itemMasterid);
        //  salesOrderList.splice(salesOrder,'ItemMasterID',);
        OrderTotalAmount();
    });
    $(document.body).on("click", ".ddd", function () {
        var $button = $(this).closest('tr td div a');
        //var $button = $(this);
        var removed = true;
        var itemMasterid = parseInt($(this).closest('tr').find('.OneUnitPrice').attr('id'));
        var ind = 0;

        var oldValue = 0;
        //
        if (salesOrderList.length >= 0) {
            ind = salesOrderList.findIndex(obj => obj.ItemMasterID === itemMasterid);
            oldValue = salesOrderList[ind].ProductQty;
        }
        else
            oldValue = $button.closest('.sp-quantity').find("input.quntity-input").val();



        unitPrice = $(this).closest('tr').find('.OneUnitPrice').text();

        if ($button.text() == "+") {
            $(this).closest('tr').find('.sp-minus').show()


            var newVal = parseFloat(oldValue) + 1;
            setfinalproductvalue(newVal, unitPrice, $(this).closest('tr').find('.totalPrice'));
            //updating quantity in case of +/-

            salesOrderList[ind].ProductQty = newVal;


        } else {

            // Don't allow decrementing below zero
            if (oldValue > 0) {
                var newVal = parseFloat(oldValue) - 1;
            } else {
                newVal = 0;
            }

            var itemMasterid = parseInt($(this).closest('tr').find('.OneUnitPrice').attr('id'));
            var ind = salesOrderList.findIndex(obj => obj.ItemMasterID === itemMasterid);


            if (Object.keys(tempSalesOrderList).length != 0 && ind < Object.keys(tempSalesOrderList).length) {
                var oldQty = tempSalesOrderList[ind].ProductQty;
                if (newVal == oldQty) {
                    $(this).closest('tr').find('.sp-minus').hide()
                    removed = false;
                }

            }
            if (true) {

                setfinalproductvalue(newVal, unitPrice, $(this).closest('tr').find('.totalPrice'));
                salesOrderList[ind].ProductQty = newVal;

                if (newVal == 0) {
                    removeItemFromCart(this);
                }
            }
        }

        $button.closest('.sp-quantity').find("input.quntity-input").val(newVal);
        OrderTotalAmount();

    });

    var removeItemFromCart = function (t) {
        $(t).parent().parent().parent().parent().remove();

        var itemMasterid = parseInt($(t).closest('tr').find('.OneUnitPrice').attr('id'));
        removeByAttr(salesOrderList, 'ItemMasterID', itemMasterid);
        //  salesOrderList.splice(salesOrder,'ItemMasterID',);
        OrderTotalAmount();
    }

    var AddItemsToCart = function (productItem, id) {
        let selectedItem = productItem.find(t => t.ItemMasterID == id)
        //if (selectedItem == undefined)
        //    selectedItem = productItem[0];


        let countExisitingItems = salesOrderList.filter(c => c.ItemMasterID == selectedItem.ItemMasterID);
        if (countExisitingItems.length <= 0) {
            ItemMasterID = selectedItem.ItemMasterID;
            var productName = selectedItem.sProduct;
            var productUnitPrice = selectedItem.nActualCost;
            var productQty = 1;
            var TotalItemPrie = productQty * productUnitPrice;
            var GSTCost = selectedItem.GSTCost;
            var CGST = selectedItem.CGST;
            var SGST = selectedItem.SGST;
            var IGST = selectedItem.IGST;
            var GSTpercent = selectedItem.GSTpercent;
            var TotalCost = selectedItem.TotalCost;
            var ItemRemarks = "";
            var orderDetail =
                '<tr><td><a href="#">' + productName + '</a></td><td id="' + ItemMasterID + '" class="OneUnitPrice">' + productUnitPrice + '</td><td class="countInput">' +
                '<div class="sp-quantity"><span class="sp-minus fff"> <a class="ddd" href="javascript:void(0)">-</a></span>' +
                '<span class="sp-input"><input type="text" style="width: 25%;" onkeypress="return isNumberKey(event)" class="quntity-input" value="1"></span>' +
                '<span class="sp-plus fff"> <a class="ddd" href="javascript:void(0)">+</a></span></div>' +
                '</td><td class="w-10"><a data-toggle="modal" class="modalremarks" id="' + ItemMasterID + '"><i class="fa fa-pencil" id="myBtn" ></i></a></td><td class="totalPrice">' + TotalItemPrie + ' </td></tr>'
            //$("#myTable").append(fragment);
            salesOrder = new Object();
            salesOrder.ItemMasterID = ItemMasterID;
            salesOrder.OrderType = parseInt(orderType); // 1 for TakeAway , 2 for Door Delivery , 3 for Dine-In
            salesOrder.ProductName = productName;
            salesOrder.ActualCost = productUnitPrice;
            salesOrder.ProductQty = productQty;
            salesOrder.OrderedUnit = 1;
            salesOrder.CGST = CGST;
            salesOrder.SGST = SGST;
            salesOrder.IGST = IGST;
            salesOrder.GSTCost = GSTCost;
            salesOrder.GSTpercent = GSTpercent;
            salesOrder.OrderType = orderType;
            salesOrder.TableID = tableID;
            salesOrder.ItemRemarks = ItemRemarks;
            salesOrderList.push(salesOrder);
            $("#OrderRow").append(orderDetail);
            OrderTotalAmount();

        }
    }
});


var removeByAttr = function (arr, attr, value) {
    var i = arr.length;
    while (i--) {
        if (arr[i]
            && arr[i].hasOwnProperty(attr)
            && (arguments.length > 2 && arr[i][attr] === value)) {

            arr.splice(i, 1);

        }
    }
    return arr;
}


//Set Final product value after multiplication
function setfinalproductvalue(totalQty, unitPrice, ele) {
    var newproductprice = parseFloat(unitPrice) * parseFloat(totalQty);
    ele.html(newproductprice);
}

//Order Total Amount
function OrderTotalAmount() {
    var TotalValue = 0;
    var TotalPriceArr = $('.totalPrice').get()
    $(TotalPriceArr).each(function () {
        TotalValue += parseInt($(this).text());
    });
    $('#lbltotalamount').html(TotalValue);
};
//Check Numbers only
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;
    return true;
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

function GetOrderIDbasedonTableID(tableID) {
    var OrderID = 0;
    $.ajax({
        type: "GET",
        url: apiUrl + '/api/Item/GetOrderIDbasedonTableID/' + tableID + '',
        dataType: "json", contentType: "application/json;charset=utf-8",
        async: false,
        success: function (response) {
            if (parseInt(response) > 0) {
                OrderID = parseInt(response);
            }
        }
    });
    return OrderID;
}

function GetTableName(tableID) {
    var rettablename = "";
    $.ajax({
        type: "GET",
        url: apiUrl + '/api/DineIn/GetTableName/' + tableID + '',
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

function getItemGroupbyACNONAC(orderType, Items) {
    var groupID = parseInt($("#hiddenGroupID").val());
    //alert(groupID);
    var acnonac = $("#ddlacnonac").val();
    //alert(acnonac);
    $.ajax({
        type: "GET",
        url: apiUrl + '/api/Item/GetItembyGroupId_Result/' + groupID + '?deliveryType=' + orderType + "&acnonac=" + acnonac,
        dataType: "json", contentType: "application/json;charset=utf-8",
        success: function (data) {
            Items = data;
            var _binditemdata = "";
            $.each(data, function (i) {
                _binditemdata += ' <div  class="row-one"><div class="col-md-4 widget splWidget" id="' + data[i].ItemMasterID + '"><div class="stats-left" id="' + data[i].ItemMasterID + '"><p>' + data[i].sProduct + ' </p></div><div class="stats-right" id="' + data[i].ItemMasterID + '">' +
                    '<p class="text-danger"> ₹ ' + data[i].nActualCost + ' </p></div></div></div>';

            });

            // alert(_binddata);
            $("#GroupItemData").html(_binditemdata);

        }
    });
}

function SetTextValue(orderType, tablename) {
    var jsLang = orderType;
    switch (jsLang) {
        case "1":
            $("#lblheading").html('Take Away');
            break;
        case "2":
            $("#lblheading").html('Door Delivery');//Door Delivery
            break;
        case "3":
            $("#divtablename").show();
            $("#lblheading").html('Dine-In');
            $("#lbltablename").html(tablename);
            break;
        case "4":
            $("#divtablename").show();
            $("#lblheading").html('Dastarkhan');
            $("#lbltablename").html(tablename);
            break;
    }
}

function GetItemCountfromCart() {
    return $('#itemloaded >tbody >tr').length;
}
function GetInvalidCartMessage() {
    alert("PLease add Items to the Cart to place Order!!!");
}
function HideControls() {
    $("#divtablename").hide();
    $("#printviewbill").hide();
    $("#printwithoutgst").hide();
    $("#gotocancel").hide();
}
function ShowControls() {
    $("#printviewbill").show();
    $("#printwithoutgst").show();
}
function HideControlswhenCancel() {
    $("#saveKot").hide();
    $("#printviewbill").hide();
    $("#printwithoutgst").hide();
}


function GetItemfromGroup(groupID, orderType, Items) {


}



