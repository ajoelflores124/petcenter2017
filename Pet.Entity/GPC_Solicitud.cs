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
    
    public partial class GPC_Solicitud
    {
        public GPC_Solicitud()
        {
            this.GPC_DetalleDeSolicitud = new HashSet<GPC_DetalleDeSolicitud>();
        }
    
        public int numero_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_hora { get; set; }
        public Nullable<int> CodigoEmpleado { get; set; }
        public Nullable<int> codigo_prioridad { get; set; }
        public Nullable<int> codigo_estado { get; set; }
    
        public virtual CE_Estado CE_Estado { get; set; }
        public virtual CE_Prioridad CE_Prioridad { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual ICollection<GPC_DetalleDeSolicitud> GPC_DetalleDeSolicitud { get; set; }
    }
}
