namespace MatrixTweakPro.Models
{
    /// <summary>
    /// User configuration persisted in AppData.
    /// </summary>
    public class AppConfig
    {
        public string SelectedPreset { get; set; } = "Balanced";
        public TweakPlan CustomPlan { get; set; } = new();
    }
}
