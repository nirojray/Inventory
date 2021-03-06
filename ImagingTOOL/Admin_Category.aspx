﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Admin_Category.aspx.cs" Inherits="Admin_Category" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <script type="text/javascript">
   


       function validateTextBoxBlank() {
              
           if (document.getElementById('<%=txtCategory.ClientID %>').value == "") {
               alert("Please Enter Category");
               document.getElementById('<%=txtCategory.ClientID %>').focus();
               return false;
           }
       }
    </script>
  <div id="main-content">
         <!-- BEGIN PAGE CONTAINER-->
         <div class="container-fluid">
            <!-- BEGIN PAGE HEADER-->   
            <div class="row-fluid">
               <div class="span12">
                  
                  <h3 class="page-title">
                      Master Data
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                           Master Data<span class="divider">&nbsp;</span>
                       </li>
                       
                    <li> <a href="Admin_Category.aspx">Category</a><span class="divider-last">&nbsp;</span></li>
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
                                Search Category:&nbsp&nbsp<asp:TextBox ID="txtSearch" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="Button1" runat="server" text="X" OnClick="Button1_Click" />&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" text="Search" OnClick="btnsearch_click" />
                            </div>
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
                       <asp:TemplateField HeaderText="Main Category" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_MainCategory" runat="server" Text='<%# Eval("M_CategoryName") %>'></asp:Label>                                   
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />                           
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Category" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                                   <asp:Label ID="lbl_Category_Id1" runat="server" Text='<%# Eval("Category_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_Categoryid" runat="server" Text='<%# Eval("Category_ID") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtbox_Category" runat="server" Text='<%#Eval("Category_Name")%>' Width="150px" Height="30px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:ButtonField CommandName="Delete" Text="Delete" HeaderText="Delete" HeaderStyle-Width="30px" />
                        <asp:CommandField ShowEditButton="True" HeaderText="Edit" HeaderStyle-Width="30px" />
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
  <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnContinue" runat="server" OnClick="btnContinue_Click" CausesValidation="false" Visible="false"
                                                Width="0px" Height="0px" />
                                            <asp:Button ID="btnDisContinue" runat="server" OnClick="btnDisContinue_Click" CausesValidation="false" Visible="false"
                                                Width="0px" Height="0px" />
                                        </td>
                                    </tr>
                                </table>
                            <br />
                             <table style="width: 100%">
                                  <tr>
                                     <td style="width: 185px">
                                         Category</td>
                                     <td>
                                         <asp:DropDownList ID="ddlCategory" runat="server" Width="222px">
                                         </asp:DropDownList>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td style="width: 185px">
                                        Sub Category</td>
                                     <td>
                                         <asp:TextBox ID="txtCategory" runat="server" Width="222px"></asp:TextBox>
                                     </td>
                                 </tr>
                             </table>
                             <table style="width: 100%">
                                 <tr class="style4">
                                     <td>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                         <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" OnClientClick="return validateTextBoxBlank();"/>
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
