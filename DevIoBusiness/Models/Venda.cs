using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Venda
    {
        [Key]
        public int IdVenda { get; set; }
        public double ValorTotal { get; set; }

        [ForeignKey("Funcionario")]
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<VendaFormaPagamento> VendaFormasPagamento { get; set; }
        public ICollection<VendaCarro> CarrosVendidos { get; set; }
        public ICollection<NotaFiscal> NotasFiscais { get; set; }

    }
}
