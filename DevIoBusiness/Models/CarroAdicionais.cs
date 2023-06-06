using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class CarroAdicionais
    {
        [ForeignKey("Carro")]
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }

        [ForeignKey("Adicionais")]
        public int IdAdicionais { get; set; }
        public Adicionais Adicionais { get; set; }
    }
}
