<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserContext.ascx.cs" Inherits="WonderFleur9.Controls.UserContext" %>
<%@ Register assembly="DevExpress.Web.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>


<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<asp:PlaceHolder ID="plhContent" runat="server" Visible="False">
</asp:PlaceHolder>
<br />
<asp:Panel ID="Panel1" runat="server">
<dx:ASPxButton ID="cmbSave" runat="server" ClientIDMode="AutoID" 
    CssFilePath="~/App_Themes/Red Wine/{0}/styles.css" CssPostfix="RedWine" 
    onclick="cmbSave_Click" SpriteCssFilePath="~/App_Themes/RedWine/{0}/sprite.css" 
    Text="Сохранить">
</dx:ASPxButton>
<dx:ASPxHtmlEditor ID="HtmlEditor" runat="server" 
    ClientIDMode="AutoID" Width="100%">
    <Settings AllowPreview="False" />
    <Toolbars>
        <dx:HtmlEditorToolbar>
            <Items>
                <dx:ToolbarCutButton>
                </dx:ToolbarCutButton>
                <dx:ToolbarCopyButton>
                </dx:ToolbarCopyButton>
                <dx:ToolbarPasteButton>
                </dx:ToolbarPasteButton>
                <dx:ToolbarPasteFromWordButton>
                </dx:ToolbarPasteFromWordButton>
                <dx:ToolbarUndoButton BeginGroup="True">
                </dx:ToolbarUndoButton>
                <dx:ToolbarRedoButton>
                </dx:ToolbarRedoButton>
                <dx:ToolbarRemoveFormatButton BeginGroup="True">
                </dx:ToolbarRemoveFormatButton>
                <dx:ToolbarSuperscriptButton BeginGroup="True">
                </dx:ToolbarSuperscriptButton>
                <dx:ToolbarSubscriptButton>
                </dx:ToolbarSubscriptButton>
                <dx:ToolbarInsertOrderedListButton BeginGroup="True">
                </dx:ToolbarInsertOrderedListButton>
                <dx:ToolbarInsertUnorderedListButton>
                </dx:ToolbarInsertUnorderedListButton>
                <dx:ToolbarIndentButton BeginGroup="True">
                </dx:ToolbarIndentButton>
                <dx:ToolbarOutdentButton>
                </dx:ToolbarOutdentButton>
                <dx:ToolbarInsertLinkDialogButton BeginGroup="True">
                </dx:ToolbarInsertLinkDialogButton>
                <dx:ToolbarUnlinkButton>
                </dx:ToolbarUnlinkButton>
                <dx:ToolbarInsertImageDialogButton>
                </dx:ToolbarInsertImageDialogButton>
                <dx:ToolbarCheckSpellingButton BeginGroup="True">
                </dx:ToolbarCheckSpellingButton>
            </Items>
        </dx:HtmlEditorToolbar>
        <dx:HtmlEditorToolbar>
            <Items>
                <dx:ToolbarParagraphFormattingEdit Width="120px">
                    <Items>
                        <dx:ToolbarListEditItem Text="Normal" Value="p" />
                        <dx:ToolbarListEditItem Text="Heading  1" Value="h1" />
                        <dx:ToolbarListEditItem Text="Heading  2" Value="h2" />
                        <dx:ToolbarListEditItem Text="Heading  3" Value="h3" />
                        <dx:ToolbarListEditItem Text="Heading  4" Value="h4" />
                        <dx:ToolbarListEditItem Text="Heading  5" Value="h5" />
                        <dx:ToolbarListEditItem Text="Heading  6" Value="h6" />
                        <dx:ToolbarListEditItem Text="Address" Value="address" />
                        <dx:ToolbarListEditItem Text="Normal (DIV)" Value="div" />
                    </Items>
                </dx:ToolbarParagraphFormattingEdit>
                <dx:ToolbarFontNameEdit>
                    <Items>
                        <dx:ToolbarListEditItem Text="Times New Roman" Value="Times New Roman" />
                        <dx:ToolbarListEditItem Text="Tahoma" Value="Tahoma" />
                        <dx:ToolbarListEditItem Text="Verdana" Value="Verdana" />
                        <dx:ToolbarListEditItem Text="Arial" Value="Arial" />
                        <dx:ToolbarListEditItem Text="MS Sans Serif" Value="MS Sans Serif" />
                        <dx:ToolbarListEditItem Text="Courier" Value="Courier" />
                    </Items>
                </dx:ToolbarFontNameEdit>
                <dx:ToolbarFontSizeEdit>
                    <Items>
                        <dx:ToolbarListEditItem Text="1 (8pt)" Value="1" />
                        <dx:ToolbarListEditItem Text="2 (10pt)" Value="2" />
                        <dx:ToolbarListEditItem Text="3 (12pt)" Value="3" />
                        <dx:ToolbarListEditItem Text="4 (14pt)" Value="4" />
                        <dx:ToolbarListEditItem Text="5 (18pt)" Value="5" />
                        <dx:ToolbarListEditItem Text="6 (24pt)" Value="6" />
                        <dx:ToolbarListEditItem Text="7 (36pt)" Value="7" />
                    </Items>
                </dx:ToolbarFontSizeEdit>
                <dx:ToolbarBoldButton BeginGroup="True">
                </dx:ToolbarBoldButton>
                <dx:ToolbarItalicButton>
                </dx:ToolbarItalicButton>
                <dx:ToolbarUnderlineButton>
                </dx:ToolbarUnderlineButton>
                <dx:ToolbarStrikethroughButton>
                </dx:ToolbarStrikethroughButton>
                <dx:ToolbarJustifyLeftButton BeginGroup="True">
                </dx:ToolbarJustifyLeftButton>
                <dx:ToolbarJustifyCenterButton>
                </dx:ToolbarJustifyCenterButton>
                <dx:ToolbarJustifyRightButton>
                </dx:ToolbarJustifyRightButton>
                <dx:ToolbarJustifyFullButton>
                </dx:ToolbarJustifyFullButton>
                <dx:ToolbarBackColorButton BeginGroup="True">
                </dx:ToolbarBackColorButton>
                <dx:ToolbarFontColorButton>
                </dx:ToolbarFontColorButton>
            </Items>
        </dx:HtmlEditorToolbar>
    </Toolbars>
    <SettingsHtmlEditing AllowFormElements="True" />
    <SettingsImageUpload UploadImageFolder="~/Images/Content/">
    </SettingsImageUpload>
</dx:ASPxHtmlEditor>
</asp:Panel>