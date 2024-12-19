<%@ Page Title="Consulta de Facturación de Clientes" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebCliente.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta de Clientes y Facturación
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 { width: 80%; margin: auto; }
        .auto-style2 { width: 20%; text-align: right; padding-right: 10px; }
        .auto-style3 { width: 80%; }
        .auto-style4 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: var(--bs-body-color);
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-clip: padding-box;
            border-radius: var(--bs-border-radius);
            transition: none;
            background-color: var(--bs-body-bg);
        }
        .auto-style5 {
            --bs-form-select-bg-img: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 16 16'%3e%3cpath fill='none' stroke='%23343a40' stroke-linecap='round' stroke-linejoin='round' stroke-width='2' d='m2 5 6 6 6-6'/%3e%3c/svg%3e");
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: var(--bs-body-color);
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            background-size: 16px 12px;
            border-radius: var(--bs-border-radius);
            transition: none;
            background-color: var(--bs-body-bg);
            background-image: url('var(--bs-form-select-bg-img),var(--bs-form-select-bg-icon,none)');
            background-repeat: no-repeat;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1 class="text-center my-3">Consulta de Clientes por Fechas y Estado</h1>

    <table class="auto-style1 table table-borderless rounded shadow-sm">
        <tr>
            <td class="auto-style2">Fecha Inicio:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtFechaInicio" runat="server" TextMode="Date" CssClass="auto-style4" Width="146px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Fecha Fin:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date" CssClass="auto-style4" Width="141px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>

                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-success mt-3" OnClick="btnConsultar_Click" />
            </td>
            <td>

            <asp:Button ID="btnDescargarExcel" runat="server" Text="Descargar Excel" CssClass="btn btn-primary mt-3" OnClick="btnDescargarExcel_Click" />

            </td>   
        </tr>
    </table>

    <div class="container mt-4">
        <h3>Resultados:</h3>
        <asp:Label ID="lblCantidadFacturas" runat="server" CssClass="text-success"></asp:Label>
        <asp:GridView ID="grvFacturacion" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" OnPageIndexChanging="grvFacturacion_PageIndexChanging">
            <Columns>
                
                <asp:BoundField DataField="NombreCliente" HeaderText="Nombre Cliente" SortExpression="NombreCliente" />
                <asp:BoundField DataField="DNICliente" HeaderText="DNI Cliente" SortExpression="DNICliente" />
                <asp:BoundField DataField="FechaReserva" HeaderText="Fecha Reserva" SortExpression="FechaReserva" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="EstadoReserva" HeaderText="Estado Reserva" SortExpression="EstadoReserva" />
                <asp:BoundField DataField="NombreAlojamiento" HeaderText="Alojamiento" SortExpression="NombreAlojamiento" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoría" SortExpression="Categoria" />
                <asp:BoundField DataField="Tar_Por_Noc" HeaderText="Tarifa Noche" SortExpression="Tar_Por_Noc" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Noches" HeaderText="Noches" SortExpression="Noches" />
                <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total" SortExpression="MontoTotal" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
