using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class chart_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindData();
        }

    }
    private void bindData() {
        DictSpecs ds = new DictSpecs();
        Orion.Common.ISQLService sql = ds.Persistence.sql;
        DataView dv1 = new DataView(sql.ExecuteDataTable("select description,no1 from vw_area"));
        Chart1.Series[0].Points.DataBindXY(dv1, "description", dv1, "no1");

        DataView dv2 = new DataView(sql.ExecuteDataTable("select description,no1 from vw_factory"));
        Chart2.Series[0].Points.DataBindXY(dv2, "description", dv2, "no1");
        DataView dv3 = new DataView(sql.ExecuteDataTable("select description,no1 from vw_section"));
        Chart3.Series[0].Points.DataBindXY(dv3, "description", dv3, "no1");


    }
}
