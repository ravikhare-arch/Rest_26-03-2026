<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="OnlineOrder.aspx.cs" Inherits="Agent_OnlineOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel='stylesheet' type='text/css' />

    <!-- Custom CSS -->
    <link href="css/style.css" rel='stylesheet' type='text/css' />
    <!-- Graph CSS -->
    <link href="css/font-awesome.css" rel="stylesheet">
    <!-- jQuery -->
    <!-- Graph CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <!-- jQuery -->
    <link href='//fonts.googleapis.com/css?family=Roboto:700,500,300,100italic,100,400' rel='stylesheet' type='text/css'>
    <!-- lined-icons -->
    <link rel="stylesheet" href="css/icon-font.min.css" type='text/css' />
    <link href="../css/customdash.css" rel="stylesheet" />
    <style>
        #page-loader{
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
                        <div class="splbar">
                            <div class="text-center center-block">
                                <a class="tabspl" onclick="openCity('8')">Placed</a>
                                <a class="tabspl active" onclick="openCity('9')">In Progress</a>
                                <a class="tabspl" onclick="openCity('10')">Completed</a>
                                <a class="tabspl" onclick="openCity('11')">Cancelled</a>
                                <a class="tabspl" onclick="openCity('12')">InFuture</a>
                            </div>
                        </div>
                        <table class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>Order Id</th>
                                    <th>Placed At</th>
                                    <th>Delivery Time</th>
                                    <th>Channel Name</th>
                                    <th>Order Status</th>
                                    
                                    <th class="ng-tns-c12-13 ng-star-inserted">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                
                            </tbody>                            
                        </table>
</asp:Content>

