using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class DictSpecsEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitPage();
            if (SpecsID > 0)
            {
                BindItems();
            }
        }
    }
    public int SpecsID
    {
        get
        {
            if (!String.IsNullOrEmpty(Request["ID"]))
                return Int32.Parse(Request["ID"]);
            else
                return 0;
        }
    }
    public void InitPage()
    {
        PageHelper.FillDropDownList(ddlSection, Dicts.ListSection);
        PageHelper.FillDropDownList(ddlCheckPosition, Dicts.ListCheckPosition);
        PageHelper.FillDropDownList(ddlCheckMethod, Dicts.ListCheckMethod);
    }
    public void BindItems()
    {
        using (IDataReader dr = DataAccess.ExecuteReader(String.Format("select * from DictSpecs where id={0}", SpecsID)))
        {
            if (dr.Read())
            {
                PageHelper.DropDownListSetValue(ddlSection, dr["Section"]);
                PageHelper.DropDownListSetValue(ddlCheckPosition, dr["checkPosition"]);
                PageHelper.DropDownListSetValue(ddlCheckMethod, dr["checkmethod"]);
                txtSequence.Text = dr["Sequence"].ToString();
                
            }
            dr.Close();
        }

        this.grdItems.ShowFooter = true;
        this.grdItems.DataSource = DataAccess.ExecuteDataTable(String.Format("select * from dictSpecsItems where DictSpecsID={0}", SpecsID));
        this.grdItems.DataBind();
    }


//    protected void btnImport_Click(object sender, EventArgs e)
//    {
//        string section = "";
//        int sequence = 0;
//        string checkposition = "";
//        string checkDetail = "";
//        string checkmethod = "";
//        string sh = "";
//        string knockposition = "";
//        float id = 0;           
//        foreach(DataRow  dr in  DataAccess.ExecuteDataTable("select * from oldData order by no").Rows)
//        {
          
//            if (dr["section"] != DBNull.Value)
//            {
//                section = dr["section"].ToString();
//            }
//            if (dr["sequence"] != DBNull.Value)
//            {
//                sequence = Int32.Parse(dr["sequence"].ToString());
//            }
//            if (dr["checkposition"] != DBNull.Value)
//            {                  
//                checkposition = dr["checkposition"].ToString();
//            }
//            if (dr["checkdetail"] != DBNull.Value)
//            {
//                checkDetail = dr["checkdetail"].ToString();
//            }
//            else
//                checkDetail = "";

//            if (dr["checkmethod"] != DBNull.Value)
//            {
//                checkmethod = dr["checkmethod"].ToString();
//            }
//            if (dr["sh"] != DBNull.Value)
//            {
//                sh = dr["sh"].ToString();
//            }
//            else
//                sh = "";

//            if (dr["knockposition"] != DBNull.Value)
//            {
//                knockposition = dr["knockposition"].ToString();
//            }
//            else
//                knockposition = "";




//            if ((dr["sequence"] != DBNull.Value) && (dr["checkposition"] != DBNull.Value))
//            {
            
//                id = float.Parse(DataAccess.ExecuteScalar(String.Format(@"Insert into DictSpecs(Section,Sequence,CheckPosition,CheckMethod)
//                                                                   Values('{0}',{1},'{2}','{3}') select @@identity",
//                                                                   section,
//                                                                   sequence,
//                                                                   checkposition,
//                                                                   checkmethod)).ToString());
//            }
//            if (id > 0)
//            {
//                DataAccess.ExecuteNonQuery(String.Format(@"Insert into DictSpecsItems(DictSpecsID,CheckDetail,CheckMethod,SpecifiedSizeHeight,KnockPosition)
//                                                          Values({0},'{1}','{2}','{3}','{4}')",
//                                                                     id,
//                                                                     checkDetail,
//                                                                     checkmethod,
//                                                                     sh,
//                                                                     knockposition));

                                                           
//            }
//        }
//    }
}
