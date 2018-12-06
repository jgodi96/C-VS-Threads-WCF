<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tryItWord._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>WordFilter</h1>
        <p class="lead">Filter out unimportant words</p>
    	<asp:Panel ID="Panel1" runat="server" Font-Size="10pt">
			URL of the Service:<br /> Method: string WordFilter(str)<br /> Input: single string<br /> Ouput:single string</asp:Panel>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Type in a word phrase</h2>
        </div>
        <div class="col-md-4">
            <h2>
				<asp:TextBox ID="txtWord" runat="server" Height="30px" Width="565px" Font-Size="12pt"></asp:TextBox>
			</h2>
			<p>
				<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filter" Width="119px" />
			</p>
        </div>
        <div class="col-md-4">
            <h2>WordFilter</h2>
			<p>
				<asp:TextBox ID="txtFilter" runat="server" Height="30px" OnTextChanged="TextChanged" Width="561px" Font-Size="12pt"></asp:TextBox>
			</p>
        </div>
    </div>

</asp:Content>
