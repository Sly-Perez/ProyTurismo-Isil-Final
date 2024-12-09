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

        public List<ReservaBE> ListarReservasFechas(DateTime fechaIni, DateTime fechaFin)
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
                                 where (miReserva.Fec_Res >= fechaIni && miReserva.Fec_Res <= fechaFin)
                                 select new
                                 {
                                     miReserva.ID_Reserva,
                                     miReserva.Fec_Res,
                                     miTour.ID_Tour,
                                     miUbicacion.ID_Ubicacion,
                                     miUbicacion.Departamento,
                                     miUbicacion.Provincia,
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
