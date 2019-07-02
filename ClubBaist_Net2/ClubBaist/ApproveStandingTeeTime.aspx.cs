using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApproveStandingTeeTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
        if (cp.IsMember())
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Logon.aspx");
        }
        else
        {
            if (!Page.IsPostBack)
            {
                StandingTeeTimes teeTimeMgr = new StandingTeeTimes();
                List<StandingTeeTime> teeTimes = teeTimeMgr.GetStandingRequests();
                teeTimeRequests.DataSource = teeTimes;
                teeTimeRequests.DataBind();
            }
        }
    }

    protected void ApproveButton_Click(object sender, EventArgs e)
    {
        foreach (Control item in teeTimeRequests.Items)
        {
            if ((item.FindControl("Approved") as CheckBox).Checked)
            {
                StandingTeeTimes teeTimeMgr = new StandingTeeTimes();
                teeTimeMgr.ApproveStandingTeeTime(int.Parse((item.FindControl("StandingTeeTimeID") as Label).Text));
            }
        }
    }
}