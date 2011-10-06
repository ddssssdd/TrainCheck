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
            _Service = new TrainCheck.TrainService.DataServices();
        }
        private TrainService.DataServices _Service;
        public void UpLoadJob()
        {
            using (IDataReader dr = DataAccess.ExecuteReader("select * from jobMain where isUploaded=0"))
            {
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
                    Int32 id = Int32.Parse(dr["ID"].ToString());
                    List<String> list = new List<string>();
                    using (IDataReader detaildr = DataAccess.ExecuteReader("select * from JobDetail where jobid=" + id.ToString()))
                    {
                        
                        while (detaildr.Read())
                        {
                            list.Add(string.Format("{0}|{1}|{2}",
                                detaildr["SpecsID"].ToString(),
                                detaildr["CheckTime"].ToString(),
                                detaildr["CheckDetailList"].ToString()));
                        }
                        detaildr.Close();
                    }
                    string childlist = string.Join("@", list.ToArray());
                    _Service.UploadJob(jobdate, userid, begintime, endtime, ipAddress, needcheckposition, CheckPosition, PassPosition, childlist);
                }
                dr.Close();
            }
            
        }
    }
}
