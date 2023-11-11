using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public static class Logging
    {
        public static string LOG_PATH { get; set; } = string.Empty;

        //Used in CPlatApiCore
        public static bool WriteLog(string content)
        {
            bool result;

            try
            {
                if (string.IsNullOrEmpty(LOG_PATH))
                {
                    string thisSolutionName = Assembly.GetEntryAssembly()!.GetName().Name!;
                    LOG_PATH = AppDomain.CurrentDomain.BaseDirectory + $@"{thisSolutionName}_log\{thisSolutionName}_yyyyMMdd.log";
                }

                Methods.CreateDirectory(LOG_PATH);

                DateTime dateTime = DateTime.Now;
                string logPath = LOG_PATH.Replace("yyyyMMdd", dateTime.ToString("yyyyMMdd"));
                string dateStr = "[" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "] ";
                content = dateStr + content + Environment.NewLine;

                Methods.SaveFile(logPath, content);
                result = true;
            }
            catch (Exception ex)
            {
                Logging.WriteLog($"[{MethodBase.GetCurrentMethod()!.Name}] {ex.Message}");
                throw;
            }

            return result;
        }

        public static bool WriteServiceLog(string serviceName, string content)
        {
            bool result;

            try
            {
                string thisSolutionName = Assembly.GetEntryAssembly()!.GetName().Name!;
                string seviceLogPath = $@"{AppDomain.CurrentDomain.BaseDirectory}{thisSolutionName}_{serviceName}_log\{thisSolutionName}_yyyyMMdd.log";

                Methods.CreateDirectory(seviceLogPath);

                DateTime dateTime = DateTime.Now;
                string logPath = seviceLogPath.Replace("yyyyMMdd", dateTime.ToString("yyyyMMdd"));
                string dateStr = "[" + dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "] ";
                content = dateStr + content + Environment.NewLine;

                Methods.SaveFile(logPath, content);
                result = true;
            }
            catch (Exception ex)
            {
                Logging.WriteLog($"[{MethodBase.GetCurrentMethod()!.Name}] {ex.Message}");
                throw;
            }

            return result;
        }
    }
}