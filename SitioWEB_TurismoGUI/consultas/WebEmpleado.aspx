<%@ Page Title="Consulta de Empleados" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebEmpleado.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebEmpleado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta de Empleados
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style>
        .table-header {
            background-color: #007bff;
            color: white;
        }
        .btn-spacing {
            margin-right: 10px;
        }
        .content-card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1 class="text-center">Consulta de Empleados</h1>
    <br />
    <div class="container">
        <div class="card content-card">
            <div class="card-header table-header">
                <h4 class="mb-0">Filtrar Empleados</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="txtIdEmpleado" class="form-label">ID Empleado</label>
                    <asp:TextBox ID="txtIdEmpleado" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDni" class="form-label">DNI</label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlEstado" class="form-label">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Activo" Value="Activo" />
                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                    </asp:DropDownList>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-primary btn-spacing" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
        <br />
        <h3 class="text-center">Empleados Encontrados</h3>
        <asp:GridView ID="gvEmpleados" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID_Empleado" HeaderText="ID" />
                <asp:BoundField DataField="Nom_Emp" HeaderText="Nombre" />
                <asp:BoundField DataField="Ape_Emp" HeaderText="Apellido" />
                <asp:BoundField DataField="Dni_Emp" HeaderText="DNI" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
