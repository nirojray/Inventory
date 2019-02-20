﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forget.aspx.cs" Inherits="forget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <meta charset="utf-8" />
  <title>Login page</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport" />
  <meta content="" name="description" />
  <meta content="" name="author" />
  <link href="web/bootstrap.min.css" rel="stylesheet" />
  <link href="web/font-awesome.css" rel="stylesheet" />
  <link href="web/style.css" rel="stylesheet" />
  <link href="web/style_responsive.css" rel="stylesheet" />
  <link href="web/style_default.css" rel="stylesheet" id="style_color" />
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
<body id="login-body">
  <div class="login-header" style="align-content:center">
      <!-- BEGIN LOGO -->
      <div id="logo" class="center">
          <img src="img/aa.jpg" alt="logo" class="center" />
      </div>
      <!-- END LOGO -->
  </div>

    <div style="height:50px;"></div>
  <!-- BEGIN LOGIN -->
  <div id="login">
    <!-- BEGIN LOGIN FORM -->
    <form id="loginform" class="form-vertical no-padding no-margin" runat="server">
      <%--<div class="lock">
          <i class="icon-lock"></i>
      </div>--%>
      <div style="height:100px; ">
          <h4>Forgot Password</h4><br />
          <div style="height:50px;">
              <div class="controls">
                  <div class="input-prepend">
                      <span class="add-on"><i class="icon-envelope"></i></span>
                      <asp:TextBox ID="txtEmailID" runat="server" type="text" placeholder="Email ID" Width="250px"></asp:TextBox>
                  </div>
              </div>
          </div>
      
      </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" type="submit" class="btn btn-success"
            value="Login" onclick="btnSubmit_Click" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:LinkButton ID="lnkLogin" runat="server" Text="User Login" PostBackUrl="~/login.aspx" Font-Underline="true" ForeColor="#000066"></asp:LinkButton>
      <br />
<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
      &nbsp; 
      <a href="login.aspx">Login</a>--%>
        
    </form>  
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <!-- END LOGIN FORM -->        
    <!-- BEGIN FORGOT PASSWORD FORM -->
  
    <!-- END FORGOT PASSWORD FORM -->
  </div>
  <!-- END LOGIN -->
  <!-- BEGIN COPYRIGHT -->
  <div id="login-copyright" style="height:500px">
      2017 &copy; Centillion Solution And service.
  </div>
  <!-- END COPYRIGHT -->
  <!-- BEGIN JAVASCRIPTS -->
  <script src="web/jquery-1.8.3.min.js"></script>
  <script src="web/bootstrap.min.js"></script>
  <script src="web/jquery.blockui.js"></script>
  <script src="web/scripts.js"></script>
  <script>
      jQuery(document).ready(function () {
          App.initLogin();
      });
  </script>
  <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>