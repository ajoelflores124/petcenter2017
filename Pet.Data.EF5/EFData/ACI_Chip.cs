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
    
    public partial class ACI_Chip
    {
        public ACI_Chip()
        {
            this.ACI_Chip_OrdenAtencion = new HashSet<ACI_Chip_OrdenAtencion>();
        }
    
        public int idChip { get; set; }
        public string nombreChip { get; set; }
        public string estado { get; set; }
    
        public virtual ICollection<ACI_Chip_OrdenAtencion> ACI_Chip_OrdenAtencion { get; set; }
    }
}