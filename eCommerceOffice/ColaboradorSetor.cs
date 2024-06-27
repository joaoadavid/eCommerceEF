using eCommerceOffice.Models;

namespace eCommerceOffice
{
    public class ColaboradorSetor
    {
        public int Id { get; set; }

        public int ColaboradorId { get; set; }

        public DateTimeOffset Criado { get; set; }

        public int SetorId { get; set; }

        public Colaborador Colaborador { get; set; } = null!;

        public Setor Setor { get; set; } = null!;
    }
}