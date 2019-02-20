using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class PORejectedData : System.Web.UI.Page
{
    double SubTotal;
    double Total;
    double TotalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
            Panel2.Visible = true;
            Panel1.Visible = false;
            BindPurchaseTypee();
         // txtLoggedIn_Date.Attributes.Add("readonly", "readonly");
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
            ds = ClsPurchaseOrder.Get_PurchaseOrderRejectDet(Convert.ToDateTime(Txt_FromDate.Text.Trim()), Convert.ToDateTime(Txt_ToDate.Text.Trim()));
            if (ds.Rows.Count > 0)
            {
                GvPOReject.Visible = true;
                GvPOReject.DataSource = ds;
                GvPOReject.DataBind();
                ViewState["Data"] = ds;
                ds.Dispose();
                if (ViewState["PageINdex"] != null)
                    GvPOReject.PageIndex = Convert.ToInt32(ViewState["PageINdex"].ToString());
            }
            else
            {
                lblmsg.Text = "NO Data Found...";
                GvPOReject.Visible = false;
                //ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('NO Data Found...');</script>", false);
            }

        }
        catch (Exception ex)
        {
        }

    }
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (Txt_FromDate.Text != string.Empty && Txt_ToDate.Text != string.Empty)
        {
            DateTime fromdate = Convert.ToDateTime(Txt_FromDate.Text.ToString());
            DateTime Todate = Convert.ToDateTime(Txt_ToDate.Text.ToString());

            if (fromdate <= Todate)
            {
                tbldate.Visible = true;
                Panel2.Visible = true;
                Panel1.Visible = false;
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
    protected void GvPOReject_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
           
            if (e.CommandName == "Edit1")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
                tbldate.Visible = false;
                GetState();
                GetMasterList("SU", DrpSupplier);
                BindMainCategory();
                LoadWarranty();
                BindPurchaseTypee();
                //DrpAppRej.SelectedIndex = 0; Txt_AppRejReason.Text = "";
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GvPOReject.Rows[index];
                Label lbl = (Label)row.FindControl("hidennID");
                // hidDetails_ID.Value = e.CommandArgument.ToString();
                string ID = lbl.Text.Trim();
                //hidDetails_ID.Value = ID;
                DataTable dtItem = (DataTable)ViewState["Data"];
                DataRow[] drModel = dtItem.Select("PO_ID='" + ID + "'");
                AddFirstRow();
                DataTable dtNew = new DataTable();
                dtNew = dtItem.Clone();
                if (drModel.Length > 0)
                {
                    foreach (DataRow dr in drModel)
                    {
                        dtNew.ImportRow(dr);
                    }
                    dtNew.AcceptChanges();
                    //PO_Number
                    lblPoNumber.Text= dtNew.Rows[0]["PO_Number"].ToString();
                    txtReason.Text = dtNew.Rows[0]["PO_Reason"].ToString();
                    txtLoggedIn_Date.Text = dtNew.Rows[0]["PO_Date"].ToString();
                    // ViewState["PO_Date"]= txtLoggedIn_Date.Text;
                    ddlState.SelectedValue = dtNew.Rows[0]["PO_State_ID"].ToString();
                    ddlState_SelectedIndexChanged(sender, e);
                    ddlState.Enabled = false;
                    DrpLocation.SelectedValue = dtNew.Rows[0]["PO_Location_ID"].ToString();
                    DrpLocation.Enabled = false;
                    DrpSupplier.SelectedValue = dtNew.Rows[0]["PO_Supplier_ID"].ToString();
                    DrpSupplier_SelectedIndexChanged(sender, e);
                    DrpSupplier.Enabled = false;
                    ddlType.SelectedValue = dtNew.Rows[0]["PO_MainCategoryId"].ToString();
                    ddlType_SelectedIndexChanged(sender, e);
                    ddlType.Enabled = false;
                    LblSubTotal.Text = dtNew.Rows[0]["PO_NetAmount"].ToString();
                    txtTermsOfDelievery.Text= dtNew.Rows[0]["TermOfDelv"].ToString();                  
                    ddlPurchaseType.SelectedValue= dtNew.Rows[0]["Purchase_Type_Id"].ToString();
                   ddlPurchaseType.Enabled = false;                
                    if (ddlType.SelectedItem.Text.Trim() == "Scanners" || ddlType.SelectedItem.Text.Trim() == "Support" || ddlType.SelectedItem.Text.Trim() == "Software")
                    {
                        tdwr.Visible = true; tdddlwr.Visible = true;
                        ddlWarranty.SelectedValue = dtNew.Rows[0]["PO_Waranty"].ToString();
                    }
                    else
                    {
                        tdwr.Visible = false; tdddlwr.Visible = false;
                    }
                    if (DrpSupplier.SelectedItem.Text.Trim() == "Others")
                    {
                        tdVndr.Visible = true; tdddlvndr.Visible = true;
                        ddlVendor.SelectedValue = dtNew.Rows[0]["PO_VendorID"].ToString();
                    }
                    else
                    {
                        tdVndr.Visible = false; tdddlvndr.Visible = false;
                    }
                    txtShippingAddress.Text = dtNew.Rows[0]["PO_Shipping_TO"].ToString();
                    txtBillingAddress.Text = dtNew.Rows[0]["PO_Billing_TO"].ToString();
                    txt_PO_RaisedTo.Text= dtNew.Rows[0]["PO_Raise_TO"].ToString();
                    ViewState["LocShippingAdd"] = txtShippingAddress.Text;
                    ViewState["LocBillingAdd"] = txtBillingAddress.Text;
                    if (dtNew.Rows[0]["SPANumber"].ToString() != "")
                    {
                        TxtSpa.Text = dtNew.Rows[0]["SPANumber"].ToString();
                    }
                    else
                    {
                        TxtSpa.Text = "";
                    }
                }

                PoDetails(Convert.ToInt64(ID));
                BindSubCategory();
                GetSalesManager();
                ViewState["PageINdex"] = GvPOReject.PageIndex;
                if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                {
                    ProductDescVisibletrue();
                }
                else
                {
                    ProductDescVisibleFalse();
                }
                WarentyDateControlsvisibleFalse();

                Button BtnAdd = (Button)GvwPurchaseOrder.FooterRow.FindControl("BtnAdd");
                if (TxtSpa.Text != "")
                {
                    BtnAdd.Visible = false;
                }
                else
                {
                    BtnAdd.Visible = true;
                }
            }
        }
        catch (Exception ex)
        { }

    }
    //Binding States
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex != 0)
        {
            GridDDlClear();
            bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), "P");
            txtBillingAddress.Text = "";
            txtShippingAddress.Text = "";
            WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse();
            LblSubTotal.Text = "0.00";
        }
        else
        {
            DrpLocation.Items.Clear();

        }

    }
    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DrpList.Items.Clear();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select--", "-1"));
        }
        catch (Exception Ex)
        {

        }
    }
    public void BindMainCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = ClsMas.GetMainCategory();
            if (DT.Rows.Count > 0)
            {
                ddlType.Items.Clear();
                ddlType.DataSource = DT;
                ddlType.DataValueField = "M_categoryid";
                ddlType.DataTextField = "M_CategoryName";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public void BindVendorName()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();

            DataTable DT = ClsMas.BindVenderName();
            if (DT.Rows.Count > 0)
            {
                ddlVendor.Items.Clear();
                ddlVendor.DataSource = DT;
                ddlVendor.DataValueField = "ID";
                ddlVendor.DataTextField = "VendorName";
                ddlVendor.DataBind();
                ddlVendor.Items.Insert(0, new ListItem("--Select Vendor--", "0"));
            }
            else
            {
                ddlVendor.Items.Clear();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void DrpSupplier_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DrpSupplier.SelectedItem.Text == "Others")
            {
                tdVndr.Visible = true; tdddlvndr.Visible = true; BindVendorName();
            }
            else
            {
                DataTable Dt = BusinessServices.BindSuppliersDet(Convert.ToInt32(DrpSupplier.SelectedValue));
                TxtVatCst.Text = Dt.Rows[0]["VATCST"].ToString();
                txtPaymentTerm.Text = Dt.Rows[0]["Paymentterm"].ToString();
                txtSupplierState.Text = Dt.Rows[0]["State_Name"].ToString();
                txtrevers.Text = Dt.Rows[0]["ReverseCharge"].ToString();
                TxtPANNum.Text= Dt.Rows[0]["PAN"].ToString();
                tdVndr.Visible = false; tdddlvndr.Visible = false;
            }
            GridDDlClear();
            WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse(); LblSubTotal.Text = "0.00";
        }
        catch (Exception)
        {

            throw;
        }


    }
    private void LoadWarranty()
    {
        DataTable DTWarranty = BusinessServices.Imaging_GetWarranty();
        ddlWarranty.DataSource = DTWarranty;
        ddlWarranty.DataValueField = "Id";
        ddlWarranty.DataTextField = "Warranty";
        ddlWarranty.DataBind();
        ddlWarranty.Items.Insert(0, new ListItem("--Select Warranty--", "0"));
    }

    //public void BindSubCategory()
    //{
    //    try
    //    {
    //        ClsMaster ClsMas = new ClsMaster();
    //        DropDownList DrpCatagory = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");

    //        DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlType.SelectedValue));
    //        if (DT.Rows.Count > 0)
    //        {
    //            DrpCatagory.Items.Clear();
    //            DrpCatagory.DataSource = DT;
    //            DrpCatagory.DataValueField = "ID";
    //            DrpCatagory.DataTextField = "NAME";
    //            DrpCatagory.DataBind();
    //            DrpCatagory.Items.Insert(0, new ListItem("--Select Catagory--", "0"));
    //        }
    //        else
    //        {
    //            DrpCatagory.Items.Clear();
    //        }
    //    }
    //    catch (Exception)
    //    {

    //        throw;
    //    }
    //}
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dt1 = BusinessLogicLayer.ClsSalesOrder.BindHSN_SAC_Code(Convert.ToInt32(ddlType.SelectedValue));

            if (ddlType.SelectedItem.ToString() == "Scanners" || ddlType.SelectedItem.ToString() == "Consumable" || ddlType.SelectedItem.Text == "Software")
            {
                lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                lblHSN_SAC_Code.Text = "HSN Code";
                TxtHSN_SAC_Code.Visible = true;
                TxtHSN_SAC_Code.Text = dt1.Rows[0]["HSN_SAC_NUM"].ToString();
                lblHSN_SAC_Code.Visible = true;

            }
            else
            {
                lblHSN_SAC_Code.Text = ""; TxtHSN_SAC_Code.Text = "";
                lblHSN_SAC_Code.Text = "SCA Code";
                TxtHSN_SAC_Code.Visible = true;
                TxtHSN_SAC_Code.Text = dt1.Rows[0]["HSN_SAC_NUM"].ToString();

                lblHSN_SAC_Code.Visible = true;

            }

            if (ddlType.SelectedItem.Text == "Scanners" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software")
            {
                tdwr.Visible = true;
                tdddlwr.Visible = true;
                LoadWarranty();
            }
            else
            {
                tdwr.Visible = false;
                tdddlwr.Visible = false;
                LoadWarranty();
            }

            GridDDlClear();
            BindSubCategory();
            //narender added for product description   
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            WarentyDateControlsvisibleFalse(); LblSubTotal.Text = "0.00";
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridDDlClear();
            ClsPurchaseOrder clsPurchase = new ClsPurchaseOrder();
           // GetMasterList("SU", DrpSupplier);
            if (DrpLocation.SelectedValue != "-1")
            {
                DataTable Dt = clsPurchase.getBSAddres(int.Parse(DrpLocation.SelectedValue));
                if (Dt.Rows.Count > 0)
                {
                    txtBillingAddress.Text = Dt.Rows[0]["BillingAddress"].ToString();
                    txtShippingAddress.Text = Dt.Rows[0]["ShippingAddress"].ToString();
                    LblSubTotal.Text = "0.00";
                    ViewState["LocShippingAdd"] = txtShippingAddress.Text;
                    ViewState["LocBillingAdd"] = txtBillingAddress.Text;
                }
            }
            else
            {
                txtBillingAddress.Text = "";
                txtShippingAddress.Text = "";
                LblSubTotal.Text = "0.00";
            }
            WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse();
        }
        catch (Exception ex)
        {
        }
    }
    private void AddFirstRow()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("sno");
        dt.Columns.Add("CatagoryID");
        dt.Columns.Add("Catagory");
        dt.Columns.Add("ProductID");

        dt.Columns.Add("PO_Product_Description");

        dt.Columns.Add("Product");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Price");
        dt.Columns.Add("TotalPrice");
        dt.Columns.Add("TaxID");
        dt.Columns.Add("TaxAmount");
        dt.Columns.Add("STDFromDate");
        dt.Columns.Add("STDToDate");
        dt.Columns.Add("ExtndFrmDate");
        dt.Columns.Add("ExtndToDate");
        dt.Columns.Add("TotalAmountPrice");
        DataRow dr1 = dt.NewRow();
        dr1["sno"] = "";
        dr1["CatagoryID"] = "";
        dr1["Catagory"] = "";
        dr1["ProductID"] = "";

        dr1["PO_Product_Description"] = "";

        dr1["Product"] = "";
        dr1["Quantity"] = "";
        dr1["Price"] = "";
        dr1["TotalPrice"] = "";
        dr1["TaxID"] = "";
        dr1["TaxAmount"] = "";
        dr1["STDFromDate"] = "";
        dr1["STDToDate"] = "";
        dr1["ExtndFrmDate"] = "";
        dr1["ExtndToDate"] = "";
        dr1["TotalAmountPrice"] = "";
        dt.Rows.Add(dr1);
        GvwPurchaseOrder.DataSource = dt;
        GvwPurchaseOrder.DataBind();
        this.GvwPurchaseOrder.Columns[1].Visible = false;
        this.GvwPurchaseOrder.Columns[3].Visible = false;
        this.GvwPurchaseOrder.Columns[9].Visible = false;

    }
    private void PoDetails(Int64 id)
    {

        DataTable ds = new DataTable();

        ds = ClsPurchaseOrder.Get_Rejecteddata_PoDetails(id);
        ViewState["OriginalDataSet"] = ds;
        GvwPurchaseOrder.DataSource = ds;
        GvwPurchaseOrder.DataBind();


    }
    public void BindSubCategory()
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DropDownList DrpCatagory = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlType.SelectedValue));
            if (DT.Rows.Count > 0)
            {
                DrpCatagory.Items.Clear();
                DrpCatagory.DataSource = DT;
                DrpCatagory.DataValueField = "ID";
                DrpCatagory.DataTextField = "NAME";
                DrpCatagory.DataBind();
                DrpCatagory.Items.Insert(0, new ListItem("--Select Catagory--", "0"));
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
    private void GridDDlClear()
    {
        LblSubTotal.Text = "";
        AddFirstRow();
        BindSubCategory();
        // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));

    }
    public void WarentyDateControlsvisibleFalse()
    {
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdFrmDate")).Visible = false;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgStdFrom")).Visible = false;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdToDate")).Visible = false;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgStdTo")).Visible = false;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndFrmDate")).Visible = false;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgExtndFrm")).Visible = false;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndToDate")).Visible = false;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgExtndTo")).Visible = false;
    }
    public void WarentyDateControlsvisibleTrue()
    {
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdFrmDate")).Visible = true;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgStdFrom")).Visible = true;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdToDate")).Visible = true;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgStdTo")).Visible = true;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndFrmDate")).Visible = true;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgExtndFrm")).Visible = true;
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndToDate")).Visible = true;
        ((Image)GvwPurchaseOrder.FooterRow.FindControl("ImgExtndTo")).Visible = true;
    }

    //narender added for product description   
    public void ProductDescVisibletrue()
    {
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription")).Visible = true;
    }
    public void ProductDescVisibleFalse()
    {
        ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription")).Visible = false;
    }

    public void EditWarentyDateControlsvisibleFalse(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditStdFrmDate")).Visible = false;
        ((Image)row.FindControl("ImgEditStdFrom")).Visible = false;
        ((TextBox)row.FindControl("TxtEditStdToDate")).Visible = false;
        ((Image)row.FindControl("ImgEditStdTo")).Visible = false;
        ((TextBox)row.FindControl("TxtEditExtndFrmDate")).Visible = false;
        ((Image)row.FindControl("ImgEditExtndFrm")).Visible = false;
        ((TextBox)row.FindControl("TxtEditExtndToDate")).Visible = false;
        ((Image)row.FindControl("ImgEditExtndTo")).Visible = false;
    }
    public void EditWarentyDateControlsvisibleTrue(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditStdFrmDate")).Visible = true;
        ((Image)row.FindControl("ImgEditStdFrom")).Visible = true;
        ((TextBox)row.FindControl("TxtEditStdToDate")).Visible = true;
        ((Image)row.FindControl("ImgEditStdTo")).Visible = true;
        ((TextBox)row.FindControl("TxtEditExtndFrmDate")).Visible = true;
        ((Image)row.FindControl("ImgEditExtndFrm")).Visible = true;
        ((TextBox)row.FindControl("TxtEditExtndToDate")).Visible = true;
        ((Image)row.FindControl("ImgEditExtndTo")).Visible = true;
    }

    //narender added for product description   
    public void EditProductDescVisibletrue(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditDescription")).Visible = true;
    }
    public void EditProductDescVisibleFalse(GridViewRow row)
    {
        ((TextBox)row.FindControl("TxtEditDescription")).Visible = false; 
    }
    protected void DrpCatagory_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlCategory = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCategory.Parent.Parent;
            if (ddlCategory.SelectedIndex != 0)
            {
                if (txtReason.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Reason For Purchase..');</script>", false);
                    return;
                }
                if (txtLoggedIn_Date.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Purchase Order Date..');</script>", false);
                    return;
                }
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
                DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpProduct");
                TextBox txtQuantity = (TextBox)row.Cells[0].FindControl("TxtQuantity");
                TextBox txtUnitPrice = (TextBox)row.Cells[0].FindControl("TxtPrice");
                DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpTaxType");
                //Product Bidning
                DataTable DTProduct = BusinessServices.Get_PO_ProductOnCategory(Convert.ToInt32(DrpSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "-1"));

                ddlProduct.SelectedIndex = 0; txtQuantity.Text = ""; txtUnitPrice.Text = "";
                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("P", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), 0, Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
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

                if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC"
                    || ddlCategory.SelectedItem.Text.Trim() == "Rental Scanner" ||
                   ddlCategory.SelectedItem.Text.Trim() == "Installation A4  Scanner Only" || ddlCategory.SelectedItem.Text.Trim() == "Any other services(digitisation, or any other service)" || ddlCategory.SelectedItem.Text.Trim() == "Software"
                    || ddlCategory.SelectedItem.Text.Trim() == "Othersoftware" || ddlCategory.SelectedItem.Text.Trim() == "One Time Support"
                    )
                {
                    WarentyDateControlsvisibleTrue();
                }
                else
                {
                    WarentyDateControlsvisibleFalse();
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
        { throw ex; }
    }
    public void AddNewGridRow(object sender, EventArgs e)
    {

        DropDownList ddlCategory = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory"));
        DropDownList ddlProduct = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct"));

        TextBox TxtDescription = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription"));

        DropDownList ddlTaxType = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType"));
        TextBox qty = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity"));
        TextBox UnitPrice = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice"));
        Label lblFtTotal1 = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");

        TextBox TxtStdFrmDate = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdFrmDate"));
        TextBox TxtStdToDate = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdToDate"));
        TextBox TxtExtndFrmDate = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndFrmDate"));
        TextBox TxtExtndToDate = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndToDate"));

        if (DrpSupplier.SelectedItem.Text.Trim() == "Others")
        {
            if (ddlVendor.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Vendor.');</script>", false);
                ddlVendor.Focus();
                return;
            }
        }

        if (ddlType.SelectedItem.Text.Trim() == "Scanners" || ddlType.SelectedItem.Text.Trim() == "Support" || ddlType.SelectedItem.Text.Trim() == "Software")
        {
            if (ddlWarranty.SelectedIndex == 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Warranty.');</script>", false);
                ddlWarranty.Focus();
                return;
            }
        }



        if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedValue != "-1" && ddlTaxType.SelectedIndex != 0 && qty.Text != "" && UnitPrice.Text != "")
        {

            if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC" || ddlCategory.SelectedItem.Text.Trim() == "One Time Support"
                    )
            {
                if (TxtStdFrmDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Standerd Warranty From Date ..');</script>", false);
                    TxtStdFrmDate.Focus();
                    return;
                }
                //----------------------------------------------Commented on 26May2017 by narender-------------------------------------
                //if (TxtStdFrmDate.Text != "")
                //{
                //    DateTime PODate = Convert.ToDateTime(txtLoggedIn_Date.Text);
                //    DateTime StdFrmDate = Convert.ToDateTime(TxtStdFrmDate.Text);
                //    if (PODate > StdFrmDate)
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Standerd Warranty From Date Should be Greater Than PO Date.');</script>", false);
                //        TxtStdFrmDate.Focus();
                //        return;
                //    }
                //}
                // -------------------------------------------------------------------------------------------------------
                if (TxtStdToDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Standerd Warranty To Date ..');</script>", false);
                    TxtStdToDate.Focus();
                    return;
                }
                if (TxtStdFrmDate.Text != "" && TxtStdToDate.Text != "")
                {
                    DateTime StdFrmDate = Convert.ToDateTime(TxtStdFrmDate.Text);
                    DateTime StdToDate = Convert.ToDateTime(TxtStdToDate.Text);
                    if (StdFrmDate > StdToDate)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Standerd Warranty To Date Should be Greater Than Standerd Warranty From Date.');</script>", false);
                        TxtStdToDate.Focus();
                        return;
                    }
                }
                #region Comment code date validation
                //----------------------------------------------Commented on 26May2017 by narender-------------------------------------
                //if (TxtExtndFrmDate.Text=="")
                //  {                    
                //      ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Extended Warranty From Date ..');</script>", false);
                //      TxtExtndFrmDate.Focus();
                //      return;
                //  }
                //  if (TxtExtndFrmDate.Text != "")
                //  {
                //      DateTime PODate = Convert.ToDateTime(txtLoggedIn_Date.Text);
                //      DateTime ExtdFrmDate = Convert.ToDateTime(TxtExtndFrmDate.Text);
                //      if (PODate > ExtdFrmDate)
                //      {
                //          ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Extended Warranty From Date Should be Greater Than PO Date.');</script>", false);
                //          TxtExtndFrmDate.Focus();
                //          return;
                //      }
                //  }
                //  if (TxtExtndToDate.Text == "")
                //  {                    
                //      ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Extended Warranty To Date ..');</script>", false);
                //      TxtExtndToDate.Focus();
                //      return;
                //  }

                //  if (TxtExtndFrmDate.Text != "" && TxtExtndToDate.Text != "")
                //  {
                //      DateTime ExtdFrmDate = Convert.ToDateTime(TxtExtndFrmDate.Text);
                //      DateTime ExtdToDate = Convert.ToDateTime(TxtExtndToDate.Text);
                //      if (ExtdFrmDate > ExtdToDate)
                //      {
                //          ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Extended Warranty To Date Should be Greater Than Standerd Warranty From Date.');</script>", false);
                //          TxtExtndToDate.Focus();
                //          return;
                //      }
                //  }

                // ----------------------------------------------------------------------------------------------

                // if (TxtStdFrmDate.Text != "" && TxtExtndFrmDate.Text != "")
                //{
                //    DateTime PODate = Convert.ToDateTime(txtLoggedIn_Date.Text);
                //    DateTime StdFrmDate = Convert.ToDateTime(TxtStdFrmDate.Text);
                //    DateTime StdToDate = Convert.ToDateTime(TxtStdToDate.Text);
                //    if (StdFrmDate > StdToDate)
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Standerd Warranty To Date Should be Greater Than Standerd Warranty From Date.');</script>", false);
                //        TxtStdToDate.Focus();
                //        return;
                //    }
                //    DateTime ExtdFrmDate = Convert.ToDateTime(TxtExtndFrmDate.Text);
                //    DateTime ExtdToDate = Convert.ToDateTime(TxtExtndToDate.Text);
                //    if (ExtdFrmDate > ExtdToDate)
                //    {
                //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Extended Warranty To Date Should be Greater Than Standerd Warranty From Date.');</script>", false);
                //        TxtExtndToDate.Focus();
                //        return;
                //    }


                //}
                #endregion

            }
            //narender added for product description 
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
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
            dt.Columns.Add("CatagoryID");
            dt.Columns.Add("Catagory");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("PO_Product_Description");
            dt.Columns.Add("Product");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("TotalPrice");
            dt.Columns.Add("TaxID");
            dt.Columns.Add("TaxAmount");
            dt.Columns.Add("STDFromDate");
            dt.Columns.Add("STDToDate");
            dt.Columns.Add("ExtndFrmDate");
            dt.Columns.Add("ExtndToDate");
            dt.Columns.Add("TotalAmountPrice");

            foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
            {
                DropDownList DrpProduct = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct");
                DropDownList DrpCatagory = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");
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
                    dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                    dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                    dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                    dr["PO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                    dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                    dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                    dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                    dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                    dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                    dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                    dr["STDFromDate"] = ((Label)gvRow.FindControl("LblStdFrmDate")).Text;
                    dr["STDToDate"] = ((Label)gvRow.FindControl("LblStdToDate")).Text;
                    dr["ExtndFrmDate"] = ((Label)gvRow.FindControl("LblExtndFrmDate")).Text;
                    dr["ExtndToDate"] = ((Label)gvRow.FindControl("LblExtndToDate")).Text;
                    dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                    dt.Rows.Add(dr);
                    SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                }
            }
            DataRow dr1 = dt.NewRow();
            dr1["CatagoryID"] = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString();
            dr1["Catagory"] = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).SelectedItem.Text;
            dr1["ProductID"] = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct")).SelectedValue.ToString();
            dr1["PO_Product_Description"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription")).Text;
            dr1["Product"] = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct")).SelectedItem.Text;
            dr1["Quantity"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text;
            dr1["Price"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text;

            if (((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue == "0")
            {
                DropDownList DrpCatagory = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");
                DrpCatagory.Focus();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);

                return;
            }
            if (((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text == "")
            {
                TextBox TxtQuan = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity");
                TxtQuan.Focus();
                return;
            }
            if (((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text == "")
            {
                TextBox TxtPrice = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice");
                TxtPrice.Focus();
                return;
            }
            if (((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue == "0")
            {
                Label lblFtTotal = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                lblFtTotal.Text = Convert.ToString(Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text));
                DropDownList DrpTaxType = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType");
                DrpTaxType.Focus();
                return;
            }
            dr1["TotalPrice"] = Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text);
            double lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text);

            DataTable DTTaxRate = new DataTable();
            int TAX1 = Convert.ToInt32(((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString());

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

            dr1["TaxAmount"] = Convert.ToString(TaxValue.ToString("0.00"));
            dr1["TaxID"] = ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
            dr1["STDFromDate"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdFrmDate")).Text;
            dr1["STDToDate"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtStdToDate")).Text;
            dr1["ExtndFrmDate"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndFrmDate")).Text;
            dr1["ExtndToDate"] = ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtExtndToDate")).Text;
            TotalAmount = Convert.ToDouble(lblSubTot) + TaxValue;
            //Narender added for Round off TotalAmountPrice
            //double TotalAmountRound = (double)Math.Floor(TotalAmount + .49);
            //dr1["TotalAmountPrice"] = TotalAmountRound.ToString("0.00");
            //SubTotal = SubTotal + TotalAmountRound;
            dr1["TotalAmountPrice"] = TotalAmount.ToString("0.00");
            SubTotal = SubTotal + TotalAmount;
            dt.Rows.Add(dr1);
            ViewState["AddNewDataset"] = dt;
            GvwPurchaseOrder.DataSource = dt;
            GvwPurchaseOrder.DataBind();
            this.GvwPurchaseOrder.Columns[1].Visible = false;
            this.GvwPurchaseOrder.Columns[3].Visible = false;
            this.GvwPurchaseOrder.Columns[9].Visible = false;
            this.GvwPurchaseOrder.Columns[8].Visible = true;
            BindSubCategory();
            // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
            ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).Focus();
            LblSubTotal.Text = Math.Floor(SubTotal + .49).ToString("0.00");
            // LblSubTotal.Text = SubTotal.ToString("0.00");
            WarentyDateControlsvisibleFalse();
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
                WarentyDateControlsvisibleFalse();
            }
        }
        else
        {

            if (ddlCategory.SelectedIndex == 0)
            {
                ddlCategory.Focus();
            }
            else if (ddlProduct.SelectedValue == "-1")
            {
                ddlProduct.Focus();
            }
            else if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
            {
                if (TxtDescription.Text == "")
                {
                    TxtDescription.Focus();
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
                    lblFtTotal1.Text = Convert.ToString(Convert.ToInt32(qty.Text) * Convert.ToDouble(UnitPrice.Text));
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
                lblFtTotal1.Text = Convert.ToString(Convert.ToInt32(qty.Text) * Convert.ToDouble(UnitPrice.Text));
                ddlTaxType.Focus();
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);

        }
    }
    protected void GvwPurchaseOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("CatagoryID");
        dt.Columns.Add("Catagory");
        dt.Columns.Add("ProductID");
        dt.Columns.Add("PO_Product_Description");
        dt.Columns.Add("Product");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Price");
        dt.Columns.Add("TotalPrice");
        dt.Columns.Add("TaxID");
        dt.Columns.Add("TaxAmount");
        dt.Columns.Add("STDFromDate");
        dt.Columns.Add("STDToDate");
        dt.Columns.Add("ExtndFrmDate");
        dt.Columns.Add("ExtndToDate");
        dt.Columns.Add("TotalAmountPrice");
        foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
            dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
            dr["PO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
            dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
            dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
            //added on 20/May/2017
            dr["STDFromDate"] = ((Label)gvRow.FindControl("LblStdFrmDate")).Text;
            dr["STDToDate"] = ((Label)gvRow.FindControl("LblStdToDate")).Text;
            dr["ExtndFrmDate"] = ((Label)gvRow.FindControl("LblExtndFrmDate")).Text;
            dr["ExtndToDate"] = ((Label)gvRow.FindControl("LblExtndToDate")).Text;
            // end
            dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dt.Rows.Add(dr);

        }
        dt.Rows[e.RowIndex].Delete();

        GvwPurchaseOrder.DataSource = dt;
        GvwPurchaseOrder.DataBind();
        this.GvwPurchaseOrder.Columns[1].Visible = false;
        this.GvwPurchaseOrder.Columns[3].Visible = false;
        this.GvwPurchaseOrder.Columns[9].Visible = false;
        double tt = 0.00;
        foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
            dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
            dr["PO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
            dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
            dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
            //added on 20/May/2017
            dr["STDFromDate"] = ((Label)gvRow.FindControl("LblStdFrmDate")).Text;
            dr["STDToDate"] = ((Label)gvRow.FindControl("LblStdToDate")).Text;
            dr["ExtndFrmDate"] = ((Label)gvRow.FindControl("LblExtndFrmDate")).Text;
            dr["ExtndToDate"] = ((Label)gvRow.FindControl("LblExtndToDate")).Text;
            // end
            dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;

            tt = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text) + tt;
        }
        LblSubTotal.Text = Math.Floor(tt + .49).ToString("0.00");
        // LblSubTotal.Text = tt.ToString();
        BindSubCategory();
        // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
        ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).Focus();
        int i = GvwPurchaseOrder.Rows.Count;
        if (i == 0)
        {
            AddFirstRow();
            BindSubCategory();
            WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse();
            //GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
        }
        if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
        {
            ProductDescVisibletrue();
            WarentyDateControlsvisibleFalse();
        }
        else
        {
            ProductDescVisibleFalse();
            WarentyDateControlsvisibleFalse();
        }


    }
    protected void GvwPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
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

                    TextBox TxtEditStdFrmDate = (TextBox)e.Row.FindControl("TxtEditStdFrmDate");
                    HiddenField HfdEditSTDFromDate = (HiddenField)e.Row.FindControl("HfdEditSTDFromDate");
                    TextBox TxtEditStdToDate = (TextBox)e.Row.FindControl("TxtEditStdToDate");
                    HiddenField HfdEditSTDToDate = (HiddenField)e.Row.FindControl("HfdEditSTDToDate");
                    TextBox TxtEditExtndFrmDate = (TextBox)e.Row.FindControl("TxtEditExtndFrmDate");
                    HiddenField HfdEditExtndFrmDate = (HiddenField)e.Row.FindControl("HfdEditExtndFrmDate");
                    TextBox TxtEditExtndToDate = (TextBox)e.Row.FindControl("TxtEditExtndToDate");
                    HiddenField HfdEditExtndToDate = (HiddenField)e.Row.FindControl("HfdEditExtndToDate");


                    DrpEditCatagory.SelectedValue = lblCatagoryId.Text;
                    BindProduct(e.Row);
                    DrpEditProduct.SelectedValue = LblProductID.Text;
                    TxtEdiDescription.Text = HfdEdiDescription.Value;
                    TxtEditQuantity.Text = HfdEditQuantity.Value;
                    TxtEditPrice.Text = HfdEditPrice.Value;

                    DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("P", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), 0, Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(DrpEditCatagory.SelectedValue));
                    DrpEditTaxType.Items.Clear();
                    DrpEditTaxType.DataSource = DTTax;
                    DrpEditTaxType.DataTextField = "TaxStructure";
                    DrpEditTaxType.DataValueField = "TaxMapID";
                    DrpEditTaxType.DataBind();
                    DrpEditTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));


                    DrpEditTaxType.SelectedValue = HfdEditTaxID.Value;
                    LblEditfttotalPrice.Text = HfdEditfttotalPrice.Value;
                    TxtEditStdFrmDate.Text = HfdEditSTDFromDate.Value;
                    TxtEditStdToDate.Text = HfdEditSTDToDate.Value;
                    TxtEditExtndFrmDate.Text = HfdEditExtndFrmDate.Value;
                    TxtEditExtndToDate.Text = HfdEditExtndToDate.Value;
                    //// DrpEditCatagory_SelectedIndexChanged(sender, e);

                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        EditProductDescVisibletrue(e.Row);
                    }
                    else
                    {
                        EditProductDescVisibleFalse(e.Row);
                    }
                    if (DrpEditCatagory.SelectedItem.Text.Trim() == "scanner with extended warranty" || DrpEditCatagory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                           DrpEditCatagory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || DrpEditCatagory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                           DrpEditCatagory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || DrpEditCatagory.SelectedItem.Text.Trim() == "AMC" || DrpEditCatagory.SelectedItem.Text.Trim() == "Rental Scanner" ||
                   DrpEditCatagory.SelectedItem.Text.Trim() == "Installation A4  Scanner Only" || DrpEditCatagory.SelectedItem.Text.Trim() == "Any other services(digitisation, or any other service)" || DrpEditCatagory.SelectedItem.Text.Trim() == "Software"
                    || DrpEditCatagory.SelectedItem.Text.Trim() == "Othersoftware" || DrpEditCatagory.SelectedItem.Text.Trim() == "One Time Support"
                           )
                    {
                        EditWarentyDateControlsvisibleTrue(e.Row);
                    }
                    else
                    {
                        EditWarentyDateControlsvisibleFalse(e.Row);
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
                        if (GvwPurchaseOrder.Rows.Count >= 0)
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

                LinkButton lnkDelete1 = (LinkButton)e.Row.FindControl("lnkLink");
                LinkButton lnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");
                if (TxtSpa.Text == "")
                {
                    // BtnAdd.Visible = true;
                    lnkDelete1.Visible = true; lnkEdit.Visible = true;
                }
                else
                {
                    // BtnAdd.Visible = false;
                    lnkDelete1.Visible = false; lnkEdit.Visible = false;
                }
            }
           

        }
        catch (Exception ex)
        {
        }
    }
    protected void GvwPurchaseOrder_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            //txtLoggedIn_Date.Attributes.Add("readonly", "readonly");
            
            if (e.CommandName == "Edited")
            {
                GridViewRow GVrow = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                if (ViewState["AddNewDataset"] != null)
                {
                    GvwPurchaseOrder.EditIndex = GVrow.RowIndex;                   

                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["AddNewDataset"];
                    GvwPurchaseOrder.DataSource = dt;
                    GvwPurchaseOrder.DataBind();
                    BindSubCategory();
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    WarentyDateControlsvisibleFalse();                  

                }
                else
                {
                    GvwPurchaseOrder.EditIndex = GVrow.RowIndex;
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["OriginalDataSet"];
                    GvwPurchaseOrder.DataSource = ds;
                    GvwPurchaseOrder.DataBind();
                    BindSubCategory();
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    WarentyDateControlsvisibleFalse();

                }
            }
            if (e.CommandName == "Canceled")
            {
                GridViewRow GVrow = (GridViewRow)((LinkButton)e.CommandSource).Parent.Parent;
                if (ViewState["AddNewDataset"] != null)
                {
                    GvwPurchaseOrder.EditIndex = -1;
                    DataTable dt = new DataTable();
                    dt = (DataTable)ViewState["AddNewDataset"];
                    GvwPurchaseOrder.DataSource = dt;
                    GvwPurchaseOrder.DataBind();
                    BindSubCategory();
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    WarentyDateControlsvisibleFalse();
                }
                else
                {
                    GvwPurchaseOrder.EditIndex = -1;
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["OriginalDataSet"];
                    GvwPurchaseOrder.DataSource = ds;
                    GvwPurchaseOrder.DataBind();
                    BindSubCategory();
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    WarentyDateControlsvisibleFalse();

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

                TextBox TxtStdFrmDate = ((TextBox)GVrow.FindControl("TxtEditStdFrmDate"));
                TextBox TxtStdToDate = ((TextBox)GVrow.FindControl("TxtEditStdToDate"));
                TextBox TxtExtndFrmDate = ((TextBox)GVrow.FindControl("TxtEditExtndFrmDate"));
                TextBox TxtExtndToDate = ((TextBox)GVrow.FindControl("TxtEditExtndToDate"));

                if (DrpSupplier.SelectedItem.Text.Trim() == "Others")
                {
                    if (ddlVendor.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Vendor.');</script>", false);
                        ddlVendor.Focus();
                        return;
                    }
                }

                if (ddlType.SelectedItem.Text.Trim() == "Scanners" || ddlType.SelectedItem.Text.Trim() == "Support" || ddlType.SelectedItem.Text.Trim() == "Software")
                {
                    if (ddlWarranty.SelectedIndex == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Warranty.');</script>", false);
                        ddlWarranty.Focus();
                        return;
                    }
                }
                if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedValue != "-1" && ddlTaxType.SelectedIndex != 0 && qty.Text != "" && UnitPrice.Text != "")
                {

                    if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                            ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                            ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC" || ddlCategory.SelectedItem.Text.Trim() == "One Time Support"
                            )
                    {
                        if (TxtStdFrmDate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Standerd Warranty From Date ..');</script>", false);
                            TxtStdFrmDate.Focus();
                            return;
                        }

                        if (TxtStdToDate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Standerd Warranty To Date ..');</script>", false);
                            TxtStdToDate.Focus();
                            return;
                        }
                        if (TxtStdFrmDate.Text != "" && TxtStdToDate.Text != "")
                        {
                            DateTime StdFrmDate = Convert.ToDateTime(TxtStdFrmDate.Text);
                            DateTime StdToDate = Convert.ToDateTime(TxtStdToDate.Text);
                            if (StdFrmDate > StdToDate)
                            {
                                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Standerd Warranty To Date Should be Greater Than Standerd Warranty From Date.');</script>", false);
                                TxtStdToDate.Focus();
                                return;
                            }
                        }
                    }
                    //narender added for product description 
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
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
                    dt.Columns.Add("CatagoryID");
                    dt.Columns.Add("Catagory");
                    dt.Columns.Add("ProductID");
                    dt.Columns.Add("PO_Product_Description");
                    dt.Columns.Add("Product");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Price");
                    dt.Columns.Add("TotalPrice");
                    dt.Columns.Add("TaxID");
                    dt.Columns.Add("TaxAmount");
                    dt.Columns.Add("STDFromDate");
                    dt.Columns.Add("STDToDate");
                    dt.Columns.Add("ExtndFrmDate");
                    dt.Columns.Add("ExtndToDate");
                    dt.Columns.Add("TotalAmountPrice");
                    DropDownList DrpProduct = (DropDownList)GVrow.FindControl("DrpEditProduct");
                    DropDownList DrpCatagory = (DropDownList)GVrow.FindControl("DrpEditCatagory");
                    foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
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
                                dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                                dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                                dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                                dr["PO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                                dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                                dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                                dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                                dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                                dr["STDFromDate"] = ((Label)gvRow.FindControl("LblStdFrmDate")).Text;
                                dr["STDToDate"] = ((Label)gvRow.FindControl("LblStdToDate")).Text;
                                dr["ExtndFrmDate"] = ((Label)gvRow.FindControl("LblExtndFrmDate")).Text;
                                dr["ExtndToDate"] = ((Label)gvRow.FindControl("LblExtndToDate")).Text;
                                dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                                dt.Rows.Add(dr);
                                SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                            }
                        }
                    }
                    DataRow dr1 = dt.NewRow();
                    dr1["CatagoryID"] = ((DropDownList)GVrow.FindControl("DrpEditCatagory")).SelectedValue.ToString();
                    dr1["Catagory"] = ((DropDownList)GVrow.FindControl("DrpEditCatagory")).SelectedItem.Text;
                    dr1["ProductID"] = ((DropDownList)GVrow.FindControl("DrpEditProduct")).SelectedValue.ToString();
                    dr1["PO_Product_Description"] = ((TextBox)GVrow.FindControl("TxtEditDescription")).Text;
                    dr1["Product"] = ((DropDownList)GVrow.FindControl("DrpEditProduct")).SelectedItem.Text;
                    dr1["Quantity"] = ((TextBox)GVrow.FindControl("TxtEditQuantity")).Text;
                    dr1["Price"] = ((TextBox)GVrow.FindControl("TxtEditPrice")).Text;

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
                    dr1["TotalPrice"] = Convert.ToInt32(((TextBox)GVrow.FindControl("TxtEditQuantity")).Text) * Convert.ToDouble(((TextBox)GVrow.FindControl("TxtEditPrice")).Text);
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

                    dr1["TaxAmount"] = Convert.ToString(TaxValue.ToString("0.00"));
                    dr1["TaxID"] = ((DropDownList)GVrow.FindControl("DrpEditTaxType")).SelectedValue.ToString();
                    dr1["STDFromDate"] = ((TextBox)GVrow.FindControl("TxtEditStdFrmDate")).Text;
                    dr1["STDToDate"] = ((TextBox)GVrow.FindControl("TxtEditStdToDate")).Text;
                    dr1["ExtndFrmDate"] = ((TextBox)GVrow.FindControl("TxtEditExtndFrmDate")).Text;
                    dr1["ExtndToDate"] = ((TextBox)GVrow.FindControl("TxtEditExtndToDate")).Text;
                    TotalAmount = Convert.ToDouble(lblSubTot) + TaxValue;
                    //Narender added for Round off TotalAmountPrice
                    //double TotalAmountRound = (double)Math.Floor(TotalAmount + .49);
                    //dr1["TotalAmountPrice"] = TotalAmountRound.ToString("0.00");
                    //SubTotal = SubTotal + TotalAmountRound;
                    dr1["TotalAmountPrice"] = TotalAmount.ToString("0.00");
                    SubTotal = SubTotal + TotalAmount;
                    dt.Rows.Add(dr1);
                    ViewState["AddNewDataset"] = dt;                 

                    GvwPurchaseOrder.EditIndex = -1;
                    GvwPurchaseOrder.DataSource = dt;
                    GvwPurchaseOrder.DataBind();
                    this.GvwPurchaseOrder.Columns[1].Visible = false;
                    this.GvwPurchaseOrder.Columns[3].Visible = false;
                    this.GvwPurchaseOrder.Columns[9].Visible = false;
                    this.GvwPurchaseOrder.Columns[8].Visible = true;
                   
                    // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
                    ((DropDownList)GVrow.FindControl("DrpEditCatagory")).Focus();
                    LblSubTotal.Text = Math.Floor(SubTotal + .49).ToString("0.00");
                    // LblSubTotal.Text = SubTotal.ToString("0.00");

                    BindSubCategory();
                    if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
                    {
                        ProductDescVisibletrue();
                    }
                    else
                    {
                        ProductDescVisibleFalse();
                    }
                    WarentyDateControlsvisibleFalse();

                }
                else
                {

                    if (ddlCategory.SelectedIndex == 0)
                    {
                        ddlCategory.Focus();
                    }
                    else if (ddlProduct.SelectedValue == "-1")
                    {
                        ddlProduct.Focus();
                    }
                    else if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
                    {
                        if (TxtDescription.Text == "")
                        {
                            TxtDescription.Focus();
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
                            lblFtTotal1.Text = Convert.ToString(Convert.ToInt32(qty.Text) * Convert.ToDouble(UnitPrice.Text));
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
                        lblFtTotal1.Text = Convert.ToString(Convert.ToInt32(qty.Text) * Convert.ToDouble(UnitPrice.Text));
                        ddlTaxType.Focus();
                    }

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill all required fields...');</script>", false);
                    return;
                }

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

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlType.SelectedValue));
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
   
    protected void DrpEditCatagory_SelectedIndexChanged(object sender,EventArgs e)
    {
        try
        {
           // GridViewRow row = null; DropDownList ddlCategory = null;

            DropDownList ddlCategory = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlCategory.Parent.Parent;
           
            if (ddlCategory.SelectedIndex != 0)
            {
                if (txtReason.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Reason For Purchase..');</script>", false);
                    return;
                }
                if (txtLoggedIn_Date.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Purchase Order Date..');</script>", false);
                    return;
                }
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
                DataTable DTProduct = BusinessServices.Get_PO_ProductOnCategory(Convert.ToInt32(DrpSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "-1"));

                ddlProduct.SelectedIndex = 0; txtQuantity.Text = ""; txtUnitPrice.Text = "";
                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("P", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), 0, Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
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

                if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC"
                   || ddlCategory.SelectedItem.Text.Trim() == "Rental Scanner" ||
                   ddlCategory.SelectedItem.Text.Trim() == "Installation A4  Scanner Only" || ddlCategory.SelectedItem.Text.Trim() == "Any other services(digitisation, or any other service)" || ddlCategory.SelectedItem.Text.Trim() == "Software"
                    || ddlCategory.SelectedItem.Text.Trim() == "Othersoftware" || ddlCategory.SelectedItem.Text.Trim() == "One Time Support"
                    )
                {
                    EditWarentyDateControlsvisibleTrue(row);
                }
                else
                {
                    EditWarentyDateControlsvisibleFalse(row);
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

    public void BindProduct(GridViewRow row)
    {
        try
        {
            DropDownList ddlCategory = null;                
                ddlCategory = (DropDownList)row.FindControl("DrpEditCatagory");
           
            if (ddlCategory.SelectedIndex != 0)
            {
                if (txtReason.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Reason For Purchase..');</script>", false);
                    return;
                }
                if (txtLoggedIn_Date.Text == "")
                {
                    ddlCategory.SelectedIndex = 0;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Select Purchase Order Date..');</script>", false);
                    return;
                }
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
                DataTable DTProduct = BusinessServices.Get_PO_ProductOnCategory(Convert.ToInt32(DrpSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlProduct.Items.Clear();
                ddlProduct.DataSource = DTProduct;
                ddlProduct.DataTextField = "Product";
                ddlProduct.DataValueField = "ID";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("--Select Product--", "-1"));

                ddlProduct.SelectedIndex = 0; txtQuantity.Text = ""; txtUnitPrice.Text = "";
                //Tax Structure Binding
                DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("P", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), 0, Convert.ToInt32(DrpSupplier.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlTaxType.Items.Clear();
                ddlTaxType.DataSource = DTTax;
                ddlTaxType.DataTextField = "TaxStructure";
                ddlTaxType.DataValueField = "TaxMapID";
                ddlTaxType.DataBind();
                ddlTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));

                if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC"
                    || ddlCategory.SelectedItem.Text.Trim() == "Rental Scanner" ||
                   ddlCategory.SelectedItem.Text.Trim() == "Installation A4  Scanner Only" || ddlCategory.SelectedItem.Text.Trim() == "Any other services(digitisation, or any other service)" || ddlCategory.SelectedItem.Text.Trim() == "Software"
                    || ddlCategory.SelectedItem.Text.Trim() == "Othersoftware" || ddlCategory.SelectedItem.Text.Trim() == "One Time Support"
                    )
                {
                    EditWarentyDateControlsvisibleTrue(row);
                }
                else
                {
                    EditWarentyDateControlsvisibleFalse(row);
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

    protected void BtnPurchaseOrderSave_Click(object sender, EventArgs e)
    {
        if (txtReason.Text != "" && DrpLocation.SelectedItem.Value != "-1" && DrpSupplier.SelectedItem.Value != "-1"
            && txt_PO_RaisedTo.Text != string.Empty && txtBillingAddress.Text != "" && txtShippingAddress.Text != "" && ddlType.SelectedValue != "0")
        {
            if (DrpSupplier.SelectedItem.Text.Trim() == "Others")
            {
                if (ddlVendor.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Vendor.');</script>", false);
                    ddlVendor.Focus();
                    return;
                }
            }

            if (ddlType.SelectedItem.Text.Trim() == "Scanners" || ddlType.SelectedItem.Text.Trim() == "Support" || ddlType.SelectedItem.Text.Trim() == "Software")
            {
                if (ddlWarranty.SelectedIndex == 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Warrant.');</script>", false);
                    ddlWarranty.Focus();
                    return;
                }
            }


            DropDownList DrpCatagory = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");
            DropDownList DrpProduct = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct");
            TextBox TxtQuantity = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity");
            TextBox TxtPrice = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice");
            DropDownList DrpTaxType = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType");



            if (DrpCatagory.SelectedValue != "0" && DrpProduct.SelectedValue != "" && TxtQuantity.Text != "" && TxtPrice.Text != "" && DrpTaxType.SelectedValue != "0" && DrpTaxType.SelectedValue != "")
            {
                if (TxtQuantity.Text != "" && TxtPrice.Text != "")
                {
                    Label LblfttotalPrice = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                    double lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text);
                    LblfttotalPrice.Text = lblSubTot.ToString("0.00");
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Click On Add Button...');</script>", false);

            }
            else
            {
                if (DrpCatagory.SelectedValue == "0" && DrpProduct.SelectedValue == "" && DrpProduct.SelectedValue != "-1" && TxtQuantity.Text == "" && TxtPrice.Text == "" && DrpTaxType.SelectedValue == "" && LblSubTotal.Text != "0.00" && LblSubTotal.Text != "" && LblSubTotal.Text != "0")
                {
                    try
                    {
                        ClsPurchaseOrder clsPurchase = new ClsPurchaseOrder();
                        DataTable dtPOSum = new DataTable();
                        dtPOSum.Columns.Add("PO_Date", typeof(DateTime));
                        dtPOSum.Columns.Add("PO_Reason", typeof(string));
                        dtPOSum.Columns.Add("PO_State_ID", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Location_ID", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Supplier_ID", typeof(Int64));
                        dtPOSum.Columns.Add("PO_NetAmount", typeof(double));
                        dtPOSum.Columns.Add("PO_EnteredBy", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Billing_TO", typeof(string));
                        dtPOSum.Columns.Add("PO_Shipping_TO", typeof(string));
                        dtPOSum.Columns.Add("PO_Raise_TO", typeof(string));
                        dtPOSum.Columns.Add("PO_MainCategoryId", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Vendor", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Warranty", typeof(Int64));
                        dtPOSum.Columns.Add("PO_Pending_Status", typeof(Int32));

                        DataRow drSum = dtPOSum.NewRow();
                        drSum["PO_Date"] = Convert.ToDateTime(txtLoggedIn_Date.Text);
                        drSum["PO_Reason"] = txtReason.Text.ToString();
                        drSum["PO_State_ID"] = ddlState.SelectedItem.Value.ToString();
                        drSum["PO_Location_ID"] = DrpLocation.SelectedItem.Value.ToString();
                        drSum["PO_Supplier_ID"] = DrpSupplier.SelectedItem.Value.ToString();
                        drSum["PO_NetAmount"] = LblSubTotal.Text;
                        drSum["PO_EnteredBy"] = Session["Id"].ToString();
                        drSum["PO_Billing_TO"] = txtBillingAddress.Text.ToString();
                        drSum["PO_Shipping_TO"] = txtShippingAddress.Text.ToString();
                        drSum["PO_Raise_TO"] = txt_PO_RaisedTo.Text;
                        drSum["PO_MainCategoryId"] = ddlType.SelectedValue.ToString();

                        if (ddlVendor.SelectedValue != "" && ddlVendor.SelectedValue != "0")
                        {
                            drSum["PO_Vendor"] = ddlVendor.SelectedValue.ToString();
                        }
                        else
                        {
                            drSum["PO_Vendor"] = 0;
                        }
                        if (ddlWarranty.SelectedValue != "" && ddlWarranty.SelectedValue != "0")
                        {
                            drSum["PO_Warranty"] = ddlWarranty.SelectedValue.ToString();
                        }
                        else
                        {
                            drSum["PO_Warranty"] = 0;
                        }

                        drSum["PO_Pending_Status"] = 1;
                        dtPOSum.Rows.Add(drSum);

                        DataTable dtPODet = new DataTable();

                        dtPODet.Columns.Add("CatagoryID", typeof(int));
                        dtPODet.Columns.Add("ProductID", typeof(int));
                        dtPODet.Columns.Add("PO_Product_Description", typeof(string));
                        dtPODet.Columns.Add("Quantity", typeof(int));
                        dtPODet.Columns.Add("Price", typeof(double));
                        dtPODet.Columns.Add("TotalPrice", typeof(double));
                        dtPODet.Columns.Add("TaxID", typeof(double));
                        dtPODet.Columns.Add("TaxAmount", typeof(double));

                        dtPODet.Columns.Add("STDFromDate", typeof(string));
                        dtPODet.Columns.Add("STDToDate", typeof(string));
                        dtPODet.Columns.Add("ExtndFrmDate", typeof(string));
                        dtPODet.Columns.Add("ExtndToDate", typeof(string));
                        dtPODet.Columns.Add("TotalAmountPrice", typeof(double));
                        dtPODet.Columns.Add("PendingQuantity", typeof(int));
                        foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
                        {
                            if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
                            {
                                DataRow drDet = dtPODet.NewRow();
                                drDet["CatagoryID"] = Convert.ToInt16(((Label)gvRow.FindControl("lblCatagoryID")).Text);
                                drDet["ProductID"] = Convert.ToInt16(((Label)gvRow.FindControl("LblProductID")).Text);
                                drDet["PO_Product_Description"] = Convert.ToString(((Label)gvRow.FindControl("LblDescription")).Text);
                                drDet["Quantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                                drDet["Price"] = Convert.ToDouble(((Label)gvRow.FindControl("LblPrice")).Text);
                                drDet["TotalPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);
                                drDet["TaxID"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxID")).Text);
                                drDet["TaxAmount"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxAmount")).Text);

                                drDet["STDFromDate"] = Convert.ToString(((Label)gvRow.FindControl("LblStdFrmDate")).Text);
                                drDet["STDToDate"] = Convert.ToString(((Label)gvRow.FindControl("LblStdToDate")).Text);
                                drDet["ExtndFrmDate"] = Convert.ToString(((Label)gvRow.FindControl("LblExtndFrmDate")).Text);
                                drDet["ExtndToDate"] = Convert.ToString(((Label)gvRow.FindControl("LblExtndToDate")).Text);

                                drDet["TotalAmountPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                                drDet["PendingQuantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                                dtPODet.Rows.Add(drDet);
                            }
                        }
                        DateTime podate = Convert.ToDateTime(txtLoggedIn_Date.Text.Trim());
                        int Result = clsPurchase.Update_PurchaseOrder_Rejected_PO_Details(lblPoNumber.Text.Trim(),podate, dtPOSum, dtPODet);
                        // AlertPageHelper.MessageBoxBeforeRedirect(this.Page, "Purchase Order Saved Successfully..", "PurchaseOrder.aspx"); 
                        if (Result > 0)
                        {
                            ClsPurchaseOrder objPO = new ClsPurchaseOrder();
                            objPO.Delete_PurchaseOrderTax_for_Rejected_PO_Details(lblPoNumber.Text.Trim());
                            foreach (GridViewRow gvRow in GvwPurchaseOrder.Rows)
                            {
                                int CategoryId = Convert.ToInt32(((Label)gvRow.FindControl("lblCatagoryID")).Text);
                                int ProductId = Convert.ToInt32(((Label)gvRow.FindControl("LblProductID")).Text);
                                int TaxMapID = Convert.ToInt32(((Label)gvRow.FindControl("LblTaxID")).Text);
                                double Price = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);
                                //int lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text);
                                DataTable DTTaxRate = new DataTable();
                                DTTaxRate = BusinessServices.GetTaxRateBaseValue(TaxMapID);
                                double TaxValue = 0;
                                if (DTTaxRate.Rows.Count > 0)
                                {                                   
                                    for (int i = 0; i <= DTTaxRate.Rows.Count - 1; i++)
                                    {
                                        int TaxNameId = Convert.ToInt32(DTTaxRate.Rows[i]["TaxNameId"].ToString());
                                        double TaxRate = Convert.ToDouble(DTTaxRate.Rows[i]["TaxRate"].ToString());
                                        double BaseValue = Convert.ToDouble(DTTaxRate.Rows[i]["BaseValue"].ToString());
                                        double SubTotonBaseVal = Convert.ToDouble(Price) * Convert.ToDouble(DTTaxRate.Rows[i][2].ToString()) / 100;
                                        TaxValue = (SubTotonBaseVal * Convert.ToDouble(DTTaxRate.Rows[i][1].ToString()) / 100);
                                        int POTaxResult = objPO.InsertPurchaseOrderTax_Rejected_PO_Details(lblPoNumber.Text.Trim(),CategoryId, ProductId, TaxMapID, TaxNameId, TaxRate, BaseValue, TaxValue);
                                    }

                                }
                            }
                        }
                        Panel1.Visible = false;Panel2.Visible = true; tbldate.Visible = true;
                        GetSalesManager();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Purchase Order Updated Successfully...');</script>", false);
                        
                    }
                    catch (Exception Ex)
                    {

                    }

                }
                else
                {
                    DropDownList DrpCatagory1 = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory");
                    DropDownList DrpProduct1 = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpProduct");
                    TextBox TxtDescription1 = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription");
                    TextBox TxtQuantity1 = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity");
                    TextBox TxtPrice1 = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice");
                    DropDownList DrpTaxType1 = (DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpTaxType");
                    if (DrpCatagory1.SelectedValue == "0")
                    {
                        DrpCatagory1.Focus();
                    }
                    else if (DrpProduct1.SelectedValue == "-1")
                    {
                        DrpProduct1.Focus();
                    }
                    else if (TxtDescription1.Text == "")
                    {
                        TxtDescription1.Focus();
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

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill the required Fields...');</script>", false);
                }
            }
        }
        else
        {
            TextBox TxtQuantity = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity");
            TextBox TxtPrice = (TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice");
            if (TxtQuantity.Text != "" && TxtPrice.Text != "")
            {
                Label LblfttotalPrice = (Label)GvwPurchaseOrder.FooterRow.FindControl("LblfttotalPrice");
                double lblSubTot = Convert.ToInt32(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToDouble(((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text);
                LblfttotalPrice.Text = lblSubTot.ToString("0.00");
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill the required Fields...');</script>", false);
        }
    }

    public void BindPurchaseTypee()
    {
        try
        {
            // DataTable dt = BusinessServices.Imaging_GetSalesType();
            DataTable dt = ClsMaster.GetMaster_purchasetype_dropdown();
            ddlPurchaseType.Items.Clear();
            ddlPurchaseType.DataSource = dt;
            ddlPurchaseType.DataTextField = "purchase_name";
            ddlPurchaseType.DataValueField = "ID";
            ddlPurchaseType.DataBind();

            ddlPurchaseType.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void chkShipping_CheckedChanged(object Sender, EventArgs e)
    {
        try
        {
            if (chkShipping.Checked == true)
            {
                txtShippingAddress.Text = txtBillingAddress.Text;
            }
            else
            {

                if (ViewState["LocShippingAdd"] != null)
                {
                    txtShippingAddress.Text = ViewState["LocShippingAdd"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void BtnClear_Click(object sender,EventArgs e)
    {
        try
        {
            chkShipping.Checked = false;
            string currentDate = GetDefaultEndDate();
            Txt_FromDate.Text = GetDefaultStartDate(Convert.ToDateTime(currentDate).AddDays(-120));
            Txt_ToDate.Text = currentDate;
            GetSalesManager();
            Panel2.Visible = true;
            Panel1.Visible = false;
            BindPurchaseTypee();
            txtReason.Text = "";
            txtBillingAddress.Text = "";
            txtShippingAddress.Text = "";
            txt_PO_RaisedTo.Text = "";
            ddlState.SelectedIndex = 0;
            DrpLocation.SelectedItem.Text = "--Select Location--";
            DrpSupplier.SelectedValue = "-1";
            BindMainCategory();
            ddlType.SelectedValue = "0";
            ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtPrice")).Text = "";
            ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtQuantity")).Text = "";
            BindSubCategory();
            //((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue = "0";
            AddFirstRow();
            //GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
            LblSubTotal.Text = "";
            WarentyDateControlsvisibleFalse(); ProductDescVisibleFalse();
            if (ddlType.SelectedItem.Text == "Scanners" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software")
            {
                tdwr.Visible = true;
                tdddlwr.Visible = true;
                LoadWarranty();
            }
            else
            {
                tdwr.Visible = false;
                tdddlwr.Visible = false;
            }
            if (DrpSupplier.SelectedItem.Text == "Others")
            {
                tdVndr.Visible = true; tdddlvndr.Visible = true; BindVendorName();
            }
            else
            {
                tdVndr.Visible = false; tdddlvndr.Visible = false;
            }
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental" || ddlType.SelectedItem.Text == "Any other services")
            {
                ProductDescVisibletrue();
            }
            else
            {
                ProductDescVisibleFalse();
            }
            TxtVatCst.Text = "";
            txtPaymentTerm.Text = "";
            txtTermsOfDelievery.Text = "";
            chkShipping.Checked = false;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}