<%@ Page Title="NC Master" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="NCMaster.aspx.cs" Inherits="NCMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <style>
        .content-page .content { margin-left: auto; margin-right: auto; display: block; margin-top: 0px; margin-bottom: 0px; padding: 0px; }
        
        /* Table theme matches the blue outline of image */
        .table { text-align: center !important; border: 1px solid #005580 !important; }
        
        /* Table Header changed from red/gray gradient to Deep Blue matching the image */
        .table th { background: #005580 !important; border: 1px solid #fff; padding: 10px; color: white !important; text-align:center; font-weight: normal; }
        .table td { padding: 8px; vertical-align: middle !important; border: 1px solid #ddd !important; }
        
        /* Modal Colors */
        .modal-header { background: #005580; color: #fff; }
        .modal-footer { background: #f5f5f5; }
        
        /* Custom red 'Create New' button like the image */
        .btn-create-custom { background-color: #e60000 !important; color: white !important; font-weight: bold; border: none; border-radius: 4px; padding: 6px 14px; }
        .btn-create-custom:hover { background-color: #cc0000 !important; color: white !important; }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    <div class="panel panel-inverse" style="margin-top:20px; border: 1px solid #003366;">
        <div class="panel-heading" style="background:#003366; color:white; padding:10px 15px; position: relative;">
            <div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-create-custom btn-sm" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>
            </div>
            <h4 class="panel-title text-center" style="margin:0; line-height:30px; font-weight: 500;">Area Master</h4>
        </div>
        
        <div class="panel-body">
            <div style="margin-top:20px;">
                <div id="divagentlist"></div>
            </div>

            <div class="modal fade" id="exampleModalCenter" role="dialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-md" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" style="color:white;">&times;</button>
                            <h4 class="modal-title">Create Name </h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">
                                
                                <div class="form-group">
                                    <label class="col-md-4 control-label">Area Name</label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txttablename" CssClass="form-control" runat="server" placeholder="Enter Area Name"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12 text-center">
                                        <label id="lbelsucess" style="color: forestgreen; display: none; font-weight:bold;">Successfully Added..!</label>
                                        <label id="lbelupdatesucess" style="color: forestgreen; display: none; font-weight:bold;">Successfully Updated..!</label>
                                        <label id="lblrequirefield" style="color: darkred; display: none; font-weight:bold;">Enter Required Fields..!</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <input type="hidden" id="hdn_ncid" value="" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnclose">Close</button>
                            <button type="button" class="btn btn-success" id="btnadd">Add</button>
                            <button type="button" class="btn btn-primary" id="btnupdate" style="display:none;">Update</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="deleteModalCenter" role="dialog" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background:#d9534f;">
                    <button type="button" class="close" data-dismiss="modal" style="color:white;">&times;</button>
                    <h4 class="modal-title" style="color: white">Confirm Delete</h4>
                </div>
                <div class="modal-body text-center">
                    <h4 id="lbldelete">Are you sure you want to delete?</h4>
                    <h4 style="color: forestgreen; display: none;" id="lbldeletesucess">Deleted Successfully..!</h4>
                    <input type="hidden" id="delete_ncid" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-danger" id="deletebutton">Delete</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            loaddata();

            // ADD METHOD
            $("#btnadd").on("click", function () {
                if (validatedata()) {
                    var obj = {
                        AreaName: $("#<%=txttablename.ClientID %>").val(),
                        OrderType: "0" // Defaulting to 0 since order type field is commented out
                    };

                    $.ajax({
                        url: '<%=ResolveUrl("NCMaster.aspx/addPagePamster") %>',
                        data: JSON.stringify({ list: obj }),
                        type: "post",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "1") {
                                $("#btnadd").hide();
                                $("#lbelsucess").show();
                                setTimeout(function () { $('#exampleModalCenter').modal('hide'); }, 1500);
                                loaddata();
                            } else {
                                alert(data.d);
                            }
                        },
                        error: function (xhr) { alert("Error adding data."); }
                    });
                }
            });

            // OPEN EDIT MODAL
            $(document.body).on("click", ".editbtn", function () {
                cleardata();
                $("#btnadd").hide();
                $("#btnupdate").show();

                var id = $(this).closest('tr').find('.td_ncid').text().trim();
                var ncName = $(this).closest('tr').find('.td_ncname').text().trim();

                $("#hdn_ncid").val(id);
                $("#<%=txttablename.ClientID %>").val(ncName);
                // Order Type setting removed from edit since it's commented out
            });

            // UPDATE METHOD
            $("#btnupdate").on("click", function () {
                if (validatedata()) {
                    var obj = {
                        AreaName: $("#<%=txttablename.ClientID %>").val(),
                        OrderType: "0",
                        AreaID: $("#hdn_ncid").val()
                    };

                    $.ajax({
                        url: '<%=ResolveUrl("NCMaster.aspx/UpdatePageMaster") %>',
                        data: JSON.stringify({ list: obj }),
                        type: "post",
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (data) {
                            if (data.d == "1") {
                                $("#lbelupdatesucess").show();
                                $("#btnupdate").hide();
                                setTimeout(function () { $('#exampleModalCenter').modal('hide'); }, 1500);
                                loaddata();
                            } else {
                                alert(data.d);
                            }
                        },
                        error: function (xhr) { alert("Error updating data."); }
                    });
                }
            });

            // OPEN DELETE MODAL
            $(document.body).on("click", ".deletebtn", function () {
                var id = $(this).closest('tr').find('.td_ncid').text().trim();
                $("#delete_ncid").val(id);
                $("#deletebutton").show();
                $("#lbldeletesucess").hide();
                $("#lbldelete").show();
            });

            // CONFIRM DELETE
            $("#deletebutton").on("click", function () {
                var ncid = $("#delete_ncid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("NCMaster.aspx/DeletePageMaster") %>',
                    data: JSON.stringify({ AccountLedgerID: ncid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data.d == "1") {
                            $("#lbldeletesucess").show();
                            $("#lbldelete").hide();
                            $("#deletebutton").hide();
                            setTimeout(function () { $('#deleteModalCenter').modal('hide'); }, 1500);
                            loaddata();
                        } else {
                            alert(data.d);
                        }
                    },
                    error: function (xhr) { alert("Error deleting data."); }
                });
            });

            // CREATE NEW BUTTON CLICK
            $("#lnklist").on("click", function () {
                cleardata();
                $("#btnupdate").hide();
                $("#btnadd").show();
            });
        });

        function cleardata() {
            $("#<%=txttablename.ClientID %>").val('');
            $("#hdn_ncid").val('');
            $("#lbelsucess, #lbelupdatesucess, #lblrequirefield").hide();
        }

        // VALIDATION METHOD (Order Type restriction removed, Mandatory constraint removed)
        function validatedata() {
            var ncname = $("#<%=txttablename.ClientID %>").val().trim();

            if (ncname == "") {
                $("#lblrequirefield").show();
                return false;
            }
            $("#lblrequirefield").hide();
            return true;
        }

        function loaddata() {
            $.ajax({
                url: '<%=ResolveUrl("NCMaster.aspx/loaddata") %>',
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    // Table headers dynamically updated to match image colors and titles
                    var html = "<table id='tblagentlist' class='table table-striped' style='width:100%'>" +
                        "<thead><tr><th style='width:10%'>Sr No.</th><th>Table Name</th><th style='width:20%'>Edit/Delete</th>" +
                        "<th style='display:none'>NC_ID</th><th style='display:none'>OrderTypeID</th></tr></thead><tbody>";

                    if (mainlist.d && mainlist.d.mpagemasterobjlist) {
                        for (var i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                            html += '<tr>';
                            html += '<td>' + (i + 1) + '</td>';
                            html += '<td class="td_ncname">' + mainlist.d.mpagemasterobjlist[i].AreaName + '</td>';

                            // Order Type ka data cell (<td>) yaha se hata diya gaya hai taaki screen par show na ho

                            html += '<td>' +
                                '<a href="#" class="editbtn btn btn-xs btn-success" data-toggle="modal" data-target="#exampleModalCenter" style="margin-right:10px;"><i class="glyphicon glyphicon-edit"></i></a>' +
                                '<a href="#" class="deletebtn btn btn-xs btn-danger" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash"></i></a>' +
                                '</td>';
                            html += '<td class="td_ncid" style="display:none;">' + mainlist.d.mpagemasterobjlist[i].AreaID + '</td>';
                            html += '<td class="td_ordertypeid" style="display:none;">' + mainlist.d.mpagemasterobjlist[i].OrderType + '</td>';
                            html += '</tr>';
                        }
                    }
                    html += "</tbody></table>";
                    $("#divagentlist").html(html);

                    $("#tblagentlist").DataTable({
                        destroy: true,
                        language: { searchPlaceholder: "Search..." }
                    });
                },
                error: function (xhr) { alert("Error loading grid data."); }
            });
        }
    </script>
</asp:Content>