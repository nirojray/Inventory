using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class SalesRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-155));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
        }
    }
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsSalesRegister.Get_SalesOrderForSaleRegister(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwSalesRegister.DataSource = ds;
            GvwSalesRegister.DataBind();
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSalesRegister.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }
    private string GetCurrentMonth(int Month)
    {
        string month = null;
        switch (Month)
        {
            case 1:
                month = "Jan";
                break;
            case 2:
                month = "Feb";
                break;
            case 3:
                month = "Mar";
                break;
            case 4:
                month = "Apr";
                break;
            case 5:
                month = "May";
                break;
            case 6:
                month = "Jun";
                break;
            case 7:
                month = "Jul";
                break;
            case 8:
                month = "Aug";
                break;
            case 9:
                month = "Sep";
                break;
            case 10:
                month = "Oct";
                break;
            case 11:
                month = "Nov";
                break;
            case 12:
                month = "Dec";
                break;
        }
        return month;


    }
    private string GetDefaultStartDate(DateTime date)
    {
        return (date.Day + "-" + GetCurrentMonth(date.Month) + "-" + date.Year);
    }
    private string GetDefaultEndDate()
    {
        return (DateTime.Now.Day.ToString() + "-" + GetCurrentMonth(DateTime.Now.Month) + "-" + DateTime.Now.Year.ToString());
    }
    private string Dateformat(string date)
    {
        string[] myDate = null;
        myDate = date.Split(' ');
        return (myDate[0] + "-" + myDate[1] + "-" + myDate[2]);
    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (Txt_FromDate.Text != string.Empty && Txt_ToDate.Text != string.Empty)
        {
            GetSalesManager();
        }
        else
        {


        }
    }
    protected void GvwSalesRegister_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesRegister.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("SO_ID='" + ID + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();


                    TxtSODate.Text = dtNew.Rows[0]["SoDate"].ToString();
                    TxtSoNo.Text = dtNew.Rows[0]["SO_Number"].ToString();
                   
                }


                SoDetails(Convert.ToInt64(ID));
                GetSalesManager();

                ViewState["PageINdex"] = GvwSalesRegister.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
    private void SoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsSalesRegister.Get_SalesOrderforApproval(id);
        GvwSaleseOrderDetails.DataSource = ds;
        GvwSaleseOrderDetails.DataBind();

    }
   
    protected void BtnInvoiceSave_Click(object sender, EventArgs e)
    {
        //if (Txt_InvoiceNo.Text.Trim() != string.Empty)
        //{
        //    if (!string.IsNullOrEmpty(hidDetails_ID.Value))
        //    {

        //        string asd = hidDetails_ID.Value;
        //        bool result = ClsSalesRegister.InsertSrInvoiceDate(Convert.ToInt32(asd), Convert.ToDateTime(Txt_InvoiceDate.Text.Trim()),Txt_InvoiceNo.Text.Trim(), Convert.ToInt32(Session["Id"]));
        //        if (result)
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);
        //            Txt_InvoiceDate.Text = "";
        //            Txt_InvoiceNo.Text = "";

        //        }



        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
        //        }
        //    }
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Not Selected...');</script>", false);
        //}
    }
}