using Microsoft.Win32;
using MatrixTweakPro.Models;
using System;
using System.Collections.Generic;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Handles registry operations with backup for revert.
    /// </summary>
    public class RegistryService
    {
        private readonly List<ChangeRecord> _changes;
        public IReadOnlyList<ChangeRecord> Changes => _changes;

        public RegistryService(List<ChangeRecord>? changes = null)
        {
            _changes = changes ?? new List<ChangeRecord>();
        }

        public object? GetValue(RegistryHive hive, string path, string name)
        {
            using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
            using var key = baseKey.OpenSubKey(path);
            return key?.GetValue(name);
        }

        public void SetValue(RegistryHive hive, string path, string name, object value)
        {
            using var baseKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry64);
            using var key = baseKey.CreateSubKey(path);
            var old = key.GetValue(name);
            key.SetValue(name, value);
            _changes.Add(new ChangeRecord
            {
                RegistryPath = $"{hive}\\{path}",
                ValueName = name,
                OldValue = old,
                NewValue = value,
                Category = "Registry"
            });
        }
    }
}
