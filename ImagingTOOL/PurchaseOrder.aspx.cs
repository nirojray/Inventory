using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using BusinessLogicLayer;
using System.Web.Services;

public partial class PurchaseOrder : System.Web.UI.Page
{
    double SubTotal;
    double Total;
    double TotalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtLoggedIn_Date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            GetState();
            AddFirstRow();
            // GetMasterList("Bill", drp_Biiling);
            // GetMasterList("Ship", drp_Shipping);
            // GetMasterList("LO", DrpLocation);
            //GetMasterList("RP", DrpReason);            
            GetMasterList("SU", DrpSupplier);
            BindMainCategory();
           // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
            txtBillingAddress.Text = "";
            txtShippingAddress.Text = "";
           
            tdwr.Visible = false;
            tdddlwr.Visible = false;
            tdVndr.Visible = false; tdddlvndr.Visible = false;
            //this.GvwPurchaseOrder.Columns[10].Visible = false;
            WarentyDateControlsvisibleFalse();
            ProductDescVisibleFalse();

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "hide('popDiv')", true);
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "hide('popDiv1')", true);
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
            if(ddlWarranty.SelectedIndex==0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('please select Warranty.');</script>", false);
                ddlWarranty.Focus();
                return;
            }
        }

        
       
       if (ddlCategory.SelectedIndex != 0 && ddlProduct.SelectedValue !="-1" && ddlTaxType.SelectedIndex != 0 && qty.Text != "" && UnitPrice.Text != "")
        {

            if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)" || ddlCategory.SelectedItem.Text.Trim() == "AMC"
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

            }
            //narender added for product description 
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
            {
                if(TxtDescription.Text=="")
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
                    string ItemProduct = ((Label)gvRow.FindControl("lblCatagory")).Text + "_" + ((Label)gvRow.FindControl("LblProduct")).Text  ;
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
            dr1["PO_Product_Description"]= ((TextBox)GvwPurchaseOrder.FooterRow.FindControl("TxtDescription")).Text;
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
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
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
    private void GridDDlClear()
    {
        LblSubTotal.Text = "";
        AddFirstRow();
        BindSubCategory();
       // GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));

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
       int i= GvwPurchaseOrder.Rows.Count;
        if (i == 0)
        {
            AddFirstRow();
            BindSubCategory();
            WarentyDateControlsvisibleFalse();ProductDescVisibleFalse();
            //GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
        }
        if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
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
    protected void BtnPurchaseOrderSave_Click(object sender, EventArgs e)
    {
        if (txtReason.Text!="" && DrpLocation.SelectedItem.Value != "-1" && DrpSupplier.SelectedItem.Value != "-1" 
            && txt_PO_RaisedTo.Text != string.Empty && txtBillingAddress.Text != "" && txtShippingAddress.Text != "" && ddlType.SelectedValue!="0")
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
                if (DrpCatagory.SelectedValue == "0" && DrpProduct.SelectedValue == "" && DrpProduct.SelectedValue != "-1" && TxtQuantity.Text == "" && TxtPrice.Text == "" &&  DrpTaxType.SelectedValue == "" && LblSubTotal.Text != "0.00" && LblSubTotal.Text != "" && LblSubTotal.Text != "0")
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
                        int Result = clsPurchase.InsertPurchaseOrder(podate, dtPOSum, dtPODet,"","","");
                        // AlertPageHelper.MessageBoxBeforeRedirect(this.Page, "Purchase Order Saved Successfully..", "PurchaseOrder.aspx"); 
                        if (Result > 0)
                        {
                            ClsPurchaseOrder objPO = new ClsPurchaseOrder();

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
                                        int POTaxResult = objPO.InsertPurchaseOrderTax(CategoryId, ProductId, TaxMapID, TaxNameId, TaxRate, BaseValue, TaxValue);
                                    }

                                }
                            }
                        }
                        //Response.Redirect("PurchaseOrder.aspx");
                        //AddFirstRow();
                        AddFirstRow();
                        BindSubCategory();
                        //GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
                        LblSubTotal.Text = "0";
                        //drp_Biiling.SelectedValue = "-1";
                        // drp_Shipping.SelectedValue = "-1";
                        txt_PO_RaisedTo.Text = "";
                        txtReason.Text = "";
                        GetState();
                        ddlState.SelectedValue = "0";
                        ddlState_SelectedIndexChanged(sender, e);
                        //DrpReason.SelectedValue = "-1";
                        //GetMasterList("LO", DrpLocation);
                        //GetMasterList("RP", DrpReason);
                        GetMasterList("SU", DrpSupplier);
                        DrpLocation.SelectedValue = "-1";
                        DrpSupplier.SelectedValue = "-1";
                        ddlType.SelectedValue = "0";
                        txtBillingAddress.Text = "";
                        txtShippingAddress.Text = "";
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
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Purchase Order Saved Successfully...');</script>", false);
                        //GetMasterList("CA", ((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")));
                        //((DropDownList)GvwPurchaseOrder.FooterRow.FindControl("DrpCatagory")).Focus();

                        //GetMasterList("Bill", drp_Biiling);
                        //GetMasterList("Ship", drp_Shipping);
                        //GetMasterList("LO", DrpLocation);
                        //GetMasterList("RP", DrpReason);
                        //GetMasterList("SU", DrpSupplier);
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
                    else if(DrpProduct1.SelectedValue == "-1")
                    {
                        DrpProduct1.Focus();
                    }
                    else if(TxtDescription1.Text=="")
                    {
                        TxtDescription1.Focus();
                    }
                    else if (TxtQuantity1.Text == "")
                    {
                        TxtQuantity1.Focus();
                    }
                    else if(TxtPrice1.Text=="")
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
    protected void GvwPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnPurchaseOrderClear_Click(object sender, EventArgs e)
    {

        txtReason.Text = "";
        txtBillingAddress.Text = "";
        txtShippingAddress.Text = "";
        txt_PO_RaisedTo.Text = "";
        ddlState.SelectedIndex = 0;
        DrpLocation.SelectedItem.Text= "--Select Location--";
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
        if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
        {
            ProductDescVisibletrue();
        }
        else
        {
            ProductDescVisibleFalse();        
        }

    }
    protected void GvwPurchaseOrder_RowDataBound(object sender, GridViewRowEventArgs e)
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
           
        }
        catch (Exception ex)
        {
        }
    }
    protected void DrpLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            GridDDlClear();
            ClsPurchaseOrder clsPurchase = new ClsPurchaseOrder();
            GetMasterList("SU", DrpSupplier);
            if (DrpLocation.SelectedValue != "-1")
            {
                DataTable Dt = clsPurchase.getBSAddres(int.Parse(DrpLocation.SelectedValue));
                if (Dt.Rows.Count > 0)
                {
                    txtBillingAddress.Text = Dt.Rows[0]["BillingAddress"].ToString();
                    txtShippingAddress.Text = Dt.Rows[0]["ShippingAddress"].ToString();
                    LblSubTotal.Text = "0.00";
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
                TextBox txtQuantity= (TextBox)row.Cells[0].FindControl("TxtQuantity");
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
                  DataTable DTTax = BusinessServices.Imaging_GetTaxStructurebasedonselection("P", Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(DrpLocation.SelectedValue), 0, Convert.ToInt32(DrpSupplier.SelectedValue), Convert.ToInt32(ddlCategory.SelectedValue));
                ddlTaxType.Items.Clear();
                ddlTaxType.DataSource = DTTax;
                ddlTaxType.DataTextField = "TaxStructure";
                ddlTaxType.DataValueField = "TaxMapID";
                ddlTaxType.DataBind();
                ddlTaxType.Items.Insert(0, new ListItem("--Select Tax Type--", "0"));

                if (ddlCategory.SelectedItem.Text.Trim() == "scanner with extended warranty" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 2 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 3 YEARS" || ddlCategory.SelectedItem.Text.Trim() == "EXTENDED WARRRANTY FOR 4 YEARS" ||
                    ddlCategory.SelectedItem.Text.Trim() == "RTB Warranty To Onsite Conversion(A4 Scanners Only)"|| ddlCategory.SelectedItem.Text.Trim() == "AMC"
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
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
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
            if (ddlType.SelectedItem.Text == "Service" || ddlType.SelectedItem.Text == "Support" || ddlType.SelectedItem.Text == "Software" || ddlType.SelectedItem.Text == "Rental")
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

}