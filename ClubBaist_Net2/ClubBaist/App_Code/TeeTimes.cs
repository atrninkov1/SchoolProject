using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TeeTimes
{
	public List<DateTime> GetScheduledTeeTimes(DateTime Day)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "GetBookedTeeTimes";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter dayParam = new SqlParameter();
		dayParam.SqlDbType = SqlDbType.Date;
		dayParam.SqlValue = Day;
		dayParam.ParameterName = "@Day";

		getTeeTimesCommand.Parameters.Add(dayParam);

		SqlDataReader dbReader = getTeeTimesCommand.ExecuteReader();

		List<DateTime> bookedDates = new List<DateTime>();

		if (dbReader.HasRows)
		{
			while (dbReader.Read())
			{
				string date = dbReader["ScheduledTime"].ToString();
				DateTime bookedDate = Convert.ToDateTime(date);
				bookedDates.Add(bookedDate);
			}
		}

		dbConnection.Close();
		return bookedDates;
	}

	public void ScheduleTeeTime(DateTime TeeTimeDate, int MemberID, int Carts)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "ScheduleTeeTime";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter teeTimeDateParam = new SqlParameter();
		teeTimeDateParam.SqlDbType = SqlDbType.DateTime;
		teeTimeDateParam.SqlValue = TeeTimeDate;
		teeTimeDateParam.ParameterName = "@TeeTimeDate";

		SqlParameter memberIDParam = new SqlParameter();
		memberIDParam.SqlDbType = SqlDbType.Int;
		memberIDParam.SqlValue = MemberID;
		memberIDParam.ParameterName = "@MemberID";

		SqlParameter cartsParam = new SqlParameter();
		cartsParam.SqlDbType = SqlDbType.Int;
		cartsParam.SqlValue = Carts;
		cartsParam.ParameterName = "@Carts";

		getTeeTimesCommand.Parameters.Add(teeTimeDateParam);
		getTeeTimesCommand.Parameters.Add(memberIDParam);
		getTeeTimesCommand.Parameters.Add(cartsParam);

		getTeeTimesCommand.ExecuteNonQuery();

		dbConnection.Close();
	}


	public void UpdateTeeTime(int TeeTimeID, int Carts)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "UpdateTeeTime";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter teeTimeDateParam = new SqlParameter();
		teeTimeDateParam.SqlDbType = SqlDbType.Int;
		teeTimeDateParam.SqlValue = TeeTimeID;
		teeTimeDateParam.ParameterName = "@TeeTimeID";

		SqlParameter cartsParam = new SqlParameter();
		cartsParam.SqlDbType = SqlDbType.Int;
		cartsParam.SqlValue = Carts;
		cartsParam.ParameterName = "@Carts";

		getTeeTimesCommand.Parameters.Add(teeTimeDateParam);
		getTeeTimesCommand.Parameters.Add(cartsParam);

		getTeeTimesCommand.ExecuteNonQuery();

		dbConnection.Close();
	}

	public List<TeeTime> GetTeeTimeByMember(int MemberID)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "GetTeeTimeByMember";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter dayParam = new SqlParameter();
		dayParam.SqlDbType = SqlDbType.Int;
		dayParam.SqlValue = MemberID;
		dayParam.ParameterName = "@MemberID";

		getTeeTimesCommand.Parameters.Add(dayParam);

		SqlDataReader dbReader = getTeeTimesCommand.ExecuteReader();

		List<TeeTime> teeTimes = new List<TeeTime>();

		if (dbReader.HasRows)
		{
			while (dbReader.Read())
			{
				string date = dbReader["ScheduledTime"].ToString();
				TeeTime teeTime = new TeeTime();
				teeTime.TeeTimeID = int.Parse(dbReader["TeeTimeID"].ToString());
				teeTime.ScheduledTime = Convert.ToDateTime(date);
				teeTime.Carts = int.Parse(dbReader["Carts"].ToString());
				teeTimes.Add(teeTime);
			}
		}

		dbConnection.Close();
		return teeTimes;
	}

	public List<TeeTime> GetTeeTimeByMemberAndDate(int MemberID, DateTime Date)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "GetTeeTimeByDateAndMember";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter memberParam = new SqlParameter();
		memberParam.SqlDbType = SqlDbType.Int;
		memberParam.SqlValue = MemberID;
		memberParam.ParameterName = "@MemberID";

		SqlParameter dayParam = new SqlParameter();
		dayParam.SqlDbType = SqlDbType.Date;
		dayParam.SqlValue = Date;
		dayParam.ParameterName = "@Date";

		getTeeTimesCommand.Parameters.Add(memberParam);
		getTeeTimesCommand.Parameters.Add(dayParam);

		SqlDataReader dbReader = getTeeTimesCommand.ExecuteReader();

		List<TeeTime> teeTimes = new List<TeeTime>();

		if (dbReader.HasRows)
		{
			while (dbReader.Read())
			{
				string date = dbReader["ScheduledTime"].ToString();
				TeeTime teeTime = new TeeTime();
				teeTime.TeeTimeID = int.Parse(dbReader["TeeTimeID"].ToString());
				teeTime.ScheduledTime = Convert.ToDateTime(date);
				teeTime.Carts = int.Parse(dbReader["Carts"].ToString());
				teeTimes.Add(teeTime);
			}
		}

		dbConnection.Close();
		return teeTimes;
	}

	public void CancelTeeTime(int TeeTimeID)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand cancelTeeTimesCommand = new SqlCommand();
		cancelTeeTimesCommand.Connection = dbConnection;
		cancelTeeTimesCommand.CommandText = "CancelTeeTime";
		cancelTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter teeTimeParam = new SqlParameter();
		teeTimeParam.SqlDbType = SqlDbType.Int;
		teeTimeParam.SqlValue = TeeTimeID;
		teeTimeParam.ParameterName = "@TeeTimeID";

		cancelTeeTimesCommand.Parameters.Add(teeTimeParam);

		cancelTeeTimesCommand.ExecuteNonQuery();

		dbConnection.Close();
	}
}
