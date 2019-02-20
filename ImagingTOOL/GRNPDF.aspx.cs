using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class GRNPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGRNList();
            Panel1.Visible = false;
        }
    }
    private void GetGRNList()
    {
        try
        {
            DataTable dt = ClsMaster.GetGRNNumbers();
            ddlGRN.DataSource = dt;
            ddlGRN.DataTextField = "GRN_Number";
            ddlGRN.DataValueField = "GRN_ID";
            ddlGRN.DataBind();
            ddlGRN.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "0"));


        }
        catch (Exception Ex)
        {

        }
    }

    private void BindGRNDetailsData()
    {
        try
        {
            DataTable DtGRNDet = BusinessServices.Get_GRNDetailsdata_ForPDF(Convert.ToInt32(ddlGRN.SelectedValue));
            GridView1.DataSource = DtGRNDet;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    protected void btnExport_Click(object sender,EventArgs e)
    {
        try
        {
            if (ddlGRN.SelectedValue != "0")
            {
                Panel1.Visible = true;
                DataTable Dt = BusinessServices.Get_GRNdataFor_PDF(Convert.ToInt32(ddlGRN.SelectedValue));//ToString("ddMMMYY");
                LblDate.Text = Dt.Rows[0]["InvoiceDate"].ToString(); //System.DateTime.Now.ToString("dd-MMM-yyyy");
                lblbtmDate.Text = Dt.Rows[0]["InvoiceDate"].ToString();//System.DateTime.Now.ToString("dd-MMM-yyyy");
                lblLocation.Text = Dt.Rows[0]["Location_Name"].ToString();
                lbl_GRNnumber.Text = Dt.Rows[0]["GRN_Number"].ToString();
                Lbl_AwbNum.Text = Dt.Rows[0]["AWBNum"].ToString();
                lbl_Transport.Text = Dt.Rows[0]["TransportCo"].ToString();
                lbl_VehicleNo.Text = Dt.Rows[0]["VehicleNo"].ToString();
                lbl_SupplierName.Text = Dt.Rows[0]["Supplier_Name"].ToString();
                lblInvoiceNum.Text = Dt.Rows[0]["InvoiceNum"].ToString();
                lblInvoiceDate.Text = Dt.Rows[0]["InvoiceDate"].ToString();
                lblPoNumber.Text = Dt.Rows[0]["PO_Number"].ToString();
                BindGRNDetailsData();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=GRN.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView1.HeaderRow.Style.Add("width", "10%");
                GridView1.HeaderRow.Style.Add("font-size", "10px");
                GridView1.Style.Add("font-size", "8px");
                Panel1.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());


                Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfWriter.PageEvent = new Comman.ITextEvents();
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                // Response.End();
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                Panel1.Visible = false;
                GetGRNList();

            }
            else
            {
                Panel1.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select GRN Number.');</script>", false);
            }
         
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}