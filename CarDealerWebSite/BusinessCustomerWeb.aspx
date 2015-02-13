<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusinessCustomerWeb.aspx.cs" Inherits="BusinessCustomerWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <strong>Add Business Customer</strong></p>
<p>
    Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCName" runat="server"></asp:TextBox>
</p>
<p>
    Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCAddress" runat="server"></asp:TextBox>
</p>
<p>
    Phone&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCPhone" runat="server"></asp:TextBox>
</p>
<p>
    SE no.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCSE" runat="server"></asp:TextBox>
</p>
<p>
    Fax&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCFax" runat="server"></asp:TextBox>
</p>
<p>
    Contact Person&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxBCContactPerson" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:RadioButton ID="rbBCSQL" runat="server" GroupName="BCsave" Text="SQL" />
        <asp:RadioButton ID="rbBCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
</p>
    <p>
        <asp:Button ID="btnBCCreate" runat="server" OnClick="btnBCCreate_Click" Text="Create Customer" />
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnBCShow" runat="server" OnClick="btnBCShow_Click" Text="Show Customer" />
</p>
    <p>
        <asp:TextBox ID="TBShow" runat="server" Height="254px" ReadOnly="True" 
            TextMode="MultiLine" Width="683px"></asp:TextBox>
</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</asp:Content>

