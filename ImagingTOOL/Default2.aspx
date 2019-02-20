<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style4
        {
            width: 874px;
        }
        .style5
        {
            width: 918px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 <div id="divexcel" runat="server">
        <table style="font-family: Arial; font-size: 10pt; width: 682; margin-right: 0px;">
            <tr>
                <td align="left" style="width: 518; height: 54px">
                    <img alt="" height="74" width="500" src="http://www.centillioncosmos.com/HRMS/gui/img/centillion_logo.png" />
                </td>
                <td style="width: 64; height: 74">
                </td>
            </tr>
            <tr style="height: 20px">
                <td align="center" colspan="2">
                    PURCHASE ORDER
                  
                </td>
            </tr>
          
        </table>
   

        <table class="style1" style="width: 100%">
            <tr>
                <td class="style4">
                    <asp:Label ID="lbl_LocationName" runat="server"></asp:Label>
                </td>
                <td style="text-align:left">
                    &nbsp;
                    Order No:<asp:Label ID="lbl_Ponumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <asp:Label ID="lbl_Location" runat="server"></asp:Label>
                </td>
                <td style="text-align:left">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:<asp:Label ID="lbl_PoDate" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        Kind Attn:<asp:Label ID="lbl_PO_RaisedTO" runat="server"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Document Imaging<br /><br />
      
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
        <table class="style1" style="width: 100%">
            <tr>
                <td class="style5" align="left">
                    Bill To:</td>
                <td align="left">
                    Ship To:</td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    <asp:Label ID="lbl_Bill_Address" runat="server"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lbl_Ship_Address" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    <asp:Label ID="lbl_Bill_Address1" runat="server"></asp:Label>
                </td>
                <td align="left">
                     <asp:Label ID="lbl_Ship_Address1" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    <asp:Label ID="lbl_Bill_Address2" runat="server"></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lbl_Ship_Address2" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    <asp:Label ID="lbl_Bill_Address3" runat="server" Text=""></asp:Label>
                </td>
                <td align="left">
                    <asp:Label ID="lbl_Ship_Address3" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    TIN:<asp:Label ID="lbl_Bill_TIN" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5" align="left">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    <br />
        <table class="style1" style="width: 100%">
            <tr>
               
                <td align="left">
                    <asp:Label ID="lbl_Term1" runat="server" 
                        Text="1. Price : Exclusive of taxes as applicable."></asp:Label>
                </td>
            </tr>
            <tr>
               
                <td align="left">
                    <asp:Label ID="lbl_Term2" runat="server" 
                        Text="2. Payment : 60 days credit from the date of Shipment. "></asp:Label>
                </td>
            </tr>
            <tr>
                
                <td align="left">
                    <asp:Label ID="lbl_Term3" runat="server" Text="3. Delivery : Within 2-3 weeks. "></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        For Indecomm Global Services (India) Private Limited<br />
        <br />
        <br />
        <br />
        Authorised Signatory<br /><br /><br />
        <table style="width: 100%">
            <tr>
                <td colspan="3" style="width: 100%">
                  <img alt="" src="http://www.centillioncosmos.com/IMG Inventory/img/Redline.png" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">                    
                    Centillion Solution And Service (P)Ltd.</td>
            </tr>
            <tr>
                <td align="left">
                   <span style="font-size:8;"> Imaging Division:
                    <br />
                    <asp:Label ID="lbl_Footer_Address1" runat="server"></asp:Label>
                    ,
                    <br />
                    &nbsp;<asp:Label ID="lbl_Footer_Address2" runat="server"></asp:Label>
                    ,<asp:Label ID="lbl_Footer_Address3" runat="server"></asp:Label>
                    .<br />
                    Phone: 91 22 40085999 Fax: 91 22 40085915
                    <br />
                    Email:sales.imaging@indecommglobal.com</span>
                </td>
                <td></td>
                <td   >
                   <span style="font-size:8;">  Imaging Division:
                    <br />
                    213,Skylark Commercial Complex,Sector 11,
                    <br />
                    CBD Belapur, Navi Mumbai -400 614, India.
                    <br />
                    Phone: 91 22 40085999 Fax9122 40085915
                    <br />
                    Email:sales.imaging@indecommglobal.com</span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
