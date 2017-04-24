<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCtrlEdit.ascx.cs" Inherits="WonderFleur9.Controls.NewsCtrlEdit" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

    <%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxUploadControl" tagprefix="dxuc" %>

    <%@ Register src="MyDateEdit.ascx" tagname="MyDateEdit" tagprefix="uc1" %>

    <%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>

    <dxwgv:ASPxGridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    Width="100%" CssFilePath="~/App_Themes/Youthful/{0}/styles.css" 
    CssPostfix="Youthful" onrowcommand="GridView1_RowCommand">
    <Templates>
        <EmptyDataRow>
            <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
                CommandName="Add" ImageUrl="~/Images/add.png" onclick="cmdNew_Click" 
                ToolTip="Добавить" />
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
    <SettingsPager Mode="ShowAllRecords" PageSize="1">
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
        <dxwgv:GridViewDataTextColumn VisibleIndex="0" Caption="Заголовок">
            <DataItemTemplate>
                <dxe:ASPxHyperLink ID="Link1" runat="server" Text='<%# Eval("Title") %>' 
                    NavigateUrl='<%# string.Format("~/ContextPage.aspx?ContextId={0}", Eval("ContextId")) %>' />
            </DataItemTemplate>
            <EditItemTemplate>
                <dxe:ASPxTextBox ID="tbTitle" runat="server" Text='<%# Eval("Title") %>' 
                    Width="100%">
                </dxe:ASPxTextBox>
            </EditItemTemplate>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn VisibleIndex="1" Caption="Вступление">
            <DataItemTemplate>
                <dxe:ASPxLabel ID="Label1" runat="server" Text='<%# Eval("Text") %>'>
                </dxe:ASPxLabel>
            </DataItemTemplate>
            <EditItemTemplate>
                <dxe:ASPxMemo ID="tbText" runat="server" Text='<%# Eval("Text") %>' 
                    Width="100%">
                </dxe:ASPxMemo>
            </EditItemTemplate>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn VisibleIndex="2" Caption="Дата" Width="120px">
            <EditCellStyle HorizontalAlign="Center">
            </EditCellStyle>
            <DataItemTemplate>
                <dxe:ASPxLabel ID="Label1" runat="server" Text='<%# Eval("DateSt") %>'>
                </dxe:ASPxLabel>
            </DataItemTemplate>
            <EditItemTemplate>
                <div align="center">
                    <dxe:ASPxDateEdit ID="DateEdit1" runat="server" 
                        Value='<%# Eval("DateSt") %>' Width="100px">
                    </dxe:ASPxDateEdit>
                </div>
            </EditItemTemplate>
            <CellStyle HorizontalAlign="Center">
            </CellStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn VisibleIndex="3" Width="130px" 
            Caption="Изображение">
            <DataItemTemplate>
                <dxe:ASPxBinaryImage ID="Image1" runat="server" 
                    ContentBytes='<%# Eval("ImageBody") %>' Width="120px">
                </dxe:ASPxBinaryImage>
            </DataItemTemplate>
            <EditItemTemplate>
                <dxuc:ASPxUploadControl ID="Upload1" runat="server" Width="100%">
                </dxuc:ASPxUploadControl>
            </EditItemTemplate>
            <CellStyle HorizontalAlign="Center">
            </CellStyle>
        </dxwgv:GridViewDataTextColumn>
        <dxwgv:GridViewDataTextColumn VisibleIndex="4" Width="160px">
            <DataItemTemplate>
                <table cellpadding="1" cellspacing="1">
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
                <table cellpadding="1" cellspacing="1">
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
        </dxwgv:GridViewDataTextColumn>
    </Columns>
    <StylesEditors>
        <ProgressBar Height="25px">
        </ProgressBar>
    </StylesEditors>
</dxwgv:ASPxGridView>


