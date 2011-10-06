<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome to this site!</h1>
    </div>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" 
        EmptyDataText="There are no data records to display.">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="UserNo" HeaderText="UserNo" 
                SortExpression="UserNo" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Department" HeaderText="Department" 
                SortExpression="Department" />
            <asp:BoundField DataField="Password" HeaderText="Password" 
                SortExpression="Password" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" />
            <asp:BoundField DataField="ExpirtationDate" HeaderText="ExpirtationDate" 
                SortExpression="ExpirtationDate" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Default %>" 
        DeleteCommand="DELETE FROM [Users] WHERE [ID] = @ID" 
        InsertCommand="INSERT INTO [Users] ([UserName], [UserNo], [Name], [Department], [Password], [IsActive], [ExpirtationDate]) VALUES (@UserName, @UserNo, @Name, @Department, @Password, @IsActive, @ExpirtationDate)" 
        ProviderName="<%$ ConnectionStrings:Default.ProviderName %>" 
        SelectCommand="SELECT [ID], [UserName], [UserNo], [Name], [Department], [Password], [IsActive], [ExpirtationDate] FROM [Users]" 
        UpdateCommand="UPDATE [Users] SET [UserName] = @UserName, [UserNo] = @UserNo, [Name] = @Name, [Department] = @Department, [Password] = @Password, [IsActive] = @IsActive, [ExpirtationDate] = @ExpirtationDate WHERE [ID] = @ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="UserNo" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="ExpirtationDate" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="UserName" Type="String" />
            <asp:Parameter Name="UserNo" Type="String" />
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Department" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="IsActive" Type="Boolean" />
            <asp:Parameter Name="ExpirtationDate" Type="DateTime" />
            <asp:Parameter Name="ID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataKeyNames="ID" DataSourceID="SqlDataSource1" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
            <asp:BoundField DataField="UserNo" HeaderText="UserNo" 
                SortExpression="UserNo" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Department" HeaderText="Department" 
                SortExpression="Department" />
            <asp:BoundField DataField="Password" HeaderText="Password" 
                SortExpression="Password" />
            <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" 
                SortExpression="IsActive" />
            <asp:BoundField DataField="ExpirtationDate" HeaderText="ExpirtationDate" 
                SortExpression="ExpirtationDate" />
            <asp:CommandField ShowEditButton="True" ShowInsertButton="True" />
        </Fields>
    </asp:DetailsView>
    </form>
</body>
</html>
