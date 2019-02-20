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

public partial class ServiceAttachApprovalUpload : System.Web.UI.Page
{
    BusinessLogicLayer.ServiceAttachApproval objprop = new BusinessLogicLayer.ServiceAttachApproval();
    ClsPurchaseOrder objClsPo = new ClsPurchaseOrder();    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DivInfDet.Visible = true;
            BindSANo();
            Binddata();
        }
    }
    public void BindSANo()
    {
        DataTable Dt = ClsPurchaseOrder.GetServiceAttachNumber();
        if (Dt.Rows.Count > 0)
        {
            ddlSANo.Items.Clear();
            ddlSANo.DataSource = Dt;
            ddlSANo.DataValueField = "id";
            ddlSANo.DataTextField = "SA_Number";
            ddlSANo.DataBind();
            ddlSANo.Items.Insert(0, new ListItem("Select SA Number", "0"));
        }
        else
        {
            ddlSANo.Items.Clear();
            ddlSANo.Items.Insert(0, new ListItem("Select SA Number", "0"));
        }
    }
    public void Binddata()
    {
        DataTable dt = ClsPurchaseOrder.BindServiceAttachApproval();
        GvSA.DataSource = dt;
        GvSA.DataBind();
        if (dt.Rows.Count == 0)
        {
            lblMessage.Text = "";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);
            lblMessage.Text = "No Records Found";
        }
        else
        {
            lblMessage.Text = "";
        }
    }
    protected void GvSA_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkSAAFile = (LinkButton)e.Row.FindControl("lnkSAAFile");
            string SAAFile = GvSA.DataKeys[e.Row.RowIndex].Values["SAFilepath"].ToString();
            if (SAAFile != "")
            {
                lnkSAAFile.Text = SAAFile;

                char[] delimiterChars = { '\\', '.' };
                string[] s2 = SAAFile.Split(delimiterChars);
                if (s2.Length >= 2)
                {
                    string SAAFileApproval = s2[s2.Length - 2].ToString();
                    lnkSAAFile.Text = SAAFileApproval;
                }
            }
        }
    }
    protected void lnkSAAFile_OnClick(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnkbtn = sender as LinkButton;
            GridViewRow gvrow = lnkbtn.NamingContainer as GridViewRow;
            string filePath = GvSA.DataKeys[gvrow.RowIndex].Values[2].ToString();
            if (filePath != "")
            {          
                char[] delimiterChars = { '\\' };
                string[] s2 = filePath.Split(delimiterChars);
                if (s2.Length >= 2)
                {
                    string SAAFileApproval = s2[s2.Length - 1].ToString();
                    Response.ContentType = "application/ms-word";
                    Response.AddHeader("Content-Disposition", "attachment;filename="+ SAAFileApproval);
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
    protected void GvSA_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edited")
        {
            DivInf.Visible = true; DivInfDet.Visible = false;
            tr3.Visible = false; tr0.Visible = true; tr1.Visible = true;tr2.Visible = true;

            int Id = Convert.ToInt32(e.CommandArgument.ToString());

            DataTable dt= ClsPurchaseOrder.Usp_GetServiceAttachforApprovaldata(Id);
            lblSANO.Text = dt.Rows[0]["SA_Number"].ToString();
            lblEndusername.Text = dt.Rows[0]["Enduser_Name"].ToString();
            lblResellerName.Text = dt.Rows[0]["Reseller_Name"].ToString();
            lblDistributorName.Text = dt.Rows[0]["Distributor_Name"].ToString();
            //lblSupplier.Text = dt.Rows[0][""].ToString();
            lblType.Text = dt.Rows[0]["Maincategory"].ToString();
            lblCatagory.Text = dt.Rows[0]["Category_Name"].ToString();
            lblProduct.Text = dt.Rows[0]["Product_Name"].ToString();
            lblQuantity.Text= dt.Rows[0]["TotalQuantity"].ToString();
            lblperiodStdYear.Text = dt.Rows[0]["TotalPeriod"].ToString();
            lblCompetitorname.Text = dt.Rows[0]["Competitor_Name"].ToString();
            txtUPSWOutdcntDistributorprice.Text = dt.Rows[0]["UPSWOutDcnt_Dstbtrprice"].ToString();
            txtUPSWOutdcntResellerPrice.Text = dt.Rows[0]["UPSWOutDcnt_Rsprice"].ToString();
            txtUPSWOutdcntEndUserPrice.Text = dt.Rows[0]["UPSWOutDcnt_Euprice"].ToString();

            txtUPSWithdcntDistributorprice.Text = dt.Rows[0]["UPSWDcnt_DstbtrPrice"].ToString();
            txtUPSWithdcntResellerPrice.Text = dt.Rows[0]["UPSWDcnt_Rsprice"].ToString();
            txtUPSWithdcntEndUserPrice.Text = dt.Rows[0]["UPSWDcnt_Euprice"].ToString();

            txtUSAWOutdcntDistributorprice.Text = dt.Rows[0]["USAWOutDcnt_Dstbtrprice"].ToString();
            txtUSAWOutdcntResellerPrice.Text = dt.Rows[0]["USAWOutDcnt_Rsprice"].ToString();
            txtUSAWOutdcntEndUserPrice.Text = dt.Rows[0]["USAWOutDcnt_Euprice"].ToString();

            txtUSAWithdcntDistributorprice.Text = dt.Rows[0]["USAWDcnt_DstbtrPrice"].ToString();
            txtUSAWithdcntResellerPrice.Text = dt.Rows[0]["USAWDcnt_Rsprice"].ToString();
            txtUSAWithdcntEndUserPrice.Text = dt.Rows[0]["USAWDcnt_Euprice"].ToString();
            

            //int index = Convert.ToInt32(e.CommandArgument.ToString());
            //Label lblSANO1 = (Label)GvSA.Rows[index].FindControl("lblSANO");
            //Label lblEndUserName1 = (Label)GvSA.Rows[index].FindControl("lblEndUserName");
            //Label lblResellerName1 = (Label)GvSA.Rows[index].FindControl("lblResellerName");
            //Label lblDistributeName1 = (Label)GvSA.Rows[index].FindControl("lblDistributeName");
            //Label lblModel1 = (Label)GvSA.Rows[index].FindControl("lblModel");
            //Label lblCatNo1 = (Label)GvSA.Rows[index].FindControl("lblCatNo");

            //lblSANO.Text = lblSANO1.Text;
            //lblEndusername.Text = lblEndUserName1.Text;
            //lblResellerName.Text = lblResellerName1.Text;
            //lblDistributorName.Text = lblDistributeName1.Text;
            //lblProduct.Text = lblModel1.Text + "_" + lblCatNo1.Text;
            //lblDistributorName.Text=
        }
    }

    protected void btnSubmit_Click(object Sender,EventArgs e)
    {
        try
        {
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

            string FilePathSave = "";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "";


            HttpContext.Current.Response.ContentType = "application/msword";

            string strFileName = string.Empty;
            strFileName = "ServiceAttachApprovalSignedDocument-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName);

            StringBuilder strHTMLContent = new StringBuilder();

            // strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\kodac1.png'>".ToString());
            strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["kodac1Logo"] + "'>".ToString());

            strHTMLContent.Append(" <h1 title='Heading' align='Center' style='font-family:Calibri;font-size:16px;background:#C0C0C0'>SERVICE ATTACH APPROVAL FORM </h1>".ToString());
            strHTMLContent.Append("<br>".ToString());

            strHTMLContent.Append("<table width='100%' border='2' style='font-family:Calibri;font-size:16px;'>".ToString());


            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td rowspan='3' colspan='2'>".ToString());
            strHTMLContent.Append("<img src='" + WebConfigurationManager.AppSettings["CentillionLogo"] + "'>".ToString());
            //strHTMLContent.Append("<img src='" + @"E:\CSSProjects\Inventory_VSS_04-May-2017\ImagingTOOL\images\logo.jpg'>".ToString());
            strHTMLContent.Append(" </td>");
            strHTMLContent.Append("<td colspan='2'>Name of  End User </td>".ToString());
            strHTMLContent.Append("<td>" + lblEndusername.Text + "</td>".ToString());
            strHTMLContent.Append("</tr>".ToString());

            //strHTMLContent.Append("<tr>".ToString());
            //strHTMLContent.Append("<td>Name of  Distributor </td>".ToString());
            //strHTMLContent.Append("<td colspan='4'>" + txtDistributorName.Text + "</td>".ToString());
            //strHTMLContent.Append("</tr>".ToString());


            // txtResellerName

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Name of  Reseller </td>".ToString());
            strHTMLContent.Append("<td>" + lblResellerName.Text + "</td>".ToString());

            strHTMLContent.Append("<tr>".ToString());
            strHTMLContent.Append("<td colspan='2'>Name of Distributor</td>".ToString());
            strHTMLContent.Append("<td>" + lblDistributorName.Text + "</td>".ToString());

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
            strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
            strHTMLContent.Append("<td>" + lblProduct.Text + "</td>".ToString());
            strHTMLContent.Append("<td> " + lblQuantity.Text + " </td>".ToString());
            strHTMLContent.Append("<td>" + lblperiodStdYear.Text + "</td>".ToString());
            strHTMLContent.Append("<td>" + lblCompetitorname.Text + "</td>".ToString());
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
            DateTime WDate = Convert.ToDateTime(TxtWarrantyDate.Text.Trim());
            string WarrentyDate = WDate.ToString("dd/MM/yyyy");
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
            string strFolderValue = WebConfigurationManager.AppSettings["SAApprovalSignedFiles"];
            // string strFolderValue = @"\\192.168.50.158\Word\SAApprovalSignedFiles\";
            DirectoryInfo Folder = new DirectoryInfo(strFolderValue);
            string SAFilename = strFileName;
            string SAFilePath = strFolderValue.ToString() + strFileName.ToString();



            objprop.P_UPSWDcnt_DstbtrPrice = Convert.ToDecimal(txtUPSWithdcntDistributorprice.Text);
            objprop.P_UPSWDcnt_Euprice = Convert.ToDecimal(txtUPSWithdcntEndUserPrice.Text);
            objprop.P_UPSWDcnt_Rsprice = Convert.ToDecimal(txtUPSWithdcntResellerPrice.Text);
            objprop.P_UPSWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUPSWOutdcntDistributorprice.Text);
            objprop.P_UPSWOutDcnt_Euprice = Convert.ToDecimal(txtUPSWOutdcntEndUserPrice.Text);
            objprop.P_UPSWOutDcnt_Rsprice = Convert.ToDecimal(txtUPSWOutdcntResellerPrice.Text);
            objprop.P_USAWDcnt_DstbtrPrice = Convert.ToDecimal(txtUSAWithdcntDistributorprice.Text);
            objprop.P_USAWDcnt_Euprice = Convert.ToDecimal(txtUSAWithdcntEndUserPrice.Text);
            objprop.P_USAWDcnt_Rsprice = Convert.ToDecimal(txtUSAWithdcntResellerPrice.Text);
            objprop.P_USAWOutDcnt_Dstbtrprice = Convert.ToDecimal(txtUSAWOutdcntDistributorprice.Text);
            objprop.P_USAWOutDcnt_Euprice = Convert.ToDecimal(txtUSAWOutdcntEndUserPrice.Text);
            objprop.P_USAWOutDcnt_Rsprice = Convert.ToDecimal(txtUSAWOutdcntResellerPrice.Text);
            objprop.P_SASignedFilename = SAFilename;
            objprop.P_SASignedFilePath = SAFilePath;

            DateTime? Warrenty;
            if (TxtWarrantyDate.Text.Trim() == string.Empty)
            {
                Warrenty = null;
            }
            else
            {
                Warrenty = Convert.ToDateTime(TxtWarrantyDate.Text, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            }           
            objprop.P_Warrenty = Warrenty;



            //filename = Path.GetFileName(FileUpload1.FileName);
            //objprop.P_SASignedFilename = filename;
            //string strFolderValue = @"\\192.168.50.158\Word\SAApprovalSignedFiles\";
            //objprop.P_SASignedFilePath = strFolderValue + filename;
            // string pat = FilePath + "" + filename;


            if (ddlSANo.SelectedValue != "0")
            {
                DataTable dt = ClsPurchaseOrder.CheckExistSA_Number(ddlSANo.SelectedItem.Text);
                if (dt.Rows.Count > 0)
                {
                    Session["SANo"] = ddlSANo.SelectedItem.Text.Trim();
                    Session["SANoValue"]= ddlSANo.SelectedValue;
                    int i = objClsPo.UpdateServiceAttachApprovalwithSignedDocument(ddlSANo.SelectedItem.Text, objprop);
                    if (i > 0)
                    {
                        //FileUpload1.SaveAs(strFolderValue + filename);
                        //lblMessage.Text = "";
                        //lblMessage.Text = "Uploaded Successfully.";
                        // FileUpload1.SaveAs(strFolderValue + filename);

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
                        lblMsg.Text = "";
                        lblMsg.Text = "Updated Successfully.";


                        // Clear();
                        tr3.Visible = true; tr0.Visible = false; tr1.Visible = false; tr2.Visible = false;
                        BindSANo();
                        Binddata();
                        Session["SPAStatus"] = 1;

                        Response.Redirect("~/SpecialPriceApproval.aspx", true);
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = "Service attach number not exists";
                }
            }
            else if (lblSANO.Text != "")
            {
                DataTable dt = ClsPurchaseOrder.CheckExistSA_Number(lblSANO.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    Session["SANo"] = lblSANO.Text;
                    Session["SANoValue"] = dt.Rows[0]["id"].ToString();
                    int i = objClsPo.UpdateServiceAttachApprovalwithSignedDocument(lblSANO.Text, objprop);
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
                        lblMsg.Text = "";
                        lblMsg.Text = "Updated Successfully.";
                        objClsPo.MAIL_FOR_ServiceAttchApprovalForSignedDocFile(lblSANO.Text.Trim());

                        //lblMessage.Text = "";
                        //lblMessage.Text = "Uploaded Successfully";
                        // Clear();
                        tr3.Visible = true; tr0.Visible = false; tr1.Visible = false; tr2.Visible = false;
                        BindSANo();
                        Binddata();
                        Session["SPAStatus"] = 1;

                        Response.Redirect("~/SpecialPriceApproval.aspx", true);
                    }
                }
                else
                {
                    lblMsg.Text = "";
                    lblMsg.Text = "Service attach number not exists";
                }
            }
            else
            {
                lblMsg.Text = "";
                lblMsg.Text = "please select Service attach number.";
            }
            //    }

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
    protected void btnCancel_Click(object sender,EventArgs e)
    {
        try
        {
            ClearInputs(Page.Controls);
            DivInfDet.Visible = true; DivInf.Visible = false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void Clear()
    {
        lblDistributorName.Text = "";
        lblResellerName.Text = "";
        lblEndusername.Text = "";
        lblSANO.Text = "";
        lblProduct.Text = "";
        TxtWarrantyDate.Text = "";
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
}