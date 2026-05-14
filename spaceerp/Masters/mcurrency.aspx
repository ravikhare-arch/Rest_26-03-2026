<%@ Page Title="currency" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="mcurrency.aspx.cs" Inherits="Master_currency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
     <%--<style>
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top: 0px;
            margin-bottom:0px;
         padding:0px;
        }
        .enlarged #wrapper .content-page {
            margin-left: 0px;
        }

        .topbar {
            display: none;
        }

        .footer {
            display: none;
        }
        .side-menu {
            display: none;
        }
    </style>--%>
    <style>
.table {
  font-family: Arial, Helvetica, sans-serif;
  border-collapse: collapse;
  width: 100%;
}

.table td, .table th {
  border: 1px solid #ddd;
  padding: 8px;
}

.table tr:nth-child(even){background-color: #f2f2f2;}

.table tr:hover {background-color: #ddd;}

.table th {
  padding-top: 12px;
  padding-bottom: 12px;
  text-align: left;
  background-color: #018fd4;
  color: white;
}
</style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <asp:Panel class="tbl" ID="tblmain" runat="server">
        <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading text-center">
                        <div class="panel-heading-btn pull-left">
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
    </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title text-center">Add Currency</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">


                        <div class="form-group row m-b-15">

                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Currency Name * :</label>
                                <asp:TextBox ID="txtCurrencyName" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <label class="col-form-label" for="email">Currency Code * :</label>
                                <asp:TextBox ID="txtCurrencyCode" runat="server" CssClass="form-control" required></asp:TextBox>
                            </div>
                             <div class="col-md-2 col-sm-6">
                                <label class="col-form-label" for="email">Country Code * :</label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="form-control js-example-placeholder-single"></asp:DropDownList>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Please fill out this field." Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-6">
                                <label class="col-form-label" for="email">Selling Price :</label>
                                <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="REV3" runat="server" ControlToValidate="txtSellingPrice"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE3" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSellingPrice"
                                    ValidChars=".-">
                                </AjaxToolKit:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-2 col-sm-6">
                                <label class="col-form-label" for="email">Buying Price  :</label>
                                <asp:TextBox ID="txtBuyingPrice" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="REV4" runat="server" ControlToValidate="txtBuyingPrice"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                                <AjaxToolKit:FilteredTextBoxExtender ID="FTBE4" runat="server"
                                    Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtBuyingPrice"
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
        <asp:GridView ID="GridView1" CssClass="table table-hover table-bordered m-b-0 text-inverse" runat="server" AutoGenerateColumns="False" EmptyDataText="No Records to display"
            DataKeyNames="nCurrencyID " Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nCurrencyID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCurrencyID") %>'></asp:Label>
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
