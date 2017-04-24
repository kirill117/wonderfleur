<%@ Page language="c#" Codebehind="Calendar.aspx.cs" AutoEventWireup="True" Inherits="WonderFleur9.PopupCalendarForm" %>
<HTML>
	<HEAD>
		<title>Календарь</title>
		<meta http-equiv="Content-Type" content="text/html">
	</HEAD>
	<body bgcolor="#dadada" vlink="#993300" alink="#993300" link="#993300">
		<form id="Form1" runat="server">
			<div align="center">
				<table border="0" width="250" cellpadding="0" cellspacing="0">
					<tr>
						<td align="left">
							<asp:DropDownList ID="year" Runat="server" Font-Size="10px" AutoPostBack="True" onselectedindexchanged="year_SelectedIndexChanged" />
						</td>
						<td align="right">
							<asp:DropDownList ID="month" Runat="server" Font-Size="10px" AutoPostBack="True" onselectedindexchanged="month_SelectedIndexChanged" />
						</td>
					</tr>
				</table>
				<asp:calendar id="cal" runat="server" backcolor="#ffffff" width="250px" height="200px" font-size="12px"
					font-names="Arial" borderwidth="2px" bordercolor="#9fb2c1" nextprevformat="FullMonth" daynameformat="Short" onselectionchanged="cal_SelectionChanged">
					<TodayDayStyle ForeColor="White" BackColor="#9fb2c1"></TodayDayStyle>
					<NextPrevStyle Font-Size="12px" Font-Bold="True" ForeColor="#993300"></NextPrevStyle>
					<DayHeaderStyle Font-Size="12px" Font-Bold="True"></DayHeaderStyle>
					<TitleStyle Font-Size="14px" Font-Bold="True" BorderWidth="2px" ForeColor="#000055"></TitleStyle>
					<OtherMonthDayStyle ForeColor="#CCCCCC"></OtherMonthDayStyle>
				</asp:calendar>
			</div>
		</form>
	</body>
</HTML>
