<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="ReportStockStatement, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>
<%@ Register Assembly="RJS.Web.WebControl.PopCalendar.Net.2010" Namespace="RJS.Web.WebControl"  TagPrefix="rjs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Report
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                          <a href="#">Report</a><span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="ReportStockStatement.aspx">Stock Statement</a><span class="divider-last">&nbsp;</span></li>
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
                            <h4>Stock Statement Report</h4>
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
                            <br />
                            <br />
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                       Stock Statement</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                      Stock As on</td>
                                    <td style="width: 217px">
                                        <asp:TextBox ID="TxtFromDate" runat="server"></asp:TextBox>
                                        <popcalendar id="PopCalendar1" runat="server" control="TxtFromDate" 
                                            format="dd mmm yyyy" separator="-" showerrormessage="False">
                        <rjs:PopCalendar ID="PopCalendar3" runat="server" ShowErrorMessage="False" Separator="-"
                                                                                Format="dd mmm yyyy" 
                                            Control="TxtFromDate"></rjs:PopCalendar>
                                            
                                        </popcalendar>
                                    </td>
                                    <td>
                                        <asp:Button ID="BtnExport" runat="server" onclick="BtnExport_Click" 
                                            Text="Export" />
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                        &nbsp;</td>
                                    <td style="width: 217px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 79px">
                                        &nbsp;</td>
                                    <td style="width: 217px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                </table>
                            <br />

                                  <asp:GridView ID="Gvw_STock" runat="server" AutoGenerateColumns="False" 
                       BorderStyle="Outset" CellPadding="5"
                    Width="100%"  
                    HorizontalAlign="Left" EmptyDataText="----- No records found ------" 
                       PageSize="5" ForeColor="Black" onrowcreated="Gvw_STock_RowCreated" 
                                onrowdatabound="Gvw_STock_RowDataBound" >
                       <AlternatingRowStyle BackColor="White" />
                    <Columns>
                                    <asp:TemplateField HeaderText="Slno">
                                        <ItemTemplate>
                                            <asp:Label ID="LblSlno" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <asp:Label ID="LblProduct_Name" runat="server" Text='<%# Eval("[Product Name]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Code">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblproduct_code" runat="server" Text='<%# Eval("[Product Code]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date as on ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldateason" runat="server" Text='<%# Eval("[As On Date]") %>'></asp:Label>
                                           
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Mumbai">
                                        <ItemTemplate>
                                            <asp:Label ID="Mum_open_bal" runat="server" Text='<%# Eval("[Openning balance Mumbai]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Delhi">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldhl_open_ba" runat="server" Text='<%# Eval("[Openning balance Delhi]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chennai">
                                        <ItemTemplate>
                                            <asp:Label ID="LblChn_open_bal" runat="server" Text='<%# Eval("[Openning balance Chennai]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bangalore">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblblr_open_bal" runat="server" Text='<%# Eval("[Openning balance Bangalore]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Ahmedabad">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblahm_open_bal" runat="server" Text='<%# Eval("[Openning balance Ahmedabad]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                  


                                     <asp:TemplateField HeaderText="Mumbai">
                                        <ItemTemplate>
                                            <asp:Label ID="Mum_pur_bal" runat="server" Text='<%# Eval("[Purchase Mumbai]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Delhi">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldhl_pur_ba" runat="server" Text='<%# Eval("[Purchase Delhi]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chennai">
                                        <ItemTemplate>
                                            <asp:Label ID="LblChn_opur_bal" runat="server" Text='<%# Eval("[Purchase Chennai]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bangalore">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblblr_pur_bal" runat="server" Text='<%# Eval("[Purchase Bangalore]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Ahmedabad">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblahm_pur_bal" runat="server" Text='<%# Eval("[Purchase Ahmedabad]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>



                                           <asp:TemplateField HeaderText="Mumbai">
                                        <ItemTemplate>
                                            <asp:Label ID="Mum_sale" runat="server" Text='<%# Eval("[Sales Mumbai]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Delhi">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldhl_sale" runat="server" Text='<%# Eval("[Sales Delhi]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chennai">
                                        <ItemTemplate>
                                            <asp:Label ID="LblChn_sale" runat="server" Text='<%# Eval("[Sales Chennai]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bangalore">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblblr_sale" runat="server" Text='<%# Eval("[Sales Bangalore]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Ahmedabad">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblahm_sale" runat="server" Text='<%# Eval("[Sales Ahmedabad]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                  

                                  
                                           <asp:TemplateField HeaderText="Mumbai">
                                        <ItemTemplate>
                                            <asp:Label ID="Mum_Closing_BL" runat="server" Text='<%# Eval("[Closeing balance Mumbai]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Delhi">
                                        <ItemTemplate>
                                            <asp:Label ID="Lbldhl_Closing_BL" runat="server" Text='<%# Eval("[Closeing balance Delhi]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chennai">
                                        <ItemTemplate>
                                            <asp:Label ID="LblChn_Closing_BL" runat="server" Text='<%# Eval("[Closeing balance Chennai]") %>'></asp:Label>
                                        </ItemTemplate>
                                      
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Bangalore">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblblr_Closing_BL" runat="server" Text='<%# Eval("[Closeing balance Bangalore]") %>'></asp:Label>
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Ahmedabad">
                                        <ItemTemplate>
                                            <asp:Label ID="Lblahm_Closing_BL" runat="server" Text='<%# Eval("[Closeing balance Ahmedabad]") %>'></asp:Label>
                                        </ItemTemplate>
                                        
                                    </asp:TemplateField>
                                  


                                </Columns>
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#67A9B9" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" 
                                    HorizontalAlign="Left" Font-Names="Cambria" />
                                <PagerStyle BackColor="#67A9B9" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                                </asp:GridView>
                
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

