<%@ Page Title="" Language="C#" MasterPageFile="~/Common/Edit.master" AutoEventWireup="true" CodeFile="DictSpecsList.aspx.cs" Inherits="DictSpecsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="grdSpecs" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" 
        EmptyDataText="There are no data records to display." 
        onrowcommand="grdSpecs_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                      <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Bind("ID") %>'
                                    CommandName="Edit" AlternateText="编辑" ImageUrl="~/images/editicon.gif" />
                </ItemTemplate>
            </asp:TemplateField>         
            <asp:TemplateField HeaderText="部位" SortExpression="Section">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Section") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Section") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="顺序" SortExpression="Sequence">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sequence") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sequence") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="检查部位" SortExpression="CheckPosition">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CheckPosition") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("CheckPosition") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="检查处所" SortExpression="CheckMethod">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("CheckMethod") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("CheckMethod") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编码" SortExpression="BarCode">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("BarCode") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("BarCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>  

</asp:Content>

