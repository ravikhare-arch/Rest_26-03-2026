<%@ Page Title="" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="Door_delievery.aspx.cs" Inherits="Door_delievery" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

    <!--//skycons-icons-->
    <style>
        #page-loader {
            display: none;
        }

        .stats-left {
            float: left;
            width: 100%;
            /*padding: 0px;*/
        }

            .stats-left p {
                color: white;
            }

        .stats-right {
            float: right;
            width: 100%;
            padding: 0.28em;
        }

        p {
            margin: 0;
        }

        .widget {
            width: 33.33333333%;
            padding: 5px;
        }
        .spltab {
  height: 60px;
  width: 100%;
  padding: 12px;
  vertical-align: middle;
  line-height: 20px;
  font-weight: bold;
  text-align: center;
  text-decoration: none;
  background-color: rgba(244, 67, 54, 0);
  color: #cccccc;
    border-left: 5px solid #cccccc;
  border-radius: 7px; 
  margin:5px 0px;
        }
       .spltab.active{
           color: #e04545;
  border-left: 5px solid #2a2c93;
       }
  input[type="submit"]{
      margin-top: 0;
      font-size: 0.8em;
  }
  .btn{
      margin: 2px 0;
  }
  .topsrch{
  background: #ededed url(https://static.tumblr.com/ftv85bp/MIXmud4tx/search-icon.png) no-repeat 9px center;
  border: solid 1px #ccc;
  padding: 9px 10px 9px 32px;
  width: 50px;
  border-radius: 10em;
  transition: all .5s; }
    </style>
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div class="col-md-12 well">
      <div class="col-md-7">          
          <input class="form-control topsrch" id="Destopsearch" onblur="this.placeholder = ''" onfocus="this.placeholder = 'Search Item Name (Ex: Aloo Gobi)'" style="width:450px" type="search" placeholder="">
      
          </div>
      <div class="col-md-5">
          <div class="col-md-3">
          <div class="colpsbox_one_top" style="padding-left:40px;">
              <div class="icon_corner">
                 <i class="material-icons">event_seat</i>                  
              </div>
              <span>Table: 1</span>&nbsp;
              </div>
              </div>
          <div class="col-md-3">
          <div class="colpsbox_one_top" style="padding-left:40px;">
              <div class="icon_corner">
                  <i class="material-icons">local_dining</i>                  
              </div>
              <span>Dine In</span>&nbsp;
              </div>
              </div>
          <div class="col-md-2">
          <div class="colpsbox_one_top" style="padding-left:40px;">
              <div class="icon_corner">
                  <i class="material-icons"> assignment </i>                  
              </div>
              <span></span>&nbsp;
              </div>
              </div>
          <div class="col-md-4">
          <div class="colpsbox_one_top" style="padding-left:40px;">
              <div class="icon_corner">
                  <i class="material-icons"> access_time </i>                  
              </div>
              <span><%--<span class="clock">
            <span id="time"></span>
            <span id="date"></span>
          </span>--%></span>&nbsp;
              </div>
              </div>
      </div>
  </div>
      <div class="col-md-2">
        <div class="scroll-box" style="width: 100%; float: left; height: 500px;">
            <!--custom-widgets-->
            <div class="custom-widgets">
                <div class="row-one">                    
                        <div id ="Itemgroup">
                            
                        </div>
                  
                        <div class="clearfix"></div>     
                    </div>
                  </div>
                </div>
    </div>
    <div class="col-md-5">
        <div class="scroll-box" style="width: 100%; float: left; height: 500px;">
            <!--custom-widgets-->
            <div class="custom-widgets">
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-one">
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="col-md-4 widget">
                        <div class="stats-left ">
                            <p>Aalo jeera (half) </p>
                        </div>
                        <div class="stats-right">
                            <p class="text-danger">(Rs. 250)</p>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div class="clearfix"></div>
                </div>
            </div>

        </div>
    </div>
    <div class="col-md-5">
        <div class="scroll-box" style="width: 100%; float: left; height: 320px;">
            <table class="table cart-table table-responsive-xs">
                <thead>
                    <tr class="table-head">
                        <th scope="col">Item Name</th>
                        <th scope="col">Unit Price</th>
                        <th scope="col">Quantity</th>
                        <th scope="col">Action</th>
                        <th scope="col">Total</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <tbody>
                    <tr>
                        <td>
                            <a href="#">Aalo jeera (half)</a>                            
                        </td>

                        <td>$31.50
                        </td>
                        <td class="ng-tns-c8-2">
                            <!---->
                            <div class="ng-tns-c8-2 ">
                                <span class="qty-input">
                                    <span class="input-group-prepend">
                                    <button class="quantity-left-minus">-</button></span>
                                    <input style="width: 29px;" class="input-number" value="3">
                                    <span class="input-group-prepend">
                                    <button class="quantity-right-plus">+</button></span>
                                    </span>
                            </div>
                            <!---->
                        </td>
                        <%--<td>
                                                <div class="qty-box">
                                                    <div class="input-group">
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="minus" class="btn quantity-left-minus">
                                                                <i class="fa fa-plus"></i></button></span>
                                                        <input type="numeric" value="3" name="quantity" class="form-control input-number ng-untouched ng-pristine" />
                                                        <span class="input-group-prepend">
                                                            <button type="button" data-type="plus" class="btn quantity-right-plus">
                                                                <i class="fa fa-minus"></i></button></span>
                                                    </div>
                                                </div>
                                            </td>--%>
                        <td>
                            <a href="javascript:void(0)" class="icon"><i class="fa fa-times"></i></a>
                        </td>
                        <td>$63.00 
                        </td>
                    </tr>
                </tbody>
                <!---->
            </table>
            </div>
            <table class="table cart-table table-responsive-md">
                <tfoot>
                    <tr>
                        <td>Dish Total Amount (Rs.) :</td>
                        <td>$189.00
                        </td>
                    </tr>
                </tfoot>
            </table>
        <div class=" col-md-12 text-center">               
                <asp:Button Text="Save KOT" runat="server" CssClass="btn btn-primary" ID="Button1" />
            <asp:Button ID="Button3" CssClass="btn btn-primary" runat="server" Text="Print & Save KOT" />
                <asp:Button ID="Button2" CssClass="btn btn-primary" runat="server" Text="Print/ View Bill" />
                <asp:Button ID="Button5" CssClass="btn btn-primary" runat="server" Text="Print Bill" />
                <asp:Button ID="Button4" CssClass="btn btn-primary" runat="server" Text="Reprint" />

            </div>
    </div>
    <script src="../assets/plugins/dropdown-autocomplete/Scripts/jquery.min.js"></script>
    <script id="rendered-js">
        $('.visibility-cart').on('click', function () {

            var $btn = $(this);
            var $cart = $('.cart');
            console.log($btn);

            if ($btn.hasClass('is-open')) {
                $btn.removeClass('is-open');
                $btn.text('O');
                $cart.removeClass('is-open');
                $cart.addClass('is-closed');
                $btn.addClass('is-closed');
            }
            else {
                $btn.addClass('is-open');
                $btn.text('X');
                $cart.addClass('is-open');
                $cart.removeClass('is-closed');
                $btn.removeClass('is-closed');
            }


        });

        // SHOPPING CART PLUS OR MINUS
        $('.input-group-prepend .quantity-left-minus').on('click', function (e) {
            e.preventDefault();
            var $this = $(this);
            var $input = $this.closest('div').find('input');
            var value = parseInt($input.val());

            if (value > 1) {
                value = value - 1;
            } else {
                value = 0;
            }

            $input.val(value);

        });

        $('.input-group-prepend .quantity-right-plus').on('click', function (e) {
            e.preventDefault();
            var $this = $(this);
            var $input = $this.closest('div').find('input');
            var value = parseInt($input.val());

            if (value < 100) {
                value = value + 1;
            } else {
                value = 100;
            }

            $input.val(value);
        });

        // RESTRICT INPUTS TO NUMBERS ONLY WITH A MIN OF 0 AND A MAX 100
        $('input').on('blur', function () {

            var input = $(this);
            var value = parseInt($(this).val());

            if (value < 0 || isNaN(value)) {
                input.val(0);
            } else if (
            value > 100) {
                input.val(100);
            }
        });
        //# sourceURL=pen.js
    </script>
    <%--closing row script--%>
    <script id="rendered-js">
        // Remove Items From Cart
        $('a.icon').click(function () {
            event.preventDefault();
            $(this).parent().parent().parent().hide(400);

        });

        // Just for testing, show all items
        $('a.btn.continue').click(function () {
            $('li.items').show(400);
        });
        //# sourceURL=pen.js
    </script>
    <script>
        /* 20. Clock */
        function getDate() {
            var date = new Date();
            var weekday = date.getDay();
            var month = date.getMonth();
            var day = date.getDate();
            var year = date.getFullYear();
            var hour = date.getHours();
            var minutes = date.getMinutes();
            var seconds = date.getSeconds();
            if (hour < 10) hour = "0" + hour;
            if (minutes < 10) minutes = "0" + minutes;
            if (seconds < 10) seconds = "0" + seconds;
            var monthNames = ["January", "February", "Sep", "April", "May", "June", "July", "August",
                "September", "October", "December", "December"
            ];
            var weekdayNames = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday",
                "Saturday"
            ];
            var ampm = " PM ";
            if (hour < 12) ampm = " AM ";
            if (hour > 12) hour -= 12;
            var showDate = weekdayNames[weekday] + ", " + monthNames[month] + " " + day + ", " + year;
            var showTime = hour + ":" + minutes + ":" + seconds + ampm;
            document.getElementById('date').innerHTML = showDate;
            document.getElementById('time').innerHTML = showTime;
            requestAnimationFrame(getDate);
        }
        getDate();
    </script>
    <script>
        $(document).ready(function () {
            $(".spltab").click(function () {
                $(".spltab").removeClass("active");
                $(this).addClass("active");
            });
        });
    </script>
</asp:Content>


