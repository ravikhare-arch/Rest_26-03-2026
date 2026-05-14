<%@ Page Title="tax_master" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="mtax_master.aspx.cs" Inherits="Master_tax_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />    
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    
    <style type="text/css">
        .panel-body {
    padding: 20px;
    padding-top: 10px !important;
}
    </style>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading">
                            <div class="panel-heading-btn pull-left">
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
    </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title text-center">Tax Master</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
    <asp:Panel class="tbl" ID="tblmain" runat="server">
        
                        <div class="col-md-2"></div>
                        <div class="col-md-8">
                        <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">Name of Tax. * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="txtTaxName" required runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <%--  <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">Type of Tax. * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:DropDownList CssClass="form-control js-example-placeholder-single"  ID="ddlTaxType" runat="server">
                                    <asp:ListItem Value="0" Text="Select Type"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Amount"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="% Percentage"></asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>--%>
                        <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">Tax Value. * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="txtValue" required runat="server"></asp:TextBox>

                            </div>
                        </div>
                         <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">CGST * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="txtCGST" required runat="server"></asp:TextBox>

                            </div>
                        </div>
                         <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">SGST * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="txtSGST" required runat="server"></asp:TextBox>

                            </div>
                        </div>
                         <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">IGST * :</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:TextBox CssClass="form-control" ID="txtIGST" required runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="form-group row m-b-0">
                            <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                            <div class="col-md-8 col-sm-8">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl text-center center-block" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
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
                        <div class="col-md-2"></div>                    
    </asp:Panel>
    <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
        
            <div class="col-md-12 ml-auto mr-auto" >
                                        <div class="clearfix form-group">  
                                            <div class="col-md-3">
                                    <label>Agency Name</label>
                                    <asp:TextBox ID="txtAName" placeHolder="Agency Name" AutoComplete="off" CssClass="form-control" runat="server" ></asp:TextBox>

                                </div>                                                                                 
                                            <div class="col-md-3">
                                                <label for="form-1-3" class="col-form-label">Agent ID</label>
                                                     <asp:TextBox ID="txtagentname" placeholder="Agent Name" runat="server" CssClass="search_filter form-control" autocomplete="off"></asp:TextBox>
                               
                                            </div>
                                            <div class="col-md-2">
                                                <label for="form-1-3" class="col-form-label">From Date</label>
                                                <div class="timepicker-input" >
                                                     <asp:TextBox ID="txttLastPurchase" CssClass="form-control" runat="server" Width="100%" placeholder="dd/mm/yyyy"></asp:TextBox>
                                                <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txttLastPurchase" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                                                <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server" TargetControlID="txttLastPurchase"
                                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV18" ControlToValidate="txttLastPurchase" ValidationGroup="A"
                                                    Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                             <div class="col-md-2">
                                                <label for="form-1-3" class="col-form-label">To Date</label>                                  
                                    <div class="timepicker-input">
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
                                                 <input type="button" name="BtnHotelSearch" value="Search" id="BtnSearch" class="btn btn-primary form-control no-mrg-btm"  />
                                                 
                                            </div>
                                        </div>
                                        
                                    </div>
            <div class=" col-md-12 text-center pb-10">
                    <br />
                  
              <%--<asp:UpdatePanel runat="server" ID="upl">
                  <ContentTemplate>--%>
                       <asp:Button ID="Button1" CssClass="btn btn-primary" runat="server" Text="Export To Excel" />
               <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Export To PDF"  />
               <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print" Visible="false"/>
                   <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Send Mail" />            
             
                                          </div>
        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nTaxMasterID " Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nTaxMasterID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTaxMasterID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sTaxName" HeaderText="Name of Tax" />
                <asp:BoundField DataField="nTaxValue" HeaderText="Tax Value (%)" />
                <asp:BoundField DataField="nCGST" HeaderText="CGST" />
                <asp:BoundField DataField="nSGST" HeaderText="SGST" />
                <asp:BoundField DataField="nIGST" HeaderText="IGST" />

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
                        </div>
                    <!-- end panel-body -->

                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->

        </div>
        <!-- end row -->
</asp:Content>
