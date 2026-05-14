<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="printmanage.aspx.cs" Inherits="printmanage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">    
    <link type="text/css" rel="stylesheet" href="../assets/css/default/mystyle.css" />
    <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />
    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    
     <link href="../assets/css/default/style.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
        .modal-header {
            padding: 15px;
            border-bottom: 1px solid #e5e5e5;
            background: #1b82ec;
            color: #fff;
            padding-top: 0px;
            padding-bottom: 0px;
        }

        .modal-footer {
            padding: 15px;
            text-align: right;
            border-top: 1px solid #e5e5e5;
            background: #1b82ec;
            padding-bottom: 5px;
            padding-top: 5px;
        }

        .modal-xl {
            width: 80% !important;
            max-width: 1200px;
        }

        .modal-body {
            max-height: 80vh;
            overflow-x: hidden;
            overflow-y: scroll;
        }

        .close {
            float: right;
            font-size: 21px;
            font-weight: 700;
            line-height: 1;
            color: #fff;
            text-shadow: 0 1px 0 #fff;
            filter: alpha(opacity=20);
            opacity: 2;
        }
        .panel-heading-btn > a {
    margin-left: 8px;
    margin-top: 0;
}
        .btnspl {
            min-width: 217px;
            padding: 10px 50px;
        }

        .row {
            margin-right: 0px;
            margin-left: 0px;
        }
        .panel{
            padding: 0px;
        }
    </style>

    <style>
        #page-loader{
            display:none;
        }
        label {
    display: inline-block;
    margin-bottom: .5rem;
    float: left;
}
        .input-group {
    padding-bottom: 1em;
    float: left;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="panel panel-inverse">
        <div class="panel-heading">

            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">Sales Order Details </h4>




        </div>
        <div class="panel-body">
    <div class="col-md-12" style="margin-top: 10px; padding: 10px">

                <div class="form-group col-sm-3">
                    <div >
                        <input class="form-control" formcontrolname="printerModel" placeholder="Enter Model Name" style="text-transform: capitalize">

                    </div>
                </div>   
                <div class="form-group col-sm-3">
                    <div >
                        <input class="form-control" formcontrolname="printerTimeout" placeholder="Enter Timeout">
                    </div>
                </div>             
                 <div class="form-group col-sm-3">
                    <div >
                        <input class="form-control" formcontrolname="printCharacters" placeholder="Enter Characters">
                    </div>
                </div>
                 <div class="form-group col-sm-3">
                    <div >
                        <input class="form-control" formcontrolname="printerValue" placeholder="Enter IP">
                    </div>
                </div>                
                <div class="form-group col-sm-3">
                    <div >
                        <div  style=" margin-top: 30px; margin-left: 10px;">
                            <label  for="printerType" style="font-weight: bolder; width: 100px ;">Print Type :</label>
                       
                            <div class="input-group">
                                <input class="mdl-radio__button" formcontrolname="printerType" type="radio" value="usb">
                                <span class="mdl-radio__label">USB</span>
                                <input class="mdl-radio__button" formcontrolname="printerType" type="radio" value="lan">
                                <span class="mdl-radio__label">LAN</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    <div >
                        <div  style=" margin-top: 30px; margin-left: 10px;">
                            <label  for="printSize" style="font-weight: bolder; width: 100px;">Print Size :</label>
                       
                            <div class="input-group">
                                <input class="mdl-radio__button" formcontrolname="printSize" type="radio" value="58">
                                <span class="mdl-radio__label">58 mm</span>
                                <input class="mdl-radio__button" formcontrolname="printSize" type="radio" value="80">
                                <span class="mdl-radio__label">80 mm</span>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-group col-sm-3">
                    <div  style=" margin-top: 30px; margin-left: 10px;">
                        <label  for="lname" style="font-weight: bolder; width: 50px">KDS:</label>
                    
                        <div class="input-group">
                            <input class="mdl-radio__button" formcontrolname="kdsFlag" type="radio" value="true">
                            <span class="mdl-radio__label">Yes</span>
                            <input class="mdl-radio__button" formcontrolname="kdsFlag" type="radio" value="false">
                            <span class="mdl-radio__label">No</span>
                        </div>
                    </div>
                </div>
                   
 </div>
    <div class="stepandbutton text-center center-block">  
                <div class="globalbuttoncell" style="display: inline-block">
                    <input class="btn btn-md btn-dark" type="button" value="Back" />
                    <input class="btn btn-md btn-danger" type="button" value="SAVE" />
                </div>
            </div>
        </div>
            </div>
</asp:Content>

