<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCtrlView.ascx.cs" Inherits="WonderFleur9.Controls.NewsCtrlView" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxNewsControl" tagprefix="dxnc" %>
<dxnc:ASPxNewsControl ID="NewsControl1" runat="server" BackColor="Transparent" 
        CssFilePath="~/App_Themes/Youthful/{0}/styles.css" CssPostfix="Youthful" 
        ImageFolder="~/App_Themes/Youthful/{0}/" LoadingPanelImagePosition="Bottom" 
        Width="100%">
        <ItemDateStyle Spacing="10px">
        </ItemDateStyle>
        <ItemSettings DateHorizontalPosition="OutsideLeft" 
            TailPosition="KeepWithLastWord">
            <TailImage Align="Bottom" Height="11px" 
                Url="~/App_Themes/Youthful/Web/hlTailImage.png" Width="16px" />
        </ItemSettings>
        <LoadingPanelStyle ImageSpacing="3px">
        </LoadingPanelStyle>
        <ItemLeftPanelStyle Spacing="7px">
        </ItemLeftPanelStyle>
        <LoadingPanelImage Url="~/App_Themes/Youthful/Web/tcLoading.gif" />
        <PagerSettings>
        <AllButton>
            <Image Height="15px" Width="21px" />
        </AllButton>
        <FirstPageButton Text="">
            <Image Height="15px" Width="21px" />
        </FirstPageButton>
        <LastPageButton ImagePosition="Left" Text="">
            <Image Height="15px" Width="21px" />
        </LastPageButton>
        <NextPageButton Text="">
            <Image Height="15px" Width="16px" />
        </NextPageButton>
        <PrevPageButton Text="">
            <Image Height="15px" Width="16px" />
        </PrevPageButton>
        <Summary AllPagesText="" Text="" />
        </PagerSettings>
        <ItemRightPanelStyle Spacing="7px">
        </ItemRightPanelStyle>
        <ItemHeaderStyle Spacing="2px">
        </ItemHeaderStyle>
</dxnc:ASPxNewsControl>