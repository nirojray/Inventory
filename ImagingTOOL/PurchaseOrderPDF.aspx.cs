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

public partial class PurchaseOrderPDF : System.Web.UI.Page
{

    int value;string StrRupInWord = "";string StrRupInWord1 = "";

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
                        //lbl_Footer_Address1.Text = dt.Rows[0]["BillingAddress"].ToString();                       
                        lbl_Term4.Text = "4. Warranty :" + dt.Rows[0]["Warranty"].ToString();
                        lblBillGST.Text= dt.Rows[0]["GST"].ToString();
                        lblBillPAN.Text= dt.Rows[0]["PAN"].ToString();
                        lblSPA.Text= dt.Rows[0]["SPANumber"].ToString();
                       // lblShipGST.Text= dt.Rows[0]["GST"].ToString();
                        lblShipPAN.Text= dt.Rows[0]["PAN"].ToString();
                        
                        DataTable DT1 = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
                        int CategoryID = 0;
                        //foreach (DataRow row in DT1.Rows)
                        //{
                        //for (int i = 0; i < DT1.Rows.Count - 1; i++)
                        //{
                        //    CategoryID = Convert.ToInt32(DT1.Rows[i]["catagoryid"].ToString());

                            //if (CategoryID == 33)
                            //{
                            //GetSalesManager();
                            GetSalesManagerAMC1();
                        //lbl_Term3.Text = "";
                        //}
                        //else
                        //{
                        //    GetSalesManager();

                        //}
                        // }
                        //if (CategoryID == 33)
                        //{

                        //foreach (GridViewRow row in GridView1.Rows)
                        //{
                        //    foreach (TableCell cell in row.Cells)
                        //    {
                        //        row.Cells[0].Width = 10;
                        //    }
                        //}


                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=PO.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        StringWriter sw = new StringWriter();
                        HtmlTextWriter hw = new HtmlTextWriter(sw);
                        GridView1.HeaderRow.Style.Add("width", "10%");
                        GridView1.HeaderRow.Style.Add("font-size", "10px");
                        GridView1.Style.Add("font-size", "8px");
                        Panel1.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                      
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 100f, 100f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfWriter.PageEvent = new Comman.ITextEvents();
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
                        lblSPA.Text = dt.Rows[0]["SPANumber"].ToString();
                        lblSupBilGST.Text = dt.Rows[0]["GST"].ToString();
                        lblSupBilPAN.Text = dt.Rows[0]["PAN"].ToString();

                        //lbl_Footer_Address1.Text = dt.Rows[0]["BillingAddress"].ToString();                       

                        DataTable DT1 = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
                        foreach (DataRow row in DT1.Rows)
                        {
                            int CategoryID = Convert.ToInt32(DT1.Rows[0]["catagoryid"].ToString());

                            if (CategoryID == 5 || CategoryID == 20 || CategoryID == 30 || CategoryID == 31 || CategoryID == 32 || CategoryID == 33 || CategoryID == 42)
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
                        GridView3.HeaderRow.Style.Add("width", "10%");
                        GridView3.HeaderRow.Style.Add("font-size", "10px");
                        GridView3.Style.Add("font-size", "8px");

                        Panel2.RenderControl(hw);

                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 130f, 100f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfWriter.PageEvent = new Comman.ITextEvents();
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
                Panel1.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select PO Number.');</script>", false);
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
            int count = ds.Rows.Count;
            double total = Convert.ToDouble(ds.Rows[count - 1]["TT"].ToString());
            StrRupInWord1 = "Word: "+ AmountInWords(Convert.ToDecimal(total));
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
            int count = ds.Rows.Count;
            double total = Convert.ToDouble(ds.Rows[count - 1]["TT"].ToString());
            StrRupInWord = "Word: "+ AmountInWords(Convert.ToDecimal(total));
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
            if (LblProduct.Text == "" && LblProductcode.Text == "" && LblPrice.Text == "")
            {
                GridView1.Rows[i].Cells[0].ColumnSpan = 5;
                GridView1.Rows[i].Cells[0].Text = StrRupInWord;
                GridView1.Rows[i].Cells[0].Font.Bold = true;
                GridView1.Rows[i].Cells[0].Font.Size = 9;
                GridView1.Rows[i].Cells.RemoveAt(1);
                GridView1.Rows[i].Cells.RemoveAt(1);
                GridView1.Rows[i].Cells.RemoveAt(1);
                GridView1.Rows[i].Cells.RemoveAt(1);
            }
            else
            {
                GridView1.Rows[i].Cells[0].Width = 2;
            }

        }
    }
    protected void GridView3_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GridView3.Rows.Count; i++)
        {
            Label LblProduct = (Label)GridView3.Rows[i].FindControl("LblProduct");
            Label LblSACCode = (Label)GridView3.Rows[i].FindControl("LblSACCode");
            Label LblPrice = (Label)GridView3.Rows[i].FindControl("LblPrice");
            if (LblProduct.Text == "" && LblSACCode.Text == "" && LblPrice.Text == "")
            {
                GridView3.Rows[i].Cells[0].ColumnSpan = 4;
                GridView3.Rows[i].Cells[0].Text = StrRupInWord1;
                GridView3.Rows[i].Cells[0].Font.Bold = true;
                GridView3.Rows[i].Cells[0].Font.Size = 9;
                GridView3.Rows[i].Cells.RemoveAt(1);
                GridView3.Rows[i].Cells.RemoveAt(1);
                GridView3.Rows[i].Cells.RemoveAt(1);
            }

        }
    }
    public string AmountInWords(decimal Num)
    {
        string returnValue;
        //I have created this function for converting amount in indian rupees (INR).
        //You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.


        string strNum;
        string strNumDec;
        string StrWord;
        strNum = Num.ToString();


        if (strNum.IndexOf(".") + 1 != 0)
        {
            strNumDec = strNum.Substring(strNum.IndexOf(".") + 2 - 1);


            if (strNumDec.Length == 1)
            {
                strNumDec = strNumDec + "0";
            }
            if (strNumDec.Length > 2)
            {
                strNumDec = strNumDec.Substring(0, 2);
            }


            strNum = strNum.Substring(0, strNum.IndexOf(".") + 0);
            StrWord = ((double.Parse(strNum) == 1) ? " Rupee " : " Rupees ") + NumToWord((decimal)(double.Parse(strNum))) + ((double.Parse(strNumDec) > 0) ? (" and " + cWord3((decimal)(double.Parse(strNumDec)))) : " ");
            StrWord += " Paise";
        }
        else
        {
            StrWord = ((double.Parse(strNum) == 1) ? " Rupee " : " Rupees ") + NumToWord((decimal)(double.Parse(strNum)));
        }
        returnValue = StrWord + " Only";
        return returnValue;
    }
    static public string NumToWord(decimal Num)
    {
        string returnValue;


        //I divided this function in two part.
        //1. Three or less digit number.
        //2. more than three digit number.
        string strNum;
        string StrWord;
        strNum = Num.ToString();


        if (strNum.Length <= 3)
        {
            StrWord = cWord3((decimal)(double.Parse(strNum)));
        }
        else
        {
            StrWord = cWordG3((decimal)(double.Parse(strNum.Substring(0, strNum.Length - 3)))) + " " + cWord3((decimal)(double.Parse(strNum.Substring(strNum.Length - 2 - 1))));
        }
        returnValue = StrWord;
        return returnValue;
    }
    static public string cWordG3(decimal Num)
    {
        string returnValue;
        //2. more than three digit number.
        string strNum = "";
        string StrWord = "";
        string readNum = "";
        strNum = Num.ToString();
        if (strNum.Length % 2 != 0)
        {
            readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
            if (readNum != "0")
            {
                StrWord = retWord(decimal.Parse(readNum));
                readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 1) + "000"));
                StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
            }
            strNum = strNum.Substring(1);
        }
        while (!System.Convert.ToBoolean(strNum.Length == 0))
        {
            readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 2)));
            if (readNum != "0")
            {
                StrWord = StrWord + " " + cWord3(decimal.Parse(readNum));
                readNum = System.Convert.ToString(double.Parse("1" + strReplicate("0", strNum.Length - 2) + "000"));
                StrWord = StrWord + " " + retWord(decimal.Parse(readNum));
            }
            strNum = strNum.Substring(2);
        }
        returnValue = StrWord;
        return returnValue;
    }
    static public string cWord3(decimal Num)
    {
        string returnValue;
        //1. Three or less digit number.
        string strNum = "";
        string StrWord = "";
        string readNum = "";
        if (Num < 0)
        {
            Num = Num * -1;
        }
        strNum = Num.ToString();


        if (strNum.Length == 3)
        {
            readNum = System.Convert.ToString(double.Parse(strNum.Substring(0, 1)));
            StrWord = retWord(decimal.Parse(readNum)) + " Hundred";
            strNum = strNum.Substring(1, strNum.Length - 1);
        }


        if (strNum.Length <= 2)
        {
            if (double.Parse(strNum) >= 0 && double.Parse(strNum) <= 20)
            {
                StrWord = StrWord + " " + retWord((decimal)(double.Parse(strNum)));
            }
            else
            {
                StrWord = StrWord + " " + retWord((decimal)(System.Convert.ToDouble(strNum.Substring(0, 1) + "0"))) + " " + retWord((decimal)(double.Parse(strNum.Substring(1, 1))));
            }
        }


        strNum = Num.ToString();
        returnValue = StrWord;
        return returnValue;
    }
    static public string retWord(decimal Num)
    {
        string returnValue;
        //This two dimensional array store the primary word convertion of number.
        returnValue = "";
        object[,] ArrWordList = new object[,] { { 0, "" }, { 1, "One" }, { 2, "Two" }, { 3, "Three" }, { 4, "Four" }, { 5, "Five" }, { 6, "Six" }, { 7, "Seven" }, { 8, "Eight" }, { 9, "Nine" }, { 10, "Ten" }, { 11, "Eleven" }, { 12, "Twelve" }, { 13, "Thirteen" }, { 14, "Fourteen" }, { 15, "Fifteen" }, { 16, "Sixteen" }, { 17, "Seventeen" }, { 18, "Eighteen" }, { 19, "Nineteen" }, { 20, "Twenty" }, { 30, "Thirty" }, { 40, "Forty" }, { 50, "Fifty" }, { 60, "Sixty" }, { 70, "Seventy" }, { 80, "Eighty" }, { 90, "Ninety" }, { 100, "Hundred" }, { 1000, "Thousand" }, { 100000, "Lakh" }, { 10000000, "Crore" } };

        int i;
        for (i = 0; i <= (ArrWordList.Length - 1); i++)
        {
            if (Num == System.Convert.ToDecimal(ArrWordList[i, 0]))
            {
                returnValue = (string)(ArrWordList[i, 1]);
                break;
            }
        }
        return returnValue;
    }
    static public string strReplicate(string str, int intD)
    {
        string returnValue;
        //This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        //using this function you can replicate any Charactor with given string.
        int i;
        returnValue = "";
        for (i = 1; i <= intD; i++)
        {
            returnValue = returnValue + str;
        }
        return returnValue;
    }
}