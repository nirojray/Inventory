using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Admin_Tax : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindtaxtype(); GetGrd(); bindcategory();
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_Tax();
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }
    public void bindtaxtype()
    {
        DataTable dt = BusinessServices.Imaging_Admin_taxType();
        ddl_Type.DataSource = dt;
        ddl_Type.DataTextField = "Tax_Type";
        ddl_Type.DataValueField = "Tax_Type";
        ddl_Type.DataBind();

        ddl_Type.Items.Insert(0, new ListItem("------Select------", "-1"));
        ddl_Type.SelectedIndex = 0;
    }
    //public void bindLocation()
    //{
    //    DataTable dt = BusinessServices.Imaging_Admin_Tax_Location();
    //    ddl_Location.DataSource = dt;
    //    ddl_Location.DataTextField = "Location_Name";
    //    ddl_Location.DataValueField = "Location_ID";
    //    ddl_Location.DataBind();

    //    ddl_Location.Items.Insert(0, new ListItem("------Select------", "-1"));
    //    ddl_Location.SelectedIndex = 0;
    //}
    public void bindcategory()
    {
        DataTable dt = BusinessServices.Imaging_Admin_CAtegory();
        ddl_Category.DataSource = dt;
        ddl_Category.DataTextField = "Category_Name";
        ddl_Category.DataValueField = "Category_ID";
        ddl_Category.DataBind();

        ddl_Category.Items.Insert(0, new ListItem("------Select------", "-1"));
        ddl_Category.SelectedIndex = 0;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string convalue = txt_Tax_Con_Value.Text.Trim();
       if(convalue != string.Empty  )
       {
           if (txtTax_Description.Text != string.Empty && txtTax_Percentage.Text != string.Empty && ddl_Type.SelectedValue != "-1" && ddl_Category.SelectedValue != "-1")
        {

            bool result = BusinessServices.Imaging_Admin_Tax_Insert(ddl_Type.SelectedItem.Value.ToString(), txtTax_Description.Text.Trim(), Convert.ToInt32(ddl_Category.SelectedItem.Value.ToString()), txtTax_Percentage.Text.Trim(), txt_Tax_Con_Value.Text.Trim());
            if (result)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                txt_Tax_Con_Value.Text = ""; txtTax_Description.Text = ""; txtTax_Percentage.Text = "";


                ddl_Type.SelectedValue = "-1"; ddl_Category.SelectedValue = "-1";
                GetGrd();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

            }

        }

        else
        {
            AlertPageHelper.ShowAlert(this.Page, "Please Fill the Required Fields");
        }
       }
       else
       {

           bool result = BusinessServices.Imaging_Admin_Tax_Insert_withoutconvalue(ddl_Type.SelectedItem.Value.ToString(), txtTax_Description.Text.Trim(), Convert.ToInt32(ddl_Category.SelectedItem.Value.ToString()), txtTax_Percentage.Text.Trim());
           if (result)
           {

               ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
               txt_Tax_Con_Value.Text = ""; txtTax_Description.Text = ""; txtTax_Percentage.Text = "";


               ddl_Type.SelectedValue = "-1"; ddl_Category.SelectedValue = "-1";
               GetGrd();
           }
           else
           {
               ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Creation Failed..');</script>", false);

           }
       }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {


        txt_Tax_Con_Value.Text = ""; txtTax_Description.Text = ""; txtTax_Percentage.Text = "";


        ddl_Type.SelectedValue = "-1"; ddl_Category.SelectedValue = "-1";
        GetGrd();

    }
    protected void GvwCustomer_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // Set the row for which to enable edit mode
        GvwCustomer.EditIndex = e.NewEditIndex;
        // Set status message 
        lbl_msg.Text = "Editing row # " + e.NewEditIndex.ToString();
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[5].Visible = false;
    }
    protected void GvwCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        // Retrieve updated data
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Supplier_Id1")).Text;
        string Tax_Desc = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_lbl_Name")).Text;
      
        string Tax_Percentage = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactPhoneNO")).Text;
        string Tax_con_Value = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactEmail")).Text;

        bool result = BusinessServices.Imaging_Admin_tax_update(Convert.ToInt32(ID), Tax_Desc, Tax_Percentage, Tax_con_Value);


        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Updated successful" : "Updation failed";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[5].Visible = true;
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
        GetGrd(); GvwCustomer.Columns[5].Visible = true;
    }
    protected void GvwCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        // Get the ID of the record to be deleted
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Supplier_Id1")).Text;


        bool result = BusinessServices.Imaging_Admin_tax_delete(Convert.ToInt32(ID));

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[5].Visible = true;
    }
    protected void GvwCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}