using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class VendaCarro
    {
        [Key]
        public int IdVendaCarro { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Venda")]
        public int IdVenda { get; set; }
        public Venda Venda { get; set; }

        [ForeignKey("Carro")]
        public int IdCarro { get; set; }
        public Carro Carro { get; set; }
    }
}
