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
using System.Drawing;

public partial class GST_DC_Form_PDF : System.Web.UI.Page
{
    int value;
    ClsGST_PDF objGST = new ClsGST_PDF();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_GST_DC_MasterList();
            Panel1.Visible = false;
        }

    }
    private void Get_GST_DC_MasterList()
    {
        try
        {
            DataTable dt1 = objGST.Get_GST_DC_Number();
            ddlGSTnumber.DataSource = dt1;
            ddlGSTnumber.DataTextField = "DC_no";
            ddlGSTnumber.DataValueField = "ID";
            ddlGSTnumber.DataBind();
            ddlGSTnumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select GST DC Number --", "0"));

        }
        catch (Exception Ex)
        {
            throw;
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void btnExport_GST_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ddlGSTnumber.SelectedValue.ToString()) != 0)
            {
                Panel1.Visible = true;

                DataTable dt = objGST.Get_GST_DCDetailsonID(Convert.ToInt32(ddlGSTnumber.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    LblSRDCNum.Text = dt.Rows[0]["Serial No. of delivery challan"].ToString();               
                    LblTrans.Text = dt.Rows[0]["Mode of Transport"].ToString();
                    LblGST.Text = dt.Rows[0]["GSTIN"].ToString();

                    LblVehical.Text = dt.Rows[0]["Vehicle No"].ToString();
                    Lblsupply.Text = dt.Rows[0]["Place of Supply"].ToString();
                    LblDate.Text = dt.Rows[0]["DC_Date"].ToString();



                    LblName.Text = dt.Rows[0]["Name"].ToString();
                    LblAddress.Text = dt.Rows[0]["Address"].ToString();
                    LblState.Text = dt.Rows[0]["State"].ToString();
                    Lbl_Place_Suply.Text = dt.Rows[0]["Place of Supply"].ToString();
                    LblGst_Uniq.Text = dt.Rows[0]["GSTIN/Unique ID"].ToString();

                    DataTable DT1 = objGST.Get_GST_DC_Product_DetailsonID(Convert.ToInt32(ddlGSTnumber.SelectedValue));
                    if (DT1.Rows.Count > 0)
                    {
                        GridView1.DataSource = DT1;
                        GridView1.DataBind();
                    }
                    DataTable dt2 = objGST.Get_GST_DC_TotAmt_onID(Convert.ToInt32(ddlGSTnumber.SelectedValue));
                    if (dt2.Rows.Count > 0)
                    {
                        LblAmountBeforeTax.Text = dt2.Rows[0]["Total Amount before Tax"].ToString();
                        LblAmountAfterTax.Text = dt2.Rows[0]["Total Amount after Tax"].ToString();
                    }
                    DataTable dt3 = objGST.Get_GST_DC_Tax_onID(Convert.ToInt32(ddlGSTnumber.SelectedValue));
                    if (dt3.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            if (dt3.Rows[i]["Taxname"].ToString() == "Add: CGST" || dt3.Rows[i]["Taxname"].ToString() == "Add: IGST")
                            {
                                trcgstigst.Visible = true;
                                lblAddCGST.Text = dt3.Rows[i]["TAX"].ToString();
                                lblCGSTIGST.Text= dt3.Rows[i]["Taxname"].ToString();
                            }
                            else if (dt3.Rows[i]["Taxname"].ToString() == "Add: SGST")
                            {
                                trsgst.Visible = true;
                                LblAddSGST.Text = dt3.Rows[i]["TAX"].ToString();
                                lblSGST.Text = dt3.Rows[i]["Taxname"].ToString();
                            }
                            else if (dt3.Rows[i]["Taxname"].ToString() == "Add: Exempted Tax @ NIL")
                            {
                                trnull.Visible = true;
                                LblAddExumpted.Text = dt3.Rows[i]["TAX"].ToString();
                                lblExumpted.Text = dt3.Rows[i]["Taxname"].ToString();
                            }
                        }

                    }
                    //int CategoryID = 0;

                    //Get_GST_DC_MasterList();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=GST_DC_Form.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridView1.HeaderRow.Style.Add("width", "10%");
                    GridView1.HeaderRow.Style.Add("font-size", "10px");

                    GridView1.Style.Add("font-size", "8px");
                    Panel1.RenderControl(hw);

                    StringReader sr = new StringReader(sw.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 120f, 100f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

                    pdfWriter.PageEvent = new Comman.ITextGSTEvent();

                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);

                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    Panel1.Visible = false;
                    //Get_GST_DC_MasterList();
                }
            }
            else
            {
                Panel1.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select GST DC Number.');</script>", false);

            }

        }
        catch (Exception ex)
        { }
    }
}