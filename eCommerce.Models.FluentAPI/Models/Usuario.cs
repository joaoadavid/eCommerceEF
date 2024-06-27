using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? Sexo { get; set; }
        public string CPF { get; set; } = null!;
        public string? RG { get; set; }

        public string? NomeMae { get; set; }

        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }

        public DateTimeOffset DataCadastro { get; set; } //guarda data hora e fuso


        
        public Contato? Contato { get; set; }
        
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }

        public ICollection<Departamento>? Departamentos { get; set; }

        public double preco { get; set; }





    }
}
