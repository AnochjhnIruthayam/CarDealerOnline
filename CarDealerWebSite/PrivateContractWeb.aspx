<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrivateContractWeb.aspx.cs" Inherits="PrivateContractWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
    Create Private Contract</p>
    <p>
        <asp:RadioButton ID="rbSCSQL" runat="server" GroupName="BCsave" Text="SQL" />
        <asp:RadioButton ID="rbSCLocalDisk" runat="server" GroupName="BCsave" Text="Local Disk" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLoad" runat="server" onclick="btnLoad_Click" Text="Load" />
    </p>
<p>
    Select Name</p>
<p>
    <asp:DropDownList ID="DDPCName" runat="server">
    </asp:DropDownList>
</p>
<p>
    Select Vehicle</p>
<p>
    <asp:DropDownList ID="DDPCVehicle" runat="server">
    </asp:DropDownList>
</p>
<p>
    Select Status</p>
<p>
    <asp:DropDownList ID="DDPCStatus" runat="server">
    </asp:DropDownList>
&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnBCCreate" runat="server" OnClick="btnBCCreate_Click" Text="Create Contract" />
</p>
    <p>
        <asp:Button ID="btnBCShow" runat="server" OnClick="btnBCShow_Click" Text="Show Contracts" />
</p>
    <p>
        <asp:TextBox ID="TextBox1" runat="server" Height="291px" ReadOnly="True" 
            TextMode="MultiLine" Width="863px"></asp:TextBox>
</p>
</asp:Content>

