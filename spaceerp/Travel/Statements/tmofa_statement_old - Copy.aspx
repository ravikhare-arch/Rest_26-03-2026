<%@ Page Title="Umrah Mofa Statement" Language="C#" MasterPageFile="~/PrintMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="tmofa_statement_old - Copy.aspx.cs" Inherits="Travel_tmofa_statement" %>

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
                    <a href="../tmofa_booking.aspx" class="btn btn-warning" id="btnprint">Home</a>
                </div>

            </div>
        </div>

        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server"
            AutoGenerateColumns="False" EmptyDataText="No Records to display" DataKeyNames="nMofaBookingID" HeaderStyle-BackColor="#1c3967" HeaderStyle-Font-Bold="true"
            HeaderStyle-Height="30px" HeaderStyle-ForeColor="White"
            Width="100%" AllowPaging="false" AllowSorting="True" PageSize="25">
            <Columns>
                <asp:TemplateField HeaderText="nMofaBookingID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nMofaBookingID") %>'></asp:Label>
                        <asp:Label ID="lblBookType" runat="server" Text='<%# Eval("sVoucherType") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sVoucherType" HeaderText="Book Type" />
                <asp:BoundField DataField="sMofaBookingNo" HeaderText="Invoice No." />
                <asp:TemplateField HeaderText="Invoice Date">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtBookingDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sAgent" HeaderText="Client" />
                <asp:BoundField DataField="sSupplier" HeaderText="Supplier" />
                <asp:BoundField DataField="sLocationName" HeaderText="Location" />
                <asp:BoundField DataField="sEngName" HeaderText="Name" />
                <asp:BoundField DataField="nNationalityID" HeaderText="Nationality" />
                <asp:TemplateField HeaderText="DOB">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtDOBDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sGender" HeaderText="Gender" />
               <asp:BoundField DataField="sMutamarNo" HeaderText="Mutamar No" />
                 <asp:BoundField DataField="sMofaNo" HeaderText="Mofa No" />
                <asp:BoundField DataField="sEmbassy" HeaderText="Embassy" />
                  
                <%-- <asp:BoundField DataField="sSponsorNo" HeaderText="Sponsor No" />--%>
                <asp:BoundField DataField="sDuration" HeaderText="Duration" />
                <asp:BoundField DataField="sVisaValiditry" HeaderText="Visa Validitry" />
                <asp:BoundField DataField="sPassportNo" HeaderText="Passport No" />
                <asp:TemplateField HeaderText="Isue DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtIssueDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Expiry DT">
                    <ItemTemplate>
                        <%#validation.TextToDate(Eval("dtExpityDate").ToString())%>
                    </ItemTemplate>
                </asp:TemplateField>

              <%--  <asp:BoundField DataField="sMuhram" HeaderText="Muhram" />
                <asp:BoundField DataField="sRelation" HeaderText="Relation" />
                <asp:BoundField DataField="sDependant" HeaderText="Dependant" />--%>

                <asp:BoundField DataField="nBasicFare" HeaderText="Basic Fare" />

                <asp:BoundField DataField="nOtherTax" HeaderText="Sup Otr Tax" />
                <%--<asp:BoundField DataField="nCommRcvd" HeaderText="Sup Comm" />--%>


                <asp:BoundField DataField="nSupSCAmount" HeaderText="Sup SC" />
                <asp:BoundField DataField="nSupTdsAmount" HeaderText="Sup TDS" />
                <asp:BoundField DataField="nSupCGst" HeaderText="Sup CGst" />
                <asp:BoundField DataField="nSupSGst" HeaderText="Sup SGst" />
                <asp:BoundField DataField="nSupIGst" HeaderText="Sup IGst" />


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
                <asp:BoundField DataField="sReemarks" HeaderText="Remarks" />

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

