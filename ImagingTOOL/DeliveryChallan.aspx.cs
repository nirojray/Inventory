using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
using System.Data.SqlTypes;

public partial class DeliveryChallan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!IsPostBack)
        {
            Panel1.Visible = Panel1.Enabled = false;
            BtnUpdate.Visible = false;
            BtnSave.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            GetSalesManager(); 
            GetMasterList("DD", DrpDispatchDetails);
            GetMasterList("TRN", DrpTransporter);
          
        }
    }

  
    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();

        }
        catch (Exception Ex)
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
    private void GetSalesManager()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = ClsDeliveryChallan.Get_SalesOrderForDC(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwSalesManagerChecking.DataSource = ds;
            GvwSalesManagerChecking.DataBind();
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSalesManagerChecking.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }
    private void SoDeliveryChallanDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsDeliveryChallan.Get_DCDetails(id);
        GvwDCDetails.DataSource = ds;
        GvwDCDetails.DataBind();

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (Txt_FromDate.Text != string.Empty && Txt_ToDate.Text != string.Empty)
        {
            DateTime fromdate = Convert.ToDateTime(Txt_FromDate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(Txt_ToDate.Text.ToString());

            if (fromdate <= Todate)
            {
                GetSalesManager();
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
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Txt_DC_Date.Text != string.Empty)
        {
            if (!string.IsNullOrEmpty(hidDetails_ID.Value))
            {
                System.Data.SqlTypes.SqlDateTime Dispatch;
                System.Data.SqlTypes.SqlDateTime DateofDel;
                System.Data.SqlTypes.SqlDateTime DateofInst;

  
              
                string asd = hidDetails_ID.Value;

                string Dispatchdate = Txt_Dispatch_Date.Text.Trim();
                if (Dispatchdate == "")
                    Dispatch = SqlDateTime.Null;
                else
                    Dispatch = Convert.ToDateTime(Txt_Dispatch_Date.Text);

                string DateOfDelivery = Txt_DateOfDelivery.Text.Trim();
                if (DateOfDelivery == "")
                    DateofDel = SqlDateTime.Null;
                else
                    DateofDel = Convert.ToDateTime(Txt_DateOfDelivery.Text);

                string DateOfInstallation =Txt_DateOf_Installation.Text.Trim();
                if (DateOfInstallation == "")
                    DateofInst = SqlDateTime.Null;
                else
                    DateofInst = Convert.ToDateTime(Txt_DateOf_Installation.Text);

                bool result = ClsDeliveryChallan.Insert_DC_Details(Convert.ToInt32(asd), Txt_DC_NO.Text.Trim(), Convert.ToDateTime(Txt_DC_Date.Text.Trim()), Convert.ToInt32( DrpTransporter.SelectedItem.Value.ToString()), Convert.ToInt32(DrpDispatchDetails.SelectedItem.Value.ToString()), Dispatch, DateofDel, DateofInst, Convert.ToInt32(Session["Id"]));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);

                    Txt_DC_Date.Text = "";
                    DrpTransporter.SelectedItem.Value = "-1";
                    DrpDispatchDetails.SelectedItem.Value = "-1";
                    Txt_Dispatch_Date.Text = "";
                    Txt_DateOf_Installation.Text = "";
                    Txt_DC_NO.Text = "";
                    Txt_DateOfDelivery.Text = "";

                    Panel1.Visible = Panel1.Enabled = false;
                    
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
                }
                
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select the Deleivery challan Date...');</script>", false);
        }
    }
    protected void GvwSalesManagerChecking_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit1")
            {
                BtnUpdate.Visible = false;
                Panel1.Visible = Panel1.Enabled = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesManagerChecking.Rows[index];
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

                    TxtSoNo.Text = dtNew.Rows[0]["SO_Number"].ToString();
                    TxtCustomerOrderNo.Text = dtNew.Rows[0]["SO_CusutomerOrderNO"].ToString();
                    TxtCustomerOrderdate.Text = dtNew.Rows[0]["SO_CusutomerOrderdate"].ToString();
                   
                }


                SoDeliveryChallanDetails(Convert.ToInt64(ID));
                GetSalesManager();
                Txt_DC_Date.Text = "";
                DrpTransporter.SelectedValue = "-1";
                DrpDispatchDetails.SelectedValue = "-1";
                Txt_Dispatch_Date.Text = "";
                Txt_DateOf_Installation.Text = "";
                Txt_DC_NO.Text = "";
                Txt_DateOfDelivery.Text = "";

              
                ViewState["PageINdex"] = GvwSalesManagerChecking.PageIndex;
            }
        }
        catch (Exception ex)
        { }

    }
    protected void GvwSalesManagerChecking_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwSalesManagerChecking.PageIndex = e.NewPageIndex;
        GetSalesManager();
    }
    protected void GvwDCDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwDCDetails.PageIndex = e.NewPageIndex;
        SoDeliveryChallanDetails(Convert.ToInt64(ID));
    }
    protected void GvwDCDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edit2")
            {
                BtnUpdate.Visible = true;
                BtnSave.Visible = false;
                Panel1.Visible = Panel1.Enabled = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwDCDetails.Rows[index];
                Label lbl = (Label)row.FindControl("lblhidenndeliveryID");

              
                string ID = lbl.Text.Trim();
                hidDetails_Deleivery_ID.Value = ID;
            
                if (!string.IsNullOrEmpty(ID))
                {

                    DataTable dtNew = new DataTable();
                    Int64 IDD = Convert.ToInt64(ID);

                    dtNew = ClsDeliveryChallan.Get_DC(IDD);
                    GvwDCDetails.DataSource = dtNew;
                  
                    
                    if (dtNew.Rows.Count > 0)
                    {
                        Txt_DC_Date.Text = dtNew.Rows[0]["DC_Date"].ToString();
                        Txt_DC_NO.Text = dtNew.Rows[0]["DC_no"].ToString();
                        
                        DrpTransporter.SelectedValue = dtNew.Rows[0]["tr"].ToString();
                        
                        DrpDispatchDetails.SelectedValue = dtNew.Rows[0]["dd"].ToString();
                        
                        Txt_Dispatch_Date.Text = dtNew.Rows[0]["DispatchDate"].ToString();
                        Txt_DateOfDelivery.Text = dtNew.Rows[0]["DateOfDelivery"].ToString();
                        Txt_DateOf_Installation.Text = dtNew.Rows[0]["DateOfInstallation"].ToString();
                    }
                }
            }
        }
        catch
        { }

    }
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
         

        if (Txt_DC_Date.Text != string.Empty)
        {
            if (!string.IsNullOrEmpty(hidDetails_ID.Value))
            {
                System.Data.SqlTypes.SqlDateTime Dispatch;
                System.Data.SqlTypes.SqlDateTime DateofDel;
                System.Data.SqlTypes.SqlDateTime DateofInst;



                string asd = hidDetails_ID.Value;
                string DCID = hidDetails_Deleivery_ID.Value;
                
                string Dispatchdate = Txt_Dispatch_Date.Text.Trim();
                if (Dispatchdate == "")
                    Dispatch = SqlDateTime.Null;
                else
                    Dispatch = Convert.ToDateTime(Txt_Dispatch_Date.Text);

                string DateOfDelivery = Txt_DateOfDelivery.Text.Trim();
                if (DateOfDelivery == "")
                    DateofDel = SqlDateTime.Null;
                else
                    DateofDel = Convert.ToDateTime(Txt_DateOfDelivery.Text);

                string DateOfInstallation = Txt_DateOf_Installation.Text.Trim();
                if (DateOfInstallation == "")
                    DateofInst = SqlDateTime.Null;
                else
                    DateofInst = Convert.ToDateTime(Txt_DateOf_Installation.Text);

                bool result = ClsDeliveryChallan.Update_DC_Details(Convert.ToInt32(DCID), Convert.ToInt32(asd), Txt_DC_NO.Text.Trim(), Convert.ToDateTime(Txt_DC_Date.Text.Trim()), DrpTransporter.SelectedItem.Value.ToString(), Convert.ToInt32(DrpDispatchDetails.SelectedItem.Value.ToString()), Dispatch, DateofDel, DateofInst, Convert.ToInt32(Session["Id"]));
                if (result)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Saved Successfully...');</script>", false);

                    Txt_DC_Date.Text = "";
                    DrpTransporter.SelectedItem.Value = "-1";
                    DrpDispatchDetails.SelectedItem.Value = "-1";
                    Txt_Dispatch_Date.Text = "";
                    Txt_DateOf_Installation.Text = "";
                    Txt_DC_NO.Text = "";
                    Txt_DateOfDelivery.Text = "";

                    Panel1.Visible = Panel1.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Failed...');</script>", false);
                }

            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select the Deleivery challan Date...');</script>", false);
        }
    }
}