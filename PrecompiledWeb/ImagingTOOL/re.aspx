<%@ page language="C#" autoeventwireup="true" inherits="re, App_Web_pfm3oxak" viewStateEncryptionMode="Never" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 304px;
        }
        .style2
        {
            width: 290px;
        }
        .style3
        {
            height: 20px;
            width: 618px;
        }
        .style4
        {
            width: 618px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="pnlPerson" runat="server">
            <br />
            <table style="font-family: Arial; font-size: 10pt; width: 1002px; margin-right: 0px;">
                <tr>
                    <td align="left" class="style4">
                        <span class="style4">
                            <img alt="" src="http://www.centillioncosmos.com/HRMS/gui/img/centillion_logo.png" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Purchase Order
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="GvwSaleseOrderDetails" runat="server" AutoGenerateColumns="False"
                DataKeyNames="PO_ID" class="table table-striped table-bordered table-advance table-hover"
                ShowHeaderWhenEmpty="True" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="Slno">
                        <ItemTemplate>
                            <asp:Label ID="lblSO_ID" runat="server" Text='<%# Eval("[PO_ID]") %>'></asp:Label>
                            <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Catagory">
                        <ItemTemplate>
                            <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Product">
                        <ItemTemplate>
                            <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <table border="1" style="font-family: Arial; font-size: 10pt; width: 307px; margin-right: 0px;">
                <tr>
                    <td style="width: 192px" class="input-mini">
                        <b>Personal Details</b>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 23px;">
                        <b>Name:</b>
                    </td>
                    <td style="width: 194px; height: 23px;">
                        <asp:Label ID="lblName" Text='<%#Eval("PO Number")%>' runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 23px;">
                        <b>Age:</b>
                    </td>
                    <td style="width: 194px; height: 23px;">
                        <asp:Label ID="lblAge" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px" class="input-mini">
                        <b>City:</b>
                    </td>
                    <td style="width: 194px">
                        <asp:Label ID="lblCity" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 192px; height: 21px;">
                        <b>Country:</b>
                    </td>
                    <td style="width: 194px; height: 21px;">
                        <asp:Label ID="lblCountry" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 983px">
                <tr>
                    <td colspan="2" style="background-color: #FF0000">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Indecomm Global Services (India) Pricate Limiterd&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Imaging Division:
                        <br />
                        213,Skylark Commercial Complex,Sector 11,
                        <br />
                        CBD Belapur, Navi Mumbai -400 614, India.
                        <br />
                        Phone: 91 22 40085999 Fax: 91 22 40085915
                        <br />
                        Email:sales.imaging@indecommglobal.com
                    </td>
                    <td class="style2">
                        Imaging Division:
                        <br />
                        213,Skylark Commercial Complex,Sector 11,
                        <br />
                        CBD Belapur, Navi Mumbai -400 614, India.
                        <br />
                        Phone: 91 22 40085999 Fax9122 40085915
                        <br />
                        Email:sales.imaging@indecommglobal.com
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
