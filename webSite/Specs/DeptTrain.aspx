<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DeptTrain.aspx.cs" Inherits="Specs_DeptTrain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panDetail" runat="server" SkinID="PanelEdit">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="供电段" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtArea" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblArea" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="供电车间" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtFactory" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblFactory" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="工区" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtSection" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblSection" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblCode" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="车辆编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtTrainCode" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblTrainCode" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="牌照" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtAlias" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblAlias" runat="server" SkinID="field_value" />
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
