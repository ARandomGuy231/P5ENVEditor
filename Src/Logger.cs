using System.Diagnostics;

namespace P5ENVEditor
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppContext.BaseDirectory, "latest.log");
        private static readonly string logFileBackupPath = Path.Combine(AppContext.BaseDirectory, "previous.log");

        public static void GenerateNewLog()
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    File.Move(logFilePath, logFileBackupPath, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while making log file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            WriteToLog($"Starting {Application.ProductName} v{Application.ProductVersion.Split("+")[0]}", LogLevel.Info);
        }

        public static void WriteToLog(string message, LogLevel logLevel)
        {
            if (logLevel == LogLevel.Debug)
            {
                Debug.WriteLine($"[{logLevel.ToString()}] {message}");
                return;
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    DateTime date = DateTime.Now;
                    writer.WriteLine($"[{date.ToString("d/M/yyyy h:mm:ss tt")}] [{logLevel.ToString()}] {message}");
                }

                Debug.WriteLine($"[{logLevel.ToString()}] {message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[{LogLevel.Error.ToString()}] Error while writing to log: {ex.Message}");
            }
        }
    }

    public enum LogLevel
    {
        Info, Warn, Error, Debug
    }
}
