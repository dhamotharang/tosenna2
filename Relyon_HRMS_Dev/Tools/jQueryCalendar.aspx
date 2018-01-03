<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jQueryCalendar.aspx.cs" Inherits="jQueryCalendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
     <script src="_scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
     <script src="_scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
    <SCRIPT type="text/javascript">
        $(function() {
         $("#txtDate").datepicker();       
        });
	
	</SCRIPT>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
    </div>    
    </form>
</body>
</html>
