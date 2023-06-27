using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class NotaFiscal
    {
        public int IdNotaFiscal { get; set; }
        public int NumeroNota { get; set; }
        public DateTime DataEmissao { get; set; }

        [ForeignKey("Venda")]
        public int IdVenda { get; set; }
        public Venda Venda { get; set; }

    }
}
