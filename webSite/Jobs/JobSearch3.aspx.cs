using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orion.Entity2;

public partial class Jobs_JobSearch3 : System.Web.UI.Page
{
    #region Variable declare
    private String EntityTypeName
    {
        get
        {
            return "JobSearch";
        }
    }

    private VW_JobMain3 _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_" + EntityTypeName];

            if (o == null)
            {
                o = new VW_JobMain3();

                ViewState["Current_Entity_" + EntityTypeName] = o;
            }
            return o as VW_JobMain3;

        }
        set
        {
            ViewState["Current_Entity_" + EntityTypeName] = value;
        }
    }
    private String Filter
    {
        get
        {
            object o = ViewState["Current_Filter"];
            if (o == null)
            {
                return "";
            }
            else
                return o.ToString();
        }
        set
        {
            ViewState["Current_Filter"] = value;
        }
    }
    private String OrderBy
    {
        get
        {
            object o = ViewState["Current_OrderBy"];
            if (o == null)
            {
                return "";
            }
            else
                return o.ToString();
        }
        set
        {
            ViewState["Current_OrderBy"] = value;
        }
    }
    private String OrderByDirection
    {
        get
        {
            object o = ViewState["Current_SortDirection"];
            if (o == null)
            {
                return " ASC ";
            }
            else
                return o.ToString();
        }
        set
        {
            ViewState["Current_SortDirection"] = value;
        }
    }
    private Int32 pageIndex
    {
        get
        {
            //object o = ViewState["Current_PageIndex"];
            //if (o == null)
            //{
            //    return 1;
            //}
            //else
            //    return Int32.Parse(o.ToString());
            return pagerMain.CurrentPageIndex;
        }
        set
        {
            //ViewState["Current_PageIndex"] = value;
            pagerMain.CurrentPageIndex = value;
        }
    }
    private Int32 pageSize
    {
        get
        {
            //object o = ViewState["Current_PageSize"];
            //if (o == null)
            //{
            //    return 10;
            //}
            //else
            //    return Int32.Parse(o.ToString());
            return pagerMain.PageSize;
        }
        set
        {
            //ViewState["Current_PageSize"] = value;
            pagerMain.PageSize = value;
        }
    }
    private Int32 pageCount
    {
        get
        {
            object o = ViewState["Current_PageCount"];
            if (o == null)
            {
                return 1;
            }
            else
                return Int32.Parse(o.ToString());
        }
        set
        {
            ViewState["Current_PageCount"] = value;
        }
    }

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    #region GridView actions
    private void BindData()
    {
        int t = 0;
        grdResult.DataKeyNames = new String[] { "VW_JobMainID" };
        grdResult.DataSource = Orion.Entity2.EntityControl.Select(_Entity, pageIndex, pageSize, out t, Filter, String.IsNullOrEmpty(OrderBy) ? "VW_JobMainID" : OrderBy + OrderByDirection);
        grdResult.DataBind();

        pagerMain.RecordCount = t;
        ddlArea_Search.DataSource = _Entity.Persistence.sql.ExecuteDataTable("select code,description from dictArea where len(code)=2");
        ddlArea_Search.DataValueField = "code";
        ddlArea_Search.DataTextField = "description";
        ddlArea_Search.DataBind();
        ddlArea_Search.Items.Insert(0, new ListItem(""));



    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        EntitySearch es = new EntitySearch(_Entity);


        if (!String.IsNullOrEmpty(txtName_Search.Text))
        {
            es.AddSearchCodition("Name", txtName_Search.Text, "like");
        }

        if (ddlArea_Search.SelectedIndex > 0)
        {
            es.AddSearchCodition("Area", ddlArea_Search.SelectedItem.Text, "like");
        }

        if (ddlFactory_Search.SelectedIndex > 0)
        {
            es.AddSearchCodition("Factory", ddlFactory_Search.SelectedItem.Text, "like");
        }

        if (ddlSection_Search.SelectedIndex > 0)
        {
            es.AddSearchCodition("Section", ddlSection_Search.SelectedItem.Text, "like");
        }

        if (!String.IsNullOrEmpty(txtJobDate_begin.Text))
        {
            String endDate = DateTime.Today.ToString();
            if (!String.IsNullOrEmpty(txtJobDate_end.Text))
            {
                endDate = txtJobDate_end.Text;
            }
            String dateFilter = String.Format(@"jobDate between '{0}' and '{1}'", txtJobDate_begin.Text, endDate);
            String filter = es.Where;
            if (filter != "")
            {
                filter = filter + " and " + dateFilter;
            }
            else
            {
                filter = dateFilter;
            }
            Filter = filter;

        }
        else
        {
            Filter = es.Where;
        }

        BindData();

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtJobDate_begin.Text = "";

        txtName_Search.Text = "";
        txtJobDate_end.Text = "";
        ddlArea_Search.SelectedIndex = -1;
        ddlFactory_Search.SelectedIndex = -1;
        ddlSection_Search.SelectedIndex = -1;




    }
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPageSize.SelectedIndex > -1)
        {
            pageIndex = 1;
            pageSize = Int32.Parse(ddlPageSize.SelectedValue);
            BindData();
        }

    }
    protected void grdResult_Sorting(object sender, GridViewSortEventArgs e)
    {

        if (OrderBy == e.SortExpression)
            if (OrderByDirection == " ASC ")
                OrderByDirection = " DESC ";
            else
                OrderByDirection = " ASC ";
        else
        {
            OrderByDirection = " ASC ";
            OrderBy = e.SortExpression;
        }
        BindData();
    }

    #endregion
    #region Detail actions
    protected void grdResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Int32.Parse(grdResult.SelectedDataKey.Value.ToString());
        Response.Redirect("JobDetail.aspx?id=" + id.ToString());
    }
    #endregion

    protected void pagerMain_PageChanged(object sender, EventArgs e)
    {
        BindData();
    }
    protected void ddlArea_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlFactory_Search.DataSource = _Entity.Persistence.sql.ExecuteDataTable(String.Format("select code,description from dictArea where parentCode='{0}'", ddlArea_Search.SelectedValue));
        ddlFactory_Search.DataValueField = "code";
        ddlFactory_Search.DataTextField = "description";
        ddlFactory_Search.DataBind();
        ddlFactory_Search.Items.Insert(0, new ListItem(""));

    }
    protected void ddlFactory_Search_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSection_Search.DataSource = _Entity.Persistence.sql.ExecuteDataTable(
            String.Format("select code,description from dictArea where parentCode='{0}'", ddlFactory_Search.SelectedValue));
        ddlSection_Search.DataValueField = "code";
        ddlSection_Search.DataTextField = "description";
        ddlSection_Search.DataBind();
        ddlSection_Search.Items.Insert(0, new ListItem(""));
    }
}
