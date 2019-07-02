<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApproveStandingTeeTime.aspx.cs" Inherits="ApproveStandingTeeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="ApproveButton" CssClass="content">
		<asp:Repeater ID="teeTimeRequests" runat="server" ItemType="StandingTeeTime">
			<HeaderTemplate>
					<asp:Label runat="server"
						Text="ID" Width="50px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text="StartDate" Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text="EndDate" Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text="TeeTimeTime" Width="100px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text="Approved" Width="75px" CssClass="col-form-label-sm row" ></asp:Label><br />

			</HeaderTemplate>
			<ItemTemplate>
				<asp:Label runat="server"
						Text='<%#Eval("StandingTeeTimeID") %>' Width="50px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text='<%#Eval("StartDate") %>' Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text='<%#Eval("EndDate") %>' Width="175px" CssClass="col-form-label-sm row" ></asp:Label>
					<asp:Label runat="server"
						Text='<%#Item.TeeTimeTime.TimeOfDay %>' Width="100px" CssClass="col-form-label-sm row" ></asp:Label>
					
					<asp:CheckBox ID="Approved" runat="server" Checked='<%#Eval("Approved") %>' CssClass="" />
					<br />
			</ItemTemplate>
			<FooterTemplate>
			</FooterTemplate>
		</asp:Repeater>
		<asp:Button ID="ApproveButton" runat="server" Text="Approve" OnClick="ApproveButton_Click" CssClass="btn-primary" />
	</asp:Panel>
</asp:Content>
