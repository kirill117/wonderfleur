<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Persons.aspx.cs" Inherits="WonderFleur9.Persons" Title="Питомник британских кошек WonderFleur*Ru - Питомцы" %>

<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Italic="True" 
            Font-Names="Georgia" Font-Size="16pt" ForeColor="#993333"></asp:Label>
    </div>
    <dxdv:ASPxDataView ID="list" runat="server" 
    onitemcommand="list_ItemCommand" EmptyDataText=" " ItemSpacing="10px" 
        onpageindexchanged="list_PageIndexChanged">
        <EmptyDataTemplate>
            <asp:ImageButton ID="cmdNew" runat="server" CommandName="Add" 
                ImageUrl="~/Images/plus.png" onclick="cmdNew_Click" 
                Visible = "<%# Custom.Settings.isAdmin %>" />
        </EmptyDataTemplate>
        <Border BorderStyle="None" />
    <ItemStyle HorizontalAlign="Center" Height="100%" VerticalAlign="Top" >
        <Paddings Padding="0px" />
        <Border BorderStyle="None" />
        </ItemStyle>
    <ItemTemplate>
        <table style="padding: 10px; border: 1px solid #C0C0C0; height: 100%; vertical-align: top;" 
            width="100%">
            <tr>
                <td align="center" valign="top">
                    <dxe:ASPxLabel ID="lbName" runat="server" 
                Text="ASPxLabel">
                    </dxe:ASPxLabel>
                    <asp:TextBox ID="tbName" runat="server" Visible="False" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" valign="top">
                    <dxe:ASPxButton ID="btn" runat="server" AllowFocus="False" ImagePosition="Top" 
                        EnableTheming="False">
                    </dxe:ASPxButton>
                </td>
            </tr>
            <tr>
                <td align="center" height="100%" valign="top">
                    <dxe:ASPxLabel ID="lbTitul" runat="server" 
                Text="ASPxLabel">
                    </dxe:ASPxLabel>
                    <asp:TextBox ID="tbTitul" runat="server" Visible="False" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                <table id="pnEdit" runat="server" Visible="False" align="center">
                    <tr align="center">
                        <td>
                            <dxe:ASPxButton ID="btnSave" runat="server" 
                                    CommandArgument='<%# Eval("Id") %>' CommandName="Save">
                                <Image Url="~/Images/disk.png" />
                            </dxe:ASPxButton>
                        </td>
                        <td>
                    <dxe:ASPxButton ID="btnDelete" runat="server" 
                                    CommandArgument='<%# Eval("Id") %>' CommandName="Delete" ToolTip="Удалить">
                        <Image Url="~/Images/delete.png" />
                    </dxe:ASPxButton>
                        </td>
                        <td>
                    <dxe:ASPxButton ID="btnUpload" runat="server" 
                                    CommandArgument='<%# Eval("Id") %>' CommandName="Upload" 
                                    ToolTip="Загрузить фото">
                        <Image Url="~/Images/download.png" />
                    </dxe:ASPxButton>
                        </td>
                        <td>
                    <dxe:ASPxButton ID="btnAdd" runat="server" 
                                    CommandArgument='<%# Eval("Id") %>' CommandName="Add" 
                                    ToolTip="Загрузить фото">
                        <Image Url="~/Images/add.png" />
                    </dxe:ASPxButton>
                        </td>
                    </tr>
                    <tr align="center" runat="server" id="pnUpload">
                        <td colspan="4">
                            <dxuc:ASPxUploadControl ID="Upload" runat="server" Width="100%">
                                <UploadButton Text="Загрузить">
                                </UploadButton>
                            </dxuc:ASPxUploadControl>
                        </td>
                    </tr>
                </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
        <Paddings PaddingTop="20px" />
        <PagerSettings>
            <Summary Visible="False" />
        </PagerSettings>
</dxdv:ASPxDataView>

</asp:Content>
