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
        tablename = temptablename.replace(/%20/g, " ");
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

        // prefer modern URLSearchParams but keep existing id fallback
        var orderId = (new URLSearchParams(window.location.search)).get('id') || id;

        var requestUrl = (apiUrl ? apiUrl : '') + '/api/Item/OrderDetailbyOrderID/' + encodeURIComponent(orderId);

        $.ajax({
            type: "GET",
            url: requestUrl,
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (data) {
                console.log("OrderDetailbyOrderID requestUrl:", requestUrl);
                console.log("Raw response:", data);

                // normalize array / object shapes
                var itemsArray = [];
                if (!data) {
                    itemsArray = [];
                } else if (Array.isArray(data)) {
                    itemsArray = data;
                } else if (Array.isArray(data.OrderDetails)) {
                    itemsArray = data.OrderDetails;
                } else if (Array.isArray(data.Items)) {
                    itemsArray = data.Items;
                } else {
                    itemsArray = [data];
                }
                console.log("Normalized itemsArray:", itemsArray);

                // get first record for room/NC/RTID/GCID
                var first = itemsArray.length ? itemsArray[0] : null;
                var roomVal = "", ncNameVal = "", rtid = "", gcid = "",ncRadioVal = "";;
                if (first) {
                    roomVal = first.RoomNumber || first.RoomNo || first.Room || (first.OrderMaster && (first.OrderMaster.RoomNumber || first.OrderMaster.RoomNo)) || "";
                    ncNameVal = first.NCName || first.NC || (first.OrderMaster && first.OrderMaster.NCName) || "";
                    rtid = first.RTID || first.rtId || first.rtID || (first.OrderMaster && first.OrderMaster.RTID) || "";
                    gcid = first.GCID || first.gcId || first.gcid || (first.OrderMaster && first.OrderMaster.GCID) || "";
                    ncRadioVal = first.NCRadio || (first.OrderMaster && first.OrderMaster.NCRadio) || "";
                }
                if (ncRadioVal === "NC") {
                    $("#nc").prop('checked', true);
                }

                // 2. Agar multi-page flow hai, toh localStorage bhi update kar do safety ke liye
                if (ncRadioVal === "NC") {
                    localStorage.setItem("isNCSelected", "true");
                }

                // Optional: Agar aapne order.aspx ke liye 'lending' ID rakhi hai
                if (ncRadioVal === "NC" && $("#NC").length) {
                    $("#NC").prop('checked', true);
                }
                console.log("Extracted -> room:", roomVal, "nc:", ncNameVal, "rtid:", rtid, "gcid:", gcid);

                // helper to set element by many selector fallbacks and trigger events
               
                function setValueTo(selectorCandidates, value, isRoomField) {
                    for (var i = 0; i < selectorCandidates.length; i++) {
                        try {
                            var $el = $(selectorCandidates[i]);
                            if ($el.length) {
                                $el.val(value).trigger('change');
                                if ($el[0]) $el[0].value = value;

                                // 🔥 FIX 2: Agar Room No bhara ja raha hai toh popup ko instant close karke lock kardo
                                if (isRoomField && value !== "") {
                                    if ($el.data("ui-autocomplete") || $el.autocomplete("instance")) {
                                        $el.autocomplete("close");
                                    }
                                    $el.prop("disabled", true).css({ "background-color": "#eeeeee", "cursor": "not-allowed" });
                                }
                                return true;
                            }
                        } catch (e) { console.warn("setValueTo error", e); }
                    }
                    return false;
                }

                // 🔥 Pass true for Room No field, false for others
                setValueTo(["#txtRoomNo", "input[id$='txtRoomNo']", "input[name='txtRoomNo']"], roomVal, true);
                setValueTo(["#txtNCName", "input[id$='txtNCName']", "input[name='txtNCName' ]"], ncNameVal);
                setValueTo(["#hdnRTID", "input[id$='hdnRTID' ]"], rtid);
                setValueTo(["#hdnGCID", "input[id$='hdnGCID' ]"], gcid);

                // If fields still empty (race), try again shortly
                setTimeout(function () {
                    setValueTo(["#txtRoomNo", "input[id$='txtRoomNo' ]"], roomVal);
                    setValueTo(["#txtNCName", "input[id$='txtNCName' ]"], ncNameVal);
                }, 120);

                // build salesOrderList and table rows (same logic, with normalized array)
                var orderDetailHtml = "";
                salesOrderList = [];
                $.each(itemsArray, function (i, item) {
                    item = item || {};
                    var salesOrder = {};
                    salesOrder.OrderID = item.OrderID || item.orderID || orderId;
                    salesOrder.ItemMasterID = item.ItemMasterID || item.ItemId || item.ItemMaster_Id;
                    salesOrder.OrderType = parseInt(orderType) || 0;
                    salesOrder.ProductName = item.ProductName || item.sProduct || "";
                    salesOrder.ActualCost = item.ActualCost || item.nActualCost || 0;
                    salesOrder.ProductQty = item.ProductQty || item.ProductQty || 0;
                    salesOrder.OrderedUnit = salesOrder.ProductQty;
                    salesOrder.CGST = item.CGST || 0;
                    salesOrder.SGST = item.SGST || 0;
                    salesOrder.IGST = item.IGST || 0;
                    salesOrder.GSTCost = item.GSTCost || 0;
                    salesOrder.GSTpercent = item.GSTPercent || item.GSTpercent || 0;
                    salesOrder.NCName = item.NCName || "";
                    salesOrder.RoomNo = item.RoomNo || item.RoomNumber || "";
                    salesOrder.RoomNumber = item.RoomNumber || item.RoomNo || "";
                    salesOrder.NCRadio = item.NCRadio || item.NCRadio || "";

                    salesOrderList.push(salesOrder);

                    orderDetailHtml +=
                        '<tr>' +
                        '<td><a href="#">' + (salesOrder.ProductName) + '</a></td>' +
                        '<td id="' + (salesOrder.ItemMasterID || '') + '" class="OneUnitPrice">' + (salesOrder.ActualCost || 0) + '</td>' +
                        '<td class="countInput">' +
                        '<div class="sp-quantity">' +
                        '<span class="sp-minus fff"> <a class="ddd" href="javascript:void(0)">-</a></span>' +
                        '<span class="sp-input"><input type="text" style="width: 40%;" onkeypress="return isNumberKey(event)" class="quntity-input" value="' + (salesOrder.ProductQty || 0) + '"></span>' +
                        '<span class="sp-plus fff"> <a class="ddd" href="javascript:void(0)">+</a></span>' +
                        '</div>' +
                        '</td>' +
                        '<td class="w-10"><a href="javascript:void(0)" class="icon"><i class="fa fa-pencil"></i></a></td>' +
                        '<td class="totalPrice">' + (item.TotalAmount || 0) + ' </td>' +
                        '</tr>';
                });

                $("#OrderRow").empty().append(orderDetailHtml);
                $('.sp-minus').hide();
                tempSalesOrderList = $.extend(true, {}, salesOrderList);
                OrderTotalAmount();
            },
            error: function (xhr, status, err) {
                console.error("OrderDetailbyOrderID failed:", status, err, xhr.responseText);
            }
        });
    }

    //$(document.body).on("click", ".splWidget", function () {

    //    // salesOrder
    //    var id = $(this).closest('div').attr('id');
    //    AddItemsToCart(Items, id);

    //});
    $(document).on("click", ".splWidget", function (e) {
        debugger;
        e.preventDefault();
        var id = $(this).attr('id');
        console.log("Clicked Item ID:", id); // F12 console mein check karo
        if (id) {
            AddItemsToCart(Items, id);
        }
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
            debugger;
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
                            debugger;
                            var isNC = $("#nc").is(":checked") ? "NC" : "";
                            salesOrderList.forEach(function (item) {
                                item.RoomNo = roomNo;
                                item.RTID = parseInt(rtid) || 0;
                                item.GCID = parseInt(gcid) || 0;
                                item.NCName = nsNameValue;
                                // Add the NC status here
                                item.NCRadio = isNC;
                            });
                            $.ajax({
                                type: "POST",
                                data: JSON.stringify(salesOrderList),
                                url: apiUrl + '/api/Item/SaveItemOrderDetail',
                                // url: 'http://localhost:5000/api/Item/SaveItemOrderDetail',
                                dataType: "json", contentType: "application/json;charset=utf-8",
                                success: function (response) {
                                    if (parseInt(response) > 0) {
                                        $('.sp-minus').hide();

                                        tempSalesOrderList = $.extend(true, {}, salesOrderList);

                                        ShowControls();

                                        $("#hdnOrderID").val(response);

                                        salesOrderList.forEach((item, index) => salesOrderList[index].OrderID = response)

                                        ///print content without loading 
                                        if (id == undefined || id == "") {
                                            id = parseInt($("#hdnOrderID").val());
                                        }

                                        openWindowForPrint("http://127.0.0.1:62351/api/Printing/Print/" + id + "?printerName=LAN1");

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
            if (id == undefined || id == "") {
                id = parseInt($("#hdnOrderID").val());
            }
            // window.location.href = "/PrintwithoutGST.aspx?id=" + id + "&orderType=" + orderType + "";
            openWindowForPrint("http://127.0.0.1:62351/api/Printing/Print/" + id + "?printerName=LAN1");
        }
        else {
            GetInvalidCartMessage();
        }
    });
    //$(document.body).on("click", "#printviewbill", function () {
    //    if (id == undefined) {
    //        id = parseInt($("#hdnOrderID").val());
    //    }
    //    window.location.href = "/order.aspx?status=" + tablestatus + "&orderType=" + orderType + "&id=" + id + "&tablename=" + tablename + "";
    //});
    //$(document.body).on("click", "#printviewbill", function () {
    //    if (id == undefined) {
    //        id = parseInt($("#hdnOrderID").val());
    //    }
    //    // Naya data pick karo fields se
    //    var roomNo = $("#txtRoomNo").val();
    //    var rtid = $("#hdnRTID").val();
    //    var gcid = $("#hdnGCID").val();

    //    // URL mein parameters add kar do
    //    window.location.href = "/order.aspx?status=" + tablestatus +
    //        "&orderType=" + orderType +
    //        "&id=" + id +
    //        "&tablename=" + tablename +
    //        "&roomNo=" + encodeURIComponent(roomNo) +
    //        "&rtid=" + rtid +
    //        "&gcid=" + gcid;
    //    window.location.href = "/order.aspx?status=" + tablestatus + "&orderType=" + orderType + "&id=" + id + "&tablename=" + tablename + "";
    //});
    // 1. Variables ko global rakhein taaki click function inhe hamesha read kar sake
    // ✅ URL se values nikaalne ka function
    function getUrlVars() {
        var vars = {};
        var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi,
            function (m, key, value) {
                vars[key] = decodeURIComponent(value);
            });
        return vars;
    }

    // ✅ URL values
    var urlData = getUrlVars();
    var id = urlData["id"] || "";
    var tablestatus = urlData["status"] || "";
    var orderType = urlData["orderType"] || "";
    var tablename = urlData["tablename"] || "";

    // ✅ Data save karne ka function
    function SaveRoomDetails() {
        try {

            var roomVal = $("[id$='txtRoomNo']").val() || "";
            var rtVal = $("[id$='hdnRTID']").val() || "0";
            var gcVal = $("[id$='hdnGCID']").val() || "0";

            localStorage.setItem("bill_roomNo", roomVal);
            localStorage.setItem("bill_rtid", rtVal);
            localStorage.setItem("bill_gcid", gcVal);

            console.log("LocalStorage Saved:", roomVal, rtVal, gcVal);
            return true;

        } catch (e) {
            console.error("Storage Error:", e);
            return false;
        }
    }

    $(document).on("click", "#printviewbill", function (e) {

        e.preventDefault();

        // ✅ Pehle localStorage save karo
        var saved = SaveRoomDetails();

        if (!saved) {
            alert("Data save nahi hua!");
            return false;
        }

        // ✅ Order ID check (Pehle variable se, warna hidden field se)
        var currentId = id || $("[id$='hdnOrderID']").val();

        if (!currentId || currentId === "0") {
            alert("Order ID nahi mili! Pehle Save KOT karein.");
            return false;
        }

        // ✅ Redirect URL properly build karo (Tablename add kar diya gaya hai)
        var nextUrl = "/order.aspx"
            + "?status=" + encodeURIComponent(tablestatus)
            + "&orderType=" + encodeURIComponent(orderType)
            + "&id=" + encodeURIComponent(currentId)
            + "&tablename=" + encodeURIComponent(tablename); // 🔥 Ye line miss thi

        console.log("Redirecting to:", nextUrl);

        // ✅ Final Redirect
        window.location.href = nextUrl;

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
    var heading = "";
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
    // UI Update
    $("#lblheading").html(heading);
    if (orderType == "3" || orderType == "4") {
        $("#divtablename").show();
        $("#lbltablename").html(tablename);
    }

    if (tablename) localStorage.setItem("current_tableName", tablename);
    localStorage.setItem("current_orderHeading", heading);
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
function openWindowForPrint(url) {
    var myWindow = window.open(url, "myWindow", "width=200,height=100");
    setTimeout(() => { myWindow.close(); }, 200);

}
$("#txtRoomNo").autocomplete({
    minLength: 1,
    appendTo: "body",
    open: function () {
        $(this).autocomplete("widget").css({
            "left": "931.949px",
            "top": "528.656px",
            "width": "81.825px",
            "position": "absolute",
            "z-index": "999999"
        });
    },
    source: function (request, response) {
        $.ajax({
            url: "https://hotelpremierinn.rstpms.com/Hotel/API/GetOccupiedRooms",
            type: "GET",
            dataType: "json",
            data: { companyid: 1067 },
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

function GetRecentOrders() {
    $.ajax({
        type: "GET",
        url: apiUrl + '/api/Item/GetRecentOrders',
        dataType: "json",
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            var recentorder = "";

            $.each(data, function (i) {
                // prepare encoded room and nc values for querystring
                var roomQs = encodeURIComponent(data[i].RoomNo || "");
                var ncQs = encodeURIComponent(data[i].NCName || "");

                recentorder += '<tr>' +
                    '<td><a href="#">' + data[i].OrderNo + '</a></td>' +
                    '<td>' + (data[i].RoomNo != null ? data[i].RoomNo : '-') + '</td>' +
                    '<td>' + data[i].OrderDate + '</td>' +
                    '<td>' + data[i].OrderTime + '</td>' +
                    '<td><b class="order-timer" data-start-time="' + data[i].OrderDate + ' ' + data[i].OrderTime + '">00:00:00</b></td>' +
                    '<td>' + data[i].OrderTypeName + '</td>' +
                    '<td>' + data[i].TableName + '</td>' +
                    '<td class="ng-tns-c8-2">' + data[i].TotalPaid + '</td>' +
                    '<td class="totalPrice">' + data[i].PaymentStatus + '</td>' +

                    // Go to Menu (Take_away) - include roomNo & ncName
                    '<td>' +
                    '<a href="/Take_away.aspx?orderType=' + data[i].OrderType +
                    '&id=' + data[i].OrderID +
                    '&status=' + data[i].TableStatus +
                    '&TableID=' + data[i].TableID +
                    '&roomNo=' + roomQs +
                    '&ncName=' + ncQs +
                    '" class="editbtn" title="Edit">' +
                    '<i class="glyphicon glyphicon-edit" style="color: green"></i>' +
                    '</a></td>' +

                    // Edit Order
                    '<td>' +
                    '<a href="/order.aspx?orderType=' + data[i].OrderType +
                    '&id=' + data[i].OrderID +
                    '&status=' + data[i].TableStatus +
                    '&TableID=' + data[i].TableID +
                    '" class="editbtn" title="Edit">' +
                    '<i class="glyphicon glyphicon-edit" style="color: green"></i>' +
                    '</a></td>' +
                    '</tr>';
            });

            $("#RecentOrders").html(recentorder);
        }
    });
}
// read optional room and NC passed via querystring (from Welcome.aspx)
var qsRoom = getUrlVars()["roomNo"] ? decodeURIComponent(getUrlVars()["roomNo"]) : "";
var qsNc = getUrlVars()["ncName"] ? decodeURIComponent(getUrlVars()["ncName"]) : "";

// If redirected with room / nc in querystring, set fields immediately
if (qsRoom || qsNc) {
    setTimeout(function () {
        var $txtRoom = $("#txtRoomNo").length ? $("#txtRoomNo") : $("[id$='txtRoomNo']");
        var $txtNC = $("#txtNCName").length ? $("#txtNCName") : $("[id$='txtNCName']");
        if (qsRoom && $txtRoom.length) {
            $txtRoom.val(qsRoom);
            // 🔥 POPUP FIX 3: Dynamic close to hide popup instantly
            if ($txtRoom.data("ui-autocomplete") || $txtRoom.autocomplete("instance")) {
                $txtRoom.autocomplete("close");
            }
            $txtRoom.prop("disabled", true).css({ "background-color": "#eeeeee", "cursor": "not-allowed" }).blur();
        }
        if (qsNc && $txtNC.length) { $txtNC.val(qsNc).blur(); }
    }, 150);
}