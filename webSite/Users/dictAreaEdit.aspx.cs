using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orion.Entity2;

public partial class Users_dictAreaEdit : System.Web.UI.Page
{
    private String EntityTypeName
    {
        get
        {
            return Request["TypeName"];
        }
    }
    private dictArea _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_UserControl_" + EntityTypeName];

            if (o == null)
            {
                o = new dictArea();

                ViewState["Current_Entity_UserControl_" + EntityTypeName] = o;
            }
            return o as dictArea;

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
        txtparentCode.Text = _Entity.parentCode;
        lblparentCode.Text = _Entity.parentCode;
        txtcode.Text = _Entity.code;
        lblcode.Text = _Entity.code;
        txtdescription.Text = _Entity.description;
        lbldescription.Text = _Entity.description;
        txtno1.Text = _Entity.no1.ToString();
        lblno1.Text = _Entity.no1.ToString();
        txtno2.Text = _Entity.no2.ToString();
        lblno2.Text = _Entity.no2.ToString();

        SetEditable(IsEditable);
    }
    private void SetEditable(Boolean visible)
    {
        btnEdit.Visible = !visible;
        btnInsert.Visible = visible;
        btnUpdate.Visible = visible;
        btnDelete.Visible = visible;
        btnCancel.Visible = visible;
        txtparentCode.Visible = visible;
        lblparentCode.Visible = !visible;
        txtcode.Visible = visible;
        lblcode.Visible = !visible;
        txtdescription.Visible = visible;
        lbldescription.Visible = !visible;
        txtno1.Visible = visible;
        lblno1.Visible = !visible;
        txtno2.Visible = visible;
        lblno2.Visible = !visible;

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

        if (!String.IsNullOrEmpty(txtparentCode.Text))
        {
            _Entity.parentCode = (txtparentCode.Text);
        }

        if (!String.IsNullOrEmpty(txtcode.Text))
        {
            _Entity.code = (txtcode.Text);
        }

        if (!String.IsNullOrEmpty(txtdescription.Text))
        {
            _Entity.description = (txtdescription.Text);
        }

        if (!String.IsNullOrEmpty(txtno1.Text))
        {
            _Entity.no1 = Int32.Parse(txtno1.Text);
        }

        if (!String.IsNullOrEmpty(txtno2.Text))
        {
            _Entity.no2 = Int32.Parse(txtno2.Text);
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


        txtparentCode.Text = "";
        txtcode.Text = "";
        txtdescription.Text = "";
        txtno1.Text = "";
        txtno2.Text = "";

    } 
}
