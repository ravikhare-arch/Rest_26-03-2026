<%@ Page Title="NC Master" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="NCMaster.aspx.cs" Inherits="NCMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <style>
        .content-page .content { margin-left: auto; margin-right: auto; display: block; margin-top: 0px; margin-bottom: 0px; padding: 0px; }
        .table { text-align: center !important; border: 1px solid #0098da !important; }
        .table th { background: linear-gradient(90deg, #ff0015 31%, #595959 69%) !important; border: 1px solid white; padding: 5px; color: white !important; text-align:center; }
        .table td { padding: 5px; vertical-align: middle !important; }
        .modal-header { background: #1b82ec; color: #fff; }
        .modal-footer { background: #f5f5f5; }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    <div class="panel panel-inverse" style="margin-top:20px;">
        <div class="panel-heading" style="background:#242a30; color:white; padding:10px 15px;">
            <div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info btn-sm" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>
            </div>
            <h4 class="panel-title text-center" style="margin:0; line-height:30px;">NC Master</h4>
        </div>
        
        <div class="panel-body">
            <div style="margin-top:20px;">
                <div id="divagentlist"></div>
            </div>

            <!-- Create/Edit Modal Popup -->
            <div class="modal fade" id="exampleModalCenter" role="dialog" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-md" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" style="color:white;">&times;</button>
                            <h4 class="modal-title">NC Master Entry</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-md-4 control-label">Order Type <span style="color:red;">*</span></label>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddlordertype" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-4 control-label">NC Name <span style="color:red;">*</span></label>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txttablename" CssClass="form-control" runat="server" placeholder="Enter NC Name"></asp:TextBox>
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

    <!-- Delete Modal Popup -->
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
                        OrderType: $("#<%=ddlordertype.ClientID %>").val()
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
                var orderTypeVal = $(this).closest('tr').find('.td_ordertypeid').text().trim();

                $("#hdn_ncid").val(id);
                $("#<%=txttablename.ClientID %>").val(ncName);
                $("#<%=ddlordertype.ClientID %>").val(orderTypeVal);
            });

            // UPDATE METHOD
            $("#btnupdate").on("click", function () {
                if (validatedata()) {
                    var obj = {
                        AreaName: $("#<%=txttablename.ClientID %>").val(),
                        OrderType: $("#<%=ddlordertype.ClientID %>").val(),
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
            $("#<%=ddlordertype.ClientID %>").val('0');
            $("#hdn_ncid").val('');
            $("#lbelsucess, #lbelupdatesucess, #lblrequirefield").hide();
        }

        function validatedata() {
            var ncname = $("#<%=txttablename.ClientID %>").val().trim();
            var ordertype = $("#<%=ddlordertype.ClientID %>").val();

            if (ncname == "" || ordertype == "0" || ordertype == null) {
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
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'>" +
                        "<thead><tr><th style='width:10%'>Sr No.</th><th>NC Name</th><th>Order Type</th><th style='width:20%'>Action</th>" +
                        "<th style='display:none'>NC_ID</th><th style='display:none'>OrderTypeID</th></tr></thead><tbody>";

                    if (mainlist.d && mainlist.d.mpagemasterobjlist) {
                        for (var i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                            html += '<tr>';
                            html += '<td>' + (i + 1) + '</td>';
                            html += '<td class="td_ncname">' + mainlist.d.mpagemasterobjlist[i].AreaName + '</td>';
                            html += '<td class="td_ordertypename">' + mainlist.d.mpagemasterobjlist[i].OrderTypeName + '</td>';
                            html += '<td>' +
                                '<a href="#" class="editbtn btn btn-xs btn-success" data-toggle="modal" data-target="#exampleModalCenter" style="margin-right:10px;"><i class="glyphicon glyphicon-edit"></i> Edit</a>' +
                                '<a href="#" class="deletebtn btn btn-xs btn-danger" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash"></i> Delete</a>' +
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
                        language: { searchPlaceholder: "Search NC Name..." }
                    });
                },
                error: function (xhr) { alert("Error loading grid data."); }
            });
        }
    </script>
</asp:Content>