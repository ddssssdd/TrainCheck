using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Specs_DictSpecsEdit : System.Web.UI.Page
{
    private String EntityTypeName
    {
        get
        {
            return "DictSpecsEdit";
        }
    }
    private DictSpecs _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_UserControl_" + EntityTypeName];

            if (o == null)
            {
                o = new DictSpecs();

                ViewState["Current_Entity_UserControl_" + EntityTypeName] = o;
            }
            return o as DictSpecs;

        }
        set
        {
            ViewState["Current_Entity_UserControl_" + EntityTypeName] = value;
        }
    }
    private Boolean IsEditable
    {
        get
        {
            object o = ViewState["Current_IsEditable"];
            if (o == null)
            {
                return false;
            }
            else
                return Boolean.Parse(o.ToString());
        }
        set
        {
            ViewState["Current_IsEditable"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!String.IsNullOrEmpty(Request["id"]))
            {
                BindDetailData(Int32.Parse(Request["id"]));
              
            }
            BindGrid();
            
        }
      

    }
    public void BindGrid()
    {
        
        System.Data.DataTable dt = _Entity.Persistence.sql.ExecuteDataTable("select * from dictspecsitems where dictSpecsID=" + _Entity.ID.ToString());
        if (dt.Rows.Count == 0)
        {
            List<DictSpecsItems> list = new List<DictSpecsItems>();
            list.Add(new DictSpecsItems());
            grdItems.DataSource = list;
            grdItems.DataBind();
            grdItems.Rows[0].Visible = false;
        }
        else
        {
            grdItems.DataSource = dt;
            grdItems.DataBind();
        }
        
        
    }
    public void BindDetailData(Int32 id)
    {
        txtSection.DataSource = AppHelper.SectionList;
        txtSection.DataBind();
        txtCheckPosition.DataSource = AppHelper.CheckPositionList;
        txtCheckPosition.DataBind();
        txtCheckMethod.DataSource = AppHelper.CheckMethodList;
        txtCheckMethod.DataBind();
        if (id > 0)
        {
            _Entity.Find(id);
        }
        txtSection.Text = _Entity.Section;
        lblSection.Text = _Entity.Section;
        txtSequence.Text = _Entity.Sequence.ToString();
        lblSequence.Text = _Entity.Sequence.ToString();
        txtCheckPosition.Text = _Entity.CheckPosition;
        lblCheckPosition.Text = _Entity.CheckPosition;
        txtCheckMethod.Text = _Entity.CheckMethod;
        lblCheckMethod.Text = _Entity.CheckMethod;
        txtBarCode.Text = _Entity.BarCode;
        lblBarCode.Text = _Entity.BarCode;
        chkIsFull.Checked = _Entity.IsFull;
        SetEditable(IsEditable);
    }
    private void SetEditable(Boolean visible)
    {
        btnEdit.Visible = !visible;
        btnInsert.Visible = visible;
        btnUpdate.Visible = visible;
        btnDelete.Visible = visible;
        btnCancel.Visible = visible;
        txtSection.Visible = visible;
        lblSection.Visible = !visible;
        txtSequence.Visible = visible;
        lblSequence.Visible = !visible;
        txtCheckPosition.Visible = visible;
        lblCheckPosition.Visible = !visible;
        txtCheckMethod.Visible = visible;
        lblCheckMethod.Visible = !visible;
        txtBarCode.Visible = visible;
        lblBarCode.Visible = !visible;


    }
    protected void btnDetail_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            IsEditable = true;
            BindDetailData(0);
            return;
        }
        if (e.CommandName == "cancel")
        {
            IsEditable = false;
            SetEditable(IsEditable);
            return;
        }

        if (!String.IsNullOrEmpty(txtSection.Text))
        {
            _Entity.Section = (txtSection.Text);
        }

        if (!String.IsNullOrEmpty(txtSequence.Text))
        {
            _Entity.Sequence = Int32.Parse(txtSequence.Text);
        }

        if (!String.IsNullOrEmpty(txtCheckPosition.Text))
        {
            _Entity.CheckPosition = (txtCheckPosition.Text);
        }

        if (!String.IsNullOrEmpty(txtCheckMethod.Text))
        {
            _Entity.CheckMethod = (txtCheckMethod.Text);
        }

        if (!String.IsNullOrEmpty(txtBarCode.Text))
        {
            _Entity.BarCode = (txtBarCode.Text);
        }

        _Entity.IsFull = chkIsFull.Checked;
        IsEditable = false;
        switch (e.CommandName)
        {
            case "insert":
                _Entity.Insert();
                BindDetailData(_Entity.ID);
                break;
            case "update":
                _Entity.Update();
                BindDetailData(_Entity.ID);
                break;
            case "delete":
                _Entity.Delete();
                break;
        }


        //txtSection.SelectedIndex = 0;
        //txtSequence.Text = "";
        //txtCheckPosition.SelectedIndex = 0;
        //txtCheckMethod.SelectedIndex = 0;
        //txtBarCode.Text = "";
        //chkIsFull.Checked = false;
    }
    private void AssignRowToSpecsItem(GridViewRow row, DictSpecsItems item)
    {
        Control control = row.FindControl("txtCheckDetail");
        if (control != null)
        {
            item.CheckDetail = (control as TextBox).Text.Trim();
        }
        control = row.FindControl("ddlCheckMethod");
        if (control != null)
        {
            item.CheckMethod = (control as DropDownList).Text;
        }
        control = row.FindControl("txtSpecifiedSizeHeight");
        if (control!=null)
        {
            item.SpecifiedSizeHeight = (control as TextBox).Text.Trim();
        }
        control = row.FindControl("txtKnockPosition");
        if (control != null)
        {
            item.KnockPosition = (control as TextBox).Text.Trim();
        }
        control = row.FindControl("chkIsFull");
        if (control != null)
        {
            item.IsFull = (control as CheckBox).Checked;
        }
    }
    protected void grdItems_RowCreated(object sender, GridViewRowEventArgs e)
    {
       
    }
    protected void grdItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals( "Add"))
        { 
            DictSpecsItems item = new DictSpecsItems();
            AssignRowToSpecsItem(grdItems.FooterRow, item);
            item.DictSpecsID = _Entity.ID;
            if (item.Insert())
            {
                grdItems.EditIndex = -1;
                BindGrid();
            }
        }
        if (e.CommandName.Equals("Save"))
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            DictSpecsItems item = new DictSpecsItems();
            if (item.Find(id))
            {
                AssignRowToSpecsItem(grdItems.Rows[grdItems.EditIndex], item);
                if (item.Update())
                {
                    grdItems.EditIndex = -1;
                    BindGrid();
                }
            }
        }
        if (e.CommandName.Equals("Delete"))
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            DictSpecsItems item = new DictSpecsItems();
            if (item.Find(id))
            {                
                if (item.Delete())
                {
                    grdItems.EditIndex = -1;
                    BindGrid();
                }
            }
        }
     
    }
    
    protected void grdItems_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdItems.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void grdItems_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void grdItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
    }
    protected void grdItems_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdItems.EditIndex = -1;
        BindGrid();
    }
    protected void grdItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
}
