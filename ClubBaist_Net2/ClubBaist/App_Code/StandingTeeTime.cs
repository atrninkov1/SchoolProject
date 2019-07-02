using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StandingTeeTime
/// </summary>
public class StandingTeeTime
{
    private int standingTeeTimeID;
    private DateTime startDate;
    private DateTime endDate;
    private DateTime teeTimeTime;
    private bool approved;

    public int StandingTeeTimeID
    {
        get
        {
            return standingTeeTimeID;
        }

        set
        {
            standingTeeTimeID = value;
        }
    }

    public DateTime StartDate
    {
        get
        {
            return startDate;
        }

        set
        {
            startDate = value;
        }
    }

    public DateTime EndDate
    {
        get
        {
            return endDate;
        }

        set
        {
            endDate = value;
        }
    }

    public DateTime TeeTimeTime
    {
        get
        {
            return teeTimeTime;
        }

        set
        {
            teeTimeTime = value;
        }
    }

    public bool Approved
    {
        get
        {
            return approved;
        }

        set
        {
            approved = value;
        }
    }
}