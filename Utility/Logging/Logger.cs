﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Logging
{
    public enum LogType
    {
        INFO,
        SQL_QUERY,
        ERROR,
        CRITICAL
    }

    public static class Logger
    {
        static string _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Kai", "Log.csv");

        public static void Log(string logMessage, LogType? type = LogType.INFO)
        {
            logMessage = logMessage.Replace("\r", "").Replace("\n", "").Replace(",", " |").Replace("The statement has been terminated.", "");

            using (StreamWriter sw = File.AppendText(_filePath))
            {
                sw.WriteLine($"{type},{DateTime.Now},{logMessage}");
            }
        }
    }
}
