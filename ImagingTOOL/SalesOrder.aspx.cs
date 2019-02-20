using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Sales_Order : System.Web.UI.Page
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
            txtSO_Date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            AddFirstRow();
            // GetMasterList("BillS", drp_Biiling);
            GetState();
            bindSalesType();
            LoadCreditPeriod();
            bindCustNames();
            //LoadWarranty();
           // GetMasterList("VE", DrpVertical);
            //GetMasterList("CU", DrpSupplier);           
            LoadType();
            bindRepresentativeOnLoc();
            // termsOfdelivery();
            ProductDescVisibleFalse(); FromToDatesvisibleFalse();
            // GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
            //  GVAdress.DataSource = fillDataTable(ClsSalesOrder.GetAddress());

            //  GVAdress.DataBind();

        }
        txtcustordDate.Attributes.Add("readonly", "true");
    }

    //Binding Cust on Vertical
    // Binding Location Dropdown on State Selection
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

    public void bindCustNames()
    {
        try
        {
            DataTable dt = BusinessServices.GetCustNames();
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
            if (dt.Rows.Count > 0)
            {
                DrpLocation.SelectedIndex = 1;
            }
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
        dt.Columns.Add("CatagoryID");
        dt.Columns.Add("Catagory");
        dt.Columns.Add("ProductID");
        dt.Columns.Add("CurntStock");
        dt.Columns.Add("SO_Product_Description");
        dt.Columns.Add("Product");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Price");
        dt.Columns.Add("TotalPrice");
        dt.Columns.Add("TaxID");
        dt.Columns.Add("TaxAmount");
        dt.Columns.Add("TotalAmountPrice");
        DataRow dr1 = dt.NewRow();
        dr1["sno"] = "";
        dr1["CatagoryID"] = "";
        dr1["Catagory"] = "";
        dr1["ProductID"] = "";
        dr1["CurntStock"] = "";
        dr1["SO_Product_Description"] = "";
        dr1["Product"] = "";
        dr1["FromDate"] = "";
        dr1["ToDate"] = "";
        dr1["Quantity"] = "";
        dr1["Price"] = "";
        dr1["TotalPrice"] = "";
        dr1["TaxID"] = "";
        dr1["TaxAmount"] = "";
        dr1["TotalAmountPrice"] = "";
        dt.Rows.Add(dr1);
        GvwSalesOrder.DataSource = dt;
        GvwSalesOrder.DataBind();
        this.GvwSalesOrder.Columns[1].Visible = false;
        this.GvwSalesOrder.Columns[3].Visible = false;
        this.GvwSalesOrder.Columns[12].Visible = false;
    }
    private DataTable fillDataTable(DataTable dt)
    {
        return dt;
    }
    //Binding Masters
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
    
    //public void AddNewGridRow(object sender, EventArgs e)
    //{

    //    Button BtnAdd = (Button)sender;
    //    GridViewRow row = (GridViewRow)BtnAdd.Parent.Parent;
    //    DropDownList ddlCategory = (DropDownList)row.Cells[0].FindControl("DrpCategory");
    //    DropDownList ddlProduct = (DropDownList)row.Cells[0].FindControl("DrpProduct");
    //    DropDownList ddlTaxType = (DropDownList)row.Cells[0].FindControl("DrpTaxType");
    //    if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedIndex != 0 && ddlTaxType.SelectedIndex != 0)

    //    {
    //        SubTotal = 0;
    //        TotalAmount = 0;

    //        DataTable dt = new DataTable();
    //        dt.Columns.Add("CatagoryID");
    //        dt.Columns.Add("Catagory");
    //        dt.Columns.Add("ProductID");
    //        dt.Columns.Add("Product");
    //        dt.Columns.Add("Quantity");
    //        dt.Columns.Add("Price");
    //        dt.Columns.Add("TotalPrice");
    //        dt.Columns.Add("TaxID");
    //        dt.Columns.Add("TaxAmount");
    //        dt.Columns.Add("TotalAmountPrice");
    //        foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
    //        {
    //            LinkButton LinkDelete = (LinkButton)gvRow.FindControl("lnkLink");
    //            LinkDelete.Visible = true;
    //            if (((Label)gvRow.FindControl("lblCatagory")).Text != "")
    //            {

    //                DataRow dr = dt.NewRow();
    //                dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
    //                dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
    //                dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
    //                dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
    //                dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
    //                dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
    //                dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
    //                dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
    //                dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
    //                dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
    //                dt.Rows.Add(dr);
    //                SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
    //            }
    //        }
    //        DataRow dr1 = dt.NewRow();
    //        dr1["CatagoryID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString();
    //        dr1["Catagory"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedItem.Text;
    //        dr1["ProductID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedValue.ToString();
    //        dr1["Product"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedItem.Text;
    //        dr1["Quantity"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text;
    //        dr1["Price"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text;
    //        if (((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text == "")
    //        {
    //            TextBox TxtQuan = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity");
    //            TxtQuan.Focus();
    //            return;
    //        }
    //        if (((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text == "")
    //        {
    //            TextBox TxtPrice = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice");
    //            TxtPrice.Focus();
    //            return;
    //        }
    //        dr1["TotalPrice"] = Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text);
    //        DataTable Ds = new DataTable();
    //        int TAX1 = Convert.ToInt32(((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString());

    //        Ds = ClsPurchaseOrder.getTax(TAX1);
    //        double TAX = Convert.ToDouble(Ds.Rows[0]["Percentage"].ToString());

    //        int catagoryid = Convert.ToInt32(((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString());

    //        if (catagoryid == 3 || catagoryid == 5 || catagoryid == 6 || catagoryid == 8)
    //        {
    //            // 70% of contract vaule

    //            if (TAX1 == 50 || TAX1 == 46)
    //            {

    //                dr1["TaxAmount"] = (((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 70) / 100)) * TAX / 100);
    //                dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
    //                TotalAmount = ((((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 70) / 100)) * TAX / 100) + (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)));
    //                dr1["TotalAmountPrice"] = TotalAmount;
    //                SubTotal = SubTotal + TotalAmount;
    //                dt.Rows.Add(dr1);
    //                GvwSalesOrder.DataSource = dt;
    //                GvwSalesOrder.DataBind();
    //                this.GvwSalesOrder.Columns[1].Visible = false;
    //                this.GvwSalesOrder.Columns[3].Visible = false;
    //                GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
    //                ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
    //                LblSubTotal.Text = SubTotal.ToString();
    //            }
    //            //60% of contract value
    //            else if (TAX1 == 51 || TAX1 == 52 || TAX1 == 47 || TAX1 == 48)
    //            {

    //                dr1["TaxAmount"] = (((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 60) / 100)) * TAX / 100);
    //                dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
    //                TotalAmount = ((((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 60) / 100)) * TAX / 100) + (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)));
    //                dr1["TotalAmountPrice"] = TotalAmount;
    //                SubTotal = SubTotal + TotalAmount;
    //                dt.Rows.Add(dr1);
    //                GvwSalesOrder.DataSource = dt;
    //                GvwSalesOrder.DataBind();
    //                this.GvwSalesOrder.Columns[1].Visible = false;
    //                this.GvwSalesOrder.Columns[3].Visible = false;
    //                GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
    //                ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
    //                LblSubTotal.Text = SubTotal.ToString();
    //            }
    //            else if (TAX1 == 45 || TAX1 == 49)
    //            {

    //                dr1["TaxAmount"] = (((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 100) / 100)) * TAX / 100);
    //                dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
    //                TotalAmount = ((((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * 100) / 100)) * TAX / 100) + (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)));
    //                dr1["TotalAmountPrice"] = TotalAmount;
    //                SubTotal = SubTotal + TotalAmount;
    //                dt.Rows.Add(dr1);
    //                GvwSalesOrder.DataSource = dt;
    //                GvwSalesOrder.DataBind();
    //                this.GvwSalesOrder.Columns[1].Visible = false;
    //                this.GvwSalesOrder.Columns[3].Visible = false;
    //                GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
    //                ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
    //                LblSubTotal.Text = SubTotal.ToString();
    //            }

    //            else
    //            {
    //                dr1["TaxAmount"] = ((Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * TAX) / 100;
    //                dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
    //                TotalAmount = ((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * TAX) / 100) + (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)));
    //                dr1["TotalAmountPrice"] = TotalAmount;
    //                SubTotal = SubTotal + TotalAmount;
    //                dt.Rows.Add(dr1);
    //                GvwSalesOrder.DataSource = dt;
    //                GvwSalesOrder.DataBind();
    //                this.GvwSalesOrder.Columns[1].Visible = false;
    //                this.GvwSalesOrder.Columns[3].Visible = false;
    //                GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
    //                ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
    //                LblSubTotal.Text = SubTotal.ToString();
    //            }

    //        }
    //        else
    //        {
    //            dr1["TaxAmount"] = ((Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * TAX) / 100;
    //            dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
    //            TotalAmount = ((((Convert.ToDouble(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text)) * (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)) * TAX) / 100) + (Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text) * Convert.ToInt32(((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text)));
    //            dr1["TotalAmountPrice"] = TotalAmount;
    //            SubTotal = SubTotal + TotalAmount;
    //            dt.Rows.Add(dr1);
    //            GvwSalesOrder.DataSource = dt;
    //            GvwSalesOrder.DataBind();
    //            this.GvwSalesOrder.Columns[1].Visible = false;
    //            this.GvwSalesOrder.Columns[3].Visible = false;
    //            GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
    //            ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
    //            LblSubTotal.Text = SubTotal.ToString();
    //        }

    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please fill the required Fields...');</script>", false);

    //    }
    //}

    protected void GvwPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GvwPurchaseOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        DataTable dt = new DataTable();
        dt.Columns.Add("CatagoryID");
        dt.Columns.Add("Catagory");
        dt.Columns.Add("ProductID");
        dt.Columns.Add("CurntStock");
        dt.Columns.Add("SO_Product_Description");
        dt.Columns.Add("Product");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        dt.Columns.Add("Quantity");
        dt.Columns.Add("Price");
        dt.Columns.Add("TotalPrice");
        dt.Columns.Add("TaxID");
        dt.Columns.Add("TaxAmount");
        dt.Columns.Add("TotalAmountPrice");
        foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
            dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
            dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
            dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
            dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
            dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
            dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
            dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
            dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
            dt.Rows.Add(dr);

        }
        dt.Rows[e.RowIndex].Delete();

        GvwSalesOrder.DataSource = dt;
        GvwSalesOrder.DataBind();
        this.GvwSalesOrder.Columns[1].Visible = false;
        this.GvwSalesOrder.Columns[3].Visible = false;
        this.GvwSalesOrder.Columns[12].Visible = false;
        double tt = 0.00;
        foreach (GridViewRow gvRow in GvwSalesOrder.Rows)
        {
            DataRow dr = dt.NewRow();
            dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
            dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
            dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
            dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
            dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
            dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
            dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
            dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
            dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
            dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
            dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
            dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
            dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
            dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;

            tt = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text) + tt;
        }
       // LblSubTotal.Text = Math.Floor(tt + .49).ToString("0.00");
        LblSubTotal.Text = tt.ToString("0.00");
        BindSubCategory();
        //GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
        ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
        int i = GvwSalesOrder.Rows.Count;
        if (i == 0)
        {
            AddFirstRow();
            BindSubCategory();
            //  GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
        }
        //narender added for product description   
        if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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
    protected void BtnPurchaseOrderSave_Click(object sender, EventArgs e)
    {

    }
    protected void BtnPurchaseOrderClear_Click(object sender, EventArgs e)
    {
        Clear();
        GridDDlClear();
        //narender added for product description   
        if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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
    private void Clear()
    {
        LblSubTotal.Text = "0";
        GetMasterList("VE", DrpVertical);        
        DrpVertical.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlSalesType.SelectedIndex = 0;
        txtVertical.Text = "";
        DrpLocation.Items.Clear();
        ddltype.SelectedIndex = 0;
        ddlRepresentative.SelectedIndex = 0;
        // ddlRepresentative.Items.Clear();
        DrpSupplier.SelectedIndex = 0;
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
    protected void BtnPurchaseOrderSave_Click1(object sender, EventArgs e)
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

                    DataTable dtPODetMail = new DataTable();

                    dtPODetMail.Columns.Add("CatagoryName", typeof(string));
                    dtPODetMail.Columns.Add("ProductName", typeof(string));
                    //dtPODetMail.Columns.Add("SO_Product_Description", typeof(string));
                    //dtPODetMail.Columns.Add("FromDate", typeof(string));
                    //dtPODetMail.Columns.Add("ToDate", typeof(string));
                    dtPODetMail.Columns.Add("Current_Stock", typeof(int));
                    dtPODetMail.Columns.Add("Quantity", typeof(int));
                    //dtPODetMail.Columns.Add("Price", typeof(double));
                    //dtPODetMail.Columns.Add("TotalPrice", typeof(double));                  
                    //dtPODetMail.Columns.Add("TaxAmount", typeof(double));
                    //dtPODetMail.Columns.Add("TotalAmountPrice", typeof(double));


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
                            int GivenQuantity = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                            int Current_Stock = Convert.ToInt16(((Label)gvRow.FindControl("lblCurntStock")).Text);
                            if (Current_Stock < GivenQuantity)
                            {
                                DataRow drDetMail = dtPODetMail.NewRow();
                                drDetMail["CatagoryName"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                                drDetMail["ProductName"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                                // drDetMail["SO_Product_Description"] = Convert.ToString(((Label)gvRow.FindControl("LblDescription")).Text);
                                //drDetMail["FromDate"] = Convert.ToString(((Label)gvRow.FindControl("LblFrmDate")).Text);
                                //drDetMail["ToDate"] = Convert.ToString(((Label)gvRow.FindControl("LblToDate")).Text);
                                drDetMail["Current_Stock"] = Convert.ToInt16(((Label)gvRow.FindControl("lblCurntStock")).Text);
                                drDetMail["Quantity"] = Convert.ToInt16(((Label)gvRow.FindControl("LblQuantity")).Text);
                                //drDetMail["Price"] = Convert.ToDouble(((Label)gvRow.FindControl("LblPrice")).Text);
                                //drDetMail["TotalPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalPrice")).Text);                               
                                //drDetMail["TaxAmount"] = Convert.ToDouble(((Label)gvRow.FindControl("LblTaxAmount")).Text);
                                //drDetMail["TotalAmountPrice"] = Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                                dtPODetMail.Rows.Add(drDetMail);
                            }

                        }
                    }
                    int Result = clsSalses.InsertSalesOrder(dtPOSum, dtPODet, "", dtSOTAX, txtBillingAddress.Text.Trim(), txtShippingAddress.Text.Trim(), TxtTermsOfDelivery.Text.Trim());

                    int CustResult = clsSalses.InsertCustomerAddress(Convert.ToInt32(DrpSupplier.SelectedValue), txtBillingAddress.Text.Trim(), txtShippingAddress.Text.Trim());

                    if (ddltype.SelectedValue != "3" && ddltype.SelectedValue != "4" && ddltype.SelectedValue != "6" && ddltype.SelectedValue != "7")
                    {
                        if (dtPODetMail.Rows.Count > 0)
                        {
                            int SentMailResult = clsSalses.Send_Mail_ZeroStock_So_ProductDetails(dtPODetMail, ddlState.SelectedItem.Text.Trim(), DrpLocation.SelectedItem.Text.Trim());
                        }
                    }


                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Sales Order Saved Successfully...');</script>", false);


                    Clear();
                    GridDDlClear();
                    ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).Focus();
                    ProductDescVisibleFalse();
                    FromToDatesvisibleFalse();
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
    //private string getErrorIDString()
    //{
    //    string conString = null;

    //    foreach (GridViewRow row in GVAdress.Rows)
    //    {
    //        if (((CheckBox)row.FindControl("chkError")).Checked)
    //        {


    //            string id = GVAdress.DataKeys[row.RowIndex].Value.ToString();
    //            if (conString != null) conString += "," + id;
    //            else conString = id;
    //        }
    //    }
    //    return conString;
    //}

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

    //protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        ClsPurchaseOrder clsPurchase = new ClsPurchaseOrder();
    //       // GetMasterList("SU", DrpSupplier);
    //        if (DrpLocation.SelectedValue != "-1")
    //        {
    //            DataTable Dt = clsPurchase.getBSAddres(int.Parse(DrpLocation.SelectedValue));
    //            if (Dt.Rows.Count > 0)
    //            {
    //                txtBillingAddress.Text = Dt.Rows[0]["BillingAddress"].ToString();
    //                txtShippingAddress.Text = Dt.Rows[0]["ShippingAddress"].ToString();
    //            }
    //        }
    //        else
    //        {
    //            txtBillingAddress.Text = "";
    //            txtShippingAddress.Text = "";
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }

    //}

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
            GetState();
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

                    GetMasterList("VE", DrpVertical);
                    if (Dt.Rows[0]["VerticalId"].ToString() != "")
                    {
                        DrpVertical.SelectedValue = Dt.Rows[0]["VerticalId"].ToString();
                    }
                    else
                    {

                        GetMasterList("VE", DrpVertical);
                    }

                    bindRepresentativeOnLoc();
                    if (Dt.Rows[0]["RepresentativeId"].ToString() != "")
                    {
                        ddlRepresentative.SelectedValue = Dt.Rows[0]["RepresentativeId"].ToString();
                    }
                    else
                    {                      
                        bindRepresentativeOnLoc();
                    }
                   
                }
            }
            
            ViewState["LocShippingAdd"] = txtShippingAddress.Text;
            ViewState["LocBillingAdd"] = txtBillingAddress.Text;
            ddlState_SelectedIndexChanged(sender, e);
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
                if (TxtCustState.Text != "" && ddlState.SelectedValue != "0")
                {
                    if (TxtCustState.Text.Trim() == ddlState.SelectedItem.Text.Trim())
                    {
                        ddlSalesType.SelectedValue = "1";
                    }
                    else
                    {
                        ddlSalesType.SelectedValue = "2";
                    }
                }
                else
                {
                    ddlSalesType.SelectedValue = "0";
                }
                DrpLocation_SelectedIndexChanged(sender, e);
            }
            else
            {

                DrpLocation.Items.Clear();
                ddlSalesType.SelectedValue = "0";
            }
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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
            Label lblCurntStock = (Label)row.FindControl("lblFtCurntStock");
            lblCurntStock.Text = "";
        }
        catch (Exception ex)
        { throw ex; }
    }
    protected void TxtPrice_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlSalesType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalesType.SelectedIndex != 0)
        {
            GridDDlClear();
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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
    private void GridDDlClear()
    {
        LblSubTotal.Text = "";

        AddFirstRow();
        BindSubCategory();
        // GetMasterList("CA", ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")));
        //DropDownList ddlCategory = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory");
        //DropDownList ddlProduct = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct");
        //DropDownList ddlTaxType = (DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType");
        //TextBox TxtQuantity = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity");
        //TextBox TxtPrice = (TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice");
        //if (ddlCategory.SelectedIndex != 0)
        //{
        //    ddlProduct.Items.Clear(); ddlTaxType.Items.Clear();TxtQuantity.Text = "";TxtPrice.Text = ""; 
        //}

        //ddlCategory.SelectedIndex = 0;


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
        Label lblFtCurntStock = (Label)row.FindControl("lblFtCurntStock");
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
            dt.Columns.Add("CatagoryID");
            dt.Columns.Add("Catagory");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("CurntStock");
            dt.Columns.Add("SO_Product_Description");
            dt.Columns.Add("Product");
            dt.Columns.Add("FromDate");
            dt.Columns.Add("ToDate");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Price");
            dt.Columns.Add("TotalPrice");
            dt.Columns.Add("TaxID");
            dt.Columns.Add("TaxAmount");
            dt.Columns.Add("TotalAmountPrice");
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
                    dr["CatagoryID"] = ((Label)gvRow.FindControl("lblCatagoryID")).Text;
                    dr["Catagory"] = ((Label)gvRow.FindControl("lblCatagory")).Text;
                    dr["ProductID"] = ((Label)gvRow.FindControl("LblProductID")).Text;
                    dr["CurntStock"] = ((Label)gvRow.FindControl("lblCurntStock")).Text;
                    dr["SO_Product_Description"] = ((Label)gvRow.FindControl("LblDescription")).Text;
                    dr["Product"] = ((Label)gvRow.FindControl("LblProduct")).Text;
                    dr["FromDate"] = ((Label)gvRow.FindControl("LblFrmDate")).Text;
                    dr["ToDate"] = ((Label)gvRow.FindControl("LblToDate")).Text;
                    dr["Quantity"] = ((Label)gvRow.FindControl("LblQuantity")).Text;
                    dr["Price"] = ((Label)gvRow.FindControl("LblPrice")).Text;
                    dr["TotalPrice"] = ((Label)gvRow.FindControl("LbltotalPrice")).Text;
                    dr["TaxID"] = ((Label)gvRow.FindControl("LblTaxID")).Text;
                    dr["TaxAmount"] = ((Label)gvRow.FindControl("LblTaxAmount")).Text;
                    dr["TotalAmountPrice"] = ((Label)gvRow.FindControl("LbltotalAmount")).Text;
                    dt.Rows.Add(dr);
                    SubTotal = SubTotal + Convert.ToDouble(((Label)gvRow.FindControl("LbltotalAmount")).Text);
                }
            }
            DataRow dr1 = dt.NewRow();
            dr1["CatagoryID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedValue.ToString();
            dr1["Catagory"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpCatagory")).SelectedItem.Text;
            dr1["ProductID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedValue.ToString();
            dr1["CurntStock"] = ((Label)GvwSalesOrder.FooterRow.FindControl("lblFtCurntStock")).Text;
            dr1["SO_Product_Description"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtDescription")).Text;
            dr1["Product"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpProduct")).SelectedItem.Text;
            dr1["FromDate"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtFrmDate")).Text;
            dr1["ToDate"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtToDate")).Text;
            dr1["Quantity"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtQuantity")).Text;
            dr1["Price"] = ((TextBox)GvwSalesOrder.FooterRow.FindControl("TxtPrice")).Text;
            dr1["TotalPrice"] = Convert.ToString(Convert.ToDouble(qty.Text) * Convert.ToDouble(UnitPrice.Text));
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


            dr1["TaxAmount"] = Convert.ToString(TaxValue);
            dr1["TaxID"] = ((DropDownList)GvwSalesOrder.FooterRow.FindControl("DrpTaxType")).SelectedValue.ToString();
            TotalAmount = SubTot + TaxValue;
            dr1["TotalAmountPrice"] = TotalAmount.ToString("0.00");
            SubTotal = SubTotal + TotalAmount;
            dt.Rows.Add(dr1);
            GvwSalesOrder.DataSource = dt;
            GvwSalesOrder.DataBind();
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
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                if (dt.Rows.Count > 0)
                {
                    GvwSalesOrder.Rows[i].Cells[5].BackColor = System.Drawing.Color.Yellow;
                }
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
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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


    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DrpLocation.SelectedIndex != 0)
        {
            GridDDlClear();
           // bindRepresentativeOnLoc(Convert.ToInt32(DrpLocation.SelectedValue));
            //narender added for product description   
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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

    protected void GvwSalesOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
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
        catch (Exception ex)
        {
        }

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
            if (ddltype.SelectedItem.ToString() == "Scanners" || ddltype.SelectedItem.Text == "Service" || ddltype.SelectedItem.Text == "Support" || ddltype.SelectedItem.Text == "Software" || ddltype.SelectedItem.Text == "Rental" || ddltype.SelectedItem.ToString() == "Any other services")
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

            if (ddltype.SelectedValue == "3" || ddltype.SelectedValue == "4" || ddltype.SelectedValue == "6" || ddltype.SelectedValue == "7")
            {
                GvwSalesOrder.Columns[5].Visible = false;
            }
            else
            {
                GvwSalesOrder.Columns[5].Visible = true;
            }

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

    protected void ddlBillingAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            
            if (ddlBillingAddress.SelectedValue != "0")
            {
                // txtBillingAddress.Text = "";
                txtBillingAddress.Text = ddlBillingAddress.SelectedItem.Text.ToString();
            }
            else
            {
                txtBillingAddress.Text = ViewState["LocBillingAdd"].ToString();
            }
            if(CheckBox1.Checked==true)
            {
                txtShippingAddress.Text = txtBillingAddress.Text;

            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    protected void ddlShippingAddress_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox1.Checked = false;
            if (ddlShippingAddress.SelectedValue != "0")
            {
                // txtShippingAddress.Text = "";
                txtShippingAddress.Text = ddlShippingAddress.SelectedItem.Text.ToString();
            }
            else
            {
                txtShippingAddress.Text = ViewState["LocShippingAdd"].ToString();

            }
        }
        catch (Exception ex)
        {

            throw;
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
            TextBox TxtQuantity1 = (TextBox)row.FindControl("TxtQuantity");
            if (ddlProduct.SelectedItem.Text== "-FREIGHT CHARGES")
            {
                TxtQuantity1.Text = "1";
                TxtQuantity1.Enabled = false;
            }
            else
            {
                TxtQuantity1.Text = "";
                TxtQuantity1.Enabled = true;
            }
        }
        catch (Exception ex)
        {

            throw;
        }
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
}