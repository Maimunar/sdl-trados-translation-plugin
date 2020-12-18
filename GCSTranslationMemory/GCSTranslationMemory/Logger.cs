using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GCSTranslationMemory
{
    public class Logger
    {
        private LoggingLevels loggingLevel;
        private string _dirPath;
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

        private void Initilization()
        {
            this._fileName = $"Logs.txt";

            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                DirectoryInfo logsDir = Directory.CreateDirectory($"{_dirPath}\\logs");
                fs = new FileStream(Path.Combine(logsDir.FullName, _fileName), FileMode.OpenOrCreate, FileAccess.Write);
                sw = new StreamWriter(fs);

                MessageBox.Show(Path.Combine(logsDir.FullName, _fileName));

                sw.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss")}] Logger initialized");
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

        protected virtual void InternalLog(string msg, LoggingLevels logLevel)
        {
            FileStream fs = null;
            StreamWriter sw = null;

            try
            {
                fs = new FileStream(Path.Combine(_dirPath, "logs", _fileName), FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);

                MessageBox.Show(Path.Combine(_dirPath, "logs", _fileName));

                sw.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd - HH:mm:ss")}] {logLevel.ToString().PadRight(10)} | {msg}");
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

        public void Debug(string msg)
        {
            InternalLog(msg, LoggingLevels.DEBUG);
        }

        public void Info(string msg)
        {
            InternalLog(msg, LoggingLevels.INFO);
        }

        public void Warning(string msg)
        {
            InternalLog(msg, LoggingLevels.WARNING);
        }

        public void Error(string msg)
        {
            InternalLog(msg, LoggingLevels.ERROR);
        }

        public void Log(string msg, LoggingLevels logLevel)
        {
            if ((int)logLevel >= (int)this.LoggingLevel) InternalLog(msg, logLevel);
        }
    }

}
