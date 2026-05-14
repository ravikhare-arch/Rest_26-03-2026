<%@ Page Title="Order Type Mapping" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="OrderTypeTableAreaMap.aspx.cs" Inherits="OrderTypeTableAreaMap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top: 0px;
            margin-bottom: 0px;
            padding: 0px;
        }

        .enlarged #wrapper .content-page {
            margin-left: 0px;
        }

        .topbar {
            display: none;
        }

        .footer {
            display: none;
        }

        .side-menu {
            display: none;
        }
    </style>
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

        .btn-primary {
            background: linear-gradient(to left, #0e6390, #00bcd4);
            border: none !important;
        }

            .btn-primary:hover, .btn-primary:focus {
                background: linear-gradient(to left, #0e6390, #00bcd4);
                border: none !important;
            }

        .btn-warning {
            background: linear-gradient(to left, #862359, #f0ad4e);
        }

            .btn-warning:hover {
                background: linear-gradient(to left, #423f9c, #f0ad4e);
            }

        .btn-danger {
            background: linear-gradient(to left, #c82333, #ff568f);
        }

            .btn-danger:hover {
                background: linear-gradient(to left, #ff568f, #c82333);
            }

        .btn-default {
            background: linear-gradient(to left, #00bcd4, #0e6390);
            border: none !important;
            color: white !important;
        }

            .btn-default:hover {
                background: linear-gradient(to left, #0e6390, #00bcd4);
                border: none !important;
            }


        .frm_sec {
            border: 1px solid #0098da;
            margin: 0;
            border-radius: 4px;
            box-shadow: 0 4px 3px 0;
        }

        .destination {
            border-right: 1px solid #0098da;
        }
    </style>
    <style>
        .modal {
            /*top: 10% !important;*/
            /*left: 22% !important;*/
            /*left: 183px;*/
            position: absolute;
            /*top: 75.5px;*/
            z-index: 10000007;
            opacity: 1;
            /* display: block;*/
        }

        .modal-open .modal {
            background: none;
            border: none;
        }
    </style>
    <style>
        .modal-header {
            border-bottom: 1px solid #e5e5e5;
            background: #1b82ec;
            color: #fff;
            padding-top: 0px;
            padding-bottom: 0px;
            height: 34px;
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
            margin: 10px 0px;
        }

        .modal-header .close {
            margin-top: -22px;
        }

        .modal-title {
            line-height: 2;
        }

        .btn-browse {
            padding: 10px 58px !important;
        }

        .modal-content {
            position: absolute;
        }
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info m-r-5 m-b-5" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Order Type Mapping </h4>




        </div>
        <div class="panel-body">
            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
            <!--create/edit Modal popup -->

            <div class="modal fade" id="exampleModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-sm" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Order Type Mapping</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="pdd-horizon-15 pdd-vertical-20">

                                <div class="card-block">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="">
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Order Type</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlordertype" runat="server" CssClass="form-control">

                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Area</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddlarea" runat="Server" CssClass="form-control"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlarea" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                 <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Table</label>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="ddltable" runat="Server" CssClass="form-control"></asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddltable" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <label id="lbelsucess" style="color: forestgreen; display: none;">Successfully Added..!</label>
                                                    <label id="lbelupdatesucess" style="color: forestgreen; display: none;">Successfully Updated..!</label>
                                                    <label id="lblrequirefield" style="color: darkred; display: none;">Enter Required Fields..!</label>
                                                </div>


                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnclose">Close</button>
                                <button type="button" class="btn btn-primary" id="btnadd">Add</button>
                                <button type="button" class="btn btn-primary" id="btnupdate">Update</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Delete Modal popup -->
    <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Order Type Mapping</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to delete?</label>
                    <label style="color: black; display: none;" id="lblsucess">Deleted Successfully..!</label>


                    <label id="accountledgerid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Delete</button>

                </div>
            </div>
        </div>
    </div>





    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>

    <script type="text/javascript">


        $(document.body).ready(function () {
            loaddata();

            $("#btnadd").on("click", function () {
                if (validatedata()) {
                    var obj = {
                        OrderTypeID: $("#ctl00_ContentPlaceHolder1_ddlordertype").val(),
                        AreaID: $("#ctl00_ContentPlaceHolder1_ddlarea").val(),
                        TableID: $("#ctl00_ContentPlaceHolder1_ddltable").val(),
                    }

                    $.ajax({
                        url: '<%=ResolveUrl("OrderTypeTableAreaMap.aspx/addPagePamster") %>',
                        data: JSON.stringify({ list: obj }),
                        type: "post",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "1") {
                                $("#btnadd").hide();
                                $("#lbelsucess").show();
                                $('#lbelupdatesucess').hide();
                                $("#lblrequirefield").hide();
                                loaddata();

                            }
                            else {
                                alert(data.d);
                            }

                        },
                        error: function (data) {
                            alert(data.d);
                        }
                    });
                }


            });

            // // // get subaccountledgerid value from row
            $(document.body).on("click", ".deletebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(5)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").show();


            });

            // // end
            // // //delete the agent
            $(document.body).on("click", "#deletebutton", function () {
                var subagentid = $("#accountledgerid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("OrderTypeTableAreaMap.aspx/DeletePageMaster") %>',
                    data: JSON.stringify({ AccountLedgerID: subagentid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            $("#lblsucess").css("display", "block");
                            $("#lbldelete").hide();
                            loaddata();
                            $("#deletebutton").hide();
                            // $('#exampleModalCenter').modal('toggle');
                            $("#accountledgerid").val('');
                        }
                        else {
                            $("#lblsucess").css("display", "block");
                            $("#lblsucess").val(data.d);
                            $("#lbldelete").hide();
                        }
                    },
                    error: function (data) {
                        alert(data.d);
                    }
                });
            });
            // // //delete agent end
            // // //  edit subagent 
            $(document.body).on("click", ".editbtn", function () {
                cleardata();

                $('#lbelupdatesucess').hide();

                $("#lbelsucess").hide();
                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(5)').text();
                $("#accountledgerid").val(id);

                $("#btnadd").css("display", "none");
                $("#ctl00_ContentPlaceHolder1_ddlordertype").val($(this).closest('tr').find('td:eq(6)').text());
                $("#ctl00_ContentPlaceHolder1_ddlarea").val($(this).closest('tr').find('td:eq(7)').text());
                $("#ctl00_ContentPlaceHolder1_ddltable").val($(this).closest('tr').find('td:eq(8)').text());
                $('#btnupdate').show();

            });


            // // // update code start
            $(document.body).on("click", "#btnupdate", function () {
                var obj = {
                    OrderTypeID: $("#ctl00_ContentPlaceHolder1_ddlordertype").val(),
                    AreaID: $("#ctl00_ContentPlaceHolder1_ddlarea").val(),
                    TableID: $("#ctl00_ContentPlaceHolder1_ddltable").val(),
                    OrderTypeTableAreaID: $("#accountledgerid").val(),
                }

                $.ajax({
                    url: '<%=ResolveUrl("OrderTypeTableAreaMap.aspx/UpdatePageMaster") %>',
                    data: JSON.stringify({ list: obj }),
                    type: "post",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == "1") {
                            $("#lbelupdatesucess").show();
                            loaddata();
                            $('#btnupdate').hide();

                        }
                        else {
                            alert(data.d);
                        }

                    },
                    error: function (data) {
                        alert(data.d);
                    }
                });

            });
            // // // update code 
            // // // clear the textbox and dropdown start
            $(document.body).on("click", "#lnklist", function () {
                cleardata();
                $('#btnupdate').hide();
                $("#lbelsucess").hide();
                $("#lbelupdatesucess").hide();
                $("#btnadd").show();


            });
            // // // end


        });
        function cleardata() {

            $("#ctl00_ContentPlaceHolder1_ddlordertype").val('')
            $("#ctl00_ContentPlaceHolder1_ddlarea").val('')
            $("#ctl00_ContentPlaceHolder1_ddltable").val('')
        }
        function validatedata() {
            var ledgername = document.getElementById("<%=ddlordertype.ClientID %>").value;
            var area = document.getElementById("<%=ddlarea.ClientID %>").value;
             var table = document.getElementById("<%=ddltable.ClientID %>").value;


            var validation = true;
            if (ledgername == "" || ledgername == "0") {
                validation = false;
            }
            if (area == "" || area == "0") {
                validation = false;
            }
            if (table == "" || table == "0") {
                validation = false;
            }
            if (!validation) {
                $("#lblrequirefield").show();
            }
            return validation;
        }

        function loaddata() {

            $.ajax({
                url: '<%=ResolveUrl("OrderTypeTableAreaMap.aspx/loaddata") %>',
                 type: "post",
                 contentType: "application/json;charset=utf-8",
                 dataType: "json",
                 success: function (mainlist) {
                     var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Order Type </td><td>Area Name</td><td>Table Name</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>Account LedgerID</td><td style='display:none'>Area ID</td></tr></thead><tbody>";
                     var vcount = 0;
                     for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                         //html += '<tr data-name>';
                         vcount = vcount + 1;
                         html += '<tr>';
                         html += '<td >' + vcount + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].OrderypeName + '</td>';
                         html += '<td >' + mainlist.d.mpagemasterobjlist[i].AreaName + '</td>';
                         html += '<td  >' + mainlist.d.mpagemasterobjlist[i].TableName + '</td>';
                         html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" data-toggle="modal" data-target="#exampleModalCenter"></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                         html += '<td style="display:none">' + mainlist.d.mpagemasterobjlist[i].OrderTypeTableAreaID + '</td>';
                         html += '<td style="display:none">' + mainlist.d.mpagemasterobjlist[i].OrderTypeID + '</td>';
                         html += '<td style="display:none">' + mainlist.d.mpagemasterobjlist[i].AreaID + '</td>';
                         html += '<td  style="display:none">' + mainlist.d.mpagemasterobjlist[i].TableID + '</td>';
                         html += '</tr>';

                     }
                     html += "</tbody><tfoot></tfoot></table>";
                     $("#divagentlist").html(html);
                     var table = $("#tblagentlist").DataTable({

                         //"bRetrieve": true,
                         //"retrieve": true,
                         //"orderCellsTop": true,

                         //"bLengthChange": false,

                         //"scrollX": true,

                         //"scrollCollapse": true,

                         //"paging": true,

                         language: {
                             searchPlaceholder: "Table Name"
                         },

                     });

                 },
                 error: function (data) {
                     alert(data.d);
                 }
             });
         }


    </script>

</asp:Content>
