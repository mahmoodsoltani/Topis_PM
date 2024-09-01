using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Text;
using System.Diagnostics;
using System.Configuration;

/// <summary>
/// Summary description for Logger
/// </summary>
public class Logger
{
	public Logger()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void ErrorLog(Exception exception)
    {
        try
        {
            ErrorLog(exception, EventLogEntryType.Error);
        }
        catch
        { }
    }
    public static void ErrorLog(Exception exception, EventLogEntryType eventLogEntryType)
    {
        try
        {
            if (exception != null)
            {
                StringBuilder exMessage = new StringBuilder();
                do
                {
                    exMessage.Append("Exception Type" + Environment.NewLine);
                    exMessage.Append(exception.GetType().Name);
                    exMessage.Append(Environment.NewLine + Environment.NewLine);
                    exMessage.Append("Message" + Environment.NewLine);
                    exMessage.Append(exception.Message + Environment.NewLine + Environment.NewLine);
                    exMessage.Append("Stack Trace" + Environment.NewLine);
                    exMessage.Append(exception.StackTrace + Environment.NewLine + Environment.NewLine);
                    exception = exception.InnerException;
                } while (exception != null);
                string logProvider = ConfigurationManager.AppSettings["LogProvider"];
                if (logProvider.ToLower() == "database")
                {
                    ErrorLogToDB(exMessage.ToString(), eventLogEntryType);

                }
                else
                    if (logProvider.ToLower() == "eventviewer")
                    {
                        ErrorLogToEventViewer(exMessage.ToString(), eventLogEntryType);

                    }
                    else if (logProvider.ToLower() == "both")
                    {
                        ErrorLogToDB(exMessage.ToString(), eventLogEntryType);
                        ErrorLogToEventViewer(exMessage.ToString(), eventLogEntryType);
                    }
            }
        }
        catch
        { }

    }

    private static void ErrorLogToEventViewer(string errorLog, EventLogEntryType eventLogEntryType)
    {
        if (!EventLog.SourceExists("MRC.co.ir"))
        {
            System.Diagnostics.EventLog.CreateEventSource("MRK.co.ir", "MRKSign");
        }
            EventLog eventLog = new EventLog("MRKSign");
            eventLog.Source = "MRC.co.ir";
            eventLog.WriteEntry(errorLog,eventLogEntryType);
        
    }

    private static void ErrorLogToDB(string errorLog, EventLogEntryType eventLogEntryType)
    {
      ////  MrkSignSecurService.SecurServiceClient p = new MrkSignSecurService.SecurServiceClient("WSHttpBinding_ISecurService");
     ////   p.Errror_Log(errorLog,eventLogEntryType);
        // p.PlayerSnapshotUpdateByMac(mac, img);
    }
}