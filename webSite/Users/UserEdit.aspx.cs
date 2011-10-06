using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Users_UserEdit : System.Web.UI.Page
{
    private String EntityTypeName
    {
        get
        {
            return "UserEdit";
        }
    }
    private Users _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_UserControl_" + EntityTypeName];

            if (o == null)
            {
                o = new Users();

                ViewState["Current_Entity_UserControl_" + EntityTypeName] = o;
            }
            return o as Users;

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
        txtUserName.Text = _Entity.UserName;
        lblUserName.Text = _Entity.UserName;
        txtUserNo.Text = _Entity.UserNo;
        lblUserNo.Text = _Entity.UserNo;
        txtName.Text = _Entity.Name;
        lblName.Text = _Entity.Name;
        txtDepartment.Text = _Entity.Department;
        lblDepartment.Text = _Entity.Department;
        txtPassword.Text = _Entity.Password;
        lblPassword.Text = _Entity.Password;
        txtIsActive.Text = _Entity.IsActive.ToString();
        lblIsActive.Text = _Entity.IsActive.ToString();
        txtExpirtationDate.Text = _Entity.ExpirtationDate.ToString();
        lblExpirtationDate.Text = _Entity.ExpirtationDate.ToString();

        SetEditable(IsEditable);
    }
    private void SetEditable(Boolean visible)
    {
        btnEdit.Visible = !visible;
        btnInsert.Visible = visible;
        btnUpdate.Visible = visible;
        btnDelete.Visible = visible;
        btnCancel.Visible = visible;
        txtUserName.Visible = visible;
        lblUserName.Visible = !visible;
        txtUserNo.Visible = visible;
        lblUserNo.Visible = !visible;
        txtName.Visible = visible;
        lblName.Visible = !visible;
        txtDepartment.Visible = visible;
        lblDepartment.Visible = !visible;
        txtPassword.Visible = visible;
        lblPassword.Visible = !visible;
        txtIsActive.Visible = visible;
        lblIsActive.Visible = !visible;
        txtExpirtationDate.Visible = visible;
        lblExpirtationDate.Visible = !visible;

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

        if (!String.IsNullOrEmpty(txtUserName.Text))
        {
            _Entity.UserName = (txtUserName.Text);
        }

        if (!String.IsNullOrEmpty(txtUserNo.Text))
        {
            _Entity.UserNo = (txtUserNo.Text);
        }

        if (!String.IsNullOrEmpty(txtName.Text))
        {
            _Entity.Name = (txtName.Text);
        }

        if (!String.IsNullOrEmpty(txtDepartment.Text))
        {
            _Entity.Department = (txtDepartment.Text);
        }

        if (!String.IsNullOrEmpty(txtPassword.Text))
        {
            _Entity.Password = (txtPassword.Text);
        }

        if (!String.IsNullOrEmpty(txtIsActive.Text))
        {
            _Entity.IsActive = Boolean.Parse(txtIsActive.Text);
        }

        if (!String.IsNullOrEmpty(txtExpirtationDate.Text))
        {
            _Entity.ExpirtationDate = DateTime.Parse(txtExpirtationDate.Text);
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


        txtUserName.Text = "";
        txtUserNo.Text = "";
        txtName.Text = "";
        txtDepartment.Text = "";
        txtPassword.Text = "";
        txtIsActive.Text = "";
        txtExpirtationDate.Text = "";

    }
}