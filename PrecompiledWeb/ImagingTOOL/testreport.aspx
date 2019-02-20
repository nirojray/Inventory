<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="testreport, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    PO Number:-<asp:DropDownList ID="ddlPonumber" runat="server">
    </asp:DropDownList>

&nbsp;&nbsp;
<asp:Button ID="btnReport" runat="server" onclick="btnReport_Click" 
    Text="Export" />

</asp:Content>

