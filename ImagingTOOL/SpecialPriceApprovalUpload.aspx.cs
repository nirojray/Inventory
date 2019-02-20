using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using System.Data;
using System.IO;
using System.Text;
using System.Web.Configuration;

public partial class SpecialPriceApprovalUpload : System.Web.UI.Page
{
    SpecialPriceApproval objprop = new SpecialPriceApproval();
    ClsPurchaseOrder objBlPo = new ClsPurchaseOrder();
    //string strFileName = string.Empty; DirectoryInfo Folder; string FilePathSave = ""; string strFileData = string.Empty;
    string strFolderValue= string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DivSPAInfo.Visible = false;DivSPAData.Visible = true;
            Binddata();
        }
        //else
        //{
        //    DivSPAInfo.Visible = false; DivSPAData.Visible = true;
        //}
    }

    public void Binddata()
    {
        DataTable dt = ClsPurchaseOrder.BindSpecialPriceforApprovaldata();
        GvSPA.DataSource = dt;
        GvSPA.DataBind();
    }
    protected void GvSPA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkSPAAFile = (LinkButton)e.Row.FindControl("lnkSPAAFile");
            string SPAAttachFilePath = GvSPA.DataKeys[e.Row.RowIndex].Values["SPAAttachFilePath"].ToString();
            if (SPAAttachFilePath != "")
            {
                lnkSPAAFile.Text = SPAAttachFilePath;

                char[] delimiterChars = { '\\', '.' };
                string[] s2 = SPAAttachFilePath.Split(delimiterChars);
                if (s2.Length >= 2)
                {
                    string SAAFileApproval = s2[s2.Length - 2].ToString();
                    lnkSPAAFile.Text = SAAFileApproval;
                }
            }
        }
    }

    protected void GvSPA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edited")
        {
            DivSPAInfo.Visible = true; ; DivSPAData.Visible = false;
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            DataTable dt = ClsPurchaseOrder.GetSpecialPriceforApprovaldata(Id);

            lblEndusername.Text= dt.Rows[0]["Enduser_Name"].ToString();
            lblResellerName.Text = dt.Rows[0]["Reseller_Name"].ToString();
            lblDistributorName.Text = dt.Rows[0]["Distributer_Name"].ToString();
            lblSupplier.Text = dt.Rows[0]["Supplier_Name"].ToString();
            lblType.Text = dt.Rows[0]["M_CategoryName"].ToString();
            lblCategory.Text = dt.Rows[0]["Category_Name"].ToString();
            lblProduct.Text = dt.Rows[0]["Product_Name"].ToString();
            lblQuantity.Text= dt.Rows[0]["Quantity"].ToString();
            txtUPPWOutDcnt_Dstbtrprice.Text = dt.Rows[0]["UPPWOutDcnt_Dstbtrprice"].ToString();
            txtUPPWOutDcnt_Rsprice.Text = dt.Rows[0]["UPPWOutDcnt_Rsprice"].ToString();
            txtUPPWOutDcnt_EUprice.Text = dt.Rows[0]["UPPWOutDcnt_EUprice"].ToString();           
            lblCompUPP_Make1.Text=" "+ dt.Rows[0]["CompUPP_Make1"].ToString();
            lblCompUPP_Model1.Text = " " +dt.Rows[0]["CompUPP_Model1"].ToString();
            txtCUPP_Dstbtrprice1.Text = dt.Rows[0]["CUPP_Dstbtrprice1"].ToString();
            txtCUPP_Rsprice1.Text = dt.Rows[0]["CUPP_Rsprice1"].ToString();
            txtCUPP_Euprice1.Text = dt.Rows[0]["CUPP_Euprice1"].ToString();
            lblCompUPP_Make2.Text = dt.Rows[0]["CompUPP_Make2"].ToString();
            lblCompUPP_Model2.Text = dt.Rows[0]["CompUPP_Model2"].ToString();
            txtCUPP_Dstbtrprice2.Text = dt.Rows[0]["CUPP_Dstbtrprice2"].ToString();
            txtCUPP_Rsprice2.Text = dt.Rows[0]["CUPP_Rsprice2"].ToString();
            txtCUPP_Euprice2.Text = dt.Rows[0]["CUPP_Euprice2"].ToString();
            txtSUPReq_Dstbtrprice.Text = dt.Rows[0]["SUPReq_Dstbtrprice"].ToString();
            txtSUPReq_Rsprice.Text = dt.Rows[0]["SUPReq_Rsprice"].ToString();
            txtSUPReq_Euprice.Text = dt.Rows[0]["SUPReq_Euprice"].ToString();
            txtAUP_Dstbtrprice.Text = dt.Rows[0]["AUP_Dstbtrprice"].ToString();
            txtAUP_Rsprice.Text = dt.Rows[0]["AUP_Rsprice"].ToString();
            txtAUP_Euprice.Text = dt.Rows[0]["AUP_Euprice"].ToString();
            txtVSP_Dstbtrprice.Text = dt.Rows[0]["VSP_Dstbtrprice"].ToString();
            txtVSP_Rsprice.Text = dt.Rows[0]["VSP_Rsprice"].ToString();
            txtVSP_Euprice.Text = dt.Rows[0]["VSP_Euprice"].ToString();
            lblServiceAttach.Text = dt.Rows[0]["ServiceAttach"].ToString();
            lblSANumber.Text = dt.Rows[0]["SANumber"].ToString();
            lblSAAppended.Text = dt.Rows[0]["SAAppend"].ToString();
            ViewState["lblSPAID"] = Id;
            //int index = Convert.ToInt32(e.CommandArgument.ToString());
            //HiddenField lblSPAID = (HiddenField)GvSPA.Rows[index].FindControl("HDFSPAId");
            //Label lblEndUserName1 = (Label)GvSPA.Rows[index].FindControl("lblEndUserName");
            //Label lblResellerName1 = (Label)GvSPA.Rows[index].FindControl("lblResellerName");
            //Label lblDistributeName1 = (Label)GvSPA.Rows[index].FindControl("lblDistributeName");
            //Label lblModel1 = (Label)GvSPA.Rows[index].FindControl("lblModel");
            //Label lblCatNo1 = (Label)GvSPA.Rows[index].FindControl("lblCatNo");

            //lblEndusername.Text = lblEndUserName1.Text;
            //lblResellerName.Text = lblResellerName1.Text;
            //lblDistributorName.Text = lblDistributeName1.Text;
            //lblProduct.Text = lblModel1.Text + "_" + lblCatNo1.Text;
            // ViewState["lblSPAID"] = lblSPAID.Value;


        }
    }

    protected void lnkSAAFile_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string filePath = GvSPA.DataKeys[gvrow.RowIndex].Values[2].ToString();
            if (filePath != "")
            {
                char[] delimiterChars = { '\\' };
                string[] s2 = filePath.Split(delimiterChars);
                if (s2.Length >= 2)
                {
                    string SAAFileApproval = s2[s2.Length - 1].ToString();
                    Response.ContentType = "application/ms-word";
                    Response.AddHeader("Content-Disposition", "attachment;filename=" + SAAFileApproval);
                    Response.TransmitFile(filePath);
                    Response.End();
                }
            }



        }
        catch (Exception ex)
        {
            throw;
        }

    }

    protected void btnSubmit_Click(object Sender, EventArgs e)
    {
        try
        {
            if (lblSANumber.Text.Trim() != "")
            {
                DataTable DtSA = ClsPurchaseOrder.GetSADetailsForSPA(lblSANumber.Text.Trim());
                if (DtSA.Rows.Count > 0)
                {
                    //string FilePathSave = "";
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Charset = "";


                    HttpContext.Current.Response.ContentType = "application/msword";

                    // string strFileName = string.Empty;
                   string strFileName = "SpecialPriceApprovalSignedDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

                    #region SAA Design

                    StringBuilder strHTMLContent1 = new StringBuilder();

                    strHTMLContent1.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                    // strHTMLContent.Append("< img src = '~/images/kodac.png' visible = 'true' runat = 'server' style = 'width: 75px; height: 41px' />".ToString());
                    //strHTMLContent.Append("<br>".ToString());

                    strHTMLContent1.Append(" <h1 title='Heading' align='Center' style='font-family:verdana;font-size:100%;background:#C0C0C0'>SERVICE ATTACH APPROVAL FORM </h1>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<table width='100%' border='1' cellpadding='2'>".ToString());

                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td style='width: 100px;background:#99CC00'><b>SERVICE ATTACH APPROVAL FORM</b></td>".ToString());            
                    //strHTMLContent.Append("</tr><br/>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Name of  End User </td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Enduser_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("<td>Name of Reseller</td>".ToString());
                    strHTMLContent1.Append("<td>" + DtSA.Rows[0]["Reseller_Name"].ToString() + "</td>".ToString());
                    strHTMLContent1.Append("</tr>".ToString());

                    strHTMLContent1.Append("<tr>".ToString());
                    strHTMLContent1.Append("<td colspan='2'>Name of  Distributor </td>".ToString());
                    strHTMLContent1.Append("<td colspan='3'>" + DtSA.Rows[0]["Distributor_Name"].ToString() + "</td>".ToString());
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
                    strHTMLContent1.Append(" Above prices valid for Warranty until (dd/mm/yyyy) :" + WarrentyDate);
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<br>".ToString());
                    strHTMLContent1.Append("<table border='1' width='100%'>".ToString());

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
                    strHTMLContent1.Append("<p align='Center'> Note : This is dynamically generated word document </p>".ToString());
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

                    strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                    // strHTMLContent.Append("< img src = '~/images/kodac.png' visible = 'true' runat = 'server' style = 'width: 75px; height: 41px' />".ToString());
                    //strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<h1 title='Heading' align='Center' style='font-family:verdana;font-size:100%;background:#C0C0C0'>SPECIAL PRICE APPROVAL FORM </h1>".ToString());
                    strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<table width='100%'>".ToString());
                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td align='center'>Special Price Approval No:" + TxtSPA.Text + "</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());
                    strHTMLContent.Append("</table>".ToString());
                    strHTMLContent.Append("<br>".ToString());
                    strHTMLContent.Append("<table width='100%' border='1' cellpadding='2'>".ToString());

                    //strHTMLContent.Append("<tr>".ToString());
                    //strHTMLContent.Append("<td style='width: 100px;background:#99CC00'><b>SERVICE ATTACH APPROVAL FORM</b></td>".ToString());            
                    //strHTMLContent.Append("</tr><br/>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Name of  End User </td>".ToString());
                    strHTMLContent.Append("<td>" + lblEndusername.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>Name of Reseller</td>".ToString());
                    strHTMLContent.Append("<td>" + lblResellerName.Text + "</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Name of  Distributor </td>".ToString());
                    strHTMLContent.Append("<td colspan='4'>" + lblDistributorName.Text + "</td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Cat No</td>".ToString());
                    strHTMLContent.Append("<td>Model </td>".ToString());
                    strHTMLContent.Append("<td>Distributor Price (INR) as per applicable slab* </td>".ToString());
                    strHTMLContent.Append("<td>Reseller Price (INR) </td>".ToString());
                    strHTMLContent.Append("<td> End User Price (INR) </td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
                    strHTMLContent.Append("<td colspan='3'>  </td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());


                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Unit Product Price without Discount </td>".ToString());
                    strHTMLContent.Append("<td>" + txtUPPWOutDcnt_Dstbtrprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtUPPWOutDcnt_Rsprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtUPPWOutDcnt_EUprice.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Quantity </td>".ToString());
                    strHTMLContent.Append("<td colspan='3'>" + lblQuantity.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make1:" + lblCompUPP_Make1.Text + "</br>Model1:" + lblCompUPP_Model1.Text + "</td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td> " + txtCUPP_Rsprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("<td>" + txtCUPP_Euprice1.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make2:" + lblCompUPP_Make2.Text + "</br>Model2:" + lblCompUPP_Model2.Text + "</td>".ToString());
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
                    strHTMLContent.Append("<td colspan='3'>" + lblServiceAttach.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td colspan='2'>Service Attach Approval Form filled and appended? (Y/N)</td>".ToString());
                    strHTMLContent.Append("<td colspan='3'>" + lblSAAppended.Text + "</ td>".ToString());
                    strHTMLContent.Append("</tr>".ToString());

                    strHTMLContent.Append("</table>".ToString());

                    #endregion

                    strHTMLContent.Append("<br>".ToString());
                    DateTime PoPlacementUntil = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                    string PoPlacementUntilDate = PoPlacementUntil.ToString("dd/MM/yyyy");
                    strHTMLContent.Append(" Above prices valid for PO placement until (dd/mm/yyyy) :" + PoPlacementUntilDate);
                    strHTMLContent.Append("<br>".ToString()); strHTMLContent.Append("<br>".ToString());
                    strHTMLContent.Append("Orders executed at above prices don’t qualify for other additional discounts that are in place.Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.".ToString());
                    strHTMLContent.Append("<br>".ToString());
                    strHTMLContent.Append("<br>".ToString());

                    strHTMLContent.Append("<table border='2' width='100%'>".ToString());

                    strHTMLContent.Append("<tr>".ToString());
                    strHTMLContent.Append("<td>Name</td>".ToString());
                    strHTMLContent.Append("<td>(Kodak Alaris India Pvt Ltd)</ td>".ToString());
                    strHTMLContent.Append("<td>(Distributor)</ td>".ToString());
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

                    strHTMLContent.Append("<br>".ToString());



                    //StreamWriter sw = File.CreateText(MapPath("myFile.txt"));
                    //sw.WriteLine( txtFile.Text );
                    //sw.Close();

                    // Convert to string
                   string strFileData = strHTMLContent.ToString() + strHTMLContent1.ToString();
                    // strFolderValue = @"\\192.168.50.158\Word\SPAApprovalSignedFiles\";
                    strFolderValue = WebConfigurationManager.AppSettings["SPAApprovalSignedFiles"];
                    // string strFolderValue = @"D:\CSS Projects\Inventory_VSS_04-May-2017\ImagingTOOL\Word\"; \\192.168.50.158\Word   \\192.168.50.158\Word        
                    //System.IO.
                    // Directory.CreateDirectory(strFolderValue);
                    DirectoryInfo Folder = new DirectoryInfo(strFolderValue);
                    string SAFilename = strFileName;
                    string SAFilePath = strFolderValue.ToString() + strFileName.ToString();
                    objprop.P_SPAAttachSignedFileName = SAFilename;
                    objprop.P_SPAAttcahSignedFilePath = SAFilePath;

                    if (TxtSPA.Text != "")
                    {
                        BindPropertice();
                        int i = objBlPo.UpdateSpecialPriceApprovalwithSignedDocument(objprop, Convert.ToInt32(ViewState["lblSPAID"].ToString()), TxtSPA.Text,0,"");
                        if (i > 0)
                        {
                            // FileUpload1.SaveAs(strFolderValue + filename);

                            if (Folder.Exists)
                            {
                                if (strFileData != string.Empty)
                                {
                                    // build the path
                                   string FilePathSave = Folder.ToString() + strFileName;

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
                           // lblMessage.Text = "";
                           // lblMessage.Text = "Updated Successfully.";                                                             
                            objBlPo.MAIL_FOR_SpecialPriceApprovalSignedDocFile(Convert.ToInt32(ViewState["lblSPAID"].ToString()));
                            DivSPAInfo.Visible = false; DivSPAData.Visible = true;
                           // ClearInputs(Page.Controls);
                        }
                    }
                    else
                    {
                        lblMessage.Text = "";
                        lblMessage.Text = "Please enter special price number.";
                    }
                }
            }
            else
            {
                #region SPA Design


                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Charset = "";


                HttpContext.Current.Response.ContentType = "application/msword";


               string strFileName = "SpecialPriceApprovalSignedDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

                StringBuilder strHTMLContent = new StringBuilder();

                strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());

                // strHTMLContent.Append("< img src = '~/images/kodac.png' visible = 'true' runat = 'server' style = 'width: 75px; height: 41px' />".ToString());
                //strHTMLContent.Append("<br>".ToString());

                strHTMLContent.Append("<h1 title='Heading' align='Center' style='font-family:verdana;font-size:100%;background:#C0C0C0'>SPECIAL PRICE APPROVAL FORM </h1>".ToString());
                strHTMLContent.Append("<br>".ToString());

                strHTMLContent.Append("<table width='100%'>".ToString());
                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td align='center'>Special Price Approval No:" + TxtSPA.Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());
                strHTMLContent.Append("</table>".ToString());
                strHTMLContent.Append("<br>".ToString());
                strHTMLContent.Append("<table width='100%' border='1' cellpadding='2'>".ToString());

                //strHTMLContent.Append("<tr>".ToString());
                //strHTMLContent.Append("<td style='width: 100px;background:#99CC00'><b>SERVICE ATTACH APPROVAL FORM</b></td>".ToString());            
                //strHTMLContent.Append("</tr><br/>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Name of  End User </td>".ToString());
                strHTMLContent.Append("<td>" + lblEndusername.Text + "</td>".ToString());
                strHTMLContent.Append("<td>Name of Reseller</td>".ToString());
                strHTMLContent.Append("<td>" + lblResellerName.Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Name of  Distributor </td>".ToString());
                strHTMLContent.Append("<td colspan='4'>" + lblDistributorName.Text + "</td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Cat No</td>".ToString());
                strHTMLContent.Append("<td>Model </td>".ToString());
                strHTMLContent.Append("<td>Distributor Price (INR) as per applicable slab* </td>".ToString());
                strHTMLContent.Append("<td>Reseller Price (INR) </td>".ToString());
                strHTMLContent.Append("<td> End User Price (INR) </td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
                strHTMLContent.Append("<td colspan='3'>  </td>".ToString());
                strHTMLContent.Append("</tr>".ToString());


                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Unit Product Price without Discount </td>".ToString());
                strHTMLContent.Append("<td>" + txtUPPWOutDcnt_Dstbtrprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtUPPWOutDcnt_Rsprice.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtUPPWOutDcnt_EUprice.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Quantity </td>".ToString());
                strHTMLContent.Append("<td colspan='3'>" + lblQuantity.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make1:" + lblCompUPP_Make1.Text + "</br>Model1:" + lblCompUPP_Model1.Text + "</td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Dstbtrprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("<td> " + txtCUPP_Rsprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("<td>" + txtCUPP_Euprice1.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Competitor Unit Product Price Quoted </br>Make2:" + lblCompUPP_Make2.Text + "</br>Model2:" + lblCompUPP_Model2.Text + "</td>".ToString());
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
                strHTMLContent.Append("<td colspan='3'>" + lblServiceAttach.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td colspan='2'>Service Attach Approval Form filled and appended? (Y/N)</td>".ToString());
                strHTMLContent.Append("<td colspan='3'>" + lblSAAppended.Text + "</ td>".ToString());
                strHTMLContent.Append("</tr>".ToString());

                strHTMLContent.Append("</table>".ToString());

                #endregion

                strHTMLContent.Append("<br>".ToString());
                DateTime PoPlacementUntil = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());
                string PoPlacementUntilDate = PoPlacementUntil.ToString("dd/MM/yyyy");
                strHTMLContent.Append(" Above prices valid for PO placement until (dd/mm/yyyy) :" + PoPlacementUntilDate);
                strHTMLContent.Append("</br>".ToString()); strHTMLContent.Append("</br>".ToString());
                strHTMLContent.Append("Orders executed at above prices do not qualify for other additional discounts that are in place.Valid only if accompanied by End Customer Purchase Order copy and subject to maximum quantity mentioned above.".ToString());
                strHTMLContent.Append("</br>".ToString());

                strHTMLContent.Append("<table border='2' width='100%'>".ToString());

                strHTMLContent.Append("<tr>".ToString());
                strHTMLContent.Append("<td>Name</td>".ToString());
                strHTMLContent.Append("<td>(Kodak Alaris India Pvt Ltd)</ td>".ToString());
                strHTMLContent.Append("<td>(Distributor)</ td>".ToString());
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

                strHTMLContent.Append("<br>".ToString());
                strHTMLContent.Append("<p align='Center'> Note : This is dynamically generated word document </p>".ToString());


                // Convert to string
               string strFileData = strHTMLContent.ToString();
                strFolderValue = WebConfigurationManager.AppSettings["SPAApprovalSignedFiles"];
                // strFolderValue = @"\\192.168.50.158\Word\SPAApprovalSignedFiles\";
                // string strFolderValue = @"D:\CSS Projects\Inventory_VSS_04-May-2017\ImagingTOOL\Word\"; \\192.168.50.158\Word   \\192.168.50.158\Word        
                //System.IO.
                // Directory.CreateDirectory(strFolderValue);
                DirectoryInfo Folder = new DirectoryInfo(strFolderValue);

                //objprop.P_SAFilename = strFileName;
                //objprop.P_SAFilepath = strFolderValue.ToString() + strFileName.ToString();
                string SAFilename = strFileName;
                string SAFilePath = strFolderValue.ToString() + strFileName.ToString();
                objprop.P_SPAAttachSignedFileName = SAFilename;
                objprop.P_SPAAttcahSignedFilePath = SAFilePath;

                if (TxtSPA.Text != "")
                {
                    BindPropertice();
                    int i = objBlPo.UpdateSpecialPriceApprovalwithSignedDocument(objprop, Convert.ToInt32(ViewState["lblSPAID"].ToString()), TxtSPA.Text,0,"");
                    if (i > 0)
                    {
                        // FileUpload1.SaveAs(strFolderValue + filename);

                        if (Folder.Exists)
                        {
                            if (strFileData != string.Empty)
                            {
                                // build the path
                               string FilePathSave = Folder.ToString() + strFileName;

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
                       // lblMessage.Text = "";
                      //  lblMessage.Text = "Updated Successfully.";                                                  
                        objBlPo.MAIL_FOR_SpecialPriceApprovalSignedDocFile(Convert.ToInt32(ViewState["lblSPAID"].ToString()));
                       // btnClear_Click(Sender, e);
                        DivSPAInfo.Visible = false; DivSPAData.Visible = true;
                       // ClearInputs(Page.Controls);
                       Binddata();
                    }
                }
                else
                {
                    lblMessage.Text = "";
                    lblMessage.Text = "Please enter special price number.";
                }
            }




            //if (FileUpload1.HasFile)
            //{
            //    string filename = "";
            //    string[] allowdFile = { ".docx", ".doc" };
            //    //Here we are allowing only pdf file so verifying selected file pdf or not
            //    string FileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            //    bool isValidFile = allowdFile.Contains(FileExt);
            //    if (!isValidFile)
            //    {
            //        lblMessage.Text = "Please upload only docx ";
            //        return;
            //    }
            //    else
            //    {
           

            //filename = Path.GetFileName(FileUpload1.FileName);
            //objprop.P_SPAAttachSignedFileName = filename;
            //string strFolderValue = @"\\192.168.50.158\Word\SPAApprovalSignedFiles\";
            //objprop.P_SPAAttcahSignedFilePath = strFolderValue + filename;
            //// string pat = FilePath + "" + filename;



            //}

            //}
            //else
            //{
            //    lblMessage.Text = "Please upload docx file. ";
            //    return;
            //}
        }
        catch (Exception ex)
        {        

            throw;
        }

    }

    protected void btnClear_Click(object sender,EventArgs e)
    {
        try
        {
          
            ClearInputs(Page.Controls);
            Binddata();
            DivSPAInfo.Visible = false; DivSPAData.Visible = true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void Clear()
    {
        TxtSPA.Text = "";
        lblDistributorName.Text = "";
        lblResellerName.Text = "";
        lblEndusername.Text = "";       
        lblProduct.Text = "";
    }
    public void ClearInputs(ControlCollection ctrls)
    {
        try
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                //else if (ctrl is DropDownList)
                //    ((DropDownList)ctrl).ClearSelection();

                ClearInputs(ctrl.Controls);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

  public void BindPropertice()
    {
        try
        {
            objprop.P_UPPWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPPWOutDcnt_Dstbtrprice.Text);
            objprop.P_UPPWOutDcnt_Rsprice = Convert.ToDecimal(txtUPPWOutDcnt_Rsprice.Text);
            objprop.P_UPPWOutDcnt_EUprice = Convert.ToDecimal(txtUPPWOutDcnt_EUprice.Text);

            objprop.P_SUPReq_Dstbtrprice = Convert.ToDecimal(txtSUPReq_Dstbtrprice.Text);
            objprop.P_SUPReq_Rsprice = Convert.ToDecimal(txtSUPReq_Rsprice.Text);
            objprop.P_SUPReq_Euprice = Convert.ToDecimal(txtSUPReq_Euprice.Text);

            objprop.P_AUP_Dstbtrprice = Convert.ToDecimal(txtAUP_Dstbtrprice.Text);
            objprop.P_AUP_Rsprice = Convert.ToDecimal(txtAUP_Rsprice.Text);
            objprop.P_AUP_Euprice = Convert.ToDecimal(txtAUP_Euprice.Text);

            objprop.P_VSP_Dstbtrprice = Convert.ToDecimal(txtVSP_Dstbtrprice.Text);
            objprop.P_VSP_Rsprice = Convert.ToDecimal(txtVSP_Rsprice.Text);
            objprop.P_VSP_Euprice = Convert.ToDecimal(txtVSP_Euprice.Text);

            objprop.P_CUPMake1_Dstbtrprice = Convert.ToDecimal(txtCUPP_Dstbtrprice1.Text);
            objprop.P_CUPMake1_Rsbtrprice = Convert.ToDecimal(txtCUPP_Rsprice1.Text);
            objprop.P_CUPMake1_Euprice = Convert.ToDecimal(txtCUPP_Euprice1.Text);

            objprop.P_CUPMake2_Dstbtrprice = Convert.ToDecimal(txtCUPP_Dstbtrprice2.Text);
            objprop.P_CUPMake2_Rsbtrprice = Convert.ToDecimal(txtCUPP_Rsprice2.Text);
            objprop.P_CUPMake2_Euprice = Convert.ToDecimal(txtCUPP_Euprice2.Text);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

  //public override void VerifyRenderingInServerForm(Control control)
  //  {
  //      return;
  //  }
}