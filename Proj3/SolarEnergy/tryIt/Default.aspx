<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tryIt._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

	<div class="jumbotron">
        <h1>Solar Intensity</h1>
    	<asp:Panel ID="Panel1" runat="server" Font-Size="15pt">
			Insert longitude and latitude to retrieve UV index</asp:Panel>
    	<asp:Panel ID="Panel2" runat="server" Font-Size="10pt">
			URL of the Service:<br /> Method: decimal SolarIntensity(decimal,decimal)<br /> Input: two decimal types (latitude,longitude)<br /> Output: decimal type (index)</asp:Panel>
		<br />
		<br />
    	<asp:Label ID="Label1" runat="server" Font-Size="12pt" Text="Latitude"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtLat" runat="server" Height="28px" Width="249px"></asp:TextBox>
		&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
&nbsp;<br />
		<br />
		<asp:Label ID="Label2" runat="server" Font-Size="12pt" Text="Longitude"></asp:Label>
&nbsp;&nbsp;&nbsp;
		<asp:TextBox ID="txtLon" runat="server" Width="249px" Height="28px" OnTextChanged="TextChanged"></asp:TextBox>
		<br />
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Button ID="btnIndex" runat="server" Font-Size="12pt" Height="38px" OnClick="btnIndex_Click" Text="Get Index" Width="153px" />
		<br />
		<a href="Bundle.config">Bundle.config</a>
		<br />
		<asp:Label ID="Label3" runat="server" Text="UV Index" Font-Size="12pt"></asp:Label>
		&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<asp:Label ID="lblIndex" runat="server" Font-Size="12pt" Text="index"></asp:Label>
		<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>

    </asp:Content>
