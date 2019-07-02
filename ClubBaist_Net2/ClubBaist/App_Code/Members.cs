using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Members
/// </summary>
public class Members
{
    public List<Member> GetAllMembers()
    {
        SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

        SqlCommand getTeeTimesCommand = new SqlCommand();
        getTeeTimesCommand.Connection = dbConnection;
        getTeeTimesCommand.CommandText = "GetAllMembers";
        getTeeTimesCommand.CommandType = CommandType.StoredProcedure;

        SqlDataReader dbReader = getTeeTimesCommand.ExecuteReader();

        List<Member> members = new List<Member>();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                Member member = new Member()
                {
                    MemberID = int.Parse(dbReader["MemberID"].ToString()),
                    FirstName = dbReader["FirstName"].ToString(),
                    LastName = dbReader["LastName"].ToString(),
                    Email = dbReader["Email"].ToString(),
                    //RoleID = int.Parse(dbReader["RoleID"].ToString())
                };
                members.Add(member);
            }
        }

        dbConnection.Close();
        return members;
    }
}

