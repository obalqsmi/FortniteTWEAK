using MatrixTweakPro.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Applies DNS changes using PowerShell.
    /// </summary>
    public class DnsService
    {
        private readonly List<ChangeRecord> _changes;
        public IReadOnlyList<ChangeRecord> Changes => _changes;

        public DnsService(List<ChangeRecord>? changes = null)
        {
            _changes = changes ?? new List<ChangeRecord>();
        }

        public void SetDns(string[] addresses)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new PlatformNotSupportedException();

            string addrParam = string.Join(",", addresses);
            string cmd = $"Get-NetAdapter | Where-Object {{ $_.Status -eq 'Up' }} | Set-DnsClientServerAddress -ServerAddresses {addrParam}";
            RunPowershell(cmd);
            _changes.Add(new ChangeRecord
            {
                Command = cmd,
                RevertCommand = "Get-NetAdapter | Where-Object { $_.Status -eq 'Up' } | Set-DnsClientServerAddress -ResetServerAddresses",
                Category = "DNS"
            });
            RunPowershell("ipconfig /flushdns");
        }

        private void RunPowershell(string command)
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
