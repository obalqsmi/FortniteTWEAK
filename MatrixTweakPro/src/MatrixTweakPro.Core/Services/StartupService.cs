using Microsoft.Win32;
using System.Collections.Generic;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Manages startup applications.
    /// </summary>
    public class StartupService
    {
        public IEnumerable<string> EnumerateRunKeys()
        {
            if (!System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                yield break;

            using var key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", false);
            if (key != null)
            {
                foreach (var value in key.GetValueNames())
                    yield return value;
            }
        }
    }
}
