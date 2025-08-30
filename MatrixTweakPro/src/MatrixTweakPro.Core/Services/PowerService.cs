using MatrixTweakPro.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Power plan related operations.
    /// </summary>
    public class PowerService
    {
        private readonly List<ChangeRecord> _changes;
        public IReadOnlyList<ChangeRecord> Changes => _changes;

        public PowerService(List<ChangeRecord>? changes = null)
        {
            _changes = changes ?? new List<ChangeRecord>();
        }

        public void EnableUltimatePerformance()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException();
            string guid = "e9a42b02-d5df-448d-aa00-03f14749eb61";
            Run("powercfg -duplicatescheme " + guid);
            Run("powercfg -setactive " + guid);
            _changes.Add(new ChangeRecord
            {
                Command = "powercfg -setactive " + guid,
                RevertCommand = "powercfg -setactive SCHEME_BALANCED",
                Category = "Power"
            });
        }

        private void Run(string args)
        {
            var proc = Process.Start(new ProcessStartInfo
            {
                FileName = "powercfg",
                Arguments = args,
                CreateNoWindow = true,
                UseShellExecute = false
            });
            proc.WaitForExit();
        }
    }
}
