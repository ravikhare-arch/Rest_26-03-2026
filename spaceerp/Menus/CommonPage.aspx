<%@ Page Title="" Language="C#" MasterPageFile="~/pagecontent.master" AutoEventWireup="true" CodeFile="CommonPage.aspx.cs" Inherits="Menus_CommonPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Graph CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <link href="../css/custom_bundle.css" rel="stylesheet" />
    <link href="../css/CommonBootstrap.css" rel="stylesheet" />
   <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <style>
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
     
    </style>
    <link href="../css/customize-model.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        #sitemap li a {
            font-size: 15px;
            letter-spacing: 1.2px;
        }

        #sitemap li li a {
            letter-spacing: 0.5px;
        }
    </style>
    
    <script type="text/javascript" src="../assets/js/sitemap.js"></script>

    <div class="fmhead" style="margin-bottom: 0px;">
        <asp:Label ID="lblMenuTitle" runat="server"></asp:Label>
    </div>
    <%--  <div class="parentmenucards row" style="margin-left: -12px;">
        <div class="col-md-4 col-xs-12 menucards" style="margin-left: 0px;">
            <div class="card">
                <div class="card-header"><span class="card-title">Sales</span></div>
                <div class="card-block">
                    <ul>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 1</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 2</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 3</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="col-md-4 col-xs-12 menucards" style="margin-left: 0px;">
            <div class="card">
                <div class="card-header"><span class="card-title">Accounts</span></div>
                <div class="card-block">
                    <ul>
                         <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 1</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 2</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 3</a></li>
                    </ul>
                </div>
            </div>
        </div>
         <div class="col-md-4 col-xs-12 menucards" style="margin-left: 0px;">
            <div class="card">
                <div class="card-header"><span class="card-title">HR</span></div>
                <div class="card-block">
                    <ul>
                         <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 1</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 2</a></li>
                        <li><span class="fa fa-caret-right menuicon"></span><a href='../'>Test 3</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="fmhead" style="margin-bottom: 0px;">
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>
    <asp:Label ID="lblMenu" runat="server"></asp:Label>
    <asp:Button ID="tempButton" runat="server" Text="Display" Style="display: none;" />
   <script>
       $("body").on("click", ".read", function () {
           var id = $(this).data('id');
           ('#' + id).modal('toggle');
       });
   </script>
    <script type="text/javascript">

    $(document).ready(function () {
        $.ajaxSetup({ cache: false });

        initialiseModals();
    });

    function initialiseModals() {

      $('#" + dr.GetValue(2).ToString() + "').on('shown.bs.modal', function () {
        $.validator.unobtrusive.parse($('#" + dr.GetValue(2).ToString() + "'));
      });

        $(document).on('click', '*[data-modalload]', function () {
            var e = $(this);

            if (e.data('submittext') != undefined) {
              $('#btnModalSave').html(e.data('submittext'));
            } else $('#btnModalSave').html('Save');

            if (e.data('class') != undefined) {
                var cls = e.data('class');
                $('#" + dr.GetValue(2).ToString() + "').removeClass(cls).addClass(cls);
            }
            if(e.data('modalsize') != undefined) {
              var size = e.data('modalsize');
              $('.modal-dialog').addClass('modal-' + size);
            }

            if (e.data('modalsubmit') == undefined) {
                $('#btnModalSave').hide();
                $('#btnModalCancel').addClass("btn-primary");
            }
            else {
                $('#btnModalSave').show();
                $('#btnModalCancel').removeClass("btn-primary");
                $('#btnModalSave').unbind('click').click(function (ctrl) {
                    $('#btnModalSave').attr('disabled', 'disabled');

                    ctrl.preventDefault();
                    var submitUrl = $('#' + e.data('modalsubmit')).attr("action");

                    var formData = $('#' + e.data('modalsubmit')).serialize();
                    $.post(submitUrl,
                        formData,
                        function (data, status, xhr) {
                            $('#btnModalSave').removeAttr('disabled');
                            $('#" + dr.GetValue(2).ToString() + "').modal('hide');
                            if (e.data('modalsuccess') != undefined) {
                                eval(e.data('modalsuccess'));
                            }
                        }).error(function () {
                          $('#btnModalSave').prop('disabled', false);
                        });
                });
            }

            $('#detailsBody').load(e.data('modalload'), function () {
                $('#detailsHeader').html(e.data('modaltitle'));
                $('#" + dr.GetValue(2).ToString() + "').modal('show');
                $.validator.unobtrusive.parse($('#detailsBody'));
            });
        });
    }

</script>
    <script>
                $(document).on("contextmenu", ".nav-item", function (e) {
                   // alert('Context Menu event has fired!');
                    return false;
                });

                $(document).on('click', '.add', function () {
                    $('.justify-content-start').append('<li class="nav-item"><a class="nav-link" href=".." + dr.GetValue(0).ToString() + " role="tab" id="6501" aria-controls="6501-panel" aria-selected="false" aria-disabled="false"><span style="font-size:14px;font-family:"Roboto Condensed", sans-serif;font-weight:400;">" + dr.GetValue(2).ToString() + "</span> &nbsp; <span><i class="fa fa-times" style="font-size:12px;"></i></span></a></li>');
                });
            </script>


</asp:Content>

