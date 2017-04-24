<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WonderFleur9.Default" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register src="Controls/Login.ascx" tagname="Login" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta name='yandex-verification' content='60d8f13a87aa064a' />
    <link href="App_Themes/Main/Dafault.css" type="text/css" rel="stylesheet"/>
    <title>Питомник британских кошек WonderFleur*Ru :: Британские короткошерстные кошки :: Продажа котят</title>
</head>
<body bgcolor="Black">
    <form id="form1" runat="server">
    <div class="intro" align="center" style="background-color: #E96F17">
        <img alt="" src="Images/intro.jpg" 
            style="position: static; width: 100%; height:auto" />
        <div align="right" style="position: fixed; right: 30%; top: 30%;">
        
            <table cellspacing="1">
                <tr>
                    <td>
        <dxe:ASPxButton ID="ASPxButton1" runat="server" AllowFocus="False" 
            BackColor="Transparent" EnableDefaultAppearance="False" 
            HorizontalAlign="Center" ImagePosition="Top" ImageSpacing="0px" 
            onclick="ASPxButton1_Click">
            <Paddings Padding="0px" />
            <Border BorderStyle="None" />
            <Image Url="~/Images/bRusG.png" UrlHottracked="~/Images/bRus.png" />
            <FocusRectBorder BorderStyle="None" />
            <FocusRectPaddings Padding="0px" />
        </dxe:ASPxButton>
                    </td>
                    <td width="50">
                    </td>
                    <td>
        <dxe:ASPxButton ID="ASPxButton2" runat="server" AllowFocus="False" 
            BackColor="Transparent" EnableDefaultAppearance="False" 
            HorizontalAlign="Center" ImagePosition="Top" ImageSpacing="0px" 
            onclick="ASPxButton2_Click">
            <Paddings Padding="0px" />
            <Border BorderStyle="None" />
            <Image Url="~/Images/bEngG.png" UrlHottracked="~/Images/bEng.png" />
            <FocusRectBorder BorderStyle="None" />
            <FocusRectPaddings Padding="0px" />
        </dxe:ASPxButton>                    
                  </td>
                </tr>
            </table>
        

        </div>
        <div align="right" style="position: relative; right: 100px; top: -60%;">
            <uc1:Login ID="Login" runat="server" />
        </div>
    </div>
<!-- Yandex.Metrika counter -->
<div style="display:none;"><script type="text/javascript">
(function(w, c) {
    (w[c] = w[c] || []).push(function() {
        try {
            w.yaCounter7155121 = new Ya.Metrika({id:7155121, enableAll: true});
        }
        catch(e) { }
    });
})(window, 'yandex_metrika_callbacks');
</script></div>
<script src="//mc.yandex.ru/metrika/watch.js" type="text/javascript" defer="defer"></script>
<noscript><div><img src="//mc.yandex.ru/watch/7155121" style="position:absolute; left:-9999px;" alt="" /></div></noscript>
<!-- /Yandex.Metrika counter -->
    </form>
</body>
</html>
