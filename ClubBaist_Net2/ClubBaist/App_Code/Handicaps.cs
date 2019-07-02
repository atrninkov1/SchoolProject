using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Handicaps
/// </summary>
public class Handicaps
{
	public void AddPlayer(int MemberID, DateTime DatePlayed, int Hole1, int Hole2, int Hole3, int Hole4,
int Hole5, int Hole6, int Hole7, int Hole8, int Hole9, int Hole10, int Hole11, int Hole12, int Hole13,
int Hole14, int Hole15, int Hole16, int Hole17, int Hole18)
	{
		double handicap = (((Hole1 + Hole2 + Hole3 + Hole4 + Hole5 + Hole6 + Hole7 + Hole8 + Hole9 +
			Hole10 + Hole11 + Hole12 + Hole13 + Hole14 + Hole15 + Hole16 + Hole17 + Hole18) - 70.6) /128) *113;
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "AddPlayerHandicap";
		getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

		SqlParameter datePlayedParam = new SqlParameter();
		datePlayedParam.SqlDbType = SqlDbType.DateTime;
		datePlayedParam.SqlValue = DatePlayed;
		datePlayedParam.ParameterName = "@DatePlayed";

		SqlParameter memberIDParam = new SqlParameter();
		memberIDParam.SqlDbType = SqlDbType.Int;
		memberIDParam.SqlValue = MemberID;
		memberIDParam.ParameterName = "@MemberID";

		SqlParameter hole1Param = new SqlParameter();
		hole1Param.SqlDbType = SqlDbType.Int;
		hole1Param.SqlValue = Hole1;
		hole1Param.ParameterName = "@Hole1";

		SqlParameter hole2Param = new SqlParameter();
		hole2Param.SqlDbType = SqlDbType.Int;
		hole2Param.SqlValue = Hole2;
		hole2Param.ParameterName = "@Hole2";

		SqlParameter hole3Param = new SqlParameter();
		hole3Param.SqlDbType = SqlDbType.Int;
		hole3Param.SqlValue = Hole3;
		hole3Param.ParameterName = "@Hole3";

		SqlParameter hole4Param = new SqlParameter();
		hole4Param.SqlDbType = SqlDbType.Int;
		hole4Param.SqlValue = Hole4;
		hole4Param.ParameterName = "@Hole4";

		SqlParameter hole5Param = new SqlParameter();
		hole5Param.SqlDbType = SqlDbType.Int;
		hole5Param.SqlValue = Hole5;
		hole5Param.ParameterName = "@Hole5";

		SqlParameter hole6Param = new SqlParameter();
		hole6Param.SqlDbType = SqlDbType.Int;
		hole6Param.SqlValue = Hole6;
		hole6Param.ParameterName = "@Hole6";

		SqlParameter hole7Param = new SqlParameter();
		hole7Param.SqlDbType = SqlDbType.Int;
		hole7Param.SqlValue = Hole7;
		hole7Param.ParameterName = "@Hole7";

		SqlParameter hole8Param = new SqlParameter();
		hole8Param.SqlDbType = SqlDbType.Int;
		hole8Param.SqlValue = Hole8;
		hole8Param.ParameterName = "@Hole8";

		SqlParameter hole9Param = new SqlParameter();
		hole9Param.SqlDbType = SqlDbType.Int;
		hole9Param.SqlValue = Hole9;
		hole9Param.ParameterName = "@Hole9";

		SqlParameter hole10Param = new SqlParameter();
		hole10Param.SqlDbType = SqlDbType.Int;
		hole10Param.SqlValue = Hole10;
		hole10Param.ParameterName = "@Hole10";

		SqlParameter hole11Param = new SqlParameter();
		hole11Param.SqlDbType = SqlDbType.Int;
		hole11Param.SqlValue = Hole11;
		hole11Param.ParameterName = "@Hole11";

		SqlParameter hole12Param = new SqlParameter();
		hole12Param.SqlDbType = SqlDbType.Int;
		hole12Param.SqlValue = Hole12;
		hole12Param.ParameterName = "@Hole12";

		SqlParameter hole13Param = new SqlParameter();
		hole13Param.SqlDbType = SqlDbType.Int;
		hole13Param.SqlValue = Hole13;
		hole13Param.ParameterName = "@Hole13";

		SqlParameter hole14Param = new SqlParameter();
		hole14Param.SqlDbType = SqlDbType.Int;
		hole14Param.SqlValue = Hole14;
		hole14Param.ParameterName = "@Hole14";

		SqlParameter hole15Param = new SqlParameter();
		hole15Param.SqlDbType = SqlDbType.Int;
		hole15Param.SqlValue = Hole15;
		hole15Param.ParameterName = "@Hole15";

		SqlParameter hole16Param = new SqlParameter();
		hole16Param.SqlDbType = SqlDbType.Int;
		hole16Param.SqlValue = Hole16;
		hole16Param.ParameterName = "@Hole16";

		SqlParameter hole17Param = new SqlParameter();
		hole17Param.SqlDbType = SqlDbType.Int;
		hole17Param.SqlValue = Hole17;
		hole17Param.ParameterName = "@Hole17";

		SqlParameter hole18Param = new SqlParameter();
		hole18Param.SqlDbType = SqlDbType.Int;
		hole18Param.SqlValue = Hole18;
		hole18Param.ParameterName = "@Hole18";

		SqlParameter handicapParam = new SqlParameter();
		handicapParam.SqlDbType = SqlDbType.Float;
		handicapParam.SqlValue = handicap;
		handicapParam.ParameterName = "@Handicap";

		getTeeTimesCommand.Parameters.Add(memberIDParam);
		getTeeTimesCommand.Parameters.Add(datePlayedParam);
		getTeeTimesCommand.Parameters.Add(hole1Param);
		getTeeTimesCommand.Parameters.Add(hole2Param);
		getTeeTimesCommand.Parameters.Add(hole3Param);
		getTeeTimesCommand.Parameters.Add(hole4Param);
		getTeeTimesCommand.Parameters.Add(hole5Param);
		getTeeTimesCommand.Parameters.Add(hole6Param);
		getTeeTimesCommand.Parameters.Add(hole7Param);
		getTeeTimesCommand.Parameters.Add(hole8Param);
		getTeeTimesCommand.Parameters.Add(hole9Param);
		getTeeTimesCommand.Parameters.Add(hole10Param);
		getTeeTimesCommand.Parameters.Add(hole11Param);
		getTeeTimesCommand.Parameters.Add(hole12Param);
		getTeeTimesCommand.Parameters.Add(hole13Param);
		getTeeTimesCommand.Parameters.Add(hole14Param);
		getTeeTimesCommand.Parameters.Add(hole15Param);
		getTeeTimesCommand.Parameters.Add(hole16Param);
		getTeeTimesCommand.Parameters.Add(hole17Param);
		getTeeTimesCommand.Parameters.Add(hole18Param);
		getTeeTimesCommand.Parameters.Add(handicapParam);

		getTeeTimesCommand.ExecuteNonQuery();

		dbConnection.Close();
	}

	public List<Handicap> GetHandicapByMemberAndDate(int MemberID, DateTime Date)
	{
		SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

		SqlCommand getTeeTimesCommand = new SqlCommand();
		getTeeTimesCommand.Connection = dbConnection;
		getTeeTimesCommand.CommandText = "GetScoresByDateAndMember";
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

		List<Handicap> handicaps = new List<Handicap>();

		if (dbReader.HasRows)
		{
			while (dbReader.Read())
			{
				string date = dbReader["DatePlayed"].ToString();
				Handicap teeTime = new Handicap();
				teeTime.DatePlayed = Convert.ToDateTime(date);
				teeTime.PlayerHandicap = float.Parse(dbReader["Handicap"].ToString());
				handicaps.Add(teeTime);
			}
		}

		dbConnection.Close();
		return handicaps;
	}
}