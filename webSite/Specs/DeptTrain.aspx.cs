using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Specs_DeptTrain : System.Web.UI.Page
{
    private String EntityTypeName
    {
        get
        {
            return "DeptTrain";
        }
    }
    private Dept _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_UserControl_" + EntityTypeName];

            if (o == null)
            {
                o = new Dept();

                ViewState["Current_Entity_UserControl_" + EntityTypeName] = o;
            }
            return o as Dept;

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
        }
    }
    public void BindDetailData(Int32 id)
    {
        if (id > 0)
        {
            _Entity.Find(id);
        }
        txtArea.Text = _Entity.Area;
        lblArea.Text = _Entity.Area;
        txtFactory.Text = _Entity.Factory;
        lblFactory.Text = _Entity.Factory;
        txtSection.Text = _Entity.Section;
        lblSection.Text = _Entity.Section;
        txtCode.Text = _Entity.Code;
        lblCode.Text = _Entity.Code;
        txtTrainCode.Text = _Entity.TrainCode;
        lblTrainCode.Text = _Entity.TrainCode;
        txtAlias.Text = _Entity.Alias;
        lblAlias.Text = _Entity.Alias;

        SetEditable(IsEditable);
    }
    private void SetEditable(Boolean visible)
    {
        btnEdit.Visible = !visible;
        btnInsert.Visible = visible;
        btnUpdate.Visible = visible;
        btnDelete.Visible = visible;
        btnCancel.Visible = visible;
        txtArea.Visible = visible;
        lblArea.Visible = !visible;
        txtFactory.Visible = visible;
        lblFactory.Visible = !visible;
        txtSection.Visible = visible;
        lblSection.Visible = !visible;
        txtCode.Visible = visible;
        lblCode.Visible = !visible;
        txtTrainCode.Visible = visible;
        lblTrainCode.Visible = !visible;
        txtAlias.Visible = visible;
        lblAlias.Visible = !visible;

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

        if (!String.IsNullOrEmpty(txtArea.Text))
        {
            _Entity.Area = (txtArea.Text);
        }

        if (!String.IsNullOrEmpty(txtFactory.Text))
        {
            _Entity.Factory = (txtFactory.Text);
        }

        if (!String.IsNullOrEmpty(txtSection.Text))
        {
            _Entity.Section = (txtSection.Text);
        }

        if (!String.IsNullOrEmpty(txtCode.Text))
        {
            _Entity.Code = (txtCode.Text);
        }

        if (!String.IsNullOrEmpty(txtTrainCode.Text))
        {
            _Entity.TrainCode = (txtTrainCode.Text);
        }

        if (!String.IsNullOrEmpty(txtAlias.Text))
        {
            _Entity.Alias = (txtAlias.Text);
        }


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


        txtArea.Text = "";
        txtFactory.Text = "";
        txtSection.Text = "";
        txtCode.Text = "";
        txtTrainCode.Text = "";
        txtAlias.Text = "";

    }
}
