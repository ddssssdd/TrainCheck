<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="JobDetail.aspx.cs" Inherits="Jobs_JobDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <table width="1024px">
        <tr>
            <td align="right">
                <a href="javascript:history.go(-1);">[返回]</a>
            </td>
        </tr>
    </table>
    <asp:GridView ID="grdDetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
        OnSorting="grdDetails_Sorting" OnRowDataBound="grdDetails_RowDataBound">
        <Columns>
            <asp:TemplateField SortExpression="SpecsID" HeaderText="SpecsID" Visible="false">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("SpecsID") %>' ID="lblSpecsID" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CheckTime" HeaderText="检查时间">
                <ItemStyle Width="150px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("CheckTime") %>' ID="lblCheckTime" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Section" HeaderText="区间、站">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Description") %>' ID="lblSection" SkinID="" />
                    <asp:Label runat="server" Text='<%# Bind("ID") %>' ID="lblID" Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Sequence" HeaderText="支柱号">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("checkPointNo") %>' ID="lblSequence" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CheckPosition" HeaderText="设备名称">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("CheckPosition") %>' ID="lblCheckPosition"
                        SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField SortExpression="BarCode" HeaderText="条码">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("BarCode") %>' ID="lblBarCode" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CheckDetailList" HeaderText="检查项目" Visible="false">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("CheckDetailList") %>' ID="lblCheckDetailList"
                        SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CheckDetailList" HeaderText="检查项目">
                <ItemStyle Width="400px" />
                <ItemTemplate>
                    <table>
                       
                        <asp:Repeater ID="rptDetail" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl='<%# Bind("ImageUrl") %>' />
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text='<%# Bind("CheckDetail") %>' ID="lblCheckDetailList"
                                            SkinID="" />
                                            
                                         <asp:Label runat="server" Text='<%# Bind("Note") %>' ID="lblNote" SkinID="req" />
                                    </td>                                    
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
