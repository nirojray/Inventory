<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="testreport.aspx.cs" Inherits="testreport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    PO Number:-<asp:DropDownList ID="ddlPonumber" runat="server">
    </asp:DropDownList>

&nbsp;&nbsp;
<asp:Button ID="btnReport" runat="server" onclick="btnReport_Click" 
    Text="Export" />

</asp:Content>

