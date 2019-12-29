<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PleaseVerifyForm.aspx.cs" Inherits="pozicam_web_forms.Forms.PleaseVerifyForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h4 style="margin-top: 80px; margin-bottom: 80px">Váš účet nie je aktivovaný. Na Váš email sme vám odoslali aktivačný link.</h4>
    </div>
    <div>
        <asp:Button Style="margin-left: 20px" ID="btnResend" OnClick="btnResend_Click" Visible="true" runat="server" CssClass="btn btn-info" Text="Znovu odoslať aktivačný email"></asp:Button>
    
    </div>
</asp:Content>
