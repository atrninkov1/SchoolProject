<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CancelTeeTime.aspx.cs" Inherits="CancelTeeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="Search" CssClass="content">
		<div class="search">
			<asp:Label ID="Label1" runat="server" Text="MemberId" CssClass="col-form-label-sm"></asp:Label>
			<asp:TextBox ID="MemberSelection" runat="server" CssClass="input-lg"></asp:TextBox>
			<asp:Button ID="Search" runat="server" Text="Search" OnClick="Search_Click" CssClass="btn-primary" />
			<br />
		</div>
		<asp:Repeater ID="TeeTimesTable" runat="server" ItemType="TeeTime">
			<HeaderTemplate>
					<asp:Label runat="server"
						Text="Scheduled time" Width="175px" CssClass="col-form-label-sm row" ></asp:Label><br />
				</HeaderTemplate>
			<ItemTemplate>
						<asp:Label runat="server"
							Text="<%# Item.ScheduledTime %>"  Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
				<asp:Button ID="Cancel" runat="server" Text="Cancel" CommandArgument="<%# Item.TeeTimeID %>" OnCommand="Cancel_Command" CssClass="btn-danger" /><br />
				<br />
			</ItemTemplate>
		</asp:Repeater>
		<asp:Label ID="Message" runat="server" Text="" CssClass="col-form-label-lg"></asp:Label>
	</asp:Panel>
</asp:Content>

