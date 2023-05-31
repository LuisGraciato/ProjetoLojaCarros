using System.ComponentModel.DataAnnotations;

namespace DevIoBusiness.Models
{
    public abstract class Pessoa
    {
        [Key]
        public int Id { get; private set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

        public List<Endereco> Enderecos{ get; set; }
        public List<Telefone> Telefones { get; set; }

        public Pessoa()
        {

        }
    }
}
