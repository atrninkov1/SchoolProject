using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccount
/// </summary>
public class UserAccount
{
    private int accountID;
    private string username;
    private string password;
    private int memberID;
    private int gamesPlayed;
    private bool isMember;

    public int AccountID
    {
        get
        {
            return accountID;
        }

        set
        {
            accountID = value;
        }
    }

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

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public int MemberID
    {
        get
        {
            return memberID;
        }

        set
        {
            memberID = value;
        }
    }

    public int GamesPlayed
    {
        get
        {
            return gamesPlayed;
        }

        set
        {
            gamesPlayed = value;
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
}