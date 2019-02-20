using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BusinessLogicLayer;


public partial class TaxRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          //  GetState();
          //  bindCategory();
           // GetMasterList("SU", ddlPurchaseType);
           // bindSalesType();
            BindTaxName_TaxRate();
            BindTaxRateGrid();
        }
    }
    //Binding State Dropdown
    //private void GetState()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        dt = BusinessServices.BindState();
    //        ddlState.Items.Clear();
    //        ddlState.DataSource = dt;
    //        ddlState.DataTextField = "State_Name";
    //        ddlState.DataValueField = "State_ID";
    //        ddlState.DataBind();
    //        ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}
    //Binding Tax Name

    private void BindTaxName_TaxRate()
    {
        DataTable dt = new DataTable();
        try
        {
            dt = BusinessServices.BindTaxName_TaxRate();
            ddlTaxName.Items.Clear();
            ddlTaxName.DataSource = dt;
            ddlTaxName.DataTextField = "TaxName";
            ddlTaxName.DataValueField = "TaxNameId";
            ddlTaxName.DataBind();
            ddlTaxName.Items.Insert(0, new ListItem("--Select Tax Name--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    //Binding Category Dropdown
    //public void bindCategory()
    //{
    //    try
    //    {
    //        DataTable dt = BusinessServices.Imaging_Get_Category();
    //        ddlcategory.Items.Clear();
    //        ddlcategory.DataSource = dt;
    //        ddlcategory.DataTextField = "Category_Name";
    //        ddlcategory.DataValueField = "Category_ID";
    //        ddlcategory.DataBind();

    //        ddlcategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    //private void GetMasterList(string Type, DropDownList DrpList)
    //{
    //    try
    //    {
    //        ClsMaster ClsMas = new ClsMaster();
    //        DataTable DT = new DataTable();
    //        DrpList.Items.Clear();
    //        DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
    //        DrpList.DataSource = DT;
    //        DrpList.DataValueField = "ID";
    //        DrpList.DataTextField = "NAME";
    //        DrpList.DataBind();
    //        DrpList.Items.Insert(0, new ListItem("--Select Purchase Type--", "0"));
    //    }
    //    catch (Exception Ex)
    //    {

    //    }
    //}
    //public void bindSalesType()
    //{
    //    try
    //    {
    //        DataTable dt = BusinessServices.Imaging_GetSalesType();
    //        ddlSalesType.Items.Clear();
    //        ddlSalesType.DataSource = dt;
    //        ddlSalesType.DataTextField = "SalesType";
    //        ddlSalesType.DataValueField = "Id";
    //        ddlSalesType.DataBind();

    //        ddlSalesType.Items.Insert(0, new ListItem("--Select Sales Type--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //public void bindLocationOnState(int StateID, string Type)
    //{
    //    try
    //    {
    //        DataTable dt = BusinessServices.Imaging_GetLocationOnState(StateID, Type);
    //        ddlLocation.Items.Clear();
    //        ddlLocation.DataSource = dt;
    //        ddlLocation.DataTextField = "Location_Name";
    //        ddlLocation.DataValueField = "Location_ID";
    //        ddlLocation.DataBind();

    //        ddlLocation.Items.Insert(0, new ListItem("--Select Location--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    if (ddlState.SelectedIndex != 0 && ddl_Type.SelectedIndex != 0)
    //    {
    //        bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), ddl_Type.SelectedValue.ToString());
    //    }
    //    else
    //    {
    //        ddlLocation.Items.Clear();

    //    }
    //}
    //protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlState.SelectedIndex != 0 && ddl_Type.SelectedIndex != 0)
    //    {
    //        bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), ddl_Type.SelectedValue.ToString());
    //    }
    //    else
    //    {
    //        ddlLocation.Items.Clear();

    //    }
    //    if (ddl_Type.SelectedValue == "P")
    //    {
    //        TrPurchaseType.Visible = true;
    //        TrSalesType.Visible = false;
    //        ddlSalesType.SelectedIndex = 0;


    //    }
    //    else if (ddl_Type.SelectedValue == "S")
    //    {
    //        TrSalesType.Visible = true;
    //        TrPurchaseType.Visible = false;
    //        ddlPurchaseType.SelectedIndex = 0;

    //    }
    //    GetState(); ddlState_SelectedIndexChanged(sender, e);
    //}

    private void Clear()
    {
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        lbl_msg.Text = "";
        //ddlcategory.SelectedIndex = 0;
        //ddl_Type.SelectedIndex = 0;
        //ddlState.SelectedIndex = 0;
        //ddlLocation.Items.Clear();
        //TrSalesType.Visible = false;
        //TrPurchaseType.Visible = false;
        //ddlSalesType.SelectedIndex = 0;
        //ddlPurchaseType.SelectedIndex = 0;
        ddlTaxName.SelectedIndex = 0;
        ddlActive.SelectedIndex = 0;
        txtTaxRate.Text = string.Empty;
        TxtBaseValue.Text = string.Empty;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        //DataTable DTTaxExists = BusinessServices.TaxRate_Exists(ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxName.SelectedValue),
        //    Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));
        DataTable DTTaxExists = BusinessServices.TaxRate_Exists(Convert.ToInt32(ddlTaxName.SelectedValue), Convert.ToInt32(ddlActive.SelectedValue));
        if (DTTaxExists.Rows.Count > 0)
        {
            lbl_msg.Text = "TaxRate Already Exists"; BindTaxRateGrid();
            return;
        }
        //bool result = BusinessServices.Insert_TaxRate(ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxName.SelectedValue),
        //    Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));
        bool result = BusinessServices.Insert_TaxRate(Convert.ToInt32(ddlTaxName.SelectedValue), Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));
        if (result)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
            Clear(); BindTaxRateGrid();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);
            BindTaxRateGrid();
        }
    }

    private void BindTaxRateGrid()
    {
        DataTable DT = new DataTable();
        try
        {
            string Cust = txtSearch.Text;
            DT = BusinessServices.BindGridTaxRate(txtSearch.Text.Trim());
            gvSearch.DataSource = DT;
            gvSearch.DataBind();
            if (DT.Rows.Count > 0)
            {
                ViewState["Taxructure"] = DT;
            }
            else
            {
            }

        }
        catch (Exception ex)
        {
        }

    }

    protected void btnSearch_click(object sender, EventArgs e)
    {
        try
        {
            BindTaxRateGrid();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnClear_click(object sender, EventArgs e)
    {
        try
        {
            Clear(); txtSearch.Text = "";
            BindTaxRateGrid();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void gvSearch_rowcommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Edited")
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                int TaxRateID = Convert.ToInt32(e.CommandArgument);
                Session["TRID"] = TaxRateID;
                DataTable Dt = BusinessServices.GetTaxRateDetailsBasedonID(TaxRateID);
                if (Dt.Rows.Count > 0)
                {
                    //ddl_Type.SelectedValue = Dt.Rows[0]["Type"].ToString();
                    //ddlState.SelectedValue = Dt.Rows[0]["StateId"].ToString();
                    //ddlState_SelectedIndexChanged(sender, e);
                    //ddlLocation.SelectedValue = Dt.Rows[0]["LocationId"].ToString();
                    //ddlcategory.SelectedValue = Dt.Rows[0]["CategoryId"].ToString();
                    ddlTaxName.SelectedValue = Dt.Rows[0]["TaxNameId"].ToString();

                    //if (Dt.Rows[0]["Type"].ToString() == "S")
                    //{
                    //    ddlSalesType.SelectedValue = Dt.Rows[0]["SalesType"].ToString();
                    //    TrSalesType.Visible = true;
                    //    TrPurchaseType.Visible = false;

                    //}
                    //else
                    //{
                    //    ddlPurchaseType.SelectedValue = Dt.Rows[0]["PurchaseType"].ToString();
                    //    TrSalesType.Visible = false;
                    //    TrPurchaseType.Visible = true;
                    //}


                    txtTaxRate.Text = Dt.Rows[0]["TaxRate"].ToString();
                    TxtBaseValue.Text = Dt.Rows[0]["BaseValue"].ToString();
                    ddlActive.SelectedValue = Dt.Rows[0]["Status"].ToString();
                }

            }
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            Clear(); txtSearch.Text = "";
            BindTaxRateGrid();
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            //DataTable DTTaxExists = BusinessServices.TaxRate_ExistsForUpdate(Convert.ToInt32(Session["TRID"]),ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxName.SelectedValue),
            //Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));

            DataTable DTTaxExists = BusinessServices.TaxRate_ExistsForUpdate(Convert.ToInt32(Session["TRID"]), Convert.ToInt32(ddlTaxName.SelectedValue), Convert.ToInt32(ddlActive.SelectedValue));
            if (DTTaxExists.Rows.Count > 0)
            {
                lbl_msg.Text = "TaxRate Already Exists";
                return;
            }
            //bool result = BusinessServices.Update_TaxRate(Convert.ToInt32(Session["TRID"]), ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxName.SelectedValue),
            //Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));

            bool result = BusinessServices.Update_TaxRate(Convert.ToInt32(Session["TRID"]), Convert.ToInt32(ddlTaxName.SelectedValue),
            Convert.ToDecimal(txtTaxRate.Text), Convert.ToDecimal(TxtBaseValue.Text), Convert.ToInt32(ddlActive.SelectedValue));

            if (result)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updated Successfully..');</script>", false);
                Clear();
                BindTaxRateGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updation Failed..');</script>", false);
            }
        }
        catch (Exception EX)
        {
            throw EX;
        }
    }

    protected void gvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSearch.PageIndex = e.NewPageIndex;
        BindTaxRateGrid();
    }
}