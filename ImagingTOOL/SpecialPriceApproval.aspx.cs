using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using System.Text;
using System.IO;
using System.Web.Configuration;

public partial class SpecialPriceApproval : System.Web.UI.Page
{
    BusinessLogicLayer.SpecialPriceApproval objprop = new BusinessLogicLayer.SpecialPriceApproval();
    ClsPurchaseOrder objBlPO = new ClsPurchaseOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            GetMasterList("SU", ddlSupplier);
            BindMainCategory();
            BindSANumber();
            txtDistributorName.Text = "Centillion Solution And Services (P) Ltd";
            if (Session["SPAStatus"] == "0")
            {
                Session["SANo"] = 0;
               // PrePopulateSaDetails();
                Binddata();
                ddlSANumber.Visible = false;
                ddlServiceAttach.SelectedValue = "2";
                ddlServiceAttach.Enabled = false;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "VisibleddlSANo();", true);
                ddlSAappended.SelectedValue = "2";
                ddlSAappended.Enabled = false;
               
            }
            else
            {
                PrePopulateSaDetails();
                ddlSANumber.Visible = true;
                ddlServiceAttach.SelectedValue = "1";
                ddlServiceAttach.Enabled = true;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "VisibleddlSANo();", true);
                ddlSAappended.SelectedValue = "1";
                ddlSAappended.Enabled = true;
                ddlSANumber.SelectedValue = Convert.ToString(Session["SANoValue"].ToString());

            }
        }
    }
    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DrpList.Items.Clear();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }
        catch (Exception Ex)
        {

        }
    }
    public void BindMainCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = ClsMas.GetMainCategoryforSPA();
            if (DT.Rows.Count > 0)
            {
                ddlType.Items.Clear();
                ddlType.DataSource = DT;
                ddlType.DataValueField = "M_categoryid";
                ddlType.DataTextField = "M_CategoryName";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("Select Type", "0"));
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void BindSubCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlType.SelectedValue));
            if (DT.Rows.Count > 0)
            {
                ddlCatagory.Items.Clear();
                ddlCatagory.DataSource = DT;
                ddlCatagory.DataValueField = "ID";
                ddlCatagory.DataTextField = "NAME";
                ddlCatagory.DataBind();
                ddlCatagory.Items.Insert(0, new ListItem("Select Catagory", "0"));
            }
            else
            {
                ddlCatagory.Items.Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void BindProducts()
    {
        try
        {
            DataTable DTProduct = BusinessServices.Get_PO_ProductOnCategory(Convert.ToInt32(ddlSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlCatagory.SelectedValue));
            ddlproduct.Items.Clear();
            ddlproduct.DataSource = DTProduct;
            ddlproduct.DataTextField = "Product";
            ddlproduct.DataValueField = "ID";
            ddlproduct.DataBind();
            ddlproduct.Items.Insert(0, new ListItem("Select Product", "0"));
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public void BindSANumber()
    {
        DataTable Dt = ClsPurchaseOrder.GetServiceAttachNumberForSPA();
        if (Dt.Rows.Count > 0)
        {
            ddlSANumber.Items.Clear();
            ddlSANumber.DataSource = Dt;
            ddlSANumber.DataValueField = "id";
            ddlSANumber.DataTextField = "SA_Number";
            ddlSANumber.DataBind();
            ddlSANumber.Items.Insert(0, new ListItem("Select SA Number", "0"));
        }
        else
        {
            ddlSANumber.Items.Clear();
            ddlSANumber.Items.Insert(0, new ListItem("Select SA Number", "0"));
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindSubCategory();

        }
        catch (Exception ex)
        {

        }
    }
    protected void ddlCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            BindProducts();
            if (Session["SPAStatus"] == "0")
            {
                ddlSANumber.Visible = false;
            }
            else
            {
                ddlSANumber.Visible = true;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int SPAStatus = Convert.ToInt32(Session["SPAStatus"]);
            if (SPAStatus == 1)
            {
                if (ddlSANumber.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Service Attach Number.');</script>", false);
                    return;
                }

                DataTable DtSA = ClsPurchaseOrder.GetSADetailsForSPA(ddlSANumber.SelectedItem.Text.Trim());

                if (DtSA.Rows.Count > 0)
                {
                    string FilePathSave = "";
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Charset = "";


                    HttpContext.Current.Response.ContentType = "application/msword";

                    string strFileName = string.Empty;
                    strFileName = "SpecialPriceApprovalDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

                    #region SAA Design

                    StringBuilder strHTMLContent1 = new StringBuilder();

                    strHTMLContent1.Append("<img src='" + WebConfigurationManager.AppSettings["kodac1Logo"] + "'>".ToString());

                    // strHTMLContent1.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                    // strHTMLContent.Append("< img src = '~/images/kodac.png' visible = 'true' runat = 'server' style = 'width: 75px; height: 41px' />".ToString());
                    //strHTMLContent.Append("<br>".ToString());

                    strHTMLContent1.Append(" <h1 title='Heading' align='Center' style='font-family:Calibri;font-size:17px;background:#C0C0C0'>SERVICE ATTACH APPROVAL FORM </h1>".ToString());
                    strHTMLContent1.Append("<br>".ToString());

                    strHTMLContent1.Append("<table width='100%' border='2' style='font-family:Calibri;font-size:17px;'>".ToString());

                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td style='width: 100px;background:#99CC00'><b>SERVICE ATTACH APPROVAL FORM</b></td>".ToString());            
                    //strHTMLContent.Append("</tr><br/>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td rowspan='3' colspan='2'>".ToString());

                    strHTMLContent1.Append("<img src='" + WebConfigurationManager.AppSettings["CentillionLogo"] + "'>".ToString());
                    //strHTMLContent1.Append("<img src='"+ @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\logo.jpg'>".ToString());

                    strHTMLContent1.Append(" </td>");
                    strHTMLContent1.Append("<td colspan='2'>Name of  End User </td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Enduser_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());
                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Name of  Distributor </td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Distributor_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Name of Reseller</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Reseller_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td>Cat No</td>".ToString());
                    strHTMLContent1.Append("<td>Model </td>".ToString());
                    strHTMLContent1.Append("<td> Total Quantity </td>".ToString());
                    strHTMLContent1.Append("<td> Total Period including Standard One year </td>".ToString());
                    strHTMLContent1.Append("<td> Name of nearest Competitor offering Service Attach </td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Product_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Product_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("<td> " + DtSA.Rows[0]["TotalQuantity"].ToString() + " </td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["TotalPeriod"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Competitor_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'></td>".ToString());
                    strHTMLContent1.Append("<td>Distributor Price(INR) </ td>".ToString());
                    strHTMLContent1.Append("<td> Reseller  Price(INR)</ td>".ToString());
                    strHTMLContent1.Append("<td> End User Price(INR) </ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Unit Product Sales Price Without Discount</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["UPSWOutDcnt_Dstbtrprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td> " + DtSA.Rows[0]["UPSWOutDcnt_Rsprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["UPSWOutDcnt_Euprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Unit Product Sales Price With Discount</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["UPSWDcnt_DstbtrPrice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td> " + DtSA.Rows[0]["UPSWDcnt_Rsprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["UPSWDcnt_Euprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Unit Service Attach Without Discount</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["USAWOutDcnt_Dstbtrprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td> " + DtSA.Rows[0]["USAWOutDcnt_Rsprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["USAWOutDcnt_Euprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Service Attach With Discount</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["USAWDcnt_DstbtrPrice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td> " + DtSA.Rows[0]["USAWDcnt_Rsprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["USAWDcnt_Euprice"].ToString() + "</ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("</table>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    //DateTime WDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    //string WarrentyDate = WDate.ToString("dd/MM/yyyy");
                    string WarrentyDate = "";
                    if (DtSA.Rows[0]["Warrenty"].ToString() != "")
                    {
                        DateTime WDate = Convert.ToDateTime(DtSA.Rows[0]["Warrenty"].ToString());
                        WarrentyDate = WDate.ToString("dd/MM/yyyy");
                    }
                    strHTMLContent1.Append("<label><font face='Calibri' size='4'>Above prices valid for Warranty until (dd/mm/yyyy) :</font></label>" + WarrentyDate);
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());

                    strHTMLContent1.Append("<table border='2' width='100%' style='font-family:Calibri;font-size:17px;'>".ToString());
                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td>Name</td>".ToString());
                    strHTMLContent1.Append("<td>(Sales Manager)</ td>".ToString());
                    strHTMLContent1.Append("<td>(Service Manager)</ td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td>Signature</td>".ToString());
                    strHTMLContent1.Append("<td></td>".ToString());
                    strHTMLContent1.Append("<td></td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td>Date</td>".ToString());
                    strHTMLContent1.Append("<td></td>".ToString());
                    strHTMLContent1.Append("<td></td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("</table>".ToString());

                    strHTMLContent1.Append("<br>".ToString());
                    //strHTMLContent1.Append("<p align='Center'> Note : This is dynamically generated word document </p>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    //strHTMLContent1.Append("<br>".ToString());
                    #endregion

                    #region SPA Design

                    StringBuilder strHTMLContent = new StringBuilder();

                    strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["kodac1Logo"] + "'>".ToString());
                    //strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                    //strHTMLContent.Append("<img src='" + @"E:\kushal\Narendar_reddy\New folder\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                    // strHTMLContent.Append("< img src = '~/images/kodac.png' visible = 'true' runat = 'server' style = 'width: 75px; height: 41px' />".ToString());
                    //strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<h1 title='Heading' align='Center' style='font-family:Calibri;font-size:17px;background:#C0C0C0'>SPECIAL PRICE APPROVAL FORM </h1>".ToString());
                    strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<table width='100%' style='font-family:Calibri;font-size:17px;'>".ToString());
                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td align='center'>Special Price Approval No:</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());
                    strHTMLContent.Append("</table>".ToString());
                    strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<table width='100%' border='2' style='font-family:Calibri;font-size:17px;'>".ToString());

                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td style='width: 100px;background:#99CC00'><b>SERVICE ATTACH APPROVAL FORM</b></td>".ToString());            
                    //strHTMLContent.Append("</tr><br/>".ToString());
                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td colspan='2'>Name of  End User </td>".ToString());
                    //strHTMLContent.Append("<td>" + txtEndusername.Text + "</td>".ToString());
                    //strHTMLContent.Append("<td>Name of Reseller</td>".ToString());
                    //strHTMLContent.Append("<td>" + txtResellerName.Text + "</td>".ToString());
                    //strHTMLContent.Append("</tr>".ToString());
                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td>Name of  Distributor </td>".ToString());
                    //strHTMLContent.Append("<td colspan='4'>" + txtDistributorName.Text + "</td>".ToString());
                    //strHTMLContent.Append("</tr>".ToString());


                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td rowspan='3' colspan='2'>".ToString());

                    strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["CentillionLogo"] + "'>".ToString());

                    // strHTMLContent.Append("<img src='"+ @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\logo.jpg'>".ToString());

                    strHTMLContent.Append(" </td>");
                    strHTMLContent.Append("<td colspan='2'>Name of End User</td>".ToString());
                    strHTMLContent.Append("<td>" + txtEndusername.Text + "</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Name of Reseller</td>".ToString());
                    strHTMLContent.Append("<td>" + txtResellerName.Text + "</td>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Name of Distributor</td>".ToString());
                    strHTMLContent.Append("<td>" + txtDistributorName.Text + "</td>".ToString());

                    strHTMLContent.Append("</tr>".ToString());
                    strHTMLContent.Append("</tr>".ToString());




                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Cat No</td>".ToString());
                    strHTMLContent.Append("<td>Model </td>".ToString());
                    strHTMLContent.Append("<td rowspan='2'>Distributor Price (INR) as per applicable slab* </td>".ToString());
                    strHTMLContent.Append("<td rowspan='2'>Reseller Price (INR) </td>".ToString());
                    strHTMLContent.Append("<td rowspan='2'> End User Price (INR) </td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>" + ddlproduct.SelectedItem.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + ddlproduct.SelectedItem.Text + "</td>".ToString());
                    //strHTMLContent.Append("<td colspan='3'>  </td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());


                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Unit Product Price without Discount </td>".ToString());
                    strHTMLContent.Append("<td>" + txtUPPWOutDcnt_Dstbtrprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtUPPWOutDcnt_Rsprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtUPPWOutDcnt_EUprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Quantity </td>".ToString());// colspan='2'
                    strHTMLContent.Append("<td>" + txtQuantity.Text + "</ td>".ToString());// colspan='3'
                    strHTMLContent.Append("<td>" + txtQuantity.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + txtQuantity.Text + "</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make1:" + txtCompUPP_Make1.Text + "</br>Model1:" + txtCompUPP_Model1.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtCUPP_Rsprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Euprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make2:" + txtCompUPP_Make2.Text + "</br>Model2:" + txtCompUPP_Model2.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice2.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtCUPP_Rsprice2.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Euprice2.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Special Unit Product Price Requested </td>".ToString());
                    strHTMLContent.Append("<td>" + txtSUPReq_Dstbtrprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtSUPReq_Rsprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtSUPReq_Euprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Approved Unit Product Price </td>".ToString());
                    strHTMLContent.Append("<td>" + txtAUP_Dstbtrprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtAUP_Rsprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtAUP_Euprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>% variation from standard price</td>".ToString());
                    strHTMLContent.Append("<td>" + txtVSP_Dstbtrprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtVSP_Rsprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtVSP_Euprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Service Attach ? (Y/N)</td>".ToString());
                    strHTMLContent.Append("<td colspan='3'>" + ddlServiceAttach.SelectedItem.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Service Attach Approval Form filled and appended? (Y/N)</td>".ToString());
                    strHTMLContent.Append("<td colspan='3'>" + ddlSAappended.SelectedItem.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("</table>".ToString());

                    #endregion

                    strHTMLContent.Append("<br>".ToString());
                    //DateTime PoPlacementUntil = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    //string PoPlacementUntilDate = PoPlacementUntil.ToString("dd/MM/yyyy");
                    string PoPlacementUntilDate = string.Empty;
                    strHTMLContent.Append("<label><font face='Calibri' size='4'>Above prices valid for PO placement until (dd/mm/yyyy) :</font></label>" + PoPlacementUntilDate);
                    strHTMLContent.Append("<br>".ToString());
                    // strHTMLContent.Append("Orders executed at above prices don’t qualify for other additional discounts that are in place.Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.".ToString());
                    strHTMLContent.Append("<label><font face='Calibri' size='4'>Orders executed at above prices do not qualify for other additional discounts that are in place.</font></label>".ToString());
                    strHTMLContent.Append("<br>".ToString());
                    strHTMLContent.Append("<label><font face='Calibri' size='4'>Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.</font></label>");
                    strHTMLContent.Append("<br>".ToString());
                    strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<table border='2' width='100%' style='font-family:Calibri;font-size:17px;'>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td></td>".ToString());
                    strHTMLContent.Append("<td>(Kodak Alaris India Pvt Ltd)</ td>".ToString());
                    strHTMLContent.Append("<td>(Distributor)</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Name</td>".ToString());
                    strHTMLContent.Append("<td> </ td>".ToString());
                    strHTMLContent.Append("<td>Binu R M</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Signature</td>".ToString());
                    strHTMLContent.Append("<td></td>".ToString());
                    strHTMLContent.Append("<td>".ToString());
                    strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["BinuSign"] + "'>".ToString());
                    strHTMLContent.Append("</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Date</td>".ToString());
                    strHTMLContent.Append("<td></td>".ToString());
                    strHTMLContent.Append("<td></td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("</table>".ToString());

                    strHTMLContent.Append("<br>".ToString());



                    //StreamWriter sw = File.CreateText(MapPath("myFile.txt"));
                    //sw.WriteLine( txtFile.Text );
                    //sw.Close();

                    // Convert to string
                    string strFileData = strHTMLContent.ToString() + strHTMLContent1.ToString();
                    string strFolderValue = WebConfigurationManager.AppSettings["SPAApprovalFiles"];
                    //string strFolderValue = @"\\192.168.50.158\Word\SPAApprovalFiles\";
                    // string strFolderValue = @"D:\CSS Projects\Inventory_VSS_04-May-2017\ImagingTOOL\Word\"; \\192.168.50.158\Word   \\192.168.50.158\Word        
                    //System.IO.
                    // Directory.CreateDirectory(strFolderValue);
                    DirectoryInfo Folder = new DirectoryInfo(strFolderValue);

                    //objprop.P_SAFilename = strFileName;
                    //objprop.P_SAFilepath = strFolderValue.ToString() + strFileName.ToString();
                    string SAFilename = strFileName;
                    string SAFilePath = strFolderValue.ToString() + strFileName.ToString();
                    objprop.P_SPAAttachFileName = SAFilename;
                    objprop.P_SPAAttachFilePath = SAFilePath;
                    BindProprtice();

                    int VariationPercentage = 0;
                    if (ChkVariationPercnt.Checked)
                    {
                        VariationPercentage = 1;
                    }
                    else
                    {
                        VariationPercentage = 0;
                    }
                    int SUPPRequestStatus = 0;
                    if(ChkSPR.Checked)
                    {
                        SUPPRequestStatus = 1;
                    }
                    else
                    {
                        SUPPRequestStatus = 0;
                    }

                    // int i = 1;
                    int i = objBlPO.InsertSpecialPriceApproval(objprop, VariationPercentage, SUPPRequestStatus);

                    if (i > 0)
                    {
                        if (Folder.Exists)
                        {
                            if (strFileData != string.Empty)
                            {
                                // build the path
                                FilePathSave = Folder.ToString() + strFileName;

                                // if file exist delete and then save again
                                // else save file
                                File.WriteAllText(FilePathSave, strFileData); // is supposed to overwrite the file if it is there but doesn't

                            }
                            else
                            {
                                lblMsg.Text = "(Nothing to save)";
                                return;
                            }

                            // If we can't find the folder
                        }
                        else
                        {
                            lblMsg.Text = "Folder [" + strFolderValue + "not found]";
                            return;
                        }
                        lblMsg.Text = "Inserted succesfully.";
                        objBlPO.MAIL_FOR_SpecialPriceApprovalForDocFile();
                        ClearInputs(Page.Controls);
                        Binddata();
                        Session["SPAStatus"] = "0";

                        ddlSANumber.Visible = false;
                        ddlServiceAttach.SelectedValue = "2";
                        ddlServiceAttach.Enabled = false;
                        ddlSAappended.SelectedValue = "2";
                        ddlSAappended.Enabled = false;

                    }
                    else
                    {
                        lblMsg.Text = "Not Inserted";
                    }
                }
            }
            else if (SPAStatus == 0)
            {
                #region SPA Design

                string FilePathSave = "";
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "";


                HttpContext.Current.Response.ContentType = "application/msword";

                string strFileName = string.Empty;
                strFileName = "SpecialPriceApprovalDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

                StringBuilder strHTMLContent = new StringBuilder();

                strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["kodac1Logo"] + "'>".ToString());
                //strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                strHTMLContent.Append("<h1 title='Heading' align='Center' style='font-family:Calibri;font-size:16px;background:#C0C0C0'>SPECIAL PRICE APPROVAL FORM </h1>".ToString());
                strHTMLContent.Append("</br>".ToString());

                strHTMLContent.Append("<table width='100%' style='font-family:Calibri;font-size:16px;'>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td align='center'>Special Price Approval No:</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());
                strHTMLContent.Append("</table>".ToString());

                strHTMLContent.Append("<br>".ToString());

                strHTMLContent.Append("<table width='100%' border='2' style='font-family:Calibri;font-size:16px;'>".ToString());// cellpadding='2'

                strHTMLContent.Append("<tr>".ToString());

                strHTMLContent.Append("<td rowspan='3' colspan='2'>".ToString());

                strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["CentillionLogo"] + "'>".ToString());

                // strHTMLContent.Append("<img src='"+ @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\logo.jpg'>".ToString());    
                strHTMLContent.Append(" </td>");
                strHTMLContent.Append("<td colspan='2'>Name of End User</td>".ToString());
                strHTMLContent.Append("<td>" + txtEndusername.Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Name of Reseller</td>".ToString());
                strHTMLContent.Append("<td>" + txtResellerName.Text + "</td>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Name of Distributor</td>".ToString());
                strHTMLContent.Append("<td>" + txtDistributorName.Text + "</td>".ToString());

                strHTMLContent.Append("</tr>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                //strHTMLContent.Append("</table>".ToString());
                //strHTMLContent.Append("<table width='100%' border='1' cellpadding='3'>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Cat No.</td>".ToString());
                strHTMLContent.Append("<td>Model</td>".ToString());

                strHTMLContent.Append("<td rowspan='2'>Distributor Price (INR) as per applicable slab</td>".ToString());
                strHTMLContent.Append("<td rowspan='2'>Reseller Price (INR)</td>".ToString());
                strHTMLContent.Append("<td rowspan='2'>End User Price(INR)</td>".ToString());

                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());

                strHTMLContent.Append("<td >" + ddlproduct.SelectedItem.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + ddlproduct.SelectedItem.Text + "</td>".ToString());

                //strHTMLContent.Append("<td></td>".ToString());//colspan='3'
                //strHTMLContent.Append("<td></td>".ToString());
                //strHTMLContent.Append("<td></td>".ToString());


                strHTMLContent.Append("</tr>".ToString());


                //strHTMLContent.Append("</table>".ToString());

                //strHTMLContent.Append("<table width='100%' border='1' cellpadding='3'>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Unit Product Price without Discount </td>".ToString());
                strHTMLContent.Append("<td>" + txtUPPWOutDcnt_Dstbtrprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtUPPWOutDcnt_Rsprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtUPPWOutDcnt_EUprice.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Quantity </td>".ToString());// colspan='2'
                strHTMLContent.Append("<td>" + txtQuantity.Text + "</ td>".ToString());// colspan='3'
                strHTMLContent.Append("<td>" + txtQuantity.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + txtQuantity.Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());


                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br> Make1:  " + txtCompUPP_Make1.Text + "</br>Model1:  " + txtCompUPP_Model1.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtCUPP_Rsprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Euprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());


                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br> Make2:  " + txtCompUPP_Make2.Text + "</br>Model2:  " + txtCompUPP_Model2.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice2.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtCUPP_Rsprice2.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Euprice2.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Special Unit Product Price Requested </td>".ToString());
                strHTMLContent.Append("<td>" + txtSUPReq_Dstbtrprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtSUPReq_Rsprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtSUPReq_Euprice.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Approved Unit Product Price </td>".ToString());
                strHTMLContent.Append("<td>" + txtAUP_Dstbtrprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtAUP_Rsprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtAUP_Euprice.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>% variation from standard price</td>".ToString());
                strHTMLContent.Append("<td>" + txtVSP_Dstbtrprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtVSP_Rsprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtVSP_Euprice.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Service Attach ? (Y/N)</td>".ToString());
                strHTMLContent.Append("<td colspan='3'>" + ddlServiceAttach.SelectedItem.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Service Attach Approval Form filled and appended? (Y/N)</td>".ToString());
                strHTMLContent.Append("<td colspan='3'>" + ddlSAappended.SelectedItem.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("</table>".ToString());



                #endregion

                strHTMLContent.Append("<br>".ToString());

                //DateTime PoPlacementUntil = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                //string PoPlacementUntilDate = PoPlacementUntil.ToString("dd/MM/yyyy");
                string PoPlacementUntilDate = string.Empty;
                strHTMLContent.Append("<label><font face='Calibri' size='3'> Above prices valid for PO placement until (dd/mm/yyyy) :</font></label>" + PoPlacementUntilDate);
                strHTMLContent.Append("<br>".ToString());
                // strHTMLContent.Append("Orders executed at above prices do not qualify for other additional discounts that are in place.Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.".ToString());
                strHTMLContent.Append("<label><font face='Calibri' size='3'>Orders executed at above prices do not qualify for other additional discounts that are in place.</font></label>".ToString());
                strHTMLContent.Append("<br>".ToString());
                strHTMLContent.Append(" <label><font face='Calibri' size='3'> Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.</font></label>");

                strHTMLContent.Append("<table border='2' width='100%' style='font-family:Calibri;font-size:16px;'>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td></td>".ToString());
                strHTMLContent.Append("<td>(Kodak Alaris India Pvt Ltd)</ td>".ToString());
                strHTMLContent.Append("<td>(Distributor)</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Name</td>".ToString());
                strHTMLContent.Append("<td> </ td>".ToString());
                strHTMLContent.Append("<td>Binu R M</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Signature</td>".ToString());
                strHTMLContent.Append("<td></td>".ToString());
                strHTMLContent.Append("<td>".ToString());
                strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["BinuSign"] + "'>".ToString());
                strHTMLContent.Append("</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Date</td>".ToString());
                strHTMLContent.Append("<td></td>".ToString());
                strHTMLContent.Append("<td></td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("</table>".ToString());

                strHTMLContent.Append("<br>".ToString());

                // strHTMLContent.Append("<p align='Center'> Note : This is dynamically generated word document </p>".ToString());


                //StreamWriter sw = File.CreateText(MapPath("myFile.txt"));
                //sw.WriteLine( txtFile.Text );
                //sw.Close();

                // Convert to string
                string strFileData = strHTMLContent.ToString();
                string strFolderValue = WebConfigurationManager.AppSettings["SPAApprovalFiles"];
                // string strFolderValue = @"\\192.168.50.158\Word\SPAApprovalFiles\";
                // string strFolderValue = @"D:\CSS Projects\Inventory_VSS_04-May-2017\ImagingTOOL\Word\"; \\192.168.50.158\Word   \\192.168.50.158\Word        
                //System.IO.
                // Directory.CreateDirectory(strFolderValue);
                DirectoryInfo Folder = new DirectoryInfo(strFolderValue);

                //objprop.P_SAFilename = strFileName;
                //objprop.P_SAFilepath = strFolderValue.ToString() + strFileName.ToString();
                string SAFilename = strFileName;
                string SAFilePath = strFolderValue.ToString() + strFileName.ToString();
                objprop.P_SPAAttachFileName = SAFilename;
                objprop.P_SPAAttachFilePath = SAFilePath;
                BindProprtice();
                int VariationPercentage = 0;
                if (ChkVariationPercnt.Checked)
                {
                    VariationPercentage = 1;
                }
                else
                {
                    VariationPercentage = 0;
                }

                int SUPPRequestStatus = 0;
                if (ChkSPR.Checked)
                {
                    SUPPRequestStatus = 1;
                }
                else
                {
                    SUPPRequestStatus = 0;
                }
                // int i = 1;
                int i = objBlPO.InsertSpecialPriceApproval(objprop, VariationPercentage, SUPPRequestStatus);
                if (i > 0)
                {
                    if (Folder.Exists)
                    {
                        if (strFileData != string.Empty)
                        {
                            // build the path
                            FilePathSave = Folder.ToString() + strFileName;

                            // if file exist delete and then save again
                            // else save file
                            File.WriteAllText(FilePathSave, strFileData); // is supposed to overwrite the file if it is there but doesn't

                        }
                        else
                        {
                            lblMsg.Text = "(Nothing to save)";
                            return;
                        }

                        // If we can't find the folder
                    }
                    else
                    {
                        lblMsg.Text = "Folder [" + strFolderValue + "not found]";
                        return;
                    }
                    lblMsg.Text = "Inserted succesfully.";
                    objBlPO.MAIL_FOR_SpecialPriceApprovalForDocFile();
                    ClearInputs(Page.Controls);
                    BindSANumber();
                    Binddata();
                    Session["SPAStatus"] = "0";

                    ddlSANumber.Visible = false;
                    ddlServiceAttach.SelectedValue = "2";
                    ddlServiceAttach.Enabled = false;                    
                    ddlSAappended.SelectedValue = "2";
                    ddlSAappended.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            CreateLogFiles Err = new CreateLogFiles();
            Err.ErrorLog(int.Parse(Session["Id"].ToString()), Server.MapPath("log/trace"), ex.Message + "  >>> from btnSubmit_Click() of SpecialPriceApproval.aspx.cs Page");
        }
    }
    public void BindProprtice()
    {
        objprop.P_EnduserName = txtEndusername.Text;
        objprop.P_ResellerName = txtResellerName.Text;
        objprop.P_DistributorName = txtDistributorName.Text;
        objprop.P_Supplierid = Convert.ToInt32(ddlSupplier.SelectedValue);
        objprop.P_MainTypeId = Convert.ToInt32(ddlType.SelectedValue);
        objprop.P_CategoryId = Convert.ToInt32(ddlCatagory.SelectedValue);
        objprop.P_ProductId = Convert.ToInt32(ddlproduct.SelectedValue);

        if (txtUPPWOutDcnt_Dstbtrprice.Text != "")
        {
            objprop.P_UPPWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text);
        }
        else
        {
            objprop.P_UPPWOutDcnt_Dstbtrprice = 0;
        }
        if (txtUPPWOutDcnt_Rsprice.Text != "")
        {
            objprop.P_UPPWOutDcnt_Rsprice = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text);
        }
        else
        {
            objprop.P_UPPWOutDcnt_Rsprice = 0;
        }
        if (txtUPPWOutDcnt_EUprice.Text != "")
        {
            objprop.P_UPPWOutDcnt_EUprice = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text);
        }
        else
        {
            objprop.P_UPPWOutDcnt_EUprice = 0;
        }
        if (txtQuantity.Text != "")
        {
            objprop.P_Quantity = Convert.ToInt32(txtQuantity.Text);
        }
        else
        {
            objprop.P_Quantity = 0;
        }
        if (txtSUPReq_Dstbtrprice.Text != "")
        {
            objprop.P_SUPReq_Dstbtrprice = Convert.ToDecimal(txtSUPReq_Dstbtrprice.Text);
        }
        else
        {
            objprop.P_SUPReq_Dstbtrprice = 0;
        }
        if (txtSUPReq_Rsprice.Text != "")
        {
            objprop.P_SUPReq_Rsprice = Convert.ToDecimal(txtSUPReq_Rsprice.Text);
        }
        else
        {
            objprop.P_SUPReq_Rsprice = 0;
        }
        if (txtSUPReq_Euprice.Text != "")
        {
            objprop.P_SUPReq_Euprice = Convert.ToDecimal(txtSUPReq_Euprice.Text);
        }
        else
        {
            objprop.P_SUPReq_Euprice = 0;
        }
        if (txtAUP_Dstbtrprice.Text != "")
        {
            objprop.P_AUP_Dstbtrprice = Convert.ToDecimal(txtAUP_Dstbtrprice.Text);
        }
        else
        {
            objprop.P_AUP_Dstbtrprice = 0;
        }
        if (txtAUP_Rsprice.Text != "")
        {
            objprop.P_AUP_Rsprice = Convert.ToDecimal(txtAUP_Rsprice.Text);
        }
        else
        {
            objprop.P_AUP_Rsprice = 0;
        }
        if (txtAUP_Euprice.Text != "")
        {
            objprop.P_AUP_Euprice = Convert.ToDecimal(txtAUP_Euprice.Text);
        }
        else
        {
            objprop.P_AUP_Euprice = 0;
        }
        if (txtVSP_Dstbtrprice.Text != "")
        {
            objprop.P_VSP_Dstbtrprice = Convert.ToDecimal(txtVSP_Dstbtrprice.Text);
        }
        else
        {
            objprop.P_VSP_Dstbtrprice = 0;
        }
        if (txtVSP_Rsprice.Text != "")
        {
            objprop.P_VSP_Rsprice = Convert.ToDecimal(txtVSP_Rsprice.Text);
        }
        else
        {
            objprop.P_VSP_Rsprice = 0;
        }
        if (txtVSP_Euprice.Text != "")
        {
            objprop.P_VSP_Euprice = Convert.ToDecimal(txtVSP_Euprice.Text);
        }
        else
        {
            objprop.P_VSP_Euprice = 0;
        }
        objprop.P_ServiceAttach = Convert.ToInt32(ddlServiceAttach.SelectedValue);
        if (ddlSANumber.SelectedValue != "0")
        {
            objprop.P_SANumber = ddlSANumber.SelectedItem.Text;
        }
        else
        {
            objprop.P_SANumber = "";
        }
        objprop.P_SAAppend = Convert.ToInt32(ddlSAappended.SelectedValue);

        //DateTime? ValidPOplacement;
        //if (TxtValidforPO.Text.Trim() == string.Empty)
        //{
        //    ValidPOplacement = null;
        //}
        //else
        //{
        //    ValidPOplacement = Convert.ToDateTime(TxtValidforPO.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
        //}

        //objprop.P_ValidPOplacement = ValidPOplacement;

        objprop.P_CUPMake1 = txtCompUPP_Make1.Text;
        objprop.P_CUPModel1 = txtCompUPP_Model1.Text;
        if (txtCUPP_Dstbtrprice1.Text != "")
        {
            objprop.P_CUPMake1_Dstbtrprice = Convert.ToDecimal(txtCUPP_Dstbtrprice1.Text);
        }
        else
        {
            objprop.P_CUPMake1_Dstbtrprice = 0;
        }
        if (txtCUPP_Euprice1.Text != "")
        {
            objprop.P_CUPMake1_Euprice = Convert.ToDecimal(txtCUPP_Euprice1.Text);
        }
        else
        {
            objprop.P_CUPMake1_Euprice = 0;
        }
        if (txtCUPP_Rsprice1.Text != "")
        {
            objprop.P_CUPMake1_Rsbtrprice = Convert.ToDecimal(txtCUPP_Rsprice1.Text);
        }
        else
        {
            objprop.P_CUPMake1_Rsbtrprice = 0;
        }
        objprop.P_CUPMake2 = txtCompUPP_Make2.Text;
        objprop.P_CUPModel2 = txtCompUPP_Model2.Text;
        if (txtCUPP_Dstbtrprice2.Text != "")
        {
            objprop.P_CUPMake2_Dstbtrprice = Convert.ToDecimal(txtCUPP_Dstbtrprice2.Text);
        }
        else
        {
            objprop.P_CUPMake2_Dstbtrprice = 0;
        }
        if (txtCUPP_Euprice2.Text != "")
        {
            objprop.P_CUPMake2_Euprice = Convert.ToDecimal(txtCUPP_Euprice2.Text);
        }
        else
        {
            objprop.P_CUPMake2_Euprice = 0;
        }
        if (txtCUPP_Rsprice2.Text != "")
        {
            objprop.P_CUPMake2_Rsbtrprice = Convert.ToDecimal(txtCUPP_Rsprice2.Text);
        }
        else
        {
            objprop.P_CUPMake2_Rsbtrprice = 0;
        }
    }

    public void PrePopulateSaDetails()
    {
        try
        {
            if (Session["SANo"] != "0")
            {
                DataTable DtSA = ClsPurchaseOrder.GetSADetailsForSPA(Convert.ToString(Session["SANo"]));
                if (DtSA.Rows.Count > 0)
                {
                    txtEndusername.Text = DtSA.Rows[0]["Enduser_Name"].ToString();
                    txtResellerName.Text = DtSA.Rows[0]["Reseller_Name"].ToString();
                    txtDistributorName.Text = DtSA.Rows[0]["Distributor_Name"].ToString();
                    ddlSupplier.SelectedValue = DtSA.Rows[0]["SupplierId"].ToString();
                    ddlType.SelectedValue = DtSA.Rows[0]["TypeId"].ToString();
                    BindSubCategory();
                    ddlCatagory.SelectedValue = DtSA.Rows[0]["CategoryId"].ToString();
                    BindProducts();
                    ddlproduct.SelectedValue = DtSA.Rows[0]["ProductId"].ToString();
                   
                }
            }
            Session["SANo"] = "0";
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();
            else if (ctrl is CheckBox)
                ((CheckBox)ctrl).Checked = false;

            ClearInputs(ctrl.Controls);
        }
    }

    protected void btnClear_Click(object Sender, EventArgs e)
    {
        try
        {
            ClearInputs(Page.Controls);
        }
        catch (Exception ex)
        {

            throw;
        }

    }

    protected void ddlServiceAttach_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (Session["SPAStatus"] == "0")
            {

                ddlSANumber.Visible = false;

            }
            else
            {
                ddlSANumber.Visible = true;

            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void ChkVariationPercnt_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            if (ChkSPR.Checked == false)
            {
                if (ChkVariationPercnt.Checked)
                {

                    if (txtUPPWOutDcnt_Dstbtrprice.Text != "" && txtAUP_Dstbtrprice.Text != "")
                    {
                        if (Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text) < Convert.ToDecimal(txtAUP_Dstbtrprice.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of Distributor Price.');</script>", false);
                            txtAUP_Dstbtrprice.Focus();

                            ChkVariationPercnt.Checked = false;
                            txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = "";
                            return;
                        }
                        else
                        {
                            decimal DifferenceDstbtrAmnt = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text) - Convert.ToDecimal(txtAUP_Dstbtrprice.Text);
                            decimal UPPWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text);
                            decimal Dstbtrpercent = (DifferenceDstbtrAmnt / UPPWOutDcnt_Dstbtrprice) * 100;
                            txtVSP_Dstbtrprice.Text = Dstbtrpercent.ToString("0.00");
                        }
                    }
                    if (txtUPPWOutDcnt_Rsprice.Text != "" && txtAUP_Rsprice.Text != "")
                    {
                        if (Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text) < Convert.ToDecimal(txtAUP_Rsprice.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of Reseller Price.');</script>", false);
                            txtAUP_Rsprice.Focus();
                            ChkVariationPercnt.Checked = false;
                            txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = "";
                            return;
                        }
                        else
                        {
                            decimal DifferenceRsAmnt = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text) - Convert.ToDecimal(txtAUP_Rsprice.Text);
                            decimal UPPWOutDcnt_Rsprice = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text);
                            decimal Rspercent = (DifferenceRsAmnt / UPPWOutDcnt_Rsprice) * 100;
                            txtVSP_Rsprice.Text = Rspercent.ToString("0.00");
                        }
                    }
                    if (txtUPPWOutDcnt_EUprice.Text != "" && txtAUP_Euprice.Text != "")
                    {
                        if (Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text) < Convert.ToDecimal(txtAUP_Euprice.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Approved Unit Product Price is less than the Unit Product Price without Discount of End User Price.');</script>", false);
                            txtAUP_Euprice.Focus();
                            ChkVariationPercnt.Checked = false;
                            txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = "";
                            return;
                        }
                        else
                        {
                            decimal DifferenceEuAmnt = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text) - Convert.ToDecimal(txtAUP_Euprice.Text);
                            decimal UPPWOutDcnt_Euprice = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text);
                            decimal Eupercent = (DifferenceEuAmnt / UPPWOutDcnt_Euprice) * 100;
                            txtVSP_Euprice.Text = Eupercent.ToString("0.00");
                        }
                    }
                }
                else
                {
                    txtVSP_Dstbtrprice.Enabled = true; txtVSP_Rsprice.Enabled = true; txtVSP_Euprice.Enabled = true;
                    txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = "";
                }
            }
            else
            {
                if (ChkVariationPercnt.Checked)
                {
                    if (txtUPPWOutDcnt_Dstbtrprice.Text != "" && txtAUP_Dstbtrprice.Text != "")
                    {
                        if (ChkSPR.Checked==true && Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text) < Convert.ToDecimal(txtAUP_Dstbtrprice.Text))
                        {
                            txtVSP_Dstbtrprice.Enabled = true;txtVSP_Dstbtrprice.Text = "";ChkVariationPercnt.Checked = true;
                        }
                        else
                        {
                            decimal DifferenceDstbtrAmnt = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text) - Convert.ToDecimal(txtAUP_Dstbtrprice.Text);
                            decimal UPPWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text);
                            decimal Dstbtrpercent = (DifferenceDstbtrAmnt / UPPWOutDcnt_Dstbtrprice) * 100;
                            txtVSP_Dstbtrprice.Text = Dstbtrpercent.ToString("0.00");
                            txtVSP_Dstbtrprice.Enabled = false;
                        }
                    }
                    if (txtUPPWOutDcnt_Rsprice.Text != "" && txtAUP_Rsprice.Text != "")
                    {
                        if (ChkSPR.Checked == true && Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text) < Convert.ToDecimal(txtAUP_Rsprice.Text))
                        {
                            txtVSP_Rsprice.Enabled = true; txtVSP_Rsprice.Text = ""; ChkVariationPercnt.Checked = true;
                        }
                        else
                        {
                            decimal DifferenceRsAmnt = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text) - Convert.ToDecimal(txtAUP_Rsprice.Text);
                            decimal UPPWOutDcnt_Rsprice = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text);
                            decimal Rspercent = (DifferenceRsAmnt / UPPWOutDcnt_Rsprice) * 100;
                            txtVSP_Rsprice.Text = Rspercent.ToString("0.00");
                            txtVSP_Rsprice.Enabled = false;
                        }
                    }
                    if (txtUPPWOutDcnt_EUprice.Text != "" && txtAUP_Euprice.Text != "")
                    {
                        if (ChkSPR.Checked == true && Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text) < Convert.ToDecimal(txtAUP_Euprice.Text))
                        {
                            txtVSP_Euprice.Enabled = true; txtVSP_Euprice.Text = ""; ChkVariationPercnt.Checked = true;
                        }
                        else
                        {
                            decimal DifferenceEuAmnt = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text) - Convert.ToDecimal(txtAUP_Euprice.Text);
                            decimal UPPWOutDcnt_Euprice = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text);
                            decimal Eupercent = (DifferenceEuAmnt / UPPWOutDcnt_Euprice) * 100;
                            txtVSP_Euprice.Text = Eupercent.ToString("0.00");
                            txtVSP_Euprice.Enabled = false;
                        }
                    }
                }
                else
                {
                    txtVSP_Dstbtrprice.Enabled = true; txtVSP_Rsprice.Enabled = true; txtVSP_Euprice.Enabled = true;
                    txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = "";                    
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void Binddata()
    {
        DataTable dt = ClsPurchaseOrder.BindServiceAttachmentForSPA();
        //if (dt.Rows.Count > 0)
        //{
           // DIVGASA.Visible = true;
            GvSA.DataSource = dt;
            GvSA.DataBind();
        //}
        //else
        //{
        //   // DIVGASA.Visible = false;
        //}

    }
    protected void GvSA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edited")
            {
                Button Btn = (Button)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)Btn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview
                string ID = myGrid.DataKeys[myRow.RowIndex].Values[0].ToString(); // value of the datakey

                ClearInputs(Page.Controls);
                string SANo = Convert.ToString(e.CommandArgument.ToString());
                Session["SANo"] = SANo;
                GetMasterList("SU", ddlSupplier);
                BindMainCategory();
                BindSANumber();
                PrePopulateSaDetails();
                ChkSPR.Checked = true;
                ddlSANumber.Visible = true;
                ddlSANumber.SelectedValue = ID;
                ddlServiceAttach.SelectedValue ="1";
                ddlServiceAttach.Enabled = true;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "VisibleddlSANo();", true);
                ddlSAappended.SelectedValue = "1";
                ddlSAappended.Enabled = true;
            }
        }
        catch (Exception ex)
        {        
            throw;
        }
    }

    protected void ChkSPR_CheckedChanged(object sender, EventArgs e)
    {
        txtVSP_Dstbtrprice.Enabled = true; txtVSP_Rsprice.Enabled = true; txtVSP_Euprice.Enabled = true;
        txtVSP_Dstbtrprice.Text = ""; txtVSP_Rsprice.Text = ""; txtVSP_Euprice.Text = ""; ChkVariationPercnt.Checked = false; 
    }
}