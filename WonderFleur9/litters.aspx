<%@ Page Title="Ожидаемые пометы" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="litters.aspx.cs" Inherits="WonderFleur9.litters" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <dxe:ASPxLabel ID="lbTitle" runat="server" Text="Ожидаемые пометы" 
        Font-Italic="True" Font-Names="Georgia" Font-Size="18pt" ForeColor="#993333">
    </dxe:ASPxLabel>
</div>
<div align="center" style="margin-top: 30px">
    <dxwgv:ASPxGridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
        CssPostfix="Youthful" onrowcommand="GridView1_RowCommand">
        <Templates>
            <EmptyDataRow>
                <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
                    CommandName="Add" ImageUrl="~/Images/add.png" 
                    ToolTip="Добавить" 
                    Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>" 
                    onclick="cmdNew_Click" />
            </EmptyDataRow>
        </Templates>
        <Styles CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
            CssPostfix="Youthful">
            <Header ImageSpacing="5px" SortingImageSpacing="5px">
            </Header>
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
        <Columns>
            <dxwgv:GridViewDataTextColumn VisibleIndex="0">
<PropertiesTextEdit>
<ValidationSettings ErrorText="Неверное значение">
<RegularExpression ErrorText="Ошибка проверки регулярного выражения"></RegularExpression>
</ValidationSettings>
</PropertiesTextEdit>
                <DataItemTemplate>
                    <table cellspacing="1">
                        <tr>
                            <td colspan="3" align="center">
                                <dxe:ASPxLabel ID="lbTitle" runat="server" Text='<%# Eval("Comment") %>' 
                                Visible="<%# (Custom.Settings.CurrentUser.Mode != Custom.Settings.UserMode.Design) %>">
                                </dxe:ASPxLabel>
                                <dxe:ASPxMemo ID="tbTitle" runat="server" Height="50px" 
                                    Text='<%# Eval("Comment") %>' Width="100%" 
                                    Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                                </dxe:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dxe:ASPxImage ID="imgFather" runat="server"
                                ImageUrl='<%# string.Format("~/GetImageUrl.ashx?id={0}&width=160",Eval("FatherImageId")) %>'>
                                </dxe:ASPxImage>
                                <br />
                                <dxuc:ASPxUploadControl ID="uploadFather" runat="server"
                                Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                                </dxuc:ASPxUploadControl>
                            </td>
                            <td>
                                <dxe:ASPxImage ID="ASPxImage3" runat="server" ImageUrl="~/Images/hearts.gif" 
                                    Width="100px">
                                </dxe:ASPxImage>
                            </td>
                            <td>
                                <dxe:ASPxImage ID="imgMother" runat="server"
                                ImageUrl='<%# string.Format("~/GetImageUrl.ashx?id={0}&width=160",Eval("MotherImageId")) %>'>
                                </dxe:ASPxImage>
                                <br />
                                <dxuc:ASPxUploadControl ID="uploadMother" runat="server"
                                Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                                </dxuc:ASPxUploadControl>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbFather" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                    Text='<%# Eval("Father") %>' PostBackUrl='<%# (int)Eval("FatherId") > 0 ? string.Format("~/Person.aspx?PersonId={0}",Eval("FatherId")) : string.Empty %>'
                                    Visible="<%# (Custom.Settings.CurrentUser.Mode != Custom.Settings.UserMode.Design) %>">
                                </asp:LinkButton>
                                <dxe:ASPxComboBox ID="cbFather" runat="server" 
                                                Text='<%# Eval("Father") %>' ValueType="System.Int32" 
                                                Value='<%# Eval("FatherId") %>' Width="100%" onload="cbFather_Load"
                                                
                                    Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                                </dxe:ASPxComboBox>
                            </td>
                            <td>
                        <table cellspacing="1" runat="server" id="tblAction" Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Сохранить" 
                                        CommandName="Save" ImageUrl="~/Images/disk.png" ToolTip="Сохранить" />
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
                            </td>
                            <td>
                                <asp:LinkButton ID="lbMother" runat="server" Font-Names="Arial" Font-Size="9pt" 
                                    Text='<%# Eval("Mother") %>' PostBackUrl='<%# (int)Eval("MotherId") > 0 ? string.Format("~/Person.aspx?PersonId={0}",Eval("MotherId")) : string.Empty %>'
                                    Visible="<%# (Custom.Settings.CurrentUser.Mode != Custom.Settings.UserMode.Design) %>">
                                </asp:LinkButton>
                                <dxe:ASPxComboBox ID="cbMother" runat="server" 
                                                Text='<%# Eval("Mother") %>' ValueType="System.Int32" 
                                                Value='<%# Eval("MotherId") %>' Width="100%" onload="cbMother_Load"
                                                
                                    Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>">
                                            </dxe:ASPxComboBox>
                            </td>
                        </tr>
                    </table>
                </DataItemTemplate>
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dxwgv:GridViewDataTextColumn>
        </Columns>
        <Settings GridLines="Horizontal" ShowColumnHeaders="False" />
        <StylesEditors>
            <ProgressBar Height="25px">
            </ProgressBar>
        </StylesEditors>
    </dxwgv:ASPxGridView>
</div>
</asp:Content>
