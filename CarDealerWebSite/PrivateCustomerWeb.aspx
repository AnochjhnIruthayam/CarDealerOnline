<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrivateCustomerWeb.aspx.cs" Inherits="PrivateCustomerWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    <strong>Add New Customer:</strong></p>
    <p style="width: 300px">
        <strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong></p>
<p>
    Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxPCName" runat="server"></asp:TextBox>
</p>
<p>
    Address&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxPCAddress" runat="server"></asp:TextBox>
</p>
<p>
    Phone&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxPCPhone" runat="server" OnTextChanged="BxPCPhone_TextChanged"></asp:TextBox>
</p>
<p>
    Age&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxPCAge" runat="server"></asp:TextBox>
</p>
<p>
    Sex&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="BxPCSex" runat="server"></asp:TextBox>
</p>
    <p>
        <asp:RadioButton ID="rbSQL" runat="server" GroupName="rbPersist" Text="Select SQL" />
        <asp:RadioButton ID="rbLocalDisk" runat="server" GroupName="rbPersist" Text="Select Local Disk" />
    </p>
    <asp:Button ID="btnPCCreatePC" runat="server" OnClick="btnPCCreatePC_Click" Text="Create Customer" />
    <br />
<br />
<asp:Button ID="btnPCShow" runat="server" OnClick="btnPCShow_Click" Text="Show Customers" />
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
            TextMode="MultiLine" Width="863px"></asp:TextBox>
</p>
</asp:Content>

