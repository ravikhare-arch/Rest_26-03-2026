<%@ Page Title="driver_assign" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="mdriver_assign.aspx.cs" Inherits="Master_driver_assign" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="vmsg" Runat="Server">
 <asp:Label ID="lblmsg" runat="server"></asp:Label>
 </asp:Content>
 <asp:Content ID="Content3" ContentPlaceHolderID="vtitle" Runat="Server">
Driver Assign
 </asp:Content>
 <asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>
        <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">ADD</asp:LinkButton>
        <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn-xs btn-info m-r-5 m-b-5">LIST</asp:LinkButton>
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
                        <h4 class="panel-title">Sub Account Details</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">
                            <label class="col-md-3 col-sm-3 col-form-label" for="email">Select Driver  * :</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:DropDownList ID="ddlDriver" runat="server" CssClass="form-control"></asp:DropDownList>
                                

                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <label class="col-md-3 col-sm-3 col-form-label" for="email">Select Vehicle * :</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:DropDownList ID="ddlVehicle" runat="server" CssClass="form-control"></asp:DropDownList>




                            </div>
                        </div>

                        <div class="form-group row m-b-15">
                            <label class="col-md-3 col-sm-3 col-form-label" for="email">Task * :</label>
                            <div class="col-md-9 col-sm-9">
                                <asp:TextBox ID="txtTask" runat="Server" required CssClass="form-control"></asp:TextBox>
                            </div>
                            

                           
                        </div>
                        <div class="form-group row m-b-15">
                            <label class="col-md-3 col-sm-3 col-form-label" for="email">Vehicle Out Date & Time * :</label>
                            <div class="col-md-3 col-sm-3">
                                
                                <asp:TextBox ID="dtVehicleOut" runat="Server" required CssClass="form-control"></asp:TextBox>
                            
                            </div>
                            <div class="col-md-1 col-sm-1">
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender4" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="Img4" TargetControlID="dtVehicleOut" PopupPosition="TopLeft" />
                                <asp:ImageButton ID="Img4" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                                <AjaxToolKit:MaskedEditExtender ID="MEE4" runat="server"
                                    TargetControlID="dtVehicleOut" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="REV4" ControlToValidate="dtVehicleOut"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                
                                <asp:TextBox ID="txtOutTime" runat="Server" CssClass="form-control"></asp:TextBox>
                            
                            
                                
                                
                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender1" runat="server"
                                    TargetControlID="txtOutTime" Mask="99:99" MaskType="Time" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtOutTime"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"> 
                                </asp:RegularExpressionValidator>


                            </div>
                            <div class="col-md-2 col-sm-2">
                                    <asp:DropDownList ID="ddlTimeFormatOut" CssClass="form-control" runat="server">

                                        
                                        <asp:ListItem Text="AM" Value="1">AM</asp:ListItem>
                                        <asp:ListItem Text="PM" Value="2">PM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <label class="col-md-3 col-sm-3 col-form-label" for="email">Vehicle IN Date & Time * :</label>
                            <div class="col-md-3 col-sm-3">
                                
                                <asp:TextBox ID="dtVehicleIN" runat="Server" required CssClass="form-control"></asp:TextBox>
                            
                            </div>
                            <div class="col-md-1 col-sm-1">
                                <AjaxToolKit:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy"
                                    PopupButtonID="Img5" TargetControlID="dtVehicleIN" PopupPosition="TopLeft" />
                                <asp:ImageButton ID="Img5" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender2" runat="server"
                                    TargetControlID="dtVehicleIN" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="dtVehicleIN"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                                </asp:RegularExpressionValidator>

                            </div>
                            <div class="col-md-3 col-sm-3">
                                
                                <asp:TextBox ID="txtTimeIN" runat="Server" required CssClass="form-control"></asp:TextBox>
                            
                            
                                
                                
                                <AjaxToolKit:MaskedEditExtender ID="MaskedEditExtender3" runat="server"
                                    TargetControlID="txtTimeIN" Mask="99:99" MaskType="Time" AcceptNegative="None" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtTimeIN"
                                    ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                    ValidationExpression="^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$"> 
                                </asp:RegularExpressionValidator>


                            </div>
                            <div class="col-md-2 col-sm-2">
                                    <asp:DropDownList ID="ddlTimeFormatIN" CssClass="form-control" runat="server">

                                        
                                        <asp:ListItem Text="AM" Value="1">AM</asp:ListItem>
                                        <asp:ListItem Text="PM" Value="2">PM</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                        </div>

                        <div class="form-group row m-b-0">
                            <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                            <div class="col-md-8 col-sm-8">
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
        <asp:GridView ID="GridView1" CssClass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False"
            DataKeyNames="nDriverAssignID" Width="100%" AllowPaging="true" AllowSorting="True" PageSize="25" EmptyDataText="No Records to display"
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="nDriverAssignID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("nDriverAssignID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="sDriverName" HeaderText="Drive Name" />

                <asp:BoundField DataField="sVehicleNo" HeaderText="Vehicle No." />
                
                <asp:BoundField DataField="sTask" HeaderText="Task" />
                <asp:BoundField DataField="dtVehicleOut" HeaderText="Vehicle Out Date" />
                <asp:BoundField DataField="dtVehicleIN" HeaderText="Vehicle In Date" />
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
