<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.master" AutoEventWireup="true" CodeFile="testForm.aspx.cs" Inherits="Masters_testForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- ================== BEGIN PAGE LEVEL JS ================== -->

    <!-- ================== END PAGE LEVEL JS ================== -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="vmsg" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="vtitle" runat="Server">
    Tabs.....
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- begin row -->
    <div class="row">
        <!-- begin col-6 -->
        <div class="col-lg-12">
            <!-- begin nav-tabs -->
            <ul class="nav nav-tabs">
                <li class="nav-items">
                    <a href="#default-tab-1" data-toggle="tab" class="nav-link active">
                        <span class="d-sm-none">Tab 1</span>
                        <span class="d-sm-block d-none">Default Tab 1</span>
                    </a>
                </li>
                <li class="nav-items">
                    <a href="#default-tab-2" data-toggle="tab" class="nav-link">
                        <span class="d-sm-none">Tab 2</span>
                        <span class="d-sm-block d-none">Default Tab 2</span>
                    </a>
                </li>
                <li class="">
                    <a href="#default-tab-3" data-toggle="tab" class="nav-link">
                        <span class="d-sm-none">Tab 3</span>
                        <span class="d-sm-block d-none">Default Tab 3</span>
                    </a>
                </li>
            </ul>
            <!-- end nav-tabs -->
            <!-- begin tab-content -->
            <div class="tab-content">
                <!-- begin tab-pane -->
                <div class="tab-pane fade active show" id="default-tab-1">
                    <div class="form-group row m-b-15">

                        <div class="col-md-6 col-sm-6">
                            <label class="col-form-label" for="fullname">Item Name * : </label>
                            <asp:TextBox ID="txtitemName" runat="server" CssClass="form-control" required></asp:TextBox>
                        </div>
                        <div class="col-md-6 col-sm-6">
                            <label class="col-form-label" for="fullname">Item Category :</label>

                            <asp:DropDownList ID="ddlItemCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group row m-b-15">

                        <div class="col-md-4 col-sm-4">
                            <label class="col-form-label" for="fullname">Item Sub Category :</label>
                            <asp:DropDownList ID="ddlItemSubCategory" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>


                        <div class="col-md-4 col-sm-4">
                            <label class="col-form-label" for="fullname">Item Type :</label>
                            <asp:DropDownList ID="ddlItemType" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Select Type" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Normal Item" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Group Item" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <label class="col-form-label" for="fullname">Item Mark *:</label>

                            <asp:TextBox ID="txtItemMark" runat="server" CssClass="form-control" required></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row m-b-15">
                        <div class="col-md-8 col-sm-8">
                            <label class="col-form-label" for="fullname">Warrenty Remarks :</label>
                            <asp:TextBox ID="txtWarrentyRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                        <div class="col-md-4 col-sm-4">
                            <label class="col-form-label" for="fullname">Show Warrenty Remarks :</label>
                            <asp:CheckBox ID="chkWarrentyRemarks" Text=" Show Warrenty Remarks" runat="server" CssClass="form-control" />
                        </div>
                    </div>

                    <div class="form-group row m-b-15">




                        <div class="col-md-8 col-sm-8">
                            <label class="col-form-label" for="fullname">Promotion Remarks :</label>

                            <asp:TextBox ID="txtPromotionRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>


                        <div class="col-md-4 col-sm-4">

                            <label class="col-form-label" for="fullname">Show Promotion Remarks :</label>
                            <asp:CheckBox ID="chkPromotionRemarks" Text="Show Promotion Remarks" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group row m-b-15">


                        <div class="col-md-8 col-sm-8">
                            <label class="col-form-label" for="fullname">Item Remarks :</label>

                            <asp:TextBox ID="txtItemRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">

                            <label class="col-form-label" for="fullname">Show Item Remarks :</label>
                            <asp:CheckBox ID="chkItemRemarks" Text="Show Item Remarks" runat="server" CssClass="form-control" />
                        </div>

                    </div>

                    <div class="form-group row m-b-15">


                        <div class="col-md-8 col-sm-8">
                            <label class="col-form-label" for="fullname">Specification Remarks:</label>

                            <asp:TextBox ID="txtSpecificationRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-4 col-sm-4">
                            <label class="col-form-label" for="fullname">Show Specification Remarks:</label>

                            <asp:CheckBox ID="chkSpecificationRemarks" Text="Show Specification Remarks" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="form-group row m-b-15">


                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Sale Price * :</label>
                            Sale Price
                                    <asp:TextBox ID="txtSalePrice" runat="server" CssClass="form-control" required></asp:TextBox><asp:RegularExpressionValidator ID="REV14" runat="server" ControlToValidate="txtSalePrice"
                                        SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                        ValidationGroup="A"></asp:RegularExpressionValidator>
                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE14" runat="server"
                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtSalePrice"
                                ValidChars=".-">
                            </AjaxToolKit:FilteredTextBoxExtender>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Avg Sale Price :</label>

                            <asp:TextBox ID="txtAvgSalePrice" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV15" runat="server" ControlToValidate="txtAvgSalePrice"
                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                ValidationGroup="A"></asp:RegularExpressionValidator>
                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE15" runat="server"
                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAvgSalePrice"
                                ValidChars=".-">
                            </AjaxToolKit:FilteredTextBoxExtender>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Last Purchase Price :</label>
                            LastPurchasePrice
                                <asp:TextBox ID="txtLastPurchasePrice" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV16" runat="server" ControlToValidate="txtLastPurchasePrice"
                                    SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                    ValidationGroup="A"></asp:RegularExpressionValidator>
                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE16" runat="server"
                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtLastPurchasePrice"
                                ValidChars=".-">
                            </AjaxToolKit:FilteredTextBoxExtender>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Avg Purchase Price :</label>

                            <asp:TextBox ID="txtAvgPurchasePrice" runat="server" CssClass="form-control"></asp:TextBox><asp:RegularExpressionValidator ID="REV17" runat="server" ControlToValidate="txtAvgPurchasePrice"
                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                ValidationGroup="A"></asp:RegularExpressionValidator>
                            <AjaxToolKit:FilteredTextBoxExtender ID="FTBE17" runat="server"
                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtAvgPurchasePrice"
                                ValidChars=".-">
                            </AjaxToolKit:FilteredTextBoxExtender>
                        </div>
                    </div>




                    <div class="form-group row m-b-15">
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Last Purchase :</label>

                            <asp:TextBox ID="txttLastPurchase" runat="server" CssClass="form-control"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender18" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Img18" TargetControlID="txttLastPurchase" PopupPosition="TopLeft" />
                            <asp:ImageButton ID="Img18" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE18" runat="server"
                                TargetControlID="txttLastPurchase" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV18" ControlToValidate="txttLastPurchase"
                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Last Order :</label>

                            <asp:TextBox ID="txttLastOrder" runat="server" CssClass="form-control"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender19" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Img19" TargetControlID="txttLastOrder" PopupPosition="TopLeft" />
                            <asp:ImageButton ID="Img19" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE19" runat="server"
                                TargetControlID="txttLastOrder" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV19" ControlToValidate="txttLastOrder"
                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>


                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Last Sold :</label>

                            <asp:TextBox ID="txttLastSold" runat="server" CssClass="form-control"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender20" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Img20" TargetControlID="txttLastSold" PopupPosition="TopLeft" />
                            <asp:ImageButton ID="Img20" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE20" runat="server"
                                TargetControlID="txttLastSold" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV20" ControlToValidate="txttLastSold"
                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>
                        <div class="col-md-3 col-sm-3">
                            <label class="col-form-label" for="fullname">Expiry Date:</label>

                            <asp:TextBox ID="txttExpiry" runat="server" CssClass="form-control"></asp:TextBox>
                            <AjaxToolKit:CalendarExtender ID="CalendarExtender21" runat="server" Format="dd/MM/yyyy"
                                PopupButtonID="Img21" TargetControlID="txttExpiry" PopupPosition="TopLeft" />
                            <asp:ImageButton ID="Img21" runat="server" ImageUrl="~/assets/img/Calendar-icon.png" Width="32" Height="32" />
                            <AjaxToolKit:MaskedEditExtender ID="MEE21" runat="server"
                                TargetControlID="txttExpiry" Mask="99/99/9999" MaskType="Date" AcceptNegative="None" />
                            <asp:RegularExpressionValidator ID="REV21" ControlToValidate="txttExpiry"
                                ValidationGroup="A" Display="Dynamic" SetFocusOnError="true" runat="server" ErrorMessage="Invalid Date"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"> 
                            </asp:RegularExpressionValidator>
                        </div>
                    </div>


                    <div class="form-group row m-b-0">
                        <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                        <div class="col-md-8 col-sm-8">
                            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Add" ValidationGroup="A" ToolTip="Add" />
                            <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" ToolTip="Update" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" Text="Delete" ToolTip="Delete" />
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
                <!-- end tab-pane -->
                <!-- begin tab-pane -->
                <div class="tab-pane fade" id="default-tab-2">
                    <blockquote>
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        <small>Someone famous in <cite title="Source Title">Source Title</cite></small>
                    </blockquote>
                    <h4>Lorem ipsum dolor sit amet</h4>
                    <p>
                        Nullam ac sapien justo. Nam augue mauris, malesuada non magna sed, feugiat blandit ligula. 
								In tristique tincidunt purus id iaculis. Pellentesque volutpat tortor a mauris convallis, 
								sit amet scelerisque lectus adipiscing.
						
                    </p>
                </div>
                <!-- end tab-pane -->
                <!-- begin tab-pane -->
                <div class="tab-pane fade" id="default-tab-3">
                    <p>
                        <span class="fa-stack fa-4x pull-left m-r-10">
                            <i class="fa fa-square-o fa-stack-2x"></i>
                            <i class="fab fa-twitter fa-stack-1x"></i>
                        </span>
                        Praesent tincidunt nulla ut elit vestibulum viverra. Sed placerat magna eget eros accumsan elementum. 
								Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam quis lobortis neque. 
								Maecenas justo odio, bibendum fringilla quam nec, commodo rutrum quam. 
								Donec cursus erat in lacus congue sodales. Nunc bibendum id augue sit amet placerat. 
								Quisque et quam id felis tempus volutpat at at diam. Vivamus ac diam turpis.Sed at lacinia augue. 
								Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
								Sed at lacinia augue. Nulla facilisi. Fusce at erat suscipit, dapibus elit quis, luctus nulla. 
								Quisque adipiscing dui nec orci fermentum blandit.
						
                    </p>
                </div>
                <!-- end tab-pane -->
            </div>
            <!-- end tab-content -->

        </div>
        <!-- end col-6 -->

    </div>
    <!-- end row -->
</asp:Content>

