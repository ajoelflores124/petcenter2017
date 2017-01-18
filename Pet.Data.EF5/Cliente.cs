using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pet.Data.EF5
{
    public static class Cliente
    {

        public static Pet.Data.EF5.EFData.Cliente obtenerClientePorId(int idCliente)
        {

            using (var db = new EFData.PET_DBEntities())
            {

                Pet.Data.EF5.EFData.Cliente cliente = db.Cliente
                                                                .Where(c => c.id_cliente == idCliente)
                                                                .SingleOrDefault();

                return cliente;

            }

        }


    }
}
