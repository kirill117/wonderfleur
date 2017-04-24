<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Galleries.aspx.cs" Inherits="WonderFleur9.Galleries" MasterPageFile="MasterPage.Master" Title="Питомник британских кошек WonderFleur*Ru - Галерея" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script type="text/javascript">
    function setFocus(ctlId) {
        var obj = document.getElementById(ctlId);
        if (obj) { obj.focus(); }
    }

    function scrollTo(ctlId) {
        var obj = document.getElementById(ctlId);
        window.scrollTo(0, obj.offsetTop+100);
    }
</script></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Font-Italic="True" 
        Font-Names="Times New Roman" Font-Size="18pt" ForeColor="#993333" Text="Label"></asp:Label>
    <br />
    <br />
        <dxwgv:ASPxGridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CssFilePath="~/App_Themes/Youthful/{0}/styles.css" CssPostfix="Youthful" 
            onpageindexchanged="GridView1_PageIndexChanged" 
            onrowcommand="GridView1_RowCommand" 
            onstartrowediting="GridView1_StartRowEditing">
            <Templates>
                <EmptyDataRow>
                    <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
                        CommandName="Add" ImageUrl="~/Images/add.png" onclick="cmdNew_Click" 
                        ToolTip="Добавить" 
                        Visible="<%# (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design) %>" />
                </EmptyDataRow>
            </Templates>
            <SettingsBehavior AllowSort="False" />
            <Styles CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
                CssPostfix="Youthful">
                <Header ImageSpacing="5px" SortingImageSpacing="5px">
                </Header>
                <Footer HorizontalAlign="Center">
                </Footer>
                <PagerBottomPanel HorizontalAlign="Center">
                </PagerBottomPanel>
                <LoadingPanel ImageSpacing="10px">
                </LoadingPanel>
            </Styles>
            <SettingsLoadingPanel Text="" />
            <SettingsPager>
                <AllButton ImagePosition="Bottom">
                </AllButton>
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
            <SettingsEditing EditFormColumnCount="1" Mode="Inline" />
            <Columns>
                <dxwgv:GridViewDataTextColumn VisibleIndex="0">
                    <DataItemTemplate>
                        <table cellspacing="1">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="cmdUp" runat="server" AlternateText="Вверх" 
                                        CommandArgument='<%# Eval("Id") %>' CommandName="Up" ImageUrl="~/Images/up.png" 
                                        ToolTip="Вверх" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="cmdDown" runat="server" AlternateText="Вниз" 
                                        CommandArgument='<%# Eval("Id") %>' CommandName="Down" ImageUrl="~/Images/down.png" 
                                        ToolTip="Вниз" />
                                </td>
                            </tr>
                        </table>
                    </DataItemTemplate>
                    <EditItemTemplate>
                        <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text=" ">
                        </dxe:ASPxLabel>
                    </EditItemTemplate>
                </dxwgv:GridViewDataTextColumn>
<dxwgv:GridViewDataTextColumn Caption="Наименование" VisibleIndex="1">
<DataItemTemplate>
                        <dxe:ASPxHyperLink ID="hlName" runat="server" 
                            NavigateUrl='<%# string.Format("~/ShowGallery.aspx?id={0}",Eval("Id")) %>' 
                            Text='<%# Eval("Name") %>' />
                    
</DataItemTemplate>
<EditItemTemplate>
                        <dxe:ASPxTextBox ID="tbName" runat="server" Text='<%# Eval("Name") %>' 
                            Width="100%">
                        </dxe:ASPxTextBox>
                    
</EditItemTemplate>
</dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataTextColumn Caption="Фото" VisibleIndex="2" ReadOnly="True">
                    <EditFormSettings Visible="False" />
                    <DataItemTemplate>
                        <dxe:ASPxImage ID="ASPxImage1" runat="server" 
                            ImageUrl='<%# string.Format("~/GetImageUrl.ashx?id={0}&width={1}", Custom.Data.DataProvider.Gallery.GetTopImageId((int)Eval("Id")), 120) %>'>
                        </dxe:ASPxImage>
                    </DataItemTemplate>
                    <EditItemTemplate>
                        <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Visible="False">
                        </dxe:ASPxLabel>
                    </EditItemTemplate>
                </dxwgv:GridViewDataTextColumn>
                <dxwgv:GridViewDataCheckColumn Caption="Достижение" 
                    Name="Achievement" UnboundType="Boolean" VisibleIndex="3">
                    <DataItemTemplate>
                        <dxe:ASPxCheckBox ID="cbAchiev" runat="server" ReadOnly="True" 
                            Value='<%# Eval("IsAchievement") %>'>
                        </dxe:ASPxCheckBox>
                    </DataItemTemplate>
                    <EditItemTemplate>
                        <dxe:ASPxCheckBox ID="cbAchievEdit" runat="server" 
                            Value='<%# Eval("IsAchievement") %>'>
                        </dxe:ASPxCheckBox>
                    </EditItemTemplate>
                </dxwgv:GridViewDataCheckColumn>
                <dxwgv:GridViewDataTextColumn VisibleIndex="4">
                    <DataItemTemplate>
                        <table cellspacing="1">
                            <tr>
                                <td>
                                    <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Изменить" 
                                        CommandName="Edit" ImageUrl="~/Images/addressbookedit.png" ToolTip="Изменить" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Удалить" 
                                        CommandName="Delete" ImageUrl="~/Images/delete.png" ToolTip="Удалить" 
                                        Visible='<%# Custom.Data.DataProvider.Gallery.CheckForDelete((int)Eval("Id")) %>' />
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
                            </tr>
                        </table>
                    </EditItemTemplate>
                </dxwgv:GridViewDataTextColumn>
            </Columns>
            <StylesPager>
                <PageNumber HorizontalAlign="Center">
                </PageNumber>
                <Summary HorizontalAlign="Center">
                </Summary>
            </StylesPager>
            <StylesEditors>
                <ProgressBar Height="25px">
                </ProgressBar>
            </StylesEditors>
        </dxwgv:ASPxGridView>
    </div>
</asp:Content>


