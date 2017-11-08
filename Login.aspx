<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shrikrishna.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" type="text/css" href="Login/css/style.css" />
<script type="text/javascript" src="Login/js/jquery.js"></script>
<script type="text/javascript" src="Login/js/jquery.pngFix.js"></script>
<script type="text/javascript">$(document).ready(function () { $(document).pngFix(); });</script>
<!--[if lt IE 8.]><link rel="stylesheet" type="text/css" href="css/style-ie.css" /><![endif]-->
<!--[if lt IE 7.]><link rel="stylesheet" type="text/css" href="css/style-ie6.css" /><![endif]-->
<script type="text/javascript" src="Login/js/swfobject/swfobject.js"></script>
<script type="text/javascript">
    var flashvars = {};
    flashvars.xml = "config.xml";
    flashvars.font = "font.swf";
    var attributes = {};
    attributes.wmode = "transparent";
    attributes.id = "slider";
    swfobject.embedSWF("design3edge.swf", "content_slider", "575", "265", "9", "expressInstall.swf", flashvars, attributes);
</script>
        <style type="text/css">
            .style1
            {
                width: 100%;
            }
        </style>
    <link href="Css/Auth.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
<div id="main_body">
  <div id="header">
      <div style="font-size:xx-large; color: #FFFFFF; text-transform: capitalize; font-weight: bold;">
          Shrikrishna Offset Printer</div>
  </div>
  <div id="content_body">
    <div id="left_content">
      <p class="headings"> Admin Login... </p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <img  src="Login/images/about_us-icon.png" alt="" /> <br />
      
     
      <br />
      <br />
       
       
        <div style="float:left;width:12%; margin-left:10%"> UserName</div>
        <div style="float:left;width:22%;">
            <asp:TextBox ID="txtuser" runat="server"></asp:TextBox> </div>
        <br /><br />

        <div style="float:left;width:12%; margin-left:10%"> Password</div>
        <div style="float:left;width:15%;">
            <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox> </div><br /><br />

       
            <div style="float:left;margin-left:25%;">

                <asp:Button ID="btnlogin" runat="server" Text="   Login   " Font-Bold="False" Font-Italic="True" Font-Names="Verdana" Font-Size="Medium" OnClick="cancel_Click" />
                &nbsp&nbsp&nbsp<asp:Button ID="btncancel" runat="server" Text="   Cancel   " Font-Bold="False" Font-Italic="True" Font-Names="Verdana" Font-Size="Medium" OnClick="btncancel_Click" />
            </div>
      
        <br />
        <div style="float:left;width:40%; margin-left:50px;">
          
        
            <asp:Label ID="msg" runat="server"></asp:Label>
          
        
            </div>
    
      <div class="clear"> </div>
      <br />
        <div>
            
       
                    
                    </div>
        
      </div>
  
    <div class="clear"> </div>
 
  <div id="footer_top_bg"> </div>
  <div id="footer_content">
    <div class="clear"><div style="float:left;vertical-align:text-top; color: #FFFFFF;"">Copyright &copy All Rights Reserved</div>
        <div style="float:right; vertical-align:text-top; color: #FFFFFF;">Develop By:-Ritosh M. Yadav</div> </div>
  </div>
  <div id="footer_bottom_bg"> </div>
</div>
</form>
</body>
</html>
