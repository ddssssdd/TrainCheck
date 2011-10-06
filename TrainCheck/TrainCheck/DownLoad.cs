using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace TrainCheck
{
    public class DownLoad
    {
        TrainService.DataServices  service ;
        public DownLoad()
        {
            service = new TrainService.DataServices();
        }
        public void DownloadUserList()
        {
            try
            {
                DataAccess.ExecuteNonQuery("delete from users");
                DataTable dtUsers = service.UserList();
                foreach (DataRow dr in dtUsers.Rows)
                {
                    String insertString = String.Format(@"Insert into Users(username,userno,[name],password) values(
                                                      '{0}','{1}','{2}','{3}')",
                                                           dr["UserName"].ToString(),
                                                           dr["UserNo"].ToString(),
                                                           dr["Name"].ToString(),
                                                           dr["password"].ToString());
                    DataAccess.ExecuteNonQuery(insertString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DownloadSpecsList()
        {
            try
            {
                DataAccess.ExecuteNonQuery("delete from DictSpecs");
                DataTable dtSpecs = service.SpecsList();
                foreach (DataRow dr in dtSpecs.Rows)
                {
                    String insertString = String.Format(@"Insert into DictSpecs(id,section,sequence,checkposition,checkmethod,barcode) values(
                                                      {0},'{1}',{2},'{3}','{4}','{5}')",
                                                           dr["ID"].ToString(),
                                                           (dr["Section"]!=DBNull.Value)?dr["Section"].ToString():"",
                                                           (dr["Sequence"]!=DBNull.Value)?dr["Sequence"].ToString():"0",
                                                           (dr["CheckPosition"]!=DBNull.Value)?dr["CheckPosition"].ToString():"",
                                                           (dr["CheckMethod"]!=DBNull.Value)?dr["CheckMethod"].ToString():"",
                                                           (dr["BarCode"]!=DBNull.Value)?dr["BarCode"].ToString():"");
                    DataAccess.ExecuteNonQuery(insertString);
                }
                DataAccess.ExecuteNonQuery("delete from DictSpecsItems");
                DataTable dtItems = service.SpecsItemsList();
                foreach (DataRow dr in dtItems.Rows)
                {
                    String insertString = String.Format(@"Insert into DictSpecsItems(id,DictSpecsID,CheckDetail,checkmethod,SpecifiedSizeHeight,KnockPosition,barcode) values(
                                                      {0},{1},'{2}','{3}','{4}','{5}','{6}')",
                                                           dr["ID"].ToString(),
                                                           (dr["DictSpecsID"] != DBNull.Value) ? dr["DictSpecsID"].ToString() : "0",
                                                           (dr["CheckDetail"] != DBNull.Value) ? dr["CheckDetail"].ToString() : "",
                                                           (dr["CheckMethod"] != DBNull.Value) ? dr["CheckMethod"].ToString() : "",
                                                           (dr["SpecifiedSizeHeight"] != DBNull.Value) ? dr["SpecifiedSizeHeight"].ToString() : "",
                                                           (dr["KnockPosition"] != DBNull.Value) ? dr["KnockPosition"].ToString() : "",
                                                           (dr["BarCode"] != DBNull.Value) ? dr["BarCode"].ToString() : "");
                    DataAccess.ExecuteNonQuery(insertString);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
