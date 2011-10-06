<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="chart_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Chart ID="Chart1" runat="server">
    <Legends>
        <asp:Legend Name="Legend1">
        </asp:Legend>
    </Legends>
    <Series>
        <asp:Series ChartType="Pie" Name="Series1" IsValueShownAsLabel="True" 
            IsXValueIndexed="True" Legend="Legend1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <Area3DStyle Enable3D="True" />
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
<asp:Chart ID="Chart2" runat="server" Palette="SemiTransparent">
    <Legends>
        <asp:Legend Name="Legend1">
        </asp:Legend>
    </Legends>
    <Series>
        <asp:Series ChartType="Pie" Name="Series1" IsValueShownAsLabel="True" 
            Legend="Legend1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <Area3DStyle Enable3D="True" />
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
<asp:Chart ID="Chart3" runat="server" Palette="Bright">
    <Legends>
        <asp:Legend Name="Legend1">
        </asp:Legend>
    </Legends>
    <Series>
        <asp:Series ChartType="Pie" Name="Series1" IsValueShownAsLabel="True" 
            Legend="Legend1">
        </asp:Series>
    </Series>
    <ChartAreas>
        <asp:ChartArea Name="ChartArea1">
            <Area3DStyle Enable3D="True" />
        </asp:ChartArea>
    </ChartAreas>
</asp:Chart>
</asp:Content>

