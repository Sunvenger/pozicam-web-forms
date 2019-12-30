<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanningToolForm.aspx.cs" Inherits="pozicam_web_forms.Forms.ManagmentTools.PlanningToolForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" Visible="false" ID="formPleaseLogin">
        <h4>Na prístup do tejto sekcie musíte byť administrátor</h4>
    </asp:Panel>
    <asp:Panel runat="server" Visible="false" ID="panelPlanningTool">
        <asp:Table runat="server">
            <asp:TableRow>
                <asp:TableCell VerticalAlign="Bottom">
                    <h4 style="color:lightseagreen">Vitajte </h4>
                </asp:TableCell>
                <asp:TableCell VerticalAlign="Bottom">
                    <asp:Image runat="server" style="margin-left:20px" ImageUrl="~/Images/unlock-64.png" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <hr />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Panel runat="server" ID="panelTaskViewer" Style="max-height: 500px; overflow-y: scroll">
                    <div>
                        <h4 style="color: gray">Úlohy</h4>
                    </div>
                    <asp:GridView runat="server" OnRowDataBound="gvTask_RowDataBound" class="table table-hover" BorderWidth="0" BorderColor="Transparent" AutoGenerateColumns="false" ID="gvTask">
                        <Columns>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:CheckBox AutoPostBack="true" ID="chbTaskSelector" CssClass="ChkBoxClass" runat="server" OnCheckedChanged="chbTaskSelector_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" />
                            <asp:BoundField DataField="Priority" />
                            <asp:BoundField DataField="DeadlineDate" />
                            <asp:BoundField DataField="Cost" ItemStyle-ForeColor="OrangeRed" DataFormatString="€{0:###,###,###.00}" />
                            <asp:BoundField DataField="Rent" ItemStyle-ForeColor="ForestGreen" DataFormatString="€{0:###,###,###.00}" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Button ID="btnCompleteTask" runat="server" class="btn btn-success" OnClick="btnCompleteTask_Click" Text="Dokončiť úlohu" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </asp:Panel>
                <asp:Button runat="server" Visible="false" ID="btnDeleteTask" OnClick="btnDelete_Click" CssClass="btn btn-danger" Text="Vymazať označené"/>
                <hr />
                <asp:Panel runat="server" ID="panelTaskEditor">
                    <asp:Label runat="server" Text="Task editor"></asp:Label>
                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Názov úlohy"></asp:Label>
                        <asp:TextBox runat="server" ID="tbTaskName" CssClass="cssTextBox"></asp:TextBox>
                    </div>

                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Popis"></asp:Label>
                        <asp:TextBox runat="server" ID="tbTaskDescription" CssClass="cssTextBox"></asp:TextBox>
                    </div>

                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Termín dokončenia"></asp:Label>
                        <asp:Calendar CssClass="calendarWrapper" runat="server" ID="calTaskDeadline"></asp:Calendar>
                    </div>

                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Priorita"></asp:Label>
                        <asp:TextBox runat="server" ID="tbTaskPriority" CssClass="cssTextBox"></asp:TextBox>
                    </div>

                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Náklady"></asp:Label>
                        <asp:TextBox runat="server" ID="tbTaskCost" CssClass="cssTextBox"></asp:TextBox>
                    </div>

                    <div style="margin-top: 30px">
                        <asp:Label runat="server" Text="Výnos"></asp:Label>
                        <asp:TextBox runat="server" ID="tbTaskRent" CssClass="cssTextBox"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button runat="server" Visible="false" ID="btnApplyChanges" Text="Upraviť" class="btn btn-success" OnClick="btnApplyChanges_Click" />
                        <asp:Button runat="server" Visible="false" ID="btnAddTask" Text="Vytvoriť novú úlohu" class="btn btn-success" OnClick="btnAddTask_Click" />

                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </asp:Panel>
</asp:Content>
