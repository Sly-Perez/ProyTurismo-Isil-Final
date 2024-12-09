<%@ Page Title="" Language="C#" MasterPageFile="~/MasterTurismo.Master" AutoEventWireup="true" CodeBehind="WebReservaDepartamento.aspx.cs" Inherits="SitioWEB_TurismoGUI.consultas.WebReservaPorDistrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titulo" runat="server">
    Consulta Reserva
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .auto-style2 {
            width: 259px;
        }
        .auto-style4 {
            width: 252px;
        }
        .auto-style5 {
            width: 310px;
        }
        .auto-style6 {
            width: 259px;
            height: 25px;
        }
        .auto-style7 {
            width: 310px;
            height: 25px;
        }
        .auto-style8 {
            width: 252px;
            height: 25px;
        }
        .auto-style9 {
            height: 25px;
        }
        .auto-style10 {
            width: 259px;
            height: 37px;
        }
        .auto-style11 {
            width: 310px;
            height: 37px;
        }
        .auto-style12 {
            width: 252px;
            height: 37px;
        }
        .auto-style13 {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
    <h1>Reservas por Departamento y Fecha</h1>
    <br />

    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Seleccione Departamento:</td>
            <td class="auto-style5">
                <ajaxToolkit:ComboBox ID="cboDepartamentos" runat="server" AutoPostBack="False" DropDownStyle="DropDownList" AutoCompleteMode="SuggestAppend" CaseSensitive="False" ItemInsertLocation="OrdinalText">
                </ajaxToolkit:ComboBox>
            </td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Fecha Inicio:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtFechaIni" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaIni" CssClass="texto-error" ErrorMessage="Obligatorio"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">Fecha Fin:</td>
            <td>
                <asp:TextBox ID="txtFechaFin" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaFin" CssClass="texto-error" ErrorMessage="Obligatorio"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style11">
                <asp:Button ID="btnConsultar" runat="server" Text="Consultar" CssClass="btn btn-outline-success" OnClick="btnConsultar_Click" />
            </td>
            <td class="auto-style12">Monto Total Generado (s/):</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Width="108px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
            <td class="auto-style8"></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style2">Cantidad de Registros:</td>
            <td class="auto-style5">
                <asp:TextBox ID="txtCantidadReg" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
                </td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grvReservas" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-striped table-dark rounded my-3" OnPageIndexChanging="grvReservas_PageIndexChanging" ShowHeaderWhenEmpty="True" PageSize="5">
                    <Columns>
                        <asp:BoundField DataField="ID_Reserva" HeaderText="Código Reserva" ReadOnly="True" />
                        <asp:BoundField DataField="Fec_Res" DataFormatString="{0:d}" HeaderText="Fecha Reserva" ReadOnly="True" />
                        <asp:BoundField DataField="Departamento" HeaderText="Departamento" ReadOnly="True" />
                        <asp:BoundField DataField="Provincia" HeaderText="Provincia" ReadOnly="True" />
                        <asp:BoundField DataField="Distrito" HeaderText="Distrito" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

     <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
     <asp:Panel ID="pnlMensaje" runat="server" Style="background-color: #8B0000; color: #FFFFFF;" CssClass="contenido-modal shadow-sm p-3 text-center"> 
           <table class="w-50 mx-auto shadow-sm rounded" style="background-color: #fff; 
               color: #000;"> 
               <tr> 
                   <td align="center"> 
                       <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                   </td> 
               </tr> 
                
           </table>
         <div>
             <br />
         </div>
           <div> 
               <asp:Label ID="lblMensajePopup" runat="server" CssClass="text-white"  /> 
           </div> 
         <div>
              <br />
         </div>
           <div> 
               <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CausesValidation="False" CssClass="btn btn-danger" /> 
           </div> 
          <div>
              <br />
         </div>
       </asp:Panel> 
       <ajaxToolkit:modalpopupextender ID="PopMensaje" runat="server" TargetControlID="lnkMensaje" 
           PopupControlID="pnlMensaje" BackgroundCssClass="background-modal" OkControlID="btnAceptar" />

      

</asp:Content>
