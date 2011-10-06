using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace TrainCheck
{
    /// <summary>
    /// 
    /// </summary>
    public class I60X0
    {
        /// <summary>
        /// 
        /// </summary>
        public enum AuthMode
        {
            /// <summary>
            /// 
            /// </summary>
            Open,

            /// <summary>
            /// 
            /// </summary>
            Shared,

            /// <summary>
            /// 
            /// </summary>
            WPA,

            /// <summary>
            /// 
            /// </summary>
            WPAPSK,

            /// <summary>
            /// 
            /// </summary>
            WPANone,

            /// <summary>
            /// 
            /// </summary>
            WPA2,

            /// <summary>
            /// 
            /// </summary>
            WPA2PSK
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EncryptMode
        {
            /// <summary>
            /// 
            /// </summary>
            Disabled,

            /// <summary>
            /// 
            /// </summary>
            WEP,

            /// <summary>
            /// 
            /// </summary>
            TKIP,

            /// <summary>
            /// 
            /// </summary>
            AES
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EapType
        {
            /// <summary>
            /// 
            /// </summary>
            TLS,

            /// <summary>
            /// 
            /// </summary>
            PEAP,

            /// <summary>
            /// 
            /// </summary>
            MD5
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class WlanInfo
        {
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] MacAddress;

            /// <summary>
            /// 
            /// </summary>
            public uint SsidLength;

            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] Ssid;

            /// <summary>
            /// 
            /// </summary>
            public int Rssi;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public class WlanInfoList
        {
            /// <summary>
            /// 
            /// </summary>
            public uint count;

            /// <summary>
            /// 
            /// </summary>
            public IntPtr pWlanInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum DeviceInfoType : uint
        {
            /// <summary>
            /// 
            /// </summary>
            BootType = 1,

            /// <summary>
            /// 
            /// </summary>
            KeyBDState = 2
        }

        /// <summary>
        /// 
        /// </summary>
        public enum TriggerMode
        {
            /// <summary>
            /// 
            /// </summary>
            Normal = 0,

            /// <summary>
            /// 
            /// </summary>
            Continuous
        }

        /// <summary>
        /// 
        /// </summary>
        public enum SmsNotifyType : byte
        {
            /// <summary>
            /// 
            /// </summary>
            Sms = 0x10,

            /// <summary>
            /// 
            /// </summary>
            Signal = 0x11,

            /// <summary>
            /// 
            /// </summary>
            NetState = 0x12
        }

        /// <summary>
        /// This function is used to power on the gsm module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableGsmModule();


        /// <summary>
        /// This function is used to power off the gsm module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableGsmModule();


        /// <summary>
        /// This function is used to get the power status of the gsm mudule
        /// </summary>
        /// <returns>true when gsm module is power on, false when power off</returns>
        [DllImport("Device.dll")]
        public static extern int GetGsmPowerStatus();


        /// <summary>
        /// This function is used to request that the gsm module return the received signal strength indication (rssi)
        /// </summary>
        /// <returns>the rssi value<br/>
        /// 0 -113 dBm or less<br/>
        /// 1 -111 dBm<br/>
        /// 2..30 -109... -53 dBm<br/>
        /// 31 -51 dBm or greater<br/>
        /// 99 not known or not detectable</returns>
        [DllImport("Device.dll")]
        public static extern int GetGsmSignalStrength();


        /// <summary>
        /// This function is used to power on the wlan module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWlanModule();


        /// <summary>
        /// This function is used to power off the wlan module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableWlanModule();


        /// <summary>
        /// This function is used to get the power status of the wlan module
        /// </summary>
        /// <returns>true when wlan module is power on, false when power off</returns>
        [DllImport("Device.dll")]
        public static extern int GetWlanPowerStatus();


        /// <summary>
        /// This function is used to request that the wlan driver return the received signal strength indication (RSSI).
        /// </summary>
        /// <returns>the RSSI value. the normal values for the RSSI value are between -10 and -200</returns>
        [DllImport("Device.dll")]
        public static extern int GetWlanSignalStrength();


        /// <summary>
        /// This function is used to  Power On the bluetooth module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableBthModule();


        /// <summary>
        /// This function is used to Power off the bluetooth module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableBthModule();

        /// <summary>
        /// get the power status of the Bluetooth module
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern int GetBthPowerStatus();

        /// <summary>
        /// This function is used to  Power On the GPS module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableGpsModule();


        /// <summary>
        /// This function is used to Power off the GPS module
        /// </summary>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableGpsModule();


        /// <summary>
        /// get the power status of the GPS module
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern int GetGpsPowerStatus();

   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableVibrateModule();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableVibrateModule();


        /// <summary>
        /// This function is used to set the backlight value
        /// </summary>
        /// <param name="level">the backlight value ,range is 1~20</param>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetBackLightLevel(int level);


        /// <summary>
        /// GetBackLightLevel
        /// </summary>
        /// <returns>Returns the backlight value. between 1-20.-1 is failed.</returns>
        [DllImport("Device.dll")]
        public static extern int GetBackLightLevel();


        /// <summary>
        /// This function is used to Check that the device is connected to the gateway
        /// </summary>
        /// <returns>true when the device has connected to the gateway, false when not connected</returns>
        /// <remarks>this function does not distinguish between network type(such as gprs, wireless lan, usb)</remarks>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CheckNetworkStat();


        /// <summary>
        /// This function is used to establishes a gprs connection
        /// </summary>
        /// <param name="connName">a ras phone book entry name</param>
        /// <param name="errorCode">the Zero indicates success. A nonzero error value, either from the set listed in the RAS header file or ERROR_NOT_ENOUGH_MEMORY, indicates failure.</param>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ConnectGprs([MarshalAs(UnmanagedType.LPWStr)]string connName, out uint errorCode);


        /// <summary>
        /// This function is used to check the gprs connection status
        /// </summary>
        /// <param name="connName">a ras phone book entry name</param>
        /// <returns>true when active, false when disactive</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetGprsStatus([MarshalAs(UnmanagedType.LPWStr)]string connName);


        /// <summary>
        /// This function is used to terminate the gprs connection
        /// </summary>
        /// <param name="connName">a ras phone book entry name</param>
        [DllImport("Device.dll")]
        public static extern void DisConnectGprs([MarshalAs(UnmanagedType.LPWStr)]string connName);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="connName"></param>
        /// <param name="apn"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateGprsEntry([MarshalAs(UnmanagedType.LPWStr)]string connName, [MarshalAs(UnmanagedType.LPWStr)]string apn, [MarshalAs(UnmanagedType.LPWStr)]string phoneNumber, [MarshalAs(UnmanagedType.LPWStr)]string userName, [MarshalAs(UnmanagedType.LPWStr)]string password, [MarshalAs(UnmanagedType.LPWStr)]string domain);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentMac"></param>
        /// <param name="pAvailableList"></param>
        /// <param name="pPreferredList"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryWlanInformation(byte[] currentMac, WlanInfoList pAvailableList, WlanInfoList pPreferredList);


        /// <summary>
        /// 
        /// </summary>
        [DllImport("Device.dll")]
        public static extern void FreeWlanInformation();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="szSSID"></param>
        /// <param name="authMode"></param>
        /// <param name="encryptMode"></param>
        /// <param name="szKey"></param>
        /// <param name="eapType"></param>
        /// <param name="bAdhoc"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AddToWlanPreferredList([MarshalAs(UnmanagedType.LPWStr)]string szSSID, AuthMode authMode, EncryptMode encryptMode, [MarshalAs(UnmanagedType.LPWStr)]string szKey, EapType eapType, [MarshalAs(UnmanagedType.Bool)]bool bAdhoc);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ResetWlanPreferredList();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RefreshWlanPreferredList();



        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSuspendEvent"></param>
        /// <param name="hNotifyEvent"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterPowerEvent(out IntPtr hSuspendEvent, out IntPtr hNotifyEvent);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSuspendEvent"></param>
        /// <param name="hNotifyEvent"></param>
        [DllImport("Device.dll")]
        public static extern void UnRegisterPowerEvent(IntPtr hSuspendEvent,IntPtr hNotifyEvent);


        /// <summary>
        /// This function is used to get the id of the device
        /// </summary>
        /// <param name="deviceId">the buffer to store the device id</param>
        /// <param name="length">the buffer length</param>
        /// <returns>true indicates success, false indicates failure</returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDeviceID(StringBuilder deviceId, uint length);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfoType"></param>
        /// <param name="pvParam"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetDeviceInfo(DeviceInfoType deviceInfoType, out int pvParam);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiMode">0,number mode 1,lowercase mode 2,capital on</param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetKeyboardMode(uint uiMode);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableCursor();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DisableCursor();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idleTime"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool StartScreenLock(uint idleTime);   //in seconds

        /// <summary>
        /// 
        /// </summary>
        [DllImport("Device.dll")]
        public static extern void ScreenLockTimerReset();


        /// <summary>
        /// 
        /// </summary>
        [DllImport("Device.dll")]
        public static extern void StopScreenLock();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsScreenLocked();


        /// <summary>
        ///  power on the Scanner module
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_EnableModule();

        /// <summary>
        ///  power off the Scanner module
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_DisableModule();

        /// <summary>
        /// get the power status of the Scanner module
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern int SCA_GetPowerStatus();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hMsgQ"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern IntPtr SCA_RegisterNotification(IntPtr hMsgQ);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="hNotify"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_UnRegisterNotification(IntPtr hNotify);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_SetTriggerState([MarshalAs(UnmanagedType.Bool)]bool state);


        /// <summary>
        /// Set the scanner's TriggerMode
        /// </summary>
        /// <param name="mode">Normal or Continuous</param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_SetTriggerMode(TriggerMode mode);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParam"></param>
        /// <param name="dwSize"></param>
        /// <param name="bPermanent"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_SendParam(byte[] pParam, uint dwSize, [MarshalAs(UnmanagedType.Bool)]bool bPermanent);



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParam"></param>
        /// <param name="dwSize"></param>
        /// <param name="pParamVal"></param>
        /// <param name="dwValSize"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_RequestParam(byte[] pParam, uint dwSize, byte[] pParamVal, ref uint dwValSize);


        /// <summary>
        /// Set the scanner's params to default
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SCA_ResetScannerParams();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_Open();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern void SMS_Close();


        /// <summary>
        /// 指示短信模块是否已开启
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_IsOpened();


        /// <summary>
        /// 启动短信模块，并注册新短信通知
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        public static extern IntPtr SMS_RegisterNotification(IntPtr hMsgQ);


        /// <summary>
        /// 停止短信模块，不再接受新短信通知
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_UnRegisterNotification(IntPtr hNotify);


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="szRecipient">收信人号码</param>
        /// <param name="szSmcc">短消息中心号码，必须以86开头。可以为空</param>
        /// <param name="szMsg">短信内容，不能超过70个字符</param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_SendSMS([MarshalAs(UnmanagedType.LPWStr)]string szRecipient, [MarshalAs(UnmanagedType.LPWStr)]string szSmcc, [MarshalAs(UnmanagedType.LPWStr)]string szMsg);


        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="szRecipient">收信人号码</param>
        /// <param name="szSmcc">短消息中心号码，必须以86开头。可以为空</param>
        /// <param name="szMsg">短信内容，不能超过70个字符</param>
        /// <param name="wID"></param>
        /// <param name="byTotalNum"></param>
        /// <param name="byCurrentNum"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_SendSMSEx([MarshalAs(UnmanagedType.LPWStr)]string szRecipient, [MarshalAs(UnmanagedType.LPWStr)]string szSmcc, [MarshalAs(UnmanagedType.LPWStr)]string szMsg, ushort wID, byte byTotalNum, byte byCurrentNum);


        /// <summary>
        /// 当收到WM_RECVSMS时可以通过此函数读取短信
        /// </summary>
        /// <param name="iIndex">新短信索引</param>
        /// <param name="szRecipient">发信人号码</param>
        /// <param name="dwRecpLen">发信人号码缓冲区长度</param>
        /// <param name="szMsg">短信内容</param>
        /// <param name="dwMsgLen">短信内容缓冲区长度</param>
        /// <param name="szTime">短信时间</param>
        /// <param name="dwTimeLen">短信时间缓冲区长度</param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_ReadSMS(int iIndex, StringBuilder szRecipient, uint dwRecpLen, StringBuilder szMsg, uint dwMsgLen, StringBuilder szTime, uint dwTimeLen);


        /// <summary>
        /// 当收到WM_RECVSMS时可以通过此函数读取短信
        /// </summary>
        /// <param name="iIndex">新短信索引</param>
        /// <param name="szRecipient">发信人号码</param>
        /// <param name="dwRecpLen">发信人号码缓冲区长度</param>
        /// <param name="szMsg">短信内容</param>
        /// <param name="dwMsgLen">短信内容缓冲区长度</param>
        /// <param name="szTime">短信时间</param>
        /// <param name="dwTimeLen">短信时间缓冲区长度</param>
        /// <param name="pwID"></param>
        /// <param name="pbyTotalNum"></param>
        /// <param name="pbyCurrentNum"></param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_ReadSMSEx(int iIndex, StringBuilder szRecipient, uint dwRecpLen, StringBuilder szMsg, uint dwMsgLen, StringBuilder szTime, uint dwTimeLen, ref ushort pwID, ref byte pbyTotalNum, ref byte pbyCurrentNum);


  

        /// <summary>
        /// 删除短信
        /// </summary>
        /// <param name="iIndex">新短信索引</param>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_DeleteSMS(int iIndex);



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_ListSMS();



        /// <summary>
        /// 获取信号强度
        /// </summary>
        /// <returns></returns>
        [DllImport("Device.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SMS_GetSignalStrength();
        

        /// <summary>
        /// 获取网络注册状态
        /// </summary>
        /// <returns>1为已注册本地网络，5为已注册漫游网络</returns>
        [DllImport("Device.dll")]
        public static extern int SMS_GetRegistrationState();

    }
}