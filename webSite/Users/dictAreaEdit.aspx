<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="dictAreaEdit.aspx.cs" Inherits="Users_dictAreaEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width=800px">
        <tr>
            <td align="right">
                <a href="javascript:history.go(-1);">[返回]</a>
            </td>
        </tr>
    </table>
    <asp:Panel ID="panDetail" runat="server" SkinID="PanelEdit">
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Text="父编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtparentCode" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblparentCode" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtcode" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblcode" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="描述" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtdescription" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lbldescription" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="接触网待检" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtno1" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblno1" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="牵引变待检" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtno2" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblno2" runat="server" SkinID="field_value" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" OnCommand="btnDetail_Command" />&nbsp
        <asp:Button ID="btnInsert" runat="server" Text="新建" CommandName="insert" OnCommand="btnDetail_Command" />&nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="更新" CommandName="update" OnCommand="btnDetail_Command" />&nbsp
        <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="delete" OnCommand="btnDetail_Command" />&nbsp
        <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="cancel" OnCommand="btnDetail_Command" />&nbsp
    </asp:Panel>
</asp:Content>
