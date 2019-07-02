using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ViewScores : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
			if (!cp.IsMember())
			{
				Label1.Visible = true;
				MemberSelection.Visible = true;

			}
			else
			{
				Label1.Visible = false;
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
		Handicaps teeTimeMGR = new Handicaps();
		if (!cp.IsMember())
		{
			int selectedMember;
			if (int.TryParse(MemberSelection.Text, out selectedMember))
			{
				TeeTimesTable.DataSource = teeTimeMGR.GetHandicapByMemberAndDate(selectedMember, DatePicker.SelectedDate);
				TeeTimesTable.DataBind();
			}
			else
			{
				Message.Text = "Please select a valid member";
			}
		}
		else
		{
			TeeTimesTable.DataSource = teeTimeMGR.GetHandicapByMemberAndDate(cp.GetId(), DatePicker.SelectedDate);
			TeeTimesTable.DataBind();
		}
	}
}