<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StoreItemForm.aspx.cs" Inherits="pozicam_web_forms.Forms.StoreItemForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Font-Size="20" ID="lblHeader" runat="server" Text=""></asp:Label>
    <asp:Panel runat="server" ID="panelNew" Visible="false" CssClass="jumbotron">
        <div>
            <asp:Label runat="server" Text="Kategória"></asp:Label>
            <asp:DropDownList ID="ddCategory" runat="server" CssClass="cssTextBox" type="text" placeholder="Kategória"></asp:DropDownList>
        </div>
        <div style="margin-top: 20px">
            <asp:Label runat="server" Text="Názov položky"></asp:Label>
            <asp:TextBox ID="tbStoreItemName" runat="server" CssClass="cssTextBox" type="text" placeholder="Názov produktu"></asp:TextBox><br>
        </div>
        <div style="margin-top: 20px">
            <asp:Label runat="server" Text="Popis položky"></asp:Label>
            <asp:TextBox TextMode="MultiLine" Height="200" Width="250" Rows="10" ID="tbDescription" runat="server" CssClass="cssTextBoxMulti" type="text" placeholder="Popis produktu"></asp:TextBox><br>
        </div>
        <div>
            <asp:Label runat="server" Text="Fotografia položky"></asp:Label>
            <asp:FileUpload ID="imageUpload" runat="server" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="panelNotLoggedIn" Visible="false" CssClass="jumbotron">
        <div>
            <h4>Pre pridanie nového inzerátu musíte byť prihlásený</h4>
        </div>
    </asp:Panel>


</asp:Content>
