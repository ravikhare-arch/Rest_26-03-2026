<%@ Page Title="Chart Of Accounts" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="tchartof_account.aspx.cs" Inherits="Transcation_chartof_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server" style="display:none"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- <p>
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
    </p>--%>

    <!-- begin row -->
    <div class="row">
        <!-- begin col-12 -->
        <div class="col-lg-12">
            <!-- begin panel -->
            <div class="panel panel-inverse">
                <!-- begin panel-heading -->
                <div class="panel-heading">
                    <div class="panel-heading-btn pull-left">
                        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                    </div>
                    <div class="panel-heading-btn">
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                        <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                    </div>

                    <h4 class="panel-title text-center">Chart Of Accounts </h4>




                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel class="tbl" ID="tblmain" runat="server">
                        <div class="form-group row m-b-0">

                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Code * :</label>
                                <asp:TextBox ID="txtCode" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtCode" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Account Type :</label>
                                <asp:DropDownList ID="ddlAccountTypeID" runat="server" Width="100%" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>

                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">First Name * :</label>
                                <asp:TextBox ID="txtFirstName" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Middle Name :</label>
                                <asp:TextBox ID="txtMidName" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Last Name * :</label>
                                <asp:TextBox ID="txtLastName" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Edit Allow/ Not Allow :</label>
                                <asp:DropDownList ID="ddlChangeAllow" runat="server" Width="100%">

                                    <asp:ListItem Text="Change Allow" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Change Not Allow" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row m-b-0">

                            <%-- <div class="col-md-3 col-sm-2">
                                <label class="col-form-label" for="email">Family Name * :</label>
                                <asp:TextBox ID="txtFamilyName" runat="server" Width="100%"></asp:TextBox>
                            </div>--%>
                            <div class="col-md-6 col-sm-2">
                                <div class="form-group row m-b-0">
                                    <div class="col-md-4 col-sm-2">
                                        <label class="col-form-label" for="email">Address :</label>
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="SingleLine" Width="100%"></asp:TextBox>
                                    </div>

                                    <div class="col-md-4 col-sm-2">
                                        <label class="col-form-label" for="email">Phone 1</label>
                                        <asp:TextBox ID="txtPhoneNo1" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4 col-sm-2">
                                        <label class="col-form-label" for="email">Phone 2</label>
                                        <asp:TextBox ID="txtPhoneNo2" runat="server" Width="100%"></asp:TextBox>
                                    </div>

                                </div>
                            </div>
                            <div class="col-md-6 col-sm-2">
                                <div class="form-group row m-b-0">
                                    <div class="col-md-3 col-sm-2">
                                        <label class="col-form-label" for="email">Mobile No. :</label>
                                        <asp:TextBox ID="txtMobileNo" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-2">
                                        <label class="col-form-label" for="email">Fax No.  :</label>
                                        <asp:TextBox ID="txtFaxNo" runat="server" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label" for="email">Email ID  :</label>
                                        <asp:TextBox ID="txtEmailID" runat="server" Width="100%"></asp:TextBox>
                                    </div>

                                    <div class="col-md-3 col-sm-3">
                                        <label class="col-form-label" for="email">Website  :</label>
                                        <asp:TextBox ID="txtWebsite" runat="server" Width="100%"></asp:TextBox>
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                        </div>
                        <div class="form-group row m-b-10">
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Country   :</label>
                                <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="js-example-placeholder-single" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">City   :</label>
                                <asp:DropDownList ID="ddlCityID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">GST No. :</label>
                                <asp:TextBox ID="txtGstNo" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Sales Prsn</label>
                                <asp:DropDownList ID="ddlSalesPersonID" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                            <%--<div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Account Category   :</label>
                                <asp:DropDownList ID="ddlAccountCategoryID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV17" runat="server" ControlToValidate="ddlAccountCategoryID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>--%>

                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Credit Limit   :</label>
                                <asp:TextBox ID="txtCreditLimit" runat="server" Width="100%"></asp:TextBox><asp:RegularExpressionValidator ID="REV18" runat="server" ControlToValidate="txtCreditLimit"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE18" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCreditLimit"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Remarks  :</label>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="SingleLine" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row m-b-0">
                            <div class="col-md-12 col-sm-12" style="text-align: center;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" />
                                <AjaxToolKit:ConfirmButtonExtender ID="btnDelete_confirmbuttonextender" runat="server"
                                    DisplayModalPopupID="btnDelete_modalpopupextender" TargetControlID="btnDelete" />
                                <AjaxToolKit:ModalPopupExtender ID="btnDelete_modalpopupextender" runat="server"
                                    BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" OkControlID="ButtonOk"
                                    PopupControlID="PNL" TargetControlID="btnDelete" />
                                <br />
                                <asp:Panel ID="PNL" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                    Are you sure you want to delete?
 <br />
                                    <br />
                                    <div style="text-align: right;">
                                        <asp:Button ID="ButtonOk" runat="server" Text="OK" />
                                        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
                                    </div>
                                </asp:Panel>

                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">

                        <div class="form-group row m-b-20">
                            <div class="col-md-4 col-sm-3">
                                <label class="col-form-label" for="email">Page Size   :</label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" CssClass="form-control">
                                    <asp:ListItem Text="Select Page Size" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                    <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                    <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-4 col-sm-3">
                                <label class="col-form-label" for="email">Account Name   :</label><br />
                                <asp:DropDownList ID="ddlSChartAcc" runat="server" CssClass="form-control js-example-placeholder-single">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3 col-sm-2 m-t-30">
                                <%--<label class="col-form-label" for="email">Search   :</label>--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div class="form-group row m-b-20">
                            <div class="col-md-12 col-sm-12">
                                <asp:GridView ID="GridView1" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nChartOfAccountID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nChartOfAccountID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nChartOfAccountID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sCode" HeaderText="Code" />

                                        <asp:BoundField DataField="sAccountTitle" HeaderText="Account Title" />
                                        <asp:BoundField DataField="sSubAccount" HeaderText="Account Type" />
                                        <%-- <asp:BoundField DataField="sAccountCategory" HeaderText="Account Category" />
                                <asp:BoundField DataField="sRemarks" HeaderText="Remarks" />--%>
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btngdDelete" runat="server" OnClick="btngdDelete_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                                </asp:LinkButton>
                                                <AjaxToolKit:ConfirmButtonExtender ID="btngdDelete_confirmbuttonextender" runat="server"
                                                    DisplayModalPopupID="btngdDelete_modalpopupextender" TargetControlID="btngdDelete" />
                                                <AjaxToolKit:ModalPopupExtender ID="btngdDelete_modalpopupextender" runat="server"
                                                    BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel0" OkControlID="ButtonOk0"
                                                    PopupControlID="PNL0" TargetControlID="btngdDelete" />
                                                <br />
                                                <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: #348fe2; border-width: 1px; border-color: Black; border-style: solid; padding: 20px;">
                                                    Are you sure you want to delete?
 <br />
                                                    <br />
                                                    <div style="text-align: right;">
                                                        <asp:Button ID="ButtonOk0" runat="server" Text="OK" />
                                                        <asp:Button ID="ButtonCancel0" runat="server" Text="Cancel" />
                                                    </div>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </asp:Panel>
                </div>
            </div>


        </div>
    </div>
    <!-- end panel-body -->





</asp:Content>
