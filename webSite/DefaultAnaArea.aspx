<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DefaultAnaArea.aspx.cs" Inherits="DefaultAnaArea" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<script language="javascript">
    J(function(){
    J('#ctl00_ContentPlaceHolder1_txtBegin').calendar();
    J('#ctl00_ContentPlaceHolder1_txtEnd').calendar();
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server">开始日期</asp:Label>
                <asp:TextBox ID="txtBegin" runat="server"></asp:TextBox>
                
            </td>
            <td>
                <asp:Label ID="label2" runat="server">结束日期</asp:Label>
                <asp:TextBox ID="txtEnd" runat="server" ></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" Width="104px" />
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grdMain" runat="server"  AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField SortExpression="Area" HeaderText="供电段">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:HyperLink ID="hlinkArea" runat="server" NavigateUrl='<%# "DefaultAnaFactory.aspx?area="+Eval("Area") %>'>
                        <asp:Label runat="server" Text='<%# Bind("Area") %>' ID="lblArea" SkinID="" />
                    </asp:HyperLink></ItemTemplate></asp:TemplateField><asp:TemplateField SortExpression="CheckPosition" HeaderText="检查点">
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
            <asp:TemplateField SortExpression="FailurePosition" HeaderText="待检总数">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("AreaNo") %>' ID="lblTrainCode" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <asp:Chart ID="Chart3" runat="server" Palette="Bright" Width="1024px">
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
            <asp:Legend Name="Legend2">
            </asp:Legend>
            <asp:Legend Name="Legend3">
            </asp:Legend>
        </Legends>
        <Series>
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="检查总数">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="通过总数">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="待检总数">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Inclination="15" Rotation="0" /></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <br />
</asp:Content>

