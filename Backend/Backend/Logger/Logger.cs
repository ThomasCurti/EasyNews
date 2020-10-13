using Backend.DataAccess;
using Backend.Dbo.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Logger
{
    public static class Logger
    {
        public static async Task LogInformation(string info, string classLocation, LogRepository logger)
        {
            log log = new log
            {
                Class = classLocation,
                Type = "INFO",
                Message = DateTime.Now.ToString() + " - " + info,
            };

            await logger.Insert(log); 
        }

        public static async Task LogError(Exception e, string classLocation, LogRepository logger)
        {

            string info = e.GetType().FullName + System.Environment.NewLine + e.Message;
            while (e.InnerException != null)
            {
                e = e.InnerException;
                info += Environment.NewLine + 
                        e.GetType().FullName +
                        Environment.NewLine + 
                        e.Message;
            }

            log log = new log
            {
                Class = classLocation,
                Type = "ERROR",
                Message = DateTime.Now.ToString() + " - " + info,
            };

            await logger.Insert(log);
        }


    }
}
