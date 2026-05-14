<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="mclient_list.aspx.cs" Inherits="mclient_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>


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

        .btn-xs {
            line-height: 1.0;
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

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
    </style>
    <style>
        .modal {
            /*top: 50% !important;*/
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
    </style>
    <div class="panel panel-inverse">
        <div class="panel-heading">
            <div class="panel-heading-btn pull-left">
                <a href="#" class="btn btn-info btn-xs" id="lnklist" data-toggle="modal" data-target="#exampleModalCenter">Create New&nbsp;<i class="fa fa-plus"></i></a>
            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>
            <h4 class="panel-title text-center">Clients</h4>
        </div>
        <div class="panel-body">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <div class="col-md-12 ml-auto mr-auto">
                        <div class="clearfix form-group">

                            <div class="col-md-2">
                                <label for="form-1-3" class="control-label">From Date</label>
                                <div class="timepicker-input input-group">
                                    <asp:TextBox ID="txttLastPurchase" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="txttLastPurchase" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                                    <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server" TargetControlID="txttLastPurchase"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txttLastPurchase" ValidationGroup="A"
                                        Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <label for="form-1-3" class="control-label">To Date</label>
                                <div class="timepicker-input input-group">
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
                                <input type="button" id="btnsearch" class="btn btn-primary form-control mt-2" style="background-color: #004080" title="Search" value="Search" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class=" col-md-12 text-center">
                <br />

                <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>

                <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />

                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF" />
                <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false" />
                <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />

            </div>

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
                    <h5 class="modal-title" id="exampleModalLongTitle">Update Clients</h5>
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
                                            <label for="form-1-3" class="col-md-2 control-label">Client Code</label>
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
                                            <label for="form-1-3" class="col-md-2 control-label">PAN No </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtPanNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                             <label for="form-1-3" class="col-md-2 control-label">VAT </label>
                                            <div class="col-md-2">
                                                <asp:TextBox ID="txtGstNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>




                                        <div class="form-group row">

                                            <label for="form-1-3" class="col-md-2 control-label">Authorized Person</label>
                                            <div class="col-md-4">
                                                <asp:TextBox ID="txtAuthorizedPerson" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>

                                            <label for="form-1-3" class="col-md-2 control-label">Credit Limit</label>
                                            <div class="col-md-4 nopad">
                                                <asp:TextBox ID="txtCreditLimit" CssClass="form-control full-wdth" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="REV18" runat="server" ControlToValidate="txtCreditLimit"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE18" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCreditLimit"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                        </div>


                                        <div class="form-group row">
                                           <%-- <label for="form-1-3" class="col-md-1 control-label">CGST</label>--%>
                                            <div class="col-md-3 nopad" style="display: none;">
                                                <asp:TextBox ID="txtCGST" CssClass="form-control full-wdth" runat="server"></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCGST"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCGST"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>

                                            <%--<label for="form-1-3" class="col-md-1 control-label">SGST</label>--%>
                                            <div class="col-md-3 nopad full-wdth" style="display: none;">
                                                <asp:TextBox ID="txtSGST" CssClass="form-control" runat="server"></asp:TextBox>

                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSGST"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSGST"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>

                                            </div>
                                            <%--<label for="form-1-3" class="col-md-1 control-label">IGST</label>--%>
                                            <div class="col-md-3 nopad full-wdth" style="display: none;">
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
                                    <img src="download.jpg" style="border: 1px dashed; width: 65%; height: 145px; text-align: center; display: block; margin-left: auto; margin-right: auto;" />
                                    <div class="text-center center-block">
                                        <button class="btn btn-primary" style="background: #164e7f;">Browse</button>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-7 control-label">
                                                <h3>Client Billing Information</h3>
                                            </label>
                                            <div class="col-md-5">
                                                &nbsp;
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Address</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="multiline" Columns="50" Rows="5" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Country</label>
                                            <div class="col-md-10">
                                                <asp:DropDownList ID="ddlCountryID" runat="Server" CssClass="form-control"></asp:DropDownList>
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
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Pin Code</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtPincode" CssClass="form-control" runat="server"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPincode"
                                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtPincode"
                                                    ValidChars=".-">
                                                </AjaxToolKit:FilteredTextBoxExtender>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Phone</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtContactNo" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Email</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtEmailID" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Website</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtWebsite" CssClass="form-control" runat="server"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Longitude</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtlongitude" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Latitude</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtlatitude" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-horizontal mrg-top-40 pdd-right-30 ng-pristine ng-valid">
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-7 control-label">
                                                <h3>Vendor Billing Information</h3>
                                            </label>
                                            <div class="col-md-5">
                                                &nbsp;
                                            </div>
                                        </div>

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
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Pin Code</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvendorpincode" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Phone</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvendorphone" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Email</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvendoremail" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Website</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Longitude</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvedorlongitiude" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label for="form-1-3" class="col-md-2 control-label">Latitude</label>
                                            <div class="col-md-10">
                                                <asp:TextBox ID="txtvendorlatitude" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer" style="background: #164e7f; color: #fff;">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal" id="btnclose">Close</button>
                    <button type="button" class="btn btn-primary" id="btnadd">Add</button>
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
            $("#btnsearch").on("click", function () {

                loaddata();
            });

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
                        Pincode: $("#ctl00_ContentPlaceHolder1_txtPincode").val(),
                        AuthorisedPerson: $("#ctl00_ContentPlaceHolder1_txtAuthorizedPerson").val(),
                        ContactNo: $("#ctl00_ContentPlaceHolder1_txtContactNo").val(),
                        Email: $("#ctl00_ContentPlaceHolder1_txtEmailID").val(),
                        Website: $("#ctl00_ContentPlaceHolder1_txtWebsite").val(),
                        Creditlimit: $("#ctl00_ContentPlaceHolder1_txtCreditLimit").val(),
                        SGST: $("#ctl00_ContentPlaceHolder1_txtSGST").val(),
                        CGST: $("#ctl00_ContentPlaceHolder1_txtCGST").val(),
                        IGST: $("#ctl00_ContentPlaceHolder1_txtIGST").val(),
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
                        url: '<%=ResolveUrl("mclient_list.aspx/AddClient") %>',
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
                    url: '<%=ResolveUrl("mclient_list.aspx/DeleteClient") %>',
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
                    url: '<%=ResolveUrl("mclient_list.aspx/UpdateClient") %>',
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
            $("#ctl00_ContentPlaceHolder1_txtvendoraddress").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorcountryid").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorstate").val(''),
            $("#ctl00_ContentPlaceHolder1_ddlvendorcity").val(''),
            $("#ctl00_ContentPlaceHolder1_txtvendorpincode").val(''),
            $("#ctl00_ContentPlaceHolder1_txtvendorphone").val(''),
            $("#ctl00_ContentPlaceHolder1_txtvendoremail").val(''),
            $("#ctl00_ContentPlaceHolder1_txtvedorlongitiude").val(''),
            $("#ctl00_ContentPlaceHolder1_txtvendorlatitude").val(''),
            $("#ctl00_ContentPlaceHolder1_txtlongitude").val(''),
            $("#ctl00_ContentPlaceHolder1_txtlatitude").val('')

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
            var fromdate = $("#ctl00_ContentPlaceHolder1_txttLastPurchase").val();
            var todate = $("#ctl00_ContentPlaceHolder1_txttLastOrder").val();
            $.ajax({
                url: '<%=ResolveUrl("mclient_list.aspx/loaddata") %>',
                type: "post",
                data: JSON.stringify({ fromdate: fromdate, todate: todate }),
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
