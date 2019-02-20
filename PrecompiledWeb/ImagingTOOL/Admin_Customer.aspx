<%@ page title="" language="C#" masterpagefile="~/Main.master" autoeventwireup="true" inherits="Admin_Customer, App_Web_okblpzmr" viewStateEncryptionMode="Never" %>

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
                       
                    <li> <a href="Admin_Customer.aspx">Customer/Supplier/Transporter</a><span class="divider-last">&nbsp;</span></li>
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
                                    onrowcancelingedit="GvwCustomer_RowCancelingEdit" 
                                    onrowdeleting="GvwCustomer_RowDeleting" onselectedindexchanged="GvwCustomer_SelectedIndexChanged" 
 >
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="180px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Supplier_Name") %>'></asp:Label>
                                   <asp:Label ID="lbl_Supplier_Id1" runat="server" Text='<%# Eval("Supplier_Id") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_Contaclbl_Nametid" runat="server" Text='<%# Eval("Supplier_Id") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtbox_lbl_Name" runat="server" Text='<%#Eval("Supplier_Name")%>' Width="150px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="Type" runat="server" Text='<%# Eval("type") %>'></asp:Label>
                         
                            </ItemTemplate>
                                                      
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Contact Name" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="150px">
                            <ItemTemplate>
                                <asp:Label ID="ContactName" runat="server" Text='<%# Eval("Supplier_Contact_Name") %>'></asp:Label>
                             </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_ContactName" runat="server" Text='<%# Eval("Supplier_Contact_Name") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtbox_ContactName" runat="server" Text='<%#Eval("Supplier_Contact_Name")%>' Width="150px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Contact PhoneNO" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="ContactPhoneNO" runat="server" Text='<%# Eval("Supplier_Contact_PhoneNO") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_ContactPhoneNOID" runat="server" Text='<%# Eval("Supplier_Contact_PhoneNO") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtContactPhoneNO" runat="server" Text='<%#Eval("Supplier_Contact_PhoneNO")%>' Width="100px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Contact Email" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px">
                            <ItemTemplate>
                                <asp:Label ID="ContactEmail" runat="server" Text='<%# Eval("Supplier_Email") %>'></asp:Label>
                        
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_ContactEmailID" runat="server" Text='<%# Eval("Supplier_Email") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtContactEmail" runat="server" Text='<%#Eval("Supplier_Email")%>' Width="250px" Height="50px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Delete" Text="Delete" HeaderText="Delete" HeaderStyle-Width="60px" />
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" HeaderStyle-Width="60px" />
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
                                          Name<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txt_Name" runat="server" Width="222px"></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          &nbsp;</td>
                                     <td>
                                         &nbsp;</td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          Type<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:DropDownList ID="ddl_Type" runat="server">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          Contact Name<span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtContactName" runat="server" Width="222px"> </asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          Contact PhoneNO</td>
                                     <td>
                                         <asp:TextBox ID="txtContactPhoneNo" runat="server" Width="222px" onkeypress="return isNumberKey(event)" ></asp:TextBox>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                          Email</td>
                                     <td>
                                         <asp:TextBox ID="txtEmail" runat="server" Width="222px"></asp:TextBox>
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

