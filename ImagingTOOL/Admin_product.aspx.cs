using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;
public partial class Admin_product : System.Web.UI.Page
{
    ClsMaster ClsMas = new ClsMaster();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindSupplier("SU", ddlSupplier);
            BindMainCategory();
            GetGrd();
        }

    }

    //binding data last three coloumn
    private void Get_Min_Max()
    {
        DataTable dt3 = new DataTable();
        try
        {
            //dt3 = BusinessServices.Binding_Min_max_coloumn();
            //GvwCustomer.DataSource = dt3;
            //GvwCustomer.DataBind();

        }
        catch (Exception ex)
        {
        }
    }
    //binding Grid
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_Product(txtSearch.Text.Trim());
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }
    //binding Supplier Dropdown
    private void bindSupplier(string Type, DropDownList DrpList)
    {
        try
        {

            DataTable DT = new DataTable();
            DrpList.Items.Clear();
            DT = ClsMas.GetMaster(Type, Session["Id"].ToString());
            DrpList.DataSource = DT;
            DrpList.DataValueField = "ID";
            DrpList.DataTextField = "NAME";
            DrpList.DataBind();
            DrpList.Items.Insert(0, new ListItem("-----Select---", "0"));
        }
        catch (Exception Ex)
        {

        }
    }

    //Bidning Main Categories to Type dropdown
    public void BindMainCategory()
    {
        try
        {

            DataTable DT = ClsMas.GetMainCategory();
            if (DT.Rows.Count > 0)
            {
                ddlType.Items.Clear();
                ddlType.DataSource = DT;
                ddlType.DataValueField = "M_categoryid";
                ddlType.DataTextField = "M_CategoryName";
                ddlType.DataBind();
                ddlType.Items.Insert(0, new ListItem("------Select------", "0"));
            }
        }
        catch (Exception)
        {

            throw;
        }
    }


    //Bidning Sub Categories to Category dropdown
    public void bindSubCategory()
    {
        try
        {

            DataTable DT = ClsMas.GetSubCategory(Convert.ToInt32(ddlType.SelectedValue));
            ddl_Category.DataSource = DT;
            ddl_Category.DataTextField = "NAME";
            ddl_Category.DataValueField = "ID";
            ddl_Category.DataBind();

            ddl_Category.Items.Insert(0, new ListItem("------Select------", "0"));
            ddl_Category.SelectedIndex = 0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    //For Clearing all Text and Ddls
    private void Clear()
    {
        txt_Name.Text = "";
        // txt_Mum_stock.Text = "0";
        // txt_Dhl_stock.Text = "0";
        // txt_Chn_stock.Text = "0";
        // txt_Blr_stock.Text = "0";
        //Txt_Hyd_stock.Text = "0";
        // Txt_Kol_stock.Text = "0";

        txt_Procode.Text = "";
        ddlSupplier.SelectedIndex = 0;
        ddlType.SelectedIndex = 0;
        ddl_Category.Items.Clear();
        GetGrd(); lbl_msg.Text = "";

        //Added by kushal patil 
        Txt_Record_level.Text = "";
        Txt_Min_Qty.Text = "";
        Txt_Man_Qty.Text = "";
    }
    //For saving the Product
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txt_Name.Text != string.Empty && txt_Mum_stock.Text != string.Empty && ddl_Category.SelectedValue != "-1" && txt_Procode.Text != string.Empty && txt_Dhl_stock.Text != string.Empty && txt_Chn_stock.Text != string.Empty && txt_Blr_stock.Text != string.Empty && txt_Ahm_stock.Text != string.Empty)
        //{



        DataTable DTProduct = BusinessServices.Imaging_Product_Exists(Convert.ToInt32(ddlSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddl_Category.SelectedValue), txt_Procode.Text.Trim());
        if (DTProduct.Rows.Count > 0)
        {
            lbl_msg.Visible = true;
            lbl_msg.Text = "Product Already Exist";
        }
        else
        {
            lbl_msg.Text = "";
            bool result = BusinessServices.Imaging_Admin_Product_Insert(Convert.ToInt32(ddlSupplier.SelectedValue), Convert.ToInt32(ddlType.SelectedValue), Convert.ToInt32(ddl_Category.SelectedValue), txt_Procode.Text.Trim(), txt_Name.Text.Trim(), Convert.ToInt32(Txt_Record_level.Text.Trim()), Convert.ToInt32(Txt_Min_Qty.Text.Trim()), Convert.ToInt32(Txt_Man_Qty.Text.Trim()));
            if (result)
            {
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

            }
        }


    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        lbl_msg.Text = "";

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd();
        GvwCustomer.Columns[8].Visible = false;
    }

    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        // Retrieve updated data
        string ProductID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Contaclbl_Nametid")).Text;
        string Name = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_lbl_Name")).Text;
        string ProductCode = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_ProCode")).Text;
        string Supplier = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Edit_SupplierId")).Text;
        string MainCategory = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Edit_MainCategoryId")).Text;
        string SubCategory = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Edit_SubCategoryId")).Text;
        string PName = Name.ToUpper();
        string PCode = ProductCode.ToUpper();


        //Added by kushal patil
        string REORDER = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txt_record")).Text;
        string MIN = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txt_Min")).Text;
        string MAX = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txt_Max")).Text;

        string Recrd = REORDER.ToUpper();
        DataTable DTProduct = new DataTable();
        if (REORDER != "")
        {
            if (MIN != "")
            {
                if (MAX != "")
                {
                    DTProduct = BusinessServices.Imaging_Product_Existsforupdate(Convert.ToInt32(ProductID), PCode.Trim(), PName.ToUpper(), Convert.ToInt32(Supplier), Convert.ToInt32(MainCategory), Convert.ToInt32(SubCategory), Convert.ToInt32(REORDER), Convert.ToInt32(MIN), Convert.ToInt32(MAX));
                }
                else
                {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please enter Max Value.');</script>", false);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please enter Min Value.');</script>", false);
                return;
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please enter Reorder Level Value.');</script>", false);
            return;
        }

        if (DTProduct.Rows.Count > 0)
        {
            lbl_msg.Visible = true;
            lbl_msg.Text = "Product Already Exist";
        }
        else
        {
            string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Contaclbl_Nametid")).Text;


            if (Convert.ToInt32(MIN) > Convert.ToInt32(MAX))
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Min Qty cannot be greater than Max Qty.');</script>", false);
            }
            else
            {                
                bool result = BusinessServices.Imaging_Admin_Product_update(Convert.ToInt32(ID), Name, ProductCode, Convert.ToInt32(REORDER), Convert.ToInt32(MIN), Convert.ToInt32(MAX));
                Clear();
                GvwCustomer.EditIndex = -1;
                // Display status message
                lbl_msg.Text = result ? "Updated successful" : "Updation failed";
                // Reload the grid
                GetGrd();
                GvwCustomer.Columns[8].Visible = true;
            }
        }
    }

    protected void GvwCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwCustomer.PageIndex = e.NewPageIndex;
        GetGrd();
    }
    protected void GvwCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Set status message
        lbl_msg.Text = "Editing canceled";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[8].Visible = true;
    }


    protected void GvwCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        btnContinue.Visible = true;
        btnDisContinue.Visible = true;

        string str = "Do you want to delete?";
        string script = "<script type='text/javascript' language='javascript'>";
        script += "if (confirm('" + str.ToString() + "')) {document.getElementById('" + btnContinue.ClientID + "').click(); }else{ document.getElementById('" + btnDisContinue.ClientID + "').click();  };"; script += "</script>";
        if (script != "<script type='text/javascript' language='javascript'></script>")
            if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                Page.RegisterStartupScript("clientScript2", script);


        // Get the ID of the record to be deleted
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Supplier_Id1")).Text;

        Session["ID"] = ID;



    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {


            bool result = BusinessServices.Imaging_Admin_Product_delete(Convert.ToInt32(Session["ID"]));
            string msg = "Product is deleted.";
            string script = "<script type='text/javascript' language='javascript'>";
            script += "alert('" + msg.ToString() + "' );"; script += "</script>";
            if (script != "<script type='text/javascript' language='javascript'></script>")
                if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                    Page.RegisterStartupScript("clientScript2", script);
            // Cancel edit mode
            GvwCustomer.EditIndex = -1;
            // Display status message
            lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
            // Reload the grid
            GetGrd(); GvwCustomer.Columns[8].Visible = true;



            btnContinue.Visible = false;
            btnDisContinue.Visible = false;




        }
        catch (Exception ex)
        {

        }
    }

    protected void btnDisContinue_Click(object sender, EventArgs e)
    {
        try
        {
            GvwCustomer.EditIndex = -1;
            GetGrd(); GvwCustomer.Columns[8].Visible = true;
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
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
        }
    }

    protected void btnsearch_click(object sender, EventArgs e)
    {
        try
        {
            GetGrd();
        }
        catch (Exception ex)
        {
        }

    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedIndex != 0)
        {
            bindSubCategory();
        }
        else
        { ddl_Category.Items.Clear(); }

    }
}