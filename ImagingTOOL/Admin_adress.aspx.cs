using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogicLayer;

public partial class Admin_adress : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindtype(); GetGrd(); bindPS();
        }

    }
    private void GetGrd()
    {
        DataTable ds = new DataTable();
        try
        {
            ds = BusinessServices.Imaging_Admin_address();
            GvwCustomer.DataSource = ds;
            GvwCustomer.DataBind();


        }
        catch (Exception ex)
        {
        }

    }
    public void bindPS()
    {
        DataTable dt = BusinessServices.Imaging_Admin_taxType();
        ddl_PS.DataSource = dt;
        ddl_PS.DataTextField = "Tax_Type";
        ddl_PS.DataValueField = "Tax_Type";
        ddl_PS.DataBind();

        ddl_PS.Items.Insert(0, new ListItem("------Select------", "-1"));
        ddl_PS.SelectedIndex = 0;
    }
    public void bindtype()
    {
        DataTable dt = BusinessServices.Imaging_Admin_address_type();
        ddl_address_type.DataSource = dt;
        ddl_address_type.DataTextField = "Address_Type";
        ddl_address_type.DataValueField = "Address_Type";
        ddl_address_type.DataBind();

        ddl_address_type.Items.Insert(0, new ListItem("------Select------", "-1"));
        ddl_address_type.SelectedIndex = 0;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txt_Name.Text != string.Empty && txtAddress.Text != string.Empty && ddl_address_type.SelectedValue != "-1" && ddl_PS.SelectedValue != "-1" && txtAddress1.Text != string.Empty && txtAddress2.Text != string.Empty && txtAddress3.Text != string.Empty && txtCST.Text != string.Empty && txtVAT.Text != string.Empty)
        {

            bool result = BusinessServices.Imaging_Admin_address_Insert(txt_Name.Text.Trim(), txtAddress.Text.Trim(), txtAddress1.Text.Trim(), txtAddress2.Text.Trim(), txtAddress3.Text.Trim(), txtVAT.Text.Trim(), txtCST.Text.Trim(), ddl_address_type.SelectedItem.Value.ToString(), ddl_PS.SelectedItem.Value.ToString());
            if (result)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Created Successfully..');</script>", false);
                txt_Name.Text = "";
                txtVAT.Text = "";
                txtAddress.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtCST.Text = "";
                txtVAT.Text = "";
                ddl_address_type.SelectedValue = "-1"; ddl_PS.SelectedValue = "-1";
                GetGrd(); lbl_msg.Text = "";
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txt_Name.Text = "";
        txtVAT.Text = "";
        txtAddress.Text = "";
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtAddress3.Text = "";
        txtCST.Text = "";
        txtVAT.Text = "";
        ddl_address_type.SelectedValue = "-1"; ddl_PS.SelectedValue = "-1";
        GetGrd(); lbl_msg.Text = "";
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
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Contaclbl_Nametid")).Text;
        string Name = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtbox_lbl_Name")).Text;

        string ContactPhoneNO = ((TextBox)GvwCustomer.Rows[e.RowIndex].FindControl("txtContactPhoneNO")).Text;


        bool result = BusinessServices.Imaging_Admin_address_update(Convert.ToInt32(ID), Name, Convert.ToInt32(ContactPhoneNO));


        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Updated successful" : "Updation failed";
        // Reload the grid
        GetGrd();
        GvwCustomer.Columns[8].Visible = true;
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
        // Get the ID of the record to be deleted
        string ID = ((Label)GvwCustomer.Rows[e.RowIndex].FindControl("lbl_Supplier_Id1")).Text;


        bool result = BusinessServices.Imaging_Admin_address_delete(Convert.ToInt32(ID));

        // Cancel edit mode
        GvwCustomer.EditIndex = -1;
        // Display status message
        lbl_msg.Text = result ? "Deleted successful" : "Deletion failed";
        // Reload the grid
        GetGrd(); GvwCustomer.Columns[8].Visible = true;
    }
}