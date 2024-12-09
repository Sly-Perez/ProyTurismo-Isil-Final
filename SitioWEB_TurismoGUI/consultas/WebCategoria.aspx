<%@ Page Title="Consulta de Categorías" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebCategoriaConsulta.aspx.cs" Inherits="TuProyecto.CategoriaConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta de Categorías
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
    <h1 class="text-center">Consulta de Categorías</h1>
    <br />
    <div class="container">
        <div class="card content-card">
            <div class="card-header table-header">
                <h4 class="mb-0">Filtrar Categorías</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label for="txtIDCategoria" class="form-label">ID Categoría</label>
                    <asp:TextBox ID="txtIDCategoria" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="txtTarifa" class="form-label">Tarifa por Noche</label>
                    <asp:TextBox ID="txtTarifa" runat="server" CssClass="form-control" TextMode="Number" />
                </div>
                <div class="mb-3">
                    <label for="txtCaracteristicas" class="form-label">Características</label>
                    <asp:TextBox ID="txtCaracteristicas" runat="server" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label for="ddlEstado" class="form-label">Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Activo" Value="Activo" />
                        <asp:ListItem Text="Inactivo" Value="Inactivo" />
                    </asp:DropDownList>
                </div>
                <div class="text-center">
                    <asp:Button ID="btnConsultar" runat="server" CssClass="btn btn-primary btn-spacing" Text="Consultar" OnClick="btnConsultar_Click" />
                </div>
            </div>
        </div>
        <br />
        <h3 class="text-center">Categorías Encontradas</h3>
        <asp:GridView ID="gvCategorias" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID_Categoria" HeaderText="ID" />
                <asp:BoundField DataField="Des_Cat" HeaderText="Descripción" />
                <asp:BoundField DataField="Tar_Por_Noc" HeaderText="Tarifa por Noche" />
                <asp:BoundField DataField="Caracteristicas" HeaderText="Características" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
