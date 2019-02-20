using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using HelperClass;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class ReportStockStatement : System.Web.UI.Page
{
    ClsStockTransfer objST = new ClsStockTransfer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Id"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                TxtFromDate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                txtTodate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
                bindLocation();
            }

        }


    }
    //Binding all locations into  location dropdown
    public void bindLocation()
    {
        try
        {
            DataTable dt = objST.Get_AllLocationsforST();
            //Bidnging Location
            ddlLocation.Items.Clear();
            ddlLocation.DataSource = dt;
            ddlLocation.DataTextField = "Location_Name";
            ddlLocation.DataValueField = "Location_ID";
            ddlLocation.DataBind();
            ddlLocation.Items.Insert(0, new ListItem("--ALL--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void downloadExcelSheet(DataTable dt, string ExcelName)
    {
        string P = Server.MapPath(".") + "\\Documents\\Reports\\" + ExcelName + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + ".xls";
        FileInfo FI = new FileInfo(P);
        StringWriter stringWriter = new StringWriter();
        HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
        DataGrid DataGrd = new DataGrid();
        DataGrd.DataSource = dt;
        DataGrd.DataBind();

        DataGrd.RenderControl(htmlWrite);
        string directory = P.Substring(0, P.LastIndexOf("\\"));
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        System.IO.StreamWriter vw = new System.IO.StreamWriter(P, true);
        stringWriter.ToString().Normalize();
        vw.Write(stringWriter.ToString());
        vw.Flush();
        vw.Close();
        writeAttachment(FI.Name, "application/vnd.ms-excel", stringWriter.ToString());
    }
    private void writeAttachment(string FileName, string FileType, string content)
    {
        HttpResponse Response = System.Web.HttpContext.Current.Response;
        Response.ClearHeaders();
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + FileName);
        Response.ContentType = FileType;
        Response.Write(content);
        Response.End();
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {        
    
        if (TxtFromDate.Text != string.Empty)
        {
            DateTime FromDate = Convert.ToDateTime(TxtFromDate.Text.ToString());

            DateTime ToDate = Convert.ToDateTime(txtTodate.Text.ToString());
            //if (fromdate.Date < DateTime.Today)
            //{
            DataSet ds = new DataSet();

            DataTable dt_values = ClsReportStock.Report_Stock(FromDate, ToDate,ddlLocation.SelectedItem.ToString());

            if (dt_values.Rows.Count > 1)
            {
                //  downloadExcelSheet(dt_values, "Stock Statement");
                ds.Tables.Add(dt_values);

                ds.Tables[0].TableName = "Daily Stock Details";


                ExcelHelper.ToExcel(ds, "DailyStockDetails.xls", Page.Response);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);
            }
               
            //}
            //else
            //{
            //    AlertPageHelper.ShowAlert(this.Page, "Please select the correct date,Date should be less than today's date");
            //}
            
        }
        
        else
        {
            AlertPageHelper.ShowAlert(this.Page, "Please select the date");
        }

           
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        return;
    }
    protected void Gvw_STock_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell Cell_Header = new TableCell();
            Cell_Header.Text = "Slno";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1; Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Product Name";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Product Code";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1; Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Date as on";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 1;
            Cell_Header.RowSpan = 2;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Openning Balance";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 5; 
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Purchase";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 5;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Sales";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 5;
            HeaderRow.Cells.Add(Cell_Header);

            Cell_Header = new TableCell();
            Cell_Header.Text = "Closing Balance";
            Cell_Header.HorizontalAlign = HorizontalAlign.Center;
            Cell_Header.ColumnSpan = 5;
            HeaderRow.Cells.Add(Cell_Header);
            Gvw_STock.Controls[0].Controls.AddAt(0, HeaderRow);

        }
    }
    protected void Gvw_STock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false; 
            e.Row.Cells[3].Visible = false;
        }
    }
}