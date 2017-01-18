using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet.Entity;

namespace Pet.Service
{
    public static class Solicitud
    {
        public static IEnumerable<object> ListaSolicitud()
        {
            return Pet.Data.EF5.Solicitud.ListaSolicitud();
        }

        public static IEnumerable<object> ListaSolicitud(int numeroSolicitud)
        {
            return Pet.Data.EF5.Solicitud.ListaSolicitud(numeroSolicitud);
        }

        public static string GuardaSolicitud(GPC_Solicitud solicitud)
        {

            int nroItem = 1;
            foreach (var item in solicitud.GPC_DetalleDeSolicitud)
            {
                item.item = nroItem++;
            }
                        

            return Pet.Data.EF5.Solicitud.GuardaSolicitud(solicitud);
        }

        public static string EliminaSolicitud(GPC_Solicitud solicitud)
        {
            return Pet.Data.EF5.Solicitud.EliminaSolicitud(solicitud);
        }
    }
}
