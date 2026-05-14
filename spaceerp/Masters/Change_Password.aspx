<%@ Page Title="" Language="C#"  MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Change_Password.aspx.cs" Inherits="Masters_Change_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">

    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <asp:Panel class="tbl" ID="tblmain" runat="server">
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
                        <h4 class="panel-title">Change Password</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">

                        <div class="form-group row m-b-15">

                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">Current Password * :</label>
                                <asp:Label ID="lblPass" runat="server" Visible="false"></asp:Label>
                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCurrentPassword" ErrorMessage="Please fill out this field!" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">New Password * :</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RFV2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please fill out this field!" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>

                            </div>
                             <div class="col-md-3 col-sm-3" style="margin-top:30px;">
                                <asp:Button ID="btnShowPass" runat="server" CssClass="btn btn-primary" Text="Show" ValidationGroup="B"  OnClick="btnShowPass_Click"   ToolTip="Show Password" />

                            </div>
                        </div>
                        <div class="form-group row m-b-15">
                            <div class="col-md-3 col-sm-3">
                                <label class="col-form-label" for="email">Confirm Password * :</label>
                                <asp:TextBox ID="txtPassConfirm" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassConfirm" ErrorMessage="Please fill out this field!" Display="Dynamic" SetFocusOnError="True" ValidationGroup="A"></asp:RequiredFieldValidator>
                                
                                <asp:CompareValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="txtPassConfirm"
                                    CssClass="ValidationError"
                                    ControlToCompare="txtPassword"
                                    ErrorMessage="No Match"
                                    ToolTip="Password must be the same" ValidationGroup="A" />

                            </div>
                        </div>

                        <div class="form-group row m-b-0">
                            <div class="col-md-3 col-sm-3" style="text-align: center;">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="A" OnClick="btnUpdate_Click" ToolTip="Save" />


                            </div>
                        </div>
                    </div>
                    <!-- end panel -->

                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->

        </div>
        <!-- end row -->

    </asp:Panel>
</asp:Content>

