using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BusinessLogicLayer;

public partial class admin_dispatch : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetGrd();
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_Dispatch();
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (txtCategory.Text != string.Empty)
        //{
            DataTable DTDup = BusinessServices.CheckDupDispatch(txtCategory.Text.Trim());
            if (DTDup.Rows.Count > 0)
            {
                lbl_msg.Text = "Dispatch Details Already Exists";
            }
            else
            {

                bool result = BusinessServices.Imaging_Admin_Dispatch_Insert(txtCategory.Text.Trim());
                if (result)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                    txtCategory.Text = ""; lbl_msg.Text = "";

                    GetGrd();
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
        txtCategory.Text = "";
        lbl_msg.Text = "";

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[1].Visible = false;   
    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Categoryid")).Text;
        string Category = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_Category")).Text;

        DataTable DTDup = BusinessServices.CheckDupDispatchUpdate(Convert.ToInt32(ID), Category);
        if (DTDup.Rows.Count > 0)
        {
            lbl_msg.Text = "Dispatch Details Already Exists";
        }
        else
        {
            bool result = BusinessServices.Imaging_Admin_Dispatch_update(Convert.ToInt32(ID), Category);


            GvwCustomer.EditIndex = -1;
            // Display status message
            lbl_msg.Text = result ? "Updated successful" : "Updation failed";
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
        GetGrd(); GvwCustomer.Columns[1].Visible = true; 
    }
    protected void GvwCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the record to be deleted
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Category_Id1")).Text;


        bool result = BusinessServices.Imaging_Admin_Dispatch_delete(Convert.ToInt32(ID));

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[1].Visible = true; 
    }
}