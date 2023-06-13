using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIoBusiness.Models
{
    public class VendaFormaPagamento
    {
        [Key]
        public int IdVendaFormaPagamento { get; set; }
        public double Valor { get; set; }

        [ForeignKey("Venda")]
        public int IdVenda { get; set; }
        public Venda Venda { get; set; }

        [ForeignKey("FormaPagamento")]
        public int IdFormaPagamento { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}
