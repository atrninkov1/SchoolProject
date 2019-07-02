<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddPlayerScore.aspx.cs" Inherits="AddPlayerScore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<asp:Panel runat="server" DefaultButton="AddScore" CssClass="content">
		<asp:Label ID="MemberLabel" runat="server" Text="Member"></asp:Label>
		<asp:TextBox ID="MemberTextBox" runat="server"></asp:TextBox><br />
		<asp:Label ID="DatePlayed" runat="server" Text="DatePlayed"></asp:Label>
		<asp:Calendar ID="DatePicker" runat="server" CssClass="calendar"></asp:Calendar>
		<br />
		<asp:Label ID="HoleLabel1" runat="server" Text="Hole 1"></asp:Label>
		<asp:TextBox ID="HoleTextBox1" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel2" runat="server" Text="Hole 2"></asp:Label>
		<asp:TextBox ID="HoleTextBox2" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel3" runat="server" Text="Hole 3"></asp:Label>
		<asp:TextBox ID="HoleTextBox3" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel4" runat="server" Text="Hole 4"></asp:Label>
		<asp:TextBox ID="HoleTextBox4" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel5" runat="server" Text="Hole 5"></asp:Label>
		<asp:TextBox ID="HoleTextBox5" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel6" runat="server" Text="Hole 6"></asp:Label>
		<asp:TextBox ID="HoleTextBox6" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel7" runat="server" Text="Hole 7"></asp:Label>
		<asp:TextBox ID="HoleTextBox7" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel8" runat="server" Text="Hole 8"></asp:Label>
		<asp:TextBox ID="HoleTextBox8" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel9" runat="server" Text="Hole 9"></asp:Label>
		<asp:TextBox ID="HoleTextBox9" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel10" runat="server" Text="Hole 10"></asp:Label>
		<asp:TextBox ID="HoleTextBox10" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel11" runat="server" Text="Hole 11"></asp:Label>
		<asp:TextBox ID="HoleTextBox11" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel12" runat="server" Text="Hole 12"></asp:Label>
		<asp:TextBox ID="HoleTextBox12" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel13" runat="server" Text="Hole 13"></asp:Label>
		<asp:TextBox ID="HoleTextBox13" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel14" runat="server" Text="Hole 14"></asp:Label>
		<asp:TextBox ID="HoleTextBox14" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel15" runat="server" Text="Hole 15"></asp:Label>
		<asp:TextBox ID="HoleTextBox15" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel16" runat="server" Text="Hole 16"></asp:Label>
		<asp:TextBox ID="HoleTextBox16" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel17" runat="server" Text="Hole 17"></asp:Label>
		<asp:TextBox ID="HoleTextBox17" runat="server"></asp:TextBox><br />
		<asp:Label ID="HoleLabel18" runat="server" Text="Hole 18"></asp:Label>
		<asp:TextBox ID="HoleTextBox18" runat="server"></asp:TextBox><br />
		<asp:Button ID="AddScore" runat="server" Text="Add score" OnClick="AddScore_Click" />
		<br />
		<asp:Label ID="MSG" runat="server" Text=""></asp:Label>
	</asp:Panel>
</asp:Content>

