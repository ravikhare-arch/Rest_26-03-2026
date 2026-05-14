<%@ Page Title="Chart Of Accounts" Language="C#" MasterPageFile="~/pagecontent.master" AutoEventWireup="true" CodeFile="tchartof_account_Test.aspx.cs" Inherits="Transcation_chartof_account_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <link href="../css/customize-model.css" rel="stylesheet" />
    <link href="../css/CustomFinance.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    
    <div class="panel panel-inverse">

        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;
             <i class="fa fa-plus"></i></a>
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Chart Of Accounts </h4>




        </div>
        <div class="panel-body">

            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
            <!--create/edit Modal popup -->

            <div class="modal fade" id="exampleModalCenter"  role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Account Ledger</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">

                            <div class="pdd-horizon-15 pdd-vertical-20">

                                <div class="card-block">
                                    <div class="row">
                                        <div class="col-md-9 ml-auto mr-auto">
                                            <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Name</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtname" CssClass="form-control" runat="server"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Code</label>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtcode" CssClass="form-control" runat="server"></asp:TextBox>

                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Under Group</label>
                                                    <div class="col-md-8">
                                                        <%--<asp:TextBox ID="txtundergroup" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                        <select class="form-control js-example-placeh older-single" runat="server"  id="cog" name="cog">
                                                            <option>Select Group</option>
                                                           
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Nature</label>
                                                    <div class="col-md-8">
                                                        <asp:Label ID="txtNatureType" CssClass="form-control" runat="server"></asp:Label>
                                                        <asp:HiddenField  id="hdnNatureId"  runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <label for="form-1-3" class="col-md-4 control-label">Type</label>
                                                    <div class="col-md-8">
                                                        <%--<asp:TextBox ID="txtnature" CssClass="form-control" runat="server"></asp:TextBox>--%>
                                                         <select class="form-control" runat="server"  id="ddlAccountCategory" name="ddlAccountCategory">
                                                            <option>Select Account Category</option>
                                                        </select>
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
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnclose">Close</button>
                                <button type="button" class="btn btn-primary" id="btnadd" validationgroup="A">Add</button>
                                <button type="button" class="btn btn-primary" id="btnupdate">Update</button>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
    <!--Delete Modal popup -->
    <div class="modal fade" id="deleteModalCenter"  role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Account Ledger</h5>
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
                        Name: $("#<%=txtname.ClientID %>").val(),
                        Code: $("#<%=txtcode.ClientID %>").val(),
                        AccountGroupID: $("#<%=cog.ClientID %>").val(),
                        Type: $("#<%=ddlAccountCategory.ClientID %>").val(),
                        Nature: $("#<%=hdnNatureId.ClientID %>").val(),

                    }

                    $.ajax({
                        url: '<%=ResolveUrl("tchartof_account_Test.aspx/addledger") %>',
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
                 var id = $(this).closest('tr').find('td:eq(7)').text();
                 $("#accountledgerid").val(id);
                 $("#deletebutton").show();


             });

             // // end

             // // //delete the agent
             $(document.body).on("click", "#deletebutton", function () {
                 var subagentid = $("#accountledgerid").val();
                 $.ajax({
                     type: "POST",
                     url: '<%=ResolveUrl("tchartof_account_Test.aspx/DeleteLedger") %>',
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

                 debugger;
                 $('#lbelupdatesucess').hide();

                 $("#lbelsucess").hide();
                 var tr = $(this).closest('tr td');
                 var id = $(this).closest('tr').find('td:eq(7)').text();
                 $("#accountledgerid").val(id);

                

                

                 $("#btnadd").css("display", "none");
                 $("#ctl00_ContentPlaceHolder1_txtname").val($(this).closest('tr').find('td:eq(1)').text());
                 $("#ctl00_ContentPlaceHolder1_txtcode").val($(this).closest('tr').find('td:eq(2)').text());
                 var gName=$(this).closest('tr').find('td:eq(3)').text();
                 loadChartofAccGroup(gName);
               //  $("#<%=cog.ClientID %>").val($(this).closest('tr').find('td:eq(3)').text());
                 $("#ctl00_ContentPlaceHolder1_txttype").val($(this).closest('tr').find('td:eq(4)').text());

                 var accountCategoryName = $(this).closest('tr').find('td:eq(4)').text();


                 loadAccountCategory(accountCategoryName);
                         


                 $('#btnupdate').show();

             });


             // // // update code start
             $(document.body).on("click", "#btnupdate", function () {


                    var obj = {
                     Name: $("#<%=txtname.ClientID %>").val(),
                     Code: $("#<%=txtcode.ClientID %>").val(),
                     AccountGroupID: $("#<%=cog.ClientID %>").val(),
                     Type: $("#<%=ddlAccountCategory.ClientID %>").val(),
                     Nature: $("#<%=hdnNatureId.ClientID %>").val(),
                     AccountLedgerID: $("#accountledgerid").val(),

                 }

                 $.ajax({
                     url: '<%=ResolveUrl("tchartof_account_Test.aspx/updateagent") %>',
                     data: JSON.stringify({ list: obj }),
                     type: "post",
                     contentType: "application/json;charset=utf-8",
                     dataType: "json",
                     success: function (data) {
                         if (data.d == "1") {
                             alert("Updated Successfully..!");
                             loaddata();
                             $('#btnupdate').hide();
                             $('#lbelupdatesucess').hide();
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
                
                 loadChartofAccGroup();
                 loadAccountCategory();


             });
             // // // end
         });
         function cleardata() {

             $("#ctl00_ContentPlaceHolder1_txtname").val(''),
             $("#ctl00_ContentPlaceHolder1_txtcode").val(''),
             $("#ctl00_ContentPlaceHolder1_txtundergroup").val(''),
             $("#ctl00_ContentPlaceHolder1_txttype").val(''),
             $("#ctl00_ContentPlaceHolder1_txtnature").val('')
         }

         function validatedata() {
             var ledgername = document.getElementById("<%=txtname.ClientID %>").value;
             var ledgercode = document.getElementById("<%=txtcode.ClientID %>").value;
             <%--var undergroup = document.getElementById("<%=txtundergroup.ClientID %>").value;--%>
             var undergroup = document.getElementById("<%=cog.ClientID %>").selectedIndex;
             var valnature = document.getElementById("<%=hdnNatureId.ClientID %>").value;
             var valtype = document.getElementById("<%=ddlAccountCategory.ClientID %>").selectedIndex;

             var validation = true;
             if (ledgername == "" || ledgername == "0") {
                 validation = false;
             }
             if (ledgercode == "" || ledgercode == "0") {
                 validation = false;
             }
             if (undergroup == "" || undergroup == "0") {
                 validation = false;
             }
             if (valtype == "" || valtype == "0") {
                 validation = false;
             }
             if (valnature == "" || valnature == "0") {
                 validation = false;
             }
             if (!validation) {
                 $("#lblrequirefield").show();
             }
             return validation;
         }

        function loadChartofAccGroup(gName) {
            $('#<%=cog.ClientID%> option:not(:first)').remove();
             $.ajax({
                 url: '<%=ResolveUrl("tchartof_account_Test.aspx/GetGroup") %>',
                 //data: JSON.stringify({ list: obj }),
                 type: "post",
                 contentType: "application/json;charset=utf-8",
                 dataType: "json",
                 success: function (data) {

                     $.each(data.d, function (data, value) {
                        
                         $("#<%=cog.ClientID%>").append($("<option></option>").val(value.GroupId).html(value.GroupName));
                     })

                     if (gName != 'undefined' || gName != '') {
                         $('#<%=cog.ClientID%> option').map(function () {
                             if ($(this).text() == gName) return this;
                         }).attr('selected', 'selected');


                         var groupId = document.getElementById("<%=cog.ClientID %>").selectedIndex;

                         if (groupId>0)
                         setNatureType(groupId);
                         
                     }
                        

                 },
                 error: function (data) {
                     alert(data.d);
                 }
             });
         }

        function loadAccountCategory(accountName) {
            $('#<%=ddlAccountCategory.ClientID%> option:not(:first)').remove();
             $.ajax({
                 url: '<%=ResolveUrl("tchartof_account_Test.aspx/GetAccountCategory") %>',
                 //data: JSON.stringify({ list: obj }),
                 type: "post",
                 contentType: "application/json;charset=utf-8",
                 dataType: "json",
                 success: function (data) {

                     $.each(data.d, function (data, value) {
                  
                         $("#<%=ddlAccountCategory.ClientID%>").append($("<option></option>").val(value.CategoryId).html(value.CategoryName));
                     })

                    
                     if (accountName != 'undefined' || accountName != '')
                         $('#<%=ddlAccountCategory.ClientID %> option').map(function () {
                             if ($(this).text() == accountName) return this;
                         }).attr('selected', 'selected');
                 },
                 error: function (data) {
                     alert(data.d);
                 }
             });
         }

         function loaddata() {

             $.ajax({
                 url: '<%=ResolveUrl("tchartof_account_Test.aspx/loaddata") %>',
                 type: "post",
                 contentType: "application/json;charset=utf-8",
                 dataType: "json",
                 success: function (mainlist) {
                     var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>Name</td><td>Code</td><td>Under Group</td><td>Type</td><td>Nature</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>Account LedgerID</td></tr></thead><tbody>";
                     var vcount = 0;
                     for (i = 0; i < mainlist.d.maccountledgerobjlist.length; i++) {
                         //html += '<tr data-name>';
                         vcount = vcount + 1;
                         html += '<tr>';
                         html += '<td >' + vcount + '</td>';
                         html += '<td >' + mainlist.d.maccountledgerobjlist[i].Name + '</td>';
                         html += '<td >' + mainlist.d.maccountledgerobjlist[i].Code + '</td>';
                         html += '<td >' + mainlist.d.maccountledgerobjlist[i].AccountGroupID + '</td>';
                         html += '<td >' + mainlist.d.maccountledgerobjlist[i].Type + '</td>';
                         html += '<td >' + mainlist.d.maccountledgerobjlist[i].Nature + '</td>';
                         html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" data-toggle="modal" data-target="#exampleModalCenter"></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                         html += '<td style="display:none" >' + mainlist.d.maccountledgerobjlist[i].AccountLedgerID + '</td>';
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
                             searchPlaceholder: "Name/Code"
                         },

                     });

                 },
                 error: function (data) {
                     alert(data.d);
                 }
             });
         }

       
        $("#<%=cog.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });

        $("#<%=ddlAccountCategory.ClientID%>").select2({
            dropdownParent: $('#exampleModalCenter')
        });
        


        $("#<%=cog.ClientID%>").select2().on("change", function (e) {
            var groupId = this.selectedIndex;
            setNatureType(groupId);
           
        })

     
        function setNatureType(groupId)
        {
            $.ajax({
                url: '<%=ResolveUrl("tchartof_account_Test.aspx/GetAccountFamily") %>',
                data: JSON.stringify({ subAccountID: groupId }),
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (data) {

                    document.getElementById("<%=txtNatureType.ClientID %>").innerHTML = data.d.FamilyName;
                    //$("<%=txtNatureType.ClientID %>").html(data.d.FamilyName);
                    document.getElementById("<%=hdnNatureId.ClientID %>").value = data.d.FamilyId;
                    //$("<%=hdnNatureId.ClientID %>").val(data.d.FamilyId);

                },
                error: function (data) {
                    alert(data.d);
                }
            });
        }
    </script>


</asp:Content>
