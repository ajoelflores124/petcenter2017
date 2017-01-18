//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Solicitud
    {
        public int CodigoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public int CodigoArea { get; set; }
        public int CodigoTipoMantenimiento { get; set; }
        public int CodigoEmpleado1 { get; set; }
        public Nullable<int> CodigoEmpleado2 { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public Nullable<System.DateTime> FechaHoraActualizacion { get; set; }
        public Nullable<bool> EstadoRegistro { get; set; }
        public int CodigoSede { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Empleado Empleado1 { get; set; }
        public virtual EstadoSolicitud EstadoSolicitud { get; set; }
        public virtual Sede Sede { get; set; }
        public virtual TipoMantenimiento TipoMantenimiento { get; set; }
        public virtual ICollection<GPCDetalleDeSolicitud> GPC_DetalleDeSolicitud { get; set; }
    }
}
