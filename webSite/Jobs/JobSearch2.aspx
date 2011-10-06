<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="JobSearch2.aspx.cs" Inherits="Jobs_JobSearch2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:Panel ID="panSearch" runat="server" DefaultButton="btnSearch">
        <table width="600px">
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server" Text="供电段" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlArea_Search" runat="server" Width="100px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlArea_Search_SelectedIndexChanged" />
                </td>
                <td>
                    <asp:Label ID="Label14" runat="server" Text="供电车间" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlFactory_Search" runat="server" Width="100px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="ddlFactory_Search_SelectedIndexChanged" />
                </td>
                <td>
                    <asp:Label ID="Label15" runat="server" Text="工区" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlSection_Search" runat="server" Width="100px" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="巡检员" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtName_Search" runat="server" Width="100px" />
                </td>
                <td>
                    <asp:Label ID="Label12" runat="server" Text="开始日期" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtJobDate_begin" runat="server" Width="100px" />
                </td>
                <td>
                     <asp:Label ID="Label3" runat="server" Text="结束日期" SkinID="field_title" />
                </td>
                <td>
                     <asp:TextBox ID="txtJobDate_end" runat="server" Width="100px" />
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
                <asp:Label ID="Label11" Text="每页条数" runat="server"></asp:Label>
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
                       <asp:TemplateField SortExpression="CheckType" HeaderText="巡检类型">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("CheckType") %>' ID="lblCheckType" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField SortExpression="Name" HeaderText="巡检员">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("Name") %>' ID="lblName" SkinID="" />
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
                        <asp:TemplateField SortExpression="JobDate" HeaderText="检查日期">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("JobDate") %>' ID="lblJobDate" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:TemplateField SortExpression="BeginTime" HeaderText="开始时间">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("BeginTime") %>' ID="lblBeginTime" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="UpdateDateTime" HeaderText="上传时间">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("UpdateDateTime") %>' ID="lblUpdateDateTime"
                                    SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField SortExpression="CheckPosition" HeaderText="检查点">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("CheckPosition") %>' ID="lblCheckPosition"
                                    SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="PassPosition" HeaderText="通过点">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Bind("PassPosition") %>' ID="lblPassPosition"
                                    SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField SortExpression="TrainCode" HeaderText="未通过">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                               
                                <asp:Label runat="server" Text='<%# Bind("FailurePosition") %>' ID="lblTrainCode" SkinID="" />
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("VW_JobMainID") %>'
                                    CommandName="Select" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
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

