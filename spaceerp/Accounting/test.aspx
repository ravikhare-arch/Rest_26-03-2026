<%@ Page Language="C#" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="Accounting_test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <title>jQuery TreeTable Demo Page</title>
    <link href="http://www.jqueryscript.net/css/jquerysctipttop.css" rel="stylesheet" type="text/css">
    <!-- Bootstrap -->
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <style>
        body {
            background-color: #fafafa;
            font-family: 'Open Sans';
        }

        .container {
            margin: 150px auto;
        }

        .treegrid-indent {
            width: 0px;
            height: 16px;
            display: inline-block;
            position: relative;
        }

        .treegrid-expander {
            width: 0px;
            height: 16px;
            display: inline-block;
            position: relative;
            left: -17px;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </form>
     <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
        <script src="http://code.jquery.com/jquery-1.12.4.min.js"></script>
        <script src="http://netdna.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <script src="../assets/js/tabletree.js"></script>
</body>
</html>
