using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
		{
			LogOut.Text = "Log out";
		}
		else
		{
			LogOut.Text = "Log in";
		}
	}

	protected void LogOut_Click(object sender, EventArgs e)
	{
		if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
		{
			FormsAuthentication.SignOut();
			Response.Redirect("~/Logon.aspx");
		}
		else
		{
			Response.Redirect("~/Logon.aspx");
		}
	}
}
