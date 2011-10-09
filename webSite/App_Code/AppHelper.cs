using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Orion.DataAccess2;
using Orion.Common;
/// <summary>
/// Summary description for AppHelper
/// </summary>
public class AppHelper
{
    private static List<String> _CheckPositionList;
    public static List<String> CheckPositionList
    {
        get
        {
            if (_CheckPositionList == null)
            {
                _CheckPositionList = new List<string>();
                FillListBySQLString(String.Format("select value from dicts where KeyName='{0}'", "CheckPosition2"), _CheckPositionList);
                
            }
            return _CheckPositionList;
        }
    }
    private static List<String> _CheckMethodList;
    public static List<String> CheckMethodList
    {
        get
        {
            if (_CheckMethodList == null)
            {
                _CheckMethodList = new List<string>();
                FillListBySQLString(String.Format("select value from dicts where KeyName='{0}'", "CheckMethod2"), _CheckMethodList);
                _CheckMethodList.Insert(0, "");
                
            }
            return _CheckMethodList;
        }
    }
    private static List<String> _SectionList;
    public static List<String> SectionList
    {
        get
        {
            if (_SectionList == null)
            {
                _SectionList = new List<string>();
                FillListBySQLString(String.Format("select value from dicts where KeyName='{0}'", "Section2"), _SectionList);
                
            }
            return _SectionList;
        }
    }
    public static void FillListBySQLString(string sqlstring, List<String> list)
    {
        using (IDataReader dr = db.ExecuteReader(sqlstring))
        {
            while (dr.Read())
            {
                list.Add(dr.GetString(0));
            }
            dr.Close();
        }
    }
    public static ISQLService db
    {
        get
        {
            return dbFactory.Create();
        }
    }
}
