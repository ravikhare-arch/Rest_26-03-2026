<%@ Page Title="Closing Sales Report" Language="C#" MasterPageFile="~/Pagecontent.master" AutoEventWireup="true" CodeFile="ClosingSalesReport.aspx.cs" Inherits="ClosingSalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />

    <link type="text/css" rel="stylesheet" href="../../assets/css/default/mystyle.css" />
    <link href="../../assets/css/default/style.min.css" rel="stylesheet" />
    <%--<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>--%>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.3/umd/popper.min.js" integrity="sha384-vFJXuSJphROIrBnz7yo7oB41mKfc8JzQZiCq4NCceLEaO4IHwicKwpJf9c9IpFgh" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" rel="stylesheet" />

    <%--<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link href="../../css/customDataTable.css" rel="stylesheet" />


   

    <link href="http://cdn.syncfusion.com/19.3.0.43/js/web/flat-azure/ej.web.all.min.css" rel="stylesheet" />


    <script src="http://cdn.syncfusion.com/19.3.0.43/js/web/ej.web.all.min.js"></script>
    <style>
        /*.table>thead:first-child>tr:first-child>td{            
            width: auto !important;
        }*/
        #div1, #div2 {
            width: 100% !important;
        }
    </style>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <input type="hidden" runat="server" id="hdnApiurl" />
    <asp:HiddenField ID="hdnCompName" runat="server" />
<asp:HiddenField ID="hdnCompAddress" runat="server" />
<asp:HiddenField ID="hdnCompContact" runat="server" />
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <div class="panel panel-inverse">
        <div class="panel-heading">

            <div class="panel-heading-btn pull-left">

                <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-info btn-xs">ADD</asp:LinkButton>

            </div>
            <div class="panel-heading-btn">
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-default" data-click="panel-expand"><i class="fa fa-expand"></i></a>
                <a href="javascript:;" class="btn btn-xs btn-icon btn-circle btn-warning" data-click="panel-collapse"><i class="fa fa-minus"></i></a>
            </div>

            <h4 class="panel-title text-center">
                <label id="lblheading"></label>
            </h4>




        </div>
        <div class="panel-body">
            <div class="clearfix row form-group">
                <div class="col-md-12 col-md-push-1">
                    <div class="col-md-2">
                        <label class="col-form-label" for="fullname">
                            Order Type
                        </label>
                        <asp:DropDownList ID="ddlordertype" runat="server" CssClass="form-control js-example-placeholder-single">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <label class="col-form-label" for="fullname">
                            Mode of Payment
                        </label>
                        <asp:DropDownList ID="ddlpaymode" runat="server" CssClass="form-control js-example-placeholder-single">
                            <asp:ListItem Text="ALL" Value="0"></asp:ListItem>
                            <asp:ListItem Text="CASH" Value="CASH"></asp:ListItem>
                            <asp:ListItem Text="CARD" Value="CARD"></asp:ListItem>
                            <asp:ListItem Text="PAYTM" Value="PAYTM"></asp:ListItem>
                            <asp:ListItem Text="PHONEPE" Value="PHONEPE"></asp:ListItem>
                            <asp:ListItem Text="NC" Value="NC"></asp:ListItem>
                            <asp:ListItem Text="Room Serv" Value="Room Serv"></asp:ListItem>
                            <asp:ListItem Text="GPAY" Value="GPAY"></asp:ListItem>
                        </asp:DropDownList>
                    </div>


                  <div class="col-md-2">
    <label for="fromdate" class="col-form-label">From Date</label>
    <input type="datetime-local" id="fromdate" class="form-control" />
</div>
<div class="col-md-2">
    <label for="todate" class="col-form-label">To Date</label>
    <input type="datetime-local" id="todate" class="form-control" />
</div>
                   
                    <div class="col-md-2">
                        <label class="col-form-label">&nbsp;</label>
                        <input type="button" id="btnsearch" class="btn btn-primary form-control mt-3" style="background-color: #004080" title="Search" value="Search" />
                    </div>
                </div>

            </div>
            <%--<div class="clearfix row form-group">
                <div class="col-sm-12 text-center center-block well-sm pad-20" id="divprint">
                    <asp:Button Text="Export To Excel" runat="server" CssClass="btn btn-primary" ID="btnexcel" OnClick="btnexcel_Click" />
                </div>
            </div>--%>
            <div class="clearfix row form-group">
    <div class="col-sm-12 well-sm pad-20" id="divprint" style="display: flex; justify-content: space-between; align-items: center; flex-wrap: wrap;">
        
        <!-- Left Side: Export Button -->
        <div class="export-left" style="display: flex; gap: 10px; align-items: center;">
            <span style="font-weight:bold;">Export :</span>
            <asp:Button Text="Excel" runat="server" CssClass="btn btn-success" ID="btnexcel" OnClick="btnexcel_Click" style="font-weight: 700; padding: 6px 20px;" />
            <!-- Agar PDF ka button banana ho toh yahan add kar lena -->
        </div>

        <!-- Right Side: Company Info UI -->
        <div id="companySummaryUI" class="text-right" style="font-size: 12px; color: #333; line-height: 1.4; font-weight: 500; text-align: right;">
            <!-- Data JS ke through aayega -->
        </div>

    </div>
</div>
            <div id="wrapper1">
                <div id="div1">
                </div>
            </div>
            <div id="wrapper2">
                <div id="div2">
                    <div id="divpendingorders"></div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="deleteModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="background: #C0C0C0">
                <div class="modal-header">
                    <h5 class="modal-title" id="delModalLongTitle" style="color: white">Cancel Order</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <label style="color: black" id="lbldelete">Are you sure you want to Cancel Order?</label>
                    <label style="color: black; display: none;" id="lblsucess">Order Cancelled..!!!</label>


                    <label id="orderid" style="display: none"></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="deletebutton">Cancel</button>

                </div>
            </div>
        </div>
    </div>

  <script type="text/javascript">


      var storedData = localStorage.getItem("CompanyListObj"); // Agar localStorage use kiya toh localStorage likhna

      if (storedData) {
          // String ko wapas JSON array/object me convert kiya
          var companyDataArray = JSON.parse(storedData);
          console.log(companyDataArray);

          // Ab tum is loop chala ke bind kar sakte ho dropdown ya table jahan bhi karna hai
      } else {
          console.log("Data nahi mila bhai, pehle main page visit karna padega.");
      }
      // 1. Global Variables for Company Data
      var compName = "", compAddress = "", compCity = "", compContact = "";
      var apiUrl = $("[id$='hdnApiurl']").val();

      $(document.body).ready(function () {




          var storedData = sessionStorage.getItem("CompanyListObj") || localStorage.getItem("CompanyListObj");

          if (storedData) {
              // String ko wapas JSON array/object me convert kiya
              var companyDataArray = JSON.parse(storedData);
              console.log("Data mil gaya bhai: ", companyDataArray);

              if (companyDataArray.length > 0) {
                  var comp = companyDataArray[0];
                  compName = comp.Name || "";
                  compAddress = comp.Address || "";
                  compCity = comp.City || "";
                  compContact = comp.Contactno || "";

                  // UI ke liye HTML format
                  var uiHtml = "<strong style='color: #004080; font-size:14px;'>" + compName + "</strong><br/>" +
                      compAddress + ", " + compCity + "<br/>" +
                      "<i class='fa fa-phone'></i> " + compContact;

                  $("#companySummaryUI").html(uiHtml);

                  // Hidden fields me set karna taaki C# (backend) Excel export me use kar sake
                  $("[id$='hdnCompName']").val(compName);
                  $("[id$='hdnCompAddress']").val(compAddress + ", " + compCity);
                  $("[id$='hdnCompContact']").val(compContact);

                  // Export (Excel/PDF) ke liye Plain Text format
                  exportMessage = compAddress + ", " + compCity + "\nMobile: " + compContact;
              }
          } else {
              console.log("Dono me se kisi bhi storage me data nahi hai bhai, pehle main page visit karna padega.");
          }



          $("#btnsearch").on("click", function () {
              loaddata();
          });
      });

      // Is function ko thoda clean kiya hai taaki HTML5 format (YYYY-MM-DDTHH:mm) ko handle kare
      function convertstringtodate(str) {
          if (!str) return "";
          var date = new Date(str);
          var mnth = ("0" + (date.getMonth() + 1)).slice(-2);
          var day = ("0" + date.getDate()).slice(-2);
          var hours = ("0" + date.getHours()).slice(-2);
          var minutes = ("0" + date.getMinutes()).slice(-2);
          var seconds = ("0" + date.getSeconds()).slice(-2);

          var sqldate = [date.getFullYear(), mnth, day].join("-");
          var sqltime = [hours, minutes, seconds].join(":");
          return [sqldate, sqltime].join(" ");
      }

      function loaddata() {
          var apiUrl = $("[id$='hdnApiurl']").val();
          var orderType = $("#ctl00_ContentPlaceHolder1_ddlordertype").val();

          // HTML5 date picker se direct value uthayenge
          var newstartDate = $("#fromdate").val();
          var newendDate = $("#todate").val();

          if (!newstartDate || !newendDate) {
              alert("Please select both From and To dates.");
              return;
          }

          var startDate = convertstringtodate(newstartDate);
          var endDate = convertstringtodate(newendDate);
          var payMode = $("#ctl00_ContentPlaceHolder1_ddlpaymode").val();

          $.ajax({
              url: apiUrl + '/api/Item/ClosingSalesOrder?orderType=' + orderType + '&startDate=' + startDate + '&endDate=' + endDate + '&payMode=' + payMode,
              type: "GET",
              contentType: "application/json;charset=utf-8",
              dataType: "json",
              success: function (data) {
                  var vcount = 0;
                  var html = "<table id='tblagentlist' class='table table-striped table-bordered table-responsive' style='width:100%'><thead><tr><td style='width:2%'>Sr No.</td><td>Order Date & Time</td><td>Order Type</td><td>Item Name</td><td>Actual Cost</td><td>Product Qty</td><td>CGST</td><td>SGST</td><td>Grand Total</td><td>Payment Mode</td></tr></thead><tbody>";

                  $.each(data, function (i) {
                      vcount = vcount + 1;
                      html += "<tr>";
                      html += "<td> " + vcount + "</td>";
                      html += "<td> " + data[i].OrderDateTime + "</td>";
                      html += "<td> " + data[i].OrderTypeName + "</td>";
                      html += "<td> " + data[i].ProductName + "</td>";
                      html += "<td> " + data[i].ActualCost + " </td>";
                      html += "<td> " + data[i].ProductQty + "</td>";
                      html += "<td> " + data[i].SGST + " </td>";
                      html += "<td> " + data[i].CGST + "</td>";
                      html += "<td> " + data[i].GrandTotal + "</td>";
                      html += "<td> " + data[i].PayMode + "</td>";
                      html += "</tr>";
                  });

                  html += "</tbody><tfoot><tr><th colspan='4' style='text-align:right;'> Total</th><th> </th><th> </th><th> </th><th> </th><th> </th><th> </th></tr></tfoot></table>";

                  $("#divpendingorders").html(html);

                  // DataTable re-initialization
                  $("#tblagentlist").DataTable({
                      "aLengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
                      "iDisplayLength": 5,
                      "paging": true,
                      "footerCallback": function (row, data, start, end, display) {
                          var api = this.api();
                          var intVal = function (i) {
                              return typeof i === 'string' ? i.replace(/[\$,]/g, '') * 1 : typeof i === 'number' ? i : 0;
                          };

                          // Calculation logic (Same as before)
                          var col5 = api.column(5).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                          var col6 = api.column(6).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                          var col7 = api.column(7).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);
                          var col8 = api.column(8).data().reduce(function (a, b) { return intVal(a) + intVal(b); }, 0);

                          $(api.column(5).footer()).html(col5);
                          $(api.column(6).footer()).html(col6);
                          $(api.column(7).footer()).html(col7);
                          $(api.column(8).footer()).html(col8);
                      }
                  });
              },
              error: function (err) {
                  console.log(err);
                  alert("Error loading data!");
              }
          });
      }
  </script>
    <script>
        $(document).ready(function () {
            $('#tblagentlist').DataTable({
                "scrollY": 200,
                "scrollX": true
            });


        });
    </script>
    <script>
        var wrapper1 = document.getElementById('wrapper1');
        var wrapper2 = document.getElementById('wrapper2');
        wrapper1.onscroll = function () {
            wrapper2.scrollLeft = wrapper1.scrollLeft;
        };
        wrapper2.onscroll = function () {
            wrapper1.scrollLeft = wrapper2.scrollLeft;
        };
    </script>
</asp:Content>
