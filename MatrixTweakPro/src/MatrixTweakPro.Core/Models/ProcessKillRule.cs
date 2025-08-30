using System.Collections.Generic;

namespace MatrixTweakPro.Models
{
    /// <summary>
    /// Processes to terminate when enabling Lean Mode.
    /// </summary>
    public class ProcessKillRule
    {
        public List<string> KillList { get; set; } = new();
        public bool IgnoreMicrosoftSigned { get; set; } = true;
    }
}
