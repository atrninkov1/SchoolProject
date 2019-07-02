<%@ Application Language="C#" %>

<script runat="server">


	void Application_AuthenticateRequest(object sender, EventArgs e)
	{
		string cookieName = FormsAuthentication.FormsCookieName;
		HttpCookie authCookie = Context.Request.Cookies[cookieName];
		if (authCookie == null)
		{
			return;
		}
		FormsAuthenticationTicket authTicket = null;
		try
		{
			authTicket = FormsAuthentication.Decrypt(authCookie.Value);
		}
		catch (Exception)
		{
			return;
		}

		if (authTicket == null)
		{
			return;
		}

		if (string.IsNullOrEmpty(authTicket.UserData))
		{
			return;
		}

		string[] roles = authTicket.UserData.Split('|');
		string role = roles[0];
		bool isMember = roles[1] == "True";
		int memberId = int.Parse(roles[2]);
		FormsIdentity id = new FormsIdentity(authTicket);
		CustomPrincipal principal = new CustomPrincipal(id, role, isMember, memberId);
		Context.User = principal;
	}

	void Application_Start(object sender, EventArgs e)
	{
		// Code that runs on application startup

	}

	void Application_End(object sender, EventArgs e)
	{
		//  Code that runs on application shutdown

	}

	void Application_Error(object sender, EventArgs e)
	{
		// Code that runs when an unhandled error occurs

	}

	void Session_Start(object sender, EventArgs e)
	{
		// Code that runs when a new session is started

	}

	void Session_End(object sender, EventArgs e)
	{
		// Code that runs when a session ends. 
		// Note: The Session_End event is raised only when the sessionstate mode
		// is set to InProc in the Web.config file. If session mode is set to StateServer 
		// or SQLServer, the event is not raised.

	}

</script>
