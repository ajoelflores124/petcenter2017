//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pet.Data.EF5.EFData
{
    using System;
    using System.Collections.Generic;
    
    public partial class GPC_HistoricoDeSolicitud
    {
        public int codigo_historia { get; set; }
        public string numero_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_operacion { get; set; }
        public int CodigoEmpleado { get; set; }
        public Nullable<int> codigo_estado { get; set; }
    }
}