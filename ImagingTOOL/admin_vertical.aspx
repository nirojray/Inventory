<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="admin_vertical.aspx.cs" Inherits="admin_vertical" EnableEventValidation="false" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : event.keyCode
         if (charCode > 31 && (charCode < 48 || charCode > 57))
             return false;



     }
  
    </script>
      <script type="text/javascript">
       function getConfirmation(){
               var retVal = confirm("Do you want to continue ?");
               if( retVal == true ){
                  document.write ("User wants to continue!");
                  return true;
               }
               else{
                  document.write ("User does not want to continue!");
                  return false;
               }
            }
         //-->
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
                       
                    <li> <a href="admin_vertical.aspx">Verticals</a><span class="divider-last">&nbsp;</span></li>
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
                                <div class="row-fluid">
                                Search Vertical:&nbsp&nbsp<asp:TextBox ID="txtSearchVertical" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="Button1" runat="server" text="X" OnClick="Button1_Click" />&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" text="Search" OnClick="btnsearch_click" />
                            </div>
                            <!-- END FORM-->
                            <div class="row-fluid">
                               
          
    <asp:GridView ID="GvwCustomer" runat="server" Width="90%" AutoGenerateColumns="False"
                    EmptyDataText="No Record Found" CssClass="content-grid" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
                                    onrowediting="GvwCustomer_RowEditing" 
                                    onrowupdating="GvwCustomer_RowUpdating" 
                                    onpageindexchanging="GvwCustomer_PageIndexChanging" 
                                    onrowcancelingedit="GvwCustomer_RowCancelingEdit" onrowdeleting="GvwCustomer_RowDeleting">
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                        <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                <asp:Label ID="lbl_Category" runat="server" Text='<%# Eval("Vertical") %>'></asp:Label>
                                   <asp:Label ID="lbl_Category_Id1" runat="server" Text='<%# Eval("Vertical_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            <EditItemTemplate>
                                <asp:Label ID="lbl_Categoryid" runat="server" Text='<%# Eval("Vertical_ID") %>' Visible="false"></asp:Label>
                                <asp:TextBox ID="txtbox_Category" runat="server" Text='<%#Eval("Vertical")%>' Width="100px" Height="30px"></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:ButtonField   CommandName="Delete" Text="Delete" HeaderText="Delete" HeaderStyle-Width="30px"  ItemStyle-CssClass=" getConfirmation()" />
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

                            <br />
                             <table style="width: 100%">
                                 <tr>
                                     <td style="width: 185px">
                                         Vertical</td>
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
