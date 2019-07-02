using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class StandingTeeTimes
{
    public void CreateStandingTeeTime(DateTime TeeTimeTime, DateTime StartDate, DateTime EndDate, int Member1ID)
    {
        SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

        SqlCommand cancelTeeTimesCommand = new SqlCommand();
        cancelTeeTimesCommand.Connection = dbConnection;
        cancelTeeTimesCommand.CommandText = "CreateStandingTeeTime";
        cancelTeeTimesCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter teeTimeTimeParam = new SqlParameter();
        teeTimeTimeParam.SqlDbType = SqlDbType.Time;
        teeTimeTimeParam.SqlValue = TeeTimeTime.TimeOfDay;
        teeTimeTimeParam.ParameterName = "@TeeTimeTime";

        SqlParameter startDateParam = new SqlParameter();
        startDateParam.SqlDbType = SqlDbType.DateTime;
        startDateParam.SqlValue = StartDate;
        startDateParam.ParameterName = "@StartDate";

        SqlParameter endDateParam = new SqlParameter();
        endDateParam.SqlDbType = SqlDbType.DateTime;
        endDateParam.SqlValue = EndDate;
        endDateParam.ParameterName = "@EndDate";

        SqlParameter member1IDParam = new SqlParameter();
        member1IDParam.SqlDbType = SqlDbType.Int;
        member1IDParam.SqlValue = Member1ID;
        member1IDParam.ParameterName = "@Member1ID";
		
        cancelTeeTimesCommand.Parameters.Add(teeTimeTimeParam);
        cancelTeeTimesCommand.Parameters.Add(startDateParam);
        cancelTeeTimesCommand.Parameters.Add(endDateParam);
        cancelTeeTimesCommand.Parameters.Add(member1IDParam);

        cancelTeeTimesCommand.ExecuteNonQuery();

        dbConnection.Close();
    }

    public List<StandingTeeTime> GetStandingRequests()
    {

        SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

        SqlCommand getTeeTimesCommand = new SqlCommand();
        getTeeTimesCommand.Connection = dbConnection;
        getTeeTimesCommand.CommandText = "GetStandingRequests";
        getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

        List<StandingTeeTime> teeTimeRequests = new List<StandingTeeTime>();

        SqlDataReader dbReader = getTeeTimesCommand.ExecuteReader();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                StandingTeeTime teetimeRequest = new StandingTeeTime();
                string id = dbReader["StandingTeeTimeID"].ToString();
                teetimeRequest.StandingTeeTimeID = int.Parse(id);
                teetimeRequest.StartDate = Convert.ToDateTime(dbReader["StartDate"].ToString());
                teetimeRequest.EndDate = Convert.ToDateTime(dbReader["EndDate"].ToString());
                teetimeRequest.TeeTimeTime = Convert.ToDateTime(dbReader["TeeTimeTime"].ToString());
                teetimeRequest.Approved = (bool)dbReader["Approved"];
                teeTimeRequests.Add(teetimeRequest);
            }
        }

        dbConnection.Close();

        return teeTimeRequests;
    }

    public void ApproveStandingTeeTime(int StandingTeeTimeID)
    {
        SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

        SqlCommand approveTeeTimesCommand = new SqlCommand();
        approveTeeTimesCommand.Connection = dbConnection;
        approveTeeTimesCommand.CommandText = "ApproveStandingRequest";
        approveTeeTimesCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter standingTeeTimeID = new SqlParameter();
        standingTeeTimeID.SqlDbType = SqlDbType.Int;
        standingTeeTimeID.SqlValue = StandingTeeTimeID;
        standingTeeTimeID.ParameterName = "@StandingTeeTimeID";

        approveTeeTimesCommand.Parameters.Add(standingTeeTimeID);

        approveTeeTimesCommand.ExecuteScalar();

        dbConnection.Close();
    }
}
