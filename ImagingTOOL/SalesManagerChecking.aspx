<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SalesManagerChecking.aspx.cs" Inherits="SalesManagerChecking" %>

<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl" TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function validateMandatory() {
            if (document.getElementById('<%=DrpAppRej.ClientID%>').selectedIndex == 0) {
               alert("Please Select Approved/Reject");
               document.getElementById('<%=DrpAppRej.ClientID %>').focus();
               return false;
           }
          <%--  else if (document.getElementById('<%=Txt_AppRejReason.ClientID %>').value == "") {
                alert("Please Enter Reason");
                  document.getElementById('<%=Txt_AppRejReason.ClientID %>').focus();
                  return false;
             }--%>
       }
    </script>
    <style type="text/css">
        .GridDock {
            overflow-x: auto;
            overflow-y: hidden;
            width: 200px;
            padding: 0 0 17px 0;
        }
       input[type="checkbox"]+label{
            display:inline!important;
        }
       .GridDock1 {
            overflow-x: auto;
            overflow-y: auto;
            width: 200px;
            height:300px;
            padding: 0 0 17px 0;
        }
    </style>

     <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth').width($('#dvScreenWidth').width());
        });
    </script>
      <script type="text/javascript">
        $(document).ready(function () {
            $('#dvGridWidth1').width($('#dvScreenWidth1').width());
        });
    </script>

    <div id="main-content">
        <!-- BEGIN PAGE CONTAINER-->
        <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->
            <div class="row-fluid">
                <div class="span12">

                    <h3 class="page-title">Sales
                    </h3>
                    <ul class="breadcrumb">
                        <li>
                            <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                        </li>
                        <li>
                            <a href="#">Sales</a><span class="divider">&nbsp;</span>
                        </li>

                        <li><a href="SalesManagerChecking.aspx">Sales Manager Checking</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Sales Manager Checking</h4>
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
                            <table style="width: 100%">
                                <tr>
                                    <td>From Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" Width="30%" ReadOnly="True"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate"
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                    </td>
                                    <td>To Date
                                    </td>
                                    <td>
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" Width="30%" ReadOnly="True"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate"
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnSearch" class="btn-success" runat="server" Text="Search"
                                            OnClick="BtnSearch_Click" />

                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <asp:Panel ID="Panel2" runat="server">
                                <div id="dvScreenWidth1" visible="false" style="width: 100%">
                                    <div class="GridDock1" id="dvGridWidth1" style="width: 100%">

                                        <asp:GridView ID="GvwSalesManagerChecking" runat="server" AutoGenerateColumns="False"
                                            class="table table-striped table-bordered table-advance table-hover"
                                            ShowFooter="True" ShowHeaderWhenEmpty="True" DataKeyNames="SO_ID"
                                            OnRowCommand="GvwSalesManagerChecking_RowCommand" AllowPaging="false"
                                            AllowSorting="True"
                                            OnPageIndexChanging="GvwSalesManagerChecking_PageIndexChanging">
                                            <Columns>
                                                <%--  <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="SO NO">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSONO" runat="server" Text='<%# Eval("SO_Number") %>'></asp:Label>

                                                        <asp:Label ID="hidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("SoDate") %>'></asp:Label>
                                                        <asp:HiddenField ID="HidCatagory" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="600px" />
                                                    <ItemStyle Width="600px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Vertical">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lblstate" runat="server" Text='<%# Eval("[State]") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Location">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("[Location]") %>'></asp:Label>
                                                        <%--       <asp:HiddenField ID="HidLocationID" runat="server"  value='<%# Eval("locationID") %>'/>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Sales Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSalesType" runat="server" Text='<%# Eval("SalesType") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer Order No">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblCustomerOrderNo" runat="server" Text='<%# Eval("CusutomerOrderNO") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Customer Order Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblCustomerOrderDate" runat="server" Text='<%# Eval("CusutomerOrderdate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <HeaderStyle Width="200px" />
                                                    <ItemStyle Width="200px" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Total Price">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Lbltotalprice" runat="server" Text='<%# Eval("SO_NetAmount") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Entered By">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblEnteredby" runat="server" Text='<%# Eval("Enteredby") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SO_Entered On">
                                                    <ItemTemplate>
                                                        <asp:Label ID="LblSO_EnteredOn" runat="server" Text='<%# Eval("SO_EnteredOn") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <%-- <asp:LinkButton ID="lnkLink" runat="server" 
                                                CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' CommandName="Edit1" 
                                                ToolTip="Edit"> <img src="img/Delete.png" height="18" width="18"  /></asp:LinkButton>--%>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                            CommandName="Edit1">Edit</asp:LinkButton>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>

                                <br />
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                             <td>Customer Name</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustomer" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                            
                                            <td>Sales Order Date
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="TxtSODate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                           <td>Vertical
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtVertical" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Customer State</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustState" runat="server" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>GST No</td>
                                            <td>
                                                <asp:TextBox ID="txtVatCst" runat="server" ReadOnly="true"></asp:TextBox>

                                            </td>
                                            <td>PAN</td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="txtPAN" runat="server" MaxLength="50" Width="100px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Reverse Charge</td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="txtReverseCharge" runat="server" MaxLength="50" Width="100px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Mode Of/Term Of Payment/Credit Period<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtCreditPeriod" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td>State<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                            <td>Location</td>
                                            <td>
                                                <asp:TextBox ID="TxtLocation" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>Customer Order No</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderno" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Customer Order Date</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderdate" runat="server" ReadOnly="True"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Main Category<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txttype" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Sales Type</td>
                                            <td>
                                                <asp:TextBox ID="txtsalesType" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>                                        

                                        <tr>
                                            <td>Representative<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtRepresentative" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>Warranty<span style="color: Red">*</span></td>
                                            <td>
                                                <asp:TextBox ID="txtWarranty" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                        </tr>                                      
                                         <tr>                                            
                                            <td>
                                                <asp:Label ID="lblHSN_SAC_Code" runat="server"></asp:Label>
                                            </td>
                                            <td style="margin-left: 40px">
                                                <asp:TextBox ID="TxtHSN_SAC_Code" runat="server" MaxLength="50" Width="100px" Visible="false" ReadOnly="True"></asp:TextBox>
                                            </td> 
                                        </tr>
                                    </table>
                                    <br />
                                    <br />
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
                                    <br />
                                    <br />
                                     <div id="dvScreenWidth" visible="false" style="width: 100%">
                                        <div class="GridDock" id="dvGridWidth" style="width: 100%">
                                    <asp:GridView ID="GvwSaleseOrderDetails" runat="server"
                                        AutoGenerateColumns="False" DataKeyNames="SO_ID"
                                        class="table table-striped table-bordered table-advance table-hover"
                                        ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="false" AllowSorting="True"
                                        OnPageIndexChanging="GvwSaleseOrderDetails_PageIndexChanging" OnRowDataBound="GvwSaleseOrderDetails_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidCatagory0" runat="server"
                                                        Value='<%# Eval("SO_Catagory_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                    <asp:HiddenField ID="HidProduct0" runat="server"
                                                        Value='<%# Eval("SO_Product_ID") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Current Stock">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblCurrentStock" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblDescription" runat="server" Text='<%# Eval("SO_Product_Description") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblFromDate" runat="server" Text='<%# Eval("FromDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="To Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblToDate" runat="server" Text='<%# Eval("ToDate") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="20%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="SO Pending Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPendingQuantity" runat="server" Text='<%# Eval("PendingQuantity") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Unit Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblSOPrice" runat="server" Text='<%# Eval("SubTot") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTaxName" runat="server" Text='<%# Eval("TaxName") %>'></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle Width="28%" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Tax Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblTaxAmount" runat="server" Text='<%# Eval("TaxAmt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SO Total Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="LbltotalAmount" runat="server" Text='<%# Eval("TotalAmt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                               
                                        </div> 
                                     </div>
                                </div>
                                <div class="row-fluid" style="width: 100%">

                                    <div class="span4 invoice-block pull-right" style="width: 100%">
                                        <ul class="unstyled amounts">

                                            <li>Total Amount:<asp:Label ID="Lbl_TotalAmount" runat="server" Text="0.00"></asp:Label>&nbsp;
                                                <table border="1px" frame="box">
                                                    <%--   <tr>
                                        <td>
                                        
                                            Shipping Adress
                                            </td> 
                                           
                                          <td>
                                                            Billing Adress</td>
                                           
                                          
                                        </tr>
                                        <tr>
                                         <td>
                                  

                                             <span class="style4">
                                             <asp:Label ID="lblmsg2" runat="server" Font-Bold="True" ForeColor="Black" 
                                                 Text="Label"></asp:Label>
                                             </span>
              
                                        </td>
                                         <td>
                                        <span class="style4">
                                             <asp:Label ID="lblmsg3" runat="server" Font-Bold="True" ForeColor="Black" 
                                                 Text="Label"></asp:Label>
                                             </span></td>
                                        </tr>--%>
                                                </table>
                                            </li>
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
                                                    <asp:Button ID="BtnAppRejSave" runat="server" ForeColor="Black"
                                                        class="btn-success" Text="Save" OnClientClick="return validateMandatory();" OnClick="BtnAppRejSave_Click" />
                                                    <span class="style4">&nbsp;<asp:Button ID="btnCancel" runat="server" class="btn-success" ForeColor="Black" OnClick="btnCancel_Click" Text="Cancel" />
                                                    </span>
                                                </div>
                                                &nbsp;&nbsp; </li>


                                        </ul>
                                    </div>
                                </div>
                                <asp:HiddenField ID="hidDetails_ID" runat="server" />
                                <asp:HiddenField ID="familyhidden" runat="server" />
                                <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
                            </asp:Panel>

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

