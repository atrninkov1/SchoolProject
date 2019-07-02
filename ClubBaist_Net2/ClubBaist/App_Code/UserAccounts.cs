using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccounts
/// </summary>
public class UserAccounts
{
    public UserInfo Login(string Username, string Password)
    {
        SqlConnection dbConnection = new SqlConnection();
		//School
		//dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=(LocalDb)\\MSSQLLocalDB;Database=ClubBaist;";
		//home
		dbConnection.ConnectionString = "Persist Security Info=false;Integrated Security=true;Server=.;Database=ClubBaist;";
		dbConnection.Open();

        SqlCommand loginCommand = new SqlCommand();
        loginCommand.Connection = dbConnection;
        loginCommand.CommandText = "Login";
        loginCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter passwordParam = new SqlParameter();
        passwordParam.SqlDbType = SqlDbType.VarChar;
        passwordParam.SqlValue = Password;
        passwordParam.ParameterName = "@Password";

        SqlParameter usernameParam = new SqlParameter();
        usernameParam.SqlDbType = SqlDbType.VarChar;
        usernameParam.SqlValue = Username;
        usernameParam.ParameterName = "@Username";

        loginCommand.Parameters.Add(usernameParam);
        loginCommand.Parameters.Add(passwordParam);

        SqlDataReader dbReader = loginCommand.ExecuteReader();

        UserInfo account = new UserInfo();

        if (dbReader.HasRows)
        {
            while (dbReader.Read())
            {
                account.Username = dbReader["Username"].ToString();
                account.Role = dbReader["Role"].ToString();
                account.IsMember = (bool)dbReader["IsMember"];
                account.MemberId = int.Parse(dbReader["MemberId"].ToString());
            }
        }

        dbConnection.Close();
        return account;
    }
}

public struct UserInfo
{
    private string username;
    private string role;
    private bool isMember;
    private int memberId;

    public string Username
    {
        get
        {
            return username;
        }

        set
        {
            username = value;
        }
    }

    public string Role
    {
        get
        {
            return role;
        }

        set
        {
            role = value;
        }
    }

    public bool IsMember
    {
        get
        {
            return isMember;
        }

        set
        {
            isMember = value;
        }
    }

    public int MemberId
    {
        get
        {
            return memberId;
        }

        set
        {
            memberId = value;
        }
    }
}