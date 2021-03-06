﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Data.Objects;

namespace Pet.Data.EF5
{
    public static class Solicitud
    {
        public static IEnumerable<object> ListaSolicitud()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var solicitud = db.GPC_Solicitud
                    .Join(db.CE_Prioridad, a => a.codigo_prioridad, b => b.codigo_prioridad, (a, b) => new { a, b })
                    .Join(db.CE_Estado, c => c.a.codigo_estado, c => c.codigo_estado, (aa, c) => new { aa, c })
                    .Join(db.Empleado, d => d.aa.a.CodigoEmpleado, d => d.CodigoEmpleado, (aaa, d) => new { aaa, d })
                    .Select(x => new
                    {
                        numero_solicitud = x.aaa.aa.a.numero_solicitud,
                        fecha_hora = x.aaa.aa.a.fecha_hora,
                        prioridad = x.aaa.aa.b.descripcion_prioridad,
                        usuario = x.d.Nombres + " " + x.d.ApellidoPaterno,
                        estado = x.aaa.c.descripcion_estado,
                        codigo_solicitud = x.aaa.aa.a.numero_solicitud,
                        codigo_estado = x.aaa.aa.a.codigo_estado
                    })//.Where(x=>  x.codigo_estado != 5)
                    .ToList()
                    .Select(x => new
                    {
                        numero_solicitud = x.numero_solicitud,
                        fecha_hora = x.fecha_hora.Value.ToString("dd-MM-yyyy") + " " + x.fecha_hora.Value.ToShortTimeString(),
                        prioridad = x.prioridad,
                        usuario = x.usuario,
                        estado = x.estado,
                        codigo_solicitud = x.codigo_solicitud,
                        codigo_estado = x.codigo_estado
                    })
                    .ToList();
                return solicitud;
            }
        }

        public static string GuardaSolicitud(Pet.Entity.Solicitud solicitud)
        {
            try
            {
                using (var db = new EFData.PET_DBEntities())
                {
                    if (solicitud.CodigoSolicitud == 0)
                    {
                        //SR000001
                        //var nroSolicitud = db.GPC_Solicitud
                        //               .Select(t => t.numero_solicitud)
                        //               .DefaultIfEmpty(-1)
                        //               .Max();
                        //if (nroSolicitud == -1)
                        //{
                        //    nroSolicitud = 1;
                        //}
                        //else
                        //{
                        //    nroSolicitud += 1;
                        //}
                        //string nroSol = string.Format("{0:000000}", nroSolicitud);
                        //string codigoGenerado = "SR" + nroSol;
                        //solicitud.codigo_solicitud = codigoGenerado;
                        //solicitud.numero_solicitud = nroSolicitud;

                        var _nroSolicitud = new SqlParameter("numero_solicitud", SqlDbType.Int)
                        {
                            Direction = System.Data.ParameterDirection.Output
                        };

                        //SqlParameter _fecha_hora = new SqlParameter()
                        //{
                        //    ParameterName = "fecha_hora",
                        //    DbType = DbType.DateTime,
                        //    Value = solicitud.fecha_hora
                        //};

                      
                        //SqlParameter _codigo_estado = new SqlParameter()
                        //{
                        //    ParameterName = "codigo_estado",
                        //    DbType = DbType.Int32,
                        //    Value = solicitud.codigo_estado
                        //};

                        var _fecha_hora = new SqlParameter("fecha_hora", solicitud.FechaHoraCreacion);
                        SqlParameter _codigo_empleado = new SqlParameter("codigo_empleado", solicitud.CodigoEmpleado1);
                        SqlParameter _codigo_prioridad = new SqlParameter("codigo_prioridad", solicitud.CodigoEmpleado1);
                        SqlParameter _codigo_estado = new SqlParameter("codigo_estado", solicitud.CodigoEmpleado1);

                        db.Database.ExecuteSqlCommand("RegistraSolicitud @fecha_hora, @codigo_empleado, @codigo_prioridad, @codigo_estado, @numero_solicitud out",
                                          _fecha_hora,
                                          _codigo_empleado,
                                          _codigo_prioridad,
                                          _codigo_estado, 
                                          _nroSolicitud
                                          );
                  
                        solicitud.CodigoSolicitud = (int)_nroSolicitud.Value;
                        AddDetalleSolicitud(solicitud);

                        //db.Set<Pet.Entity.GPCSolicitud>().Add(solicitud);
                        //db.SaveChanges();
                    }
                    else
                    {

                        EliminaDetalleSolicitud(solicitud.CodigoSolicitud);

                        db.Database.ExecuteSqlCommand("ActualizaSolicitud @numero_solicitud, @fecha_hora, @codigo_empleado, @codigo_prioridad, @codigo_estado",
                             new SqlParameter("numero_solicitud", solicitud.CodigoSolicitud),
                            new SqlParameter("fecha_hora", solicitud.CodigoSolicitud),
                            new SqlParameter("codigo_empleado", solicitud.CodigoSolicitud),
                            new SqlParameter("codigo_prioridad", solicitud.CodigoSolicitud),
                            new SqlParameter("codigo_estado", solicitud.CodigoSolicitud)
                            );

                        AddDetalleSolicitud(solicitud);
                    }
                }
            }
            catch (DbUpdateException ex)
            {
                UpdateException updateException = (UpdateException)ex.InnerException;
                SqlException sqlException = (SqlException)updateException.InnerException;
                StringBuilder dd = new StringBuilder();
                foreach (SqlError error in sqlException.Errors)
                {
                    dd.Append(error);
                }
                string ddd = dd.ToString();
                throw;
            }
            
            return "OK";
        }

        public static string EliminaSolicitud(Pet.Entity.Solicitud solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                if (solicitud.CodigoSolicitud != 0)
                {
                    //var _solicitud = db.GPC_Solicitud.SingleOrDefault(x => x.numero_solicitud == solicitud.numero_solicitud);
                    //EliminaDetalleSolicitud(solicitud.numero_solicitud);
                    //db.GPC_Solicitud.Attach(_solicitud);
                    //db.GPC_Solicitud.Remove(_solicitud);
                    //db.SaveChanges();

                    db.Database.ExecuteSqlCommand("EliminaSolicitud @numero_solicitud",
                            new SqlParameter("numero_solicitud", solicitud.CodigoSolicitud)
                           );
                }
            }

            return "OK";
        }

        public static void EliminaDetalleSolicitud(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                if (numero_solicitud != 0)
                {

                    var detalle = db.GPC_DetalleDeSolicitud
                    .Select(x => new
                    {
                        x.numero_solicitud,
                        x.item
                    }).Where(x => x.numero_solicitud == numero_solicitud);


                    foreach (var item in detalle)
                    {
                        var _detalle = db.GPC_DetalleDeSolicitud.SingleOrDefault(x => x.numero_solicitud == numero_solicitud && x.item == item.item);
                        db.GPC_DetalleDeSolicitud.Attach(_detalle);
                        db.GPC_DetalleDeSolicitud.Remove(_detalle);
                    }
               
                    db.SaveChanges();
                }
            }
        }

        public static bool EnviaSolicitudAprobar(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                if (numero_solicitud != 0)
                {
                    db.Database.ExecuteSqlCommand("EnviaSolicitud @numero_solicitud",
                            new SqlParameter("numero_solicitud", numero_solicitud)
                           );
                }
            }

            return true;
        }

        public static void AddDetalleSolicitud(Pet.Entity.Solicitud solicitud)
        {
          
            using (var db = new EFData.PET_DBEntities())
            {
                //Add detalle solcitud
                foreach (Pet.Entity.GPCDetalleDeSolicitud item in solicitud.GPC_DetalleDeSolicitud)
                {
                    db.Database.ExecuteSqlCommand("RegistraDetalleSolicitud @item, @cantidad_solicitada, @codigo_recurso, @numero_solicitud",
                                 new SqlParameter("item", item.item),
                                 new SqlParameter("cantidad_solicitada", item.cantidad_solicitada),
                                 new SqlParameter("codigo_recurso", item.codigo_recurso),
                                 new SqlParameter("numero_solicitud", solicitud.CodigoSolicitud)
                                 );
                }
            }
        }

        public static IEnumerable<object> EditarSolicitud(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var solicitud = db.GPC_Solicitud
                    .Select(x => new
                    {
                        numero_solicitud = x.numero_solicitud,
                        fecha_hora = x.fecha_hora,
                        codigo_prioridad = x.codigo_prioridad,
                        codigo_solicitud = x.numero_solicitud,
                        codigo_estado = x.codigo_estado
                    }).Where(x => x.numero_solicitud == numero_solicitud)
                    .ToList()
                    .Select(x => new
                    {
                        numero_solicitud = x.numero_solicitud,
                        fecha_hora =  x.fecha_hora.Value.ToString("dd-MM-yyyy") + " " + x.fecha_hora.Value.ToShortTimeString(),
                        codigo_prioridad = x.codigo_prioridad,
                        codigo_solicitud = x.codigo_solicitud,
                        codigo_estado = x.codigo_estado
                    }).ToList();
                return solicitud;
            }
        }

        public static IEnumerable<object> EditarDetalleSolicitud(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var prioridad = db.GPC_DetalleDeSolicitud
                    .Select(x => new
                    {
                        x.numero_solicitud,
                        x.item,
                        x.cantidad_solicitada,
                        x.codigo_recurso
                    }).Where(x => x.numero_solicitud == numero_solicitud).ToList()
                    .Select(y => new
                    {
                        numero_solicitud = int.Parse(y.numero_solicitud.ToString()),
                        item = int.Parse(y.item.ToString()),
                        cantidad_solicitada = int.Parse(y.cantidad_solicitada.ToString()),
                        codigo_recurso = int.Parse(y.codigo_recurso.ToString())
                    });
                return prioridad;
            }
        }

        public static List<Pet.Entity.EstatusSolicitud> EstadosDeSolicitud(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                SqlParameter _numero_solicitud = new SqlParameter()
                {
                    ParameterName = "numero_solicitud",
                    DbType = DbType.Int32,
                    Value = numero_solicitud
                };

                List<Pet.Entity.EstatusSolicitud> x = db.Database.SqlQuery<Pet.Entity.EstatusSolicitud>("EXEC Estado_Solicitud @numero_solicitud", _numero_solicitud).ToList();
                  
               return x;
            }
       }

        public static string ApruebaRechazaSolicitud(Pet.Entity.Solicitud solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                if (solicitud.CodigoSolicitud != 0)
                {

                    db.Database.ExecuteSqlCommand("aprueba_rechaza_solicitud @numero_solicitud, @codigo_estado",
                            new SqlParameter("numero_solicitud", solicitud.CodigoSolicitud),
                            new SqlParameter("codigo_estado", solicitud.Estado)
                           );
                    //aprueba_detalle_solicitud
                 
                    if (solicitud.Estado ==3)
                    {
                        foreach (Pet.Entity.GPCDetalleDeSolicitud item in solicitud.GPC_DetalleDeSolicitud)
                        {
                            db.Database.ExecuteSqlCommand("aprueba_detalle_solicitud @numero_solicitud, @item, @cantidad_aprobada",
                                        new SqlParameter("numero_solicitud", solicitud.CodigoSolicitud),
                                         new SqlParameter("item", item.item),
                                         new SqlParameter("cantidad_aprobada", item.cantidad_aprobada)
                                         );
                        }
                    }
                }
            }

            return "OK";
        }

        public static IEnumerable<object> ListaDetalleSolicitudAprobar(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var solicitud = db.GPC_DetalleDeSolicitud
                    .Join(db.GPC_Recurso, a => a.codigo_recurso, b => b.codigo_recurso, (a, b) => new { a, b })
                    .Select(x => new
                    {
                        item = x.a.item,
                        codigo_recurso = x.a.codigo_recurso,
                        recurso = x.b.nombre_recurso,
                        cantidad = x.a.cantidad_solicitada,
                        numero_solicitud = x.a.numero_solicitud
                    }).Where(x => x.numero_solicitud == numero_solicitud)
                    .ToList();
                return solicitud;
            }
        }

        //public static IEnumerable<object> NotificarAprobacionORechazo(int numero_solicitud)
        //{
        //    using (var db = new EFData.PET_DBEntities())
        //    {
        //        var solicitud = db.GPC_Solicitud
        //            .Join(db.CE_Empleado, a => a.codigo_aprobador, b => b.codigo_empleado, (a, b) => new { a, b })
        //            .Join(db.CE_Empleado, c => c.a.codigo_empleado, c => c.codigo_empleado, (aa, c) => new { aa, c })
        //            .Select(x => new
        //            {
        //                numero_solicitud = x.aa.a.numero_solicitud,
        //                codigo_solicitud = x.aa.a.codigo_solicitud,
        //                codigo_aprobador  = x.aa.a.codigo_aprobador,
        //                apellido_paternoAprob = x.aa.b.apellido_paterno,
        //                apellido_maternoAprob = x.aa.b.apellido_materno,
        //                nombresAprob = x.aa.b.nombres,
        //                correoAprob = x.aa.b.correo,
        //              //  aprobador = x.aa.b.apellido_paterno + ' ' + x.aa.b.apellido_materno + ' ' + x.aa.b.nombres,

        //                apellido_paterno = x.c.apellido_paterno,
        //                apellido_materno = x.c.apellido_materno,
        //                nombres = x.c.nombres,
        //                correo = x.c.correo
        //                //empleado = x.c.apellido_paterno + ' ' + x.c.apellido_materno + ' ' + x.c.nombres
        //            }).Where(x => x.numero_solicitud == numero_solicitud)
        //            .ToList();
        //        return solicitud.ToList();
        //    }
           
        //}


        public static List<Pet.Entity.CENotificaSolicitud> NotificarAprobacionORechazo(int numero_solicitud)
        {
            using (var db = new EFData.PET_DBEntities())
            {
                SqlParameter _numero_solicitud = new SqlParameter()
                {
                    ParameterName = "numero_solicitud",
                    DbType = DbType.Int32,
                    Value = numero_solicitud
                };
                List<Pet.Entity.CENotificaSolicitud> x = db.Database.SqlQuery<Pet.Entity.CENotificaSolicitud>("EXEC datos_notificacion @numero_solicitud", _numero_solicitud).ToList();
                return x;
            }
        }


        public static IEnumerable<object> ListaSolicitudAprobar()
        {
            using (var db = new EFData.PET_DBEntities())
            {
                var solicitud = db.GPC_Solicitud
                    .Join(db.CE_Prioridad, a => a.codigo_prioridad, b => b.codigo_prioridad, (a, b) => new { a, b })
                    .Join(db.CE_Estado, c => c.a.codigo_estado, c => c.codigo_estado, (aa, c) => new { aa, c })
                    .Join(db.Empleado, d => d.aa.a.CodigoEmpleado, d => d.CodigoEmpleado, (aaa, d) => new { aaa, d })
                    .Select(x => new
                    {
                        numero_solicitud = x.aaa.aa.a.numero_solicitud,
                        fecha_hora = x.aaa.aa.a.fecha_hora,
                        prioridad = x.aaa.aa.b.descripcion_prioridad,
                        usuario = x.d.Nombres + " " + x.d.ApellidoPaterno,
                        estado = x.aaa.c.descripcion_estado,
                        codigo_solicitud = x.aaa.aa.a.numero_solicitud,
                        codigo_estado = x.aaa.aa.a.codigo_estado
                    }).Where(x=>  x.codigo_estado == 2)
                    .ToList()
                    .Select(x => new
                    {
                        numero_solicitud = x.numero_solicitud,
                        fecha_hora = x.fecha_hora.Value.ToString("dd-MM-yyyy") + " " + x.fecha_hora.Value.ToShortTimeString(),
                        prioridad = x.prioridad,
                        usuario = x.usuario,
                        estado = x.estado,
                        codigo_solicitud = x.codigo_solicitud,
                        codigo_estado = x.codigo_estado
                    })
                    .ToList();
                return solicitud;
            }
        }


    }
}
