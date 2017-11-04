using log4net.Core;

namespace ServizioWin.Infrastructure
{
    public class Logger : ILogger
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        //private static readonly string pathLogFile = AppDomain.CurrentDomain.BaseDirectory + @"log\log.txt";        

        public void WriteLog(string text)
        {
            log.Info(text);
        }

        public void WriteLog(string text, Level level)
        {
            log.Logger.Log(log.GetType(), level, text, null);
        }


        
        //public static void WriteLog(string text)
        //{            
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
        //    sb.Append(" ");
        //    sb.Append(text);
        //    sb.Append(Environment.NewLine);

        //    // This text is added only once to the file.
        //    if (!File.Exists(pathLogFile))
        //    {
        //        // Create a file to write to.
        //        string createText = "PATH FILE: " + pathLogFile + Environment.NewLine;
        //        File.WriteAllText(pathLogFile, createText);
        //    }

        //    File.AppendAllText(pathLogFile, sb.ToString());
        //}
    }
}
