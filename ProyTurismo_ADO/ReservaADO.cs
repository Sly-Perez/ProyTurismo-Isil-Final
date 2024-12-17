using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using ProyTurismo_BE;

namespace ProyTurismo_ADO
{
    public class ReservaADO
    {
        public List<ReservaBE> ListarReservasDepartamentoFechas(String strDepartamento, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                ProyectoTurismoEntities TurismoBaseDatos = new ProyectoTurismoEntities();

                List<ReservaBE> objListaReservaBE = new List<ReservaBE>();


                var query = (
                                (from miReserva in TurismoBaseDatos.Tb_Reserva
                                 join miTour in TurismoBaseDatos.Tb_Tour
                                 on miReserva.ID_Tour equals miTour.ID_Tour
                                 join miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                                 on miTour.ID_Ubicacion equals miUbicacion.ID_Ubicacion
                                 where (miUbicacion.Departamento == strDepartamento) && 
                                 (miReserva.Fec_Res >= fechaIni && miReserva.Fec_Res <= fechaFin)
                                 select new
                                    { 
                                     miReserva.ID_Reserva, miReserva.Fec_Res, 
                                     miTour.ID_Tour, miUbicacion.ID_Ubicacion,
                                     miUbicacion.Departamento, miUbicacion.Provincia,
                                     miUbicacion.Distrito
                                    }).ToList()
                            );

                foreach (var resultado in query)
                {
                    ReservaBE objReservaBE = new ReservaBE();
                    objReservaBE.Id_Reserva = Convert.ToInt16(resultado.ID_Reserva);
                    objReservaBE.Fec_Res = resultado.Fec_Res;
                    objReservaBE.Id_Tour = Convert.ToInt16(resultado.ID_Tour);
                    objReservaBE.Id_Ubicacion = Convert.ToInt16(resultado.ID_Ubicacion);
                    objReservaBE.Departamento = resultado.Departamento;
                    objReservaBE.Provincia = resultado.Provincia;
                    objReservaBE.Distrito = resultado.Distrito;

                    objListaReservaBE.Add(objReservaBE);
                }

                return objListaReservaBE;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ReservaBE> ListarReservasFechas(Int16 Codigo, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                ProyectoTurismoEntities TurismoBaseDatos = new ProyectoTurismoEntities();

                List<ReservaBE> objListaReservaBE = new List<ReservaBE>();


                var query = (
                                (from miTour in TurismoBaseDatos.Tb_Tour
                                 join miReserva in TurismoBaseDatos.Tb_Reserva
                                 on miTour.ID_Tour equals miReserva.ID_Tour
                                 join miFactura in TurismoBaseDatos.Tb_Factura
                                 on miReserva.ID_Reserva equals miFactura.ID_Reserva
                                 join miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                                 on miTour.ID_Ubicacion equals miUbicacion.ID_Ubicacion
                                 where ((miTour.ID_Tour == Codigo) && (miFactura.Fec_Emi >= fechaIni && miFactura.Fec_Emi <= fechaFin))
                                 select new
                                 {
                                     miTour.ID_Tour,
                                     miTour.Est_Tour,
                                     miFactura.Fec_Emi,
                                     miFactura.Total,
                                     miUbicacion.Departamento,
                                     miUbicacion.Provincia,
                                     miUbicacion.Distrito,
                                     miFactura.Met_Pag,
                                     miFactura.ID_Factura
                                 }).ToList()
                            );

                foreach (var resultado in query)
                {
                    ReservaBE objReservaBE = new ReservaBE();
                    objReservaBE.Id_Factura = Convert.ToInt16(resultado.ID_Factura);
                    objReservaBE.Id_Tour = Convert.ToInt16(resultado.ID_Tour);
                    
                    if(resultado.Est_Tour.Equals(0))
                    {
                        objReservaBE.Est_Tour = "Activo";
                    }
                    else
                    {
                        objReservaBE.Est_Tour = "Finalizado";
                    }

                    objReservaBE.Fec_Emi = Convert.ToDateTime(resultado.Fec_Emi);
                    objReservaBE.Total = Convert.ToSingle(resultado.Total);
                    objReservaBE.Departamento = resultado.Departamento;
                    objReservaBE.Provincia = resultado.Provincia;
                    objReservaBE.Distrito = resultado.Distrito;

                    if(resultado.Met_Pag == 0)
                    {
                        objReservaBE.Met_Pag = "Efectivo";
                    }
                    else if(resultado.Met_Pag == 1){
                        objReservaBE.Met_Pag = "Tarjeta de crédito";
                    }
                    else
                    {
                        objReservaBE.Met_Pag = "Tarjeta de débito";
                    }
                    

                    objListaReservaBE.Add(objReservaBE);
                }

                return objListaReservaBE;
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public Single CalcularTotalDepartamentoFechas(String strDepartamento, DateTime fechaIni, DateTime fechaFin)
        {
            try
            {
                ProyectoTurismoEntities TurismoBaseDatos = new ProyectoTurismoEntities();

                Single Total = 0;

                if (strDepartamento == "Todos")
                {
                    Total = Convert.ToSingle(
                                            (from miFactura in TurismoBaseDatos.Tb_Factura
                                             join miReserva in TurismoBaseDatos.Tb_Reserva
                                             on miFactura.ID_Reserva equals miReserva.ID_Reserva
                                             join miTour in TurismoBaseDatos.Tb_Tour
                                             on miReserva.ID_Tour equals miTour.ID_Tour
                                             join miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                                             on miTour.ID_Ubicacion equals miUbicacion.ID_Ubicacion
                                             where (miReserva.Fec_Res >= fechaIni && miReserva.Fec_Res <= fechaFin)
                                             select miFactura.Total).Sum()
                                      );
                }
                else
                {
                    Total = Convert.ToSingle(
                                            (from miFactura in TurismoBaseDatos.Tb_Factura
                                             join miReserva in TurismoBaseDatos.Tb_Reserva
                                             on miFactura.ID_Reserva equals miReserva.ID_Reserva
                                             join miTour in TurismoBaseDatos.Tb_Tour
                                             on miReserva.ID_Tour equals miTour.ID_Tour
                                             join miUbicacion in TurismoBaseDatos.Tb_Ubicacion
                                             on miTour.ID_Ubicacion equals miUbicacion.ID_Ubicacion
                                             where (miUbicacion.Departamento == strDepartamento) &&
                                             (miReserva.Fec_Res >= fechaIni && miReserva.Fec_Res <= fechaFin)
                                             select miFactura.Total).Sum()
                                      );
                }
                return Total;
            }
            catch (EntityException ex)
            {
                throw new Exception (ex.Message);
            }
        }
    }
}
