using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Jobs_JobMainEdit : System.Web.UI.UserControl
{
    private String EntityTypeName
    {
        get
        {
            return "JobMainEdit";
        }
    }
    private JobMain _Entity
    {
        get
        {
            Object o;
            o = ViewState["Current_Entity_UserControl_" + EntityTypeName];

            if (o == null)
            {
                o = new JobMain();

                ViewState["Current_Entity_UserControl_" + EntityTypeName] = o;
            }
            return o as JobMain;

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

        }
    }
    public void BindDetailData(Int32 id)
    {
        if (id > 0)
        {
            _Entity.Find(id);
        }
        txtJobDate.Text = _Entity.JobDate.ToString();
        lblJobDate.Text = _Entity.JobDate.ToString();
        txtUserID.Text = _Entity.UserID.ToString();
        lblUserID.Text = _Entity.UserID.ToString();
        txtBeginTime.Text = _Entity.BeginTime.ToString();
        lblBeginTime.Text = _Entity.BeginTime.ToString();
        txtEndTime.Text = _Entity.EndTime.ToString();
        lblEndTime.Text = _Entity.EndTime.ToString();
        txtIpAddress.Text = _Entity.IpAddress;
        lblIpAddress.Text = _Entity.IpAddress;
        chkIsUploaded.Checked = _Entity.IsUploaded;
        lblIsUploaded.Text = chkIsUploaded.Checked.ToString();
        txtUpdateDateTime.Text = _Entity.UpdateDateTime.ToString();
        lblUpdateDateTime.Text = _Entity.UpdateDateTime.ToString();
        txtNeedCheckPosition.Text = _Entity.NeedCheckPosition.ToString();
        lblNeedCheckPosition.Text = _Entity.NeedCheckPosition.ToString();
        txtCheckPosition.Text = _Entity.CheckPosition.ToString();
        lblCheckPosition.Text = _Entity.CheckPosition.ToString();
        txtPassPosition.Text = _Entity.PassPosition.ToString();
        lblPassPosition.Text = _Entity.PassPosition.ToString();

        SetEditable(IsEditable);
    }
    private void SetEditable(Boolean visible)
    {
        btnEdit.Visible = !visible;
        btnInsert.Visible = visible;
        btnUpdate.Visible = visible;
        btnDelete.Visible = visible;
        btnCancel.Visible = visible;
        txtJobDate.Visible = visible;
        lblJobDate.Visible = !visible;
        txtUserID.Visible = visible;
        lblUserID.Visible = !visible;
        txtBeginTime.Visible = visible;
        lblBeginTime.Visible = !visible;
        txtEndTime.Visible = visible;
        lblEndTime.Visible = !visible;
        txtIpAddress.Visible = visible;
        lblIpAddress.Visible = !visible;
        chkIsUploaded.Visible = visible;
        lblIsUploaded.Visible = !visible;
        txtUpdateDateTime.Visible = visible;
        lblUpdateDateTime.Visible = !visible;
        txtNeedCheckPosition.Visible = visible;
        lblNeedCheckPosition.Visible = !visible;
        txtCheckPosition.Visible = visible;
        lblCheckPosition.Visible = !visible;
        txtPassPosition.Visible = visible;
        lblPassPosition.Visible = !visible;

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

        if (!String.IsNullOrEmpty(txtJobDate.Text))
        {
            _Entity.JobDate = DateTime.Parse(txtJobDate.Text);
        }

        if (!String.IsNullOrEmpty(txtUserID.Text))
        {
            _Entity.UserID = Int32.Parse(txtUserID.Text);
        }

        if (!String.IsNullOrEmpty(txtBeginTime.Text))
        {
            _Entity.BeginTime = DateTime.Parse(txtBeginTime.Text);
        }

        if (!String.IsNullOrEmpty(txtEndTime.Text))
        {
            _Entity.EndTime = DateTime.Parse(txtEndTime.Text);
        }

        if (!String.IsNullOrEmpty(txtIpAddress.Text))
        {
            _Entity.IpAddress = (txtIpAddress.Text);
        }

        _Entity.IsUploaded = chkIsUploaded.Checked;
        if (!String.IsNullOrEmpty(txtUpdateDateTime.Text))
        {
            _Entity.UpdateDateTime = DateTime.Parse(txtUpdateDateTime.Text);
        }

        if (!String.IsNullOrEmpty(txtNeedCheckPosition.Text))
        {
            _Entity.NeedCheckPosition = Int32.Parse(txtNeedCheckPosition.Text);
        }

        if (!String.IsNullOrEmpty(txtCheckPosition.Text))
        {
            _Entity.CheckPosition = Int32.Parse(txtCheckPosition.Text);
        }

        if (!String.IsNullOrEmpty(txtPassPosition.Text))
        {
            _Entity.PassPosition = Int32.Parse(txtPassPosition.Text);
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


        txtJobDate.Text = "";
        txtUserID.Text = "";
        txtBeginTime.Text = "";
        txtEndTime.Text = "";
        txtIpAddress.Text = "";
        chkIsUploaded.Checked = false;
        txtUpdateDateTime.Text = "";
        txtNeedCheckPosition.Text = "";
        txtCheckPosition.Text = "";
        txtPassPosition.Text = "";

    }
}
