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
    
    public partial class GPC_DetalleDeSolicitud
    {
        public int item { get; set; }
        public Nullable<double> cantidad_solicitada { get; set; }
        public Nullable<double> cantidad_aprobada { get; set; }
        public Nullable<double> cantidad_atendida { get; set; }
        public Nullable<int> codigo_recurso { get; set; }
        public int numero_solicitud { get; set; }
    
        public virtual GPC_Recurso GPC_Recurso { get; set; }
        public virtual GPC_Solicitud GPC_Solicitud { get; set; }
    }
}
