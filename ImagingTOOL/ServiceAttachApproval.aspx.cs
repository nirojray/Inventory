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

public partial class ServiceAttachApproval_ : System.Web.UI.Page
{
    BusinessLogicLayer.ServiceAttachApproval objprop = new BusinessLogicLayer.ServiceAttachApproval();
    ClsPurchaseOrder objpo = new ClsPurchaseOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetMasterList("SU", ddlSupplier);
            BindMainCategory();
            txtDistributorName.Text= "Centillion Solution And Services (P) Ltd";
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
    protected void btnSubmit_click(object sender, EventArgs e)
    {
        try
        {
            string FilePathSave = "";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";


            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = string.Empty;
            strFileName = "ServiceAttachApprovalDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();

            //strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

            strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["kodac1Logo"] + "'>".ToString());

            strHTMLContent.Append(" <h1 title='Heading' align='Center' style='font-family:Calibri;font-size:16px;background:#C0C0C0'>SERVICE ATTACH APPROVAL FORM </h1>".ToString());
            strHTMLContent.Append("<br>".ToString());

            strHTMLContent.Append("<table width='100%' border='2' style='font-family:Calibri;font-size:16px;'>".ToString());

           
            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td rowspan='3' colspan='2'>".ToString());
            strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["CentillionLogo"] + "'>".ToString());
            //strHTMLContent.Append("<img src='"+ @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\logo.jpg'>".ToString());
            strHTMLContent.Append(" </td>");
            strHTMLContent.Append("<td colspan='2'>Name of  End User </td>".ToString());
            strHTMLContent.Append("<td>" + txtEndusername.Text + "</td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            //strHTMLContent.Append("<tr>".ToString());
            //strHTMLContent.Append("<td>Name of  Distributor </td>".ToString());
            //strHTMLContent.Append("<td colspan='4'>" + txtDistributorName.Text + "</td>".ToString());
            //strHTMLContent.Append("</tr>".ToString());


           // txtResellerName

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Name of  Reseller </td>".ToString());
            strHTMLContent.Append("<td>" + txtResellerName.Text + "</td>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Name of Distributor</td>".ToString());
            strHTMLContent.Append("<td>" + txtDistributorName.Text + "</td>".ToString());

            strHTMLContent.Append("</tr>".ToString());
            strHTMLContent.Append("</tr>".ToString());



            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td>Cat No</td>".ToString());
            strHTMLContent.Append("<td>Model </td>".ToString());
            strHTMLContent.Append("<td> Total Quantity </td>".ToString());
            strHTMLContent.Append("<td> Total Period including Standard One year </td>".ToString());
            strHTMLContent.Append("<td> Name of nearest Competitor offering Service Attach </td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td>" + ddlproduct.SelectedItem.Text + "</td>".ToString());
            strHTMLContent.Append("<td>" + ddlproduct.SelectedItem.Text + "</td>".ToString());
            strHTMLContent.Append("<td> " + txtQuantity.Text + " </td>".ToString());
            strHTMLContent.Append("<td>" + txtperiodStdYear.Text + "</td>".ToString());
            strHTMLContent.Append("<td>" + txtCompetitorname.Text + "</td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'></td>".ToString());
            strHTMLContent.Append("<td>Distributor Price(INR) </ td>".ToString());
            strHTMLContent.Append("<td> Reseller  Price(INR)</ td>".ToString());
            strHTMLContent.Append("<td> End User Price(INR) </ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Unit Product Sales Price Without Discount</td>".ToString());
            strHTMLContent.Append("<td>" + txtUPSWOutdcntDistributorprice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td> " + txtUPSWOutdcntResellerPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td>" + txtUPSWOutdcntEndUserPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Unit Product Sales Price With Discount</td>".ToString());
            strHTMLContent.Append("<td>" + txtUPSWithdcntDistributorprice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td> " + txtUPSWithdcntResellerPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td>" + txtUPSWithdcntEndUserPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Unit Service Attach Without Discount</td>".ToString());
            strHTMLContent.Append("<td>" + txtUSAWOutdcntDistributorprice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td> " + txtUSAWOutdcntResellerPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td>" + txtUSAWOutdcntEndUserPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Service Attach With Discount</td>".ToString());
            strHTMLContent.Append("<td>" + txtUSAWithdcntDistributorprice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td> " + txtUSAWithdcntResellerPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("<td>" + txtUSAWithdcntEndUserPrice.Text + "</ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("</table>".ToString());
            strHTMLContent.Append("<br>".ToString());

            //DateTime WDate = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
            //string WarrentyDate = WDate.ToString("dd/MM/yyyy");
            string WarrentyDate = string.Empty;
            strHTMLContent.Append("<label><font face='Calibri' size='3'>Above prices valid for Warranty until (dd/mm/yyyy) :</font></label>" + WarrentyDate);

            strHTMLContent.Append("<br>".ToString());
            strHTMLContent.Append("<br>".ToString());
            strHTMLContent.Append("<table border='2' width='100%' style='font-family:Calibri;font-size:16px;'>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td>Name</td>".ToString());
            strHTMLContent.Append("<td>(Sales Manager)</ td>".ToString());
            strHTMLContent.Append("<td>(Service Manager)</ td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td>Signature</td>".ToString());
            strHTMLContent.Append("<td></td>".ToString());
            strHTMLContent.Append("<td></td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td>Date</td>".ToString());
            strHTMLContent.Append("<td></td>".ToString());
            strHTMLContent.Append("<td></td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            strHTMLContent.Append("</table>".ToString());

            strHTMLContent.Append("<br><br>".ToString());
            //strHTMLContent.Append("<p align='Center'> Note : This is dynamically generated word document </p>".ToString());


            //StreamWriter sw = File.CreateText(MapPath("myFile.txt"));
            //sw.WriteLine( txtFile.Text );
            //sw.Close();

            // Convert to string
            string strFileData = strHTMLContent.ToString();
            string strFolderValue = WebConfigurationManager.AppSettings["SAApprovalFiles"]; 
            // string strFolderValue = @"\\192.168.50.158\Word\SAApprovalFiles\";
            // string strFolderValue = @"D:\CSS Projects\Inventory_VSS_04-May-2017\ImagingTOOL\Word\"; \\192.168.50.158\Word   \\192.168.50.158\Word        
            //System.IO.
            // Directory.CreateDirectory(strFolderValue);
            DirectoryInfo Folder = new DirectoryInfo(strFolderValue);

            //objprop.P_SAFilename = strFileName;
            //objprop.P_SAFilepath = strFolderValue.ToString() + strFileName.ToString();
            string SAFilename = strFileName;
            string SAFilePath = strFolderValue.ToString() + strFileName.ToString();

            BindProperties();
            int i = objpo.InsertServiceAttachApproval(objprop, SAFilename, SAFilePath);
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
                        Response.Write("(Nothing to save)");
                    }

                    // If we can't find the folder
                }
                else
                {
                    Response.Write("Folder [" + strFolderValue + "not found]");
                }
                lblMsg.Text = "Inserted succesfully.";
                objpo.MAIL_FOR_ServiceAttchApprovalForDocFile();
                Clear();
            }

        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void BindProperties()
    {
        try
        {
            objprop.P_EnduserName = txtEndusername.Text;
            objprop.P_ResellerName = txtResellerName.Text;
            objprop.P_DistributorName = txtDistributorName.Text;
            objprop.P_Supplierid = Convert.ToInt32(ddlSupplier.SelectedValue);
            objprop.P_MainTypeId = Convert.ToInt32(ddlType.SelectedValue);
            objprop.P_CategoryId = Convert.ToInt32(ddlCatagory.SelectedValue);
            objprop.P_ProductId = Convert.ToInt32(ddlproduct.SelectedValue);
            objprop.P_Quantity = Convert.ToInt32(txtQuantity.Text);
            objprop.P_TotalPeriod = txtperiodStdYear.Text;
            objprop.P_CompetitorName = txtCompetitorname.Text;
            objprop.P_UPSWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPSWOutdcntDistributorprice.Text);
            objprop.P_UPSWOutDcnt_Rsprice = Convert.ToDecimal(txtUPSWOutdcntResellerPrice.Text);
            objprop.P_UPSWOutDcnt_Euprice = Convert.ToDecimal(txtUPSWOutdcntEndUserPrice.Text);
            objprop.P_UPSWDcnt_DstbtrPrice = Convert.ToDecimal(txtUPSWithdcntDistributorprice.Text);
            objprop.P_UPSWDcnt_Rsprice = Convert.ToDecimal(txtUPSWithdcntResellerPrice.Text);
            objprop.P_UPSWDcnt_Euprice = Convert.ToDecimal(txtUPSWithdcntEndUserPrice.Text);
            objprop.P_USAWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUSAWOutdcntDistributorprice.Text);
            objprop.P_USAWOutDcnt_Rsprice = Convert.ToDecimal(txtUSAWOutdcntResellerPrice.Text);
            objprop.P_USAWOutDcnt_Euprice = Convert.ToDecimal(txtUSAWOutdcntEndUserPrice.Text);
            objprop.P_USAWDcnt_DstbtrPrice = Convert.ToDecimal(txtUSAWithdcntDistributorprice.Text);
            objprop.P_USAWDcnt_Rsprice = Convert.ToDecimal(txtUSAWithdcntResellerPrice.Text);
            objprop.P_USAWDcnt_Euprice = Convert.ToDecimal(txtUSAWithdcntEndUserPrice.Text);

           // DateTime? Warrenty;
           // if (TxtWarrantyDate.Text.Trim() == string.Empty)
           // {
           //     Warrenty = null;
           // }
           // else
           // {
           //     Warrenty = Convert.ToDateTime(TxtWarrantyDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

           // }

           // //DateTime Warrenty1 = Convert.ToDateTime(TxtWarrantyDate.Text);
           //// DateTime Warrenty = Convert.ToDateTime(TxtWarrantyDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);
           // objprop.P_Warrenty = Warrenty;
            objprop.P_SPA = Convert.ToInt32(Session["SPA"].ToString());
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public void Clear()
    {
        txtEndusername.Text = "";
        txtResellerName.Text = "";
        txtDistributorName.Text = "";
        ddlSupplier.SelectedIndex = 0;
        ddlType.SelectedIndex = 0;
        ddlCatagory.SelectedIndex = 0;
        ddlproduct.SelectedIndex = 0;
        txtQuantity.Text = "";
        txtperiodStdYear.Text = "";
        txtCompetitorname.Text = "";
        txtUPSWOutdcntDistributorprice.Text = "";
        txtUPSWOutdcntResellerPrice.Text = "";
        txtUPSWOutdcntEndUserPrice.Text = "";
        txtUPSWithdcntDistributorprice.Text = "";
        txtUPSWithdcntResellerPrice.Text = "";
        txtUPSWithdcntEndUserPrice.Text = "";
        txtUSAWOutdcntDistributorprice.Text = "";
        txtUSAWOutdcntResellerPrice.Text = "";
        txtUPSWithdcntEndUserPrice.Text = "";
        txtUSAWOutdcntDistributorprice.Text = "";
        txtUSAWOutdcntResellerPrice.Text = "";
        txtUSAWOutdcntEndUserPrice.Text = "";
        txtUSAWithdcntDistributorprice.Text = "";
        txtUSAWithdcntResellerPrice.Text = "";
        txtUSAWithdcntEndUserPrice.Text = "";
        //TxtWarrantyDate.Text = "";
    }
    public void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            else if (ctrl is DropDownList)
                ((DropDownList)ctrl).ClearSelection();

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
}