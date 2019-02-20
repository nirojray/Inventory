using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;


/// <summary>
/// Summary description for AlertPageHelper
/// </summary>
public class AlertPageHelper
{
	public AlertPageHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void ShowAlert(Page aPage, String Message)
    {
        String Output;
        Output = String.Format("<Script Language='javascript'> alert('{0}');</script>", Message);
        aPage.ClientScript.RegisterStartupScript(aPage.GetType(), Guid.NewGuid().ToString(), string.Format("alert('{0}');", Message.Replace("'", @"\'")), true);

        // aPage.ClientScript.RegisterStartupScript(aPage.GetType(), Guid.NewGuid().ToString(), string.Format("alert('{0}');window.location.herf='default.aspx'", Message.Replace("'", @"\'").Replace("\r", "\\r")), true);

        //aPage.ClientScript.RegisterStartupScript(aPage.GetType(),Guid.NewGuid().ToString(), "ShowMessage('shiva','default1.aspx')",true);
    }
    public static void MessageBoxBeforeRedirect(Page aPage, String alertMessage, String responseUrl)
    {
        String Output;
        Output = String.Format("<Script Language='javascript'> alert('{0}');</script>", alertMessage);
        aPage.ClientScript.RegisterStartupScript(aPage.GetType(), Guid.NewGuid().ToString(), "ShowMessage('" + alertMessage + "','" + responseUrl + "')", true);
    }
}