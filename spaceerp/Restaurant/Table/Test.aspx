<%@ Page Title="" Language="C#" MasterPageFile="~/PageData.master" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Agent_Restaurant_Table_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <div class="panel panel-inverse">
        <div class="panel-heading">
           
            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server"  CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                 
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center"> <label id="lblheading"></label></h4>




        </div>
        <div class="panel-body">
             <div class="col-md-12 col-md-push-2">
                <div class="clearfix form-group">
                    <div class="col-md-2">
                        <label class="col-form-label" for="fullname">
                                        Mode of Payment
                                    </label>
                                    <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="form-control js-example-placeholder-single">
                                        <asp:ListItem Text="Select Payment Mode" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="CASH" Value="CASH"></asp:ListItem>
                                        <asp:ListItem Text="CARD" Value="CARD"></asp:ListItem>
                                        <asp:ListItem Text="PAYTM" Value="PAYTM"></asp:ListItem>
                                        <asp:ListItem Text="PHONEPE" Value="PHONEPE"></asp:ListItem>
                                        <asp:ListItem Text="LENDING" Value="LENDING"></asp:ListItem>
                                        <asp:ListItem Text="MULTIPLE" Value="MULTIPLE"></asp:ListItem>
                                         <asp:ListItem Text="GPAY" Value="GPAY"></asp:ListItem>
                                    </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label for="form-1-3" class="col-form-label">From Date</label>
                        <div class="timepicker-input">
                            <asp:TextBox ID="txttLastPurchase" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="txttLastPurchase" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server" TargetControlID="txttLastPurchase"
                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV18" ControlToValidate="txttLastPurchase" ValidationGroup="A"
                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="col-md-2">
                        <label for="form-1-3" class="col-form-label">To Date</label>
                        <div class="timepicker-input">
                            <asp:TextBox ID="txttLastOrder" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender19" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="txttLastOrder" TargetControlID="txttLastOrder" PopupPosition="TopLeft" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE19" runat="server" TargetControlID="txttLastOrder"
                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV19" ControlToValidate="txttLastOrder" ValidationGroup="A"
                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <label>&nbsp;</label>
                    <input type="button" id="btnsearch" class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />
                </div>
                </div>

            </div>
            <div>
                <div id="divpendingorders"></div>
            </div>
        </div>
    </div>
 
     <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Cancel Order</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to Cancel Order?</label>
                    <label style="color: black; display: none;" id="lblsucess">Order Cancelled..!!!</label>


                    <label id="orderid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Cancel</button>

                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">                                                                                           
        var orderType = getUrlVars()["orderType"];
        $(document.body).ready(function () {
            SetButtonTextValue(orderType);
            $("#btnsearch").on("click", function () {
                loaddata();
            });

            $(document.body).on("click", ".deletebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(17)').text();
                $("#orderid").val(id);
                $("#deletebutton").show();


            });

            // // end
            // // //delete the agent
            $(document.body).on("click", "#deletebutton", function () {
                var id = $("#orderid").val();
                $.ajax({
                    type: "POST",
                    url: 'http://localhost:62351/api/Item/CancelOrder/' + id + '',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {

                        if (parseInt(response) > 0) {
                            $("#lblsucess").css("display", "block");
                            $("#lbldelete").hide();
                            loaddata();
                            $("#deletebutton").hide();
                            // $('#exampleModalCenter').modal('toggle');
                            $("#orderid").val('');
                        }
                        else {
                            $("#lblsucess").css("display", "block");
                            $("#lblsucess").val(data.d);
                            $("#lbldelete").hide();
                        }
                    },
                    error: function (response) {
                        alert(response);
                    }
                });
            });
        });

        function SetButtonTextValue(orderType) {
            var jsLang = orderType;
            switch (jsLang) {
                case "1":
                    $("#lblheading").html('Take Away Report');
                    break;
                case "2":
                    $("#lblheading").html('Door Delivery Report');
                    break;
                case "3":
                    $("#lblheading").html('Dine-In Report');
                    break;
            }
        }



        function loaddata() {
            var startDate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var endDate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var payMode = $("#ctl00_ContentPlaceHolder1_ddlpaymode").val();
            $.ajax({
                url: 'http://localhost:62351/api/Item/CompletedOrders?orderType=' + orderType + '&startDate=' + startDate + '&endDate=' + endDate + '&payMode=' + payMode + '',
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var vcount = 0;
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Order ID</td><td>Order Date</td><td>Order Time</td><td>Order Type</td><td>Rider</td><td>Customer</td><td>Table Status</td><td>Total Amount</td><td>Total Discount</td><td>Charge</td><td>Total GST</td><td>Total Paid</td><td>Payment Mode</td><td>Payment Status</td><td style='width:3%'>View Data</td><td>Cancel Order</td><td style='display:none'>OrderID</td></tr></thead><tbody>";
                    $.each(data, function (i) {
                        vcount = vcount + 1;
                        html += "<tr>" ;
                        html += "<td> " + vcount + "</td>";
                        html += "<td> " + data[i].OrderNo + "</td>";
                        html += "<td> " + data[i].OrderDate + " </td>";
                        html += "<td> " + data[i].OrderTime + " </td>";
                        html += "<td> " + data[i].OrderTypeName + "</td>";
                        html += "<td> </td>";
                        html += "<td> " + data[i].CustomerName + "</td>";
                        html += "<td> " + data[i].TableStatus + "</td>";
                        html += "<td> " + data[i].TotalOrderAmount + "</td>";
                        html += "<td> </td>";
                        html += "<td> " + data[i].Charge + "</td>";
                        html += "<td> </td>";
                        html += "<td> " + data[i].TotalPaid + "</td>";
                        html += "<td> " + data[i].PayMode + "</td>";
                        html += "<td> " + data[i].PaymentStatus + "</td>";
                        html += '<td >' + '<a href=/Agent/order.aspx?orderType=' + orderType + '&id=' + data[i].OrderID + '&status=' + data[i].TableStatus + ' class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>' + '</td>';
                        html += '<td >' + '<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += "<td style='display:none'> " + data[i].OrderID + " </td>";
                        html += "</tr>";
                    });
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divpendingorders").html(html);

                    var table = $("#tblagentlist").DataTable({
                        "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                        "iDisplayLength": 5,

                        //"bRetrieve": true,
                        //"retrieve": true,
                        //"orderCellsTop": true,

                        //"bLengthChange": false,

                        //"scrollX": true,

                        //"scrollCollapse": true,

                        "paging": true,

                        language: {
                            searchPlaceholder: ""
                        },

                    });

                },
                error: function (data) {
                    alert(data.d);
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
        
    </script>

</asp:Content>
