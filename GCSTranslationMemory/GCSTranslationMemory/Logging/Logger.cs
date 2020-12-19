using System.IO;
using System;

namespace GCSTranslationMemory
{
    /// <summary>
    /// A utility class that records and persists log data into a text file
    /// </summary>
    public class Logger
    {
        private LoggingLevels loggingLevel;
        private readonly string _dirPath;
        private string _fileName;

        public LoggingLevels LoggingLevel
        {
            get { return this.loggingLevel; }
            set { this.loggingLevel = value; }
        }

        public Logger(string dirPath)
        {
            this._dirPath = dirPath;
            this.LoggingLevel = LoggingLevels.INFO;
            Initilization();
        }

        public Logger(string dirPath, LoggingLevels logLevel)
        {
            this._dirPath = dirPath;
            this.loggingLevel = logLevel;
            Initilization();
        }

        /// <summary>
        /// Internal initialization method that handles all file-based operations
        /// to prepare the class for logging
        /// </summary>
        private void Initilization()
        {
            this._fileName = $"Logs.txt";

            FileStream fs;
            StreamWriter sw = null;

            try
            {
                DirectoryInfo logsDir = Directory.CreateDirectory($"{_dirPath}\\logs");
                fs = new FileStream(Path.Combine(logsDir.FullName, _fileName), FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex}");
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        /// <summary>
        /// Internal method that handles the log persistance operation
        /// </summary>
        protected virtual void InternalLog(string msg, LoggingLevels logLevel)
        {
            FileStream fs;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(Path.Combine(_dirPath, "logs", _fileName), FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);

                // Note: Time is configured in specified format; The logging level is padded right by 10 spaces
                sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd - HH:mm:ss}] {logLevel, -10} | {msg}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"ERROR: {ex}");
            }
            finally
            {
                if (sw != null) sw.Close();
            }
        }

        /// <summary>
        /// Logs the provided message as a debug type log entry
        /// </summary>
        public void Debug(string msg) => InternalLog(msg, LoggingLevels.DEBUG);

        /// <summary>
        /// Logs the provided message as an informational type log entry
        /// </summary>
        public void Info(string msg) => InternalLog(msg, LoggingLevels.INFO);

        /// <summary>
        /// Logs the provided message as a warning type log entry
        /// </summary>
        public void Warning(string msg) => InternalLog(msg, LoggingLevels.WARNING);

        /// <summary>
        /// Logs the provided message as an error type log entry
        /// </summary>
        public void Error(string msg) => InternalLog(msg, LoggingLevels.ERROR);

        /// <summary>
        /// Logs the provided message as an entry of the specified logging level
        /// </summary>
        public void Log(string msg, LoggingLevels logLevel)
        {
            if ((int)logLevel >= (int)this.LoggingLevel) InternalLog(msg, logLevel);
        }
    }
}
