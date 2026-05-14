<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="Masters_UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="../assets/plugins/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
     <%-- <style>
          .row{
              margin:0px 0px;
          }
        .content-page .content {
            margin-left: auto;
            margin-right: auto;
            display: block;
            margin-top:0px;
            margin-bottom:0px;
        padding:0px;
        }
        .enlarged #wrapper .content-page {
            margin-left: 0px;
        }
        .topbar {
            display: none;
        }

        .footer {
            display: none;
        }
        .side-menu {
            display: none;
        }
    </style>--%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <asp:HiddenField ID="hidcount" runat="server" />
     <asp:Panel ID="tblmain" runat="server">
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
                        <h4 class="panel-title">User Access Management</h4>
                    </div>
                    <!-- end panel-heading -->
                    <!-- begin panel-body -->
                    <div class="panel-body">
                        <div>&nbsp;</div>
                        <div class="form-group row m-b-15">
                            <label class="col-md-4 col-sm-4 col-form-label" for="email">
                                User
                            </label>
                            <div class="col-md-8 col-sm-8">
                                <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddlUser_SelectedIndexChnage"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFV4" runat="server" ControlToValidate="ddlUser" ErrorMessage="Please fill out this field! " Display="Dynamic" SetFocusOnError="True" InitialValue="0" ValidationGroup="A"></asp:RequiredFieldValidator>
                            </div>
                        </div>

                         <div class="form-group row m-b-12" style="overflow:auto;height:900px;">
                            <asp:Table ID="usertab" runat="server" CssClass="fmdGrid" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell><b>Menu Links</b></asp:TableCell>
                                    <asp:TableCell></asp:TableCell>
                                    <asp:TableCell></asp:TableCell>

                                </asp:TableRow>
                            </asp:Table>
                        </div>
                        <div class="form-group row m-b-0">
                           <%-- <label class="col-md-4 col-sm-4 col-form-label">
                                &nbsp;</label>--%>
                            <div class="text-center mt-2" style="display: block;margin-left: auto;margin-right: auto;">
                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btnspl" Text="Configure" ValidationGroup="A"
                                    OnClick="btnAdd_Click" ToolTip="Add" Visible="false" />
                            </div>
                        </div>

                    </div>
                    <!-- end panel-body -->
                </div>
                <!-- end panel -->
            </div>
            <!-- end col-6 -->
            <div class="col-lg-12">
            </div>
        </div>
        <!-- end row -->
        <div class="row">
            <!-- begin col-6 -->

            <!-- end col-6 -->
        </div>
    </asp:Panel>


</asp:Content>

