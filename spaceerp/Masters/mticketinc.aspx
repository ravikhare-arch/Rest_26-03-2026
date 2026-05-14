<%@ Page Title="ticketinc" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="mticketinc.aspx.cs" Inherits="Master_ticketinc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Ticket INC
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
    </p>
    <asp:Panel CssClass="tbl" ID="tblmain" runat="server">
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
                        <h4 class="panel-title">Ticket Com</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <div class="form-group row m-b-15">

                                    <div class="col-md-2 col-sm-4">
                                        <label class="col-form-label" for="email">Received From :</label>
                                        <asp:DropDownList ID="ddlReceivedFromID" Width="100%" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlReceivedFromID_SelectedIndexChanged">
                                            <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Airline" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Supplier" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlReceivedFromID" ErrorMessage="*" Display="Dynamic"
                                            SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-2 col-sm-4">
                                        <label class="col-form-label" for="email">Supplier Name</label>
                                        <asp:DropDownList ID="ddlSupplierID" runat="server" Width="100%" Enabled="false" CssClass="js-example-placeholder-single"></asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-sm-4">
                                        <label class="col-form-label" for="email">Airline</label>
                                        <asp:DropDownList ID="ddlAirlineID" runat="server" Width="100%" CssClass="js-example-placeholder-single"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV2" runat="server"
                                            ControlToValidate="ddlAirlineID" ErrorMessage="*" Display="Dynamic"
                                            SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>

                                    <div class="col-md-2 col-sm-4">
                                        <label class="col-form-label" for="email">Ticket Type</label>
                                        <asp:DropDownList ID="ddlTicketTypeID" runat="server" Width="100%">
                                            <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Domestic" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Internarional" Value="2"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlTicketTypeID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                    </div>
                                     <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Start Date</label>
                                <asp:TextBox ID="txttStartDate" runat="server" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender5" runat="server" Format="dd/MM/yyyy" PopupButtonID="txttStartDate" TargetControlID="txttStartDate" PopupPosition="TopLeft" />

                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttStartDate"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txttStartDate"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>
                            </div>
                            <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">End Date</label>
                                <asp:TextBox ID="txttEndDate" runat="server" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender6" runat="server"
                                    Format="dd/MM/yyyy" PopupPosition="TopLeft" PopupButtonID="txttEndDate" TargetControlID="txttEndDate" />

                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttEndDate"
                                    Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txttEndDate"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RFV6" runat="server"
                                    ControlToValidate="txttEndDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True"
                                    ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <div class="form-group row m-b-15">
                           
                            <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Air Class</label>
                                <asp:DropDownList ID="ddlClassID" runat="server" Width="100%">
                                    <asp:ListItem Text="Select Class" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Business" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Economic" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV10" runat="server" ControlToValidate="ddlClassID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Gross / Net</label>
                                <asp:DropDownList ID="ddlGrossNetID" runat="server" Width="100%">
                                    <asp:ListItem Text="Gross" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Net" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV9" runat="server" ControlToValidate="ddlGrossNetID" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>



                        
                            <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Auto/ Manual</label>
                                <asp:DropDownList ID="ddlAutoManualID" Width="100%" runat="server">
                                    <asp:ListItem Text="Auto" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Manual" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                    ControlToValidate="ddlAutoManualID" ErrorMessage="*" Display="Dynamic"
                                    SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Calc. Method</label>
                                <asp:DropDownList ID="ddlCalMethodID" Width="100%" runat="server">
                                    <asp:ListItem Text="% On Basic" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="% On Basic + All Taxes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="% On Basic + YQ TAX" Value="2"></asp:ListItem>
                                </asp:DropDownList>

                            </div>
                            <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Inct Value</label>
                                <asp:TextBox ID="txtIncValue" Width="100%" runat="server">
                                </asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                    ControlToValidate="txtIncValue" ErrorMessage="*" Display="Dynamic"
                                    SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                            

                       
                            <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Sector</label>
                                <asp:TextBox ID="txtSector" Width="100%" runat="server">
                                </asp:TextBox>
                               
                            </div>
                             <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Fare Basic</label>
                                <asp:TextBox ID="txtFareBasic" Width="100%" runat="server">
                                </asp:TextBox>
                               
                            </div>
                             <div class="col-md-1 col-sm-4">
                                <label class="col-form-label" for="email">Deal Code </label>
                                <asp:TextBox ID="txtDealCode" Width="100%" runat="server">
                                </asp:TextBox>
                               
                            </div>
                             <div class="col-md-2 col-sm-4">
                                <label class="col-form-label" for="email">Class Name</label>
                                <asp:TextBox ID="txtClassName" Width="100%" runat="server">
                                </asp:TextBox>
                               
                            </div>
                            

                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-12 col-sm-12 text-center">
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

    <asp:Panel CssClass="tbl table-responsive" ID="tblGrd" runat="server">
        <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nticketincId " Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nticketincId" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nticketincId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nReceivedFromID" HeaderText="ReceivedFromID" />
                <asp:BoundField DataField="nAirlineID" HeaderText="AirlineID" />
                <asp:BoundField DataField="nSupplierID" HeaderText="SupplierID" />
                <asp:BoundField DataField="nTicketTypeID" HeaderText="TicketTypeID" />
                <asp:TemplateField HeaderText="tStartDate">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtStartDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="tEndDate">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtEndDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nCalMethodID" HeaderText="CalMethodID" />
                <asp:BoundField DataField="nClassID" HeaderText="ClassID" />
                <asp:BoundField DataField="nGrossNetID" HeaderText="GrossNetID" />
                <asp:BoundField DataField="nAutoManualID" HeaderText="AutoManualID" />
                <asp:BoundField DataField="nIncValue" HeaderText="IncValue" />
                <asp:BoundField DataField="sSector" HeaderText="Sector" />
                <asp:BoundField DataField="nFareBasic" HeaderText="FareBasic" />
                <asp:BoundField DataField="sDealCode" HeaderText="DealCode" />
                <asp:BoundField DataField="sClassName" HeaderText="ClassName" />
                <asp:BoundField DataField="bStatus" HeaderText="Status" />
                <asp:BoundField DataField="nConfigID" HeaderText="ConfigID" />
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
                        <asp:Panel ID="PNL0" runat="server" Style="display: none; width: 200px; background-color: White; border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
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
