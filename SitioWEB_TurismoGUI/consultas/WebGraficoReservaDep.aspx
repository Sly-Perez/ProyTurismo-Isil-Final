<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebGraficoReservaDep.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebGraficoReservaDep" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta Reserva Gráfico
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1>Departamentos más visitados y con mayor monto total generado</h1>
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <asp:GridView ID="grvResultado" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark rounded my-3" PageSize="6" Width="698px">
                    <Columns>
                        <asp:BoundField DataField="Departamento" HeaderText="Departamento" />
                        <asp:BoundField DataField="MontoTotalGenerado" DataFormatString="{0:n}" HeaderText="Monto Total (S/)">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CantidadReservas" HeaderText="Cantidad Reservas">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Chart ID="grafMontoTotal" runat="server" Height="362px" Width="507px">
                    <series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </td>
            <td>
                <asp:Chart ID="grafCantidadReservas" runat="server" Height="354px" Width="528px">
                    <series>
                        <asp:Series Name="Series1">
                        </asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMensajeError" runat="server" CssClass="texto-error"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
