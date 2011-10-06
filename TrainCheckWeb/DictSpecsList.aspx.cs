using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DictSpecsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }
    }
    private void BindList()
    {
        grdSpecs.DataSource = DataAccess.ExecuteDataTable("select * from dictSpecs");
        grdSpecs.DataBind();
    }
    protected void grdSpecs_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Response.Redirect("DictSpecsEdit.aspx?ID=" + e.CommandArgument);
        }
    }
}
