using MatrixTweakPro.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Applies service configuration changes.
    /// </summary>
    public class ServiceTweaksService
    {
        private readonly List<ChangeRecord> _changes;
        public ServiceTweaksService(List<ChangeRecord>? changes = null)
        {
            _changes = changes ?? new List<ChangeRecord>();
        }

        public void SetServiceStart(string name, string startType)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;
            string cmd = $"Set-Service -Name {name} -StartupType {startType}";
            Run(cmd);
            _changes.Add(new ChangeRecord
            {
                Command = cmd,
                RevertCommand = $"Set-Service -Name {name} -StartupType Automatic",
                Category = "Service"
            });
        }

        private void Run(string command)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-ExecutionPolicy Bypass -Command \"{command}\"",
                CreateNoWindow = true,
                UseShellExecute = false
            };
            var proc = Process.Start(psi);
            proc.WaitForExit();
        }
    }
}
