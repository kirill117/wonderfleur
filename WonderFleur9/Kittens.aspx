<%@ Page Title="Питомник британских кошек WonderFleur*Ru - Продажа, стоимость британских котят" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Kittens.aspx.cs" Inherits="WonderFleur9.Kittens" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td align="center" style="color: #800000; font-weight: normal; font-size: 18px; font-family: Georgia; font-style: italic;" valign="top">
                <asp:Label ID="Label1" runat="server" Text="Label" Font-Names="Times New Roman" 
                    Font-Size="18pt"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxGridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    CssFilePath="~/App_Themes/Youthful/{0}/styles.css" CssPostfix="Youthful" 
                    onrowcommand="GridView1_RowCommand" 
                    onpageindexchanged="GridView1_PageIndexChanged">
                    <Templates>
                        <EmptyDataRow>
                            <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
                                CommandName="Add" ToolTip="Добавить" 
                                Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>"  
                                ImageUrl="~/Images/add.png" onclick="cmdNew_Click"/>
                        </EmptyDataRow>
                    </Templates>
                    <Styles CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                        CssPostfix="Youthful">
                        <Header ImageSpacing="5px" SortingImageSpacing="5px">
                        </Header>
                        <PagerBottomPanel HorizontalAlign="Center">
                        </PagerBottomPanel>
                        <LoadingPanel ImageSpacing="10px">
                        </LoadingPanel>
                    </Styles>
                    <SettingsLoadingPanel Text="" />
                    <SettingsPager>
                        <Summary Visible="False" />
                    </SettingsPager>
                    <Images ImageFolder="~/App_Themes/Youthful/{0}/">
                        <CollapsedButton Height="15px" 
                            Url="~/App_Themes/Youthful/GridView/gvCollapsedButton.png" Width="15px" />
                        <ExpandedButton Height="15px" 
                            Url="~/App_Themes/Youthful/GridView/gvExpandedButton.png" Width="15px" />
                        <FilterRowButton Height="13px" Width="13px" />
                        <CustomizationWindowClose Height="13px" Width="13px" />
                        <PopupEditFormWindowClose Height="13px" Width="13px" />
                        <FilterBuilderClose Height="13px" Width="13px" />
                    </Images>
                    <SettingsEditing Mode="Inline" />
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="0">
                            <DataItemTemplate>
                    <table>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    
                                    
                                    ImageUrl='<%# string.Format("~/GetImageUrl.ashx?id={0}&height=160",Eval("ImageId")) %>' 
                                    AlternateText=" " 
                                    PostBackUrl='<%# string.Format("~/ShowGallery.aspx?id={0}",Eval("GalleryId")) %>' />
                                    <br />
                                    <br />
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbSex" runat="server" Text='<%# Eval("SexSt") %>' 
                                                Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbColor" runat="server" 
                                                Text='<%# Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Color" : "Окрас" %>'></asp:Label>
                                            <asp:Label ID="lbColorValue" runat="server" Text='<%# Eval("Color") %>' 
                                                Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbFather" runat="server" 
                                                Text='<%# Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Father" : "Отец" %>'></asp:Label>
                                            <br />
                                            <dx:ASPxHyperLink ID="hlFather" runat="server" NavigateUrl='<%# (int)Eval("FatherId") > 0 ? string.Format("~/Person.aspx?PersonId={0}",Eval("FatherId")) : string.Empty %>' Text='<%# Eval("Father") %>' />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbMother" runat="server" 
                                                Text='<%# Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Mother" : "Мать" %>'></asp:Label>
                                            <br />
                                            <dx:ASPxHyperLink ID="hlMother" runat="server" NavigateUrl='<%# (int)Eval("MotherId") > 0 ? string.Format("~/Person.aspx?PersonId={0}",Eval("MotherId")) : string.Empty %>' Text='<%# Eval("Mother") %>' />
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbAge" runat="server" 
                                                Text='<%# Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Born" : "Родился" %>'></asp:Label>
                                            <asp:Label ID="lbAgeValue" runat="server" Text='<%# Eval("DateBirth") %>' 
                                                Font-Bold="True" Font-Italic="True"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbPomet" runat="server" 
                                                Text='<%# Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Litter" : "Помет" %>'></asp:Label>
                                            <asp:Label ID="lbPometValue" runat="server" Font-Bold="True" 
                                                Font-Italic="True" Text='<%# Eval("Comment") %>'></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" valign="middle">
                                <dx:ASPxLabel ID="lbComment" runat="server" Text='<%# Eval("Titul") %>'>
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                    </table>
                            </DataItemTemplate>
                            <EditItemTemplate>
                    <table>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:ImageButton ID="ImageButton1" runat="server" 
                                    
                                    ImageUrl='<%# string.Format("~/GetImageUrl.ashx?id={0}&height=120",Eval("ImageId")) %>' 
                                    AlternateText=" " 
                                    PostBackUrl='<%# string.Format("~/ShowGallery.aspx?id={0}",Eval("GalleryId")) %>' />
                                <br />
                                <br />
                                <dxuc:ASPxUploadControl ID="Upload1" runat="server" Width="100%">
                                </dxuc:ASPxUploadControl>
                                <br />
                                <dx:ASPxMemo ID="tbComment" runat="server" Height="71px" 
                                    Text='<%# Eval("Titul") %>' Width="100%">
                                </dx:ASPxMemo>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            Пол
                                            <dx:ASPxComboBox ID="cbSex" runat="server" Value='<%# Eval("Sex") %>' 
                                                ValueType="System.Int32" Width="90px">
                                                <Items>
                                                    <dx:ListEditItem Text="Кот" Value="0" />
                                                    <dx:ListEditItem Text="Кошка" Value="1" />
                                                </Items>
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Цвет
                                            <dx:ASPxTextBox ID="tbColor" runat="server" Text='<%# Eval("Color") %>' 
                                                Width="100%">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Отец&nbsp;<dx:ASPxComboBox ID="cbFather" runat="server" DropDownStyle="DropDown" 
                                                Text='<%# Eval("Father") %>' ValueType="System.Int32" 
                                                Value='<%# Eval("FatherId") %>' Width="300px" onload="cbFather_Load">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Мать&nbsp;<dx:ASPxComboBox ID="cbMother" runat="server" DropDownStyle="DropDown" 
                                                Text='<%# Eval("Mother") %>' ValueType="System.Int32" 
                                                Value='<%# Eval("MotherId") %>' Width="300px" onload="cbMother_Load">
                                            </dx:ASPxComboBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Родился
                                            <dx:ASPxDateEdit ID="cbDate" runat="server" Value='<%# Eval("DateBirth") %>' 
                                                Width="100px">
                                            </dx:ASPxDateEdit>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Помет<dx:ASPxTextBox ID="tbPomet" runat="server" Text='<%# Eval("Comment") %>' 
                                                Width="100%">
                                            </dx:ASPxTextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                            </EditItemTemplate>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="1">
                            <DataItemTemplate>
                                <table cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Изменить" 
                                                CommandName="Edit" ImageUrl="~/Images/addressbookedit.png" ToolTip="Изменить" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Удалить" 
                                                CommandName="Delete" ImageUrl="~/Images/delete.png" ToolTip="Удалить" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="cmdAdd" runat="server" AlternateText="Добавить" 
                                                CommandName="Add" ImageUrl="~/Images/add.png" ToolTip="Добавить" />
                                        </td>
                                    </tr>
                                </table>
                            </DataItemTemplate>
                            <EditItemTemplate>
                                <table cellspacing="1">
                                    <tr>
                                        <td>
                                            <asp:ImageButton ID="cmdSave" runat="server" AlternateText="Сохранить" 
                                                CommandName="Update" ImageUrl="~/Images/disk.png" ToolTip="Сохранить" />
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="cmdCancel" runat="server" AlternateText="Отмена" 
                                                CommandName="Cancel" ImageUrl="~/Images/delete.png" ToolTip="Отмена" />
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </EditItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowColumnHeaders="False" />
                    <StylesEditors>
                        <ProgressBar Height="25px">
                        </ProgressBar>
                    </StylesEditors>
                </dx:ASPxGridView>
            </td>
        </tr>
    </table>
    <div>
        <h5 style="font-family: Calibri; color: #FF9966">
            Стоимость британских котят, и любую другую интересующую вас информацию вы можете узнать в разделе <a href="ContextPage.aspx?contextId=10">Контакты...</a>
        </h5>
    </div>
</asp:Content>
