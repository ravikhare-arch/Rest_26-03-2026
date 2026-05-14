<%@ Page Title="ompany_main" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="company_main.aspx.cs" Inherits="Master_company_main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>Company</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Company
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
    </p>

    <asp:Panel class="tbl" ID="tblmain" runat="server">
        <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading">
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Company Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">

                            <div class="col-md-4 col-sm-4">
                                <label class="col-form-label" for="fullname">Company Name * :</label>

                                <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <label class="col-form-label" for="fullname">Address  :</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4 col-sm-4">
                                <label class="col-form-label" for="fullname">Phone No. :</label>

                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Email ID. :</label>

                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmailID" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Fax No. :</label>

                                <asp:TextBox ID="txtFax" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Website :</label>
                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="fullname">Company Image :</label>

                                <asp:FileUpload ID="FUCompanyImage" runat="server" CssClass="form-control" />
                                <asp:Label ID="lblimagename" runat="server" ForeColor="Black"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                        </div>

                        <div class="form-group row m-b-0" style="text-align: center">
                            <div class="col-md-12 col-sm-12">
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
                    </div>
                </div>

            </div>
            <!-- end panel-body -->

        </div>
        <!-- end row -->
    </asp:Panel>
    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">

        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nCompanyID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nCompanyID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCompanyID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Company Images" >
                    <ItemTemplate>
                        <img src="../Uploads/<%# Eval("sCompanyImage") %>" width="100" height="100" title="Company Logo" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sCompanyName" HeaderText="CompanyName" />
                <asp:BoundField DataField="sAddress" HeaderText="Address" />
                <asp:BoundField DataField="sPhone" HeaderText="Phone" />
                <asp:BoundField DataField="sEmailID" HeaderText="EmailID" />
                <asp:BoundField DataField="sFax" HeaderText="Fax" />
                <asp:BoundField DataField="sWebsite" HeaderText="Website" />
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

    </asp:Panel>
</asp:Content>
