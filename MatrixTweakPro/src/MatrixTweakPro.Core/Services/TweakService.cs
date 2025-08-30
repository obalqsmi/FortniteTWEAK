using MatrixTweakPro.Models;
using System.Collections.Generic;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Coordinates applying tweaks using the underlying services.
    /// </summary>
    public class TweakService
    {
        private readonly RegistryService _registry;
        private readonly PowerService _power;
        private readonly DnsService _dns;
        private readonly RestorePointService _restorePoint;
        private readonly Logger _logger;

        public List<ChangeRecord> Changes { get; } = new();

        public TweakService()
        {
            _registry = new RegistryService(Changes);
            _power = new PowerService(Changes);
            _dns = new DnsService(Changes);
            _restorePoint = new RestorePointService();
            _logger = new Logger();
        }

        public void Apply(TweakPlan plan)
        {
            _logger.Info("Creating restore point");
            _restorePoint.CreateRestorePoint("MatrixTweakPro Apply");

            if (plan.EnableUltimatePerformance)
            {
                _logger.Info("Enabling Ultimate Performance");
                _power.EnableUltimatePerformance();
            }

            if (plan.DisableGameDvr)
            {
                _logger.Info("Disabling GameDVR");
                _registry.SetValue(Microsoft.Win32.RegistryHive.CurrentUser, "System\\GameConfigStore", "GameDVR_Enabled", 0);
            }

            if (plan.EnableHags)
            {
                _logger.Info("Enabling HAGS");
                _registry.SetValue(Microsoft.Win32.RegistryHive.LocalMachine, "SYSTEM\\CurrentControlSet\\Control\\GraphicsDrivers", "HwSchMode", 2);
            }
        }

        public void SetDns(string[] addresses)
        {
            _dns.SetDns(addresses);
        }

        public void GenerateRevertScripts(string folder)
        {
            System.IO.Directory.CreateDirectory(folder);
            string ps1 = System.IO.Path.Combine(folder, "Revert.ps1");
            string bat = System.IO.Path.Combine(folder, "Revert.bat");
            var lines = new System.Collections.Generic.List<string>();
            foreach (var change in Changes)
            {
                if (!string.IsNullOrWhiteSpace(change.RevertCommand))
                    lines.Add(change.RevertCommand);
            }
            System.IO.File.WriteAllLines(ps1, lines);
            System.IO.File.WriteAllLines(bat, new[] { "@echo off", "powershell -ExecutionPolicy Bypass -File Revert.ps1" });
        }
    }
}
