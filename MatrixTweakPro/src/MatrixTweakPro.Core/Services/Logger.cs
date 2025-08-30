using System;
using System.IO;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Simple file based logger writing JSON lines to %ProgramData%\MatrixTweakPro\logs.
    /// </summary>
    public class Logger
    {
        private readonly string _logDir;

        public Logger()
        {
            var programData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            _logDir = Path.Combine(programData, "MatrixTweakPro", "logs");
            Directory.CreateDirectory(_logDir);
        }

        public void Info(string message)
        {
            Write("INFO", message);
        }

        public void Error(string message)
        {
            Write("ERROR", message);
        }

        private void Write(string level, string message)
        {
            var path = Path.Combine(_logDir, $"{DateTime.UtcNow:yyyy-MM-dd}.log");
            var line = System.Text.Json.JsonSerializer.Serialize(new { ts = DateTime.UtcNow, level, message });
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
