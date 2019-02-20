using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class InvoiceDispatch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            BindMainGrid();


        }

    }
    private void LoadddlDispatch()
    {

        try
        {
            DataTable DTDispatch = ClsSalesManagerChecking.Get_DispatchDEtails();
            ddlDispatchDetails.DataSource = DTDispatch;
            ddlDispatchDetails.DataTextField = "Dispatch_Type_Name";
            ddlDispatchDetails.DataValueField = "Dispatch_TypeID";
            ddlDispatchDetails.DataBind();
            ddlDispatchDetails.Items.Insert(0, new ListItem("--Select Dispatch Details--", "0"));


        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    private void LoadddlTransporter()
    {

        try
        {
            DataTable DTTr = ClsSalesManagerChecking.Get_Transporterdetails();
            ddlTransporter.DataSource = DTTr;
            ddlTransporter.DataTextField = "Transporter";
            ddlTransporter.DataValueField = "TID";
            ddlTransporter.DataBind();
            ddlTransporter.Items.Insert(0, new ListItem("--Select Transporter Details--", "0"));


        }
        catch (Exception ex)
        {
            throw ex;
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
            DateTime fromdate = Convert.ToDateTime(Txt_FromDate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(Txt_ToDate.Text.ToString());

            if (fromdate <= Todate)
            {
                BindMainGrid();
                Panel2.Visible = true;
                Panel1.Visible = false;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Todate Should be Greater than or equal to Fromdate');</script>", false);
            }


        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Date');</script>", false);

        }
    }
    private void BindMainGrid()
    {
        DataTable DT = new DataTable();
        try
        {
            DT = ClsSalesManagerChecking.Get_InvoiceDispatchSearch(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwMatDispatch.DataSource = DT;
            GvwMatDispatch.DataBind();

            if (DT.Rows.Count > 0)
            {
                lblmessage.Text = "";

            }
            else
            {
                lblmessage.Text = "No Records Found...";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('No Records Found...');</script>", false);


            }
            ViewState["Data"] = DT;
            DT.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwMatDispatch.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }
    private DataTable fillDataTable(DataTable dt)
    {
        return dt;
    }
    private void SoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsSalesManagerChecking.Get_SoDetailsFor_MaterialDispatch(id);
        GvwSaleseOrderDetails.DataSource = ds;
        GvwSaleseOrderDetails.DataBind();

    }
    protected void GvwMatDispatch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                Panel2.Visible = false;
                Panel1.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwMatDispatch.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                Label lblhidennInvcID = (Label)row.FindControl("hidennInvcID");

                string InvcId = lblhidennInvcID.Text;

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("SO_ID='" + ID + "' AND Invoice_Id='" + InvcId + "'");


                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();

                    TxtVertical.Text = dtNew.Rows[0]["Vertical"].ToString();
                    txtSOID.Text = dtNew.Rows[0]["SO_ID"].ToString();
                    int DcID = Convert.ToInt32(dtNew.Rows[0]["Id"].ToString());
                    Session["DCID"] = DcID;
                    TxtSODate.Text = dtNew.Rows[0]["SoDate"].ToString();
                    txtState.Text = dtNew.Rows[0]["State"].ToString();
                    TxtLocation.Text = dtNew.Rows[0]["Location"].ToString();
                    txtsalesType.Text = dtNew.Rows[0]["SalesType"].ToString();
                    TxtCustomer.Text = dtNew.Rows[0]["Customer"].ToString();
                    TxtCustmerOrderno.Text = dtNew.Rows[0]["CusutomerOrderNO"].ToString();
                    TxtCustmerOrderdate.Text = dtNew.Rows[0]["CusutomerOrderdate"].ToString();
                    txtCreditPeriod.Text = dtNew.Rows[0]["CreditPeriod"].ToString();
                    txtWarranty.Text = dtNew.Rows[0]["Warranty"].ToString();
                    txtRepresentative.Text = dtNew.Rows[0]["Representative"].ToString();
                    txttype.Text = dtNew.Rows[0]["MainCategoryType"].ToString();
                    double SubTotalamnt = Convert.ToDouble(dtNew.Rows[0]["SO_NetAmount"].ToString());
                    Lbl_TotalAmount.Text = SubTotalamnt.ToString("0.00");
                    //Lbl_TotalAmount.Text = Math.Floor(SubTotalamnt + 0.49).ToString("0.00");
                    // Lbl_TotalAmount.Text = dtNew.Rows[0]["SO_NetAmount"].ToString();
                    TxtShippingAddress.Text = dtNew.Rows[0]["ShippingAddress"].ToString();
                    TxtBillingAddress.Text = dtNew.Rows[0]["BillingAddress"].ToString();
                    txtDCNo.Text = dtNew.Rows[0]["DC_no"].ToString();
                    txtDCDate.Text = dtNew.Rows[0]["DC_Date"].ToString();
                    txtInvNo.Text = dtNew.Rows[0]["Invoice_Number"].ToString();
                    txtInvDate.Text = dtNew.Rows[0]["InvocieDate"].ToString();
                    LoadddlDispatch();
                    if (dtNew.Rows[0]["DispatchID"].ToString() != null && dtNew.Rows[0]["DispatchID"].ToString() != string.Empty)
                    {
                        ddlDispatchDetails.SelectedValue = dtNew.Rows[0]["DispatchID"].ToString();
                        if (ddlDispatchDetails.SelectedItem.ToString() != "HD")
                        {
                            td1.Visible = td2.Visible = true;
                            // TRTransporter.Visible = true;
                            LoadddlTransporter();
                            ddlTransporter.SelectedValue = dtNew.Rows[0]["TransaporterID"].ToString();
                        }
                        else
                        {
                            ddlTransporter.Items.Clear();
                            td1.Visible = td2.Visible = false;
                            // TRTransporter.Visible = false;
                        }
                    }
                    //else {
                    //    //td1.Visible = td2.Visible = false;
                    //    // TRTransporter.Visible = false;
                    //   // Clear();
                    //}

                    if(dtNew.Rows[0]["AWBNumber"].ToString() != null && dtNew.Rows[0]["AWBNumber"].ToString() != "")
                    {
                        txtAWBNo.Text= dtNew.Rows[0]["AWBNumber"].ToString();
                    }
                    else
                    {
                        txtAWBNo.Text = "";
                    }
                    if (dtNew.Rows[0]["DispatchDate"].ToString() != null && dtNew.Rows[0]["DispatchDate"].ToString() != "")
                    {
                        Txt_Dispatch_Date.Text = GetDefaultStartDate(Convert.ToDateTime(dtNew.Rows[0]["DispatchDate"].ToString()));
                    }
                    else
                    {
                        Txt_Dispatch_Date.Text = "";
                    }
                    if (dtNew.Rows[0]["DelieveryDate"].ToString() != null && dtNew.Rows[0]["DelieveryDate"].ToString() !="")
                    {
                        Txt_DateOfDelivery.Text = GetDefaultStartDate(Convert.ToDateTime(dtNew.Rows[0]["DelieveryDate"].ToString()));
                    }
                    else
                    {
                        Txt_DateOfDelivery.Text = "";
                    }
                    if (dtNew.Rows[0]["InstallationDate"].ToString() != null && dtNew.Rows[0]["InstallationDate"].ToString() !="")
                    {
                        txtdateofinst.Text = GetDefaultStartDate(Convert.ToDateTime(dtNew.Rows[0]["InstallationDate"].ToString()));
                    }
                    else
                    {
                        txtdateofinst.Text = "";
                    }

                }


                SoDetails(Convert.ToInt64(InvcId));
                BindMainGrid();

            }
            ViewState["PageINdex"] = GvwMatDispatch.PageIndex;

        }
        catch (Exception ex)
        {



        }
    }
    protected void GvwMatDispatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwMatDispatch.PageIndex = e.NewPageIndex;
        BindMainGrid();
    }

    protected void GvwSaleseOrderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSaleseOrderDetails.PageIndex = e.NewPageIndex;
        SoDetails(Convert.ToInt64(ID));
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        int Int_transporter;
        if (ddlTransporter.Text != "")
        { Int_transporter = Convert.ToInt32(ddlTransporter.SelectedValue); }
        else
        { Int_transporter = 0; }

        DateTime? DateOfDelivery;
        if (Txt_DateOfDelivery.Text.Trim() == string.Empty)
        {
            DateOfDelivery = null;
        }
        else
        {
            DateOfDelivery = Convert.ToDateTime(Txt_DateOfDelivery.Text.Trim());
        }

        DateTime? DateofInst;
        if (txtdateofinst.Text.Trim() == string.Empty)
        {
            DateofInst = null;
        }
        else
        {
            DateofInst = Convert.ToDateTime(txtdateofinst.Text.Trim());
        }

        bool result = ClsSalesManagerChecking.InsertINVDispatchDetails(Convert.ToInt32(ddlDispatchDetails.SelectedValue), Convert.ToDateTime(Txt_Dispatch_Date.Text.Trim()),
            txtAWBNo.Text.Trim(), DateOfDelivery, DateofInst, Int_transporter, Convert.ToInt32(Session["Id"]), Convert.ToInt32(txtSOID.Text), Convert.ToInt32(Session["DCID"]));
        if (result)
        {
            Clear();
            BindMainGrid();
            Panel2.Visible = true;
            Panel1.Visible = false;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);

        }

        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
        }



    }

    private void Clear()
    {
        ddlDispatchDetails.SelectedIndex = 0;
        // ddlTransporter.SelectedIndex = 0;
        txtAWBNo.Text = "";
        Txt_Dispatch_Date.Text = "";
        Txt_DateOfDelivery.Text = "";
        txtdateofinst.Text = "";

    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            Clear();
            BindMainGrid();


        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void ddlDispatchDetails_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDispatchDetails.SelectedItem.ToString() != "HD")
        {
            td1.Visible = td2.Visible = true;
            // TRTransporter.Visible = true;
            LoadddlTransporter();
        }
        else
        {
            ddlTransporter.Items.Clear();
            td1.Visible = td2.Visible = false;
            // TRTransporter.Visible = false;
        }
    }

    protected void GvwSaleseOrderDetails_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            double SubTotalamnt = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label LbltotalAmount = (Label)e.Row.FindControl("LbltotalAmount");
                SubTotalamnt += Convert.ToDouble(LbltotalAmount.Text);
                //Lbl_TotalAmount.Text = Math.Floor(SubTotalamnt + 0.49).ToString("0.00");
                Lbl_TotalAmount.Text = SubTotalamnt.ToString("0.00");
            }
        }
        catch (Exception ex)
        {

        }
    }
}
