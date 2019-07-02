using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CancelTeeTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		try
		{
			CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
			if (!cp.IsMember())
			{
				MemberSelection.Visible = true;

			}
			else
			{
				MemberSelection.Visible = false;
			}
		}
		catch (Exception)
		{
			
		}
    }

    protected void Search_Click(object sender, EventArgs e)
    {
        CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
        TeeTimes teeTimeMGR = new TeeTimes();
        if (!cp.IsMember())
        {
            int selectedMember;
            if (int.TryParse(MemberSelection.Text, out selectedMember))
            {
                TeeTimesTable.DataSource = teeTimeMGR.GetTeeTimeByMember(selectedMember);
                TeeTimesTable.DataBind();
            }
            else
            {
                Message.Text = "Please select a valid member";
            }
        }
        else
        {
            TeeTimesTable.DataSource = teeTimeMGR.GetTeeTimeByMember(cp.GetId());
			TeeTimesTable.DataBind();
		}
    }

    protected void Cancel_Command(object sender, CommandEventArgs e)
    {
        CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
        TeeTimes teeTimeMGR = new TeeTimes();
        if (!cp.IsMember())
        {
            teeTimeMGR.CancelTeeTime(int.Parse(e.CommandArgument.ToString()));
            MemberSelection.DataBind();
        }
        else
        {
            teeTimeMGR.CancelTeeTime(int.Parse(e.CommandArgument.ToString()));
            MemberSelection.DataBind();
        }
    }
}
