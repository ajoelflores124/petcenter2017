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
    
    public partial class USP_GET_FICHAMANTENIMIENTO_Result
    {
        public int CodigoFichaMantenimiento { get; set; }
        public int CodigoMantenimiento { get; set; }
        public int CodigoSolicitud { get; set; }
        public int CodigoTipoMantenimiento { get; set; }
        public string DescripcionTipoMantenimiento { get; set; }
        public int CodigoEmpleadoAprueba { get; set; }
        public string NombreEmpleadoAprueba { get; set; }
        public int CodigoArea { get; set; }
        public string DescripcionAreaMantenimiento { get; set; }
        public string DescrpcionFichaMantenimiento { get; set; }
        public System.DateTime FechaFichaMantenimiento { get; set; }
        public System.DateTime FechaInicioFichaMantenimiento { get; set; }
        public System.DateTime FechaFinFichaMantenimiento { get; set; }
        public int CantidadTecnicosFichaMantenimiento { get; set; }
        public Nullable<int> CodigoEstadoFichaMantenimiento { get; set; }
        public string DescrpcionEstadoFichaMantenimiento { get; set; }
        public string UsuarioCreacion { get; set; }
        public System.DateTime FechaHoraCreacion { get; set; }
        public string UsuarioActualizacion { get; set; }
        public Nullable<System.DateTime> FechaHoraActualizacion { get; set; }
        public bool EstadoRegistro { get; set; }
        public int CodigoSede { get; set; }
        public string DescripcionSedeMantenimiento { get; set; }
    }
}
