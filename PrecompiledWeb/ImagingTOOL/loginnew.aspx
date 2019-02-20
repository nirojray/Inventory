<%@ page language="C#" autoeventwireup="true" inherits="loginnew, App_Web_pfm3oxak" viewStateEncryptionMode="Never" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="web/login.css" />
    <script type="text/javascript" src="web/Common.js" language="javascript">
        function getload() {

            window.document.getElementById('txtusername').focus();
        }
     
     
     </script>
</head>
<body onload="getload();">
        <!--main wrapper start-->
        &nbsp;
        <div id="wrapper">
 
        <!--2ndmain wrapper start-->
        <div id="wrapperin">
 
        <!-- Top Panel-->
        <div id ="top" style="background:#1669b3; height: 25px;" >
        <div id ="top_in">
 
            IMG Inventory
            </div>
        </div>
 
 
 
        <div id="logo">
        <a href=""><img src="images/logo.jpg" alt="Centillion Logo" title="Centillion Logo"/> </a>
        <p style="margin-top:-34px; margin-left:165px;font-size:13px!important;font-style:italic;font-weight:700; font-family:calibri;color:#959595"> Centillion's - Strategic Partnership to Engage and Enhance Delivery </p>
        </div>
 
 
        <!--text below banner starts-->
        <div style="clear:both"></div>
 
 
        <!--About us page -->
 
        <br /><br />
         <div style="margin-left:400px; margin-bottom:-25px;color:#959595">Login </div>
         <div id="component" style="border:1px solid #1669b3;">
	        <div id="login" >
	
		        <form id="Form1" action="#" method="post" runat="server">
		
			        <font size="3" font="Trebuchet MS" color="#54596c" />
                    <table style="width: 403px; height: 42px;" border="0">
                        <tr>
                            <td colspan="2" style="height: 30px">
                                <asp:Label ID="Label1" runat="server" Font-Bold="False" ForeColor="#C00000" ></asp:Label></td>
                        </tr>
                        <tr>
                            <td style="color: #54596c; font=Trebuchet MS;">
                                Username :</td>
                            <td style="width: 163px; height: 30px;">
                                <asp:TextBox ID="txtusername" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color: #54596c; font=Trebuchet MS;">
                                Password :</td>
                            <td style="width: 163px">
                                <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" MaxLength="50" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 6px; height: 27px;">
                            </td>
                            <td align="left" style="width: 163px; height: 27px;">
                                <asp:Button ID="btnLogin" runat="server" Text=" Sign In" 
                                style="background:#1669b3; border:0; font-weight:700; color:#fff; width:75px; padding:2px; margin:10px 0 20px 75px; display:block"/>&nbsp;
                                <asp:HiddenField ID="hid1" Value="" runat="server"  />
                            </td>
                        </tr>
                                        
                    </table> 
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="lblErrorMsg" runat="server"  Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>   
			        <%--Username : <input type="text" width="30"> <br><br>
			        Password : <input type="password" width="30" style="margin-left:7px;"> <br><br>--%>		
			        <%--<input type="button" Value="Sign In" style="background:#00A7EE; border:0; font-weight:700; color:#fff; width:75px; padding:2px; margin:10px 0 20px 75px; display:block">--%>
		        </form>
	        </div>
	
        </div>	
 
        <!--main wrapper end-->
        </div>
 
        </div>
        <div style="margin-top:3px;font-size:13px;font-family:calibri;color:#959595"><center /> &copy; 2015 Service as a platform Offered by Centillion Solutions and Services. All Rights Reserved.
        </div>
</body>
</html>
