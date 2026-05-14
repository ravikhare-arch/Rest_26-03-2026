<%@ Page Title="Reports" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="AutoCapture_Test.aspx.cs" Inherits="Reports_AutoCapture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <style>
        input[type="radio"] {
            margin-left: 10px;
            padding-left: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Reports
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

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
                        <h4 class="panel-title">Reports</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <asp:UpdatePanel ID="up1" runat="server">
                            <ContentTemplate>
                                <div class="form-group row m-b-15">
                                    <div class="col-md-12 col-sm-4">
                                        <asp:RadioButtonList ID="optReport" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="form-control"  >
                                            <asp:ListItem Text="By PNR No" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="By Ticket No" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="By Passenger Name" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="By Creation Date Range" Value="4"></asp:ListItem>
                                           
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                <asp:Panel ID="pnlAirlineSales" runat="server">
                                    <fieldset class="the-fieldset">
                                        <legend class="the-legend text-black">Auto Capture (AIR File)</legend>
                                        <div class="form-group row m-b-15">
                                            
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="email">PNR No</label>
                                               </div>  
                                            <div class="col-md-3 col-sm-6">
                                                <asp:TextBox ID="txtpnrno" runat="server" CssClass="form-control" required="*"></asp:TextBox>
                                            </div>
                                            
                                            <div class="col-md-2 col-sm-6">
                                                <label class="col-form-label" for="email">Ticket No</label>
                                               </div>  
                                            <div class="col-md-3 col-sm-6">  
                                                <asp:TextBox ID="txtticketno" runat="server" CssClass="form-control" required="*"></asp:TextBox>
                                            </div>

                                           

                                            

                                        </div>
                                         <div class="form-group row m-b-15">
                                              <div class="col-md-2 col-sm-2">


                                                <label class="col-form-label" for="email">From Date :</label>
                                                <asp:TextBox ID="txtdtFrom" runat="server" CssClass="datepicker" Width="100%" Style="z-index: 9999;" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>

                                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                                    TargetControlID="txtdtFrom" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtdtFrom"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtFrom" TargetControlID="txtdtFrom" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtdtFrom" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>
                                             <div class="col-md-3  col-sm-2">
                                                 </div>
                                            <div class="col-md-2  col-sm-2">
                                                <label class="col-form-label" for="email">To Date :</label>
                                                <asp:TextBox ID="txtdtToDate" runat="server" CssClass="datepicker" Width="100%" placeholder="dd/MM/yyyy" AutoComplete="off"></asp:TextBox>


                                                <AjaxToolKit:MaskedEditExtender ID="MEE3" runat="server"
                                                    TargetControlID="txtdtToDate" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                                <asp:RegularExpressionValidator ID="REV3" ControlToValidate="txtdtToDate"
                                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                                </asp:RegularExpressionValidator>
                                                <%--<AjaxToolKit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy"
                                                    PopupButtonID="txtdtToDate" TargetControlID="txtdtToDate" PopupPosition="BottomRight" />--%>
                                                <%--<asp:RequiredFieldValidator ID="RFV3" runat="server" ControlToValidate="txtdtToDate" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>--%>
                                            </div>

                                             </div>

                                        <div class="form-group row m-b-15">
                                            <div class="col-md-3 col-sm-6">
                                                
                                            </div>
                                            <div class="col-md-3 col-sm-6">
                                                
                                            </div>
                                            </div>



                                        <div class="form-group row m-b-0 text-center">
                                            <div class="col-md-12 col-sm-12">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="A" ToolTip="Search"  />
                                            </div>
                                        </div>
                                    </fieldset>
                                </asp:Panel>
                                
                               
                            </ContentTemplate>
                        </asp:UpdatePanel>




                    </div>
                    <!-- end panel-body -->
                     <div class="tab-pane fade" id="ItemTab_2">
                        <asp:Panel ID="grdDet" runat="server" Width="100%">
                            


       <%-- <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nLoginId" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nLoginId" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nCaptureId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="sTicketNo" HeaderText="Full Name" />
                <asp:BoundField DataField="sPNRNo" HeaderText="Login" />
                

                
            </Columns>
        </asp:GridView>--%>
                            

                        </asp:Panel>
                    </div>
                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->

        </div>
        <!-- end row -->
    </asp:Panel>
</asp:Content>

