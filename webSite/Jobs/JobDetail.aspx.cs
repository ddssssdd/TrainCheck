using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jobs_JobDetail : System.Web.UI.Page
{
    private String EntityTypeName
    {
        get
        {
            return "JobSearch";
        }
    }

    private JobMain _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_" + EntityTypeName];

            if (o == null)
            {
                o = new JobMain();

                ViewState["Current_Entity_" + EntityTypeName] = o;
            }
            return o as JobMain;

        }
        set
        {
            ViewState["Current_Entity_" + EntityTypeName] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }
    private void BindData()
    {
        if (!String.IsNullOrEmpty(Request["id"]))
        {
            if (_Entity.Find(Int32.Parse(Request["id"])))
            {
                /*
                string sqlstring = @"SELECT  dbo.jobdetail.id,dbo.JobDetail.JobID, dbo.JobDetail.SpecsID, dbo.JobDetail.CheckTime, dbo.JobDetail.CheckDetailList, dbo.JobDetail.BarCode, dbo.DictSpecs.Section, 
                      dbo.DictSpecs.Sequence, dbo.DictSpecs.CheckPosition, dbo.DictSpecs.CheckMethod, dbo.DictSpecs.IsFull
                        FROM         dbo.JobDetail INNER JOIN
                      dbo.DictSpecs ON dbo.JobDetail.SpecsID = dbo.DictSpecs.ID where jobid=" + Request["id"];
                */
                string sqlstring = string.Format(@"select * from VW_JobDetail2 where jobid={0} and charindex('=0$',checkDetailList)>0", Request["id"]);
                grdDetails.DataSource = _Entity.Persistence.sql.ExecuteDataTable(sqlstring);
                grdDetails.DataBind();
            }
        }
    }
    protected void grdDetails_Sorting(object sender, GridViewSortEventArgs e)
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

    protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Control control = e.Row.FindControl("lblCheckDetailList");
        if (control != null)
        {
            string checkstatus = (control as Label).Text;
            if (!String.IsNullOrEmpty(checkstatus))
            {
                control = e.Row.FindControl("rptDetail");
                if (control != null)
                {
                    (control as Repeater).DataSource = SpecFactory.GetJobDetails(checkstatus);
                    (control as Repeater).DataBind();
                }
            }
        }

    }
}
