using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Funcionario : Pessoa
    {
        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

        [ForeignKey("Telefone")]
        public int IdTelefone { get; set; }
        public Telefone Telefone { get; set; }

        public string Cargo { get; set; }

        public Funcionario()
        {

        }
    }
}
