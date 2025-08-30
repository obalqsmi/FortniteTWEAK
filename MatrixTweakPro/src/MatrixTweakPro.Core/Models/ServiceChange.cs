namespace MatrixTweakPro.Models
{
    /// <summary>
    /// Represents a change to a Windows service.
    /// </summary>
    public class ServiceChange
    {
        public string Name { get; set; } = string.Empty;
        public string? PreviousStartType { get; set; }
        public string? NewStartType { get; set; }
        public bool WasRunning { get; set; }
    }
}
