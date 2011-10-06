<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DictArea.aspx.cs" Inherits="Users_DictArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Panel ID="panSearch" runat="server" DefaultButton="btnSearch">
        <table><tr>
                                                   <td><asp:Label  runat="server" text="编码" SkinID="field_title" /></td>
                                                   <td><asp:TextBox id="txtcode_Search" runat="server" width="100px" /></td>
                                              </tr><tr>
                                                   <td><asp:Label  runat="server" text="描述" SkinID="field_title" /></td>
                                                   <td><asp:TextBox id="txtdescription_Search" runat="server" width="100px" /></td>
                                              </tr><tr>
                                                   <td><asp:Label  runat="server" text="接触网待检" SkinID="field_title" /></td>
                                                   <td><asp:TextBox id="txtno1_Search" runat="server" width="100px" /></td>
                                              </tr></table>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查找" OnClick="btnSearch_Click" />&nbsp
        <asp:Button ID="btnClear" runat="server" Text="清除" OnClick="btnClear_Click" />
    </asp:Panel>
    <table>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" Text="每页" runat="server"></asp:Label>
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
                    OnSorting="grdResult_Sorting" 
                    OnSelectedIndexChanged="grdResult_SelectedIndexChanged">
                    <Columns>
                     <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Select" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="parentCode" HeaderText="父编码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("parentCode") %>' ID="lblparentCode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="code" HeaderText="编码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("code") %>' ID="lblcode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="description" HeaderText="描述">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("description") %>' ID="lbldescription" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="no1" HeaderText="接触网待检">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("no1") %>' ID="lblno1" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="no2" HeaderText="牵引变待检">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("no2") %>' ID="lblno2" SkinID="" />
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

