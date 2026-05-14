<%@ Page Title="Visa Statement" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="tvisa_statement_old.aspx.cs" Inherits="Travel_tvisa_statement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            background-color: white;
        }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <asp:Panel ID="pnlMain" runat="server">
        <div style="border: 1px solid #e0e0d9; padding: 10px; margin-top: 20px; margin-bottom: 20px;" id="tpContent" runat="server">
            <div class="form-group row m-b-15">
                <div class="col-md-2 col-sm-3">
                    <label class="col-form-label" for="fullname">
                        Invoice No. :</label>
                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlInvoiceNo" runat="server">
                    </asp:DropDownList>

                </div>

                <div class="col-md-2 col-sm-3">
                    <label class="col-form-label" for="fullname">
                        Client Name :</label>
                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSClient" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-3">
                    <label class="col-form-label" for="fullname">
                        Supplier Name :</label>
                    <asp:DropDownList CssClass="form-control js-example-placeholder-single" ID="ddlSSup" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-3">
                    <label class="col-form-label" for="fullname">
                        Expiry  :</label>
                    <asp:DropDownList ID="ddlExpiry" runat="server" CssClass="js-example-placeholder-single form-control">
                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        <asp:ListItem Text="10 Days" Value="-10"></asp:ListItem>
                        <asp:ListItem Text="20 Days" Value="-20"></asp:ListItem>
                        <asp:ListItem Text="30 Days" Value="-30"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-3">
                    <label class="col-form-label" for="fullname">
                        Location  :</label>
                    <asp:DropDownList ID="ddlSLoc" runat="server" CssClass="js-example-placeholder-single form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2 col-sm-12 m-t-30">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A"
                        ToolTip="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
            <div class="form-group row m-b-5">
                <div class="col-md-12 col-sm-12">
                    <asp:Button ID="btnExcel" runat="server" CssClass="btn btn-primary" Text="Export Excel" ValidationGroup="A"
                        ToolTip="Export Excel" OnClick="btnExcel_Click" />
                     <asp:Button ID="btnPdf" runat="server" CssClass="btn btn-danger" Text="Export PDF" ValidationGroup="A"
                        ToolTip="Export PDF" OnClick="btnPdf_Click" />
                     <asp:Button ID="btnSendMail" runat="server" Text=" Email" CssClass="btn btn-success" OnClick="btnSendMail_Click" />
                     <a href="../tvisa.aspx" class="btn btn-warning" id="btnprint">Home</a>
                </div>
               
            </div>
        </div>

        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nVisaId" HeaderStyle-BackColor="#1c3967" HeaderStyle-Font-Bold="true"
            HeaderStyle-Height="30px" HeaderStyle-ForeColor="White"
            Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
            <Columns>
                <asp:TemplateField HeaderText="nVisaId" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nVisaId") %>'></asp:Label>
                        <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sVoucherType" HeaderText="Visa Type" />
                <asp:BoundField DataField="sVisaBookingNo" HeaderText="Invoice No." />
                <asp:TemplateField HeaderText="Invoice Date">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtBooking").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sVisaSellCompany" HeaderText="Client" />
                <asp:BoundField DataField="sVisaBuyCompany" HeaderText="Supplier" />
                <asp:BoundField DataField="sCustomerName" HeaderText="Custommer Name" />
                 <asp:BoundField DataField="sLocationName" HeaderText="Location" />
                <asp:BoundField DataField="sGender" HeaderText="Gender" />
                 <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtDOB").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sNationality" HeaderText="Nationality" />
                <asp:BoundField DataField="sCountryName" HeaderText="Country" />
                <asp:BoundField DataField="sPassportNo" HeaderText="Passport No" />
                 <asp:TemplateField HeaderText="Passport Issue DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtPassportIssue").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Passport Expiry DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtPasspoprtExpiry").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="nExpectedDuration" HeaderText="Exptd. Duration" />
                 <asp:TemplateField HeaderText="Arrival  DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtExpectedArrival").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Departure  DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtExpectedDeparture").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Visa Apply  DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtApply").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText=" Visa Issue  DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtIssue").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText=" Visa Expiry  DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtVisaExpiryDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sContact1" HeaderText="Contact No." />
                <asp:BoundField DataField="sVisaType" HeaderText="Visa Type" />
               
                <asp:BoundField DataField="nDuration" HeaderText="Duration" />
                <asp:BoundField DataField="sStatus" HeaderText="Status" />
                <asp:BoundField DataField="nExtension" HeaderText="Extension" />
                <asp:BoundField DataField="nCost" HeaderText="Visa Cost" />
                
                <asp:BoundField DataField="nSupSCAmount" HeaderText="Sup SC" />
                <asp:BoundField DataField="nSupTdsAmount" HeaderText="Sup TDS" />
                <asp:BoundField DataField="nSupCGst" HeaderText="Sup CGst" />
                <asp:BoundField DataField="nSupSGst" HeaderText="Sup SGst" />
                <asp:BoundField DataField="nSupIGst" HeaderText="Sup IGst" />
                <%-- <asp:BoundField DataField="nSupTktFare" HeaderText="Tkt Cost" />--%>

               
                <asp:BoundField DataField="nProfitAmount" HeaderText="Clnt SC1" />
                <asp:BoundField DataField="nClntSC2Amount" HeaderText="Clnt SC2" />
                <asp:BoundField DataField="nClntTdsAmount" HeaderText="Clnt TDS" />
                <asp:BoundField DataField="nDiscount" HeaderText="Clnt Discount" />
                <asp:BoundField DataField="nOtherCharges" HeaderText="Otr Chrg" />
                <asp:BoundField DataField="nCourierCharges" HeaderText="Courier Chrg" />
                <asp:BoundField DataField="nClntCGst" HeaderText="Clnt CGst" />
                <asp:BoundField DataField="nClntSGst" HeaderText="Clnt SGst" />
                <asp:BoundField DataField="nClntIGst" HeaderText="Clnt IGst" />
                <asp:BoundField DataField="nBuyCost" HeaderText="Sup Cost" />
                <asp:BoundField DataField="nSellingRate" HeaderText="Clnt Cost" />
                <%--<asp:TemplateField HeaderText="Edit">
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
            </asp:TemplateField>--%>
            </Columns>
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="PNL0" runat="server" Style="background-color: white; width: 500px; border-width: 2px; border-color: Black; border-style: solid; padding: 20px; margin: 0 auto">
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">To</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">CC</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtCC" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">BCC</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtBCC" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">Subject</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtSub" runat="server" CssClass="form-control" Style="color: black;" />
            </div>
        </div>
        <div class="form-group row m-b-15">
            <label class="control-label col-sm-3" for="email" style="color: black;">Body</label>
            <div class="col-sm-8">
                <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" Style="color: black;" />
                <i class="fa fa-paperclip text-black"></i>
                <asp:LinkButton ID="lnkAttachment" runat="server" Style="font-size: 11px; color: black"></asp:LinkButton>
            </div>
        </div>
        <div style="text-align: right;">
            <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary" Text="Send" Style="color: black;" OnClick="btnSend_Click" />
            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-default" Text="Close" Style="color: black;" OnClick="btnClose_Click" />
        </div>
    </asp:Panel>
</asp:Content>

