using System;
using System.Net.NetworkInformation;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Provides basic network metrics.
    /// </summary>
    public class NetworkService
    {
        public long GetTotalBytesSent()
        {
            long total = 0;
            foreach (var ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                var stats = ni.GetIPv4Statistics();
                total += stats.BytesSent;
            }
            return total;
        }
    }
}
