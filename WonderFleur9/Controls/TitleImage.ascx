<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TitleImage.ascx.cs" Inherits="WonderFleur9.Controls.TitleImage" %>
<%@ Register Assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register assembly="HighslideImage" namespace="Encosia" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "xhtml11.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

<script type="text/javascript" src="Scripts/highslide-full.js"></script>
<link rel="stylesheet" type="text/css" href="Scripts/highslide.css" />


<script type="text/javascript">
    hs.graphicsDir = 'Scripts/graphics/';
    hs.align = 'center';
    hs.transitions = ['expand', 'crossfade'];
    hs.outlineType = 'rounded-white';
    hs.fadeInOut = true;
    hs.dimmingOpacity = 0.75;

    hs.useBox = true;
    hs.width = 640;
    hs.height = 480;

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
</script>

</head>

<body>

<div class="highslide-gallery" >
    <dx:ASPxPanel ID="pnImage" runat="server">
    </dx:ASPxPanel>
    <div style="visibility: collapse; display: none;">
        <dx:ASPxPanel ID="pnGallery" runat="server" Width="0px">
        </dx:ASPxPanel>
    </div>
</div>
</body>
</html>

