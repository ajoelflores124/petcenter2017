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
    
    public partial class Examen
    {
        public Examen()
        {
            this.Comprobante_Examen = new HashSet<Comprobante_Examen>();
            this.Detalle_Atencion = new HashSet<Detalle_Atencion>();
        }
    
        public int id_tipo_examen { get; set; }
        public string tipo_examen { get; set; }
        public Nullable<System.DateTime> fecha_creacion { get; set; }
    
        public virtual ICollection<Comprobante_Examen> Comprobante_Examen { get; set; }
        public virtual ICollection<Detalle_Atencion> Detalle_Atencion { get; set; }
    }
}