<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewScores.aspx.cs" Inherits="ViewScores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="Search" CssClass="content">
		<div class="search">
			<asp:Label ID="Label1" runat="server" Text="MemberId" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="MemberSelection" runat="server" CssClass="input-lg"></asp:TextBox><br />
			<asp:Label ID="Label2" runat="server" Text="Date" CssClass="col-form-label-sm"></asp:Label>
			<asp:Calendar ID="DatePicker" runat="server" CssClass="calendar"></asp:Calendar>
			<asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CssClass="btn-primary" />
			<br />
		</div>
		<div class="results">
			<asp:Repeater ID="TeeTimesTable" runat="server" ItemType="Handicap">
				<HeaderTemplate>
					<asp:Label runat="server" Text="DatePlayed" CssClass="col-form-label-sm row" Width="175px"></asp:Label>
					<asp:Label runat="server" Text="Handicap" CssClass="col-form-label-sm row" Width="75px"></asp:Label>
					 <br />
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Label runat="server" CssClass="col-form-label-sm row" Width="175px"
						Text="<%#Item.DatePlayed %>"></asp:Label>
					<asp:Label runat="server" CssClass="col-form-label-sm row" Width="75px"
						Text="<%#Item.PlayerHandicap %>"></asp:Label><br />
				</ItemTemplate>
			</asp:Repeater>
			<asp:Label ID="Message" runat="server" Text="" CssClass="col-form-label-lg"></asp:Label>
		</div>
	</asp:Panel>
</asp:Content>

