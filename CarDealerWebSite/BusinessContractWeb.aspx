<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusinessContractWeb.aspx.cs" Inherits="BusinessContractWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    Create Business Leasing</p>
    <p>
        <asp:RadioButton ID="rbSCSQL" runat="server" GroupName="BCsave" Text="SQL" />
        <asp:RadioButton ID="rbSCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
&nbsp;
        <asp:Button ID="btnLoad" runat="server" onclick="btnLoad_Click" Text="Load" />
    </p>
<p>
    Select Name</p>
<p>
    <asp:DropDownList ID="DDBCName" runat="server">
    </asp:DropDownList>
</p>
<p>
    Select Vehicle</p>
<p>
    <asp:DropDownList ID="DDBCVechicle" runat="server">
    </asp:DropDownList>
</p>
<p>
    Select Status</p>
<p>
    <asp:DropDownList ID="DDBCStatus" runat="server">
    </asp:DropDownList>
</p>
<p>
    Rent per Month&nbsp;&nbsp;
    <asp:TextBox ID="BxBCRentprMonth" runat="server"></asp:TextBox>
</p>
<p>
    Rent Period (in month)
    <asp:TextBox ID="BxBCRentPeriod" runat="server"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnBCCreate" runat="server" OnClick="btnBCCreate_Click" Text="Create Leasing" />
</p>
    <p>
        <asp:Button ID="btnBCShow" runat="server" OnClick="btnBCShow_Click" Text="Show Leasing" />
</p>
<p>
        <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
            TextMode="MultiLine" Width="863px"></asp:TextBox>
</p>
<p>
        &nbsp;</p>
</asp:Content>

