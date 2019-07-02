using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Member
/// </summary>
public class Member
{
    private int memberID;
    private string firstName;
    private string lastName;
    private string email;
    private int roleID;

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

    public string FirstName
    {
        get
        {
            return firstName;
        }

        set
        {
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }

        set
        {
            lastName = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public int RoleID
    {
        get
        {
            return roleID;
        }

        set
        {
            roleID = value;
        }
    }
}