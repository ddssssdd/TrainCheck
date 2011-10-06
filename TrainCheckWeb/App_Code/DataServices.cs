using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Services;
using System.Data;

/// <summary>
/// Summary description for Users
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DataServices : System.Web.Services.WebService {

   
    [WebMethod]
    public DataTable UserList()
    {
        return DataAccess.ExecuteDataTable("select * from users where isActive=1");

    }
    [WebMethod]
    public DataTable SpecsList()
    {
        return DataAccess.ExecuteDataTable("select * from dictSpecs");
    }
    [WebMethod]
    public DataTable SpecsItemsList()
    {
        return DataAccess.ExecuteDataTable("select * from dictSpecsItems");
    }
    [WebMethod]
    public DataTable Settings()
    {
        return DataAccess.ExecuteDataTable("select * from Settings");
    }
    [WebMethod]
    public int UploadJob(String jobdate, 
        Int32 userid, 
        string begintime, 
        string endtime, 
        string ipaddress, 
        int needcheckposition, 
        int checkposition, 
        int passposition,
        string childList,
        bool isFull,
        string trainCode)
    {
        int result=0;
        try
        {
            string insertString = String.Format(@"Insert into JobMain(JobDate,UserID,BeginTime,EndTime,IpAddress,
                        IsUploaded,NeedCheckPosition,CheckPosition,PassPosition,IsFull,TrainCode)
                        Values('{0}',{1},'{2}','{3}','{4}',1,{5},{6},{7},{8},'{9}') select @@identity",
                             jobdate,
                             userid,
                             begintime,
                             endtime,
                             ipaddress,
                             needcheckposition,
                             checkposition,
                             passposition,
                             isFull?1:0,
                             trainCode);
            result = Int32.Parse(DataAccess.ExecuteScalar(insertString).ToString());

            foreach (string detail in childList.Split('@'))
            {
                String[] items = detail.Split('|');
                if (items.Length == 4)
                {
                    String specsid = items[0];
                    string checktime = items[1];
                    string checkdetaillist = items[2];
                    string barcode = items[3];
                    string sqlstring = String.Format(@"Insert into JobDetail(jobid,SpecsID,checktime,CheckDetailList,barCode)
                                                  Values({0},{1},'{2}','{3}','{4}')",
                                                      result,
                                                      specsid,
                                                      checktime,
                                                      checkdetaillist,
                                                      barcode);
                    DataAccess.ExecuteNonQuery(sqlstring);
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }
    [WebMethod]
    public int UploadJob2(String jobdate,
        Int32 userid,
        string begintime,
        string endtime,
        string ipaddress,        
        string childList,
        bool isFull,
        string trainCode)
    {
        int result = 0;
        try
        {
            string insertString = String.Format(@"Insert into JobMain(JobDate,UserID,BeginTime,EndTime,IpAddress,
                        IsUploaded,IsFull,TrainCode)
                        Values('{0}',{1},'{2}','{3}','{4}',1,{5},'{6}') select @@identity",
                             jobdate,
                             userid,
                             begintime,
                             endtime,
                             ipaddress,
                             isFull ? 1 : 0,
                             trainCode);
            result = Int32.Parse(DataAccess.ExecuteScalar(insertString).ToString());
            int icount = 0;
            int passcount = 0;
            string position = "";
            string checkPointNo = "";
            foreach (string detail in childList.Split('@'))
            {
                String[] items = detail.Split('|');
                if (items.Length == 4)
                {
                    String specsid = items[0];
                    string checktime = items[1];
                    string checkdetaillist = items[2];
                    string barcode = items[3].Trim();
                    if (barcode.Length == 16)
                    {
                        position = barcode.Substring(0, 8);
                        checkPointNo = barcode.Substring(9, 4);
                    }
                    else
                    {
                        position = barcode.Substring(0, 6);
                        checkPointNo = barcode.Substring(6, 4);
                    }

                    string sqlstring = String.Format(@"Insert into JobDetail(jobid,SpecsID,checktime,CheckDetailList,barCode,position,checkPointNo)
                                                  Values({0},{1},'{2}','{3}','{4}','{5}','{6}')",
                                                      result,
                                                      specsid,
                                                      checktime,
                                                      checkdetaillist,
                                                      barcode,
                                                      position,
                                                      checkPointNo);
                    DataAccess.ExecuteNonQuery(sqlstring);
                    if (!(checkdetaillist.IndexOf("=0") > 0))
                    {
                        passcount++;
                    }
                    icount++;
                }
            }
            DataAccess.ExecuteNonQuery(String.Format(@"Update jobmain set line='{0}',area='{1}',dept='{2}',checkType='{3}',CheckPosition={4},PassPosition={6} where ID={5}",
                trainCode.Substring(0,2),
                trainCode.Substring(0,4),
                trainCode.Substring(0,6),
                trainCode.Length==16?"接触网":"牵引变",
                icount,
                result,
                passcount));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return result;
    }
    [WebMethod]
    public int UploadSpecsBarCode(Int32 id, string barcode)
    {
        return DataAccess.ExecuteNonQuery(String.Format("Update DictSpecs set barcode='{1}' where id={0}",id,barcode));
    }
    
}

