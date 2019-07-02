<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Logon.aspx.cs" Inherits="Logon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="LogonButton" CssClass="content">
		<h3 class="col-form-label">Logon Page</h3>
		<asp:Label runat="server" Class="loginLabel" Text="Username:"></asp:Label>
		<asp:TextBox ID="Username" runat="server"></asp:TextBox>
		<asp:RequiredFieldValidator
			ID="RequiredFieldValidator1"
			runat="server"
			ErrorMessage="Username cannot be empty"
			ControlToValidate="Username"></asp:RequiredFieldValidator><br />
		<asp:Label runat="server" CssClass="loginLabel" Text="Password:"></asp:Label>
		<asp:TextBox ID="UserPassword" runat="server" ViewStateMode="Inherit" TextMode="Password" CssClass="input-group-sm"></asp:TextBox>
		<asp:RequiredFieldValidator
			ID="RequiredFieldValidator2"
			runat="server"
			ErrorMessage="Password cannot be empty"
			ControlToValidate="UserPassword"></asp:RequiredFieldValidator><br />
		<asp:Button ID="LogonButton" runat="server" Text="Log On" OnClick="Logon_Click" CssClass="btn-primary" />
		<asp:Label ID="Msg" runat="server" ForeColor="Red" CssClass="col-form-label-sm"></asp:Label><br />
	</asp:Panel>
</asp:Content>

