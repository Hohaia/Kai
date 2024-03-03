using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logging
{
    public static class Logger
    {
        static string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Kai", "Log.csv");

        public static void Log(string message)
        {
            //TODO
        }
        public static void LogError(string timeStamp, string logMessage)
        {
            string logType = "ERROR";
            logMessage = logMessage.Replace("\r", "").Replace("\n", "").Replace("The statement has been terminated.", "");

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"{timeStamp},{logType},{logMessage}");
            }
        }
    }
}
