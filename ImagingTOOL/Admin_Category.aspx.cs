using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Admin_Category : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGrd();
            GetMainCategory();
        }

    }

    private void GetMainCategory()
    {
        try
        {
            DataTable Dt = BusinessServices.Get_Admin_MainCategory();
            if (Dt.Rows.Count > 0)
            {
                ddlCategory.Items.Clear();
                ddlCategory.DataSource = Dt;
                ddlCategory.DataValueField = "M_categoryid";
                ddlCategory.DataTextField = "M_CategoryName";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
            }
             
        }
        catch (Exception)
        {

            throw;
        }
    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_Category(txtSearch.Text);
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }
    private void Clear()
    {
        txtCategory.Text = "";ddlCategory.SelectedValue = "0";
        GetGrd();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txtCategory.Text != string.Empty)
        //{
        DataTable DTCategory = BusinessServices.Imaging_Category_Exists(txtCategory.Text.Trim(),Convert.ToInt32(ddlCategory.SelectedValue));
        if (DTCategory.Rows.Count > 0)
        {
            lbl_msg.Text = "Sub Category Already Exists";
        }
        else
        {
           
            bool result = BusinessServices.Imaging_Admin_category_Insert(txtCategory.Text.Trim(),Convert.ToInt32(ddlCategory.SelectedValue));
            if (result)
            {
                lbl_msg.Text = "";
                Clear();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);


            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

            }
        }

        //}

        //else
        //{
        //    AlertPageHelper.ShowAlert(this.Page, "Please Fill the Required Fields");
        //}
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        lbl_msg.Text = "";
        Clear();

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd();
        GvwCustomer.Columns[2].Visible = false;
    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Categoryid")).Text;
        string Category = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_Category")).Text;


        DataTable DTCategory = BusinessServices.Imaging_Category_ExistsforUpdate(Convert.ToInt32(ID), Category);
        if (DTCategory.Rows.Count > 0)
        {
            lbl_msg.Text = "Category Already Exist";
        }
        else
        {
            bool result = BusinessServices.Imaging_Admin_category_update(Convert.ToInt32(ID), Category);
            Clear();
          

            GvwCustomer.EditIndex = -1;

            // Display status message
            lbl_msg.Text = result ? "Updated successful" : "Updated failed";
            // Reload the grid
            GetGrd(); GvwCustomer.Columns[1].Visible = true;
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
        GetGrd(); GvwCustomer.Columns[2].Visible = true;
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
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Category_Id1")).Text;
        Session["ID"] = ID;



    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable DtProduct = BusinessServices.GetProduct_UnderCategory(Convert.ToInt32(Session["ID"]));
            if (DtProduct.Rows.Count > 0)
            {
                lbl_msg.Text = "Products are there under this Category, You cant delete";
            }
            else
            {

                bool result = BusinessServices.Imaging_Admin_Category_delete(Convert.ToInt32(Session["ID"]));

                // Cancel edit mode
                GvwCustomer.EditIndex = -1;
                // Display status message
                // lbl_msg.Text = result ? "Deleted successful" : "Deleted failed";
                // Reload the grid
                GetGrd(); GvwCustomer.Columns[1].Visible = true;



                string msg = "Category is deleted.";
                string script = "<script type='text/javascript' language='javascript'>";
                script += "alert('" + msg.ToString() + "' );"; script += "</script>";
                if (script != "<script type='text/javascript' language='javascript'></script>")
                    if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                        Page.RegisterStartupScript("clientScript2", script);


                btnContinue.Visible = false;
                btnDisContinue.Visible = false;
            }



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
            GetGrd(); GvwCustomer.Columns[1].Visible = true;
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
}