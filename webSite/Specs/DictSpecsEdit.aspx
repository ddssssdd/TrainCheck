<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="DictSpecsEdit.aspx.cs" Inherits="Specs_DictSpecsEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="panDetail" runat="server" SkinID="PanelEdit">
        <table width="800px">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="部位" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="txtSection" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblSection" runat="server" SkinID="field_value" />
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="顺序" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtSequence" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblSequence" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="检查部位" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="txtCheckPosition" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblCheckPosition" runat="server" SkinID="field_value" />
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="检查方法" SkinID="field_title" />
                </td>
                <td>
                    <asp:DropDownList ID="txtCheckMethod" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblCheckMethod" runat="server" SkinID="field_value" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="条码" SkinID="field_title" />
                </td>
                <td>
                    <asp:TextBox ID="txtBarCode" runat="server" Width="200px" Visible="false" />
                    <asp:Label ID="lblBarCode" runat="server" SkinID="field_value" />
                </td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="全面检查" SkinID="field_title" />
                </td>
                <td>
                    <asp:CheckBox ID="chkIsFull" runat="server" Width="200px" />
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="grdItems" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        Width="100%" OnRowCommand="grdItems_RowCommand" OnRowCreated="grdItems_RowCreated"
                        OnRowDeleting="grdItems_RowDeleting" OnRowEditing="grdItems_RowEditing" OnRowUpdating="grdItems_RowUpdating"
                        OnRowCancelingEdit="grdItems_RowCancelingEdit" OnRowDataBound="grdItems_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="检查处所" SortExpression="CheckDetail">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCheckDetail" runat="server" Text='<%# Bind("CheckDetail") %>'
                                        Width="180px"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckDetail" runat="server" Text='<%# Bind("CheckDetail") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCheckDetail" runat="server" Width="180px"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle Width="200px" />
                                <ItemStyle Width="200px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="检查方法" SortExpression="CheckMethod">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="ddlCheckMethod" runat="server" SelectedValue='<%# Bind("CheckMethod") %>'
                                        DataSource='<%# AppHelper.CheckMethodList %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCheckMethod" runat="server" Text='<%# Bind("CheckMethod") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:DropDownList ID="ddlCheckMethod" runat="server" DataSource='<%# AppHelper.CheckMethodList %>'>
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
                                    <asp:TextBox ID="txtSpecifiedSizeHeight" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtKnockPosition" runat="server"></asp:TextBox>
                                </FooterTemplate>
                                <FooterStyle Width="80px" />
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="全面检查" SortExpression="IsFull">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkIsFull" runat="server" Checked='<%# Bind("IsFull") %>'></asp:CheckBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkIsFull" runat="server" Checked='<%# Bind("IsFull") %>'></asp:CheckBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                     <asp:CheckBox ID="chkIsFull" runat="server" ></asp:CheckBox>
                                </FooterTemplate>
                                <FooterStyle Width="80px" />
                                <ItemStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle Width="60px" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Edit" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                                    <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Delete" AlternateText="删除" ImageUrl="~/images/delete.gif" OnClientClick="return confirm('请确认准备删除此项？');" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnSave" runat="server" CommandArgument='<%# Bind("ID") %>'
                                        CommandName="Save" AlternateText="存储" ImageUrl="~/images/save.gif" />
                                    <asp:ImageButton ID="btnCancel" runat="server" CommandName="Cancel" AlternateText="取消"
                                        ImageUrl="~/images/icon-cancel.gif" />
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
                    <%--<table>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtCheckDetail" runat="server" Width="180px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlCheckMethod" runat="server" DataSource='<%# AppHelper.CheckMethodList %>'>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtSpecifiedSizeHeight" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKnockPosition" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Add" AlternateText="增加"
                                            ImageUrl="~/images/icon-checked.gif" />
                                    </td>
                                </tr>
                            </table>--%>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="btnEdit" runat="server" Text="编辑" CommandName="edit" OnCommand="btnDetail_Command"
            SkinID="btnshort" />&nbsp
        <asp:Button ID="btnInsert" runat="server" Text="新增" CommandName="insert" OnCommand="btnDetail_Command"
            SkinID="btnshort" />&nbsp
        <asp:Button ID="btnUpdate" runat="server" Text="更新" CommandName="update" OnCommand="btnDetail_Command"
            SkinID="btnshort" />&nbsp
        <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="delete" OnCommand="btnDetail_Command"
            SkinID="btnshort" />&nbsp
        <asp:Button ID="btnCancel" runat="server" Text="取消" CommandName="cancel" OnCommand="btnDetail_Command"
            SkinID="btnshort" />&nbsp
    </asp:Panel>
</asp:Content>
