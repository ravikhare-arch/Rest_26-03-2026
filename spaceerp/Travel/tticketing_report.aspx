<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="tticketing_report.aspx.cs" Inherits="Travel_tticketing_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Ticket Report
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand">
                                <i class="fa fa-expand"></i></a><a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning"
                                    data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Ticket Booking Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div style="border: 1px solid #e0e0d9; padding: 10px; margin-top: 20px;">
                            <div class="form-group row m-b-15">
                                <div class="col-md-3 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Ticket Booking No. :</label>
                                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlTicketBookingNo" runat="server">
                                    </asp:DropDownList>

                                </div>
                                <div class="col-md-2 col-sm-2">
                                    <label class="col-form-label" for="fullname">
                                        Booking Date :</label>
                                    <asp:TextBox ID="txtdtBooking" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1 col-sm-1" style="padding-top: 23px; padding-left: 0px">
                                    <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                        PopupButtonID="Img4" TargetControlID="txtdtBooking" PopupPosition="TopLeft" />
                                    <asp:ImageButton ID="Img4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png"
                                        Width="32" Height="32" />
                                    <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server" TargetControlID="txtdtBooking"
                                        Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                    <asp:RegularExpressionValidator ID="REV4" ControlToValidate="txtdtBooking" ValidationGroup="A"
                                        Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                    </asp:RegularExpressionValidator>
                                </div>
                                <div class="col-md-3 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Agent Name :</label>
                                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlAgentID" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Location  :</label>
                                    <asp:DropDownList ID="ddlLocationID" runat="server" CssClass="js-example-placeholder-single form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>



                        <div class="form-group row m-b-0" style="margin: 20px; text-align: center;">
                            <div class="col-md-12 col-sm-12">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A"
                                    ToolTip="Search" OnClick="btnSearch_Click" />

                            </div>
                        </div>

                        <div class="row row m-b-0" style="margin-top: 20px;">
                            <asp:Panel class="tbl table-responsive" ID="tblGrd" runat="server">
                                <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
                                    AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nTicketingID"
                                    Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
                                    <Columns>
                                        <asp:TemplateField HeaderText="nTicketingID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTicketingID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sTicketBookingNo" HeaderText="Ticket Booking No" />
                                        <asp:TemplateField HeaderText="Booking Date">
                                            <ItemTemplate>
                                                <%#validation.TextToDate(Eval("dtBooking").ToString())%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="sVisaCompanySell" HeaderText="Visa Sell To" />
                                        <asp:BoundField DataField="sVisaCompanyBuy" HeaderText="Visa Buy From" />
                                        <asp:BoundField DataField="sVisaCompanySell" HeaderText="Visa Sell To" />
                                        <asp:BoundField DataField="sCustomerName" HeaderText="Custommer Name" />
                                        <asp:BoundField DataField="sFromCountry" HeaderText="From Country" />
                                        <asp:BoundField DataField="sToCountry" HeaderText="To Country" />
                                        <asp:BoundField DataField="sTripType" HeaderText="Trip Type" />
                                        <asp:BoundField DataField="sFlightClass" HeaderText="Flight Class" />
                                        <asp:BoundField DataField="nBuyRate" HeaderText="Buying Cost" />
                                        <asp:BoundField DataField="nSellRate" HeaderText="Selling Cost" />
                                        <asp:TemplateField HeaderText="Edit/Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btngdEdit" runat="server" OnClick="btngdEdit_Click" ToolTip="Edit">
                           <i class="far fa-lg fa-fw m-r-10 fa-edit fa-grid-edit"></i> <span class="text-inverse">Edit</span>
                                                </asp:LinkButton>
                                                <asp:LinkButton ID="btngdPrint" runat="server" OnClick="btngdPrint_Click" ToolTip="Print">
                           <i class="fas fa-lg fa-fw m-r-10 fa-print fa-grid-edit"></i> <span class="text-inverse">Print</span>
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
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

