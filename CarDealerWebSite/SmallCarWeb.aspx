<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SmallCarWeb.aspx.cs" Inherits="SmallCarWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .auto-style3 {
        font-style: normal;
        font-weight: normal;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="auto-style3">
    <strong>Add Small Car</strong></p>
<p class="auto-style3">
    Model&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxSCModel" runat="server"></asp:TextBox>
</p>
<p class="auto-style3">
    Price&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxSCPrice" runat="server"></asp:TextBox>
</p>
<p class="auto-style3">
    Color&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxSCColor" runat="server"></asp:TextBox>
</p>
<p class="auto-style3">
    Weight&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxSCWeight" runat="server"></asp:TextBox>
</p>
<span class="auto-style3">&nbsp;</span>
    <asp:RadioButton ID="rbSCSQL" runat="server" GroupName="BCsave" Text="SQL" />
    <asp:RadioButton ID="rbSCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
    <br />
    <asp:Button ID="btnSCCreate" runat="server" OnClick="btnSCCreate_Click" Text="Add Small Car" />
    <br />
    <br />
    <asp:Button ID="btnSCShow" runat="server" OnClick="btnBCShow_Click" Text="Show Small Cars" />
    <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
        TextMode="MultiLine" Width="863px"></asp:TextBox>
</asp:Content>

