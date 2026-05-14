<%@ Page Title="Item Category" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="mitemcategory_list.aspx.cs" Inherits="tbankreco_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <style>
        /*div.dataTables_wrapper {
        width:800px;
        margin: 0 auto;
    }*/
        .pagination > li > a, .pagination > li > span {
            padding: 0px !important;
        }
    </style>
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
            box-shadow: 0 4px 3px 0;
        }

        .destination {
            border-right: 1px solid #0098da;
        }
    </style>
    <style>
        .modal {
            top: 50% !important;
            left: 22% !important;
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

    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Item Category </h4>
        </div>


        <div class="panel-body">



            <div class="col-md-10 col-md-push-2">


                <div class=" col-md-6 mt-10">
                    <br />
                    <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>

                    <asp:Button ID="btnReconcile" runat="server" Text="Reconcile" CssClass="btn btn-primary" ValidationGroup="A" />
                    <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Export To Excel" />
                    <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF" />
                    <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false" />
                    <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />

                </div>
            </div>
            <div class="form-group row m-b-15">

                <div class="col-md-12 col-sm-6">
                    <div id="divagentlist" class="display nowrap mytables"></div>
                </div>

            </div>
        </div>


            <div class="modal fade" id="deleteModalCenter" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content" style="background: #C0C0C0">
                        <div class="modal-header">
                            <h5 class="modal-title" id="delModalLongTitle" style="color: white">Airlines</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <label style="color: black" id="lbldelete">Are you sure you want to delete?</label>
                            <label style="color: black; display: none;" id="lblsucess">Deleted Successfully..!</label>
                            <label style="color: white; display: none" id="lblinactive">Are you sure you want to De-Active User?</label>
                            <label style="color: white; display: none;" id="lblinactivesucess">Your Account has been successfully De-Activated?</label>
                            <label id="accountledgerid" style="display: none"></label>
                            <label id="journalvoucherdetid" style="display: none"></label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary" id="deletebutton">Delete</button>
                            <button type="button" class="btn btn-primary" id="inactivebutton">De-Activate</button>

                        </div>
                    </div>
                </div>
            </div>


    </div>
    <script type="text/javascript">


        $(document.body).ready(function () {
            loaddata();

            $(document.body).on("click", ".editbtn", function () {
                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(3)').text();
                $("#accountledgerid").val(id);
                var datastring = 'ID=' + id;
                window.location.href = "../Masters/mitem_category.aspx?" + datastring + "";
            });

            $(document.body).on("click", ".deletebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(3)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").show();
                $("#inactivebutton").hide();



            });

            $(document.body).on("click", "#deletebutton", function () {
                var subagentid = $("#accountledgerid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("mitemcategory_list.aspx/DeleteVoucher") %>',
                    data: JSON.stringify({ AccountLedgerID: subagentid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            $("#lblsucess").css("display", "block");
                            $("#lbldelete").hide();
                            loaddata();
                            $("#deletebutton").hide();
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
        });


        function loaddata() {

            $.ajax({
                url: '<%=ResolveUrl("mitemcategory_list.aspx/loaddata") %>',
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Category Name</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>Module ID</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.mpagemasterobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.mpagemasterobjlist[i].CategoryName + '</td>';
                        html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" data-toggle="modal" data-target="#exampleModalCenter"></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.mpagemasterobjlist[i].CategoryID + '</td>';
                        html += '</tr>';
                    }
                    html += "</tbody><tfoot></tfoot></table>";
                    $("#divagentlist").html(html);

                    var table = $("#tblagentlist").DataTable({
                        "aLengthMenu": [[10, 15, 25, 50, 75, -1], [10, 15, 25, 50, 75, "All"]],
                        "iDisplayLength": 10,

                        //"bRetrieve": true,
                        //"retrieve": true,
                        //"orderCellsTop": true,

                        //"bLengthChange": false,

                        //"scrollX": true,

                        //"scrollCollapse": true,

                        //"paging": true,

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


</asp:Content>
