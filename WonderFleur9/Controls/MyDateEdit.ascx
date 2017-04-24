<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyDateEdit.ascx.cs" Inherits="WonderFleur9.Controls.MyDateEdit" %>
<script language="javascript">
	function popup<%=this.ClientID%>() {
		var w=280; var h=250; var l=(screen.width-w)/2; var t=(screen.height-h)/2-40;
		var val=document.getElementById('<%=DateEdit1.ClientID%>').value;
		newWindow = window.open('/Controls/Forms/Calendar.aspx?ctl=<%=DateEdit1.ClientID%>&val="'+val+'"',null,'height='+h+',width='+w+',left='+l+',top='+t+',status=no,toolbar=no,menubar=no,location=no,scrollbars=no');
		newWindow.focus();
	}
</script>

<div>
	<table cellspacing="1">
        <tr>
            <td>
            	<asp:TextBox ID="DateEdit1" Runat="server" Width="75px" />
            </td>
            <td>
            	<a href="javascript:popup<%=this.ClientID%>();"><img src="/images/calendar.png" border="0" hspace="0"></a>
            </td>
        </tr>
    </table>
</div>
