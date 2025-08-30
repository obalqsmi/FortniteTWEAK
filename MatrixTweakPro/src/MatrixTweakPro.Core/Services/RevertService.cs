using MatrixTweakPro.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Reverts previously captured changes.
    /// </summary>
    public class RevertService
    {
        public void Revert(IEnumerable<ChangeRecord> records)
        {
            foreach (var record in records)
            {
                try
                {
                    if (record.RegistryPath != null && record.ValueName != null)
                    {
                        var hive = ParseHive(record.RegistryPath, out string sub);
                        using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
                        using var key = baseKey.CreateSubKey(sub);
                        if (record.OldValue == null)
                            key.DeleteValue(record.ValueName, false);
                        else
                            key.SetValue(record.ValueName, record.OldValue);
                    }
                    else if (!string.IsNullOrWhiteSpace(record.RevertCommand))
                    {
                        RunCommand(record.RevertCommand);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Failed to revert {record.Category}: {ex.Message}");
                }
            }
        }

        private RegistryHive ParseHive(string path, out string subKey)
        {
            var parts = path.Split('\\', 2);
            subKey = parts.Length > 1 ? parts[1] : string.Empty;
            return parts[0] switch
            {
                "HKLM" or "HKEY_LOCAL_MACHINE" => RegistryHive.LocalMachine,
                "HKCU" or "HKEY_CURRENT_USER" => RegistryHive.CurrentUser,
                _ => RegistryHive.CurrentUser
            };
        }

        private void RunCommand(string command)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return;
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
