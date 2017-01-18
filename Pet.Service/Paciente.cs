using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pet.Service
{
    public class Paciente
    {

        public static String obtenerNombre(int idPaciente)
        {

            Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);

            return paciente.nombre;
        }

        public static String obtenerRaza(int idPaciente)
        {
            Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);
            return paciente.raza;
        }

        public static String obtenerTipo(int idPaciente)
        {
            Pet.Data.EF5.EFData.Paciente paciente = Pet.Data.EF5.Paciente.obtenerPacientePorId(idPaciente);
            return paciente.tipo;
        }

    }
}
