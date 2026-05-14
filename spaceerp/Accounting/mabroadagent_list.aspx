<%@ Page Title="Abroad Agent" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="mabroadagent_list.aspx.cs" Inherits="mabroadagent_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />    
   
<link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />
       
   
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>



</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <asp:Label ID="lblmsg" runat="server"></asp:Label>
    
    
    <link href="../css/custom-modal.css" rel="stylesheet" />
    
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">
                 <a href="#" class="btn btn-info btn-xs" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>
            <h4 class="panel-title text-center">Abroad Agent</h4>
        </div>
        <div class="panel-body">
            
            <div>
                <label id="lblsucessclick" style="display: none" data-toggle="modal" data-target="#successModal"></label>
                <label id="lblvalidation" style="display: none"></label>
                <p id="demo"></p>
                <div id="divagentlist"></div>
            </div>
        </div>
    </div>
    <!--create/edit Modal popup -->

    <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header" style="background: #164e7f; color: #fff;">
                    <h5 class="modal-title" id="exampleModalLongTitle">Update Abroad Agent</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="pdd-horizon-15 pdd-vertical-20">
                        <div class="card-block">
                            <div class="row">
                                <div class="col-md-9">
                                    <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                        <%--<div class="form-group row">
                                            <label class="col-form-label" for="email">Joining Date * :</label>
                                            <div class="col-md-4">
                                            <asp:TextBox ID="txtdtJoiningDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtJoiningDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                                PopupButtonID="txtdtJoiningDate" TargetControlID="txtdtJoiningDate" PopupPosition="BottomLeft" />
                                            <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtJoiningDate"
                                                Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                            <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtJoiningDate" ValidationGroup="A"
                                                Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                            </asp:RegularExpressionValidator>

                                        </div>--%>


                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Supplier Code</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtCode" CssClass="form-control" runat="server"></asp:TextBox>

                                            </div>
                                            <label for="form-1-3" class="col-md-2 control-label">Agency Name</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtAgencyName" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label for="form-1-3" class="col-md-2 control-label">IATA No</label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtIataNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">License No </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtLicenseNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label for="form-1-3" class="col-md-2 control-label">GST No </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            <label for="form-1-3" class="col-md-2 control-label">PAN No </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>




                                        <div class="form-group row">

                                            <label for="form-1-3" class="col-md-2 control-label">Authorized Person</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtAuthorizedPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                            </div>
                                        <div style="display:none">
                                                <label for="form-1-3" class="col-md-2 control-label">Credit Limit</label>
                                                <div class="col-md-4 nopad">
                                                    <asp:TextBox ID="txtCreditLimit" CssClass="form-control full-wdth" runat="server"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="REV18" runat="server" ControlToValidate="txtCreditLimit"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FTBE18" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCreditLimit"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>
                                                </div>
                                        </div>


                                        <div class="form-group row" style="display:none">
                                            
                                                <label for="form-1-3" class="col-md-1 control-label">CGST</label>
                                                <div class="col-md-3 nopad">
                                                    <asp:TextBox ID="txtCGST" CssClass="form-control full-wdth" runat="server"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCGST"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCGST"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>

                                                </div>                                            
                                                <label for="form-1-3" class="col-md-1 control-label">SGST</label>
                                                <div class="col-md-3 nopad full-wdth">
                                                    <asp:TextBox ID="txtSGST" CssClass="form-control" runat="server"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSGST"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                        ></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSGST"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>

                                                </div>
                                                <label for="form-1-3" class="col-md-1 control-label">IGST</label>
                                                <div class="col-md-3 nopad full-wdth">
                                                    <asp:TextBox ID="txtIGST" CssClass="form-control" runat="server"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtIGST"
                                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                                    <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                        Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtIGST"
                                                        ValidChars=".-">
                                                    </AjaxToolKit:FilteredTextBoxExtender>

                                                </div>
                                            
                                        </div>

                                        <div class="form-group row" id="divpassword">

                                            <label id="lbelsucess" style="color: forestgreen; display: none;">Successfully Added..!</label>
                                            <label id="lbelupdatesucess" style="color: forestgreen; display: none;">Successfully Updated..!</label>
                                            <label id="lblrequirefield" style="color: darkred; display: none;">Enter Required Fields..!</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <img src="download.jpg" style="border: 1px dashed;width: 65%;height: 145px;text-align: center;display: block;margin-left: auto;margin-right: auto;" />
                                    <div class="text-center center-block">
                                        <button class="btn btn-primary btn-browse" style="background: #164e7f;">Browse</button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="display:none;">
                                    <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                        
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Address</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="multiline" Columns="50" Rows="5" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Country</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlCountryID" runat="Server" CssClass="js-example-placeholder-single"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">State</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlState" runat="Server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">City</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlCityID" runat="Server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                        

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Address</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvendoraddress" runat="server" TextMode="multiline" Columns="50" Rows="5" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Country</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlvendorcountryid" runat="Server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">State</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlvendorstate" runat="Server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">City</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlvendorcity" runat="Server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="background: #164e7f; color: #fff;">
                    <button type="button" class="btn btn-primary" data-dismiss="modal" id="btnclose">Close</button>
                    <button type="button" class="btn btn-primary" id="btnadd" >Add</button>
                    <button type="button" class="btn btn-primary" id="btnupdate">Update</button>
                </div>
            </div>
        </div>  
    </div>


    <!--Delete Modal popup -->
    <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
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
                    <label id="CAccountID" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Delete</button>
                    <button type="button" class="btn btn-primary" id="inactivebutton">De-Activate</button>

                </div>
            </div>
        </div>
    </div>







    <script type="text/javascript">


        $(document.body).ready(function () {
            loaddata();

            $("#btnadd").on("click", function () {

                if (validatedata()) {
                    var obj = {
                        Code: $("#ctl00_ContentPlaceHolder1_txtCode").val(),
                        AgencyName: $("#ctl00_ContentPlaceHolder1_txtAgencyName").val(),
                        IATANo: $("#ctl00_ContentPlaceHolder1_txtIataNo").val(),
                        LicenseNo: $("#ctl00_ContentPlaceHolder1_txtLicenseNo").val(),
                        GSTNo: $("#ctl00_ContentPlaceHolder1_txtGstNo").val(),
                        PANno: $("#ctl00_ContentPlaceHolder1_txtPanNo").val(),
                        Address: $("#ctl00_ContentPlaceHolder1_txtAddress").val(),
                        CountryID: $("#ctl00_ContentPlaceHolder1_ddlCountryID").val(),
                        StateID: $("#ctl00_ContentPlaceHolder1_ddlState").val(),
                        CityID: $("#ctl00_ContentPlaceHolder1_ddlCityID").val(),
                        AuthorisedPerson: $("#ctl00_ContentPlaceHolder1_txtAuthorizedPerson").val(),
                        VendorAddress: $("#ctl00_ContentPlaceHolder1_txtvendoraddress").val(),
                        VendorCountryID: $("#ctl00_ContentPlaceHolder1_ddlvendorcountryid").val(),
                        VendorStateID: $("#ctl00_ContentPlaceHolder1_ddlvendorstate").val(),
                        VendorCityID: $("#ctl00_ContentPlaceHolder1_ddlvendorcity").val(),
                            
                    }

                    $.ajax({
                        url: '<%=ResolveUrl("mabroadagent_list.aspx/AddClient") %>',
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



            $(document.body).on("click", ".deletebtn,.Inactivebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(8)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").show();
                $("#inactivebutton").hide();

            });
            $(document.body).on("click", ".Inactivebtn", function () {

                var tr = $(this).closest('tr td');
                var id = $(this).closest('tr').find('td:eq(8)').text();
                $("#accountledgerid").val(id);
                $("#deletebutton").hide();
                $("#inactivebutton").show();
                $("#lblinactive").css("display", "block");
                $("#lbldelete").hide();

            });

            // // end
            // // //delete the agent
            $(document.body).on("click", "#deletebutton", function () {
                var subagentid = $("#accountledgerid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("mabroadagent_list.aspx/DeleteClient") %>',
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


            // // //delete the agent
            $(document.body).on("click", "#inactivebutton", function () {
                var agencyid = $("#accountledgerid").val();
                $.ajax({
                    type: "POST",
                    url: '<%=ResolveUrl("mclient_list/MarkInactive") %>',
                    data: JSON.stringify({ agencyid: agencyid }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {

                        if (data.d == "1") {
                            $("#lblsucess").css("display", "none");
                            $("#lbldelete").hide();
                            $("#inactivebutton").hide();
                            $("#lblinactive").css("display", "none");
                            $("#lblinactivesucess").css("display", "block");
                            loaddata();
                            $("#deletebutton").hide();
                            // $('#exampleModalCenter').modal('toggle');
                            $("#agentid").val('');
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
                var id = $(this).closest('tr').find('td:eq(8)').text();
                var CAid = $(this).closest('tr').find('td:eq(9)').text();
                $("#accountledgerid").val(id);
                $("#CAccountID").val(CAid);

                $("#btnadd").css("display", "none");
                $("#ctl00_ContentPlaceHolder1_txtCode").val($(this).closest('tr').find('td:eq(1)').text());
                $("#ctl00_ContentPlaceHolder1_txtAgencyName").val($(this).closest('tr').find('td:eq(2)').text());
                $("#ctl00_ContentPlaceHolder1_txtIataNo").val($(this).closest('tr').find('td:eq(3)').text());
                $("#ctl00_ContentPlaceHolder1_txtLicenseNo").val($(this).closest('tr').find('td:eq(4)').text());
                $("#ctl00_ContentPlaceHolder1_txtGstNo").val($(this).closest('tr').find('td:eq(5)').text());
                $("#ctl00_ContentPlaceHolder1_txtPanNo").val($(this).closest('tr').find('td:eq(6)').text());
                $("#ctl00_ContentPlaceHolder1_txtAddress").val($(this).closest('tr').find('td:eq(10)').text());
                $("#ctl00_ContentPlaceHolder1_ddlCountryID").val($(this).closest('tr').find('td:eq(11)').text());
                $("#ctl00_ContentPlaceHolder1_ddlState").val($(this).closest('tr').find('td:eq(12)').text());
                $("#ctl00_ContentPlaceHolder1_ddlCityID").val($(this).closest('tr').find('td:eq(13)').text());
                $("#ctl00_ContentPlaceHolder1_txtPincode").val($(this).closest('tr').find('td:eq(14)').text());
                $("#ctl00_ContentPlaceHolder1_txtAuthorizedPerson").val($(this).closest('tr').find('td:eq(15)').text());
                $("#ctl00_ContentPlaceHolder1_txtContactNo").val($(this).closest('tr').find('td:eq(16)').text());
                $("#ctl00_ContentPlaceHolder1_txtEmailID").val($(this).closest('tr').find('td:eq(17)').text());
                $("#ctl00_ContentPlaceHolder1_txtWebsite").val($(this).closest('tr').find('td:eq(18)').text());
                $("#ctl00_ContentPlaceHolder1_txtCreditLimit").val($(this).closest('tr').find('td:eq(19)').text());
                $("#ctl00_ContentPlaceHolder1_txtSGST").val($(this).closest('tr').find('td:eq(20)').text());
                $("#ctl00_ContentPlaceHolder1_txtCGST").val($(this).closest('tr').find('td:eq(21)').text());
                $("#ctl00_ContentPlaceHolder1_txtIGST").val($(this).closest('tr').find('td:eq(22)').text());
               
                $("#ctl00_ContentPlaceHolder1_txtvendoraddress").val($(this).closest('tr').find('td:eq(23)').text());
                $("#ctl00_ContentPlaceHolder1_ddlvendorcountryid").val($(this).closest('tr').find('td:eq(24)').text());
                $("#ctl00_ContentPlaceHolder1_ddlvendorstate").val($(this).closest('tr').find('td:eq(25)').text());
                $("#ctl00_ContentPlaceHolder1_ddlvendorcity").val($(this).closest('tr').find('td:eq(26)').text());
                $("#ctl00_ContentPlaceHolder1_txtvendorpincode").val($(this).closest('tr').find('td:eq(27)').text());
                $("#ctl00_ContentPlaceHolder1_txtvendorphone").val($(this).closest('tr').find('td:eq(28)').text());
                $("#ctl00_ContentPlaceHolder1_txtvendoremail").val($(this).closest('tr').find('td:eq(29)').text());
                $("#ctl00_ContentPlaceHolder1_txtvedorlongitiude").val($(this).closest('tr').find('td:eq(30)').text());
                $("#ctl00_ContentPlaceHolder1_txtvendorlatitude").val($(this).closest('tr').find('td:eq(31)').text());
                $("#ctl00_ContentPlaceHolder1_txtlongitude").val($(this).closest('tr').find('td:eq(32)').text());
                $("#ctl00_ContentPlaceHolder1_txtlatitude").val($(this).closest('tr').find('td:eq(33)').text());

                $('#btnupdate').show();

            });


            // // // update code start
            $(document.body).on("click", "#btnupdate", function () {
                var obj = {
                    Code: $("#ctl00_ContentPlaceHolder1_txtCode").val(),
                    AgencyName: $("#ctl00_ContentPlaceHolder1_txtAgencyName").val(),
                    IATANo: $("#ctl00_ContentPlaceHolder1_txtIataNo").val(),
                    LicenseNo: $("#ctl00_ContentPlaceHolder1_txtLicenseNo").val(),
                    GSTNo: $("#ctl00_ContentPlaceHolder1_txtGstNo").val(),
                    PANno: $("#ctl00_ContentPlaceHolder1_txtPanNo").val(),
                    Address: $("#ctl00_ContentPlaceHolder1_txtAddress").val(),
                    CountryID: $("#ctl00_ContentPlaceHolder1_ddlCountryID").val(),
                    StateID: $("#ctl00_ContentPlaceHolder1_ddlState").val(),
                    CityID: $("#ctl00_ContentPlaceHolder1_ddlCityID").val(),
                    Pincode: $("#ctl00_ContentPlaceHolder1_txtPincode").val(),
                    AuthorisedPerson: $("#ctl00_ContentPlaceHolder1_txtAuthorizedPerson").val(),
                    ContactNo: $("#ctl00_ContentPlaceHolder1_txtContactNo").val(),
                    Email: $("#ctl00_ContentPlaceHolder1_txtEmailID").val(),
                    Website: $("#ctl00_ContentPlaceHolder1_txtWebsite").val(),
                    Creditlimit: $("#ctl00_ContentPlaceHolder1_txtCreditLimit").val(),
                    SGST: $("#ctl00_ContentPlaceHolder1_txtSGST").val(),
                    CGST: $("#ctl00_ContentPlaceHolder1_txtCGST").val(),
                    IGST: $("#ctl00_ContentPlaceHolder1_txtIGST").val(),
                    ClientID: $("#accountledgerid").val(),
                    CAccountID: $("#CAccountID").val(),
                    VendorAddress: $("#ctl00_ContentPlaceHolder1_txtvendoraddress").val(),
                    VendorCountryID: $("#ctl00_ContentPlaceHolder1_ddlvendorcountryid").val(),
                    VendorStateID: $("#ctl00_ContentPlaceHolder1_ddlvendorstate").val(),
                    VendorCityID: $("#ctl00_ContentPlaceHolder1_ddlvendorcity").val(),
                    VendorPincode: $("#ctl00_ContentPlaceHolder1_txtvendorpincode").val(),
                    VendorContactNo: $("#ctl00_ContentPlaceHolder1_txtvendorphone").val(),
                    VendorEmail: $("#ctl00_ContentPlaceHolder1_txtvendoremail").val(),
                    VendorLongitude: $("#ctl00_ContentPlaceHolder1_txtvedorlongitiude").val(),
                    VendorLatitude: $("#ctl00_ContentPlaceHolder1_txtvendorlatitude").val(),
                    Longitude: $("#ctl00_ContentPlaceHolder1_txtlongitude").val(),
                    Latitude: $("#ctl00_ContentPlaceHolder1_txtlatitude").val(),
                }

                $.ajax({
                    url: '<%=ResolveUrl("mabroadagent_list.aspx/UpdateClient") %>',
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


            });
            // // // end


        });
        function cleardata() {

            $("#ctl00_ContentPlaceHolder1_txtCode").val(''),
            $("#ctl00_ContentPlaceHolder1_txtAgencyName").val(''),
            $("#ctl00_ContentPlaceHolder1_txtIataNo").val(''),
            $("#ctl00_ContentPlaceHolder1_txtLicenseNo").val(''),
            $("#ctl00_ContentPlaceHolder1_txtGstNo").val(''),
            $("#ctl00_ContentPlaceHolder1_txtPanNo").val(''),
            $("#ctl00_ContentPlaceHolder1_txtAddress").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlCountryID").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlState").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlCityID").val(''),
            $("#ctl00_ContentPlaceHolder1_txtPincode").val(''),
            $("#ctl00_ContentPlaceHolder1_txtAuthorizedPerson").val(''),
            $("#ctl00_ContentPlaceHolder1_txtContactNo").val(''),
            $("#ctl00_ContentPlaceHolder1_txtEmailID").val(''),
            $("#ctl00_ContentPlaceHolder1_txtWebsite").val(''),
            $("#ctl00_ContentPlaceHolder1_txtCreditLimit").val(''),
            $("#ctl00_ContentPlaceHolder1_txtSGST").val(''),
            $("#ctl00_ContentPlaceHolder1_txtCGST").val(''),
            $("#ctl00_ContentPlaceHolder1_txtIGST").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorcountryid").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorstate").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorcity").val('')
      

        }

        function validatedata() {
            var Code = document.getElementById("<%=txtCode.ClientID %>").value;
            var Agencyname = document.getElementById("<%=txtAgencyName.ClientID %>").value;



            var validation = true;
            if (Agencyname == "" || Agencyname == "0") {
                validation = false;
            }
            if (Code == "" || Code == "0") {
                //validation = false;
            }

            return validation;
        }





        function loaddata() {

            $.ajax({
                url: '<%=ResolveUrl("mabroadagent_list.aspx/loaddata") %>',
                type: "post",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (mainlist) {
                    var html = "<table id='tblagentlist' class='table table-striped table-bordered' style='width:100%'><thead><tr> <td style='width:2%'>Sr No.</td><td>AIRLINE CODE</td><td>AGENCY NAME</td><td>IATA NO</td><td>LICENSE NO</td><td>GST NO</td><td>PAN NO</td><td style='width:3%'>Edit/Delete</td><td style='display:none'>AirlineID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td><td style='display:none'>CAID</td></tr></thead><tbody>";
                    var vcount = 0;
                    for (i = 0; i < mainlist.d.muserobjlist.length; i++) {
                        //html += '<tr data-name>';
                        vcount = vcount + 1;
                        html += '<tr>';
                        html += '<td >' + vcount + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].Code + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].AgencyName + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].IATANo + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].LicenseNo + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].GSTNo + '</td>';
                        html += '<td >' + mainlist.d.muserobjlist[i].PANno + '</td>';
                        html += '<td >' + '<a href="#" class="editbtn" title="Edit"><i class="glyphicon glyphicon-edit" style="color: green" data-toggle="modal" data-target="#exampleModalCenter"></i></a>&nbsp;&nbsp;&nbsp;<a href="#" class="deletebtn" title="Delete" data-toggle="modal" data-target="#deleteModalCenter"><i class="glyphicon glyphicon-trash" style="color: red"></i></a>' + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].ClientID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].CAccountID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Address + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].CountryID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].StateID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].CityID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Pincode + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].AuthorisedPerson + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].ContactNo + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Email + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Website + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Creditlimit + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].SGST + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].CGST + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].IGST + '</td>';

                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorAddress + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorCountryID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorStateID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorCityID + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorPincode + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorContactNo + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorEmail + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorLongitude + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].VendorLatitude + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Longitude + '</td>';
                        html += '<td style="display:none;" >' + mainlist.d.muserobjlist[i].Latitude + '</td>';
                       
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
                            searchPlaceholder: "Name / Code"
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
