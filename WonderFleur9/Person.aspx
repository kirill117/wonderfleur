<%@ Page Title="Питомник британских кошек WonderFleur*Ru" Language="C#" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="WonderFleur9.Person" MasterPageFile="MasterPage.Master" %>

<%@ Register src="Controls/PersonCart.ascx" tagname="PersonCart" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:PersonCart ID="PersonCart1" runat="server" />
</asp:Content>

