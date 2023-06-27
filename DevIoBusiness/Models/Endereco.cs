using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Endereco
    {
        [Key]
        public int IdEndereco { get; private set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

        public Endereco()
        {

        }
    }

}
