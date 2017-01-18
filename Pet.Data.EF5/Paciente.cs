using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet.Data.EF5
{
     public static class Paciente
    {

        public static Pet.Data.EF5.EFData.Paciente obtenerPacientePorId(int idPaciente)
        {

            using (var db = new EFData.PET_DBEntities())
            {

                Pet.Data.EF5.EFData.Paciente paciente = db.Paciente
                                                                .Where(p => p.id_paciente == idPaciente)
                                                                .SingleOrDefault();

                return paciente;

            }

        }

    }
}
