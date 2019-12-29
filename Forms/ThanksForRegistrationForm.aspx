<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ThanksForRegistrationForm.aspx.cs" Inherits="pozicam_web_forms.Forms.ThanksForRegistrationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h4 style="margin-top: 80px; margin-bottom: 80px">Ďakujeme za registráciu. Teraz by Vám mal prísť aktivačný email.</h4>
    </div>
    <div>
        <asp:Button Style="margin-left: 20px" ID="btnLogin" Visible="true" runat="server" CssClass="btn btn-info" Text="Prihlásiť sa"></asp:Button>
    </div>
</asp:Content>
