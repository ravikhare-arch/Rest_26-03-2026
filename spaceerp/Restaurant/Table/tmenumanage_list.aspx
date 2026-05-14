<%@ Page Title="Menu Management" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tmenumanage_list.aspx.cs" Inherits="tmenumanage_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
  <%--  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .modal-header {
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background: #1b82ec;
            color: #fff;
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
            background: #1b82ec;
            padding-bottom: 5px;
            padding-top: 5px;
        }

        .modal-xl {
            width: 80% !important;
            max-width: 1200px;
        }

        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }
        /*.modal-body {
    position: relative;
    padding: 0px;
}*/
        .close {
            float: right;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: 2;
        }

        .btnspl {
            min-width: 217px;
            padding: 10px 50px;
        }

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
    <link href="../../css/customDataTable.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lblmsg" runat="server"></asp:Label>

    <style type="text/css">
        .card-title {
            text-align: center;
            /*padding: 10px;*/
            font-weight: 600;
            border: 1px solid #0098da;
        }

        .text-white {
            color: red !important;
        }

        .nav-tabs > li > a:hover {
            background: #00bcd4;
        }

        label {
            color: black;
            padding-top: 8px;
        }

        .radio-inline, .checkbox-inline {
            margin-top: -8px;
        }

        .well {
            background: white;
            border: 1px solid #0098da;
        }


            .well .fa {
                color: Black;
            }

        .nav-tabs .nav-link.active, .nav-tabs .nav-item.show .nav-link {
            color: white !important;
        }

        .card-block {
            color: black;
        }

        .card {
            background: whitesmoke !important;
        }

        .form-control {
            border: 1px solid #00bcd4;
        }

        .table {
            text-align: center !important;
            border: 1px solid #0098da !important;
            /*background: white;*/
            /*margin-left: 15px;*/
        }

            .table th {
                background: linear-gradient(90deg, #ff0015 31%, #595959 69%) !important;
                /*color: white;*/
                border: 1px solid white;
                border-bottom: none;
                padding: 5px;
            }

            .table td {
                padding: 5px;
            }

            .table tr:nth-of-type(even) {
                background-color: rgba(94, 93, 82, 0.1);
            }

        .frm_sec {
            border: 1px solid #0098da;
            margin: 0;
            border-radius: 4px;
            box-shadow: 0 4px 3px 0 #0e6390c7;
        }

        .destination {
            border-right: 1px solid #0098da;
        }
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <%--<div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;
             <i class="fa fa-plus"></i></a>
            </div>--%>
            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Menu Management</h4>




        </div>
        <div class="panel-body">
            <div class="col-md-12 col-md-push-2">
                <div class="clearfix form-group">
                    <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="fullname">
                                    Delivery Type
                                </label>
                                <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlDeliveryType_selected">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDeliveryType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                            </div>
                            <div class="col-md-2 col-sm-3" id="trac" runat="server" visible="false">
                                <label class="col-form-label" for="fullname">
                                    AC / NON - AC 
                                </label>
                                <asp:DropDownList ID="ddlacnonac" runat="server" CssClass="form-control js-example-placeholder-single">
                                    <asp:ListItem Text="Select AC / NON - AC" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="AC" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="NON - AC" Value="1"></asp:ListItem>

                                </asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlacnonac" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2">
                                <label>&nbsp;</label>
                                <input type="button" id="btnsearch" class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>



            </div>
            <div id="wrapper1">
                <div id="div1">
                </div>
            </div>
            <div id="wrapper2">
                <div id="div2">
                    <div id="divagentlist"></div>
                </div>
            </div>
        </div>
    </div>


    <!--Delete Modal popup -->
    <div class="modal fade" id="deleteModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Menu Management</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to delete?</label>
                    <label style="color: black; display: none;" id="lblsucess">Deleted Successfully..!</label>
                    <label style="color: white; display: none" id="lblinactive">Are you sure you want to De-Activate?</label>
                    <label style="color: white; display: none;" id="lblinactivesucess">Successfully De-Activated?</label>
                    <label style="color: white; display: none" id="lblactive">Are you sure you want to Activate?</label>
                    <label style="color: white; display: none;" id="lblactivesucess">Successfully Activated!!!</label>
                    <label id="accountledgerid" style="display: none"></label>
                    <label id="journalvoucherdetid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Delete</button>
                    <button type="button" class="btn btn-primary" id="inactivebutton">De-Activate</button>
                    <button type="button" class="btn btn-primary" id="activebutton">Activate</button>
                </div>
            </div>
        </div>
    </div>



    <script type="text/javascript">
        function pageLoad(sender, args) {
            $(document).ready(function () {
                // Search Button Click
                $("#btnsearch").on("click", function () {
                    loaddata();
                });

                // 1. DELETE ACTION (Direct Alert)
                $(document).off("click", ".deletebtn").on("click", ".deletebtn", function (e) {
                    e.preventDefault();
                    var id = $(this).closest('tr').find('td:eq(13)').text().trim();

                    if (confirm("Do you want to delete this then please ok ?")) {
                        debugger;
                        $.ajax({
                            type: "POST",
                            url: 'tmenumanage_list.aspx/DeleteVoucher',
                            data: JSON.stringify({ AccountLedgerID: id }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d == "1") {
                                    alert("Deleted Successfully!");
                                    loaddata(); // Table refresh
                                } else {
                                    alert("Error: " + data.d);
                                }
                            },
                            error: function (xhr) {
                                alert("API Hit nahi hui. Console check karein.");
                            }
                        });
                    }
                });

                // 2. INACTIVE ACTION (Direct Alert)
                $(document).off("click", ".Inactivebtn").on("click", ".Inactivebtn", function (e) {
                    e.preventDefault();
                    var id = $(this).closest('tr').find('td:eq(13)').text().trim();

                    if (confirm("Do you want to De-Active this please ok ?")) {
                        $.ajax({
                            type: "POST",
                            url: 'tmenumanage_list.aspx/MarkInactive',
                            data: JSON.stringify({ agencyid: id }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d == "1") {
                                    alert("De-Activated!");
                                    loaddata();
                                }
                            }
                        });
                    }
                });

                // 3. ACTIVE ACTION (Direct Alert)
                $(document).off("click", ".Activebtn").on("click", ".Activebtn", function (e) {
                    e.preventDefault();
                    var id = $(this).closest('tr').find('td:eq(13)').text().trim();

                    if (confirm("Do you want to Active this please ok ")) {
                        $.ajax({
                            type: "POST",
                            url: 'tmenumanage_list.aspx/MarkActive',
                            data: JSON.stringify({ agencyid: id }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                                if (data.d == "1") {
                                    alert("Activated Successfully!");
                                    loaddata();
                                }
                            }
                        });
                    }
                });
            });
        }

        // loaddata() function aapka pehle wala hi rahega...
        function loaddata() {
            var acnonac = document.getElementById("<%=ddlacnonac.ClientID %>") ? document.getElementById("<%=ddlacnonac.ClientID %>").value : "0";
        var deliveryType = document.getElementById("<%=ddlDeliveryType.ClientID %>").value;

            $.ajax({
                url: 'tmenumanage_list.aspx/loaddata',
                type: "post",
                data: JSON.stringify({ deliveryType: deliveryType, acnonac: acnonac }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'>" +
                        "<thead><tr><th>No.</th><th>Delivery Type</th><th>Code</th><th>Dish Name</th><th>Group</th><th>Category</th><th>Type</th><th>Amount</th><th>CGST</th><th>SGST</th><th>Total GST</th><th>Net</th><th>Action</th><th style='display:none'>MenuID</th></tr></thead><tbody>";

                    for (var i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        var row = mainlist.d.mpagemasterobjlist[i];
                        html += '<tr>' +
                            '<td>' + (i + 1) + '</td>' +
                            '<td>' + row.DeliveryType + '</td>' +
                            '<td>' + row.ProductCode + '</td>' +
                            '<td>' + row.Product + '</td>' +
                            '<td>' + row.GroupName + '</td>' +
                            '<td>' + row.CategoryID + '</td>' +
                            '<td>' + row.FoodTypeID + '</td>' +
                            '<td>' + row.Price + '</td>' +
                            '<td>' + row.CGST + '</td>' +
                            '<td>' + row.SGST + '</td>' +
                            '<td>' + row.ActualCost + '</td>' +
                            '<td>' + row.NetPayable + '</td>' +
                            '<td>' +
                            '<a href="/Restaurant/Table/tmenumanage.aspx?id=' + row.MenuID + '" class="btn btn-xs" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green"></i></a>' +
                            '<a href="#" class="deletebtn btn btn-xs" title="Delete"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' +
                            '<a href="#" class="Inactivebtn btn btn-xs" title="De-Activate"><i class="glyphicon glyphicon-ban-circle" style="color: orange"></i></a>' +
                            '<a href="#" class="Activebtn btn btn-xs" title="Activate"><i class="glyphicon glyphicon-ok" style="color: blue"></i></a>' +
                            '</td>' +
                            '<td style="display:none;">' + row.MenuID + '</td>' +
                            '</tr>';
                    }
                    html += "</tbody></table>";
                    $("#divagentlist").html(html);

                    $("#tblagentlist").DataTable({
                        "aLengthMenu": [[15, 50, 100, -1], [15, 50, 100, "All"]],
                        "iDisplayLength": 15,
                        "destroy": true
                    });
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
