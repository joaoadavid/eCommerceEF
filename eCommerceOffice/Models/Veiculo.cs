using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceOffice.Models
{
    public class Veiculo
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Placa { get; set; } = null!;

        public ICollection<Colaborador> Colaboradores { get; set; }
        public ICollection<ColaboradorVeiculo> ColaboradoresVeiculos { get; set; }
    }
}
