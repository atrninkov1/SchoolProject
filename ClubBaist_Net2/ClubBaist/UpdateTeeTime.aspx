<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateTeeTime.aspx.cs" Inherits="UpdateTeeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="Search" CssClass="content">
		<div class="search">
			<asp:Label ID="Label1" runat="server" Text="MemberId" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="MemberSelection" runat="server" DataTextField="FirstName" DataValueField="MemberID"></asp:TextBox>
			<asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" /><br />
			<asp:Label ID="MemberID" runat="server" Enabled="false" Visible="false"></asp:Label>
			<asp:Label ID="Message" runat="server" Text=""></asp:Label>
		</div>
		<br />
		<div class="results">
			<asp:Label ID="Label2" runat="server" Text="New number of carts" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="carts" runat="server" Text=""></asp:TextBox><br />
			<asp:Repeater ID="TeeTimesTable" runat="server" ItemType="TeeTime">
				<HeaderTemplate>
					<asp:Label runat="server"
						Text="Scheduled time" Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text="Number of carts" Width="150px" CssClass="col-form-label-sm row" ></asp:Label>
				</HeaderTemplate>
				<ItemTemplate>
					<asp:Panel runat="server" DefaultButton="Cancel">
						<asp:Label runat="server"
							Text="<%# Item.ScheduledTime %>"  Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
						<asp:Label runat="server"
							Text="<%# Item.Carts %>"  Width="150px" CssClass="col-form-label-sm row" ></asp:Label>
						<asp:Button ID="Cancel" runat="server" CommandArgument="<%#Item.TeeTimeID %>" Text="Book carts" OnCommand="Cancel_Command" />
						<br />
					</asp:Panel>
				</ItemTemplate>
			</asp:Repeater>
		</div>
	</asp:Panel>
</asp:Content>

