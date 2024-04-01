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

        public static void Log(string logMessage, string? logType = "")
        {
            string timeStamp = DateTime.Now.ToString();
            logMessage = logMessage.Replace("\r", "").Replace("\n", "").Replace(",", " |").Replace("The statement has been terminated.", "");

            WriteLog(timeStamp, logType, logMessage);
        }

        private static void WriteLog(string timeStamp, string logType, string logMessage)
        {
            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"{timeStamp},{logType},{logMessage}");
            }
        }
    }
}
