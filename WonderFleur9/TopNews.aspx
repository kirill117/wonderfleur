<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TopNews.aspx.cs" Inherits="WonderFleur9.TopNews" Title="Питомник британских кошек WonderFleur*Ru - Новости" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxNewsControl" tagprefix="dxnc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True" 
        Font-Names="Times New Roman,Georgia" Font-Size="18pt" ForeColor="#993333"></asp:Label>
    <br />
    <br />
    <asp:PlaceHolder ID="phContent" runat="server"></asp:PlaceHolder>
</div>
</asp:Content>
