using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
/// <summary>
/// Summary description for Dicts
/// </summary>
public class Dicts
{
    private static DataTable _DtDicts;
    public static DataTable  DictsDataTable
    {
        get
        {
            if (_DtDicts == null)
            {
                _DtDicts = DataAccess.ExecuteDataTable("select * from dicts");
            }
            return _DtDicts;
        }
    }
   
    private static void FillList(String keyName,List<String> _list)
    {
        _list.Clear();
        foreach (DataRow dr in DictsDataTable.Select(String.Format("KeyName='{0}'", keyName)))
        {
            if (dr["value"] != DBNull.Value)
            {
                if (!_list.Contains(dr["value"].ToString()))
                    _list.Add(dr["value"].ToString());
            }
        }
    }
    private static List<String> _ListSection;
    private static List<String> _ListCheckPosition;
    private static List<String> _ListCheckMethod;
    public static List<String> ListSection
    {
        get
        {
            if (_ListSection == null)
            {
                _ListSection = new List<string>();
                FillList("Section", _ListSection);
            }
            return _ListSection;
        }
    }
    public static List<String> ListCheckPosition
    {
        get
        {
            if (_ListCheckPosition == null)
            {
                _ListCheckPosition = new List<string>();
                FillList("CheckPosition", _ListCheckPosition);
            }
            return _ListCheckPosition;
        }
    }
    public static List<string> ListCheckMethod
    { 
        get
        {
            if (_ListCheckMethod == null)
            {
                _ListCheckMethod = new List<string>();
                FillList("CheckMethod", _ListCheckMethod);
            }
            return _ListCheckMethod;
        }
    }
}
