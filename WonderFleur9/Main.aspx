<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WonderFleur9.Default" MasterPageFile="MasterPage.Master" Title="Питомник британских кошек WonderFleur*Ru" EnableViewStateMac="False" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register src="Controls/UserContext.ascx" tagname="UserContext" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <uc1:UserContext ID="UserContext1" runat="server" ContextId="1"/>
</asp:Content>


