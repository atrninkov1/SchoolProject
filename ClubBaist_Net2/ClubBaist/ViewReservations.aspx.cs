using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Reservations : System.Web.UI.Page
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
		TeeTimes teeTimeMGR = new TeeTimes();
		if (!cp.IsMember())
		{
			int selectedMember;
			if (int.TryParse(MemberSelection.Text, out selectedMember))
			{
				TeeTimesTable.DataSource = teeTimeMGR.GetTeeTimeByMemberAndDate(selectedMember, DatePicker.SelectedDate);
				TeeTimesTable.DataBind();
				Message.Text = "Search executed";
			}
			else
			{
				Message.Text = "Please select a valid member";
			}
		}
		else
		{
			TeeTimesTable.DataSource = teeTimeMGR.GetTeeTimeByMemberAndDate(cp.GetId(), DatePicker.SelectedDate);
			TeeTimesTable.DataBind();
		}
	}
}