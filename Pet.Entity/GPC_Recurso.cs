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
    
    public partial class GPC_Recurso
    {
        public GPC_Recurso()
        {
            this.GPC_DetalleDeSolicitud = new HashSet<GPC_DetalleDeSolicitud>();
        }
    
        public int codigo_recurso { get; set; }
        public string nombre_recurso { get; set; }
        public string unidad_medida { get; set; }
        public string unidad_compra { get; set; }
        public Nullable<decimal> precio_unitario { get; set; }
        public string moneda { get; set; }
    
        public virtual ICollection<GPC_DetalleDeSolicitud> GPC_DetalleDeSolicitud { get; set; }
    }
}
