<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ScheduleTeeTime.aspx.cs" Inherits="ScheduleTeeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="Submit" CssClass="content">
		<div class="search">
			<asp:Calendar ID="DateSelection" runat="server" CssClass="glyphicon-calendar calendar"></asp:Calendar>
			<%--<asp:Button ID="GetAvailableTimes" runat="server" Text="Get available times" OnClick="GetAvailableTimes_Click" CssClass="btn-primary" />--%><br />
		</div>
		<div class="results">
			<asp:Label ID="Label1" runat="server" Text="Tee time time" CssClass="col-form-label-sm"></asp:Label>
			<asp:DropDownList ID="TimeSelection" runat="server" DataTextField="TimeOfDay" CssClass="dropdown"></asp:DropDownList><br />
			<asp:Label ID="Label2" runat="server" Text="Member id" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="Member" runat="server" CssClass="input-group-sm"></asp:TextBox><br />
			<asp:Label ID="Label3" runat="server" Text="Carts" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="Carts" runat="server" CssClass="input-group-sm"></asp:TextBox><br />
			<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" CssClass="btn-primary" /><br />
			<asp:Label ID="Message" runat="server" Text="" CssClass="col-form-label-lg"></asp:Label>
		</div>
	</asp:Panel>
</asp:Content>
