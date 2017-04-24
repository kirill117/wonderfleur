<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContextPage.aspx.cs" Inherits="WonderFleur9.ContextPage" Title="Питомник британских кошек WonderFleur*Ru" %>
<%@ Register src="Controls/UserContext.ascx" tagname="UserContext" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UserContext ID="UserContext1" runat="server" />
</asp:Content>

