using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScheduleTeeTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			TimeSelection.DataSource = getTimesInRange(new DateTime(2019, 1, 1, 7, 0, 0), new DateTime(2019, 1, 1, 20, 0, 0));
			TimeSelection.DataBind();
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

  //  protected void GetAvailableTimes_Click(object sender, EventArgs e)
  //  {
		//try
		//{
		//		Message.Text = "";
		//		if (DateSelection.SelectedDate < DateTime.Now || DateSelection.SelectedDate > DateTime.Now.AddDays(7))
		//		{
		//			throw new Exception("Date must be within this week");
		//		}
		//		TeeTimes teeTimeMGR = new TeeTimes();
		//		DateTime selectedDate = DateSelection.SelectedDate;
		//		DateTime start = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 7, 0, 0);
		//		DateTime end = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 20, 0, 0);
		//		List<DateTime> dates = getTimesInRange(start, end);
		//		List<DateTime> bookedDates = teeTimeMGR.GetScheduledTeeTimes(selectedDate);
		//		foreach (var date in bookedDates)
		//		{
		//			dates.Remove(date);
		//		}
		//		TimeSelection.DataSource = dates;
		//		TimeSelection.DataBind();
			
		//}
		//catch (Exception ex)
		//{
		//	Message.Text = ex.Message;
		//}
  //  }

    protected void Submit_Click(object sender, EventArgs e)
    {
        try
        {
			Message.Text = "Tee time scheduled";
			if (DateSelection.SelectedDate < DateTime.Now || DateSelection.SelectedDate > DateTime.Now.AddDays(7))
			{
				throw new Exception("Date must be within this week");
			}
			TeeTimes teeTimeMGR = new TeeTimes();
			string[] time = TimeSelection.SelectedItem.Text.Split(':');
			DateTime teeTimeDate = Convert.ToDateTime(TimeSelection.SelectedValue);
            teeTimeMGR.ScheduleTeeTime(new DateTime(teeTimeDate.Year, teeTimeDate.Month, teeTimeDate.Day, int.Parse(time[0]), int.Parse(time[1]), int.Parse(time[2])),
                int.Parse(Member.Text), int.Parse(Carts.Text));
        }
        catch (Exception ex)
        {
            Message.Text = ex.Message;
        }
    }
}