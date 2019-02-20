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

public partial class TaxMapping : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGrd();
            GetState();
            bindCategory();
            GetMasterList("SU", ddlPurchaseType);
            bindSalesType();
            BindTaxnamesformapping();
            bindTaxStructure();
        }
    }
    //Getting Supplier and binding to ddlPurchaseType dropdown
    private void GetMasterList(string Type, DropDownList DrpList)
    {
        try
        {
            ClsMaster ClsMas = new ClsMaster();
            DataTable DT = new DataTable();
            DrpList.Items.Clear();
            // DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DT = ClsMaster.GetMaster_purchasetype_dropdown();
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "purchase_name";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("--Select Purchase Type--", "0"));
        }
        catch (Exception Ex)
        {

        }
    }
   // Binding Sales Type Dropdown
    public void bindSalesType()
    {
        try
        {
            // DataTable dt = BusinessServices.Imaging_GetSalesType();
            DataTable dt = ClsMaster.GetMaster_purchasetype_dropdown();
            ddlSalesType.Items.Clear();
            ddlSalesType.DataSource = dt;
            ddlSalesType.DataTextField = "purchase_name";
            ddlSalesType.DataValueField = "ID";
            ddlSalesType.DataBind();

            ddlSalesType.Items.Insert(0, new ListItem("--Select Sales Type--", "0"));
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
            ddlLocation.Items.Clear();
            ddlLocation.DataSource = dt;
            ddlLocation.DataTextField = "Location_Name";
            ddlLocation.DataValueField = "Location_ID";
            ddlLocation.DataBind();

            ddlLocation.Items.Insert(0, new ListItem("--Select Location--", "0"));
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
   // Binding Category Dropdown
    public void bindCategory()
    {
        try
        {
            DataTable dt = BusinessServices.Imaging_Get_Category();
            ddlcategory.Items.Clear();
            ddlcategory.DataSource = dt;
            ddlcategory.DataTextField = "Category_Name";
            ddlcategory.DataValueField = "Category_ID";
            ddlcategory.DataBind();

            ddlcategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    // Binding TaxStructure Dropdown
    public void bindTaxStructure()
    {
        try
        {
            DataTable dt = BusinessServices.Imaging_GetTaxStructureforBind();
            ddlTaxStructure.Items.Clear();
            ddlTaxStructure.DataSource = dt;
            ddlTaxStructure.DataTextField = "TaxStructure";
            ddlTaxStructure.DataValueField = "ID";
            ddlTaxStructure.DataBind();

            ddlTaxStructure.Items.Insert(0, new ListItem("--Select Tax Structure--", "0"));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //binding Tax Names to checklist for mapping with structure
    protected void BindTaxnamesformapping()
    {
        DataTable Dt = BusinessServices.Imaging_Get_Taxnamesformapping();
       if (Dt.Rows.Count > 0)
        {
            chkTaxnames.Items.Clear();
            chkTaxnames.DataSource = Dt;
            chkTaxnames.DataTextField = "TaxName";
            chkTaxnames.DataValueField = "TaxRateId";
            chkTaxnames.DataBind();

            //chkTaxnames.Items.Clear();
            //for (int i = 0; i < Dt.Rows.Count; i++)
            //{                             
            //    chkTaxnames.Items.Add(new ListItem(Dt.Rows[i]["TaxName"].ToString(), Dt.Rows[i]["TaxRateId"].ToString()));
            //    chkTaxnames.Items[i].Attributes.Add("style", "display:inline!important");
            //}
        }


    }
    //binding Grid
    private void GetGrd()
    {
        DataTable DT = new DataTable();
        try
        {
           DT = BusinessServices.BindTaxRateMapping(txtSearch.Text);
            if (DT.Rows.Count > 0)
            {
                GvSearch.DataSource = DT;
                GvSearch.DataBind();
            }
            else
            {
                lbl_msg.Text = "No records found...";
            }

        }
        catch (Exception ex)
        {
        }

    }
    
    private void Clear()
    {
        btnSave.Visible = true;
        btnUpdate.Visible = false;
        lbl_msg.Text = "";
        ddlcategory.SelectedIndex = 0;
        ddl_Type.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        ddlLocation.Items.Clear();
        TrSalesType.Visible = false;
        TrPurchaseType.Visible = false;
        ddlSalesType.SelectedIndex = 0;
        ddlPurchaseType.SelectedIndex = 0;
        ddlTaxStructure.SelectedIndex = 0;
        ddlActive.SelectedIndex = 0;
        BindTaxnamesformapping();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DTDup = BusinessServices.Imaging_CheckDuplicateTaxMapping(ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue),
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxStructure.SelectedValue),
          Convert.ToInt32(ddlSalesType.SelectedValue),Convert.ToInt32(ddlPurchaseType.SelectedValue));
            if(DTDup.Rows.Count >0)
            {
                lbl_msg.Text = "Mapping already exists for the selected tax structure";
                return;
            }


            btnSave.Visible = true;btnUpdate.Visible = false;
            bool Result = BusinessServices.TaxRateMappingMain_Insert(ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue),
                Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxStructure.SelectedValue),
                Convert.ToInt32(ddlActive.SelectedValue),Convert.ToInt32(ddlPurchaseType.SelectedValue),Convert.ToInt32(ddlSalesType.SelectedValue));
            if (Result == true)
            {
                for (int i = 0; i < chkTaxnames.Items.Count; i++)
                {
                    if (chkTaxnames.Items[i].Selected == true)
                    {
                        bool Result1 = BusinessServices.TaxRateMappingChield_Insert(Convert.ToInt32(chkTaxnames.Items[i].Value));
                    }
                }
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                Clear();
                GetGrd();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        DataTable DTDup = BusinessServices.Imaging_CheckDuplicateTaxMappingUpdate(Convert.ToInt32(Session["TxtMapId"]) ,ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue),
                       Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxStructure.SelectedValue),
                 Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue));
        if (DTDup.Rows.Count > 0)
        {
            lbl_msg.Text = "Mapping already exists for the selected tax structure";
            return;
        }

        bool Result = BusinessServices.TaxRateMappingMain_Update(Convert.ToInt32(Session["TxtMapId"]) ,ddl_Type.SelectedValue, Convert.ToInt32(ddlState.SelectedValue),
               Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlTaxStructure.SelectedValue),
               Convert.ToInt32(ddlActive.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue));
        if (Result == true)
        {
            bool Result1 = BusinessServices.TaxRateMappingChield_delete(Convert.ToInt32(Session["TxtMapId"]));
            for (int i = 0; i < chkTaxnames.Items.Count; i++)
            {
                if (chkTaxnames.Items[i].Selected == true)
                {
                    bool Result2 = BusinessServices.TaxRateMappingChield_Update(Convert.ToInt32(chkTaxnames.Items[i].Value), Convert.ToInt32(Session["TxtMapId"]));
                }
            }
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Update Successfully..');</script>", false);
            Clear();
            GetGrd();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear(); GetGrd();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearch.Text = "";
            GetGrd();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnsearch_click(object sender, EventArgs e)
    {
        GetGrd();

    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlState.SelectedIndex != 0 && ddl_Type.SelectedIndex != 0)
        {
            bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), ddl_Type.SelectedValue.ToString());
        }
        else
        {
            ddlLocation.Items.Clear();

        }
    }

    protected void ddl_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex != 0 && ddl_Type.SelectedIndex != 0)
        {
            bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), ddl_Type.SelectedValue.ToString());
        }
        else
        {
            ddlLocation.Items.Clear();

        }
        if (ddl_Type.SelectedValue == "P")
        {
            TrPurchaseType.Visible = true;
            TrSalesType.Visible = false;
            //ddlSalesType.SelectedIndex = 0;


        }
        else if (ddl_Type.SelectedValue == "S")
        {
            TrSalesType.Visible = true;
            TrPurchaseType.Visible = false;
           // ddlPurchaseType.SelectedIndex = 0;

        }
        Sale_Purchase_TypeBinding();


    }  

    protected void GvSearch_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvSearch.PageIndex = e.NewPageIndex;
        GetGrd();
    }

    protected void GvSearch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EDITED")
            {
                btnSave.Visible = false;btnUpdate.Visible = true;
                int TxtMapId =Convert.ToInt32(e.CommandArgument);
                Session["TxtMapId"] = TxtMapId;
                DataTable DTMain = BusinessServices.BindTaxRateMappingMain(TxtMapId);
                if (DTMain.Rows.Count > 0)
                {
                    ddl_Type.SelectedValue = DTMain.Rows[0]["TypeID"].ToString();
                    ddlState.SelectedValue= DTMain.Rows[0]["StateID"].ToString();
                    ddlState_SelectedIndexChanged(sender, e);
                    ddlLocation.SelectedValue = DTMain.Rows[0]["LocationID"].ToString();
                    ddlcategory.SelectedValue = DTMain.Rows[0]["CategoryID"].ToString();
                    if (ddl_Type.SelectedValue == "P")
                    {
                        TrPurchaseType.Visible = true;
                        TrSalesType.Visible = false;
                        ddlSalesType.SelectedIndex = 0;
                        ddlPurchaseType.SelectedValue= DTMain.Rows[0]["PurchaseType"].ToString();

                    }
                    else if (ddl_Type.SelectedValue == "S")
                    {
                        TrSalesType.Visible = true;
                        TrPurchaseType.Visible = false;
                        ddlPurchaseType.SelectedIndex = 0;
                        ddlSalesType.SelectedValue= DTMain.Rows[0]["SalesType"].ToString();
                    }
                    ddlTaxStructure.SelectedValue = DTMain.Rows[0]["TaxStructureID"].ToString();
                    ddlActive.SelectedValue = DTMain.Rows[0]["ActiveStatus"].ToString();
                }
                DataTable DtChield = BusinessServices.BindTaxRateMappingChield(TxtMapId);
                if (DtChield.Rows.Count > 0)
                {
                    BindTaxnamesformapping();
                    for (int i = 0; i < chkTaxnames.Items.Count; i++)
                    {
                        for (int j = 0; j < DtChield.Rows.Count; j++)
                        {
                            if (chkTaxnames.Items[i].Value == DtChield.Rows[j]["TaxRateID"].ToString())
                            {
                                chkTaxnames.Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void ddlTaxStructure_SelectedIndexChanged(object sender, EventArgs e)
    {
        Sale_Purchase_TypeBinding();
    }
    private void Sale_Purchase_TypeBinding()
    {
        //if (ddlTaxStructure.SelectedValue != "0" && ddlTaxStructure.SelectedValue != "3")
        if (ddlTaxStructure.SelectedValue == "1" || ddlTaxStructure.SelectedValue == "2")
        {
            DataTable DT = BusinessServices.GetSalTypeonStrID(Convert.ToInt32(ddlTaxStructure.SelectedValue));
            if (ddl_Type.SelectedValue == "S")
            {
                ddlSalesType.SelectedValue = DT.Rows[0][0].ToString();
                ddlSalesType.Enabled = false;
            }
            else if (ddl_Type.SelectedValue == "P")
            {
                ddlPurchaseType.SelectedValue = DT.Rows[0][0].ToString();
                ddlPurchaseType.Enabled = false;
            }


        }
        else
        {
            ddlSalesType.SelectedValue = ddlPurchaseType.SelectedValue = "0";
            ddlSalesType.Enabled = true;
            ddlPurchaseType.Enabled = true;
        }
    }
}