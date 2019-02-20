using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class InvoiceCreditNote : System.Web.UI.Page
{
    ClsSalesOrder clsSalses = new ClsSalesOrder();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadSoInvoiceNumber();
        }
    }
    private void LoadSoInvoiceNumber()
    {
        try
        {
            ddlSOInvoiceNumber.Items.Clear();
            DataTable dt = ClsMaster.GetSONumberApproved();
            ddlSOInvoiceNumber.DataSource = dt;
            ddlSOInvoiceNumber.DataTextField = "Invoice_Number";
            ddlSOInvoiceNumber.DataValueField = "Invoice_ID";
            ddlSOInvoiceNumber.DataBind();
            ddlSOInvoiceNumber.Items.Insert(0, new System.Web.UI.WebControls.ListItem("--Select SO Invoice NO--", "0"));            
        }
        catch (Exception Ex)
        {

        }
    }

    public void btnCancel_click(object sender,EventArgs e)
    {
        try
        {
           int value = Convert.ToInt32(ddlSOInvoiceNumber.SelectedValue.ToString());
            if (value != 0)
            {
                int i = clsSalses.SalesInvoiceCreditNote(ddlSOInvoiceNumber.SelectedItem.Text.Trim(), Convert.ToInt32(Session["Id"]));
                if (i > 0)
                {                    
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Invoice - (" + ddlSOInvoiceNumber.SelectedItem.Text.Trim() + " Canceled Successfully.');</script>", false);

                    LoadSoInvoiceNumber();
                }                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Alert", "<script>alert('Please Select Sales Invoice Number .');</script>", false);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {

        }
    }
}