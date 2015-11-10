using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Screen.Alive
{
    public class NativeMethodApproach : IApproach
    {
        public void KeepScreenAlive()
        {
            uint fPreviousExecutionState;

            // Set new state to prevent system sleep
            fPreviousExecutionState = NativeMethods.SetThreadExecutionState(
                NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            if (fPreviousExecutionState == 0)
            {
                throw new Exception("SetThreadExecutionState failed. Do something here...");
            }
        }

        internal static class NativeMethods
        {
            // Import SetThreadExecutionState Win32 API and necessary flags
            [DllImport("kernel32.dll")]
            public static extern uint SetThreadExecutionState(uint esFlags);

            public const uint ES_CONTINUOUS = 0x80000000;
            public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        }
    }
}