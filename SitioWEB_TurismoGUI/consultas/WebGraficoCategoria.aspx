<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebGraficoCategoria.aspx.cs" Inherits="TuProyecto.WebGraficoCategoria" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Gráfico de Categorías y Tarifa
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style>
        .auto-style1 {
            width: 80%;
            margin: auto;
            border-collapse: collapse;
        }
        .auto-style1 th, .auto-style1 td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .auto-style1 th {
            background-color: #f2f2f2;
            text-align: left;
        }
        .table-container {
            margin: 20px 0;
        }
        .grafico-container {
            display: flex;
            justify-content: space-around;
            margin: 20px 0;
        }
        .grafico-container div {
            flex: 1;
            margin: 0 10px;
        }
        .chartTitle {
            text-align: center;
            font-size: 18px;
            margin-bottom: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1 class="text-center">Gráfico de Categorías y Tarifas</h1>

    <div class="table-container">
        <table class="auto-style1">
            <tr>
                <th>Categoria</th>
                <th>Tarifa por Noche</th>
                <th>Características</th>
            </tr>
            <asp:Repeater ID="rptDatos" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Des_Cat") %></td>
                        <td><%# Eval("Tar_Por_Noc") %></td>
                        <td><%# Eval("Caracteristicas") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <div class="grafico-container">
        <div>
            <h3 class="chartTitle">Tarifas por Noche</h3>
            <asp:Chart ID="chartTarifaPorNoche" runat="server" Width="500px" Height="400px">
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1" />
                </ChartAreas>
                <Legends>   
                    <asp:Legend Name="Legend1" />
                </Legends>
                <Series>
                    <asp:Series Name="Tarifas" ChartType="Column" LegendText="Tarifas por Noche" />
                </Series>
            </asp:Chart>
        </div>

        <div>
            <h3 class="chartTitle">Características</h3>
           <asp:Chart ID="chartCaracteristicas" runat="server" Width="600px" Height="400px">
    <ChartAreas>
        <asp:ChartArea Name="ChartArea2">
            <AxisX>
                <LabelStyle Angle="-45" />
            </AxisX>
        </asp:ChartArea>
    </ChartAreas>
    <Legends>
        <asp:Legend Name="Legend2" />
    </Legends>
    <Series>
        <asp:Series Name="Caracteristicas" ChartType="Pie" LegendText="Características" />
    </Series>
</asp:Chart>

        </div>
    </div>
</asp:Content>
