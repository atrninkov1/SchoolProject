using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;

public partial class CreateStandingTeeTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			TimeOfDay.DataSource = getTimesInRange(new DateTime(2019, 1, 1, 7, 0, 0), new DateTime(2019, 1, 1, 20, 0, 0));
			TimeOfDay.DataBind();
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

    protected void Submit_Click(object sender, EventArgs e)
    {
		try
		{
			Message.Text = "";
			if (Convert.ToDateTime(StartDateTextBox.Text) < DateTime.Now || Convert.ToDateTime(EndDateTextBox.Text) < Convert.ToDateTime(StartDateTextBox.Text))
			{
				throw new Exception("Please select a valid start and end date");
			}
			StandingTeeTimes standingTeeTimeMGR = new StandingTeeTimes();
			DateTime selectedDate = DayOfWeek.SelectedDate;
			string[] time = TimeOfDay.SelectedItem.Text.Split(':');
			standingTeeTimeMGR.CreateStandingTeeTime(new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2])),
				Convert.ToDateTime(StartDateTextBox.Text), Convert.ToDateTime(EndDateTextBox.Text), int.Parse(Member1IDTextBox.Text));
		}
		catch (Exception ex)
		{
			Message.Text = ex.Message;
		}
    }
}
