<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="tmenumanage.aspx.cs" Inherits="Restaurant_tmenumanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
   <%-- <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:Panel class="tbl" ID="tblmain" runat="server">
        <!-- begin row -->
        <div class="row">
            <!-- begin col-6 -->
            <div class="col-lg-12">
                <!-- begin panel -->
                <div class="panel panel-inverse">
                    <!-- begin panel-heading -->
                    <div class="panel-heading">
                        <div class="panel-heading-btn pull-left">
                            <asp:LinkButton ID="lnkAdd" runat="server" OnClick="lnkAdd_Click" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>
                            <asp:LinkButton ID="lnkList" runat="server" OnClick="lnkList_Click" CssClass="btn btn-info btn-xs">LIST</asp:LinkButton>
                        </div>
                        <div class="panel-heading-btn">
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                            <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
                        </div>

                        <h4 class="panel-title text-center">Menu Category Management</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div style="margin-top: 10px; padding: 10px">

                            <div class="form-group row m-b-0">

                                <div class="col-md-2 col-sm-2">
                                    <label class="col-form-label" for="fullname">Product Code</label>
                                    <asp:TextBox CssClass="form-control" ID="txtproductcode" runat="server" Width="100%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtproductcode" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Dish Name
                                    </label>
                                    <asp:TextBox CssClass="form-control" ID="txtproduct" runat="server" Width="100%"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtproduct" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Item Group
                                    </label>
                                    <%-- <asp:DropDownList ID="ddItems" runat="server" CssClass="form-control js-example-placeholder-single">
                                         </asp:DropDownList>--%>

                                    <select id="ddItems" class="form-control js-example-placeholder-single">
                                        <option value="0">Select Item Group </option>
                                    </select>
                                    <asp:HiddenField ID="hfSelectedValue" runat="server" />
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Delivery Type
                                    </label>
                                    <asp:DropDownList ID="ddlDeliveryType" runat="server" CssClass="form-control js-example-placeholder-single">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlDeliveryType" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-md-2 col-sm-3" id="trac" runat="server">
                                    <label class="col-form-label" for="fullname">
                                   AC / NON - AC 
                                    </label>
                                    <asp:DropDownList ID="ddlacnonac" runat="server" CssClass="form-control js-example-placeholder-single">
                                        <asp:ListItem Text="Select AC / NON - AC" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="AC" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="NON - AC" Value="1"></asp:ListItem>
                                       
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlacnonac" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Category
                                    </label>
                                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control js-example-placeholder-single">
                                        <asp:ListItem Text="Select Category" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Snacks" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Chaat" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Liquor" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Dessert" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="Starter" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="Chinese" Value="6"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlcategory" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>

                                </div>
                                
                                <div class="col-md-2 col-sm-3">
                                    <label class="col-form-label" for="fullname">
                                        Food Type
                                    </label>
                                    <asp:DropDownList ID="ddlfoodtype" runat="server" CssClass="form-control js-example-placeholder-single">
                                        <asp:ListItem Text="Select Food Type" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Veg" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Non-Veg" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Beverages" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Egg" Value="4"></asp:ListItem>
                                    </asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlfoodtype" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                </div>
                                <asp:UpdatePanel ID="UP1" runat="server">
                                    <ContentTemplate>
                                        <div class="col-md-1 col-sm-2">
                                            <label class="col-form-label" for="fullname">Price</label>
                                            <asp:TextBox CssClass="form-control" ID="txtprice" AutoPostBack="true" runat="server" OnTextChanged="txtprice_TextChanged"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="txtprice"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtprice"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtprice" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-2 col-sm-3">
                                            <label class="col-form-label" for="fullname">
                                                GST
                                            </label>
                                            <asp:DropDownList ID="ddlgst" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlgst_SelectedIndexChanged">
                                                <asp:ListItem Text="Select GST" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="GST" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Non-GST" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hCGST" runat="server" />
                                            <asp:HiddenField ID="hSGST" runat="server" />
                                            <asp:HiddenField ID="hIGST" runat="server" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlgst" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-1 col-sm-2" id="trgstpercent" runat="server">
                                            <label class="col-form-label" for="fullname">GST %</label>
                                            <asp:TextBox CssClass="form-control" ID="txtgstpercent" runat="server" AutoPostBack="true" OnTextChanged="txtgstpercent_TextChanged" Enabled="false" ValidationGroup="A"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtgstpercent"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtgstpercent"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtgstpercent" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-1 col-sm-2">
                                            <label class="col-form-label" for="fullname">Cost</label>
                                            <asp:TextBox CssClass="form-control" ID="txtactualcost" runat="server" ValidationGroup="A" Enabled="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtactualcost"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtactualcost"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtactualcost" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>

                                        <div class="col-md-2 col-sm-2">
                                            <label class="col-form-label" for="fullname">Net Payable</label>
                                            <asp:TextBox CssClass="form-control" ID="txtgstcost" runat="server" ValidationGroup="A"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtgstcost"
                                                SetFocusOnError="True" Display="Dynamic" ErrorMessage="Invalid Numbers" ValidationExpression="^(-)?\d+(\.\d+$)?$"
                                                ValidationGroup="A"></asp:RegularExpressionValidator>
                                            <AjaxToolKit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                Enabled="True" FilterMode="ValidChars" FilterType=" Custom,Numbers" TargetControlID="txtgstcost"
                                                ValidChars=".-">
                                            </AjaxToolKit:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtgstcost" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <div class="col-md-1 col-sm-1">
                                    <label class="col-form-label" for="fullname">Offer</label>
                                    <asp:CheckBox ID="chkoffer" runat="server" CssClass="form-control" />

                                </div>
                                <div class="col-md-1 col-sm-1" id="tractive" runat="server" visible="false">
                                    <label class="col-form-label" for="fullname">Active</label>
                                    <asp:CheckBox ID="chkactive" runat="server" CssClass="form-control" />

                                </div>
                            </div>

                           
                                                    <div class="form-group row m-b-0"> 
                                                        <label class="col-md-4 col-sm-4 col-form-label">&nbsp;</label>
                                                        <div class="col-md-8 col-sm-8">
        
                                                          
                                                            <asp:Button ID="btnDelete" Visible="false" runat="server" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_Click" ToolTip="Delete" CausesValidation="false" />
        
                                                            <AjaxToolKit:ConfirmButtonExtender ID="btnDelete_confirmbuttonextender" runat="server"
                                                                DisplayModalPopupID="btnDelete_modalpopupextender" TargetControlID="btnDelete" />
            
                                                            <AjaxToolKit:ModalPopupExtender ID="btnDelete_modalpopupextender" runat="server"
                                                                BackgroundCssClass="modalBackground" CancelControlID="ButtonCancel" OkControlID="ButtonOk"
                                                                PopupControlID="PNL" TargetControlID="btnDelete" />
        
                                                            <br />
        
                                                            <asp:Panel ID="PNL" runat="server" Style="display: none; width: 250px; background-color: #348fe2; border-radius: 8px; border: 1px solid Black; padding: 20px; text-align:center; color:white;">
                                                                <h5 style="color:white; margin-bottom:15px;">Are you sure you want to delete?</h5>
                                                                <div>
                                                                    <asp:Button ID="ButtonOk" runat="server" Text="OK" CssClass="btn btn-danger btn-sm" />
                                                                    <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" CssClass="btn btn-default btn-sm" />
                                                                </div>
                                                            </asp:Panel>
                                                        </div>
                                                    </div>
                        
                        <asp:Panel class="tbl" ID="Panel1" runat="server">
                            <div style="margin-top: 10px; padding: 10px">
                                <div class="form-group row m-b-0">
                                    <div class="col-md-12 col-sm-12">
                                        <div id="ItemGroup">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel class="tbl" ID="tblDet" runat="server">
                            <div style="margin-top: 10px; padding: 10px">
                                <div class="form-group row m-b-0">
                                    <div class="col-md-12 col-sm-12" style="text-align: center;">
                                        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Add" ValidationGroup="A" OnClick="btnAdd_Click" ToolTip="Add" />
                                        <asp:Button ID="btnUpdate" Visible="false" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Update" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <!-- end panel-body -->
                </div>
                <!-- end panel -->
            </div>
        </div>
        <!-- end col-6 -->
        <!-- end row -->
    </asp:Panel>
    <script type="text/javascript">
        var apiUrl = $("[id$='hdnApiurl']").val();
        $(document).ready(function () {
            <%--var id = 16;
            $('#<%=hfSelectedValue.ClientID%>').val(16);--%>
            $('#ddItems').change(function () {
                $('#<%=hfSelectedValue.ClientID%>').val($('#ddItems').val());
            });
            $.ajax({
                type: "GET",
                url: apiUrl+'/api/ItemGroupMasters/GetItemGroupMasters',
                dataType: "json", contentType: "application/json;charset=utf-8",
                success: function (data) {
                    var _binddata = "";
                    $.each(data, function (i) {
                        $('#ddItems').append($('<option></option>').val(data[i].GroupID).html(data[i].GroupName));
                    });
                    $('#ddItems').val($('#<%=hfSelectedValue.ClientID%>').val());
                }
            });
        });
    </script>

    <%--  <script  type="text/javascript">
        $(document).ready(function () {
 
            $('#<%=ddItems.ClientID%>').append(
                    $('<option></option>').val('0').html('Please Wait...')                    
                );
            $.ajax({
                url: 'http://localhost:62351/api/ItemGroupMasters',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: OnSuccess,
                error: OnError
            });
 
            // for get selected value from code behind
            $('#<%=ddItems.ClientID%>').change(function () {
                $('#<%=hfSelectedValue.ClientID%>').val($('#<%=ddItems.ClientID%>').val());
            });
 
        });
 
        function OnSuccess(data) {
            $('#<%=ddItems.ClientID%>').empty();
            var d = data.d;
            alert(d);
            var dropdown = $('#<%=ddItems.ClientID%>');
            for (var i = 0; i < d.length; i++) {
                dropdown.append(
                     $('<option></option>').val(d[i].GroupID.toString()).html(d[i].GroupName.toString())
                    );
            }
            //for keep data after postback
            $('#<%=ddItems.ClientID%>').val($('#<%=hfSelectedValue.ClientID%>').val());
        }
        function OnError() {
            alert("Failed!");
        }
 
    </script>--%>
</asp:Content>

