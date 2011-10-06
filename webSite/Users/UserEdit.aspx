<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="UserEdit.aspx.cs" Inherits="Users_UserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="panDetail" runat="server" SkinID="PanelEdit">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="工号" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtUserName" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblUserName" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="编码" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtUserNo" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblUserNo" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="姓名" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblName" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="部门" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtDepartment" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblDepartment" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="密码" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblPassword" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="状态" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtIsActive" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblIsActive" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="过期日" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtExpirtationDate" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblExpirtationDate" runat="server" SkinID="field_value" />
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" OnCommand="btnDetail_Command" SkinID="btnshort" />&nbsp
    <asp:Button ID="btnInsert" runat="server" Text="新增" CommandName="insert" OnCommand="btnDetail_Command" SkinID="btnshort" />&nbsp
    <asp:Button ID="btnUpdate" runat="server" Text="更新" CommandName="update" OnCommand="btnDetail_Command" SkinID="btnshort" />&nbsp
    <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="delete" OnCommand="btnDetail_Command" SkinID="btnshort" />&nbsp
    <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="cancel" OnCommand="btnDetail_Command" SkinID="btnshort" />&nbsp
</asp:Panel>
</asp:Content>

