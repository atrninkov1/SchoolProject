using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;

/// <summary>
/// Summary description for CustomPrincipal
/// </summary>
public class CustomPrincipal : IPrincipal
{
    private IIdentity _identity;
    private string _role;
    private bool _isMember;
    private int _id;

    public CustomPrincipal(IIdentity identity, string role, bool isMember, int id)
    {
        _identity = identity;
        _role = role;
        _isMember = isMember;
        _id = id;
    }

    public IIdentity Identity
    {
        get
        {
            return _identity;
        }
    }

    public bool IsInRole(string role)
    {
        return _role == role;
    }

    public bool IsMember()
    {
        return _isMember;
    }

    public int GetId()
    {
        return _id;
    }
}