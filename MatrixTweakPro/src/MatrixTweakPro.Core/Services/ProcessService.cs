using MatrixTweakPro.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Provides process enumeration and termination for Lean Mode.
    /// </summary>
    public class ProcessService
    {
        public IEnumerable<Process> GetUserProcesses()
        {
            return Process.GetProcesses().Where(p => !string.IsNullOrEmpty(p.MainWindowTitle));
        }

        public void KillProcesses(IEnumerable<string> names)
        {
            foreach (var proc in Process.GetProcesses().Where(p => names.Contains(p.ProcessName)))
            {
                try { proc.Kill(); } catch { }
            }
        }
    }
}
