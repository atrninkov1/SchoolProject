using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logon : System.Web.UI.Page
{
    protected void Logon_Click(object sender, EventArgs e)
    {
        UserAccounts accountMGR = new UserAccounts();
        UserInfo user = accountMGR.Login(Username.Text, UserPassword.Text);
        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddMinutes(60), false, user.Role + "|" + user.IsMember + "|" + user.MemberId);
        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
        HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
        authCookie.HttpOnly = true;
        Response.Cookies.Add(authCookie);
		if (!string.IsNullOrEmpty(Request.Params["ReturnUrl"]))
		{
			Response.Redirect(Request.Params["ReturnUrl"]);
		}
		else
		{
			if (user.Username == null)
			{
				Msg.Text = "Invalid username or password";
			}
			else
			{
				Msg.ForeColor = System.Drawing.Color.Blue;
				Msg.Text = "Logged in successfully";
			}
		}
	}
}