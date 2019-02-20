using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;
using AjaxControlToolkit;
using System.Configuration;
using System.Data;
using System.Web.Configuration;


/// <summary>
/// Summary description for DropdownWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService()]
public class WebService : System.Web.Services.WebService 
{
    [WebMethod]
    public CascadingDropDownNameValue[] BindSupplier(string knownCategoryValues, string category)
    {
        string LocationID;
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        LocationID = knownCategoryValues;
        int i = knownCategoryValues.IndexOf(":");
        LocationID = knownCategoryValues.Substring(i + 1, knownCategoryValues.Length - i - 2);
        SqlConnection constate = new SqlConnection(WebConfigurationManager.AppSettings["ImagingTool"].ToString());
        constate.Open();
        // AND Supplier_Location_ID = @LocationID
        SqlCommand cmdstate = new SqlCommand("SELECT Supplier_Id AS [ID],  Supplier_Name AS [NAME] FROM  dbo.M_Supplier WHERE  Supplier_Active=1   AND Supplier_Type IN( SELECT SupplierType_ID FROM dbo.M_Supplier_Type where SupplierType_Name='S')", constate);
        cmdstate.Parameters.AddWithValue("@LocationID", LocationID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        Int16 Cnt = 1;
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
         statedetails.Add(new CascadingDropDownNameValue("[ Select Supplier]", "-1"));
        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
            string CustID = dtstaterow["ID"].ToString();
            string CustName = dtstaterow["Name"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(CustName, CustID));
        }
        return statedetails.ToArray();
    }

    [WebMethod]
    public CascadingDropDownNameValue[] BindProduct(string knownCategoryValues, string category)
    {
        string CategoryID;
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        CategoryID = knownCategoryValues;
        int i = knownCategoryValues.IndexOf(":");
        CategoryID = knownCategoryValues.Substring(i + 1, knownCategoryValues.Length - i - 2);
        SqlConnection constate = new SqlConnection(WebConfigurationManager.AppSettings["ImagingTool"].ToString());
        constate.Open();

        SqlCommand cmdstate = new SqlCommand("SELECT Product_ID AS ID,Product_Name+' - (' + cast( convert(varchar(50),Product_Code) as varchar(12))+')' AS 'NAME'  FROM dbo.M_Product WHERE Product_Active=1 and  Product_Category_ID=@CategoryID", constate);
        cmdstate.Parameters.AddWithValue("@CategoryID", CategoryID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        Int16 Cnt = 1;
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
        statedetails.Add(new CascadingDropDownNameValue("--Select Product--", "-1"));
        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
            string CustID = dtstaterow["ID"].ToString();
            string CustName = dtstaterow["Name"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(CustName, CustID));
        }
        return statedetails.ToArray();
    }
    [WebMethod]
    public CascadingDropDownNameValue[] BindTAX(string knownCategoryValues, string category)
    {
        string LocationID; 
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        LocationID = knownCategoryValues;
    

        int i = knownCategoryValues.IndexOf(":");
        LocationID = knownCategoryValues.Substring(i + 1, knownCategoryValues.Length - i - 2);
        SqlConnection constate = new SqlConnection(WebConfigurationManager.AppSettings["ImagingTool"].ToString());
        constate.Open();

        SqlCommand cmdstate = new SqlCommand("SELECT Tax_ID AS [ID],Tax_Desc+' ' + cast( convert(numeric(18,2),Tax_Percentage) as varchar(12))+'%'   AS [Name] FROM dbo.M_Tax WHERE Tax_Type='P' AND  Tax_Active=1  AND  Tax_Cat=@LocationID", constate);
        cmdstate.Parameters.AddWithValue("@LocationID", LocationID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        Int16 Cnt = 1;
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
          //statedetails.Add(new CascadingDropDownNameValue("[Select Location]", "-1"));
        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
            string CustID = dtstaterow["ID"].ToString();
            string CustName = dtstaterow["Name"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(CustName, CustID));
        }
        return statedetails.ToArray();
    }
     [WebMethod]
    public CascadingDropDownNameValue[] BindSTAX(string knownCategoryValues, string category)
    {
        string LocationID;
        StringDictionary countrydetails = AjaxControlToolkit.CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues);
        LocationID = knownCategoryValues;
        int i = knownCategoryValues.IndexOf(":");
        LocationID = knownCategoryValues.Substring(i + 1, knownCategoryValues.Length - i - 2);
        SqlConnection constate = new SqlConnection(WebConfigurationManager.AppSettings["ImagingTool"].ToString());
        constate.Open();

        SqlCommand cmdstate = new SqlCommand("SELECT Tax_ID AS [ID],Tax_Desc+' ' + cast( convert(numeric(18,2),Tax_Percentage) as varchar(12))+'%'   AS [Name] FROM dbo.M_Tax WHERE Tax_Type='S' AND  Tax_Active=1 AND  Tax_Cat=@LocationID", constate);
        cmdstate.Parameters.AddWithValue("@LocationID", LocationID);
        cmdstate.ExecuteNonQuery();
        SqlDataAdapter dastate = new SqlDataAdapter(cmdstate);
        DataSet dsstate = new DataSet();
        dastate.Fill(dsstate);
        constate.Close();
        Int16 Cnt = 1;
        List<CascadingDropDownNameValue> statedetails = new List<CascadingDropDownNameValue>();
        //statedetails.Add(new CascadingDropDownNameValue("[Select Location]", "-1"));
        foreach (DataRow dtstaterow in dsstate.Tables[0].Rows)
        {
            string CustID = dtstaterow["ID"].ToString();
            string CustName = dtstaterow["Name"].ToString();
            statedetails.Add(new CascadingDropDownNameValue(CustName, CustID));
        }
        return statedetails.ToArray();
    }
    

}
