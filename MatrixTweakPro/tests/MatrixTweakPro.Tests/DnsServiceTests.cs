using MatrixTweakPro.Services;
using System;
using System.Runtime.InteropServices;
using Xunit;

namespace MatrixTweakPro.Tests
{
    public class DnsServiceTests
    {
        [Fact]
        public void SetDns_ThrowsOnNonWindows()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return; // skip when on Windows
            var svc = new DnsService();
            Assert.Throws<PlatformNotSupportedException>(() => svc.SetDns(new[] { "1.1.1.1" }));
        }
    }
}
