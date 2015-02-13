<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LargeCarWeb.aspx.cs" Inherits="LargeCarWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <strong>Add Large Car</strong></p>
<p>
    Model&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxLCModel" runat="server"></asp:TextBox>
</p>
<p>
    Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxLCPrice" runat="server"></asp:TextBox>
</p>
<p>
    Color&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxLCColor" runat="server"></asp:TextBox>
</p>
<p>
    Capacity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxLCCapacity" runat="server"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:RadioButton ID="rbSCSQL" runat="server" GroupName="BCsave" Text="SQL" />
        <asp:RadioButton ID="rbSCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
</p>
    <p>
        <asp:Button ID="btnSCCreate" runat="server" OnClick="btnSCCreate_Click" Text="Add Large Car" />
</p>
    <p>
        &nbsp;<asp:Button ID="btnSCShow" runat="server" OnClick="btnBCShow_Click" Text="Show Large Cars" />
</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
            TextMode="MultiLine" Width="863px"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
</asp:Content>

