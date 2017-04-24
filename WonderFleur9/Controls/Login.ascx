<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="WonderFleur9.Controls.Login" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<div>
    <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" 
        BackColor="#E5EECF" HeaderText="Авторизация" Width="200px" 
        CssFilePath="~/App_Themes/Youthful/{0}/styles.css" CssPostfix="Youthful">
        <BottomRightCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpBottomRight.png" Width="8px" />
        <ContentPaddings Padding="6px" PaddingBottom="6px" PaddingTop="4px" />
        <NoHeaderTopRightCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpNoHeaderTopRight.png" 
            Width="8px" />
        <HeaderRightEdge>
            <BackgroundImage 
                ImageUrl="~/App_Themes/Youthful/Web/rpHeaderLeftEdge.gif" 
                VerticalPosition="bottom" />
        </HeaderRightEdge>
        <Border BorderStyle="None" />
        <HeaderLeftEdge>
            <BackgroundImage 
                ImageUrl="~/App_Themes/Youthful/Web/rpHeaderLeftEdge.gif" 
                VerticalPosition="bottom" />
        </HeaderLeftEdge>
        <HeaderStyle BackColor="#D3E4A6">
        <Paddings PaddingBottom="13px" PaddingTop="0px" />
        <BorderBottom BorderStyle="None" />
        </HeaderStyle>
        <TopRightCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpTopRight.png" Width="8px" />
        <HeaderContent>
            <BackgroundImage 
                ImageUrl="~/App_Themes/Youthful/Web/rpHeaderSeparator.gif" Repeat="RepeatX" 
                VerticalPosition="bottom" />
        </HeaderContent>
        <NoHeaderTopLeftCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpNoHeaderTopLeft.png" Width="8px" />
        <PanelCollection>
<dxp:PanelContent runat="server">
    <br />
    <dxe:ASPxTextBox ID="ASPxTextBox1" runat="server" 
        ForeColor="Black" Password="True" Width="100%">
    </dxe:ASPxTextBox>
            </dxp:PanelContent>
</PanelCollection>
        <TopLeftCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpTopLeft.png" Width="8px" />
        <BottomLeftCorner Height="8px" 
            Url="~/App_Themes/Youthful/Web/rpBottomLeft.png" Width="8px" />
    </dxrp:ASPxRoundPanel>
</div>