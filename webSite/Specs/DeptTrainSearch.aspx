<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DeptTrainSearch.aspx.cs" Inherits="Specs_DeptTrainSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panSearch" runat="server" DefaultButton="btnSearch">
        <table width="800px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="供电段" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtArea_Search" runat="server" Width="100px" />
                </td>
           
                <td>
                    <asp:Label ID="Label2" runat="server" Text="供电车间" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtFactory_Search" runat="server" Width="100px" />
                </td>
           
                <td>
                    <asp:Label ID="Label3" runat="server" Text="工区" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtSection_Search" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtCode_Search" runat="server" Width="100px" />
                </td>
            
                <td>
                    <asp:Label ID="Label5" runat="server" Text="车辆编码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtTrainCode_Search" runat="server" Width="100px" />
                </td>
            
                <td>
                    <asp:Label ID="Label6" runat="server" Text="牌照" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtAlias_Search" runat="server" Width="100px" />
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查找" SkinID="btnshort" OnClick="btnSearch_Click" />&nbsp
        <asp:Button ID="btnClear" runat="server" Text="清除" SkinID="btnshort" OnClick="btnClear_Click" />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="增加新车辆" SkinID="btnlong" 
            onclick="btnAdd_Click" />
    </asp:Panel>
    <table>
        <tr>
            <td align="right">
                <asp:Label ID="Label7" Text="每页条数" runat="server"></asp:Label>
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
                    OnSorting="grdResult_Sorting"  OnSelectedIndexChanged="grdResult_SelectedIndexChanged">
                    <Columns>
                    <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Select" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Area" HeaderText="供电段">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Area") %>' ID="lblArea" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Factory" HeaderText="供电车间">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Factory") %>' ID="lblFactory" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Section" HeaderText="工区">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Section") %>' ID="lblSection" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Code" HeaderText="编码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Code") %>' ID="lblCode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="TrainCode" HeaderText="车辆编码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("TrainCode") %>' ID="lblTrainCode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Alias" HeaderText="牌照">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Alias") %>' ID="lblAlias" SkinID="" />
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
