<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LockScreen.aspx.cs" Inherits="LockScreen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
  <title>Lock page</title>
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
<body id="lock-body">
  <div class="lock-header">
      <!-- BEGIN LOGO -->
      <a href="index.html" id="logo" class="center">
       
 
      </a>
      <!-- END LOGO -->
  </div>

  <!-- BEGIN LOCK -->
  <div id="lock">
    <!-- BEGIN LOCK FORM -->
    <form id="lockform" class="form-vertical no-padding no-margin" runat="server">
      <div class="lock-title">
          <i class="icon-lock"></i>
          <h3>Locked</h3>
      </div>
      <div class="lock-avatar-row">
          <div class="lock-round">
              <img src="img/downlock.jpg" alt="">
          </div>
      </div>
      <div class="control-wrap lock-identity">
          <h3>
              <asp:Label ID="lblUpName" runat="server" Text="Label"></asp:Label></h3>
          <span>
              <asp:Label ID="lblemailid" runat="server" Text="Label"></asp:Label></span>
          <div class="lock-form-row">
              <div class="form-search">
                  <div class="input-append">
                      <asp:TextBox ID="txtpassword" runat="server" type="password" placeholder="Password" class="m-wrap"></asp:TextBox>
                    
                      <asp:Button ID="btncheck" runat="server" Text="Login" class="btn tarquoise" 
                          type="submit" onclick="btncheck_Click" />
                      <i class=" icon-arrow-right"></i>
                  </div>
                  <div class="relogin">
                      <a href="login.aspx">Not 
                          <asp:Label ID="lbldownname" runat="server" Text="Label"></asp:Label> ?</a>
                  </div>
              </div>
          </div>
      </div>

    </form>
    <!-- END LOCK FORM -->        
    
  </div>
  <!-- END LOCK -->
  <!-- BEGIN COPYRIGHT -->
  <div id="login-copyright">
      2013 &copy; Centillion Solution And Services.
  </div>
  <!-- END COPYRIGHT -->
  <!-- BEGIN JAVASCRIPTS -->
  <script src="web/jquery-1.8.3.min.js"></script>
  <script src="web/bootstrap.min.js"></script>
  <script src="web/jquery.blockui.js"></script>
  <script src="web/scripts.js"></script>
  <script>
      jQuery(document).ready(function () {
          App.initLOCK();
      });
  </script>
  <!-- END JAVASCRIPTS -->
</body>
<!-- END BODY -->
</html>