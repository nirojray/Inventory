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



public partial class SalesTaxInvoice : System.Web.UI.Page
{
    int value;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSoNumber();
             Panel1.Visible = false;            
        }
    }
    private void LoadSoNumber()
    {
        try
        {
            DataTable dt = ClsMaster.GetSONumberApproved();
            ddlSONumber.DataSource = dt;
            ddlSONumber.DataTextField = "SO_Number";
            ddlSONumber.DataValueField = "SO_ID";
            ddlSONumber.DataBind();
            ddlSONumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select SO NO--", "0"));


        }
        catch (Exception Ex)
        {

        }
    }
    private void LoadGridDetails()
    {
        DataTable DtDetails = new DataTable();
        try
        {
            DtDetails = ClsMaster.Get_Salesdetails(value);
            int count = DtDetails.Rows.Count;
            double total = Convert.ToDouble(DtDetails.Rows[count - 1]["SO_TotalPrice"].ToString());
            lblTotalinrs.Text = lblTotalinrs.Text + AmountInWords(Convert.ToDecimal(total));
            GvwSaleseOrderDetails.DataSource = DtDetails;
            GvwSaleseOrderDetails.DataBind();
            ViewState["Data"] = DtDetails;
            DtDetails.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSaleseOrderDetails.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
            //CreateTax();

        }
        catch (Exception ex)
        {
        }

    }
    //private void LoadTax()
    //{
    //    DataTable DtTaxDetails = new DataTable();
    //    try
    //    {
    //        DtTaxDetails = ClsMaster.Get_SalesTaxdetails(value);
    //        TableRow objTableRow = new TableRow();
    //        TableCell objTableCell = new TableCell();
    //        if(DtTaxDetails.Rows.Count>0)
    //        {
    //            //Code TO Add Datas in Table
    //            for (int iRow = 0; iRow < DtTaxDetails.Rows.Count; iRow++)
    //            {
    //                objTableRow = new TableRow();
    //                for (int iColumn = 0; iColumn < DtTaxDetails.Columns.Count; iColumn++)
    //                {
    //                    objTableCell = new TableCell();
    //                    objTableCell.Text = DtTaxDetails.Rows[iRow][iColumn].ToString();
    //                  //  objTableCell.Width = Unit.Pixel(120);
    //                    objTableCell.Wrap = false;
    //                    objTableCell.HorizontalAlign = HorizontalAlign.Right;
    //                    objTableRow.Cells.Add(objTableCell);
    //                }
    //                BooksTable.Rows.Add(objTableRow);
    //            }
    //        }
    //        //Code to Create HtmlPage for the Report
    //        StringWriter sw = new StringWriter();
    //        HtmlTextWriter htw = new HtmlTextWriter(sw);
    //        StringBuilder strData = new StringBuilder(string.Empty);
    //        StringBuilder strFunction = new StringBuilder(string.Empty);
    //        string strHTMLpath = HttpContext.Current.Server.MapPath("HtmlFile/PrintPage.htm");
    //        BooksTable.RenderControl(htw);
    //        StreamWriter strWriter = new StreamWriter(strHTMLpath, false, Encoding.Default);
    //        strData.Append("<html><body>");
    //        strData.Append(htw.InnerWriter.ToString());
    //        strData.Append("</body></html>");
    //        strWriter.Write(strData.ToString());
    //        strWriter.Close();
    //        strWriter.Dispose();


    //    }
    //    catch (Exception ex)
    //    {
    //    }
    //}
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        TabScanner.Visible = false;
        TabService.Visible = false;
        TabSupport.Visible = false;
        value = Convert.ToInt32(ddlSONumber.SelectedValue.ToString());
        if (value != 0)
        {
            DataTable dt = ClsMaster.Get_SalesSummary(value);           

            if (dt.Rows[0]["M_ShortName"].ToString() == "SCN" || dt.Rows[0]["M_ShortName"].ToString() == "CON" || dt.Rows[0]["M_ShortName"].ToString() == "SOF" || dt.Rows[0]["M_ShortName"].ToString() == "RN")
            {
                TabScanner.Visible = true;
                lblInvoiceNo.Text = dt.Rows[0]["Invoice_Number"].ToString();
                lblCustomerNo.Text = dt.Rows[0]["CusutomerOrderNO"].ToString();
                lblInvoiceDate.Text = dt.Rows[0]["InvocieDate"].ToString();
                lblCustomerdate.Text = dt.Rows[0]["CusutomerOrderdate"].ToString();
                lblDCno.Text = dt.Rows[0]["DC_no"].ToString();
                lblDCDate.Text = dt.Rows[0]["DC_Date"].ToString();
                lblCreditPrediod.Text = dt.Rows[0]["CreditPeriod"].ToString();                
                lblWarranty.Text = dt.Rows[0]["Warranty"].ToString();
                lblCustVAT.Text = dt.Rows[0]["VATCST"].ToString();
                lblCustPan.Text = dt.Rows[0]["PAN"].ToString();
                lblCustSerTax.Text = dt.Rows[0]["ServiceTaxNumber"].ToString();
            }
            else
                if (dt.Rows[0]["M_ShortName"].ToString() == "SER")
            {
                TabService.Visible = true;
                lblSerInvoiceNo.Text = dt.Rows[0]["Invoice_Number"].ToString();
                lblSerCustomerNo.Text = dt.Rows[0]["CusutomerOrderNO"].ToString();
                lblSerInvoiceDate.Text = dt.Rows[0]["InvocieDate"].ToString();
                lblSerContractDate.Text = dt.Rows[0]["CusutomerOrderdate"].ToString();
                lblSerCreditPeriod.Text = dt.Rows[0]["CreditPeriod"].ToString();
                lblSerCustVAT.Text = dt.Rows[0]["VATCST"].ToString();
                lblSerCustPAN.Text = dt.Rows[0]["PAN"].ToString();
                lblSerCustSerTax.Text = dt.Rows[0]["ServiceTaxNumber"].ToString();
            }
            else
                if (dt.Rows[0]["M_ShortName"].ToString() == "SUP")
            {
                TabSupport.Visible = true;
                lblSupInvocieNO.Text = dt.Rows[0]["Invoice_Number"].ToString();
                lblSupCustomerNo.Text = dt.Rows[0]["CusutomerOrderNO"].ToString();
                lblSupInvoicedate.Text = dt.Rows[0]["InvocieDate"].ToString();
                lblSupContractDate.Text = dt.Rows[0]["CusutomerOrderdate"].ToString();
                lblSupCreditPeriod.Text = dt.Rows[0]["CreditPeriod"].ToString();
                lblSupWarranty.Text = dt.Rows[0]["Warranty"].ToString();
                lblSupVAT.Text = dt.Rows[0]["VATCST"].ToString();
                lblSupPAN.Text = dt.Rows[0]["PAN"].ToString();
                lblSupSerTax.Text = dt.Rows[0]["ServiceTaxNumber"].ToString();

            }
            
            lbl_Ship_Address.Text = dt.Rows[0]["ShippingAddress"].ToString();
            lbl_Bill_Address.Text = dt.Rows[0]["BillingAddress"].ToString();

            LoadGridDetails();
            // LoadTax();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=SalesTaxInvoice.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

           // GvwSaleseOrderDetails.HeaderRow.Style.Add("width", "10%");
            GvwSaleseOrderDetails.HeaderRow.Style.Add("font-size", "10px");
            GvwSaleseOrderDetails.Style.Add("font-size", "8px");

            //for (int i = 0; i <= GvwSaleseOrderDetails.Rows.Count - 1; i++)
            //{
            //    if (GvwSaleseOrderDetails.Rows[i].Cells[0].Text == "")
            //    {
            //        GvwSaleseOrderDetails.Rows[i].BackColor = System.Drawing.Color.DarkRed;

            //    }
            //}
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
            LoadSoNumber();
        }
        else
        {
            Panel1.Visible = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select SO Number.');</script>", false);

        }
        //ddlPonumber.SelectedItem.Value = "-1";
    }

    //private void GetSalesManagerAMC()
    //{
    //    DataTable ds = new DataTable();
    //    try
    //    {
    //        ds = ClsPurchaseInvoice.Get_PurchaseOrderForInvoice(value);
    //        GridView1.DataSource = ds;
    //        GridView1.DataBind();
    //        ViewState["Data"] = ds;
    //        ds.Dispose();
    //        if (ViewState["PageINdex"] != null)
    //            GridView1.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }

    protected void GvwSaleseOrderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSlno = (Label)e.Row.FindControl("lblSlno");
               
                Label LblQuantity = (Label)e.Row.FindControl("LblQuantity");
                Label LblAmount = (Label)e.Row.FindControl("LblAmount");
                if (lblSlno.Text == "0")
                {
                    lblSlno.Text = "";
                    e.Row.BackColor = System.Drawing.Color.Cyan;                  
                    //LblQuantity.Font.Size = FontUnit.Medium;
                    //LblAmount.Font.Size = FontUnit.Medium;
                }
                            
            }

        }
        catch (Exception ex)
        {
        }
    }

    #region Seeta code Converting the Amount in text

    //public String changeNumericToWords(double numb)
    //{
    //    String num = numb.ToString();
    //    return changeToWords(num, false);
    //}
    //public String changeCurrencyToWords(String numb)
    //{
    //    return changeToWords(numb, true);
    //}
    //public String changeNumericToWords(String numb)
    //{
    //    return changeToWords(numb, false);
    //}
    //public String changeCurrencyToWords(double numb)
    //{
    //    return changeToWords(numb.ToString(), true);
    //}
    //private String changeToWords(String numb, bool isCurrency)
    //{
    //    String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
    //    String endStr = (isCurrency) ? ("Only") : ("");
    //    try
    //    {
    //        int decimalPlace = numb.IndexOf(".");
    //        if (decimalPlace > 0)
    //        {
    //            wholeNo = numb.Substring(0, decimalPlace);
    //            points = numb.Substring(decimalPlace + 1);
    //            if (Convert.ToInt32(points) > 0)
    //            {
    //                andStr = (isCurrency) ? ("and") : ("point");// just to separate whole numbers from points/cents
    //                endStr = (isCurrency) ? ("Cents " + endStr) : ("");
    //                pointStr = translateCents(points);
    //            }
    //        }
    //        val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
    //    }
    //    catch {; }
    //    return val;
    //}
    //private String translateWholeNumber(String number)
    //{
    //    string word = "";
    //    try
    //    {
    //        bool beginsZero = false;//tests for 0XX
    //        bool isDone = false;//test if already translated
    //        double dblAmt = (Convert.ToDouble(number));
    //        //if ((dblAmt > 0) && number.StartsWith("0"))
    //        if (dblAmt > 0)
    //        {//test for zero or digit zero in a nuemric
    //            beginsZero = number.StartsWith("0");
    //            int numDigits = number.Length;
    //            int pos = 0;//store digit grouping
    //            String place = "";//digit grouping name:hundres,thousand,etc...
    //            switch (numDigits)
    //            {
    //                case 1://ones' range
    //                    word = ones(number);
    //                    isDone = true;
    //                    break;
    //                case 2://tens' range
    //                    word = tens(number);
    //                    isDone = true;
    //                    break;
    //                case 3://hundreds' range
    //                    pos = (numDigits % 3) + 1;
    //                    place = " Hundred ";
    //                    break;
    //                case 4://thousands' range
    //                case 5:
    //                case 6:
    //                    pos = (numDigits % 4) + 1;
    //                    place = " Thousand ";
    //                    break;
    //                case 7://millions' range
    //                case 8:
    //                case 9:
    //                    pos = (numDigits % 7) + 1;
    //                    place = " Million ";
    //                    break;
    //                case 10://Billions's range
    //                    pos = (numDigits % 10) + 1;
    //                    place = " Billion ";
    //                    break;
    //                //add extra case options for anything above Billion...
    //                default:
    //                    isDone = true;
    //                    break;
    //            }
    //            if (!isDone)
    //            {//if transalation is not done, continue...(Recursion comes in now!!)
    //                word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));
    //                //check for trailing zeros
    //                if (beginsZero) word = " and " + word.Trim();
    //            }
    //            //ignore digit grouping names
    //            if (word.Trim().Equals(place.Trim())) word = "";
    //        }
    //    }
    //    catch {; }
    //    return word.Trim();
    //}
    //private String tens(String digit)
    //{
    //    int digt = Convert.ToInt32(digit);
    //    String name = null;
    //    switch (digt)
    //    {
    //        case 10:
    //            name = "Ten";
    //            break;
    //        case 11:
    //            name = "Eleven";
    //            break;
    //        case 12:
    //            name = "Twelve";
    //            break;
    //        case 13:
    //            name = "Thirteen";
    //            break;
    //        case 14:
    //            name = "Fourteen";
    //            break;
    //        case 15:
    //            name = "Fifteen";
    //            break;
    //        case 16:
    //            name = "Sixteen";
    //            break;
    //        case 17:
    //            name = "Seventeen";
    //            break;
    //        case 18:
    //            name = "Eighteen";
    //            break;
    //        case 19:
    //            name = "Nineteen";
    //            break;
    //        case 20:
    //            name = "Twenty";
    //            break;
    //        case 30:
    //            name = "Thirty";
    //            break;
    //        case 40:
    //            name = "Fourty";
    //            break;
    //        case 50:
    //            name = "Fifty";
    //            break;
    //        case 60:
    //            name = "Sixty";
    //            break;
    //        case 70:
    //            name = "Seventy";
    //            break;
    //        case 80:
    //            name = "Eighty";
    //            break;
    //        case 90:
    //            name = "Ninety";
    //            break;
    //        default:
    //            if (digt > 0)
    //            {
    //                name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));
    //            }
    //            break;
    //    }
    //    return name;
    //}
    //private String ones(String digit)
    //{
    //    int digt = Convert.ToInt32(digit);
    //    String name = "";
    //    switch (digt)
    //    {
    //        case 1:
    //            name = "One";
    //            break;
    //        case 2:
    //            name = "Two";
    //            break;
    //        case 3:
    //            name = "Three";
    //            break;
    //        case 4:
    //            name = "Four";
    //            break;
    //        case 5:
    //            name = "Five";
    //            break;
    //        case 6:
    //            name = "Six";
    //            break;
    //        case 7:
    //            name = "Seven";
    //            break;
    //        case 8:
    //            name = "Eight";
    //            break;
    //        case 9:
    //            name = "Nine";
    //            break;
    //    }
    //    return name;
    //}
    //private String translateCents(String cents)
    //{
    //    String cts = "", digit = "", engOne = "";
    //    for (int i = 0; i < cents.Length; i++)
    //    {
    //        digit = cents[i].ToString();
    //        if (digit.Equals("0"))
    //        {
    //            engOne = "Zero";
    //        }
    //        else
    //        {
    //            engOne = ones(digit);
    //        }
    //        cts += " " + engOne;
    //    }
    //    return cts;
    //}

    #endregion

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
    protected void GvwSaleseOrderDetails_DataBound(object sender, EventArgs e)
    {
        for (int i = 0; i < GvwSaleseOrderDetails.Rows.Count; i++)
        {
            Label lblSlno = (Label)GvwSaleseOrderDetails.Rows[i].FindControl("lblSlno");
            Label LblProduct = (Label)GvwSaleseOrderDetails.Rows[i].FindControl("LblProduct");
            Label LblProductCode = (Label)GvwSaleseOrderDetails.Rows[i].FindControl("LblProductCode");
            Label LblPrice = (Label)GvwSaleseOrderDetails.Rows[i].FindControl("LblPrice");
            Label lblTypeId = (Label)GvwSaleseOrderDetails.Rows[i].FindControl("lblTypeId");
            
            if (lblSlno.Text == "" && LblProduct.Text == "" && LblProductCode.Text == "" && LblPrice.Text == "")
            {                
                GvwSaleseOrderDetails.Rows[i].Cells[0].ColumnSpan = 4;
                GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);
                GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);
                GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);

            }
            //if(lblTypeId.Text!="4")
            //{
            //    GvwSaleseOrderDetails.Rows[i].Cells[2].Visible = true;
            //    GvwSaleseOrderDetails.Rows[i].Cells[0].ColumnSpan = 4;
            //    GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);
            //    GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);
            //    GvwSaleseOrderDetails.Rows[i].Cells.RemoveAt(1);
            //}

        }
    }
}
