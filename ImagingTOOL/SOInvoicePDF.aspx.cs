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
using System.Collections;

public partial class SOInvoicePDF : System.Web.UI.Page
{
    int value;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSoNumber();
           // LoadGridDetails();
            Panel1.Visible = false; TblCgst.Visible = false; tblIGST.Visible = false;
        }
    }
    private void LoadSoNumber()
    {
        try
        {
            DataTable dt = ClsMaster.GetSONumberApproved();
            ddlSONumber.DataSource = dt;
            ddlSONumber.DataTextField = "Invoice_Number";
            ddlSONumber.DataValueField = "Invoice_ID";
            ddlSONumber.DataBind();
            ddlSONumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select SO Invoice NO--", "0"));


        }
        catch (Exception Ex)
        {

        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true; tblIGST.Visible = false;
        value = Convert.ToInt32(ddlSONumber.SelectedValue.ToString());
        if (value != 0)
        {
            DataTable Dt = BusinessServices.GetSOInvoicedataForPdf(Convert.ToInt32(ddlSONumber.SelectedValue));


            lblInvoiceNo.Text = Dt.Rows[0]["Invoice_Number"].ToString();
            lblCustPoNum.Text= Dt.Rows[0]["SO_CusutomerOrderNO"].ToString();
            lblInvoiceDate.Text = Dt.Rows[0]["Invocie_Date"].ToString();
            lblCustPOdate.Text = Dt.Rows[0]["SO_CusutomerOrderdate"].ToString();
            lblReverseCharge.Text= Dt.Rows[0]["ReverseCharge"].ToString();
            lblTransportMode.Text = Dt.Rows[0]["TransportMode"].ToString(); 
            lblGSTIN.Text= Dt.Rows[0]["GSTIN"].ToString();
            lblDCNum.Text = Dt.Rows[0]["DC_no"].ToString();
            lblSate.Text = Dt.Rows[0]["State_Name"].ToString();
            lblStatecode.Text = Dt.Rows[0]["StateCode"].ToString();
            lblDateofSupply.Text = Dt.Rows[0]["DC_Date"].ToString();
            lblPaymentterm.Text = Dt.Rows[0]["PaymentTerm"].ToString();
            lblPlaceofSupply.Text = Dt.Rows[0]["SupplyStateName"].ToString();
            lblSupplyCode.Text = Dt.Rows[0]["SupplyStateCode"].ToString();
            lblWarrenty.Text = Dt.Rows[0]["Warranty"].ToString();
            lblNatureofSupply.Text = Dt.Rows[0]["NatureofSupply"].ToString();            
            if(Dt.Rows[0]["SO_Main_CategoryID"].ToString()=="3" || Dt.Rows[0]["SO_Main_CategoryID"].ToString() == "4")
            {
                lblHNatureofSupply.Text = "Nature of Service :";
            }
            else
            {
                lblHNatureofSupply.Text = "Nature of Supply :";
            }
            LblBilName.Text = Dt.Rows[0]["CustomerName"].ToString();
            lbl_Bill_Address.Text = Dt.Rows[0]["SO_Billing_TO"].ToString();
            lblBilGSTIN.Text = Dt.Rows[0]["SupGSTIN"].ToString();
            lblBilState.Text =" "+ Dt.Rows[0]["SupplyStateName"].ToString();
            lblBilStateCode.Text = Dt.Rows[0]["SupplyStateCode"].ToString();

            lblShipName.Text = Dt.Rows[0]["CustomerName"].ToString();
            lbl_Ship_Address.Text = Dt.Rows[0]["SO_Shipping_TO"].ToString();
           // lblShipGSTIN.Text = "";
            // lblShipState.Text = Dt.Rows[0]["SupplyStateName"].ToString();
           // lblShipStateCode.Text = Dt.Rows[0]["SupplyStateCode"].ToString();
            string SalesType= Dt.Rows[0]["SalesType"].ToString();
            Session["LocationName"] = Dt.Rows[0]["Location_Name"].ToString();
            if (SalesType == "CGST-SGST-INTRA STATE")
            {
                LoadGridDetails();
                TblCgst.Visible = true; tblIGST.Visible = false;
                // LoadTax();

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=SalesTaxInvoice.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // GvwSaleseOrderDetails.HeaderRow.Style.Add("width", "10%");
                GvSalesInvcDet.HeaderRow.Style.Add("font-size", "8px");
                GvSalesInvcDet.Style.Add("font-size", "8px");

                //for (int i = 0; i <= GvSalesInvcDet.Rows.Count - 1; i++)
                //{
                //    GvSalesInvcDet.Rows[i].Cells[1].Style.Add("Width", "1000px");
                //    //if (GvwSaleseOrderDetails.Rows[i].Cells[0].Text == "")
                //    //{
                //    //    GvwSaleseOrderDetails.Rows[i].BackColor = System.Drawing.Color.DarkRed;

                //    //}
                //}
                Panel1.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 120f, 130f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfWriter.PageEvent = new Comman.ITextSoEvent();
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                // Response.End();
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                Panel1.Visible = false;
            }
            else if (SalesType == "IGST-INTER  STATE")
            {
                LoadGridIGSTDetails();
                TblCgst.Visible = false;tblIGST.Visible = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=SalesTaxInvoice.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                // GvwSaleseOrderDetails.HeaderRow.Style.Add("width", "10%");
                GVSalesInvcDetIGST.HeaderRow.Style.Add("font-size", "8px");
                GVSalesInvcDetIGST.Style.Add("font-size", "8px");

                //for (int i = 0; i <= GvSalesInvcDet.Rows.Count - 1; i++)
                //{
                //    GvSalesInvcDet.Rows[i].Cells[1].Style.Add("Width", "1000px");
                //    //if (GvwSaleseOrderDetails.Rows[i].Cells[0].Text == "")
                //    //{
                //    //    GvwSaleseOrderDetails.Rows[i].BackColor = System.Drawing.Color.DarkRed;

                //    //}
                //}
                Panel1.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 120f, 130f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfWriter.PageEvent = new Comman.ITextSoEvent();
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                // Response.End();
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                Panel1.Visible = false;


            }
                LoadSoNumber();
        }
        else
        {
            Panel1.Visible = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select SO Number.');</script>", false);
        }

    }
    private void LoadGridDetails()
    {
        DataTable DtDetails = new DataTable();
        try
        {
            DtDetails = ClsMaster.GetSalesInvoiceDetailsForPDF(value);
            int count = DtDetails.Rows.Count;
            double total = Convert.ToDouble(DtDetails.Rows[count - 1]["SO_TotalAmount"].ToString());
            lblTotalinrs.Text = lblTotalinrs.Text + AmountInWords(Convert.ToDecimal(total));
            GvSalesInvcDet.DataSource = DtDetails;
            GvSalesInvcDet.DataBind();
            ViewState["Data"] = DtDetails;
            DtDetails.Dispose();
            //if (ViewState["PageINdex"] != null)
            //    GvSalesInvcDet.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
            //CreateTax();

        }
        catch (Exception ex)
        {
        }

    }

    private void LoadGridIGSTDetails()
    {
        DataTable DtDetails = new DataTable();
        try
        {
            DtDetails = ClsMaster.GetSalesInvoiceIGSTDetailsForPDF(value);
            int count = DtDetails.Rows.Count;
            double total = Convert.ToDouble(DtDetails.Rows[count - 1]["SO_TotalAmount"].ToString());
            lblTotalinrs1.Text = lblTotalinrs1.Text + AmountInWords(Convert.ToDecimal(total));
            GVSalesInvcDetIGST.DataSource = DtDetails;
            GVSalesInvcDetIGST.DataBind();
            ViewState["IGSTData"] = DtDetails;
            DtDetails.Dispose();
            //if (ViewState["PageINdex"] != null)
            //    GvSalesInvcDet.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
            //CreateTax();

        }
        catch (Exception ex)
        {
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

    public override void VerifyRenderingInServerForm(Control control)
    {
        
    }
    protected void grvMergeHeader_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = "S.No.";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Product Description";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "HSN code";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "UOM";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Qty";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Rate";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Amount";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Discount";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Taxable Value";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "CGST";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "SGST";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            //HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "Amount";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderGridRow.Cells.Add(HeaderCell);

            GvSalesInvcDet.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }

    protected void GvSalesInvcDet_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblProductDescr = (Label)e.Row.FindControl("LblProductDescr");
                if (LblProductDescr.Text == "Total")
                {
                    Label lblSno = (Label)e.Row.FindControl("lblSno");
                    lblSno.Text = "";
                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    Label lblTaxableValue = (Label)e.Row.FindControl("lblTaxableValue");
                    Label lblCGSTAmount = (Label)e.Row.FindControl("lblCGSTAmount");
                    Label lblSGSTAmount = (Label)e.Row.FindControl("lblSGSTAmount"); 
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");

                    lblAmountbeforeTax.Text = lblAmount.Text;
                    lblCGST.Text = lblCGSTAmount.Text;
                    lblSGST.Text = lblSGSTAmount.Text;
                    lblTotalTaxAmnt.Text = Convert.ToString(Convert.ToDecimal(lblCGSTAmount.Text) + Convert.ToDecimal(lblSGSTAmount.Text)); 
                    lblTotalAmntafterTax.Text = lblTotal.Text;

                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }

        ////// Invisibling the first three columns of second row header (normally created on binding)
        //if (e.Row.RowType == DataControlRowType.Header)
        //{
        //    e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
        //    e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
        //    e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
        //    e.Row.Cells[3].Visible = false;
        //    e.Row.Cells[4].Visible = false;
        //    e.Row.Cells[5].Visible = false;
        //    e.Row.Cells[6].Visible = false;
        //    e.Row.Cells[7].Visible = false;
        //    e.Row.Cells[8].Visible = false;
        //    //e.Row.Cells[9].Visible = false;
        //    //e.Row.Cells[12].Visible = false;
        //    e.Row.Cells[13].Visible = false;
        //}

        ////if (e.Row.RowType == DataControlRowType.Header)
        ////{

        ////    SortedList formatCells1 = new SortedList();
        ////    formatCells1.Add("9", "CGST, 9, 1");
        ////    //formatCells1.Add("11", "Number of Loan Files Audited(a),  " + i + ", 1");
        ////    //formatCells1.Add("12", "# of Loan Files having Exceptions(b),  " + i + ", 1");
        ////    //formatCells1.Add("13", "Out of (b) No of exceptions observed,  " + i + ", 1");

        ////    GetMultiRowHeader(e, formatCells1);         

        ////    e.Row.Cells[0].Text = "";
        ////    //e.Row.Cells[int.Parse((9).ToString())].Text = "";

        ////}

    }

    protected void GVSalesInvcDetIGST_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label LblProductDescr = (Label)e.Row.FindControl("LblProductDescr");
                if (LblProductDescr.Text == "Total")
                {
                    Label lblSno = (Label)e.Row.FindControl("lblSno");
                    lblSno.Text = "";
                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    Label lblTaxableValue = (Label)e.Row.FindControl("lblTaxableValue");
                    Label lblIGSTAmount = (Label)e.Row.FindControl("lblIGSTAmount");
                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");

                    Label10.Text = lblAmount.Text;
                    Label13.Text = lblIGSTAmount.Text;
                    Label16.Text = lblTotal.Text;

                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void GetMultiRowHeader(GridViewRowEventArgs e, SortedList GetCels)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = default(GridViewRow);
            IDictionaryEnumerator enumCels = GetCels.GetEnumerator();

            row = new GridViewRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

            while (enumCels.MoveNext())
            {
                string[] count = enumCels.Value.ToString().Split(Convert.ToChar(","));
                TableCell Cell = default(TableCell);
                Cell = new TableCell();
                Cell.RowSpan = Convert.ToInt16(count[2].ToString());
                Cell.ColumnSpan = Convert.ToInt16(count[1].ToString());
                Cell.Controls.Add(new LiteralControl(count[0].ToString()));
                Cell.HorizontalAlign = HorizontalAlign.Center;

                Cell.CssClass = "gridReportHeader";
                Cell.Font.Bold = true;
                row.Cells.Add(Cell);
            }

            e.Row.Parent.Controls.AddAt(0, row);
        }
    }

}