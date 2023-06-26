using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class CarroAdicionais
    {
        [Key]
        public int IdCarroAdicionais { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Carro")]
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }

        [ForeignKey("Adicionais")]
        public int IdAdicionais { get; set; }
        public Adicionais Adicionais { get; set; }
    }
}
