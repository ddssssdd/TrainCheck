using System;

using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Urovo
{

    /// <summary>
    /// Scanner control interfaces
    /// </summary>
    public class Scanner
    {
        /// <summary>
        /// Scanner trigger mode
        /// </summary>
        public enum TriggerMode {
            /// <summary>
            /// Normal Mode
            /// </summary>
            Normal,
            /// <summary>
            /// Continuous mode
            /// </summary>
            Continuous
        }	//trigger mode

        /// <summary>
        /// This function is used to get the power status of the scanner module
        /// </summary>
        /// <returns>true when scanner module is power on, false when power off</returns>
        [DllImport("Scanner.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsScannerEnabled();

        /// <summary>
        /// This function is used to Register the barcode notifycation message,
        /// </summary>
        /// <param name="hWnd">a handle to a window to receive the notification messages</param>
        /// <param name="uiMessage">the custome windows message. range is 0x0400~0x7FFF</param>
        [DllImport("Scanner.dll")]
        public static extern void RegisterScannerMessage(IntPtr hWnd, uint uiMessage);

        /// <summary>
        /// This function is used to Power on the scanner module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Scanner.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableScanner();

        /// <summary>
        /// This function is used to Power off the scanner module
        /// </summary>
        [DllImport("Scanner.dll")]
        public static extern void DisableScanner();

        /// <summary>
        /// This function is used to open the laser
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Scanner.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartScan();

        /// <summary>
        /// This function is used to close the laser
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Scanner.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StopScan();


        /// <summary>
        /// This function is used to set the trigger mode
        /// </summary>
        /// <param name="nTriggerMode">normal mode or continuous mode</param>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Scanner.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetTriggerMode(int nTriggerMode);
    }
}
