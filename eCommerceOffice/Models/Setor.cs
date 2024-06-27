using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceOffice.Models
{
    public class Setor
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public ICollection<ColaboradorSetor> ColaboradoresSetores { get; set; } = null!;
    }
}
