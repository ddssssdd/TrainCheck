<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="UsersSearch.aspx.cs" Inherits="Users_UsersSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panSearch" runat="server" DefaultButton="btnSearch">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="工号" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtUserName_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="编号" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtUserNo_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="姓名" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtName_Search" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="部门" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtDepartment_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="密码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtPassword_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="状态" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtIsActive_Search" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="过期日" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtExpirtationDate_Search" runat="server" Width="100px" />
                </td>
                <td colspan="4">
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查找" SkinID="btnshort" OnClick="btnSearch_Click" />&nbsp
        <asp:Button ID="btnClear" runat="server" Text="清除" SkinID="btnshort" OnClick="btnClear_Click" />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="新增用户" SkinID="btnlong" OnClick="btnAdd_Click" />
    </asp:Panel>
    <table>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" Text="每页条数" runat="server"></asp:Label>
                <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged"
                    AutoPostBack="true">
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                    <asp:ListItem>100</asp:ListItem>
                    <asp:ListItem>200</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdResult" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                    OnSorting="grdResult_Sorting" OnSelectedIndexChanged="grdResult_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Select" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="UserName" HeaderText="工号">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("UserName") %>' ID="lblUserName" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="UserNo" HeaderText="编号">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("UserNo") %>' ID="lblUserNo" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Name" HeaderText="姓名">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="lblName" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Department" HeaderText="部门">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Department") %>' ID="lblDepartment" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Password" HeaderText="密码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Password") %>' ID="lblPassword" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="IsActive" HeaderText="状态">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("IsActive") %>' ID="lblIsActive" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="ExpirtationDate" HeaderText="过期日">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("ExpirtationDate") %>' ID="lblExpirtationDate"
                                    SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <Pager:AspNetPager ID="pagerMain" runat="server" OnPageChanged="pagerMain_PageChanged">
                </Pager:AspNetPager>
            </td>
        </tr>
    </table>
</asp:Content>
