using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            InitDate();
            bindData();
        }

    }
    private void InitDate()
    {
        DateTime d1 = DateTime.Today;

        if (Session["SelectDateBegin"] != null)
        {

            txtBegin.Text = Session["SelectDateBegin"].ToString();
        }
        else
        {
            txtBegin.Text = d1.AddMonths(-1).ToString("yyyy-MM-dd");

        }

        if (Session["SelectDateEnd"] != null)
        {
            txtEnd.Text = Session["SelectDateEnd"].ToString();
        }
        else
        {
            txtEnd.Text = d1.ToString("yyyy-MM-dd");

        }
    }
    private void bindData()
    {
        if (String.IsNullOrEmpty(txtEnd.Text))
            return;
        if (String.IsNullOrEmpty(txtBegin.Text))
            return;
        DateTime d1;
        DateTime d2;
        try
        {
            d1 = Convert.ToDateTime(txtBegin.Text);
            d2 = Convert.ToDateTime(txtEnd.Text);
        }
        catch (Exception e)
        {
            txtBegin.Text = "";
            txtEnd.Text = "";
            return;
        }

        Session["SelectDateBegin"] = txtBegin.Text;
        Session["SelectDateEnd"] = txtEnd.Text;
        string f = "%";
        if (Request["factory"] != null)
        {
            f = Request["factory"];
        }
        
        DictSpecs ds = new DictSpecs();
        String sqlstring =String.Format(@"select area,factory,section,sum(checkposition) as checkposition,
sum(passPosition) as passPosition,SectionNo as AreaNo from vw_jobmain2 where factory='{2}' and jobdate between '{0}' and '{1}' 
group by area,factory,section,sectionNo",txtBegin.Text,d2.AddDays(1).ToString("yyyy-MM-dd"),f);
        DataTable dt = ds.Persistence.sql.ExecuteDataTable(sqlstring);
        grdMain.DataSource = dt;
        grdMain.DataBind();
        DataView dv = new DataView(dt);


        Chart3.Series[0].Points.DataBindXY(dv, "section", dv, "checkPosition");
        Chart3.Series[1].Points.DataBindXY(dv, "section", dv, "passPosition");
        Chart3.Series[2].Points.DataBindXY(dv, "section", dv, "AreaNo");
        Orion.Common.ISQLService sql = ds.Persistence.sql;
        //DataView dvArea = new DataView(sql.ExecuteDataTable(""));
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        bindData();
    }
   
}
