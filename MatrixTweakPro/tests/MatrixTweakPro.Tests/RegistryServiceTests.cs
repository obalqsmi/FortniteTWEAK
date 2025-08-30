using MatrixTweakPro.Services;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Xunit;

namespace MatrixTweakPro.Tests
{
    public class RegistryServiceTests
    {
        [Fact]
        public void SetValue_RecordsChange()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return; // skip on non-Windows

            var svc = new RegistryService();
            svc.SetValue(RegistryHive.CurrentUser, "Software\\MatrixTweakProTest", "TestValue", 1);
            Assert.Single(svc.Changes);
        }
    }
}
