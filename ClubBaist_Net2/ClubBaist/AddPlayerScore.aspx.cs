using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddPlayerScore : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
			if (!cp.IsMember())
			{
				MemberLabel.Visible = true;
				MemberTextBox.Visible = true;

			}
			else
			{
				MemberLabel.Visible = false;
				MemberTextBox.Visible = false;
			}
		}
		catch (Exception)
		{

		}

	}

	protected void AddScore_Click(object sender, EventArgs e)
	{
		try
		{
			Handicaps HandicapMgr = new Handicaps();
			CustomPrincipal cp = (CustomPrincipal)HttpContext.Current.User;
			if (cp.IsMember())
			{
				HandicapMgr.AddPlayer(cp.GetId(), DatePicker.SelectedDate, int.Parse(HoleTextBox1.Text), int.Parse(HoleTextBox2.Text),
					int.Parse(HoleTextBox3.Text), int.Parse(HoleTextBox4.Text), int.Parse(HoleTextBox5.Text), int.Parse(HoleTextBox6.Text),
					int.Parse(HoleTextBox7.Text), int.Parse(HoleTextBox8.Text), int.Parse(HoleTextBox9.Text), int.Parse(HoleTextBox10.Text),
					int.Parse(HoleTextBox11.Text), int.Parse(HoleTextBox12.Text), int.Parse(HoleTextBox13.Text), int.Parse(HoleTextBox14.Text),
					int.Parse(HoleTextBox15.Text), int.Parse(HoleTextBox16.Text), int.Parse(HoleTextBox17.Text), int.Parse(HoleTextBox18.Text));
				MSG.Text = "Player score added successfully";
			}
			else
			{
				HandicapMgr.AddPlayer(int.Parse(MemberTextBox.Text), DatePicker.SelectedDate, int.Parse(HoleTextBox1.Text), int.Parse(HoleTextBox2.Text),
					int.Parse(HoleTextBox3.Text), int.Parse(HoleTextBox4.Text), int.Parse(HoleTextBox5.Text), int.Parse(HoleTextBox6.Text),
					int.Parse(HoleTextBox7.Text), int.Parse(HoleTextBox8.Text), int.Parse(HoleTextBox9.Text), int.Parse(HoleTextBox10.Text),
					int.Parse(HoleTextBox11.Text), int.Parse(HoleTextBox12.Text), int.Parse(HoleTextBox13.Text), int.Parse(HoleTextBox14.Text),
					int.Parse(HoleTextBox15.Text), int.Parse(HoleTextBox16.Text), int.Parse(HoleTextBox17.Text), int.Parse(HoleTextBox18.Text));
				MSG.Text = "Player score added successfully";
			}
		}
		catch (Exception ex)
		{
			MSG.Text = ex.Message;
		}
	}
}