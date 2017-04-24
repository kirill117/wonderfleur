<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PersonCart.ascx.cs" Inherits="WonderFleur9.Controls.PersonCart" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>
<%@ Register src="TitleImage.ascx" tagname="TitleImage" tagprefix="uc1" %>
<%@ Register src="UserContext.ascx" tagname="UserContext" tagprefix="uc2" %>

<table width="100%">
    <tr>
        <td align="center" colspan="2">
            <dx:ASPxLabel ID="lbTitul" runat="server" Text="ASPxLabel" Font-Bold="False" 
                Font-Italic="True" Font-Names="Georgia" Font-Size="14pt" 
                ForeColor="#993333">
            </dx:ASPxLabel>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2" height="50">
            <dx:ASPxLabel ID="lbName" runat="server" Font-Bold="False" Font-Size="18px" 
                ForeColor="Black" Text="ASPxLabel" Font-Italic="True" 
                Font-Names="Georgia,Times New Roman" Font-Underline="False">
            </dx:ASPxLabel>
        </td>
    </tr>
    <tr>
        <td width="200px">
        <div align="left">
            <uc1:TitleImage ID="TitleImage1" runat="server" />
         </div>   
         <br />
         <div id="Gallery" align="center">
            <dx:ASPxButton ID="cmbGallery" runat="server" AllowFocus="False" Text="Галерея">
            </dx:ASPxButton>
         </div>
         </td>
        <td align="left" valign="top" width="100%">
            <table id="tblPersonView" runat="server" visible="false">
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbDateBirth" runat="server" Text="Родился">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbDateBirthValue" runat="server" Text="ASPxLabel">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbMother" runat="server" Text="Мать">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxHyperLink ID="hlMother" runat="server" Text="ASPxHyperLink" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbFather" runat="server" Text="Отец">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxHyperLink ID="hlFather" runat="server" Text="ASPxHyperLink" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbOwner" runat="server" Text="Заводчик">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbOwnerValue" runat="server" Text="ASPxLabel">
                        </dx:ASPxLabel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <dx:ASPxLabel ID="lbColor" runat="server" Text="Окрас">
                        </dx:ASPxLabel>
                    </td>
                    <td>
                        <dx:ASPxLabel ID="lbColorValue" runat="server" Text="ASPxLabel">
                        </dx:ASPxLabel>
                    </td>
                </tr>
            </table>

            <table id="tblPersonEdit" runat="server"
                style="font-family: Tahoma; font-size: small;" visible="false">
                <tr>
                    <td>
                        Кличка (русский)</td>
                    <td>
                        <dx:ASPxTextBox ID="EditName_ru" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Кличка (english)</td>
                    <td>
                        <dx:ASPxTextBox ID="EditName_en" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Титул (русский)</td>
                    <td>
                        <dx:ASPxTextBox ID="EditTitul_ru" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="400px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Титул (english)</td>
                    <td>
                        <dx:ASPxTextBox ID="EditTitul_en" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="400px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Дата рождения</td>
                    <td>
                        <dx:ASPxDateEdit ID="DateEdit" runat="server" AllowMouseWheel="False" 
                            ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="100px">
                            <DropDownButton>
                                <Image>
                                </Image>
                            </DropDownButton>
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
                <tr>
                    <td>
                        Мать</td>
                    <td>
                        <dx:ASPxComboBox ID="EditMother" runat="server" ClientIDMode="AutoID" 
                            DropDownStyle="DropDown" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" 
                            ValueType="System.Int32" Width="250px">
                            <DropDownButton>
                                <Image>
                                  </Image>
                            </DropDownButton>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Отец</td>
                    <td>
                        <dx:ASPxComboBox ID="EditFather" runat="server" ClientIDMode="AutoID" 
                            DropDownStyle="DropDown" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" 
                            ValueType="System.Int32" Width="250px">
                            <DropDownButton>
                                <Image>
                                </Image>
                            </DropDownButton>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Заводчик</td>
                    <td>
                        <dx:ASPxTextBox ID="EditOwner" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Окрас</td>
                    <td>
                        <dx:ASPxTextBox ID="EditColor" runat="server" ClientIDMode="AutoID" 
                            SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" Width="250px">
                        </dx:ASPxTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Активен</td>
                    <td>
                        <dx:ASPxCheckBox ID="cbxVeteran" runat="server" Text=" ">
                        </dx:ASPxCheckBox>
                    </td>
                </tr>
                <tr align="center">
                    <td align="center" colspan="2">
                        <dx:ASPxButton ID="cmbSave" runat="server" onclick="cmbSave_Click" 
                            Text="Сохранить">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>

        </td>
    </tr>
    <tr>
        <td colspan="1" align="center">
        </td>
        <td align="center">
            &nbsp;</td>
    </tr>
    <tr>
        <td colspan="2" width="100%" align="justify">
            <uc2:UserContext ID="UserContext1" runat="server" />
        </td>
    </tr>
</table>

