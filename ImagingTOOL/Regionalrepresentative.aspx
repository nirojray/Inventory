<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Regionalrepresentative.aspx.cs" EnableEventValidation="false"  Inherits="Regionalrepresentative" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">

         function validateTextBoxBlank() {
             var Txtname = document.getElementById('<%=Txtname.ClientID %>').value;
             var TxtDesignation = document.getElementById('<%=TxtDesignation.ClientID %>').value;
             var TxtEmail = document.getElementById('<%=TxtEmail.ClientID %>').value;
             var ddlLocation = document.getElementById('<%=ddlLocation.ClientID %>');
             var ddlLocationvalue = ddlLocation.options[ddlLocation.selectedIndex].value;
             var ddlStatus = document.getElementById('<%=ddlStatus.ClientID %>');
             //var ddlStatusvalue = ddlStatus.options[ddlStatus.selectedIndex].value;
             var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

             if (ddlLocationvalue == "-1") {
                 alert("Please Select Location");
                 document.getElementById('<%=ddlLocation.ClientID %>').focus();
                 return false;
             }
             else if (Txtname == "") {
                 alert("Please Enter Name");
                 document.getElementById('<%=Txtname.ClientID %>').focus();
                 return false;
             }
             else if (TxtDesignation == "") {
                 alert("Please Enter Designation");
                 document.getElementById('<%=TxtDesignation.ClientID %>').focus();
                 return false;
             }
             else if (TxtEmail == "") {
                 alert("Please Enter Email");
                 document.getElementById('<%=TxtEmail.ClientID %>').focus();
                 return false;
             }
             else if (reg.test(TxtEmail) == false) {
                 alert('Please provide a valid email address');
                 document.getElementById("<%=TxtEmail.ClientID %>").focus();
                 return false;
             }
            <%-- if (ddlStatusvalue == "") {
                 alert("Please Select Status");
                 document.getElementById('<%=ddlStatus.ClientID %>').focus();
                 return false;
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
                      Master data
                  </h3>
                   <ul class="breadcrumb">
                       <li>
                           <a href="Workflow.aspx"><i class="icon-home"></i></a><span class="divider">&nbsp;</span>
                       </li>
                       <li>
                           <a href="#">Master data</a><span class="divider">&nbsp;</span>
                       </li>
                        <li> <a href="Regionalrepresentative.aspx">Representative Names</a><span class="divider-last">&nbsp;</span></li>                      
                   </ul>
               </div>
            </div>
            <!-- END PAGE HEADER-->
            <!-- BEGIN PAGE CONTENT-->
            <div class="row-fluid">
                <div class="span12 sortable">
                    <!-- BEGIN SAMPLE FORMPORTLET-->
                    <div class="widget">
                        
                          <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btnContinue" runat="server" CausesValidation="false" Visible="false" OnClick="btnContinue_Click"
                                                Width="0px" Height="0px" />
                                            <asp:Button ID="btnDisContinue" runat="server" CausesValidation="false" Visible="false" OnClick="btnDisContinue_Click"
                                                Width="0px" Height="0px" />
                                        </td>
                                    </tr>
                                </table>
                            <table style="width: 100%">
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        Location</td>
                                    <td>
                                        <asp:DropDownList ID="ddlLocation" runat="server" Width="285px">                                           
                                        </asp:DropDownList>
                                    </td>
                                </tr>                     
                                <tr>                                    
                                    <td>
                                        Name</td>
                                    <td>
                                        <asp:TextBox ID="Txtname"  Width="285px"  runat="server"></asp:TextBox>
                                    </td>
                                </tr> 
                                <tr>                                    
                                    <td>
                                        Designation</td>
                                    <td>
                                        <asp:TextBox ID="TxtDesignation"  Width="285px"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        Email</td>
                                    <td>
                                        <asp:TextBox ID="TxtEmail"  Width="285px"  runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>                                    
                                    <td>
                                        Status</td>
                                    <td>
                                       <asp:DropDownList ID="ddlStatus" runat="server">                                          
                                           <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="De-Active" Value="0"></asp:ListItem>
                                       </asp:DropDownList>
                                    </td>
                                </tr>                                           
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>                                   
                                    <td colspan="3" align="left">
                                        <asp:Button ID="btnCreate" runat="server" Text="Save" type="submit"  onclick="btnCreate_Click"
                                            OnClientClick="return validateTextBoxBlank();"    />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                         <asp:Button ID="btnUpdate" runat="server" Text="Update"  type="submit" Enabled="false" onclick="btnUpdate_click" OnClientClick="return validateTextBoxBlank();"
                                           />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel"  type="submit" onclick="btnCancel_Click"  />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="input-medium" style="width: 134px">
                                        &nbsp;</td>
                                    <td style="width: 80px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="input-medium"  colspan="3">
                                       <asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        &nbsp;</td>                                   
                                </tr>
                                <tr>
                                    <td class="input-medium"  colspan="3">
                                        Search Name:<asp:TextBox ID="txtSearch" runat="server"></asp:TextBox> &nbsp 
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />&nbsp
                                        <asp:Button ID="btnclear" runat="server" Text="Clear" onclick="btnClear_Click"  />
                                        &nbsp;</td>                                   
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <%--<div style="height:350px; overflow:scroll;">--%>
                                        <asp:GridView ID="gvSearch" runat="server" AutoGenerateColumns="false" Width="80%"
                                            AllowPaging="True" PageSize="10"
                                        EmptyDataText="No Record Found" CssClass="content-grid"
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                        OnPageIndexChanging="gvSearch_PageIndexChanging"
                                             OnRowCommand="gvSearch_rowcommand" >
                                           <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.no">
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblSlNo" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Location">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblLocatin" runat="server" Text='<%# Eval("Location_Name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                               
                                                  <asp:TemplateField HeaderText="Action" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                       <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" CommandName="Edited" ForeColor="Black" CommandArgument='<%#Eval("Id") %>' />&nbsp
                                                        <asp:LinkButton ID="BtnDelete" runat="server" Text="Delete" CommandName="Deleted"  ForeColor="Black" CommandArgument='<%#Eval("Id") %>' />
                                                    </ItemTemplate>
                                                     
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        &nbsp;
                                           <%-- </div>--%>
                                            </td>
                                   
                                </tr>
                            </table>
                    </div>
                    <!-- END SAMPLE FORM PORTLET-->
                </div>
            </div>

            <!-- END PAGE CONTENT-->         
         </div>
         <!-- END PAGE CONTAINER-->
      </div>
</asp:Content>

