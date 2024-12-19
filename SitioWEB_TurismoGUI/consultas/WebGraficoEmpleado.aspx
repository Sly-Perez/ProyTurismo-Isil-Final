<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebGraficoEmpleado.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebGraficoEmpleado" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Estadísticas de Empleados
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style>
        .auto-style1 {
            width: 80%;
            margin: auto;
        }
        .table-container {
            margin: 20px 0;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1 class="text-center">Estadísticas de Empleados</h1>
    <div class="table-container">
        <asp:GridView ID="gvEmpleadosEstadisticas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-dark rounded my-3" PageSize="6">
            <Columns>
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
            </Columns>
        </asp:GridView>
    </div>

    <table class="auto-style1">
        <tr>
            <td>
                <asp:Chart ID="grafEmpleadosPorEstado" runat="server" Height="400px" Width="500px">
                    <Series>
                        <asp:Series Name="Empleados" ChartType="Pie">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" Title="Estado" />
                    </Legends>
                </asp:Chart>
            </td>
            <td>
                <asp:Chart ID="grafEmpleadosPorRol" runat="server" Height="400px" Width="500px">
                    <Series>
                        <asp:Series Name="Roles">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Title="Rol" />
                            <AxisY Title="Cantidad" />
                        </asp:ChartArea>
                    </ChartAreas>
                    <Legends>
                        <asp:Legend Name="Legend1" Title="Rol" />
                    </Legends>
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
