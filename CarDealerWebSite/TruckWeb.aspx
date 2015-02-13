<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TruckWeb.aspx.cs" Inherits="TruckWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <strong>Add Truck</strong></p>
<p>
    Model&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxTModel" runat="server"></asp:TextBox>
</p>
<p>
    Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxTPrice" runat="server"></asp:TextBox>
</p>
<p>
    Color&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxTColor" runat="server"></asp:TextBox>
</p>
<p>
    Capacity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxTCapacity" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:RadioButton ID="rbSCSQL" runat="server" GroupName="BCsave" Text="SQL" />
        <asp:RadioButton ID="rbSCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
</p>
    <p>
        <asp:Button ID="btnSCCreate" runat="server" OnClick="btnSCCreate_Click" Text="Add Truck" />
</p>
    <p>
        <asp:Button ID="btnSCShow" runat="server" OnClick="btnSCShow_Click" Text="Show Trucks" />
</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
            TextMode="MultiLine" Width="863px"></asp:TextBox>
</p>
</asp:Content>

