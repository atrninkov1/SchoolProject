using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TeeTime
/// </summary>
public class TeeTime
{
    private int teeTimeID;
    private DateTime scheduledTime;
    private bool canceled;
	private int carts;

    public int TeeTimeID
    {
        get
        {
            return teeTimeID;
        }

        set
        {
            teeTimeID = value;
        }
    }

    public DateTime ScheduledTime
    {
        get
        {
            return scheduledTime;
        }

        set
        {
            scheduledTime = value;
        }
    }

    public bool Canceled
    {
        get
        {
            return canceled;
        }

        set
        {
            canceled = value;
        }
    }

	public int Carts
	{
		get
		{
			return carts;
		}

		set
		{
			carts = value;
		}
	}
}
