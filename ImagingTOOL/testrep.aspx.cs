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

public partial class testrep : System.Web.UI.Page
{
    int value;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetMasterList();
            Panel1.Visible = false; Panel2.Visible = false;
        }
    }
    private void GetMasterList()
    {
        try
        {
            DataTable dt = ClsMaster.GetPONumber();
            ddlPonumber.DataSource = dt;
            ddlPonumber.DataTextField = "PO_Number";
            ddlPonumber.DataValueField = "PO_ID";
            ddlPonumber.DataBind();
            ddlPonumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "-1"));


        }
        catch (Exception Ex)
        {

        }
    }
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
            GvwSaleseOrderDetails.DataSource = ds;
            GvwSaleseOrderDetails.DataBind();
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSaleseOrderDetails.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }
    private void GetSalesManagerSupport()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
            GvwSaleseOrderDetailsSupport.DataSource = ds;
            GvwSaleseOrderDetailsSupport.DataBind();
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSaleseOrderDetailsSupport.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());

        }
        catch (Exception ex)
        {
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPonumber.SelectedIndex != 0)
            {
                string MainCategory = ClsPurchaseInvoice.Get_MainCategory_BasedOn_POID(Convert.ToInt64(ddlPonumber.SelectedValue.ToString()));
                if (MainCategory != "Support")
                {
                    Panel1.Visible = true;
                    value = Convert.ToInt32(ddlPonumber.SelectedValue.ToString());
                    if (value != -1)
                    {
                        DataTable dt = ClsReportPurchaseOrder.Report_PurchaseOrder(value);                       
                        lbl_Ponumber.Text = dt.Rows[0]["PO Number"].ToString();
                        lbl_PoDate.Text = Convert.ToDateTime(dt.Rows[0]["PO Date"]).ToString("dd-MM-yyyy");
                        lbl_PO_RaisedTO.Text = dt.Rows[0]["PO_Raise_TO"].ToString();
                        lbl_Bill_Address.Text = dt.Rows[0]["BillingAddress"].ToString();                       
                        lbl_Ship_Address.Text = dt.Rows[0]["ShippingAddress"].ToString();                      
                        lbl_Footer_Address1.Text = dt.Rows[0]["BillingAddress"].ToString();                       
                        lbl_Term4.Text = "3. Warranty :" + dt.Rows[0]["Warranty"].ToString();

                        DataTable DT1 = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
                        int CategoryID = 0;
                        //foreach (DataRow row in DT1.Rows)
                        //{
                        for (int i = 0; i < DT1.Rows.Count - 1; i++)
                        {
                            CategoryID = Convert.ToInt32(DT1.Rows[i]["catagoryid"].ToString());

                            //if (CategoryID == 33)
                            //{
                            //GetSalesManager();
                            
                            //lbl_Term3.Text = "";
                            //}
                            //else
                            //{
                            //    GetSalesManager();

                            //}
                        }
                        GetSalesManagerAMC1();
                        //if (CategoryID == 33)
                        //{
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=PO.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //GridView1.HeaderRow.Style.Add("width", "10%");
                      
                        GridView1.HeaderRow.Style.Add("font-size", "10px");
                        GridView1.Style.Add("font-size", "8px");
                        Panel1.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        // Response.End();
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.SuppressContent = true;
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        Panel1.Visible = false;
                        GetMasterList();
                        #region old code
                        //}
                        //else
                        //{
                        //    Response.ContentType = "application/pdf";
                        //    Response.AddHeader("content-disposition", "attachment;filename=PO.pdf");
                        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        //    StringWriter sw = new StringWriter();
                        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
                        //    GvwSaleseOrderDetails.HeaderRow.Style.Add("width", "10%");
                        //    GvwSaleseOrderDetails.HeaderRow.Style.Add("font-size", "10px");
                        //    GvwSaleseOrderDetails.Style.Add("font-size", "8px");
                        //    Panel1.RenderControl(hw);

                        //    StringReader sr = new StringReader(sw.ToString());
                        //    Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        //    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        //    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        //    pdfDoc.Open();
                        //    htmlparser.Parse(sr);
                        //    pdfDoc.Close();
                        //    Response.Write(pdfDoc);
                        //    // Response.End();
                        //    HttpContext.Current.Response.Flush();
                        //    HttpContext.Current.Response.SuppressContent = true;
                        //    HttpContext.Current.ApplicationInstance.CompleteRequest();
                        //    Panel1.Visible = false;
                        //    GetMasterList();
                        //}
                        #endregion
                    }
                    else
                    {
                        Panel1.Visible = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select PO Number.');</script>", false);

                    }
                }
                else
                {
                    Panel2.Visible = true;
                    value = Convert.ToInt32(ddlPonumber.SelectedValue.ToString());
                    if (value != -1)
                    {
                        DataTable dt = ClsReportPurchaseOrder.Report_PurchaseOrder(value);                      
                        lbl_PonumberSupport.Text = dt.Rows[0]["PO Number"].ToString();
                        lbl_PoDateSupport.Text = Convert.ToDateTime(dt.Rows[0]["PO Date"]).ToString("dd-MM-yyyy");
                        lbl_PO_RaisedTO.Text = dt.Rows[0]["PO_Raise_TO"].ToString();
                        lbl_Bill_Address_Support.Text = dt.Rows[0]["BillingAddress"].ToString();                        
                        lbl_Ship_Address_Support.Text = dt.Rows[0]["ShippingAddress"].ToString();                       
                        lbl_Footer_Address1.Text = dt.Rows[0]["BillingAddress"].ToString();                       

                        DataTable DT1 = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
                        foreach (DataRow row in DT1.Rows)
                        {
                            int CategoryID = Convert.ToInt32(DT1.Rows[0]["catagoryid"].ToString());

                            if (CategoryID == 5 || CategoryID == 20 || CategoryID == 30 || CategoryID == 31 || CategoryID == 32 || CategoryID == 33)
                            {
                                //GetSalesManagerSupport();
                                GetSalesManagerAMC();
                                lbl_Term3.Text = "";
                            }
                            else
                            {
                                GetSalesManagerSupport();
                            }
                        }
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=PO.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();                        
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        
                       // GridView3.HeaderRow.Style.Add("width", "10%");                     
                        GridView3.HeaderRow.Style.Add("font-size", "10px");
                        GridView3.Style.Add("font-size", "8px");

                        Panel2.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        Response.Write(pdfDoc);
                        // Response.End();
                        HttpContext.Current.Response.Flush();
                        HttpContext.Current.Response.SuppressContent = true;
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        Panel2.Visible = false;
                        GetMasterList();
                    }
                    else
                    {
                        Panel2.Visible = false;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select PO Number.');</script>", false);

                    }
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
        }
        //ddlPonumber.SelectedItem.Value = "-1";
    }

    private void GetSalesManagerAMC()
    {       
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoicePDF(value);
            GridView3.DataSource = ds;
            GridView3.DataBind();

            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GridView3.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }

    private void GetSalesManagerAMC1()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoicePDF(value);
            GridView1.DataSource = ds;
            GridView1.DataBind();          
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
            GridView1.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void GridView1_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label LblProduct = (Label)GridView1.Rows[i].FindControl("LblProduct");
            Label LblProductcode = (Label)GridView1.Rows[i].FindControl("LblProductcode");
            Label LblPrice = (Label)GridView1.Rows[i].FindControl("LblPrice");

            //GridView1.Rows[i].Cells[1].Style.Add("Width", "200px");
            if (LblProduct.Text == "" && LblProductcode.Text == "" && LblPrice.Text == "")
            {               
                GridView1.Rows[i].Cells[0].ColumnSpan = 3;
                GridView1.Rows[i].Cells.RemoveAt(1);
                GridView1.Rows[i].Cells.RemoveAt(1);
            }

        }
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {

            Label LblProduct = (Label)GridView3.Rows[i].FindControl("LblProduct");
            Label LblProductcode = (Label)GridView3.Rows[i].FindControl("LblProductcode");
            Label LblPrice = (Label)GridView3.Rows[i].FindControl("LblPrice");
           // GridView3.Rows[i].Cells[0].Style.Add("Width", "200px");
            if (LblProduct.Text == "" && LblPrice.Text == "")
            {
                GridView3.Rows[i].Cells[0].ColumnSpan = 2;
                GridView3.Rows[i].Cells.RemoveAt(1);
                GridView3.Rows[i].Cells.RemoveAt(1);
            }

        }
    }

}


