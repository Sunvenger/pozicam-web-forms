<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingUpForm.aspx.cs" Inherits="pozicam_web_forms.Forms.SingUpForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Font-Size="20" ID="HeaderLabel" runat="server" Text="Zaregistrujte sa zdarma"></asp:Label>
    <asp:Label Font-Size="20" ID="lblHeader" runat="server" Text=""></asp:Label>
    <asp:Panel runat="server" ID="panelNew" Visible="true" CssClass="jumbotron">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Table runat="server" CellSpacing="10">
                    <asp:TableRow CssClass="cssFormRow">
                        <asp:TableCell>
                        <asp:Label runat="server" Text="Emailová adresa"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox Width="200" Rows="10" ID="tbEmail" runat="server" CssClass="cssTextBox" type="text" placeholder="Email"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lblBadMail" runat="server" Visible="false" Text="Mail už existuje" ForeColor="Red"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow CssClass="cssFormRow">
                        <asp:TableCell>
                        <asp:Label runat="server" Text="Heslo"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox TextMode="Password" Width="150" Rows="10" ID="tbPassword" runat="server" CssClass="cssTextBox" type="text" placeholder="Heslo"></asp:TextBox>
                        </asp:TableCell>

                    </asp:TableRow>

                    <asp:TableRow CssClass="cssFormRow">
                        <asp:TableCell>
                        <asp:Label runat="server" Text="Potvrdenie hesla"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox TextMode="Password" AutoPostBack="true" OnTextChanged="tbPasswordComfirm_TextChanged" Width="150" Rows="10" ID="tbPasswordComfirm" runat="server" CssClass="cssTextBox" type="text" placeholder="Heslo pre potvrdenie"></asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:Label ID="lbPasswordAreSame" runat="server" Visible="false" Text="Heslá sú rovnaké" ForeColor="#339966"></asp:Label>
                            <asp:Label ID="lbPasswordAreNotSame" runat="server" Visible="false" Text="Heslá sa nezhodujú" ForeColor="#ff3300"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
                <asp:Button ID="btnRegistrate" OnClick="btnRegistrate_Click" Style="margin-left: 50px; 80px; min-width: 250px" runat="server" Enabled="false" CssClass="btn btn-success" Text="Zaregistrovať"></asp:Button>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

</asp:Content>
