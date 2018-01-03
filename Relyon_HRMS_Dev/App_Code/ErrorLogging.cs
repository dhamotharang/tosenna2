using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;

using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using context = System.Web.HttpContext;

/// <summary>
/// Summary description for ErrorLogging
/// </summary>
/// 
namespace SchoolNet
{

    public class ErrorLogging
    {

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ee">The ee.</param>
        /// <param name="userFriendlyError">The user friendly error.</param>
        /// <returns></returns>
        public static string LogError(Exception ee, string userFriendlyError)
        {
            string logType = ConfigurationManager.AppSettings["ErrorLogType"].ToString();
            if (logType.Equals("1"))
            {
                return LogErrorToLogFile(ee, userFriendlyError);
            }
            else
            {
                return LogErrorInSystemEvent(ee, userFriendlyError);
            }
        }

        /// <summary>
        /// Log the error and return
        /// </summary>
        /// <param name="ee">The ee.</param>
        /// <param name="userFriendlyError">The user friendly error.</param>
        /// <returns></returns>
        public static string LogErrorToLogFile(Exception ee, string userFriendlyError)
        {
            try
            {
                string path = context.Current.Server.MapPath("~/ErrorLogging/");
                // check if directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = path + DateTime.Today.ToString("dd-MMM-yy") + ".log";
                // check if file exist
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }
                // log the error now
                using (StreamWriter writer = File.AppendText(path))
                {
                    string error = "\r\nLog written at : " + DateTime.Now.ToString() +
                                   "\r\nError occured on page : " + context.Current.Request.Url.ToString() +
                                   "\r\n\r\nHere is the actual error :\n" + ee.ToString();
                    writer.WriteLine(error);
                    writer.WriteLine("==========================================");
                    writer.Flush();
                    writer.Close();
                }
                return userFriendlyError;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Logs the error in system event.
        /// </summary>
        /// <param name="ee">The ee.</param>
        /// <param name="userFriendlyError">The user friendly error.</param>
        /// <returns></returns>
        public static string LogErrorInSystemEvent(Exception ee, string userFriendlyError)
        {
            string eventLog = "Sample1Error1";
            string eventSource = "ErrorLoggingSampleApp1";

            // check if source exists
            if (!EventLog.SourceExists(eventSource))
            {
                System.Diagnostics.EventLog.CreateEventSource(eventSource, eventLog);
            }

            // create the instance of the EventLog and log the error
            using (EventLog myLog = new EventLog(eventLog))
            {
                myLog.Source = eventSource;

                string error = "\r\nLog written at : " + DateTime.Now.ToString() +
                               "\r\nError occured on page : " + context.Current.Request.Url.ToString() +
                               "\r\n\nHere is the actual error :\n" + ee.ToString();
                myLog.WriteEntry(error, EventLogEntryType.Error);
            }

            return userFriendlyError;
        }
    }
}