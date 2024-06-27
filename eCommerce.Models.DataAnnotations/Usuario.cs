using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models
{

    /*
     * 
     * 
     * [Table] = definir o nome da tabela utilizado pela classe
     * [Colum] = definir o nome da coluna utilizado pelas propriedades
     * [NotMapped] = Não mapear determinada propriedade
     * [Foreignkey] = Define que a propriedade é o vinculo da chave estrangeira
     * [InverseProperty] = Definir a referencia para cada FK vinda da mesma tabela
     * [DatabaseGenerated] = definir se uma propriedade vai ou não ser gerenciada pelo banco.
     * [DatabaseGenerated(DatabaseGeneratedOption.Identity ou Computed ou None)]
     * 
     * [DataAnnotations]:
     * [Key] = Definir que a propriedade é uma PK
     * 
     * 
     * EF Core
     * [Index] = definir/Criar Indice no banco (x - Unique).
     */

    /*
     * DataAnnotation, FluentAPI:
     * Code-First -> Code -> DataBase
     * Database-First =  Database -> Code
     */

    [Index(nameof(Email),IsUnique =true, Name = "IXI_EMAIL_UNICO")]
    [Index(nameof(Nome),nameof(CPF),IsUnique =true, Name = "IXI_EMAIL_UNICO")]
    [Table("TB_USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("Id")]
        public int Codigo { get; set; }
        public string Nome { get; set; } = null!;
        
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(15)]
        public string? Sexo { get; set; }
        public string CPF { get; set; } = null!;

        [Column("REGISTRO_GERAL")]
        public string? RG { get; set; }

        public string? NomeMae { get; set; }

        public string? NomePai { get; set; }
        public string? SituacaoCadastro { get; set; }

        //faz com que seja auto incrementado no banco de dados
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Matricula { get; set; }

        //RegistroAtivo = (situaçãoCadastro = "Ativo") ? true : false ;
        //Não precisa ser persistido.
        [NotMapped]
        public bool RegistroAtivo { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset DataCadastro { get; set; } //guarda data hora e fuso

        //mapeia a foreignKey
        [ForeignKey("UsuarioId")]
        public Contato? Contato { get; set; }


        /*
         * 
         * [InverseProperty]
         * 
         * PedidosCompradosPeloCLiente
         * - ClienteId*
         * - ColabroadorId
         * - SupervisorId 
         * 
         * PedidosGerenciadosPeloColaborador
         * - ClienteId
         * - ColabroadorId*
         * - SupervisorId
         * 
         * PedidosSupervisionadosPeloColaboradorSupervisor
         * - ClienteId
         * - ColabroadorId
         * - SupervisorId*
         * 
         */
        public ICollection<EnderecoEntrega>? EnderecosEntrega { get; set; }

        public ICollection<Departamento>? Departamentos { get; set; }

        [InverseProperty("Cliente")]
        public ICollection<Pedido>? PedidosCompradosPeloCliente { get; set; }

        [InverseProperty("Colaborador")]
        public ICollection<Pedido>? PedidosGerenciadosPeloColaborador { get; set; }

        [InverseProperty("Supervisor")]
        public ICollection<Pedido>? PedidosSupervisionadosPeloColaboradorSupervisor { get; set; }
       
    }
}
