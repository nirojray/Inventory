<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Master_TaxStructure.aspx.cs" Inherits="Master_TaxStructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
      <script type="text/javascript">
   


          function validateTextBoxBlank() {




              <%--if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 0) {
                  alert("Please Select Type");
                  document.getElementById('<%=ddl_Type.ClientID %>').focus();
                  return false;
              }
              else if (document.getElementById('<%=ddlState.ClientID%>').selectedIndex == 0) {
                  alert("Please Select State");
                  document.getElementById('<%=ddlState.ClientID %>').focus();
                  return false;
              }
              else if (document.getElementById('<%=ddlLocation.ClientID%>').selectedIndex == 0) {
                  alert("Please Select Location");
                  document.getElementById('<%=ddlLocation.ClientID %>').focus();
                  return false;
              }
              else if (document.getElementById('<%=ddlcategory.ClientID%>').selectedIndex == 0) {
                  alert("Please Select category");
                  document.getElementById('<%=ddlcategory.ClientID %>').focus();
                  return false;
              }else--%>

               if (document.getElementById('<%=txtTaxStructure.ClientID %>').value == "") {
                  alert("Please Enter Tax Structure");
                  document.getElementById('<%=txtTaxStructure.ClientID %>').focus();
                  return false;
              }

              <%--if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 1) {

                  if (document.getElementById('<%=ddlSalesType.ClientID%>').selectedIndex == 0) {

                      alert("Please Select Sales Type");
                      document.getElementById('<%=ddlSalesType.ClientID %>').focus();
                      return false;
                  }

              }
            else if (document.getElementById('<%=ddl_Type.ClientID%>').selectedIndex == 2) {

                  if (document.getElementById('<%=ddlPurchaseType.ClientID%>').selectedIndex == 0) {

                      alert("Please Select Purchase Type");
                      document.getElementById('<%=ddlPurchaseType.ClientID %>').focus();
                      return false;
                  }

              }--%>
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
                       
                    <li> <a href="Master_TaxStructure.aspx">Tax Structure</a><span class="divider-last">&nbsp;</span></li>
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
                              <table style="width: 100%">
                              <%--  <tr>
                                        <td style="width: 185px">Type<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddl_Type" runat="server" Width="222px" AutoPostBack="True" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                                <asp:ListItem Value="0">--Select Type--</asp:ListItem>
                                                <asp:ListItem Value="S">Sales</asp:ListItem>
                                                <asp:ListItem Value="P">Purchases</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                
                                  <tr>
                                        <td style="width: 185px">State<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlState" runat="server" Width="222px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                         
                                                 </asp:DropDownList>
                                            </td>
                                    </tr>
                                  <tr>
                                        <td style="width: 185px">Location<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlLocation" runat="server" Width="222px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                  <tr>
                                        <td style="width: 185px">Category<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlcategory" runat="server" Width="222px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                 <tr>
                                     <td style="width: 185px">Tax Structure 
                                          <span style="color: Red">*</span></td>
                                     <td>
                                         <asp:TextBox ID="txtTaxStructure" runat="server" Width="250px" TextMode="MultiLine"> </asp:TextBox>
                                     </td>
                                 </tr>
                                 <%-- <tr id="TrSalesType" runat="server" visible="false">
                                        <td style="width: 185px">Sales Type<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlSalesType" runat="server" Width="222px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                  <tr id="TrPurchaseType" runat="server" visible="false">
                                        <td style="width: 185px">Purchase Type<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlPurchaseType" runat="server" Width="222px">
                                               
                                            </asp:DropDownList>
                                        </td>
                                    </tr>--%>
                                    <tr">
                                        <td style="width: 185px">Active Status<span style="color: Red">*</span></td>
                                        <td>
                                            <asp:DropDownList ID="ddlActive" runat="server" Width="222px">
                                                <asp:ListItem Value="1">Active</asp:ListItem>
                                                <asp:ListItem Value="0">DeActive</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                             </table>
                             <table style="width: 100%">
                                 <tr class="style4">
                                     <td>
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                         <span class="style4" style="font-weight: 700">
                                             <asp:Button ID="btnSave" runat="server" Text="Save"   OnClick="btnSave_Click" OnClientClick="return validateTextBoxBlank();"></asp:Button>
                                       
 <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClientClick="return validateTextBoxBlank();" Visible="false" OnClick="btnUpdate_Click"></asp:Button>
                                        &nbsp;&nbsp;&nbsp; <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                                             onclick="btnCancel_Click"></asp:Button>
                                         </span>
                                         <asp:Label ID="lbl_msg" runat="server" BackColor="Black" Font-Bold="True"></asp:Label>
                                     </td>
                                 </tr>
                             </table>
                            <br />
                             <div class="row-fluid">
                                Search Tax Name:&nbsp&nbsp<asp:TextBox ID="txtSearch" runat="server" Width="150px" Height="20px"></asp:TextBox>&nbsp&nbsp<asp:Button ID="Button1" runat="server" text="X" OnClick="Button1_Click" />&nbsp&nbsp<asp:Button ID="btnSearch" runat="server" text="Search" OnClick="btnsearch_click" />
                            </div>
                            <br />
                            <div class="row-fluid">
                               
          
    <asp:GridView ID="GvwTaxStructure" runat="server" Width="70%" AutoGenerateColumns="False" PageSize="10" 
                    EmptyDataText="No Record Found" CssClass="content-grid" 
                    BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="3" ForeColor="Black" GridLines="Vertical" AllowPaging="True" OnPageIndexChanging="GvwTaxStructure_PageIndexChanging" OnRowEditing="GvwTaxStructure_RowEditing" OnRowUpdating="GvwTaxStructure_RowUpdating" 
                                   >
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                     <Columns>
                       
                         <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_TaxStructure_Id" runat="server" Text='<%#Bind("ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="TaxStructure" ItemStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Label ID="lbl_TaxStructure" runat="server" Text='<%# Eval("TaxStructure") %>'></asp:Label>
                                  
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" />
                            
                        </asp:TemplateField>

                        <%--<asp:TemplateField HeaderText="Type" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="Type" runat="server" Text='<%# Eval("TypeName") %>'></asp:Label>
                         
                            </ItemTemplate>
                                                      
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="State" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" Text='<%# Eval("State_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                           
                                        </asp:TemplateField>


                       
                           <asp:TemplateField HeaderText="Location" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%# Eval("Location_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                           
                                        </asp:TemplateField>

                           <asp:TemplateField HeaderText="Category" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                           
                                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="SalesType" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSalesType" runat="server" Text='<%# Eval("SalesTypeName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                           
                                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="PurchaseType" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPurchaseType" runat="server" Text='<%# Eval("PurchaseTypeName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            
                                        </asp:TemplateField>--%>
                           <asp:TemplateField HeaderText="Active" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActive" runat="server" Text='<%# Eval("ActiveStatus") %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" />
                                            
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Modify">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EDIT" CommandArgument='<%# Bind("ID") %>' Text="Edit">
                                        Edit
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                       <%--   <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%# Bind("ID") %>' Text="Edit">
                                        Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                       
                    </Columns>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
  
                                
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

