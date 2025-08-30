using System;

namespace MatrixTweakPro.Models
{
    /// <summary>
    /// Represents a reversible change made by the application.
    /// </summary>
    public class ChangeRecord
    {
        public string? RegistryPath { get; set; }
        public string? ValueName { get; set; }
        public object? OldValue { get; set; }
        public object? NewValue { get; set; }
        public string? Command { get; set; }
        public string? RevertCommand { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Risk { get; set; } = "Low";
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
