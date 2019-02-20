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

public partial class Master_TaxStructure : System.Web.UI.Page
{
   int int_TSID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GetGrd();
           // GetState();
           // bindCategory();
           // GetMasterList("SU", ddlPurchaseType);
           // bindSalesType();
          
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
            DrpList.Items.Insert(0, new ListItem("--Select Purchase Type--", "0"));
        }
        catch (Exception Ex)
        {

        }
    }
    //Binding Sales Type Dropdown
    //public void bindSalesType()
    //{
    //    try
    //    {
    //        DataTable dt = BusinessServices.Imaging_GetSalesType();
    //        ddlSalesType. Items.Clear();
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
    //Binding Location Dropdown on State Selection 
    //public void bindLocationOnState(int StateID,string Type)
    //{
    //    try
    //    {
    //        DataTable dt = BusinessServices.Imaging_GetLocationOnState(StateID,Type);
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

    //Binding State Dropdown
    //private void GetState()
    //{
    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        dt = BusinessServices.BindState();            
    //            ddlState.Items.Clear();
    //            ddlState.DataSource = dt;
    //            ddlState.DataTextField = "State_Name";
    //            ddlState.DataValueField = "State_ID";
    //            ddlState.DataBind();
    //            ddlState.Items.Insert(0, new ListItem("--Select State--", "0"));
          

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }

    //}
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
    //binding Grid
    private void GetGrd()
    {
        DataTable DT = new DataTable();
        try
        {
            string Cust = txtSearch.Text;
            DT = BusinessServices.Imaging_Get_TaxStrusture(txtSearch.Text.Trim());
             GvwTaxStructure.DataSource = DT;
            GvwTaxStructure.DataBind();
            //if (DT.Rows.Count > 0)
            //{                
            //    ViewState["Taxructure"] = DT;
            //}
            //else
            //{
            //}

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
        // ddlcategory.SelectedIndex = 0;        
        //ddl_Type.SelectedIndex = 0;
        // ddlState.SelectedIndex = 0;
        //ddlLocation.Items.Clear();
       // TrSalesType.Visible = false;
       // TrPurchaseType.Visible = false;
       // ddlSalesType.SelectedIndex = 0;
       // ddlPurchaseType.SelectedIndex = 0;
        txtTaxStructure.Text = "";
        ddlActive.SelectedIndex = 0;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try { 

       // DataTable DTTaxExists = BusinessServices.Imaging_TaxStrusture_Exists(txtTaxStructure.Text.Trim(), ddl_Type.SelectedValue.ToString(), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue));
        DataTable DTTaxExists = BusinessServices.Imaging_TaxStrusture_Exists(txtTaxStructure.Text.Trim());

        if (DTTaxExists.Rows.Count>0)
        {
            lbl_msg.Text = "TaxStructure Already Exists";
            return;
        }
        // bool result = BusinessServices.Imaging_Insert_TAxStructure(ddl_Type.SelectedValue.ToString(), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), txtTaxStructure.Text.Trim(), Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlActive.SelectedValue));

        bool result = BusinessServices.Imaging_Insert_TAxStructure(txtTaxStructure.Text.Trim(), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlActive.SelectedValue));
        if (result)
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);

            Clear();

            GetGrd();
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

        }
        }
        catch (Exception ex)
        { throw ex; }
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
        try { 
        GetGrd();}
        catch(Exception ex)
        { throw ex; }
    }
  

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }

    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //    if(ddlState.SelectedIndex !=0 && ddl_Type.SelectedIndex !=0)
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
        

    //}

    protected void GvwTaxStructure_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            GridViewRow row = GvwTaxStructure.Rows[e.NewEditIndex];
            int index = Int32.Parse(row.RowIndex.ToString());

            int_TSID = Convert.ToInt32(((Label)(GvwTaxStructure.Rows[index].FindControl("lbl_TaxStructure_Id"))).Text);
            
             Session["TSID"] = int_TSID;
            // DataTable dItem = (DataTable)ViewState["Taxructure"];
            //DataRow[] drw = dItem.Select("ID='" + int_TSID + "'");
            // ddl_Type.SelectedValue = drw[0]["Type"].ToString();
            //ddlState.SelectedValue = drw[0]["StateID"].ToString();
            // bindLocationOnState(Convert.ToInt32(ddlState.SelectedValue), ddl_Type.SelectedValue.ToString());
            // ddlLocation.SelectedValue = drw[0]["LocationID"].ToString();
            // ddlcategory.SelectedValue = drw[0]["CategoryID"].ToString();
            txtTaxStructure.Text = ((Label)(GvwTaxStructure.Rows[index].FindControl("lbl_TaxStructure"))).Text;
string Activestatus= ((Label)(GvwTaxStructure.Rows[index].FindControl("lblActive"))).Text;

            if (Activestatus == "True")
            {
                ddlActive.SelectedValue = "1";

            }
            else
            {
                ddlActive.SelectedValue = "0";
            }
                        
            //if (drw[0]["Type"].ToString()=="S")
            //{
            //    ddlSalesType.SelectedValue = drw[0]["SalesType"].ToString();
            //    TrSalesType.Visible = true;
            //    TrPurchaseType.Visible = false;

            //}
            //else
            //{
            //    ddlPurchaseType.SelectedValue = drw[0]["PurchaseType"].ToString();
            //    TrSalesType.Visible = false;
            //    TrPurchaseType.Visible = true;
            //}
        


        }
        catch(Exception ex)
        {
            throw ex;
        }


        }

    protected void GvwTaxStructure_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }

    protected void GvwTaxStructure_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwTaxStructure.PageIndex = e.NewPageIndex;
        GetGrd();
    }
        
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            // DataTable DTTaxExists = BusinessServices.Imaging_TaxStrusture_Existsupdate(Convert.ToInt32(Session["ID"]),txtTaxStructure.Text.Trim(), ddl_Type.SelectedValue.ToString(), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue));
            DataTable DTTaxExists = BusinessServices.Imaging_TaxStrusture_Existsupdate(Convert.ToInt32(Session["TSID"]), txtTaxStructure.Text.Trim());
            if (DTTaxExists.Rows.Count > 0)
            {
                lbl_msg.Text = "TaxStructure Already Exists";
                return;
            }
            //bool result = BusinessServices.Imaging_Update_TAxStructure(Convert.ToInt32(Session["ID"]), ddl_Type.SelectedValue.ToString(), Convert.ToInt32(ddlState.SelectedValue), Convert.ToInt32(ddlLocation.SelectedValue), Convert.ToInt32(ddlcategory.SelectedValue), txtTaxStructure.Text.Trim(), Convert.ToInt32(ddlSalesType.SelectedValue), Convert.ToInt32(ddlPurchaseType.SelectedValue), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlActive.SelectedValue));
            bool result = BusinessServices.Imaging_Update_TAxStructure(Convert.ToInt32(Session["TSID"]), txtTaxStructure.Text.Trim(), Convert.ToInt32(Session["Id"]), Convert.ToInt32(ddlActive.SelectedValue));

            if (result)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updated Successfully..');</script>", false);

                Clear();

                GetGrd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Updation Failed..');</script>", false);

            }
        }
        catch(Exception ex)
        { throw ex; }
    }
}