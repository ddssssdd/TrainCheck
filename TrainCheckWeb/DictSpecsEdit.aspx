<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Edit.master" AutoEventWireup="true"
    CodeFile="DictSpecsEdit.aspx.cs" Inherits="DictSpecsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%">
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="编码："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtBarCode" runat="server" Width="120px"></asp:TextBox>
                <asp:Label ID="lblBarCode" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="部位："></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlSection" runat="server" Width="120px">
                </asp:DropDownList>
                <asp:Label ID="lblSection" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="顺序："></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtSequence" runat="server" Width="120px"></asp:TextBox>
                <asp:Label ID="lblSequence" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="检查部位："></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCheckPosition" runat="server" Width="120px">
                </asp:DropDownList>
                <asp:Label ID="lblCheckPosition" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" Text="检查方法："></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlCheckMethod" runat="server" Width="120px">
                </asp:DropDownList>
                <asp:Label ID="lblCheckMethod" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" 
                    ShowFooter="True">
                    <Columns>
                        <asp:TemplateField HeaderText="检查处所" SortExpression="CheckDetail">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtCheckDetail" runat="server" Text='<%# Bind("CheckDetail") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCheckDetail" runat="server" Text='<%# Bind("CheckDetail") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtCheckDetail" runat="server" Text='<%# Bind("CheckDetail") %>'></asp:TextBox>
                            </FooterTemplate>
                            <FooterStyle Width="200px" />
                            <ItemStyle Width="200px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="检查方法" SortExpression="CheckMethod">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlCheckMethod" runat="server">
                                </asp:DropDownList>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCheckMethod" runat="server" Text='<%# Bind("CheckMethod") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddlCheckMethod" runat="server">
                                </asp:DropDownList>
                            </FooterTemplate>
                             <FooterStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="规定尺寸、高度" SortExpression="SpecifiedSizeHeight">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtSpecifiedSizeHeight" runat="server" Text='<%# Bind("SpecifiedSizeHeight") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblSpecifiedSizeHeight" runat="server" Text='<%# Bind("SpecifiedSizeHeight") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtSpecifiedSizeHeight" runat="server" Text='<%# Bind("SpecifiedSizeHeight") %>'></asp:TextBox>
                            </FooterTemplate>
                             <FooterStyle Width="100px" />
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="打点位置" SortExpression="KnockPosition">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtKnockPosition" runat="server" Text='<%# Bind("KnockPosition") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblKnockPosition" runat="server" Text='<%# Bind("KnockPosition") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtKnockPosition" runat="server" Text='<%# Bind("KnockPosition") %>'></asp:TextBox>
                            </FooterTemplate>
                             <FooterStyle Width="80px" />
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Edit" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                                <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Delete" AlternateText="删除" ImageUrl="~/images/delete.gif" />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ID="btnSave" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Save" AlternateText="删除" ImageUrl="~/images/delete.gif" />
                                <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" AlternateText="取消"
                                    ImageUrl="~/images/delete.gif" />
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" CommandName="Add" AlternateText="增加"
                                    ImageUrl="~/images/icon-checked.gif" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                    </EmptyDataTemplate>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
