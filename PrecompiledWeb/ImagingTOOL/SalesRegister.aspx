<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="SalesRegister, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Sales
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Sales</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="SalesRegister.aspx">Sales Register</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Sales Register</h4>
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
                                    <td style="height: 38px">
                                        From Date
                                    </td>
                                    <td style="height: 38px">
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate" 
                                            Format="MM/dd/yyyy" Separator="-" ShowErrorMessage="False" />
                                    </td>
                                    <td style="height: 38px">
                                        To Date
                                    </td>
                                    <td style="height: 38px">
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate" 
                                                Format="MM/dd/yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td style="height: 38px">
                                    <asp:Button id="BtnSearch" class="btn-success" runat ="server" Text="Search" 
                                            onclick="BtnSearch_Click" />
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                       
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="GvwSalesRegister" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                              ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="SO_ID" 
                                onrowcommand="GvwSalesRegister_RowCommand">
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
                                       
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Vertical">
                                        <ItemTemplate>
                                            <asp:Label ID="LblVertical" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                        </ItemTemplate>
                                          
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location">
                                        <ItemTemplate>
                                            <asp:Label ID="LblLocation" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Supplier">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tax">
                                        <ItemTemplate>
                                            <asp:Label ID="LblTax" runat="server" Text='<%# Eval("Tax") %>'></asp:Label>
                                        </ItemTemplate>
                                   
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
                         
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                           
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                So No. 
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtSoNo" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td style="width: 163px">
                                                Sales Order Date
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="TxtSODate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:GridView ID="GvwSaleseOrderDetails" runat="server" 
        AutoGenerateColumns="False"  DataKeyNames="SO_ID"
        class="table table-striped table-bordered table-advance table-hover" 
       ShowHeaderWhenEmpty="True" Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSO_ID" runat="server"  Text='<%# Eval("SO_ID") %>'></asp:Label>
                                                   <asp:Label ID="lblhidennID" runat="server" Text='<%# Eval("SO_ID") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Catagory">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCatagory" runat="server"  Text='<%# Eval("category") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="Product">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("SO_Quantity") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="LblPrice" runat="server" 
                        Text='<%# Eval("SO_UnitPrice") %>'></asp:Label>
                                                </ItemTemplate>
                                             
                                            </asp:TemplateField>
                                           
                                            
                                        </Columns>
                                    </asp:GridView>
                                     <div class="row-fluid" style="width: 100%">
                                         <div class="span4 invoice-block pull-right" style="width: 100%">
                                             <ul class="unstyled amounts">
                                                 <li style="height: 41px">
                                                     <div class="span4 invoice-block pull-left" style="width: 99%; height: 57px;">
                                                         Invoice No<asp:TextBox ID="Txt_InvoiceNo" runat="server"></asp:TextBox>
                                                         Invocie Date<asp:TextBox ID="Txt_InvoiceDate" runat="server" MaxLength="50" 
                                                             width="30%"></asp:TextBox>
                                                         <rjs:PopCalendar ID="PopCalendar3" runat="server" Control="Txt_InvoiceDate" 
                                                             Format="mm dd yyyy" Separator="-" ShowErrorMessage="False" />
&nbsp;
                                                         <asp:Button ID="BtnInvoiceSave" runat="server" class="btn-success" 
                                                             ForeColor="Black"  Text="Save" onclick="BtnInvoiceSave_Click" />
                                                     </div>
                                                     &nbsp;&nbsp; </li>
                                             </ul>
                                         </div>
                                    </div>
                                    <br />
                            </asp:Panel>
                                    <asp:HiddenField ID="hidDetails_ID" runat="server" />
                   
                    <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
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
    </div>
</asp:Content>

