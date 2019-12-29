<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanningToolForm.aspx.cs" Inherits="pozicam_web_forms.Forms.ManagmentTools.PlanningToolForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" Visible="false" ID="formPleaseLogin">
        <h4>Na prístup do tejto sekcie musíte byť administrátor</h4>
    </asp:Panel>
    <asp:Panel runat="server" Visible="false" ID="panelPlanningTool">
        <asp:Table runat="server" >
            <asp:TableRow >
                <asp:TableCell VerticalAlign="Bottom">
                    <h4 style="color:lightseagreen">Vitajte </h4>
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Bottom">
                    <asp:Image runat="server" style="margin-left:20px" ImageUrl="~/Images/unlock-64.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>


    </asp:Panel>
</asp:Content>
