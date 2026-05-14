<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="mcreditcard.aspx.cs" Inherits="mcreditcard_masters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Credit Card
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <%--<asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>--%>
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
                        <h4 class="panel-title">Add Credit Card</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">


                        <div class="form-group row m-b-15">

                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Code</label>
                                <asp:TextBox ID="txtcode" runat="server" CssClass="form-control" required="*"></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Name</label>
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control" required="*"></asp:TextBox>
                            </div>
                             
                           
                           
                        </div>
                         <div class="form-group row m-b-15">
                             <div class="col-md-2 col-sm-6">
                                <label class="col-form-label" for="email">Currency</label>
                                <asp:DropDownList ID="ddlcurrency" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlcurrency" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                          </div>
                        <div class="form-group row m-b-15">
                             <div class="col-md-2 col-sm-6">
                                <label class="col-form-label" for="email">Main Ledger</label>
                                <asp:DropDownList ID="ddlmainledger" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlmainledger" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Description</label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" s></asp:TextBox>
                            </div>
                          </div>
                         <div class="form-group row m-b-15">
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Created By : </label>
                               <label class="col-form-label" ID="lblcretedby"></label>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Modified By : </label>
                                <label class="col-form-label" ID="lblmodifiedby"></label>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Created Time : </label>
                               <label class="col-form-label" ID="lblcreatedtime"></label>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Modified Time : </label>
                                <label class="col-form-label" ID="lblmodifiedtime"></label>
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

                    </div>
                    <!-- end panel-body -->

                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->

        </div>
        <!-- end row -->
    </asp:Panel>

    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">

        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" EmptyDataText="No Records to display"
            DataKeyNames="nCurrencyID " Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nCurrencyID" Visible="false">
                    <ItemTemplate>
                      <%--  <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCurrencyID") %>'></asp:Label>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sCurrencyName" HeaderText="CurrencyName" />
                <asp:BoundField DataField="sCurrencyCode" HeaderText="CurrencyCode" />
                <asp:BoundField DataField="nSellingPrice" HeaderText="SellingPrice" />
                <asp:BoundField DataField="nBuyingPrice" HeaderText="BuyingPrice" />
                 <asp:BoundField DataField="sCountryName" HeaderText="Country" />
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

