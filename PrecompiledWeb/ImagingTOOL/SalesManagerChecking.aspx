<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="SalesManagerChecking, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>
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
                       
                    <li> <a href="SalesManagerChecking.aspx">Sales Manager Checking</a><span class="divider-last">&nbsp;</span></li>
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
                                    <td>
                                        From Date
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Txt_FromDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                        <rjs:PopCalendar ID="PopCalendar2" runat="server" Control="Txt_FromDate" 
                                            Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                    </td>
                                    <td>
                                        To Date
                                    </td>
                                    <td>
                                        <div class="controls">
                                            <asp:TextBox ID="Txt_ToDate" runat="server" MaxLength="50" width="30%"></asp:TextBox>
                                            <rjs:PopCalendar ID="PopCalendar1" runat="server" Control="Txt_ToDate" 
                                                Format="dd mmm yyyy" Separator="-" ShowErrorMessage="False" />
                                        </div>
                                    </td>
                                    <td>
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
                            <asp:Panel ID="Panel2" runat="server">
                            
                            <asp:GridView ID="GvwSalesManagerChecking" runat="server" AutoGenerateColumns="False" 
                                class="table table-striped table-bordered table-advance table-hover" 
                                ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%" DataKeyNames="SO_ID" 
                                onrowcommand="GvwSalesManagerChecking_RowCommand" AllowPaging="True" 
                                AllowSorting="True" 
                                onpageindexchanging="GvwSalesManagerChecking_PageIndexChanging">
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
                                               <asp:HiddenField ID="HidLocationID" runat="server"  value='<%# Eval("locationID") %>'/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSupplier" runat="server" Text='<%# Eval("Supplier") %>'></asp:Label>
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
                         </asp:Panel>
                            <br />
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="widget-body">
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                Vertical
                                            </td>
                                            <td>
                                                <asp:TextBox ID="TxtVertical" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                Sales Order Date
                                            </td>
                                            <td>
                                                <div class="controls">
                                                    <asp:TextBox ID="TxtSODate" runat="server" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Location</td>
                                            <td>
                                                <asp:TextBox ID="TxtLocation" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                Customer</td>
                                            <td>
                                                <asp:TextBox ID="TxtSupplier" runat="server" ReadOnly="True"></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                           <tr>
                                            <td>
                                                Customer Order No</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderno" runat="server" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                Customer Order Date</td>
                                            <td>
                                                <asp:TextBox ID="TxtCustmerOrderdate" runat="server" ReadOnly="True"></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <asp:GridView ID="GvwSaleseOrderDetails" runat="server" 
        AutoGenerateColumns="False"  DataKeyNames="SO_ID"
        class="table table-striped table-bordered table-advance table-hover" 
       ShowHeaderWhenEmpty="True" Width="100%" AllowPaging="True" AllowSorting="True" 
                                        onpageindexchanging="GvwSaleseOrderDetails_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Slno">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Catagory">
                                                     <ItemTemplate>
                                                         <asp:Label ID="lblCatagory" runat="server" Text='<%# Eval("category") %>'></asp:Label>
                                                         <asp:HiddenField ID="HidCatagory0" runat="server" 
                                                             value='<%# Eval("catagoryid") %>' />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                               
                                                 <asp:TemplateField HeaderText="Product">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblProduct" runat="server" Text='<%# Eval("Product") %>'></asp:Label>
                                                         <asp:HiddenField ID="HidProduct0" runat="server" 
                                                             value='<%# Eval("productid") %>' />
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Quantity">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("SO_Quantity") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Product Price">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("SO_UnitPrice") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Tax">
                                                     <ItemTemplate>
                                                         <asp:Label ID="Lbltaxid" runat="server" Text='<%# Eval("taxID") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="PO Total Price">
                                                     <ItemTemplate>
                                                         <asp:Label ID="LbltotalAmount" runat="server" 
                                                             Text='<%# Eval("SO_TotalAmount") %>'></asp:Label>
                                                     </ItemTemplate>
                                                 </asp:TemplateField>
                                                
                                             </Columns>
                                         </asp:GridView>
                                </div>
                               <div class="row-fluid" style="width:100%">
                            
                                <div class="span4 invoice-block pull-right" style="width:100%">
                                    <ul class="unstyled amounts">
                                        
                                        <li> Total Amount:<asp:Label ID="Lbl_TotalAmount" runat="server" Text="0.00"></asp:Label>&nbsp; <table border="1px" frame="box">
                                        <tr>
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
                                        </tr>
                                        </table> </li>
                                        <li style="height:85px"> <div class="span4 invoice-block pull-left"  
                                                style="width:99%; height: 57px;"> Approved/Reject:<asp:DropDownList 
                                                ID="DrpAppRej" runat="server" Width="95px">
                                                <asp:ListItem Value="1">Select</asp:ListItem>
                                                <asp:ListItem Value="20">Accepted</asp:ListItem>
                                                <asp:ListItem Value="30">Rejected</asp:ListItem>
                                            </asp:DropDownList>
&nbsp;
                                            <asp:TextBox ID="Txt_AppRejReason" runat="server" Height="77px" 
                                                TextMode="MultiLine" Width="186px"></asp:TextBox>
                                            <asp:Button  ID="BtnAppRejSave" runat="server" ForeColor="Black"  
                                                class="btn-success" Text ="Save" onclick="BtnAppRejSave_Click"/>  </div> 
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

