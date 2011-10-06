using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace TrainCheck
{
    public class AppHelper
    {
        private static string _ServiceUrl ;
        private static int _UserNoDim = 0;
        private static int _BarCodeDim = 0;
        private static string _IsLockOnCheck;
        private static String _LocalUserNo;
        private static String _LocalTrainNo;
        public static bool IsLockOnCheck
        {
            get
            {
                if (String.IsNullOrEmpty(_IsLockOnCheck))
                    _IsLockOnCheck = Settings.GetSettings("IsLockOnCheck");
                if (String.IsNullOrEmpty(_IsLockOnCheck))
                    return false;
                return _IsLockOnCheck.ToLower().Equals("true");
            }           
        }
        public static String ServiceUrl
        {
            get
            {
                if (String.IsNullOrEmpty(_ServiceUrl))
                {
                    _ServiceUrl = Settings.GetSettings("WebServiceUrl");
                    if (String.IsNullOrEmpty(_ServiceUrl))
                        _ServiceUrl = "http://192.168.0.101/TrainCheck/DataServices.asmx";
                }
                return _ServiceUrl;
            }
            set
            {
                _ServiceUrl = value;
            }
        }
        public static Int32 BarCodeDim
        {
            get
            {
                if (_BarCodeDim == 0)
                {
                    string value = Settings.GetSettings("BarCodeDim");
                    if (!String.IsNullOrEmpty(value))
                        _BarCodeDim = Int32.Parse(value);
                    else
                        _BarCodeDim = 10;
                }
                return _BarCodeDim;
            }
            set
            {
                _BarCodeDim = value;
            }
        }
        public static Int32 UserNoDim
        {
            get
            {
                if (_UserNoDim == 0)
                {
                    string value = Settings.GetSettings("UserNoDim");
                    if (!String.IsNullOrEmpty(value))
                        _UserNoDim = Int32.Parse(value);
                    else
                        _UserNoDim = 10;
                }
                return _UserNoDim;
            }
            set
            {
                _UserNoDim = value;

            }
        }
        public static String LocalUserNo
        {
            get
            {
                if (String.IsNullOrEmpty(_LocalUserNo))
                {
                    _LocalUserNo = Settings.GetSettings("LocalUserNo");
                    if (String.IsNullOrEmpty(_LocalUserNo))
                        _LocalUserNo = "";
                }
                return _LocalUserNo;
            }
            set
            {
                _LocalUserNo = value;
            }
        }
        public static String LocalTrainNo
        {
            get
            {
                if (String.IsNullOrEmpty(_LocalTrainNo))
                {
                    _LocalTrainNo = Settings.GetSettings("LocalTrainNo");
                    if (String.IsNullOrEmpty(_LocalTrainNo))
                        _LocalTrainNo = "";
                }
                return _LocalTrainNo;
            }
            set
            {
                _LocalTrainNo = value;
            }
        }
        public static int UserID { get; set; }
        public static String UserName { get; set; }
        public static void FillCombobox(ComboBox cbo,String sqlString)
        {
            cbo.Items.Clear();
            using (IDataReader dr = DataAccess.ExecuteReader(sqlString))
            {
                while (dr.Read())
                {
                    if (dr[0] != DBNull.Value)
                    {
                        if (cbo.Items.IndexOf(dr[0].ToString()) < 0)
                        {
                            cbo.Items.Add(dr[0].ToString());
                        }
                    }
                }
                dr.Close();
            }
        }
        public static TrainService.DataServices Service
        {
            get
            {
                return new DynamicService(ServiceUrl);
            }
        }
        public static void StartWlan()
        {
            bool ret;
            if (!Device.GetWlanPowerStatus())
            {
                ret = Device.EnableWlanModule();
            }
            else
            {
                ret = Device.RebindWlanAdapter();
            }
        }
        public static void StopWlan()
        {
            Device.DisableWlanModule();
        }
        public static bool IsConnected()
        {
            return Device.CheckNetworkStat();
        }
    }
    public class DynamicService : TrainService.DataServices
    {
        public DynamicService():base()
        {
            this.Url = "http://192.168.1.99/TrainCheckWeb/DataServices.asmx";
        }
        public DynamicService(String sUrl)
            : base()
        {
            this.Url = sUrl;
        }
    }
    public class Settings
    {
        private static DataTable _dt;
        public static DataTable Data
        {
            get
            {
                if (_dt == null)
                    _dt = DataAccess.ExecuteDataTable("select * from Settings");
                return _dt;
            }
        }
        public static String GetSettings(String Key)
        {
            string Result = "";
            DataRow[] drs = Data.Select(String.Format("key='{0}'", Key));
            if (drs.Length > 0)
            {
                if (drs[0]["Value"] != DBNull.Value)
                    Result = drs[0]["Value"].ToString();
            }
            return Result;
        }
        public static bool SetSettings(String key, String value)
        {
            string sqlstring = String.Format("Update Settings set [value]='{1}' where [key]='{0}'", key, value);
            return DataAccess.ExecuteNonQuery(sqlstring) > 0;
        }
    }
    
}
