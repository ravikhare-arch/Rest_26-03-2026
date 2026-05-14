<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PrintMaster.master" CodeFile="rptvisa_invoice.aspx.cs" Inherits="TradeInventory_rptvisa_invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="content" class="content" style="color: black">
        <!-- begin breadcrumb -->
        <ol class="breadcrumb hidden-print pull-right">
            <li class="breadcrumb-item"><a href="javascript:;">Home</a></li>
            <li class="breadcrumb-item active">Invoice</li>
        </ol>
        <!-- end breadcrumb -->
        <!-- begin page-header -->
        <h1 class="page-header hidden-print">Invoice <small>header small text goes here...</small></h1>
        <!-- end page-header -->

        <!-- begin invoice -->
        <div class="invoice">
            <!-- begin invoice-company -->
            <div class="invoice-company text-inverse f-w-600">
                <span class="pull-right hidden-print">
                    <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-file-pdf t-plus-1 text-danger fa-fw fa-lg"></i>Export as PDF</a>
                    <a href="javascript:;" onclick="window.print()" class="btn btn-sm btn-white m-b-10 p-l-5"><i class="fa fa-print t-plus-1 fa-fw fa-lg"></i>Print</a>
                </span>
                Space Knights Tours and Travels
               
            </div>
            <!-- end invoice-company -->
            <!-- begin invoice-header -->
            <div class="invoice-header">
                <div class="invoice-from">
                    <small>from</small>
                    <address class="m-t-5 m-b-5">
                        <strong class="text-inverse">Twitter, Inc.</strong><br />
                        Street Address<br />
                        City, Zip Code<br />
                        Phone: (123) 456-7890<br />
                        Fax: (123) 456-7890
                       
                    </address>
                </div>
                <div class="invoice-to">
                    <small>to</small>
                    <address class="m-t-5 m-b-5">
                        <strong class="text-inverse">Company Name</strong><br />
                        Street Address<br />
                        City, Zip Code<br />
                        Phone: (123) 456-7890<br />
                        Fax: (123) 456-7890
                       
                    </address>
                </div>
                <div class="invoice-date">
                    <div class="date text-inverse m-t-5">Invoice No.: </div>

                    <div class="invoice-detail">
                        0000123DSS
                    </div>
                    <div class="date text-inverse m-t-5">Date:</div>
                    <div class="invoice-detail">
                        03/08/2018
                    </div>
                    <div class="date text-inverse m-t-5">GST No.:</div>
                    <div class="invoice-detail">
                        27BMXPA6006N1ZL
                    </div>

                </div>
            </div>
            <!-- end invoice-header -->
            <!-- begin invoice-content -->
            <div class="invoice-content">
                <!-- begin table-responsive -->
                <div class="table-responsive">
                    <table class="table table-bordered">
                        <thead>
                            <tr>
                                <th>SR NO</th>
                                <th class="text-center" width="10%">TICKET NO</th>
                                <th class="text-center" width="20%">PASSENGER NAME</th>
                                <th class="text-right" width="10%">SECTOR</th>
                                <th class="text-center" width="20%">FLIGHT DETAILS</th>
                                <th class="text-center" width="10%">BASICS</th>
                                <th class="text-right" width="10%">IGST 18%</th>
                                <th class="text-right" width="20%">FARE AMOUNT</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1
                                </td>
                                <td class="text-center">607 53 56763476</td>
                                <td class="text-center">MR. ALAMGEER</td>
                                <td class="text-center">DEL - AUH</td>
                                <td class="text-center">EY 229 (EITHAD AIRWAYS)</td>
                                <td class="text-center">16895</td>
                                <td class="text-center"></td>
                                <td class="text-center">16895</td>
                            </tr>
                            <tr>
                                <td colspan="8"></td>
                            </tr>
                            <tr>
                                <td colspan="7" class="text-right font-weight-bold">SUB TOTAL
                                </td>
                                <td class="text-center font-weight-bold">16895
                                </td>

                            </tr>
                        </tbody>
                    </table>
                </div>
                <!-- end table-responsive -->
                <!-- begin invoice-price -->
                <div class="invoice-price">
                    <div class="invoice-price-left">
                        <div class="invoice-price-row">
                            <div class="sub-price">
                                <small>SUB TOTAL</small>
                                <span class="text-inverse">16895</span>
                            </div>
                            <div class="sub-price">
                                <i class="fa fa-plus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>TAX</small>
                                <span class="text-inverse">236</span>
                            </div>
                            <div class="sub-price">
                                <i class="fa fa-minus text-muted"></i>
                            </div>
                            <div class="sub-price">
                                <small>DISCOUNT</small>
                                <span class="text-inverse">131</span>
                            </div>
                        </div>
                    </div>
                    <div class="invoice-price-right">
                        <small>TOTAL</small> <span class="f-w-600">17000</span>
                    </div>
                </div>
                <!-- end invoice-price -->
                <!-- end Bank Details -->

            </div>

            <!-- end invoice-content -->
            <div class="invoice-note">
                <div class="row">
                    <div class="col-md-8">
                        <strong>Note:</strong>
                        <br />
                        * Make all cheques payable to [SPACE KNIGHTS TOURS AND TRAVELS]<br />
                        * Payment is due within 30 days<br />
                        * If you have any questions concerning this invoice, contact [Name, Phone Number, Email]
                    </div>

                    <div class="col-md-4">
                        <table class="table table-bordered">

                            <tr>
                                <td colspan="2" class="text-center">BANK DETAILS</td>
                            </tr>
                            <tr>
                                <td colspan="2" class="text-center">SPACE KNIGHTS TOURS AND TRAVELS</td>
                            </tr>
                            <tr>
                                <td>BANK NAME</td>
                                <td>INDUSLAND BANK</td>
                            </tr>
                            <tr>
                                <td>BRANCH NAME</td>
                                <td>GHATKOPER BRANCH</td>
                            </tr>
                            <tr>
                                <td>ACCOUNT NO.</td>
                                <td>201002266375</td>
                            </tr>
                            <tr>
                                <td>IFSC CODE</td>
                                <td>INDB0000152</td>
                            </tr>

                        </table>

                    </div>

                </div>
            </div>
            <!-- begin invoice-note -->

            <!-- end invoice-note -->
            <!-- begin invoice-footer -->
            <div class="invoice-footer">
                <p class="text-center m-b-5 f-w-600">
                    THANK YOU FOR YOUR BUSINESS
                   
                </p>
                <p class="text-center">
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-globe"></i>matiasgallipoli.com</span>
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-phone-volume"></i>T:016-18192302</span>
                    <span class="m-r-10"><i class="fa fa-fw fa-lg fa-envelope"></i>rtiemps@gmail.com</span>
                </p>
            </div>
            <!-- end invoice-footer -->
        </div>
        <!-- end invoice -->
    </div>
</asp:Content>
