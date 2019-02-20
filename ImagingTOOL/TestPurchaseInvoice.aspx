<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="TestPurchaseInvoice.aspx.cs" Inherits="TestPurchaseInvoice" EnableEventValidation="false" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="Scripts/jquery-1.4.1-vsdoc.js"></script>
    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: hidden;
            width: 200px;
            padding: 0 0 17px 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
    </script>
    <style type="text/css">
        .GridDock1 {
            overflow-x: auto;
            overflow-y: auto;
            width: 200px;
            height: 500px;
            padding: 0 0 17px 0;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth1').width($('#dvScreenWidth1').width());
        });
    </script>
    <script type="text/javascript">
        function InvoiceDate1() {
            var TxtPoDate = document.getElementById('<%=TxtPoDate.ClientID %>').value;
            var Txt_InvoiceDate = document.getElementById('<%=Txt_InvoiceDate.ClientID %>').value;

            var TxtPoDate = new Date(TxtPoDate);
            var Txt_InvoiceDate = new Date(Txt_InvoiceDate);

            if (TxtPoDate != '' && Txt_InvoiceDate != '') {
                if (TxtPoDate > Txt_InvoiceDate) {
                    alert(" Invoice Date should be greater than or equal to the PO Date.");
                    return false;
                }
            }
        }


        function InvoiceDate() {
            var TxtPoDate = document.getElementById('<%=TxtPoDate.ClientID %>').value;
            var Txt_InvoiceDate = document.getElementById('<%=Txt_InvoiceDate.ClientID %>').value;
            var firstValue = TxtPoDate.split('-');
            var secondValue = Txt_InvoiceDate.split('-');

            var firstDate = new Date();
            firstDate.setFullYear(firstValue[2], (firstValue[1] - 1), firstValue[0]);

            var secondDate = new Date();
            secondDate.setFullYear(secondValue[2], (secondValue[1] - 1), secondValue[0]);

            if (firstDate > secondDate) {
                alert(" Invoice date can not be less than the PO date");
                document.getElementById('<%=Txt_InvoiceDate.ClientID %>').value = "";
                return false;
            }
        }
    </script>

    <script type="text/javascript">
    function setMaxLength(control) {
        //get the isMaxLength attribute
        var mLength = control.getAttribute ? parseInt(control.getAttribute("isMaxLength")) : ""

        //was the attribute found and the length is more than the max then trim it
        if (control.getAttribute && control.value.length > mLength) {
            control.value = control.value.substring(0, mLength);
            alert('Purchase Invoice Length exceeded');
        }

        //display the remaining characters
        var modid = control.getAttribute("id") + "_remain";
        if (document.getElementById(modid) != null) {
            document.getElementById(modid).innerHTML = mLength - control.value.length;
        }
    }
</script>


    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Purchase
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">Purchase</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="TestPurchaseInvoice.aspx">Purchase Invoice</a><span class="divider-last">&nbsp;</span></li>
                    </ul>
                </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        <div class="widget-title">
                            <h4>Purchase Invoice</h4>
                            <span class="tools">
                                <a href="javascript:;" class="icon-chevron-down"></a>
                                <a href="javascript:;" class="icon-remove"></a>
                            </span>
                        </div>
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form action="#" class="form-horizontal">
                            </form>
                            <!-- END FORM-->
                            <table id="tbldate" runat="server">
                                <tr>
                                    <td style="height: 38px">&nbsp;&nbsp;&nbsp; From Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                         <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                    </td>
                                    <td style="height: 38px">&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                                        To Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        &nbsp&nbsp
                                        <asp:Button ID="BtnSearch" runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />
                                    </td>

                                </tr>
                                <br />
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                                <div id="dvScreenWidth1" visible="false" style="width: 100%">
                                    <div class="GridDock1" id="dvGridWidth1" style="width: 100%">
                                        <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False" EmptyDataText="No Records Found" ShowHeaderWhenEmpty="true"
                                            class="table table-striped table-bordered table-advance table-hover"
                                            Width="100%" DataKeyNames="GRN_ID"
                                            OnRowCommand="GvwSalesRegister_RowCommand" AllowPaging="false" AllowSorting="True" OnRowDataBound="GvwSalesRegister_RowdataBound"
                                            OnPageIndexChanging="GvwSalesRegister_PageIndexChanging" PageSize="5">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Slno">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="GRN NO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("[GRN_Number]") %>'></asp:Label>

                                                        <asp:Label ID="hidennID" runat="server" Text='<%# Eval("[GRN_ID]") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("[GRN_Date]") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidCatagory" runat="server" />
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Location">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidLocationID" runat="server" Value='<%# Eval("locationID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Supplier">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vendor">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblVendor" runat="server" Text='<%# Eval("VendorName") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("GRN_TotalAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="PO_Entered On">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("GRN_EnteredOn") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                            CommandName="Edit1">Edit</asp:LinkButton>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                            </Columns>
                                            <EmptyDataTemplate>No Record Available</EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>


                            <asp:Panel ID="Panel1" runat="server">

                                <div class="widget-body">
                                    <table>
                                        <tr>
                                            <td class="input-mini" style="width: 85px">GRN Number. &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:TextBox ID="TxtGRNNum" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 77px" class="input-mini">GRN Date &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:TextBox ID="TxtGRNDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="input-mini" style="width: 85px">Purchase Order Number. 
                                                <asp:TextBox ID="TxtPoNo" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 77px" class="input-mini">Purchase Order Date &nbsp
                                                <asp:TextBox ID="TxtPoDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Invoice No &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_InvoiceNo" runat="server" onKeyUp="setMaxLength(this)" isMaxLength="16"></asp:TextBox>
                                            </td>
                                            <td>Invoice Date &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_InvoiceDate" runat="server" ReadOnly="True"></asp:TextBox>
                                                <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="Txt_InvoiceDate"
                                                    Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 250px">Supplier &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 190px">Supplier State&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:TextBox ID="TxtSupplierState" runat="server" ReadOnly="True" Width="170px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="input-mini" style="width: 190px">State&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoSupplierState" runat="server" ReadOnly="True" Width="160px"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 75px">Location  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="input-mini" style="width: 75px">Supplier GST NO &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtGST" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 75px">Payment Terms &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtPaymentterms" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                         <tr>
                                              <td class="input-mini" style="width: 75px">Reverse Charges &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtrevers" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>  
                                            <td class="input-mini" style="width: 75px">PAN Num &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPANNum" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>  
                                          </tr>
                                        <tr>
                                             <td class="input-mini" style="width: 75px">Main Category &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtType" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 168px" runat="server"><asp:Label ID="lbl_hsnac" runat="server"></asp:Label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txt_hsnac" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                           
                                        </tr>
                                        <tr>
                                             <td style="width: 168px" runat="server">Terms Of Delivery&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtTermsOfDelivery" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td class="input-mini" style="width: 75px" id="TrWarranty" runat="server">Warranty &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtWarranty" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="input-mini" style="width: 75px" id="Td1" runat="server">Lorry Receipt Number &nbsp&nbsp
                                                 <asp:TextBox ID="txtlryRecptNum" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                             <td style="width: 168px" id="Td2" runat="server">Purchase Type&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPurchaseType" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 168px" id="TrVendor" runat="server">Vendor&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtVendor" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <%--<tr>
                                            <td class="input-mini" style="width: 85px">
                                              PO No.  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;  <asp:TextBox ID="TxtPoNo" runat="server" Width="240px"  ReadOnly="True"></asp:TextBox>
                                            </td>
                                           
                                            <td style="width: 77px" class="input-mini">
                                                PO Date  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:TextBox ID="TxtPoDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                            
                                                                                    
                                        </tr>                                      
                                        <tr>
                                            <td style="width: 168px">
                                               Total Amount &nbsp;
                                                 <asp:TextBox ID="TxtTotalAmount" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>    
                                            <td class="input-mini" style="width: 75px">
                                                Location  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                 <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True" 
                                                    ontextchanged="TxtLocation_TextChanged"></asp:TextBox>
                                            </td>
                                       </tr>
                                        <tr>      
                                            <td class="input-mini" style="width: 77px">
                                               Supplier  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                                 <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                           
                                            <td style="width: 168px" >
                                                Type &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                                <asp:TextBox ID="txtType" runat="server" ReadOnly="True" ></asp:TextBox>
                                            </td>                                           
                                              
                                        </tr> 
                                         <tr >      
                                            <td class="input-mini" id ="TrVendor" runat="server" style="width: 77px">
                                               Vendor  &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                                 <asp:TextBox ID="Txtvendor" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                           
                                            <td style="width: 168px" id ="TrWarranty" runat="server" >
                                                Warranty&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;
                                                <asp:TextBox ID="TxtWarranty" runat="server" ReadOnly="True"  ></asp:TextBox>
                                            </td>                                           
                                              
                                        </tr>            
                                        
                                    </table>--%>
                                    <table border="1">
                                        <tr>
                                            <td style="height: 22px; width: 75px;">Billing Adress</td>
                                            <td style="width: 75px">ShippingAddress</td>                                            
                                        </tr>
                                        <tr>
                                             <td><span class="style4">
                                                <asp:TextBox ID="Txt_BillingAddress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                            </span>
                                            </td>
                                            <td>
                                                <span class="style4">
                                                    <asp:TextBox ID="Txt_shippingAdress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                </span>
                                            </td>                                           
                                        </tr>
                                    </table>
                                </div>
                                <%--       <asp:GridView ID="GvwPurchaseInvocie" runat="server" AutoGenerateColumns="False" 
                                        class="table table-striped table-bordered table-advance table-hover" 
                                       ShowHeaderWhenEmpty="True" Width="100%" ShowFooter="True"  PageSize="5" 
                                        AllowPaging="true" AllowSorting="true"
                                        onpageindexchanging="GvwPurchaseInvocie_PageIndexChanging" 
                                        onrowdeleting="GvwPurchaseInvocie_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                    
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CatagoryID">
                                                <ItemTemplate>
                                                    <asp:Label ID="HidCatagory0" runat="server" Text='<%# Eval("catagoryid") %>'></asp:Label>
                                               
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                 
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Productid">
                                                <ItemTemplate>
                                                    <asp:Label ID="HidProduct0" runat="server" Text='<%# Eval("productid") %>'></asp:Label>
                                                  
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PO Product Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                          
                                             <asp:TemplateField HeaderText="PO Tax">
                                                <ItemTemplate>
                                                    <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("taxID") %>'></asp:Label>
                                                   
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="PO Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInQuantity" runat="server"  Text='<%# Eval("PO_Quantity1") %>' Width="30Px"></asp:TextBox>
                                                </ItemTemplate>
                                              
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Price">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="TxtInPrice" runat="server" Text='<%# Eval("PO_UnitPrice1") %>' Width="60Px"></asp:TextBox>
                                                </ItemTemplate>
                                             

                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Invoice Tax">
                                                <ItemTemplate>
                                                <asp:TextBox ID="txttaxid" runat="server" Text='<%# Eval("taxID1") %>'></asp:TextBox>
                                                    
                                                   
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Invoice Total Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblInvocietotalPrice" runat="server" Text='<%# Eval("TT1") %>'></asp:Label>
                                                </ItemTemplate>
                                                   </asp:TemplateField>
                                              <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                         <asp:Button id="BtnAdd" class="btn-success" runat ="server" OnClick="AddNewGridRow" Text="Update" ToolTip=" Add New Product"/>
                                       
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                --%>
                                <%-- OnRowDataBound="GvwPurchaseInvocie_RowDataBound"--%>
                                <div id="dvScreenWidth" visible="false" style="width: 100%">
                                    <div class="GridDock" id="dvGridWidth" style="width: 100%">

                                        <asp:GridView ID="GvwPurchaseInvocie" runat="server" AutoGenerateColumns="False"
                                            class="table table-striped table-bordered table-advance table-hover"
                                            ShowHeaderWhenEmpty="True" ShowFooter="True"
                                            AllowPaging="false" AllowSorting="true"
                                            OnPageIndexChanging="GvwPurchaseInvocie_PageIndexChanging"
                                            OnRowDeleting="GvwPurchaseInvocie_RowDeleting" Width="100%">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Slno">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                        <asp:HiddenField ID="HdfPODETID" runat="server" Value='<%# Eval("GRN_DET_ID") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Catagory">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidCatagory0" runat="server" Value='<%# Eval("catagoryid") %>' />
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidProduct0" runat="server" Value='<%# Eval("productid") %>' />
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Product Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("PO_Product_Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Unit Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Pending Quantity" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPendingQuantity" runat="server" Text='<%# Eval("PO_pendingCount") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Product Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="TotalPrice">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPOTotalPrice" runat="server" Text='<%# Eval("PO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltaxName" runat="server" Text='<%# Eval("TaxName") %>' Width="150px"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Tax Amount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Total Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtInQuantity" runat="server" Text='<%# Eval("PO_Quantity1") %>' Width="30Px" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Price">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtInPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>' Width="60Px" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Invoice Total Price">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TxtInTotalPrice" runat="server" Text='<%# Eval("PO_TotalPrice1") %>' Width="75Px" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Invoice Tax">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txttaxid" Width="70px" runat="server" Text='<%# Eval("PO_TaxAmount") %>' Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" Standerd Warranty From Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStdFrmDate" runat="server" Width="130px" Text='<%# Eval("PO_STD_From_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" Standerd Warranty To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStdToDate" runat="server" Width="130px" Text='<%# Eval("PO_STD_To_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" Extended Warranty From Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblExtndWarentyFrmDate" runat="server" Width="130px" Text='<%# Eval("PO_Extnd_From_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText=" Extended Warranty To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblExtndWarentyToDate" runat="server" Width="130px" Text='<%# Eval("PO_Extend_To_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Invoice Total Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblInvocietotalPrice" runat="server" Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        <asp:Button ID="BtnAdd" runat="server" OnClick="AddNewGridRow" Text="Update" class="btn-success" Visible="false" ToolTip=" Add New Product" />

                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <%--   <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkLink" runat="server" CommandArgument="<%#Container.DataItemIndex+1 %>"
                                                ToolTip="Delete" CommandName="Delete"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                  
                                        </FooterTemplate>
                                    </asp:TemplateField>--%>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <br />
                                <div class="row-fluid" style="width: 100%">
                                    <div class="span4 invoice-block pull-right" style="width: 100%">
                                        <ul class="unstyled amounts">
                                            <li style="height: 150px">
                                                <div class="span4 invoice-block pull-left" style="width: 100%; height: 57px;">
                                                    <table style="width: 100%">

                                                        <tr>
                                                            <td>PO Total Amount &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="TxtInTotalAmount" runat="server"
                                                                         onkeypress="return isNumberKey(event)" Text="0.00" ReadOnly="True"></asp:TextBox>
                                                            </td>

                                                            <td>Invoice Total&nbsp; Amount &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="Txt_SubTotal" runat="server" Text="0.00" ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>                                                                                                                            
                                                                 <td colspan="2" >    
                                                                      Lorry Receipt Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                     <asp:TextBox ID="TxtLorryRcptNum" runat="server"></asp:TextBox>                                                                
                                                                 </td>                                                                
                                                             </tr>--%>
                                                        <tr>
                                                            <td colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:Button ID="BtnInvoiceSave0" runat="server" Width="80px" class="btn-success"
                                                                    ForeColor="Black" OnClick="BtnInvoiceSave_Click" Text="Save" OnClientClick="return InvoiceDate1();" />&nbsp &nbsp
                                                                     <asp:Button ID="BtnCancel" runat="server" Width="80px"
                                                                         ForeColor="Black" OnClick="BtnCancel_Click" Text="Cancel" class="btn-success" />
                                                            </td>

                                                        </tr>
                                                    </table>
                                                    <br />
                                                    <br />

                                                    &nbsp;&nbsp;
                                                </div>
                                                &nbsp;&nbsp; </li>
                                        </ul>
                                    </div>
                                </div>
                                <br />
                            </asp:Panel>
                            <asp:HiddenField ID="hidDetails_ID" runat="server" />

                            <%--<asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>--%>
                            <br />
                        </div>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->
        </div>
        <!-- END PAGE CONTAINER-->
    </div>
</asp:Content>


