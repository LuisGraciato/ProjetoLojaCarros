using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Telefone
    {
        [Key]
        public int IdTelefone { get; private set; }
        public string Numero { get; set; }
        public string DDD { get; set; }
        public string DDI { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }


        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        public Telefone()
        {

        }
    }

}
