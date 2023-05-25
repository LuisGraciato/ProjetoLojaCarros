using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class CarroCarroAdicionais
    {
        [ForeignKey("Carro")]
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }

        [ForeignKey("CarroAdicionais")]
        public int IdAdicionais { get; set; }
        public CarroAdicionais CarroAdicionais { get; set; }
    }
}
