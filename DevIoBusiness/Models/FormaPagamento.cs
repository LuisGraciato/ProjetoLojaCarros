using System.ComponentModel.DataAnnotations;

namespace DevIoBusiness.Models
{
    public class FormaPagamento
    {
        [Key]
        public int IdFormaPagamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<VendaFormaPagamento> VendaFormasPagamento { get; set; }
    }

}
