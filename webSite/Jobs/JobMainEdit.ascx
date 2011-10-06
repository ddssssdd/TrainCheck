<%@ Control Language="C#" AutoEventWireup="true" CodeFile="JobMainEdit.ascx.cs" Inherits="Jobs_JobMainEdit" %>
<asp:Panel ID="panDetail" runat="server" SkinID="PanelEdit">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="JobDate" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtJobDate" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblJobDate" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="UserID" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblUserID" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="BeginTime" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtBeginTime" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblBeginTime" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="EndTime" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtEndTime" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblEndTime" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="IpAddress" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtIpAddress" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblIpAddress" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="IsUploaded" SkinID="field_title" />
            </td>
            <td>
                <asp:CheckBox ID="chkIsUploaded" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblIsUploaded" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="UpdateDateTime" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtUpdateDateTime" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblUpdateDateTime" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" Text="NeedCheckPosition" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtNeedCheckPosition" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblNeedCheckPosition" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label9" runat="server" Text="CheckPosition" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtCheckPosition" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblCheckPosition" runat="server" SkinID="field_value" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="PassPosition" SkinID="field_title" />
            </td>
            <td>
                <asp:TextBox ID="txtPassPosition" runat="server" Width="200px" Visible="false" />
                <asp:Label ID="lblPassPosition" runat="server" SkinID="field_value" />
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
