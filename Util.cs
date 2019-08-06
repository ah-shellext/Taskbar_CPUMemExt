using System;
using System.Runtime.InteropServices;
using ComTypes = System.Runtime.InteropServices.ComTypes;

namespace Util {
     public static class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            else
                return -1;
        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            else
                return -1;
        }
    }

    public static class SystemTimesInfo {
        [DllImport("Kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetSystemTimes([Out] out ComTypes.FILETIME lpIdleTime, [Out] out ComTypes.FILETIME lpKernelTime, [Out] out ComTypes.FILETIME lpUserTime);

        private static TimeSpan last_idleTime;
        private static TimeSpan last_kernelTime;
        private static TimeSpan last_userTime;

        public static double getCPURate() {
            ComTypes.FILETIME idleTime, kernelTime, userTime;
            GetSystemTimes(out idleTime, out kernelTime, out userTime);

            TimeSpan idleTimeTs = GetTimeSpanFromFileTime(idleTime);
            TimeSpan kernelTimeTs = GetTimeSpanFromFileTime(kernelTime);
            TimeSpan userTimeTs = GetTimeSpanFromFileTime(userTime);

            TimeSpan idlDiff = idleTimeTs - last_idleTime;
            TimeSpan kerDiff = kernelTimeTs - last_kernelTime;
            TimeSpan usrDiff = userTimeTs - last_userTime;

            last_idleTime = idleTimeTs;
            last_kernelTime = kernelTimeTs;
            last_userTime = userTimeTs;

            TimeSpan tot = kerDiff + usrDiff;

            double rate = (tot - idlDiff).TotalMilliseconds / tot.TotalMilliseconds * 100;

            return rate;
        }

        private static TimeSpan GetTimeSpanFromFileTime(ComTypes.FILETIME time) => 
            TimeSpan.FromMilliseconds((((ulong)time.dwHighDateTime << 32) + (uint)time.dwLowDateTime) * 0.000001);
    }
}