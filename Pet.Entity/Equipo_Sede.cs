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
    
    public partial class Equipo_Sede
    {
        public Equipo_Sede()
        {
            this.Detalle_Atencion = new HashSet<Detalle_Atencion>();
        }
    
        public int id_equipo { get; set; }
        public string descripcion { get; set; }
        public int CodigoSede { get; set; }
    
        public virtual ICollection<Detalle_Atencion> Detalle_Atencion { get; set; }
        public virtual Sede Sede { get; set; }
    }
}