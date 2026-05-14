<%@ Page Title="Train Ticket Statement" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="ttrainticket_statement_old.aspx.cs" Inherits="Travel_texcursion_statement" %>

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
                        Booking Type  :</label>
                    <asp:DropDownList ID="ddlSBookType" runat="server" CssClass="js-example-placeholder-single form-control">
                        <asp:ListItem Text="Select Ticket Type" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Booking" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Refund" Value="2"></asp:ListItem>

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
                     <a href="../ttrain_booking.aspx" class="btn btn-warning" id="btnprint">Home</a>
                </div>
               
            </div>
        </div>

        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nTrainBookingID" HeaderStyle-BackColor="#1c3967" HeaderStyle-Font-Bold="true"
            HeaderStyle-Height="30px" HeaderStyle-ForeColor="White"
            Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25">
            <Columns>
                <asp:TemplateField HeaderText="nTrainBookingID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nTrainBookingID") %>'></asp:Label>
                        <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sVoucherType" HeaderText="Book Type" />
                <asp:BoundField DataField="sTrainBookingNo" HeaderText="Invoice No." />
                <asp:TemplateField HeaderText="Invoice Date">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtBookingDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sAgent" HeaderText="Client" />
                <asp:BoundField DataField="sSupplier" HeaderText="Supplier" />
                 <asp:BoundField DataField="sLocationName" HeaderText="Location" />
                <asp:BoundField DataField="sPaxName1" HeaderText="Pax Name" />
                
                <asp:BoundField DataField="sPnrNo" HeaderText="PNR No." />
                <asp:BoundField DataField="sTrainNo" HeaderText="Train No" />
                <asp:BoundField DataField="sClass" HeaderText="Class" />
                <asp:TemplateField HeaderText="Travel Date">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtTravelDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sBoarding" HeaderText="Boarding" />
               
                <asp:BoundField DataField="sFromStn" HeaderText="Stn. From" />
                  <asp:BoundField DataField="sToStn" HeaderText="Stn. To" />
                <asp:BoundField DataField="sPaxNos" HeaderText="Pax Nos." />
                <asp:BoundField DataField="sTicketNo" HeaderText="Ticket No" />
                <asp:BoundField DataField="nBasicFare" HeaderText="Basic Fare" />

                 <asp:BoundField DataField="nOtherTax" HeaderText="Sup Otr Tax" />
                <asp:BoundField DataField="nSupComm" HeaderText="Sup Comm" />
              
                
                <asp:BoundField DataField="nSupSCAmount" HeaderText="Sup SC" />
                <asp:BoundField DataField="nSupTdsAmount" HeaderText="Sup TDS" />
                <asp:BoundField DataField="nSupCGst" HeaderText="Sup CGst" />
                <asp:BoundField DataField="nSupSGst" HeaderText="Sup SGst" />
                <asp:BoundField DataField="nSupIGst" HeaderText="Sup IGst" />
                <%-- <asp:BoundField DataField="nSupTktFare" HeaderText="Tkt Cost" />--%>

               
                <asp:BoundField DataField="nClntScAmount" HeaderText="Clnt SC1" />
                <asp:BoundField DataField="nClntSc2Amount" HeaderText="Clnt SC2" />
                <asp:BoundField DataField="nClntOtherChrgs" HeaderText="Clnt Otr Chrg" />
                <asp:BoundField DataField="nClntTdsAmount" HeaderText="Clnt TDS" />
                <asp:BoundField DataField="nDiscount" HeaderText="Clnt Discount" />
                
                <asp:BoundField DataField="nClntCGst" HeaderText="Clnt CGst" />
                <asp:BoundField DataField="nClntSGst" HeaderText="Clnt SGst" />
                <asp:BoundField DataField="nClntIGst" HeaderText="Clnt IGst" />
                <asp:BoundField DataField="nSupplierCost" HeaderText="Sup Cost" />
                <asp:BoundField DataField="nClientCost" HeaderText="Clnt Cost" />
                <asp:BoundField DataField="sRemarks" HeaderText="Remarks" />
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

