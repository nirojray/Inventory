using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class SORejectedData : System.Web.UI.Page
{
    string id;
    double SubTotal;
    double TaxAmount;
    double TotalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Id"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
        }
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-160));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();

            txtSO_Date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            AddFirstRow();
            // GetMasterList("BillS", drp_Biiling);
            GetState();
            bindSalesType();
            LoadCreditPeriod();
            //LoadWarranty();
            GetMasterList("VE", DrpVertical);
            //GetMasterList("CU", DrpSupplier);           
            LoadType();
            bindRepresentativeOnLoc();
            // termsOfdelivery();
            ProductDescVisibleFalse(); FromToDatesvisibleFalse();
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
            ds = ClsSalesManagerChecking.Get_SalesOrder_RejectedData(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            GvwSalesManagerChecking.DataSource = ds;
            GvwSalesManagerChecking.DataBind();

            if (ds.Rows.Count > 0)
            {
                lblmessage.Text = "";
            }
            else {
                lblmessage.Text = "No Records Found...";
            }
            ViewState["Data"] = ds;
            ds.Dispose();
            if (ViewState["PageINdex"] != null)
                GvwSalesManagerChecking.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());


        }
        catch (Exception ex)
        {
        }

    }

    //  Binding State Dropdown
    private void GetState()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = BusinessServices.BindState();
            ddlState.Items.Clear();
            ddlState.DataSource = dt;
            ddlState.DataTextField = "State_Name";
            ddlState.DataValueField = "State_ID";
            ddlState.DataBind();
            ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));


        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    // Binding Location Dropdown on State Selection
    public void bindLocationOnState(int StateID, string Type)
    {
        try
        {
            DataTable dt = BusinessServices.Imaging_GetLocationOnState(StateID, Type);
            DrpLocation.Items.Clear();
            DrpLocation.DataSource = dt;
            DrpLocation.DataTextField = "Location_Name";
            DrpLocation.DataValueField = "Location_ID";
            DrpLocation.DataBind();

            DrpLocation.Items.Insert(0, new ListItem("--Select Location--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    // Binding Sales Type Dropdown
    public void bindSalesType()
    {
        try
        {
            DataTable dt = BusinessServices.Imaging_GetSalesType();
            ddlSalesType.Items.Clear();
            ddlSalesType.DataSource = dt;
            ddlSalesType.DataTextField = "SalesType";
            ddlSalesType.DataValueField = "Id";
            ddlSalesType.DataBind();

            ddlSalesType.Items.Insert(0, new ListItem("--Select Sales Type--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //  Binding CreditPeriod Dropdown
    private void LoadCreditPeriod()
    {
        DataTable DTCreditPeriod = BusinessServices.Imaging_GetCreditperiod();
        ddlCreditPeriod.DataSource = DTCreditPeriod;
        ddlCreditPeriod.DataValueField = "Id";
        ddlCreditPeriod.DataTextField = "CreditPeriod";
        ddlCreditPeriod.DataBind();
        ddlCreditPeriod.Items.Insert(0, new ListItem("--Select CreditPeriod--", "0"));
    }
    //  Binding Warranty Dropdown
    private void LoadWarranty()
    {
        DataTable DTWarranty = BusinessServices.Imaging_GetWarranty();
        ddlWarranty.DataSource = DTWarranty;
        ddlWarranty.DataValueField = "Id";
        ddlWarranty.DataTextField = "Warranty";
        ddlWarranty.DataBind();
        ddlWarranty.Items.Insert(0, new ListItem("--Select Warranty--", "0"));
    }
    // Binding Representative Dropdown on Location Selection
    public void bindRepresentativeOnLoc()
    {
        try
        {
            DataTable dt = BusinessServices.GetRepresentativeonLoc();
            ddlRepresentative.Items.Clear();
            ddlRepresentative.DataSource = dt;
            ddlRepresentative.DataTextField = "Name";
            ddlRepresentative.DataValueField = "Id";
            ddlRepresentative.DataBind();
            ddlRepresentative.Items.Insert(0, new ListItem("--Select Representative--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    //  Binding Type(MAin CAtegory) Dropdown
    private void LoadType()
    {
        DataTable DTMainCategory = BusinessServices.Get_Admin_MainCategory();
        ddltype.DataSource = DTMainCategory;
        ddltype.DataValueField = "M_categoryid";
        ddltype.DataTextField = "M_CategoryName";
        ddltype.DataBind();
        ddltype.Items.Insert(0, new ListItem("--Select Type--", "0"));
    }

    //private void termsOfdelivery()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        dt = ClsSalesOrder.termsdeliver_dropdown();
    //        ddlTermsOfDelievery.Items.Clear();
    //        ddlTermsOfDelievery.DataSource = dt;
    //        ddlTermsOfDelievery.DataTextField = "terms_delivery";
    //        ddlTermsOfDelievery.DataValueField = "ID";
    //        ddlTermsOfDelievery.DataBind();
    //        ddlTermsOfDelievery.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    //Addming First Row to grid
    private void AddFirstRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("sno");
        dt.Columns.Add("SO_Catagory_ID");
        dt.Columns.Add("Category");
        dt.Columns.Add("SO_Product_ID");
        dt.Columns.Add("Product");
        // dt.Columns.Add("CurntStock");
        dt.Columns.Add("SO_Product_Description");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("UnitPrice");
        dt.Columns.Add("SubTot");
        dt.Columns.Add("TaxID");
        dt.Columns.Add("TaxAmt");
        dt.Columns.Add("TotalAmt");
        DataRow dr1 = dt.NewRow();
        dr1["sno"] = "";
        dr1["SO_Catagory_ID"] = "";
        dr1["Category"] = "";
        dr1["SO_Product_ID"] = "";
        dr1["Product"] = "";
        //dr1["CurntStock"] = "";
        dr1["SO_Product_Description"] = "";
        dr1["FromDate"] = "";
        dr1["ToDate"] = "";
        dr1["Quantity"] = "";
        dr1["UnitPrice"] = "";
        dr1["SubTot"] = "";
        dr1["TaxID"] = "";
        dr1["TaxAmt"] = "";
        dr1["TotalAmt"] = "";
        dt.Rows.Add(dr1);
        GvwSalesOrder.DataSource = dt;
        GvwSalesOrder.DataBind();
        this.GvwSalesOrder.Columns[1].Visible = false;
        this.GvwSalesOrder.Columns[3].Visible = false;
        this.GvwSalesOrder.Columns[11].Visible = false;
    }

    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            DrpList.Items.Clear();
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select Vertical--", "0"));

        }
        catch (Exception Ex)
        {

        }
    }

    public void ProductDescVisibletrue()
    {
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtDescription")).Visible = true;
    }
    public void ProductDescVisibleFalse()
    {
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtDescription")).Visible = false;
    }
    public void FromToDatesvisibleFalse()
    {
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtFrmDate")).Visible = false;
        ((Image)GvwSalesOrder.FooterRow.FindControl("ImgFrom")).Visible = false;
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtToDate")).Visible = false;
        ((Image)GvwSalesOrder.FooterRow.FindControl("ImgTo")).Visible = false;
    }
    public void FromToDatesvisibleTrue()
    {
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtFrmDate")).Visible = true;
        ((Image)GvwSalesOrder.FooterRow.FindControl("ImgFrom")).Visible = true;
        ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtToDate")).Visible = true;
        ((Image)GvwSalesOrder.FooterRow.FindControl("ImgTo")).Visible = true;
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

    protected void GvwSalesManagerChecking_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        try
        {
            if (e.CommandName == "Edit1")
            {

                Panel2.Visible = false;
                Panel1.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvwSalesManagerChecking.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");

                //  hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                //hidDetails_ID.Value = ID;
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
                    GetMasterList("VE", DrpVertical); 
                    lblSoNumber.Text= dtNew.Rows[0]["SO_Number"].ToString();
                    DrpVertical.SelectedValue = dtNew.Rows[0]["SO_Vertical_ID"].ToString();
                    txtSO_Date.Text = dtNew.Rows[0]["SoDate"].ToString();
                    bindCustOnVertical(Convert.ToInt32(DrpVertical.SelectedValue));
                    DrpSupplier.SelectedValue = dtNew.Rows[0]["CustomerId"].ToString();
                    DrpSupplier_SelectedIndexChanged(sender, e);
                    LoadCreditPeriod();
                    ddlCreditPeriod.SelectedValue = dtNew.Rows[0]["SO_CrPeriod_ID"].ToString();
                    ddlState.SelectedValue = dtNew.Rows[0]["SO_State_ID"].ToString();
                    ddlState_SelectedIndexChanged(sender, e);
                    ddlState.Enabled = false;
                    DrpLocation.SelectedValue = dtNew.Rows[0]["SO_Location_ID"].ToString();
                    DrpLocation.Enabled = false;
                    Txt_CusOrdno.Text = dtNew.Rows[0]["CusutomerOrderNO"].ToString();
                    txtcustordDate.Text = dtNew.Rows[0]["CusutomerOrderdate"].ToString();
                    LoadType();
                    ddltype.SelectedValue = dtNew.Rows[0]["MainCategoryTypeID"].ToString();
                    ddltype.Enabled = false;
                    ddltype_SelectedIndexChanged(sender, e);
                    ddlSalesType.SelectedValue = dtNew.Rows[0]["SO_SalesType_ID"].ToString();
                    ddlSalesType.Enabled = false;
                    DrpLocation_SelectedIndexChanged(sender, e);
                    ddlRepresentative.SelectedValue = dtNew.Rows[0]["SO_Rep_ID"].ToString();
                    ddlWarranty.SelectedValue = dtNew.Rows[0]["SO_Warranty_ID"].ToString();
                    TxtTermsOfDelivery.Text = dtNew.Rows[0]["TermsOfDelivery"].ToString();
                    LblSubTotal.Text= dtNew.Rows[0]["SO_NetAmount"].ToString();
                }

                SoDetails(Convert.ToInt64(ID));
                BindSubCategory();
                GetSalesManager();
                if (ddltype.SelectedIndex != 0)
                {
                    tdwarrenty.Visible = false;
                    tdwarrenty1.Visible = false;

                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.ToString() == "Support" || ddltype.SelectedItem.ToString() == "Software")
                    {
                        tdwarrenty.Visible = true;
                        tdwarrenty1.Visible = true;

                    }
                    //narender added for product description   
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }

                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }
                }

                ViewState["PageINdex"] = GvwSalesManagerChecking.PageIndex;
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void SoDetails(Int64 id)
    {
        DataTable ds = new DataTable();
        ds = ClsSalesManagerChecking.Get_SalesOrderforApproval(id);
        ViewState["OriginalDataSet"] = ds;
        GvwSalesOrder.DataSource = ds;
        GvwSalesOrder.DataBind();
    }
    public void bindCustOnVertical(int VerticalId)
    {
        try
        {
            DataTable dt = BusinessServices.GetCustOnVertical(VerticalId);
            DrpSupplier.Items.Clear();
            DrpSupplier.DataSource = dt;
            DrpSupplier.DataTextField = "Supplier_Name";
            DrpSupplier.DataValueField = "Supplier_Id";
            DrpSupplier.DataBind();

            DrpSupplier.Items.Insert(0, new ListItem("--Select Customer--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void DrpVertical_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox1.Checked = false;
            txtBillingAddress.Text = "";
            txtShippingAddress.Text = "";
            txtVatCst.Text = "";
            txtPAN.Text = "";
            txtReverseCharge.Text = "";
            TxtCustState.Text = "";
            ddlBillingAddress.Items.Clear();
            ddlShippingAddress.Items.Clear();

            if (DrpVertical.SelectedValue != "0")
            {
                bindCustOnVertical(Convert.ToInt32(DrpVertical.SelectedValue));

                //If Others is slected then they can enter their own vertical in txtVertical tetxbox
                if (DrpVertical.SelectedItem.ToString() == "Others")
                {
                    txtVertical.Text = "";
                    txtVertical.Visible = true;
                }
                else
                {
                    txtVertical.Text = DrpVertical.SelectedItem.ToString();
                    txtVertical.Visible = false;
                }
            }
            else
            {

                DrpSupplier.Items.Clear();

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    protected void DrpSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox1.Checked = false;
            txtBillingAddress.Text = "";
            txtShippingAddress.Text = "";
            txtVatCst.Text = "";
            txtPAN.Text = "";
            txtReverseCharge.Text = "";
            TxtCustState.Text = "";

            if (DrpSupplier.SelectedValue != "0")
            {
                //CheckBox1.Visible = true;
                DataTable Dt = BusinessServices.Imaging_GetBillShipAddCustomer(int.Parse(DrpSupplier.SelectedValue));
                if (Dt.Rows.Count > 0)
                {
                    txtBillingAddress.Text = Dt.Rows[0]["BillingAddress"].ToString();
                    txtShippingAddress.Text = Dt.Rows[0]["ShippingAddress"].ToString();
                    txtVatCst.Text = Dt.Rows[0]["VATCST"].ToString();
                    txtPAN.Text = Dt.Rows[0]["PAN"].ToString();
                    txtReverseCharge.Text = Dt.Rows[0]["REVERSECharge"].ToString();
                    //txtservicetaxnumber.Text= Dt.Rows[0]["ServiceTaxNumber"].ToString();
                    BindBillingAddress(Convert.ToInt32(DrpSupplier.SelectedValue));
                    BindShippingAddress(Convert.ToInt32(DrpSupplier.SelectedValue));
                    TxtCustState.Text = Dt.Rows[0]["State_Name"].ToString();
                }
            }

            ViewState["LocShippingAdd"] = txtShippingAddress.Text;
            ViewState["LocBillingAdd"] = txtBillingAddress.Text;
        }
        catch (Exception ex)
        {
        }

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           // ddlRepresentative.Items.Clear();
            if (ddlState.SelectedIndex != 0)
            {

                GridDDlClear();
                bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), "S");
            }
            else
            {

                DrpLocation.Items.Clear();

            }
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }
        }
        catch (Exception ex)
        { throw ex; }

    }

    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {

        tdwarrenty.Visible = false;
        tdwarrenty1.Visible = false;

        if (ddltype.SelectedIndex != 0)
        {
            LoadWarranty();
            GridDDlClear();
            DataTable dt = BusinessLogicLayer.ClsSalesOrder.BindHSN_SAC_Code(Convert.ToInt32(ddltype.SelectedValue));
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.ToString() == "Support" || ddltype.SelectedItem.ToString() == "Software")
            {
                tdwarrenty.Visible = true;
                tdwarrenty1.Visible = true;

            }
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }

            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }

            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.ToString() == "Consumable" || ddltype.SelectedItem.Text == "Software")
            {
                lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                lblHSN_SAC_Code.Text = "HSN Code";
                TxtHSN_SAC_Code.Visible = true;
                TxtHSN_SAC_Code.Text = dt.Rows[0]["HSN_SAC_NUM"].ToString();
            }
            else
            {
                lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                lblHSN_SAC_Code.Text = "SAC Code";
                TxtHSN_SAC_Code.Visible = true;
                TxtHSN_SAC_Code.Text = dt.Rows[0]["HSN_SAC_NUM"].ToString();
            }

        }

    }

    private void GridDDlClear()
    {
        LblSubTotal.Text = "";

        AddFirstRow();
        BindSubCategory();

    }
    public void BindBillingAddress(int CustId)
    {
        try
        {
            ddlBillingAddress.Items.Clear();
            DataTable Dt = ClsSalesOrder.BindCusomerBillingAddress(CustId);
            ddlBillingAddress.DataSource = Dt;
            ddlBillingAddress.DataTextField = "BillingAddress";
            ddlBillingAddress.DataValueField = "id";
            ddlBillingAddress.DataBind();
            ddlBillingAddress.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "-1"));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void BindShippingAddress(int CustId)
    {
        try
        {
            ddlShippingAddress.Items.Clear();
            DataTable Dt = ClsSalesOrder.BindCusomerShippingAddress(CustId);
            ddlShippingAddress.DataSource = Dt;
            ddlShippingAddress.DataTextField = "ShippingAddress";
            ddlShippingAddress.DataValueField = "id";
            ddlShippingAddress.DataBind();
            ddlShippingAddress.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select--", "-1"));
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void BindSubCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DropDownList DrpCatagory = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory");

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddltype.SelectedValue));
            if (DT.Rows.Count > 0)
            {
                DrpCatagory.Items.Clear();
                DrpCatagory.DataSource = DT;
                DrpCatagory.DataValueField = "ID";
                DrpCatagory.DataTextField = "NAME";
                DrpCatagory.DataBind();
                DrpCatagory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
            else
            {
                DrpCatagory.Items.Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpLocation.SelectedIndex != 0)
        {
            GridDDlClear();
           // bindRepresentativeOnLoc(Convert.ToInt32(DrpLocation.SelectedValue));
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }
        }
    }
    protected void ddlSalesType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesType.SelectedIndex != 0)
        {
            GridDDlClear();
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }
        }
    }

    protected void DrpEditCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            // GridViewRow row = null; DropDownList ddlCategory = null;

            DropDownList ddlCategory = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCategory.Parent.Parent;

            if (ddlCategory.SelectedIndex != 0)
            {
                if (ddlState.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select State..');</script>", false);
                    return;
                }
                else if (DrpLocation.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Location..');</script>", false);
                    return;
                }
                else if (DrpSupplier.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Suplier Type..');</script>", false);
                    return;
                }

                int idx = row.RowIndex;
                //// string dd = ddlCategory.SelectedValue;
                DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpEditProduct");
                TextBox txtQuantity = (TextBox)row.Cells[0].FindControl("TxtEditQuantity");
                TextBox txtUnitPrice = (TextBox)row.Cells[0].FindControl("TxtEditPrice");
                DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpEditTaxType");
                //Product Bidning
                DataTable DTProduct = BusinessServices.GetProductOnCategory(Convert.ToInt32(ddltype.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

                ddlProduct.SelectedIndex = 0; txtQuantity.Text = ""; txtUnitPrice.Text = "";
                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("S", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), 0, Convert.ToInt32(ddlCategory.SelectedValue));
                ddlTaxType.Items.Clear();
                ddlTaxType.DataSource = DTTax;
                ddlTaxType.DataTextField = "TaxStructure";
                ddlTaxType.DataValueField = "TaxMapID";
                ddlTaxType.DataBind();
                ddlTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));

                if (DTTax.Rows.Count > 0)
                {
                    ddlTaxType.SelectedIndex = 1;
                }
                else
                {
                    ddlTaxType.SelectedIndex = 0;
                }
            }
            else
            {
                DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpProduct");
                DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpTaxType");
                TextBox TxtDescription = (TextBox)row.Cells[0].FindControl("TxtDescription");
                TextBox txtQuantity = (TextBox)row.Cells[0].FindControl("TxtQuantity");
                TextBox txtUnitPrice = (TextBox)row.Cells[0].FindControl("TxtPrice");
                ddlProduct.Items.Clear();
                ddlTaxType.Items.Clear();
                txtQuantity.Text = "";
                txtUnitPrice.Text = "";
                TxtDescription.Text = "";
            }

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void DrpCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCategory.Parent.Parent;
            // int idx = row.RowIndex;
            // string dd = ddlCategory.SelectedValue;
            // Find all of the other DropDownLists within the same row
            TextBox TxtQuantity = (TextBox)row.FindControl("TxtQuantity");
            DropDownList ddlProduct = (DropDownList)row.FindControl("DrpProduct");
            DropDownList ddlTaxType = (DropDownList)row.FindControl("DrpTaxType");
            TextBox TxtDescription = (TextBox)row.FindControl("TxtDescription");
            TextBox TxtPrice = (TextBox)row.FindControl("TxtPrice");
            TxtQuantity.Text = "";
            TxtPrice.Text = ""; TxtDescription.Text = "";
            if (ddlCategory.SelectedIndex != 0)
            {
                if (ddlState.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select State..');</script>", false);
                    return;
                }
                else if (DrpLocation.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Location..');</script>", false);
                    return;
                }
                else if (ddlSalesType.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Sales Type..');</script>", false);
                    return;
                }


                //Product Bidning Based on Main Type and Sub Category (only Kodak Products)
                DataTable DTProduct = BusinessServices.GetProductOnCategory(Convert.ToInt32(ddltype.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("S", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), 0, Convert.ToInt32(ddlCategory.SelectedValue));
                ddlTaxType.Items.Clear();
                ddlTaxType.DataSource = DTTax;
                ddlTaxType.DataTextField = "TaxStructure";
                ddlTaxType.DataValueField = "TaxMapID";
                ddlTaxType.DataBind();
                ddlTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));
                if (DTTax.Rows.Count > 0)
                {
                    ddlTaxType.SelectedIndex = 1;
                }
                else
                {
                    ddlTaxType.SelectedIndex = 0;
                }

            }
            else
            {
                ddlProduct.Items.Clear();
                ddlTaxType.Items.Clear();
            }
            //Label lblCurntStock = (Label)row.FindControl("lblFtCurntStock");
            //lblCurntStock.Text = "";
        }
        catch (Exception ex)
        { throw ex; }
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {

        Button BtnAdd = (Button)sender;
        // Get the GridViewRow 
        GridViewRow row = (GridViewRow)BtnAdd.Parent.Parent;

        TextBox qty = (TextBox)row.FindControl("TxtQuantity");
        TextBox TxtDescription = (TextBox)row.FindControl("TxtDescription");
        TextBox TxtFrmDate = (TextBox)row.FindControl("TxtFrmDate");
        TextBox TxtToDate = (TextBox)row.FindControl("TxtToDate");
        TextBox UnitPrice = (TextBox)row.FindControl("TxtPrice");
        DropDownList ddlCategory = (DropDownList)row.FindControl("DrpCatagory");
        DropDownList ddlProduct = (DropDownList)row.FindControl("DrpProduct");
        DropDownList ddlTaxType = (DropDownList)row.FindControl("DrpTaxType");
        Label lblFtTotal = (Label)row.FindControl("LblfttotalPrice");
        // Label lblFtCurntStock = (Label)row.FindControl("lblFtCurntStock");
        if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedIndex != 0 && ddlTaxType.SelectedIndex != 0 && qty.Text != "" && UnitPrice.Text != "")

        {
            if (ddltype.SelectedValue.ToString() == "3" || ddltype.SelectedValue.ToString() == "4" || ddltype.SelectedValue.ToString() == "6")
            {

            }
            else
            {

                DataTable DtStock = BusinessServices.Get_ProductStock(DrpLocation.SelectedItem.Text, Convert.ToInt32(ddlProduct.SelectedValue));
                //if (Convert.ToInt32(DtStock.Rows[0][0].ToString()) == 0)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('There is no stock available for this product...');</script>", false);
                //    return;
                //}
                //else
                //{
                int SameProductqty = 0;
                int StckAvailable = 0;
                foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
                {
                    if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                    {
                        if (((Label)gvRow.FindControl("LblProductID")).Text == ddlProduct.SelectedValue.ToString())
                        {
                            SameProductqty = SameProductqty + Convert.ToInt32(((Label)gvRow.FindControl("LblQuantity")).Text.Trim());
                        }
                    }
                }
                StckAvailable = Convert.ToInt32(DtStock.Rows[0][0].ToString()) - SameProductqty;
                SameProductqty = SameProductqty + Convert.ToInt32(qty.Text.Trim());

                //if (Convert.ToInt32(DtStock.Rows[0][0].ToString()) < SameProductqty)
                //{
                //    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Stock available for this product is : " + StckAvailable + "');</script>", false);
                //    return;
                //}

                // }
            }

            //narender added for product description 
            if (ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental")
            {
                if (TxtDescription.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Enter Product Description');</script>", false);
                    TxtDescription.Focus();
                    return;
                }
            }

            SubTotal = 0;
            TotalAmount = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("SO_Catagory_ID");
            dt.Columns.Add("Category");
            dt.Columns.Add("SO_Product_ID");
            dt.Columns.Add("Product");
            // dt.Columns.Add("CurntStock");
            dt.Columns.Add("SO_Product_Description");
            dt.Columns.Add("FromDate");
            dt.Columns.Add("ToDate");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("SubTot");
            dt.Columns.Add("TaxID");
            dt.Columns.Add("TaxAmt");
            dt.Columns.Add("TotalAmt");
            string Product = ddlProduct.SelectedItem.ToString();
            foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
            {
                // LinkButton LinkDelete = (LinkButton)gvRow.FindControl("lnkLink");
                // LinkDelete.Visible = true;
                if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                {
                    if (((Label)gvRow.FindControl("LblProductID")).Text == ddlProduct.SelectedValue.ToString() && ((Label)gvRow.FindControl("lblCatagoryID")).Text == ddlCategory.SelectedValue.ToString())
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('You cant selct same product twice...');</script>", false);

                        return;
                    }
                    DataRow dr = dt.NewRow();
                    dr["SO_Catagory_ID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                    dr["Category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                    dr["SO_Product_ID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                    //dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
                    dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                    dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                    dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
                    dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
                    dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                    dr["UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                    dr["SubTot"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                    dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                    dr["TaxAmt"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                    dr["TotalAmt"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                    dt.Rows.Add(dr);
                    SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                }
            }
            DataRow dr1 = dt.NewRow();
            dr1["SO_Catagory_ID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString();
            dr1["Category"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedItem.Text;
            dr1["SO_Product_ID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedValue.ToString();
            dr1["Product"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedItem.Text;
            // dr1["CurntStock"] = ((Label)GvwSalesOrder.FooterRow.FindControl("lblFtCurntStock")).Text;
            dr1["SO_Product_Description"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtDescription")).Text;
            dr1["FromDate"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtFrmDate")).Text;
            dr1["ToDate"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtToDate")).Text;
            dr1["Quantity"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text;
            dr1["UnitPrice"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text;
            dr1["SubTot"] = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));
            DataTable DTTaxRate = new DataTable();
            int TAX1 = Convert.ToInt32(((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString());

            DTTaxRate = BusinessServices.GetTaxRateBaseValue(TAX1);
            double SubTot = Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text);
            double TaxValue = 0;
            if (DTTaxRate.Rows.Count > 0)
            {

                for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                {
                    double SubTotonBaseVal = SubTot * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                    TaxValue = TaxValue + (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);

                }

            }



            // = Convert.ToDouble(Ds.Rows[0]["Percentage"].ToString());

            int catagoryid = Convert.ToInt32(((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString());

            dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
            dr1["TaxAmt"] = Convert.ToString(TaxValue);
            TotalAmount = SubTot + TaxValue;
            dr1["TotalAmt"] = TotalAmount.ToString("0.00");
            SubTotal = SubTotal + TotalAmount;
            dt.Rows.Add(dr1);
            GvwSalesOrder.DataSource = dt;
            GvwSalesOrder.DataBind();
            ViewState["AddNewDataset"] = dt;
            //LinkDelete1.Visible = true;
            this.GvwSalesOrder.Columns[1].Visible = false;
            this.GvwSalesOrder.Columns[3].Visible = false;
            BindSubCategory();
            // GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
            ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
            // double SubTotalRound = (double)Math.Floor(SubTotal + .49);
            double SubTotalRound = Convert.ToDouble(SubTotal.ToString("0.00"));
            LblSubTotal.Text = SubTotalRound.ToString("0.00");
            // LblSubTotal.Text = SubTotal.ToString();

            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{

            //    if (dt.Rows.Count > 0)
            //    {
            //        GvwSalesOrder.Rows[i].Cells[5].BackColor = System.Drawing.Color.Yellow;
            //    }
            //}

        }
        else
        {

            if (ddlCategory.SelectedIndex == 0)
            {
                ddlCategory.Focus();

            }
            else if (ddlProduct.SelectedIndex == 0)
            {
                ddlProduct.Focus();

            }
            else if (ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental")
            {
                if (TxtDescription.Text == "")
                {
                    TxtDescription.Focus();
                }
                else if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                {
                    if (TxtFrmDate.Text == "")
                    {
                        TxtFrmDate.Focus();
                    }
                    else if (TxtToDate.Text == "")
                    {
                        TxtToDate.Focus();
                    }
                    else if (qty.Text == "")
                    {
                        qty.Focus();

                    }
                    else if (UnitPrice.Text == "")
                    {
                        UnitPrice.Focus();

                    }
                    else if (ddlTaxType.SelectedIndex == 0)
                    {
                        lblFtTotal.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                        ddlTaxType.Focus();

                    }
                }
                else if (qty.Text == "")
                {
                    qty.Focus();

                }
                else if (UnitPrice.Text == "")
                {
                    UnitPrice.Focus();

                }
                else if (ddlTaxType.SelectedIndex == 0)
                {
                    lblFtTotal.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                    ddlTaxType.Focus();

                }
            }
            else if (qty.Text == "")
            {
                qty.Focus();

            }
            else if (UnitPrice.Text == "")
            {
                UnitPrice.Focus();

            }
            else if (ddlTaxType.SelectedIndex == 0)
            {
                lblFtTotal.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                ddlTaxType.Focus();

            }
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);


        }

    }

    public void DrpProduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList DrpProduct = (DropDownList)sender;
            // Get the GridViewRow  lblCurntStock
            GridViewRow row = (GridViewRow)DrpProduct.Parent.Parent;
            DropDownList ddlProduct = (DropDownList)row.FindControl("DrpProduct");
            Label lblCurntStock = (Label)row.FindControl("lblFtCurntStock");
            lblCurntStock.Text = "";
            DataTable DtStock = BusinessServices.Get_ProductStock(DrpLocation.SelectedItem.Text, Convert.ToInt32(ddlProduct.SelectedValue));
            lblCurntStock.Text = DtStock.Rows[0][0].ToString();
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    protected void GvwSalesOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("sno");
            dt.Columns.Add("SO_Catagory_ID");
            dt.Columns.Add("Category");
            dt.Columns.Add("SO_Product_ID");
            dt.Columns.Add("Product");
            // dt.Columns.Add("CurntStock");
            dt.Columns.Add("SO_Product_Description");
            dt.Columns.Add("FromDate");
            dt.Columns.Add("ToDate");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("SubTot");
            dt.Columns.Add("TaxID");
            dt.Columns.Add("TaxAmt");
            dt.Columns.Add("TotalAmt");
            foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["SO_Catagory_ID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                dr["Category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                dr["SO_Product_ID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                //dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
                dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                dr["UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                dr["SubTot"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                dr["TaxAmt"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                dr["TotalAmt"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                dt.Rows.Add(dr);
                SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
            }
            dt.Rows[e.RowIndex].Delete();

            GvwSalesOrder.DataSource = dt;
            GvwSalesOrder.DataBind();
            this.GvwSalesOrder.Columns[1].Visible = false;
            this.GvwSalesOrder.Columns[3].Visible = false;
            this.GvwSalesOrder.Columns[11].Visible = false;
            double tt = 0.00;
            foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
            {
                DataRow dr = dt.NewRow();
                dr["SO_Catagory_ID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                dr["Category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                dr["SO_Product_ID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                //dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
                dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                dr["UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                dr["SubTot"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                dr["TaxAmt"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                dr["TotalAmt"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;

                tt = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text) + tt;
            }
           // LblSubTotal.Text = Math.Floor(tt + .49).ToString("0.00");
             LblSubTotal.Text = tt.ToString("0.00");
            BindSubCategory();
            // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
            ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
            int i = GvwSalesOrder.Rows.Count;
            if (i == 0)
            {
                AddFirstRow();
                BindSubCategory();
                //WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse();
                ////GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
            }
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
            {
                FromToDatesvisibleTrue();
            }
            else
            {
                FromToDatesvisibleFalse();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public void BindEditSubCategory(GridViewRow Row)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DropDownList DrpEditCatagory = (DropDownList)Row.FindControl("DrpEditCatagory");

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddltype.SelectedValue));
            if (DT.Rows.Count > 0)
            {
                DrpEditCatagory.Items.Clear();
                DrpEditCatagory.DataSource = DT;
                DrpEditCatagory.DataValueField = "ID";
                DrpEditCatagory.DataTextField = "NAME";
                DrpEditCatagory.DataBind();
                DrpEditCatagory.Items.Insert(0, new ListItem("--Select Catagory--", "0"));
            }
            else
            {
                DrpEditCatagory.Items.Clear();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void GvwSalesOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    BindEditSubCategory(e.Row);
                    DropDownList DrpEditCatagory = (DropDownList)e.Row.FindControl("DrpEditCatagory");
                    Label lblCatagoryId = (Label)e.Row.FindControl("lblCatagoryID");
                    DropDownList DrpEditProduct = (DropDownList)e.Row.FindControl("DrpEditProduct");
                    Label LblProductID = (Label)e.Row.FindControl("LblProductID");
                    TextBox TxtEdiDescription = (TextBox)e.Row.FindControl("TxtEditDescription");
                    HiddenField HfdEdiDescription = (HiddenField)e.Row.FindControl("HfdEditDescription");
                    TextBox TxtEditQuantity = (TextBox)e.Row.FindControl("TxtEditQuantity");
                    HiddenField HfdEditQuantity = (HiddenField)e.Row.FindControl("HfdEditQuantity");
                    TextBox TxtEditPrice = (TextBox)e.Row.FindControl("TxtEditPrice");
                    HiddenField HfdEditPrice = (HiddenField)e.Row.FindControl("HfdEditPrice");
                    DropDownList DrpEditTaxType = (DropDownList)e.Row.FindControl("DrpEditTaxType");
                    HiddenField HfdEditTaxID = (HiddenField)e.Row.FindControl("HfdEditTaxID");
                    Label LblEditfttotalPrice = (Label)e.Row.FindControl("LblEditfttotalPrice");
                    HiddenField HfdEditfttotalPrice = (HiddenField)e.Row.FindControl("HfdEditfttotalPrice");

                    TextBox TxtEditFrmDate = (TextBox)e.Row.FindControl("TxtEditFrmDate");
                    HiddenField HfdEditFromDate = (HiddenField)e.Row.FindControl("HfdEditFromDate");
                    TextBox TxtEditToDate = (TextBox)e.Row.FindControl("TxtEditToDate");
                    HiddenField HfdEditToDate = (HiddenField)e.Row.FindControl("HfdEditToDate");                   


                    DrpEditCatagory.SelectedValue = lblCatagoryId.Text;
                    BindProduct(e.Row);
                    DrpEditProduct.SelectedValue = LblProductID.Text;
                    TxtEdiDescription.Text = HfdEdiDescription.Value;
                    TxtEditQuantity.Text = HfdEditQuantity.Value;
                    TxtEditPrice.Text = HfdEditPrice.Value;

                    DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("S", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), 0, Convert.ToInt32(DrpEditCatagory.SelectedValue));
                    DrpEditTaxType.Items.Clear();
                    DrpEditTaxType.DataSource = DTTax;
                    DrpEditTaxType.DataTextField = "TaxStructure";
                    DrpEditTaxType.DataValueField = "TaxMapID";
                    DrpEditTaxType.DataBind();
                    DrpEditTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));


                    DrpEditTaxType.SelectedValue = HfdEditTaxID.Value;
                    LblEditfttotalPrice.Text = HfdEditfttotalPrice.Value;
                    TxtEditFrmDate.Text = HfdEditFromDate.Value;
                    TxtEditToDate.Text = HfdEditToDate.Value;
                    
                    //// DrpEditCatagory_SelectedIndexChanged(sender, e);

                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        EditProductDescVisibletrue(e.Row);
                    }
                    else
                    {
                        EditProductDescVisibleFalse(e.Row);
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        EditFromToDatesvisibleTrue(e.Row);
                    }
                    else
                    {
                        EditFromToDatesvisibleFalse(e.Row);
                    }

                }
                else
                {
                    Label lblCatagory = (Label)e.Row.FindControl("lblCatagory");
                    Label LblProduct = (Label)e.Row.FindControl("LblProduct");
                    Label LblQuantity = (Label)e.Row.FindControl("LblQuantity");
                    Label LblPrice = (Label)e.Row.FindControl("LblPrice");
                    Label LbltotalPrice = (Label)e.Row.FindControl("LbltotalPrice");
                    Label LblTaxAmount = (Label)e.Row.FindControl("LblTaxAmount");
                    Label LbltotalAmount = (Label)e.Row.FindControl("LbltotalAmount");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkLink");
                    if (lblCatagory.Text != "" && LblProduct.Text != "" && LblQuantity.Text != "" && LblPrice.Text != "" && LbltotalPrice.Text != "" && LblTaxAmount.Text != "" && LbltotalAmount.Text != "")
                    {
                        if (GvwSalesOrder.Rows.Count >= 0)
                        {
                            lnkDelete.Visible = true;
                        }
                        else
                        {
                            lnkDelete.Visible = false;
                        }
                    }
                    else
                    {
                        lnkDelete.Visible = false;
                    }


                }
            }

        }
        catch (Exception ex)
        {
        }
    }

    public void BindProduct(GridViewRow row)
    {
        try
        {
            DropDownList ddlCategory = null;
            ddlCategory = (DropDownList)row.FindControl("DrpEditCatagory");

            if (ddlCategory.SelectedIndex != 0)
            {
                if (ddlState.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select State..');</script>", false);
                    return;
                }
                else if (DrpLocation.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Location..');</script>", false);
                    return;
                }
                else if (ddlSalesType.SelectedIndex == 0)
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Sales Type..');</script>", false);
                    return;
                }

                int idx = row.RowIndex;
                //// string dd = ddlCategory.SelectedValue;
                DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpEditProduct");
                TextBox txtQuantity = (TextBox)row.Cells[0].FindControl("TxtEditQuantity");
                TextBox txtUnitPrice = (TextBox)row.Cells[0].FindControl("TxtEditPrice");
                DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpEditTaxType");
                //Product Bidning
                DataTable DTProduct = BusinessServices.GetProductOnCategory(Convert.ToInt32(ddltype.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "0"));

                ddlProduct.SelectedIndex = 0; txtQuantity.Text = ""; txtUnitPrice.Text = "";

                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("S", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), 0, Convert.ToInt32(ddlCategory.SelectedValue));
                ddlTaxType.Items.Clear();
                ddlTaxType.DataSource = DTTax;
                ddlTaxType.DataTextField = "TaxStructure";
                ddlTaxType.DataValueField = "TaxMapID";
                ddlTaxType.DataBind();
                ddlTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));

                if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                {
                    ProductDescVisibletrue();
                }
                else
                {
                    ProductDescVisibleFalse();
                }
                if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                {
                    FromToDatesvisibleTrue();
                }
                else
                {
                    FromToDatesvisibleFalse();
                }

            }
            else
            {
                DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpProduct");
                DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpTaxType");
                TextBox TxtDescription = (TextBox)row.Cells[0].FindControl("TxtDescription");
                TextBox txtQuantity = (TextBox)row.Cells[0].FindControl("TxtQuantity");
                TextBox txtUnitPrice = (TextBox)row.Cells[0].FindControl("TxtPrice");
                ddlProduct.Items.Clear();
                ddlTaxType.Items.Clear();
                txtQuantity.Text = "";
                txtUnitPrice.Text = "";
                TxtDescription.Text = "";
            }

        }
        catch (Exception ex)
        {

            throw;
        }
    }
    protected void GvwSalesOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edited")
            {
                GridViewRow GVrow = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                if (ViewState["AddNewDataset"] != null)
                {
                    GvwSalesOrder.EditIndex = GVrow.RowIndex;

                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["AddNewDataset"];
                    GvwSalesOrder.DataSource = dt;
                    GvwSalesOrder.DataBind();
                    BindSubCategory();
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }

                }
                else
                {
                    GvwSalesOrder.EditIndex = GVrow.RowIndex;
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["OriginalDataSet"];
                    GvwSalesOrder.DataSource = ds;
                    GvwSalesOrder.DataBind();
                    BindSubCategory();
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }

                }
            }
            if (e.CommandName == "Canceled")
            {
                GridViewRow GVrow = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                if (ViewState["AddNewDataset"] != null)
                {
                    GvwSalesOrder.EditIndex = -1;
                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["AddNewDataset"];
                    GvwSalesOrder.DataSource = dt;
                    GvwSalesOrder.DataBind();
                    BindSubCategory();
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }
                }
                else
                {
                    GvwSalesOrder.EditIndex = -1;
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["OriginalDataSet"];
                    GvwSalesOrder.DataSource = ds;
                    GvwSalesOrder.DataBind();
                    BindSubCategory();
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }

                }
            }
            if (e.CommandName == "Updated")
            {
                GridViewRow GVrow = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                DropDownList ddlCategory = ((DropDownList)GVrow.FindControl("DrpEditCatagory"));
                DropDownList ddlProduct = ((DropDownList)GVrow.FindControl("DrpEditProduct"));

                TextBox TxtDescription = ((TextBox)GVrow.FindControl("TxtEditDescription"));

                DropDownList ddlTaxType = ((DropDownList)GVrow.FindControl("DrpEditTaxType"));
                TextBox qty = ((TextBox)GVrow.FindControl("TxtEditQuantity"));
                TextBox UnitPrice = ((TextBox)GVrow.FindControl("TxtEditPrice"));
                Label lblFtTotal1 = (Label)GVrow.FindControl("LblEditfttotalPrice");

                TextBox TxtEditFrmDate = ((TextBox)GVrow.FindControl("TxtEditFrmDate"));
                TextBox TxtEditToDate = ((TextBox)GVrow.FindControl("TxtEditToDate"));
               

                if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedIndex != 0 && ddlTaxType.SelectedIndex != 0 && qty.Text != "" && UnitPrice.Text != "")

                {

                    SubTotal = 0;
                    TotalAmount = 0;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("sno");
                    dt.Columns.Add("SO_Catagory_ID");
                    dt.Columns.Add("Category");
                    dt.Columns.Add("SO_Product_ID");
                    dt.Columns.Add("Product");
                    // dt.Columns.Add("CurntStock");
                    dt.Columns.Add("SO_Product_Description");
                    dt.Columns.Add("FromDate");
                    dt.Columns.Add("ToDate");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("UnitPrice");
                    dt.Columns.Add("SubTot");
                    dt.Columns.Add("TaxID");
                    dt.Columns.Add("TaxAmt");
                    dt.Columns.Add("TotalAmt");
                    DropDownList DrpProduct = (DropDownList)GVrow.FindControl("DrpEditProduct");
                    DropDownList DrpCatagory = (DropDownList)GVrow.FindControl("DrpEditCatagory");
                    foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
                    {

                        Label lblCatagory = (Label)gvRow.FindControl("lblCatagory");
                        if (lblCatagory != null)
                        {
                            if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                            {
                                string ItemProduct = ((Label)gvRow.FindControl("lblCatagory")).Text + "_" + ((Label)gvRow.FindControl("LblProduct")).Text;
                                string FooterProduct = DrpCatagory.SelectedItem.Text + "_" + DrpProduct.SelectedItem.Text;

                                if (ItemProduct == FooterProduct)
                                {
                                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('You cant select same product twice...');</script>", false);
                                    return;
                                }
                                DataRow dr = dt.NewRow();
                                dr["SO_Catagory_ID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                                dr["Category"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                                dr["SO_Product_ID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                                dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                                dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
                                dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
                                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                                dr["UnitPrice"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                                dr["SubTot"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                                dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                                dr["TaxAmt"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;                               
                                dr["TotalAmt"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                                dt.Rows.Add(dr);
                                SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                            }
                        }
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["SO_Catagory_ID"] = ((DropDownList)GVrow.FindControl("DrpEditCatagory")).SelectedValue.ToString();
                    dr1["Category"] = ((DropDownList)GVrow.FindControl("DrpEditCatagory")).SelectedItem.Text;
                    dr1["SO_Product_ID"] = ((DropDownList)GVrow.FindControl("DrpEditProduct")).SelectedValue.ToString();
                    dr1["Product"] = ((DropDownList)GVrow.FindControl("DrpEditProduct")).SelectedItem.Text;
                    dr1["SO_Product_Description"] = ((TextBox)GVrow.FindControl("TxtEditDescription")).Text;
                    dr1["FromDate"] = ((TextBox)GVrow.FindControl("TxtEditFrmDate")).Text;
                    dr1["ToDate"] = ((TextBox)GVrow.FindControl("TxtEditToDate")).Text;
                    dr1["Quantity"] = ((TextBox)GVrow.FindControl("TxtEditQuantity")).Text;
                    dr1["UnitPrice"] = ((TextBox)GVrow.FindControl("TxtEditPrice")).Text;

                    if (((DropDownList)GVrow.FindControl("DrpEditCatagory")).SelectedValue == "0")
                    {
                        DrpCatagory = (DropDownList)GVrow.FindControl("DrpEditCatagory");
                        DrpCatagory.Focus();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);

                        return;
                    }
                    if (((TextBox)GVrow.FindControl("TxtEditQuantity")).Text == "")
                    {
                        TextBox TxtQuan = (TextBox)GVrow.FindControl("TxtEditQuantity");
                        TxtQuan.Focus();
                        return;
                    }
                    if (((TextBox)GVrow.FindControl("TxtEditPrice")).Text == "")
                    {
                        TextBox TxtPrice = (TextBox)GVrow.FindControl("TxtEditPrice");
                        TxtPrice.Focus();
                        return;
                    }
                    if (((DropDownList)GVrow.FindControl("DrpEditTaxType")).SelectedValue == "0")
                    {
                        Label lblFtTotal = (Label)GVrow.FindControl("LblEditfttotalPrice");
                        lblFtTotal.Text = Convert.ToString(Convert.ToInt32(((TextBox)GVrow.FindControl("TxtEditQuantity")).Text) * Convert.ToDouble(((TextBox)GVrow.FindControl("TxtEditPrice")).Text));
                        DropDownList DrpTaxType = (DropDownList)GVrow.FindControl("DrpEditTaxType");
                        DrpTaxType.Focus();
                        return;
                    }
                    dr1["SubTot"] = Convert.ToInt32(((TextBox)GVrow.FindControl("TxtEditQuantity")).Text) * Convert.ToDouble(((TextBox)GVrow.FindControl("TxtEditPrice")).Text);
                    double lblSubTot = Convert.ToInt32(((TextBox)GVrow.FindControl("TxtEditQuantity")).Text) * Convert.ToDouble(((TextBox)GVrow.FindControl("TxtEditPrice")).Text);

                    DataTable DTTaxRate = new DataTable();
                    int TAX1 = Convert.ToInt32(((DropDownList)GVrow.FindControl("DrpEditTaxType")).SelectedValue.ToString());

                    DTTaxRate = BusinessServices.GetTaxRateBaseValue(TAX1);
                    // Label lblSubTot = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                    double TaxValue = 0;
                    if (DTTaxRate.Rows.Count > 0)
                    {
                        for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                        {
                            double SubTotonBaseVal = Convert.ToDouble(lblSubTot) * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                            TaxValue = TaxValue + (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);

                        }

                    }
                    dr1["TaxID"] = ((DropDownList)GVrow.FindControl("DrpEditTaxType")).SelectedValue.ToString();
                    dr1["TaxAmt"] = Convert.ToString(TaxValue.ToString("0.00"));
                  
                   
                   
                    TotalAmount = Convert.ToDouble(lblSubTot) + TaxValue;
                    //Narender added for Round off TotalAmountPrice
                    //double TotalAmountRound = (double)Math.Floor(TotalAmount + .49);
                    //dr1["TotalAmountPrice"] = TotalAmountRound.ToString("0.00");
                    //SubTotal = SubTotal + TotalAmountRound;
                    dr1["TotalAmt"] = TotalAmount.ToString("0.00");
                    SubTotal = SubTotal + TotalAmount;
                    dt.Rows.Add(dr1);
                    ViewState["AddNewDataset"] = dt;

                    GvwSalesOrder.EditIndex = -1;
                    GvwSalesOrder.DataSource = dt;
                    GvwSalesOrder.DataBind();
                    this.GvwSalesOrder.Columns[1].Visible = false;
                    this.GvwSalesOrder.Columns[3].Visible = false;
                    this.GvwSalesOrder.Columns[11].Visible = false;
                    //this.GvwSalesOrder.Columns[8].Visible = true;

                    // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
                    ((DropDownList)GVrow.FindControl("DrpEditCatagory")).Focus();
                   // LblSubTotal.Text = Math.Floor(SubTotal + .49).ToString("0.00");
                     LblSubTotal.Text = SubTotal.ToString("0.00");

                    BindSubCategory();
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }

                }
                else
                {

                    if (ddlCategory.SelectedIndex == 0)
                    {
                        ddlCategory.Focus();

                    }
                    else if (ddlProduct.SelectedIndex == 0)
                    {
                        ddlProduct.Focus();

                    }
                    else if (ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental")
                    {
                        if (TxtDescription.Text == "")
                        {
                            TxtDescription.Focus();
                        }
                        else if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                        {
                            if (TxtEditFrmDate.Text == "")
                            {
                                TxtEditFrmDate.Focus();
                            }
                            else if (TxtEditToDate.Text == "")
                            {
                                TxtEditToDate.Focus();
                            }
                            else if (qty.Text == "")
                            {
                                qty.Focus();

                            }
                            else if (UnitPrice.Text == "")
                            {
                                UnitPrice.Focus();

                            }
                            else if (ddlTaxType.SelectedIndex == 0)
                            {
                                lblFtTotal1.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                                ddlTaxType.Focus();

                            }
                        }
                        else if (qty.Text == "")
                        {
                            qty.Focus();

                        }
                        else if (UnitPrice.Text == "")
                        {
                            UnitPrice.Focus();

                        }
                        else if (ddlTaxType.SelectedIndex == 0)
                        {
                            lblFtTotal1.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                            ddlTaxType.Focus();

                        }
                    }
                    else if (qty.Text == "")
                    {
                        qty.Focus();

                    }
                    else if (UnitPrice.Text == "")
                    {
                        UnitPrice.Focus();

                    }
                    else if (ddlTaxType.SelectedIndex == 0)
                    {
                        lblFtTotal1.Text = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));

                        ddlTaxType.Focus();

                    }
                    //narender added for product description   
                    if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        FromToDatesvisibleTrue();
                    }
                    else
                    {
                        FromToDatesvisibleFalse();
                    }

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);


                }

            }

        }
        catch (Exception ex)
        {

        }
    }

    public void EditProductDescVisibletrue(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditDescription")).Visible = true;
    }
    public void EditProductDescVisibleFalse(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditDescription")).Visible = false;
    }
    public void EditFromToDatesvisibleFalse(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditFrmDate")).Visible = false;
        ((TextBox)row.FindControl("TxtEditToDate")).Visible = false;
        ((Image)row.FindControl("ImgEditFrom")).Visible = false;
        ((Image)row.FindControl("ImgEditTo")).Visible = false;
    }
    public void EditFromToDatesvisibleTrue(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditFrmDate")).Visible = true;
        ((TextBox)row.FindControl("TxtEditToDate")).Visible = true;
        ((Image)row.FindControl("ImgEditFrom")).Visible = true;
        ((Image)row.FindControl("ImgEditTo")).Visible = true;
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        ddlShippingAddress.SelectedValue = "-1";
        if (CheckBox1.Checked == true)
        {
            txtShippingAddress.Text = txtBillingAddress.Text;

        }
        else
        {
            if (ViewState["LocShippingAdd"] != null)
            {
                txtShippingAddress.Text = ViewState["LocShippingAdd"].ToString();
            }
            // ddlShippingAddress.SelectedValue = "0";
        }
    }

    private void Clear()
    {
        LblSubTotal.Text = "0";
        DrpVertical.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlSalesType.SelectedIndex = 0;
        txtVertical.Text = "";
        DrpLocation.Items.Clear();
        ddltype.SelectedIndex = 0;
        ddlRepresentative.SelectedIndex = 0;
        //ddlRepresentative.Items.Clear();
        DrpSupplier.Items.Clear();
        txtBillingAddress.Text = "";
        txtShippingAddress.Text = "";
        txtVatCst.Text = "";
        txtPAN.Text = "";
        //txtservicetaxnumber.Text = "";
        ddlCreditPeriod.SelectedIndex = 0;
        ddlWarranty.SelectedIndex = 0;
        txtcustordDate.Text = "";
        Txt_CusOrdno.Text = "";
        // BindBillingAddress(Convert.ToInt32(DrpSupplier.SelectedValue));
        //BindShippingAddress(Convert.ToInt32(DrpSupplier.SelectedValue));
        //ddlBillingAddress.SelectedIndex = 0;
        ddlBillingAddress.Items.Clear();
        //ddlShippingAddress.SelectedIndex = 0;
        ddlShippingAddress.Items.Clear();
        lblHSN_SAC_Code.Text = "";
        TxtHSN_SAC_Code.Visible = false;
        TxtTermsOfDelivery.Text = "";
        txtReverseCharge.Text = "";
        CheckBox1.Checked = false;
        TxtCustState.Text = "";
    }
    protected void BtnSOSSave_Click(object sender, EventArgs e)
    {

        DropDownList DrpCatagory = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory");
        DropDownList DrpProduct = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct");
        TextBox TxtQuantity = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity");
        TextBox TxtPrice = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice");
        DropDownList DrpTaxType = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType");

        if (DrpCatagory.SelectedValue != "0" && DrpProduct.SelectedValue != "0" && TxtQuantity.Text != "" && TxtPrice.Text != "" && DrpTaxType.SelectedValue != "0" && DrpTaxType.SelectedValue != "")
        {
            if (TxtQuantity.Text != "" && TxtPrice.Text != "")
            {
                Label LblfttotalPrice = (Label)GvwSalesOrder.FooterRow.FindControl("LblfttotalPrice");

                double dbl_lblSubTot = Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text);
                LblfttotalPrice.Text = dbl_lblSubTot.ToString();
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Click On Add Button...');</script>", false);

        }
        else
        {
            if (DrpCatagory.SelectedValue == "0" && TxtQuantity.Text == "" && TxtPrice.Text == "" && DrpTaxType.SelectedValue == "" && LblSubTotal.Text != "0.00" && LblSubTotal.Text != "" && LblSubTotal.Text != "0")
            {

                try
                {
                    ClsSalesOrder clsSalses = new ClsSalesOrder();
                    DataTable dtPOSum = new DataTable();
                    dtPOSum.Columns.Add("SO_Vertical_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Date", typeof(DateTime));
                    dtPOSum.Columns.Add("SO_State_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Location_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_SalesType_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Supplier_ID", typeof(int));
                    dtPOSum.Columns.Add("cus_Order_NO", typeof(string));
                    dtPOSum.Columns.Add("cus_Date", typeof(DateTime));
                    dtPOSum.Columns.Add("SO_CrPeriod_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Warranty_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Rep_ID", typeof(int));
                    dtPOSum.Columns.Add("SO_Main_CategoryID", typeof(int));
                    dtPOSum.Columns.Add("SO_NetAmount", typeof(double));
                    dtPOSum.Columns.Add("SO_EnteredBy", typeof(int));



                    DataRow drSum = dtPOSum.NewRow();
                    drSum["SO_Vertical_ID"] = DrpVertical.SelectedValue.ToString();
                    drSum["SO_Date"] = Convert.ToDateTime(txtSO_Date.Text);
                    drSum["SO_State_ID"] = ddlState.SelectedValue.ToString();
                    drSum["SO_Location_ID"] = DrpLocation.SelectedValue.ToString();
                    drSum["SO_SalesType_ID"] = ddlSalesType.SelectedValue.ToString();
                    drSum["SO_Supplier_ID"] = DrpSupplier.SelectedItem.Value.ToString();
                    drSum["cus_Order_NO"] = Txt_CusOrdno.Text;
                    drSum["cus_Date"] = Convert.ToDateTime(txtcustordDate.Text);
                    drSum["SO_CrPeriod_ID"] = ddlCreditPeriod.SelectedValue.ToString();
                    drSum["SO_Warranty_ID"] = ddlWarranty.SelectedItem.Value.ToString();
                    drSum["SO_Rep_ID"] = ddlRepresentative.SelectedItem.Value.ToString();
                    drSum["SO_Main_CategoryID"] = ddltype.SelectedItem.Value.ToString();
                    drSum["SO_NetAmount"] = LblSubTotal.Text;
                    drSum["SO_EnteredBy"] = Session["Id"].ToString();

                    dtPOSum.Rows.Add(drSum);
                    DataTable dtPODet = new DataTable();

                    dtPODet.Columns.Add("CatagoryID", typeof(int));
                    dtPODet.Columns.Add("ProductID", typeof(int));
                    dtPODet.Columns.Add("SO_Product_Description", typeof(string));
                    dtPODet.Columns.Add("FromDate", typeof(string));
                    dtPODet.Columns.Add("ToDate", typeof(string));
                    dtPODet.Columns.Add("Quantity", typeof(int));
                    dtPODet.Columns.Add("Price", typeof(double));
                    dtPODet.Columns.Add("TotalPrice", typeof(double));
                    dtPODet.Columns.Add("TaxID", typeof(double));
                    dtPODet.Columns.Add("TaxAmount", typeof(double));
                    dtPODet.Columns.Add("TotalAmountPrice", typeof(double));
                    dtPODet.Columns.Add("PendingQuantity", typeof(int));

                    //Creating Datatable for Individual Tax Saving

                    DataTable dtSOTAX = new DataTable();
                    dtSOTAX.Columns.Add("CatagoryID", typeof(int));
                    dtSOTAX.Columns.Add("ProductID", typeof(int));
                    dtSOTAX.Columns.Add("TaxMapId", typeof(int));
                    dtSOTAX.Columns.Add("TaxNameId", typeof(int));
                    dtSOTAX.Columns.Add("TaxRate", typeof(double));
                    dtSOTAX.Columns.Add("BaseValue", typeof(double));
                    dtSOTAX.Columns.Add("TaxAmount", typeof(double));


                    //For Mails

                    //DataTable dtPODetMail = new DataTable();

                    //dtPODetMail.Columns.Add("CatagoryName", typeof(string));
                    //dtPODetMail.Columns.Add("ProductName", typeof(string));
                    ////dtPODetMail.Columns.Add("SO_Product_Description", typeof(string));
                    ////dtPODetMail.Columns.Add("FromDate", typeof(string));
                    ////dtPODetMail.Columns.Add("ToDate", typeof(string));
                    //dtPODetMail.Columns.Add("Current_Stock", typeof(int));
                    //dtPODetMail.Columns.Add("Quantity", typeof(int));
                    ////dtPODetMail.Columns.Add("Price", typeof(double));
                    ////dtPODetMail.Columns.Add("TotalPrice", typeof(double));                  
                    ////dtPODetMail.Columns.Add("TaxAmount", typeof(double));
                    ////dtPODetMail.Columns.Add("TotalAmountPrice", typeof(double));


                    foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
                    {
                        if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                        {
                            DataRow drDet = dtPODet.NewRow();
                            drDet["CatagoryID"] = Convert.ToInt16(((Label)gvRow.FindControl("lblCatagoryID")).Text);
                            drDet["ProductID"] = Convert.ToInt16(((Label)gvRow.FindControl("LblProductID")).Text);
                            drDet["SO_Product_Description"] = Convert.ToString(((Label)gvRow.FindControl("LblDescription")).Text);
                            drDet["FromDate"] = Convert.ToString(((Label)gvRow.FindControl("LblFrmDate")).Text);
                            drDet["ToDate"] = Convert.ToString(((Label)gvRow.FindControl("LblToDate")).Text);
                            drDet["Quantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                            drDet["Price"] = Convert.ToDouble(((Label)gvRow.FindControl("LblPrice")).Text);
                            drDet["TotalPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);
                            drDet["TaxID"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxID")).Text);
                            drDet["TaxAmount"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxAmount")).Text);
                            Double TotAmnt = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                            //double SubTotalRound = (double)Math.Floor(TotAmnt + .49);
                            double SubTotalRound = Convert.ToDouble(TotAmnt.ToString("0.00"));
                            drDet["TotalAmountPrice"] = Convert.ToDouble(SubTotalRound.ToString("0.00"));
                            // drDet["TotalAmountPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                            drDet["PendingQuantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                            dtPODet.Rows.Add(drDet);

                            DataTable DTTaxRate = new DataTable();
                            int TAX1 = Convert.ToInt32(((Label)gvRow.FindControl("LblTaxID")).Text);
                            //Convert.ToInt32(((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString());

                            DTTaxRate = BusinessServices.GetTaxRateBaseValue(TAX1);
                            double SubTot = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);
                            double TaxValue = 0;
                            if (DTTaxRate.Rows.Count > 0)
                            {

                                for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                                {
                                    double SubTotonBaseVal = SubTot * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;

                                    TaxValue = (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);
                                    DataRow drTax = dtSOTAX.NewRow();

                                    //Individual Tax Saving
                                    drTax["CatagoryID"] = Convert.ToInt16(((Label)gvRow.FindControl("lblCatagoryID")).Text);
                                    drTax["ProductID"] = Convert.ToInt16(((Label)gvRow.FindControl("LblProductID")).Text);
                                    drTax["TaxMapId"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxID")).Text);
                                    drTax["TaxNameId"] = Convert.ToInt32(DTTaxRate.Rows[i][0].ToString());
                                    drTax["TaxRate"] = Convert.ToDouble(DTTaxRate.Rows[i][1].ToString());
                                    drTax["BaseValue"] = Convert.ToDouble(DTTaxRate.Rows[i][2].ToString());
                                    drTax["TaxAmount"] = TaxValue;
                                    dtSOTAX.Rows.Add(drTax);
                                }

                            }
                            //int GivenQuantity = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                            //int Current_Stock = Convert.ToInt16(((Label)gvRow.FindControl("lblCurntStock")).Text);
                            //if (Current_Stock < GivenQuantity)
                            //{
                            //    DataRow drDetMail = dtPODetMail.NewRow();
                            //    drDetMail["CatagoryName"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                            //    drDetMail["ProductName"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                            //    // drDetMail["SO_Product_Description"] = Convert.ToString(((Label)gvRow.FindControl("LblDescription")).Text);
                            //    //drDetMail["FromDate"] = Convert.ToString(((Label)gvRow.FindControl("LblFrmDate")).Text);
                            //    //drDetMail["ToDate"] = Convert.ToString(((Label)gvRow.FindControl("LblToDate")).Text);
                            //    drDetMail["Current_Stock"] = Convert.ToInt16(((Label)gvRow.FindControl("lblCurntStock")).Text);
                            //    drDetMail["Quantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                            //    //drDetMail["Price"] = Convert.ToDouble(((Label)gvRow.FindControl("LblPrice")).Text);
                            //    //drDetMail["TotalPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);                               
                            //    //drDetMail["TaxAmount"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxAmount")).Text);
                            //    //drDetMail["TotalAmountPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                            //    dtPODetMail.Rows.Add(drDetMail);
                            //}

                        }
                    }
                    int Result = clsSalses.INSERT_SO_Details_Modified_Rejected_SO_Details(dtPOSum, dtPODet, "", dtSOTAX, txtBillingAddress.Text.Trim(), txtShippingAddress.Text.Trim(), TxtTermsOfDelivery.Text.Trim(), lblSoNumber.Text.Trim());

                    int CustResult = clsSalses.InsertCustomerAddress(Convert.ToInt32(DrpSupplier.SelectedValue), txtBillingAddress.Text.Trim(), txtShippingAddress.Text.Trim());

                    //if (dtPODetMail.Rows.Count > 0)
                    //{
                    //    int SentMailResult = clsSalses.Send_Mail_ZeroStock_So_ProductDetails(dtPODetMail, ddlState.SelectedItem.Text.Trim(), DrpLocation.SelectedItem.Text.Trim());
                    //}


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Sales Order Saved Successfully...');</script>", false);


                    Clear();
                    GridDDlClear();
                    ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
                    ProductDescVisibleFalse();
                    FromToDatesvisibleFalse(); Panel2.Visible = true; Panel1.Visible = false; GetSalesManager();
                }
                catch (Exception Ex)
                {

                }
            }

            else
            {
                DropDownList DrpCatagory1 = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory");
                DropDownList DrpProduct1 = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct");
                TextBox TxtDescription1 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtDescription");
                TextBox TxtFrmDate1 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtFrmDate");
                TextBox TxtToDate1 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtToDate");
                TextBox TxtQuantity1 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity");
                TextBox TxtPrice1 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice");
                DropDownList DrpTaxType1 = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType");
                if (DrpCatagory1.SelectedValue == "0")
                {
                    DrpCatagory1.Focus();
                }
                else if (DrpProduct1.SelectedValue == "0")
                {
                    DrpProduct1.Focus();
                }
                else if (ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental")
                {
                    if (TxtDescription1.Text == "")
                    {
                        TxtDescription1.Focus();
                    }
                    else if (ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Rental")
                    {
                        if (TxtFrmDate1.Text == "")
                        {
                            TxtFrmDate1.Focus();
                        }
                        else if (TxtToDate1.Text == "")
                        {
                            TxtToDate1.Focus();
                        }
                        else if (TxtQuantity1.Text == "")
                        {
                            TxtQuantity1.Focus();
                        }
                        else if (TxtPrice1.Text == "")
                        {
                            TxtPrice1.Focus();
                        }
                        else if (DrpTaxType1.SelectedValue == "0" || DrpTaxType1.SelectedValue == "")
                        {
                            DrpTaxType1.Focus();
                        }
                    }
                    else if (TxtQuantity1.Text == "")
                    {
                        TxtQuantity1.Focus();
                    }
                    else if (TxtPrice1.Text == "")
                    {
                        TxtPrice1.Focus();
                    }
                    else if (DrpTaxType1.SelectedValue == "0" || DrpTaxType1.SelectedValue == "")
                    {
                        DrpTaxType1.Focus();
                    }
                }
                else if (TxtQuantity1.Text == "")
                {
                    TxtQuantity1.Focus();
                }
                else if (TxtPrice1.Text == "")
                {
                    TxtPrice1.Focus();
                }
                else if (DrpTaxType1.SelectedValue == "0" || DrpTaxType1.SelectedValue == "")
                {
                    DrpTaxType1.Focus();
                }
                //TextBox TxtQuantity2 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity");
                //TextBox TxtPrice2 = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice");
                if (TxtQuantity1.Text != "" && TxtPrice1.Text != "")
                {
                    Label LblfttotalPrice = (Label)GvwSalesOrder.FooterRow.FindControl("LblfttotalPrice");
                    double lblSubTot = Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text);
                    LblfttotalPrice.Text = lblSubTot.ToString();
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill the required Fields...');</script>", false);
            }
        }
    }

    protected void BtnPurchaseOrderClear_Click(object sender,EventArgs e)
    {
        try
        {
            Clear(); GridDDlClear();
            Panel2.Visible = true;Panel1.Visible = false;


        }
        catch (Exception ex)
        {
            throw;
        }
    }
}