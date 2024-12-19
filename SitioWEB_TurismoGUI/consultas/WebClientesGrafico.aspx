<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebClientesGrafico.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebClientesGrafico" %>


<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta Clientes con Más Reservas
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1>Clientes con Más Reservas y Monto Total Generado</h1>
    
    <!-- Tabla de resultados -->
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <asp:GridView ID="grvResultado" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark rounded my-3" PageSize="6" Width="698px" style="margin-bottom: 0px">
                    <Columns>
                         <asp:BoundField DataField="ID_Cliente" HeaderText="ID del Cliente" />
                        <asp:BoundField DataField="NumeroReservas" HeaderText="Número de Reservas" />
                        <asp:BoundField DataField="MontoTotalGenerado" DataFormatString="{0:n}" HeaderText="Monto Total Generado (S/)" />
                    </Columns>
                </asp:GridView>
                <br />
            </td>
        </tr>

        <!-- Gráficos -->
        <tr>
            <td>
                <asp:Chart ID="grafMontoTotal" runat="server" Height="362px" Width="507px" OnLoad="grafMontoTotal_Load">
                    <series>
                        <asp:Series Name="Series1"></asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </chartareas>
                    <Titles>
                        <asp:Title Name="Monto generado por cliente">
                        </asp:Title>
                    </Titles>
                </asp:Chart>
            </td>
            <td>
                <asp:Chart ID="grafCantidadReservas" runat="server" Height="354px" Width="528px">
                    <series>
                        <asp:Series Name="Series1"></asp:Series>
                    </series>
                    <chartareas>
                        <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                    </chartareas>
                </asp:Chart>
            </td>
        </tr>

        <!-- Mensaje de error si no hay datos -->
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMensajeError" runat="server" CssClass="texto-error"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
