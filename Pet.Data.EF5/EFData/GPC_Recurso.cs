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
