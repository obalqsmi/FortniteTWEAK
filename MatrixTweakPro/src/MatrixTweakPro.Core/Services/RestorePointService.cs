using System;
using System.Runtime.InteropServices;

namespace MatrixTweakPro.Services
{
    /// <summary>
    /// Creates system restore points via SRSetRestorePointW.
    /// </summary>
    public class RestorePointService
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct RESTOREPOINTINFO
        {
            public int dwEventType;
            public int dwRestorePtType;
            public long llSequenceNumber;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDescription;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STATEMGRSTATUS
        {
            public int nStatus;
            public long llSequenceNumber;
        }

        [DllImport("srclient.dll", CharSet = CharSet.Unicode)]
        private static extern bool SRSetRestorePointW(ref RESTOREPOINTINFO pRestorePtSpec, out STATEMGRSTATUS pSMgrStatus);

        public bool CreateRestorePoint(string description)
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return false;

            var info = new RESTOREPOINTINFO
            {
                dwEventType = 100, // BEGIN_SYSTEM_CHANGE
                dwRestorePtType = 0, // APPLICATION_INSTALL
                llSequenceNumber = 0,
                szDescription = description
            };
            var status = new STATEMGRSTATUS();
            return SRSetRestorePointW(ref info, out status);
        }
    }
}
