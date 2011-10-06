<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DictSpecsSearch.aspx.cs" Inherits="Specs_DictSpecsSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panSearch" runat="server" DefaultButton="btnSearch">
        <table width="600px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="部位" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtSection_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="顺序" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtSequence_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="检查部位" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtCheckPosition_Search" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="检查方法" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtCheckMethod_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="条码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtBarCode_Search" runat="server" Width="100px" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="查找" SkinID="btnshort" OnClick="btnSearch_Click" />&nbsp
        <asp:Button ID="btnClear" runat="server" Text="清除" SkinID="btnshort" OnClick="btnClear_Click" />
    </asp:Panel>
    <table>
        <tr>
            <td align="right">
                <asp:Label ID="Label6" Text="每页条数" runat="server"></asp:Label>
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
                    OnSorting="grdResult_Sorting"  OnSelectedIndexChanged="grdResult_SelectedIndexChanged" >
                   
                    <Columns>
                    <asp:TemplateField>
                            <ItemTemplate>
                                 <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Select" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Section" HeaderText="部位">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Section") %>' ID="lblSection" SkinID="" />
                                <asp:Label runat="server" Text='<%# Bind("ID") %>' ID="lblID" visible="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="Sequence" HeaderText="顺序">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Sequence") %>' ID="lblSequence" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CheckPosition" HeaderText="检查部位">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("CheckPosition") %>' ID="lblCheckPosition"
                                    SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="CheckMethod" HeaderText="检查方法">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("CheckMethod") %>' ID="lblCheckMethod" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="BarCode" HeaderText="条码">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("BarCode") %>' ID="lblBarCode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField SortExpression="IsFull" HeaderText="全面检查">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:CheckBox runat="server" Checked='<%# Bind("IsFull") %>' ID="chkIsFull" />
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
