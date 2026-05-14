<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="AutoCapture.aspx.cs" Inherits="Reports_AutoCapture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
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
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>
                        <h4 class="panel-title">Auto Capture (AIR File)</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">
                            <div class="col-md-2 col-sm-3" style="z-index: 9999">
                                <label class="col-form-label" for="email">Creation Date From</label>
                                <asp:TextBox ID="txtdatefrom" runat="server" ValidationGroup="A" CssClass="datepicker" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                   
                                                    <AjaxToolKit:MaskedEditExtender ID="MEE9" runat="server"
                                                        TargetControlID="txtdatefrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="REV9" ControlToValidate="txtdatefrom"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>

                            </div>
                            
                            <div class="col-md-2  col-sm-3" style="z-index: 9999;">
                                <label class="col-form-label" for="email">Creation Date To</label>
                               
                                <asp:TextBox ID="txtdateto" runat="server" ValidationGroup="A" CssClass="datepicker" Width="100%" placeholder="DD/MM/YYYY"></asp:TextBox>
                                                   
                                                    <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                        TargetControlID="txtdateto" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdateto"
                                                        ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                    </asp:RegularExpressionValidator>

                                
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">PNR No</label>
                                <asp:TextBox ID="txtpnrno" runat="server"  required="*"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Ticket No</label>
                                <asp:TextBox ID="txtticketno" runat="server"  required="*"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Passenger Name</label>

                                <asp:TextBox ID="txtpassengername" runat="server"  required="*"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-2 col-sm-3">
                                <label class="col-form-label" for="email">Client Name</label>

                                <asp:TextBox ID="txtclientname" runat="server" required="*"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="ddlReportType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                            </div>
                             
                        </div>
                       
                        <div class="form-group row m-b-15">
                            
                        </div>

                        <%--<div class="form-group row m-b-0 text-center">
                            <div class="col-md-12 col-sm-12">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A" ToolTip="Search" OnClick="btnSearch_Click" />
                            </div>
                        </div>--%>
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
       <%-- <asp:Label ID="lblpgs" runat="server" Text="Page Size :"></asp:Label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
        </asp:DropDownList>--%>
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nCaptureId" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
            >
            <Columns>
                <asp:TemplateField HeaderText="nCaptureId" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCaptureId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Sr No." >
                    <ItemTemplate>
                        <%# Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="sJourneyType" HeaderText="Journey Type" />
                <asp:BoundField DataField="sAirNumeric" HeaderText="Air Numeric" />
                <asp:BoundField DataField="sAirPNRNo" HeaderText="Air PNR" />
                <asp:BoundField DataField="sPAXMob" HeaderText="Pax Mobile" />
                <asp:BoundField DataField="sPAXEmail" HeaderText="Pax Email" />
                <asp:BoundField DataField="sFlightClass" HeaderText="RBD" />
                <asp:BoundField DataField="dttravel" HeaderText="Travel Date" />
                <asp:BoundField DataField="dtReturn" HeaderText="Return Date" />
                <asp:BoundField DataField="sBookingSign" HeaderText="Booking Signin" />
                <asp:BoundField DataField="sIATACom" HeaderText="IATA Comm." />
                <asp:BoundField DataField="sAIRPLB" HeaderText="AIR PLB" />
                <asp:BoundField DataField="sFareBasis" HeaderText="Fare Basis" />
                <asp:BoundField DataField="sTaxDetails" HeaderText="Tax Details" />
                <asp:BoundField DataField="sCancellation" HeaderText="Cancellation" />
                <asp:BoundField DataField="sMF" HeaderText="MF" />
                <asp:BoundField DataField="sBilling" HeaderText="Billing" />
                <asp:BoundField DataField="sTourCode" HeaderText="TOUR Code" />
                <asp:BoundField DataField="sTicketNo" HeaderText="Ticket No" />
                <asp:BoundField DataField="sPNRNo" HeaderText="PNR No" />
                <asp:BoundField DataField="sCRSType" HeaderText="CRS" />
                 <asp:BoundField DataField="sPCC" HeaderText="PCC" />
                <asp:BoundField DataField="sIATANo" HeaderText="IATA No" />
                <asp:BoundField DataField="sPassengerName" HeaderText="PAX Name" />
                <asp:BoundField DataField="sPassengerType" HeaderText="PAX Type" />
                <asp:BoundField DataField="sSectorfrom" HeaderText="Sector From" />
                <asp:BoundField DataField="sSectorTo" HeaderText="Sector To" />
                <asp:BoundField DataField="sFileName" HeaderText="File Name" />
                <asp:BoundField DataField="dtProcess" HeaderText="Process Date" />
                <asp:BoundField DataField="sProcessTime" HeaderText="Process Time" />
                <asp:BoundField DataField="sStaffSign" HeaderText="Staff Sign" />
                <asp:BoundField DataField="dtIssue" HeaderText="Issue Date" />
                <asp:BoundField DataField="sCurrency" HeaderText="Currency" />
                <asp:BoundField DataField="nBasicFare" HeaderText="Basic Fare" />
                 <asp:BoundField DataField="nTotalTax" HeaderText="Total TAX" />
                 <asp:BoundField DataField="nGrandTotal" HeaderText="Grand Total" />
                
            </Columns>
        </asp:GridView>

    </asp:Panel>

</asp:Content>

