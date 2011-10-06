using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI.WebControls;
/// <summary>
/// Summary description for PageHelper
/// </summary>
public class PageHelper
{
	public static void FillDropDownList(DropDownList ddl,List<string> list)
    {
        ddl.DataSource = list;
        ddl.DataBind();
    }
    public static void DropDownListSetValue(DropDownList ddl, object value)
    {
        if (value == DBNull.Value)
            return;
        ListItem item = ddl.Items.FindByText(value.ToString());
        if (item != null)
            ddl.SelectedIndex = ddl.Items.IndexOf(item);
    }
}
