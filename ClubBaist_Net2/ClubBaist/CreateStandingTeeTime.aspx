<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateStandingTeeTime.aspx.cs" Inherits="CreateStandingTeeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="Submit" CssClass="content">
		<asp:Label runat="server" Text="Day of week"></asp:Label>
		<asp:Calendar ID="DayOfWeek" runat="server" CssClass="glyphicon-calendar calendar"></asp:Calendar>
		<asp:Label runat="server" Text="Time of Day"></asp:Label>
		<asp:DropDownList ID="TimeOfDay" runat="server" DataTextField="TimeOfDay" CssClass="dropdown"></asp:DropDownList><br />
		<asp:Label ID="StartDate" runat="server" Text="Start date" CssClass="col-form-label"></asp:Label>
		<asp:TextBox ID="StartDateTextBox" runat="server" CssClass="input-group-sm"></asp:TextBox><br />
		<asp:Label ID="EndDateLabel" runat="server" Text="End date" CssClass="col-form-label"></asp:Label>
		<asp:TextBox ID="EndDateTextBox" runat="server" CssClass="input-group-sm"></asp:TextBox><br />
		<asp:Label ID="Member1IDLabel" runat="server" Text="Member 1 ID" CssClass="col-form-label"></asp:Label>
		<asp:TextBox ID="Member1IDTextBox" runat="server" CssClass="input-group-sm"></asp:TextBox><br />
		<asp:Button ID="Submit" runat="server" Text="Create standing tee time" OnClick="Submit_Click" />
		<asp:Label ID="Message" runat="server" Text=""></asp:Label>
	</asp:Panel>
</asp:Content>
