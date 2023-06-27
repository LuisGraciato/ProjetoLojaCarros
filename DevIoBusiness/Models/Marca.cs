using System.ComponentModel.DataAnnotations;

namespace DevIoBusiness.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; private set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

        public ICollection<Modelo> Modelos { get; set; }

        public Marca()
        {
        }

    }

}
