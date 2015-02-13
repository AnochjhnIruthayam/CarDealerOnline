<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MainPage.aspx.cs" Inherits="MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 1024px;
        height: 768px;
    }
        .style2
        {
            font-size: medium;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p class="auto-style1" style="text-align: center">
    <strong>Welcome to the Car Dealer Application - Web Edition</strong></p>
<p class="auto-style1" style="text-align: left; font-size: small">
    <span class="style2">by Anochjhn Iruthayam<br />
    6 Semester 2013 - Robotteknologi</span><br />
</p>
<p style="text-align: center">
    <img alt="" class="style1" src="carimage.jpg" title="LIKE A BOSS" /></p>
</asp:Content>

