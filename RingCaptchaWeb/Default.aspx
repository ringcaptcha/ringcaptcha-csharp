<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="Default" %>

<%@ Register src="Form.ascx" tagname="Form" tagprefix="uc1" %>
<%@ Register src="Sucess.ascx" tagname="Sucess" tagprefix="uc1" %>
<%@ Register src="Error.ascx" tagname="Error" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>Ringcaptcha test form</title>
    <link rel="stylesheet" type="text/css" href="assets/view.css" media="all">
    <script type="text/javascript" src="assets/view.js"></script>
</head>
<body id="main_body" >
    <form id="form1" runat="server">
        <img id="top" src="assets/top.png" alt="">
        <div id="form_container">        
        <uc1:Form ID="FormControl" runat="server" AppKey="<%# APP_KEY %>" />
        <uc1:Sucess ID="SucessControl" runat="server" Visible="false" />
        <uc1:Error ID="ErrorControl" runat="server" Visible="false" />
        <asp:Panel ID="pnlTryAgain" runat="server" Visible="false">
        <ul>
            <li class="section_break">
                <label><strong><asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Try Again</asp:LinkButton></strong></label>
            </li>
        </ul>
        </asp:Panel>
        </div>
        <img id="bottom" src="assets/bottom.png" alt="">
    </form>
</body>
</html>
