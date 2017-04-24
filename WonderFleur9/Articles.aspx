<%@ Page Title="Питомник британских кошек WonderFleur*Ru - Полезные статьи" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="WonderFleur9.Articles" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.2, Version=11.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
    <asp:Label ID="Label1" runat="server" Font-Italic="True" 
        Font-Names="Times New Roman" Font-Size="18pt" ForeColor="#993333" 
        Text="Полезные статьи"></asp:Label>
        <br />
        <br />
    <br />
    <asp:GridView ID="list" runat="server" AutoGenerateColumns="False" 
    onrowcancelingedit="list_RowCancelingEdit" onrowcommand="list_RowCommand" 
    onrowdeleting="list_RowDeleting" onrowediting="list_RowEditing" 
    onrowupdating="list_RowUpdating" ShowHeader="False">
    <RowStyle Height="25px" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="cmdUp" runat="server" AlternateText="Вверх" 
                    CommandName="Up" ImageUrl="~/Images/up.png" ToolTip="Вверх" 
                    CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="cmdDown" runat="server" AlternateText="Вниз" 
                    CommandName="Down" ImageUrl="~/Images/down.png" ToolTip="Вниз" 
                    CommandArgument='<%# Eval("Id") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <EditItemTemplate>
                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Title") %>' 
                    Width="99%"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" 
                    CommandArgument='<%# Eval("ContextId") %>' CommandName="ContextEdit" 
                    Text='<%# Eval("Title") %>'></asp:LinkButton>
            </ItemTemplate>
            <ItemStyle Width="300px" />
        </asp:TemplateField>
        <asp:TemplateField>
            <EditItemTemplate>
                <asp:ImageButton ID="cmdSave" runat="server" AlternateText="Сохранить" 
                    CommandName="Update" ImageUrl="~/Images/disk.png" ToolTip="Сохранить" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:ImageButton ID="cmdEdit" runat="server" AlternateText="Изменить" 
                    CommandName="Edit" ImageUrl="~/Images/addressbookedit.png" ToolTip="Изменить" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <EditItemTemplate>
                <asp:ImageButton ID="cmdCancel" runat="server" AlternateText="Отмена" 
                    CommandName="Cancel" ImageUrl="~/Images/delete.png" ToolTip="Отмена" />
            </EditItemTemplate>
            <ItemTemplate>
                <asp:ImageButton ID="cmdDelete" runat="server" AlternateText="Удалить" 
                    CommandName="Delete" ImageUrl="~/Images/delete.png" ToolTip="Удалить" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="cmdAdd" runat="server" AlternateText="Добавить" 
                    CommandName="Add" ImageUrl="~/Images/add.png" ToolTip="Добавить" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <EmptyDataTemplate>
        <asp:ImageButton ID="cmdNew" runat="server" AlternateText="Добавить" 
            CommandName="Add" ToolTip="Добавить" />
    </EmptyDataTemplate>
</asp:GridView>
</div>
</asp:Content>
