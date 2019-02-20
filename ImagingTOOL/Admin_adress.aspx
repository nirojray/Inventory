<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Admin_adress.aspx.cs" Inherits="Admin_adress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script language="javascript" type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
        }
  
    </script>
  <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Admin
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                           Admin<span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> Adress<a href="Admin_product.aspx">t</a><span class="divider-last">&nbsp;</span></li>
                   </ul>
               </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                  
                        <div class="widget-body">
                            <!-- BEGIN FORM-->
                            <form  class="form-horizontal">
                              
                            </form>
                            <!-- END FORM-->
                            <div class="row-fluid">
                               
          
    <asp:GridView ID="GvwCustomer" runat="server" Width="90%" AutoGenerateColumns="False"
                    EmptyDataText="No Record Found" CssClass="content-grid" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
                                    onrowediting="GvwCustomer_RowEditing" 
                                    onrowupdating="GvwCustomer_RowUpdating" 
                                    onpageindexchanging="GvwCustomer_PageIndexChanging" 
                                    onrowcancelingedit="GvwCustomer_RowCancelingEdit" onrowdeleting="GvwCustomer_RowDeleting" 
 >
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                   <asp:Label ID="lbl_Supplier_Id1" runat="server" Text='<%# Eval("Address_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_Contaclbl_Nametid" runat="server" Text='<%# Eval("Address_ID") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtbox_lbl_Name" runat="server" Text='<%#Eval("Location")%>' Width="150px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="Type" runat="server" Text='<%# Eval("Address_Type") %>'></asp:Label>
                         
                            </ItemTemplate>
                                                      
                        </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="Address" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Address" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_AddressID" runat="server" Text='<%# Eval("Address") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        

                            <asp:TemplateField HeaderText="Address1" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Address1" runat="server" Text='<%# Eval("Address1") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_AddressID1" runat="server" Text='<%# Eval("Address1") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtAddress1" runat="server" Text='<%#Eval("Address1")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address2" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Address2" runat="server" Text='<%# Eval("Address2") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_AddressID2" runat="server" Text='<%# Eval("Address2") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtAddress2" runat="server" Text='<%#Eval("Address2")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address3" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Address3" runat="server" Text='<%# Eval("Address3_Pincode") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_AddressID3" runat="server" Text='<%# Eval("Address3_Pincode") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtAddress3" runat="server" Text='<%#Eval("Address3_Pincode")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="VAT_TIN" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_VAT_TIN" runat="server" Text='<%# Eval("VAT_TIN") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_VAT_TIN" runat="server" Text='<%# Eval("VAT_TIN") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtVAT_TIN" runat="server" Text='<%#Eval("VAT_TIN")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CST_No" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_CST_No" runat="server" Text='<%# Eval("CST_No") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_CST_No" runat="server" Text='<%# Eval("CST_No") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtCST_No" runat="server" Text='<%#Eval("CST_No")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField CommandName="Delete" Text="Delete" HeaderText="Delete" HeaderStyle-Width="60px" />
                       <%-- <asp:CommandField ShowEditButton="True" HeaderText="Edit" HeaderStyle-Width="60px" />--%>
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

                            <br />
                             <table style="width: 100%">
                                 <tr>
                                     <td style="width: 185px">
                                          Display Name<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Name" runat="server" Width="222px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          Addres Type(shiping/billing)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:DropDownList ID="ddl_address_type" runat="server">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                    <tr>
                                     <td style="width: 185px">
                                           Type(Purchase/Sales)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:DropDownList ID="ddl_PS" runat="server">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                       Address<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtAddress" runat="server" Width="471px"></asp:TextBox>
                                     </td>
                                 </tr>
                                   <tr>
                                     <td style="width: 185px">
                                         Address1<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtAddress1" runat="server" Width="471px"> </asp:TextBox>
                                     </td>
                                 </tr>
                                   <tr>
                                     <td style="width: 185px">
                                         Address2<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtAddress2" runat="server" Width="471px"> </asp:TextBox>
                                     </td>
                                 </tr>
                                <tr>
                                     <td style="width: 185px">
                                         Address3(pincode)<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtAddress3" runat="server" Width="471px"> </asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                         VAT TIN<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtVAT" runat="server" Width="471px"> </asp:TextBox>
                                     </td>
                                 </tr>
                                   <tr>
                                     <td style="width: 185px">
                                        CST No<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtCST" runat="server" Width="471px"> </asp:TextBox>
                                     </td>
                                 </tr>
                             </table>
                             <table style="width: 100%">
                                 <tr class="style4">
                                     <td>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                         <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                             onclick="btnCancel_Click" />
                                         </span>
                                         <asp:Label ID="lbl_msg" runat="server" BackColor="Black" Font-Bold="True"></asp:Label>
                                     </td>
                                 </tr>
                             </table>

                                
                            </div>
                           
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

