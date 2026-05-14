<%@ Page Title="Add Clients" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="mclient_master.aspx.cs" Inherits="Transcation_chartof_account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
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

                    <h4 class="panel-title text-center">Add Clients </h4>




                </div>
                <!-- end panel-heading -->
                <!-- begin panel-body -->
                <div class="panel-body">
                    <asp:Panel class="tbl" ID="tblmain" runat="server">
                        <div class="form-group row m-b-0">
                            <div class="col-md-2 col-sm-2" style="z-index: 99;">
                                <label class="col-form-label" for="email">Joining Date * :</label>
                                <asp:TextBox ID="txtdtJoiningDate" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtJoiningDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="txtdtJoiningDate" TargetControlID="txtdtJoiningDate" PopupPosition="BottomLeft" />
                                <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtJoiningDate"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtJoiningDate" ValidationGroup="A"
                                    Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Client Code * :</label>
                                <asp:TextBox ID="txtCode" runat="server" Width="100%" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV1" runat="server" ControlToValidate="txtCode" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <%--  <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Account Type :</label>
                                <asp:DropDownList ID="ddlAccountTypeID" runat="server" Width="100%" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlAccountTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>--%>

                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Agency Name * :</label>
                                <asp:TextBox ID="txtAgencyName" runat="server" Width="100%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtAgencyName" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">IATA No :</label>
                                <asp:TextBox ID="txtIataNo" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">License No :</label>
                                <asp:TextBox ID="txtLicenseNo" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">GST No :</label>
                                <asp:TextBox ID="txtGstNo" runat="server" Width="100%"></asp:TextBox>
                            </div>

                            <%--<div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Edit Allow/ Not Allow :</label>
                                <asp:DropDownList ID="ddlChangeAllow" runat="server" Width="100%">

                                    <asp:ListItem Text="Change Allow" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Change Not Allow" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <div class="form-group row m-b-0">

                            <%-- <div class="col-md-3 col-sm-2">
                                <label class="col-form-label" for="email">Family Name * :</label>
                                <asp:TextBox ID="txtFamilyName" runat="server" Width="100%"></asp:TextBox>
                            </div>--%>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">PAN No :</label>
                                <asp:TextBox ID="txtPanNo" runat="server" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Address :</label>
                                <asp:TextBox ID="txtAddress" runat="server" TextMode="SingleLine" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Country   :</label>
                                <asp:DropDownList ID="ddlCountryID" runat="server" CssClass="js-example-placeholder-single" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">State    :</label>
                                <asp:DropDownList ID="ddlState" runat="server" CssClass="js-example-placeholder-single" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">City   :</label>
                                <asp:DropDownList ID="ddlCityID" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                            </div>




                        </div>
                        <div class="form-group row m-b-20">
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Pincode</label>
                                <asp:TextBox ID="txtPincode" runat="server" Width="100%"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPincode"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtPincode"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Office Tele</label>
                                <asp:TextBox ID="txtTelephone" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Authorized Person</label>
                                <asp:TextBox ID="txtAuthorizedPerson" runat="server" Width="100%"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-sm-2">
                                <label class="col-form-label" for="email">Contact No :</label>
                                <asp:TextBox ID="txtContactNo" runat="server" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Email ID  :</label>
                                <asp:TextBox ID="txtEmailID" runat="server" Width="100%"></asp:TextBox>
                            </div>

                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Website  :</label>
                                <asp:TextBox ID="txtWebsite" runat="server" Width="100%"></asp:TextBox>
                            </div>


                        </div>
                        <div class="form-group row m-b-20">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">Credit Limit   :</label>
                                <asp:TextBox ID="txtCreditLimit" runat="server" Width="100%"></asp:TextBox><asp:RegularExpressionValidator ID="REV18" runat="server" ControlToValidate="txtCreditLimit"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE18" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCreditLimit"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">CGST   :</label>
                                <asp:TextBox ID="txtCGST" runat="server" Width="100%" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtCGST"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtCGST"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">SGST   :</label>
                                <asp:TextBox ID="txtSGST" runat="server" Width="100%" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtSGST"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSGST"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

                            </div>

                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">IGST   :</label>
                                <asp:TextBox ID="txtIGST" runat="server" Width="100%" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtIGST"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtIGST"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>

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
                                <label class="col-form-label" for="email">Account Name   :</label><br />
                                <asp:DropDownList ID="ddlSClient" runat="server" CssClass="form-control js-example-placeholder-single">
                                </asp:DropDownList>
                            </div>

                            <div class="col-md-3 col-sm-2 m-t-30">
                                <%--<label class="col-form-label" for="email">Search   :</label>--%>
                                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSearch_Click" />
                            </div>
                            <div class="col-md-4 col-sm-3 p-30">
                                <%--<label class="col-form-label" for="email">Page Size   :</label>--%>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" CssClass="form-control">
                                    <asp:ListItem Text="Select Page Size" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                    <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                    <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group row m-b-20">
                            <div class="col-md-12 col-sm-12">
                                <asp:GridView ID="GridView1" CssClass="table table-hover m-b-0 text-inverse" runat="server" AutoGenerateColumns="False"
                                    DataKeyNames="nClientID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nClientID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nClientID") %>'></asp:Label>
                                                <asp:Label ID="lblCAID" runat="server" Text='<%# Eval("nCAccountID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sClientCode" HeaderText="CLIENT CODE" />

                                        <asp:BoundField DataField="sAgencyName" HeaderText="AGENCY NAME" />
                                        <asp:BoundField DataField="sIATANo" HeaderText="IATA NO" />
                                        <asp:BoundField DataField="sLicenseNo" HeaderText="LICENSE NO" />
                                        <asp:BoundField DataField="sGSTNo" HeaderText="GST NO" />
                                        <asp:BoundField DataField="sPanCardNo" HeaderText="PAN NO" />
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                </asp:LinkButton>
                                                <%--<asp:LinkButton ID="btngdDelete" runat="server" OnClick="btngdDelete_Click" ToolTip="Delete">
                           <i class="far fa-lg fa-fw m-r-10 fa-trash-alt fa-grid-del"></i> <span class="text-inverse">Delete</span>
                                                </asp:LinkButton>--%>
                                               <%-- <AjaxToolKit:ConfirmButtonExtender ID="btngdDelete_confirmbuttonextender" runat="server"
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
                                                </asp:Panel>--%>
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
