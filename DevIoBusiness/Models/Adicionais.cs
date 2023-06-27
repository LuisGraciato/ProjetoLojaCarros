using System.ComponentModel.DataAnnotations;

namespace DevIoBusiness.Models
{
    public class Adicionais
    {
        [Key]
        public int IdAdicionais { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public ICollection<CarroAdicionais> CarroAdicionais { get; set; }

    }
}
