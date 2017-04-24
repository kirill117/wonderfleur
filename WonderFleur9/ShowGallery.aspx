<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowGallery.aspx.cs" Inherits="WonderFleur9.ShowGallery" MasterPageFile="~/MasterPage.Master" Title="Питомник британских кошек WonderFleur*Ru" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDataView" tagprefix="dxdv" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register src="Controls/TitleImage.ascx" tagname="TitleImage" tagprefix="uc1" %>
<%@ Register assembly="HighslideImage" namespace="Encosia" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript" src="Scripts/highslide-full.js"></script>
<link rel="stylesheet" type="text/css" href="Scripts/highslide.css" />

<script type="text/javascript">
    hs.graphicsDir = 'Scripts/graphics/';
    hs.align = 'center';
    hs.transitions = ['expand', 'crossfade'];
    hs.outlineType = 'rounded-white';
    hs.fadeInOut = true;
    hs.dimmingOpacity = 0.75;

    // define the restraining box
    hs.useBox = true;
    hs.width = 640;
    hs.height = 480;

    // Add the controlbar
    hs.addSlideshow({
        //slideshowGroup: 'group1',
        interval: 5000,
        repeat: false,
        useControls: true,
        fixedControls: 'fit',
        overlayOptions: {
            opacity: 1,
            position: 'bottom center',
            hideOnMouseOut: true
        }
    });

    function ShowUpload(cid) {
        var s = document.getElementById(cid);
        s.style.visibility = "visible";
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Text="Label" Font-Bold="False" 
            Font-Italic="True" Font-Names="Georgia,Times New Roman" Font-Size="18pt" 
            ForeColor="#993333"></asp:Label>
    </div>
    <br />
    <dxdv:ASPxDataView ID="list" runat="server" EmptyDataText=" " 
        onitemcommand="list_ItemCommand" EnableCallBacks="False" 
    onpageindexchanged="list_PageIndexChanged" ItemSpacing="10px">
        <EmptyDataTemplate>
            <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
                CommandName="Add" ImageUrl="~/Images/plus.png" ToolTip="Добавить" 
                onclick="cmdNew_Click" Visible="<%# Custom.Settings.isAdmin %>" />
        </EmptyDataTemplate>
        <ItemStyle HorizontalAlign="Center" Height="100%" >
        <Paddings Padding="0px" />
        <Border BorderStyle="None" />
        </ItemStyle>
        <ItemTemplate>
            <table align="center" 
                style="border: 1px solid #C0C0C0; padding: 10px; height: 100%" width="100%">
                <tr>
                    <td>
                        <div class="highslide-gallery" >
                            <dx:ASPxPanel ID="pnImage" runat="server">
                            </dx:ASPxPanel>
                        </div>                    
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label ID="lbComment" runat="server" Text="Label"></asp:Label>
                        <asp:TextBox ID="tbComment" runat="server" Visible="False" TextMode="MultiLine" 
                            Width="100%"></asp:TextBox>
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
                                    ToolTip="Загрузить фото" AutoPostBack="False">
                        <Image Url="~/Images/download.png" />
                    </dxe:ASPxButton>
                        </td>
                        <td>
                    <dxe:ASPxButton ID="btnAdd" runat="server" CommandName="Add" 
                                    ToolTip="Добавить">
                        <Image Url="~/Images/add.png" />
                    </dxe:ASPxButton>
                        </td>
                    </tr>
                </table>
                        </td>
                    </tr>
                    <tr ID="Upload1" runat="server" style="visibility: hidden">
                        <td>
                    <dxuc:ASPxUploadControl ID="Upload" runat="server" Width="100%">
                        <UploadButton Text="Загрузить">
                        </UploadButton>
                    </dxuc:ASPxUploadControl>
                        </td>
                    </tr>
            </table>
        </ItemTemplate>
        <PagerSettings>
            <Summary Visible="False" />
        </PagerSettings>
    </dxdv:ASPxDataView>
</asp:Content>