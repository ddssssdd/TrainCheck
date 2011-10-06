using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orion.Entity2;

/// <summary>
/// Summary description for Entity
/// </summary>
[Serializable]
public class DictSpecs : Entity
{
 
    public String Section { get; set; }
    public Int32 Sequence { get; set; }
    public String CheckPosition { get; set; }
    public String CheckMethod { get; set; }
    public String BarCode { get; set; }
    public Boolean IsFull {get;set;}
}
[Serializable]
public class VW_Specs : Entity
{

    public String Section { get; set; }
    public Int32 Sequence { get; set; }
    public String CheckPosition { get; set; }
    public String CheckMethod { get; set; }
    public String BarCode { get; set; }
    public Boolean IsFull { get; set; }
}

[Serializable]
public class DictSpecsItems : Entity
{
   
    public Int32 DictSpecsID { get; set; }
    public String CheckDetail { get; set; }
    public String CheckMethod { get; set; }
    public String SpecifiedSizeHeight { get; set; }
    public String KnockPosition { get; set; }
    public String BarCode { get; set; }
    public Boolean IsFull {get;set;}
    public bool IsCheck {get;set;}
    public String ImageUrl { get; set; }
    public String Note { get; set; }
}

      
[Serializable]
public class JobMain : Entity
{

    public DateTime JobDate { get; set; }
    public Int32 UserID { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public String IpAddress { get; set; }
    public Boolean IsUploaded { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public Int32 NeedCheckPosition { get; set; }
    public Int32 CheckPosition { get; set; }
    public Int32 PassPosition { get; set; }
    public Boolean IsFull {get;set;}
    public String TrainCode  {get;set;}
}
[Serializable]
public class VW_JobMain : Entity
{
    public Int32 VW_JobMainID { get; set; }
    public DateTime JobDate { get; set; }
    public Int32 UserID { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public Int32 NeedCheckPosition { get; set; }
    public Int32 CheckPosition { get; set; }
    public Int32 PassPosition { get; set; }
    public String CheckType { get; set; }
    public String TrainCode { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public String Area { get; set; }
    public String Factory { get; set; }
    public String Section { get; set; }
}

[Serializable]
public class VW_JobMain2 : Entity
{
    public Int32 VW_JobMainID { get; set; }
    public DateTime JobDate { get; set; }
    public Int32 UserID { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public Int32 NeedCheckPosition { get; set; }
    public Int32 CheckPosition { get; set; }
    public Int32 PassPosition { get; set; }
    public Int32 FailurePosition { get; set; }
    public String CheckType { get; set; }
    public String TrainCode { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public String Area { get; set; }
    public String Factory { get; set; }
    public String Section { get; set; }
}
[Serializable]
public class VW_JobMain3 : Entity
{
    public Int32 VW_JobMainID { get; set; }
    public DateTime JobDate { get; set; }
    public Int32 UserID { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public Int32 NeedCheckPosition { get; set; }
    public Int32 CheckPosition { get; set; }
    public Int32 PassPosition { get; set; }
    public Int32 FailurePosition { get; set; }
    public String CheckType { get; set; }
    public String TrainCode { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public String Area { get; set; }
    public String Factory { get; set; }
    public String Section { get; set; }
}
[Serializable]
public class VW_JobMain4 : Entity
{
    public Int32 VW_JobMainID { get; set; }
    public DateTime JobDate { get; set; }
    public Int32 UserID { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime UpdateDateTime { get; set; }
    public Int32 NeedCheckPosition { get; set; }
    public Int32 CheckPosition { get; set; }
    public Int32 PassPosition { get; set; }
    public Int32 FailurePosition { get; set; }
    public String CheckType { get; set; }
    public String TrainCode { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public String Area { get; set; }
    public String Factory { get; set; }
    public String Section { get; set; }
}
[Serializable]
public class dictArea : Entity
{
    public Int32 id { get; set; }
    public String parentCode { get; set; }
    public String code { get; set; }
    public String description { get; set; }
    public Int32 no1 { get; set; }
    public Int32 no2 { get; set; }
}


[Serializable]
public class Users : Entity
{

    public String UserName { get; set; }
    public String UserNo { get; set; }
    public String Name { get; set; }
    public String Department { get; set; }
    public String Password { get; set; }
    public Boolean IsActive { get; set; }
    public DateTime ExpirtationDate { get; set; }
}
[Serializable]
public class Dept : Entity
{

    public String Area { get; set; }
    public String Factory { get; set; }
    public String Section { get; set; }
    public String Code { get; set; }
    public String TrainCode { get; set; }
    public String Alias { get; set; }
}

public class SpecFactory
{
    private static Dictionary<int, DictSpecsItems> _specitems;
    public static Dictionary<int, DictSpecsItems> SpecsItems
    {
        get
        {
            if (_specitems == null)
            {
                _specitems = new Dictionary<int, DictSpecsItems>();
                foreach (var item in Orion.Entity2.EntityControl.Select<DictSpecsItems>())
                {
                    _specitems.Add(item.ID, item);
                }
            }
            return _specitems;
        }
    }
    public static List<DictSpecsItems> GetJobDetails(String checkStatus)
    {
        List<DictSpecsItems> result = new List<DictSpecsItems>();
        string[] list = checkStatus.Split(',');
        if (list.Length > 0)
        {
            foreach (string kv in list)
            {
                string[] idcheck = kv.Split('=');
                if (idcheck.Length == 2)
                {
                    int id = Int32.Parse(idcheck[0]);
                    String checkResult = idcheck[1].Trim();
                    Boolean ischeck = checkResult.Substring(0,1)=="1"?true:false;
                    DictSpecsItems item = null;
                    if (SpecsItems.TryGetValue(id,out item))
                    {
                        item.IsCheck=ischeck;
                        item.Note = "";
                        if (checkResult.Length > 2)
                        {
                            item.Note = String.Format("备注:{0}",checkResult.Substring(2, checkResult.Length - 2));
                        }
                        if (ischeck)
                            item.ImageUrl = "~/images/icon-checked.gif";
                        else
                            item.ImageUrl = "~/images/icon-cancel.gif";

                                
                        result.Add(item);
                    }
                }
            }
        }
        return result;
    }
}