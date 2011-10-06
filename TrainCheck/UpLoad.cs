using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace TrainCheck
{
    public class UpLoad
    {
        public UpLoad()
        {
            //_Service = new TrainCheck.TrainService.DataServices();
            _Service = AppHelper.Service;
        }
        private TrainService.DataServices _Service;
        public void UpLoadJob()
        {
            List<int> successList = new List<int>();
            try
            {
                using (IDataReader dr = DataAccess.ExecuteReader("select * from jobMain where isUploaded=0"))
                {
                    int id = 0;
                    while (dr.Read())
                    {
                        String jobdate = dr["jobDate"].ToString();
                        Int32 userid = Int32.Parse(dr["UserID"].ToString());
                        string begintime = dr["BeginTime"] == DBNull.Value ? "" : dr["BeginTime"].ToString();
                        string endtime = dr["EndTime"] == DBNull.Value ? "" : dr["EndTime"].ToString();
                        string ipAddress = dr["ipAddress"] == DBNull.Value ? "" : dr["ipAddress"].ToString();
                        Int32 needcheckposition = dr["NeedCheckPosition"] == DBNull.Value ? 0 : Int32.Parse(dr["NeedCheckPosition"].ToString());
                        Int32 CheckPosition = dr["CheckPosition"] == DBNull.Value ? 0 : Int32.Parse(dr["CheckPosition"].ToString());
                        Int32 PassPosition = dr["PassPosition"] == DBNull.Value ? 0 : Int32.Parse(dr["PassPosition"].ToString());
                        id = Int32.Parse(dr["ID"].ToString());
                        String isfull = (dr["IsFull"] != DBNull.Value) ? dr["IsFull"].ToString() : "0";
                        string TrainCode = (dr["TrainCode"] == DBNull.Value) ? "" : dr["TrainCode"].ToString();
                        List<String> list = new List<string>();
                        using (IDataReader detaildr = DataAccess.ExecuteReader("select * from JobDetail where jobid=" + id.ToString()))
                        {

                            while (detaildr.Read())
                            {
                                list.Add(string.Format("{0}|{1}|{2}|{3}",
                                    detaildr["SpecsID"].ToString(),
                                    detaildr["CheckTime"].ToString(),
                                    detaildr["CheckDetailList"].ToString(),
                                    detaildr["BarCode"].ToString()));
                                if (detaildr["BarCode"] != DBNull.Value)
                                    TrainCode = detaildr["BarCode"].ToString().Trim();
                            }
                            detaildr.Close();
                        }
                        string childlist = string.Join("@", list.ToArray());
                        if (TrainCode.Length == AppHelper.BarCodeDim)
                            TrainCode = TrainCode.Substring(4, 3);
                        _Service.UploadJob(jobdate, userid, begintime, endtime, ipAddress, needcheckposition, CheckPosition, PassPosition, childlist, isfull == "1" ? true : false, TrainCode);
                        successList.Add(id);
                    }
                    dr.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (successList.Count > 0)
                {
                    DataAccess.ExecuteNonQuery(String.Format("Delete from jobmain where id in ({0})", String.Join(",", successList.Select(jid => jid.ToString()).ToArray())));
                    DataAccess.ExecuteNonQuery(String.Format("Delete from jobDetail where jobid in ({0})", String.Join(",", successList.Select(jid => jid.ToString()).ToArray())));
                }
            }
        }
        public void UpLoadSpecsBarCode()
        {
            using (IDataReader dr = DataAccess.ExecuteReader("select * from dictspecs"))
            {
                while (dr.Read())
                {
                    if (dr["barCode"] != DBNull.Value)
                    {
                        string barcode = dr["barcode"].ToString();
                        if (barcode.Length==AppHelper.BarCodeDim)
                            _Service.UploadSpecsBarCode(Int32.Parse(dr["id"].ToString()), barcode);
                    }
                }
                dr.Close();
            }

        }
    }
}
