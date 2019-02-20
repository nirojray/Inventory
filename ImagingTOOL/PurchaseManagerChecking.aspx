<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="PurchaseManagerChecking.aspx.cs" EnableEventValidation="false" Inherits="PurchaseManagerChecking" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <style type="text/css">
    .GridDock
    {
        overflow-x: auto;
        overflow-y: hidden;
        width: 200px;
        padding: 0 0 17px 0;
    }
</style>
    <script type="text/javascript">
    $(document).ready(function() {
       $('#dvGridWidth').width($('#dvScreenWidth').width());
    });
</script>


 <style type="text/css">
    .GridDock1
    {
        overflow-x: auto;
        overflow-y: auto;
        width: 200px;
        height: 300px;
        padding: 0 0 17px 0;       
    }
</style>
    <script type="text/javascript">
    $(document).ready(function() {
       $('#dvGridWidth1').width($('#dvScreenWidth1').width());
    });
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

                        <li><a href="PurchaseManagerChecking.aspx">Purchase Manager Checking</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Purchase Manager Checking</h4>
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
                                    <td style="height: 38px">&nbsp&nbsp&nbsp From Date &nbsp&nbsp                                   
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" Move="True" />
                                    </td>
                                    <td style="height: 38px">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp To Date                                
                                         <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%" ReadOnly="true"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />  &nbsp&nbsp&nbsp&nbsp
                                        <asp:Button ID="BtnSearch"  runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />                                 
                                    </td>                                    
                                </tr>
                                <tr>
                                    <td colspan="2" align="center">
                                         <asp:Label ID="lblmsg" runat="server" Text="" ForeColor="Red" Font-Size="Medium" Font-Bold="true"></asp:Label>
                                    </td>
                                </tr>
                            </table>                            
                            <asp:Panel ID="Panel2" runat="server">
                                 <div id="dvScreenWidth1" visible="false" style="width: 100%">
                                    <div class="GridDock1" id="dvGridWidth1" style="width: 100%">

                                <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False"
                                    class="table table-striped table-bordered table-advance table-hover"
                                    ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="PO_ID"
                                    OnRowCommand="GvwSalesRegister_RowCommand" AllowPaging="false" AllowSorting="True"
                                    OnPageIndexChanging="GvwSalesRegister_PageIndexChanging">
                                    <Columns>
                                        <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="PRN NO">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("[PO_Number]") %>'></asp:Label>

                                                <asp:Label ID="hidennID" runat="server" Text='<%# Eval("[PO_ID]") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldate" runat="server" Text='<%# Eval("[PO_Date]") %>'></asp:Label>
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
                                                <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("PO_NetAmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="PRN Entered On">
                                            <ItemTemplate>
                                                <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("PO_EnteredOn") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                    CommandName="Edit1">Edit</asp:LinkButton>
                                            </ItemTemplate>

                                        </asp:TemplateField>

                                    </Columns>
                                    
                                </asp:GridView>
                                   </div>
                                </div>
                            </asp:Panel>
                          
                            <asp:Panel ID="Panel1" runat="server">

                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="input-mini" style="width: 85px">PRN No. &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:TextBox ID="TxtPoNo" runat="server" Width="200px" ReadOnly="True"></asp:TextBox>
                                            </td>                                            
                                            <td style="width: 77px" class="input-mini">PRN Date &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                <asp:TextBox ID="TxtPoDate" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                           
                                        </tr>
                                        <tr>
                                            <td class="input-mini" style="width: 250px">Supplier &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoSupplier" runat="server" ReadOnly="True" Width="210px"></asp:TextBox>
                                            </td>  
                                            <td class="input-mini" style="width: 250px">Supplier State&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtSupplierState" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                             <td class="input-mini" style="width: 250px">State&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoSupplierState" runat="server" ReadOnly="True" Width="200px"></asp:TextBox>
                                            </td>  
                                            <td class="input-mini" style="width: 75px">Location  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPoLocation" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td> 
                                               
                                        </tr>
                                          <tr>
                                              <td class="input-mini" style="width: 75px">Supplier GST NO &nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtGST" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>  
                                            <td class="input-mini" style="width: 75px">Payment Terms &nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtPaymentterms" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>   
                                                                                        
                                        </tr>

                                         <tr>
                                              <td class="input-mini" style="width: 75px">Reverse Charge &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtrevers" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>  
                                            <td style="width: 168px" runat="server">Terms Of Delivery&nbsp&nbsp
                                                 <asp:TextBox ID="txtTermsOfDelivery" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>    
                                                                                        
                                        </tr>

                                        <tr>
                                            <td class="input-mini" style="width: 75px">PAN Num &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtPanNum" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td> 

                                            <td class="input-mini" style="width: 75px">Main Category &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtType" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td> 
                                                                                   
                                        </tr>
                                          <tr> 
                                               <td style="width: 168px" runat="server"><asp:Label ID="lbl_hsnac" runat="server"></asp:Label> &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txt_hsnac" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                             
                                              <td class="input-mini" style="width: 75px" id="TrWarranty" runat="server">Warranty &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtWarranty" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                                                                   
                                        </tr>  
                                        <tr>
                                             <td style="width: 168px">Purchase Type&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtPurchaseType" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>   
                                             <td style="width: 168px" id="TrVendor" runat="server">Vendor&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="TxtVendor" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>                                            
                                        </tr> 
                                        <tr id="trspa" runat="server" visible="false">
                                            <td style="width: 168px">SPA Number&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                 <asp:TextBox ID="txtSPANum" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="1">
                                        <tr>
                                            <td style="height: 22px; width: 75px;">Billing Adress</td>
                                            <td style="width: 75px">ShippingAddress</td>                                            
                                        </tr>
                                        <tr>
                                             <td><span class="style4">
                                                <asp:TextBox ID="TxtBillingAddress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                            </span>
                                            </td>
                                            <td>
                                                <span class="style4">
                                                    <asp:TextBox ID="TxtShippingAddress" runat="server" ReadOnly="True" Width="60%" Height="80px" TextMode="MultiLine"></asp:TextBox>
                                                </span>
                                            </td>                                           
                                        </tr>
                                    </table>
                                     <br /><br />
                                    <%--<div class="row-fluid" style="width: 100%">--%>
                                        <%--<div id="dvScreenWidth" visible="false" style="width:100%">
                                        <div class="GridDock" id="dvGridWidth" style="width:100%" >
                                              OnPageIndexChanging="GvwPurchaseInvocie_PageIndexChanging" PageSize="5"
                                            --%>
                                    <div id="dvScreenWidth" visible="false" style="width:100%">
                                        <div class="GridDock" id="dvGridWidth" style="width:100%">
                                        <asp:GridView ID="GvwPurchaseInvocie" runat="server" AllowPaging="false"
                                            AllowSorting="true" AutoGenerateColumns="False"
                                            class="table table-striped table-bordered table-advance table-hover"                                          
                                            ShowHeaderWhenEmpty="True" >
                                            <Columns>
                                                <%--<asp:TemplateField HeaderText="Slno">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>--%>
                                                <%-- <asp:TemplateField HeaderText="CatagoryID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagoryID" runat="server" Text='<%# Eval("CatagoryID") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Catagory">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidCatagory0" runat="server"
                                                            Value='<%# Eval("catagoryid") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              
                                                <asp:TemplateField HeaderText="Product">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidProduct0" runat="server"
                                                            Value='<%# Eval("productid") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                

                                                <asp:TemplateField HeaderText="Product Description">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("PO_Product_Description") %>'></asp:Label>
                                                    </ItemTemplate>                                                   
                                                    <ItemStyle Width="20%" />
                                                </asp:TemplateField>                                               

                                                <asp:TemplateField HeaderText="PRN Quantity">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("PO_Quantity") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRN Unit Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("PO_UnitPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRN Total Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblPO_TotalPrice" runat="server" Text='<%# Eval("PO_TotalPrice") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tax Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblTaxName" runat="server" Text='<%# Eval("TaxName") %>'></asp:Label>
                                                    </ItemTemplate>
                                                  <ItemStyle Width="100%" />
                                                  <HeaderStyle Width="100%" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PRN TaxAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltaxAmount" runat="server" Text='<%# Eval("PO_TaxAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="STD Warranty From Date" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStdWrntyFrmDate" runat="server" Text='<%# Eval("PO_STD_From_Date") %>' Width="100%"></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="STD Warranty To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblStdWrntyToDate" runat="server" Text='<%# Eval("PO_STD_To_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle Width="20%" />
                                                     
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Extended Warranty From Date" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblExtdWrntyFromDate" runat="server" Text='<%# Eval("PO_Extnd_From_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                      <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Extended Warranty To Date" >
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblExtdWrntyToDate" runat="server" Text='<%# Eval("PO_Extend_To_Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                     <ItemStyle Width="20%" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="PRN TotalAmount">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LbltotalAmount" runat="server" style="text-align:left"
                                                            Text='<%# Eval("TT") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>
                                         </div>
                                            </div>
                                        <div class="span4 invoice-block pull-right" style="width: 100%">
                                            <ul class="unstyled amounts">

                                                <li style="height: 85px">
                                                    <div class="span4 invoice-block pull-left"
                                                        style="width: 99%; height: 57px;">
                                                        Approved/Reject:<asp:DropDownList
                                                            ID="DrpAppRej" runat="server" Width="95px">
                                                            <asp:ListItem Value="1">Select</asp:ListItem>
                                                            <asp:ListItem Value="20">Accepted</asp:ListItem>
                                                            <asp:ListItem Value="30">Rejected</asp:ListItem>
                                                        </asp:DropDownList>
                                                        &nbsp;
                                            <asp:TextBox ID="Txt_AppRejReason" runat="server" Height="77px"
                                                TextMode="MultiLine" Width="186px"></asp:TextBox>
                                                        <asp:Button ID="BtnAppRejSave" runat="server" ForeColor="Black" class="btn-success"
                                                            Text="Save" OnClick="BtnAppRejSave_Click" />
                                                        <asp:Button ID="btnCancel" runat="server" ForeColor="Black" class="btn-success"
                                                            Text="Cancel" OnClick="btnCancel_Click" />
                                                    </div>
                                                    &nbsp;&nbsp; </li>


                                            </ul>
                                        </div>
                                  <%--  </div>--%>
                                </div>
                                <br />
                            </asp:Panel>
                            <asp:HiddenField ID="hidDetails_ID" runat="server" />
                            
                           
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

