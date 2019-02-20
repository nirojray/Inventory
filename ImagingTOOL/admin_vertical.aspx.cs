using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class admin_vertical : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGrd1();
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_Vertical();
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtCategory.Text != string.Empty)
        {
            DataTable Dt = new DataTable();
            Dt = BusinessServices.PreventDublicate(txtCategory.Text.ToString());
           if (Dt.Rows.Count>0)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Vertical is alredy existed..');</script>", false);
            }
           else
            { 

            bool result = BusinessServices.Imaging_Admin_Vertical_Insert(txtCategory.Text.Trim());
            if (result)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                txtCategory.Text = "";

                GetGrd1(); lbl_msg.Text = "";
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

            }

        }
        }

        else
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill the Required Fields");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtCategory.Text = "";GetGrd1();

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd1(); GvwCustomer.Columns[1].Visible = false;
    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Categoryid")).Text;
        string Category = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_Category")).Text;
        DataTable Dt = new DataTable();
        Dt = BusinessServices.PreventDublicate(Category);
        if (Dt.Rows.Count > 0)
        {

            ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Vertical is Alredy Existed..');</script>", false);
        }
        else
        { 
            bool result = BusinessServices.Imaging_Admin_Vertical_update(Convert.ToInt32(ID), Category);


        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Updated successful" : "Updation failed";
        // Reload the grid
        GetGrd1(); GvwCustomer.Columns[1].Visible = true;
        }
    }
    protected void GvwCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GvwCustomer.PageIndex = e.NewPageIndex;
        GetGrd1();
    }
    protected void GvwCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Set status message
        lbl_msg.Text = "Editing canceled";
        // Reload the grid
        GetGrd1(); GvwCustomer.Columns[1].Visible = true;
    }
    protected void GvwCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the record to be deleted
        btnContinue.Visible = true;
        btnDisContinue.Visible = true;




        string str = "Do you want to delete?";
        string script = "<script type='text/javascript' language='javascript'>";
        script += "if (confirm('" + str.ToString() + "')) {document.getElementById('" + btnContinue.ClientID + "').click(); }else{ document.getElementById('" + btnDisContinue.ClientID + "').click();  };"; script += "</script>";
        if (script != "<script type='text/javascript' language='javascript'></script>")
            if (!Page.IsStartupScriptRegistered("clientScript2".ToString()))
                Page.RegisterStartupScript("clientScript2", script);
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Category_Id1")).Text;
        Session["ID"] = ID;

    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {     



            bool result = BusinessServices.Imaging_Admin_Vertical_delete(Convert.ToInt32(Session["ID"]));

            // Cancel edit mode
            GvwCustomer.EditIndex = -1;
            // Display status message

            //lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
            lbl_msg.Text = "Deleted successful";
            // Reload the grid
            GetGrd1(); 
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
            GetGrd1();
            lbl_msg.Text = "Deletion failed";
            btnContinue.Visible = false;
            btnDisContinue.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnsearch_click(object sender, EventArgs e)
    {
        try
        {
            GetGrd1();
        }
        catch (Exception ex)
        {
        }
    }


    public  void GetGrd1()
    {
        DataTable ds = new DataTable();
        try
        {
            string Vertical = txtSearchVertical.Text;
            ds = BusinessServices.Imaging_Admin_Vertical_Get(txtSearchVertical.Text.Trim());
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            txtSearchVertical.Text = "";
            GetGrd1();
        }
        catch (Exception ex)
        {
        }
    }
}