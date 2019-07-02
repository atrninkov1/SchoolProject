using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateTeeTime : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
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

	protected void Search_Click(object sender, EventArgs e)
	{
		CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
		TeeTimes teeTimeMGR = new TeeTimes();
		if (!cp.IsMember())
		{
			int selectedMember;
			if (int.TryParse(MemberSelection.Text, out selectedMember))
			{
				List<TeeTime> teeTimes = teeTimeMGR.GetTeeTimeByMember(selectedMember);
				TeeTimesTable.DataSource = teeTimes;
				MemberID.Text = selectedMember.ToString();
				TeeTimesTable.DataBind();
				carts.Text = teeTimes[0].Carts.ToString();
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
			int selectedMember;
			if (int.TryParse(MemberID.Text, out selectedMember))
			{
				int cartsInt = int.Parse(carts.Text);
				teeTimeMGR.UpdateTeeTime(int.Parse(e.CommandArgument.ToString()), cartsInt);
				MemberSelection.DataBind();
			}
			else
			{
				Message.Text = "something went wrong";
			}
		}
		else
		{
			int cartsInt = int.Parse(carts.Text);
			teeTimeMGR.UpdateTeeTime(int.Parse(e.CommandArgument.ToString()), cartsInt);
			MemberSelection.DataBind();
		}
	}

	private List<DateTime> getTimesInRange(DateTime start, DateTime End)
	{
		List<DateTime> dates = new List<DateTime>();
		bool add7 = true;
		while (start.Hour < End.Hour || start.Minute <= End.Minute)
		{
			if (add7)
			{
				dates.Add(start);
				start = start.AddMinutes(7);
				add7 = false;
			}
			else
			{
				dates.Add(start);
				start = start.AddMinutes(8);
				add7 = true;
			}
		}
		return dates;
	}
}