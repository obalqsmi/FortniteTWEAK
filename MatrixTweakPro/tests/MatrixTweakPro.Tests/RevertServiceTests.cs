using MatrixTweakPro.Models;
using MatrixTweakPro.Services;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;

namespace MatrixTweakPro.Tests
{
    public class RevertServiceTests
    {
        [Fact]
        public void Revert_NoErrors()
        {
            var svc = new RevertService();
            var changes = new List<ChangeRecord>();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                changes.Add(new ChangeRecord
                {
                    RegistryPath = "HKCU\\Software\\MatrixTweakProTest",
                    ValueName = "TestValue",
                    OldValue = null,
                    NewValue = 1
                });
            }
            svc.Revert(changes);
        }
    }
}
