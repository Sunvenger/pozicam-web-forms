<%@ Page Title="Domovská stránka" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pozicam_web_forms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron" style="position:relative">

        <asp:Button Style="min-height: 80px" runat="server" PostBackUrl="~/Forms/StoreItemForm.aspx?mode=new" CssClass="btn btn-success" Text="Pridať inzerát"></asp:Button>

        <asp:Button Style="position:absolute; right:20px; min-height: 80px" runat="server" CssClass="btn btn-primary" Text="Chcem si požičiať tovar"></asp:Button>



    </div>

</asp:Content>
