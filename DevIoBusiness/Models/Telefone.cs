using System.ComponentModel.DataAnnotations;

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

        public Telefone()
        {

        }
    }

}
