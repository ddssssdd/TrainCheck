<%@ Page Title="" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

<script language="javascript">
        J(function() {
        J('#ctl00_ContentPlaceHolder1_txtBegin').calendar();
        J('#ctl00_ContentPlaceHolder1_txtEnd').calendar();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="label1" runat="server">��ʼ����</asp:Label>
                <asp:TextBox ID="txtBegin" runat="server" SkinID="txt_dateselect"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="label2" runat="server">��������</asp:Label>
                <asp:TextBox ID="txtEnd" runat="server" class="txt_dateselect"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="��ѯ" OnClick="btnSearch_Click" Width="104px" />
            </td>
            <td>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grdMain" runat="server"  AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField SortExpression="Area" HeaderText="�����">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Area") %>' ID="lblArea" SkinID="" />
                    
                 </ItemTemplate>
                 </asp:TemplateField>
            <asp:TemplateField SortExpression="Factory" HeaderText="���糵��">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Factory") %>' ID="lblFactory" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="Section" HeaderText="����">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("Section") %>' ID="lblSection" SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="CheckPosition" HeaderText="����">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("CheckPosition") %>' ID="lblCheckPosition"
                        SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="PassPosition" HeaderText="ͨ����">
                <ItemStyle Width="100px" />
                <ItemTemplate>
                    <asp:Label runat="server" Text='<%# Bind("PassPosition") %>' ID="lblPassPosition"
                        SkinID="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField SortExpression="FailurePosition" HeaderText="Ӧ������">
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
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="�������">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="ͨ������">
            </asp:Series>
            <asp:Series ChartArea="ChartArea1" IsValueShownAsLabel="True" Legend="Legend1" Name="Ӧ������">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
                <Area3DStyle Inclination="15" Rotation="45" />
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <table Width="1024px"><tr><td align="center">�Ӵ���Ѳ��ͼʾ</td></tr></table><br />
    <br />
</asp:Content>
