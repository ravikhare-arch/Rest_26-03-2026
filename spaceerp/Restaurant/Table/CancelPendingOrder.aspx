<%@ Page Title="Cancelled Pending Orders" Language="C#" MasterPageFile="~/PageData.master" AutoEventWireup="true" CodeFile="CancelPendingOrder.aspx.cs" Inherits="CancelPendingOrderlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
   
   
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="../../css/CustomModal.css" rel="stylesheet" />
    <link href="../../css/customize-model.css" rel="stylesheet" />
   <link href="../../css/customDataTable.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    
    <div class="panel panel-inverse">
        <div class="panel-heading">

            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Cancelled Pending Order</h4>




        </div>
        <div class="panel-body">
            <div class="col-md-12 col-md-push-2">
                <div class="clearfix form-group">
                    <div class="col-md-2">
                        <label class="col-form-label" for="fullname">
                            Order Type
                        </label>
                        <asp:DropDownList ID="ddlordertype" runat="server" CssClass="form-control js-example-placeholder-single">
                           
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
            <div class="col-sm-12 text-center center-block well-sm" id="divprint">
                <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
            </div>
            <div id="wrapper1">
                <div id="div1">
                </div>
            </div>
            <div id="wrapper2">
                <div id="div2">
                <div id="divpendingorders"></div>
            </div>
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
        var apiUrl = $("[id$='hdnApiurl']").val();
        $(document.body).ready(function () {
            $("#btnsearch").on("click", function () {
                loaddata();
            });
            // // // get subaccountledgerid value from row
            $(document.body).on("click", ".deletebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(16)').text();
                $("#orderid").val(id);
                $("#deletebutton").show();


            });

            // // end
            // // //delete the agent
            $(document.body).on("click", "#deletebutton", function () {
                var id = $("#orderid").val();
                $.ajax({
                    type: "POST",
                    url: apiUrl+'/api/Item/CancelOrder/' + id + '',
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



        function loaddata() {
            var startDate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var endDate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            var orderType = $("#ctl00_ContentPlaceHolder1_ddlordertype").val();
            $.ajax({
                url: apiUrl+'/api/Item/CancelledPendingOrder?orderType=' + orderType + '&startDate=' + startDate + '&endDate=' + endDate + '',
                type: "GET",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var vcount = 0;
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><td style='width:2%'>Sr No.</td><td>Order ID</td><td>Order Date</td><td>Order Time</td><td>Order Type</td><td>Customer</td><td>Table Status</td><td>Total Amount</td><td>Total Discount</td><td>Charge</td><td>Total GST</td><td>Total Paid</td><td>Payment Status</td><td style='width:3%'>Go to Menu</td><td style='display:none;'>Order ID</td></tr></thead><tbody>";
                    $.each(data, function (i) {
                        vcount = vcount + 1;
                        html += "<tr>";
                        html += "<td> " + vcount + "</td>";
                        html += "<td> " + data[i].OrderNo + "</td>";
                        html += "<td> " + data[i].OrderDate + " </td>";
                        html += "<td> " + data[i].OrderTime + " </td>";
                        html += "<td> " + data[i].OrderTypeName + "</td>";
                        //html += "<td> </td>";
                        html += "<td> " + data[i].CustomerName + "</td>";
                        html += "<td> Cancelled</td>";
                        html += "<td> " + data[i].TotalOrderAmount + "</td>";
                        html += "<td> " + data[i].TotalDiscount + " </td>";
                        html += "<td> " + data[i].Charge + "</td>";
                        html += "<td>  " + data[i].GSTCost + " </td>";
                        html += "<td> " + data[i].TotalPaid + "</td>";
                        html += "<td> " + data[i].PaymentStatus + "</td>";
                        html += '<td >' + '<a href=/Agent/Take_away.aspx?orderType=' + data[i].OrderType + '&id=' + data[i].OrderID + '&status=' + data[i].TableStatus + '&TableID=' + data[i].TableID + '&cancel=0 class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" ></i></a>' + '</td>';
                        html += "<td style='display:none;'> " + data[i].OrderID + "</td>";
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
